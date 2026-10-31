using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiscImageStudio.BluRay;
using DiscImageStudio.Burning;
using DiscImageStudio.Cd;
using DiscImageStudio.Core;
using DiscImageStudio.Core.Calibration;
using DiscImageStudio.Dvd;
using DiscImageStudio.Services;

namespace DiscImageStudio.ViewModels;

public partial class BurnViewModel : ObservableObject
{
    private readonly ShellViewModel _shell;
    private readonly DiscParametersState _state;
    private readonly DesignViewModel _design;
    private readonly IOpticalDiscBurner _opticalDiscBurner;
    private CancellationTokenSource? _burnCancellation;
    private int _burnWriteSpeedRefreshRevision;
    private int _burnPreparationRevision;
    private string? _sourceIdentity;
    private bool _isPreparingBurn;

    [ObservableProperty]
    private IReadOnlyList<OpticalBurnDevice>? _devices;

    [ObservableProperty]
    private OpticalBurnDevice? _selectedDevice;

    [ObservableProperty]
    private string _deviceStatusText = "[EN]Recorder。";

    [ObservableProperty]
    private IReadOnlyList<BurnWriteSpeedOption> _speeds = [BurnWriteSpeedOption.Automatic];

    [ObservableProperty]
    private BurnWriteSpeedOption? _selectedSpeed = BurnWriteSpeedOption.Automatic;

    [ObservableProperty]
    private bool _isSpeedComboEnabled;

    [ObservableProperty]
    private bool _isSpeedRefreshEnabled;

    [ObservableProperty]
    private string _speedStatusText = "[EN]Disc Media[EN]；[EN]，[EN]Error[EN]。";

    [ObservableProperty]
    private bool _useCalibrationPattern;

    [ObservableProperty]
    private string _sourceTitle = "[EN]";

    [ObservableProperty]
    private string _sourceDetails = "[EN]";

    [ObservableProperty]
    private bool _confirmChecked;

    [ObservableProperty]
    private string _burnStatusText = "[EN]";

    [ObservableProperty]
    private double _burnProgressValue;

    [ObservableProperty]
    private bool _isBurnRunning;

    public BurnViewModel(ShellViewModel shell, DiscParametersState state, DesignViewModel design)
        : this(shell, state, design, new WindowsImapiBurner())
    {
    }

    internal BurnViewModel(ShellViewModel shell, DiscParametersState state, DesignViewModel design,
        IOpticalDiscBurner opticalDiscBurner)
    {
        _shell = shell;
        _state = state;
        _design = design;
        _opticalDiscBurner = opticalDiscBurner;
        RefreshDevicesCommand = new RelayCommand(() => _ = RefreshDevicesAsync(), () => !_shell.IsBusy);
        RefreshSpeedsCommand = new RelayCommand(() => _ = RefreshWriteSpeedsAsync(), () => !_shell.IsBusy);
        StartBurnCommand = new AsyncRelayCommand(() => StartStreamBurnAsync(), CanStartBurn);
        CancelBurnCommand = new RelayCommand(CancelStreamBurn, () => IsBurnRunning);
        _shell.BusyChanged += () =>
        {
            InvalidateConfirmation();
            OnPropertyChanged(nameof(IsSetupEnabled));
            RefreshDevicesCommand.NotifyCanExecuteChanged();
            RefreshSpeedsCommand.NotifyCanExecuteChanged();
            StartBurnCommand.NotifyCanExecuteChanged();
            CancelBurnCommand.NotifyCanExecuteChanged();
        };
        // The disc family is derived from the burn source (project family, or the calibration
        // target's family), so a project switch or a new target has to re-derive and re-arm.
        _shell.PropertyChanged += (_, args) =>
        {
            if (args.PropertyName is nameof(ShellViewModel.IsProjectOpen)
                or nameof(ShellViewModel.CurrentProject))
            {
                OnFamilyInputsChanged();
            }
        };
        _state.PropertyChanged += (_, args) =>
        {
            if (args.PropertyName == nameof(DiscParametersState.CdDataDirectory)
                && !UseCalibrationPattern
                && _shell.CurrentProject?.Family == OpticalDiscFamily.CompactDisc)
            {
                OnFamilyInputsChanged();
            }
        };
        PropertyChanged += (_, args) =>
        {
            if (args.PropertyName is nameof(IsBurnRunning))
            {
                CancelBurnCommand.NotifyCanExecuteChanged();
            }
        };
    }

    public RelayCommand RefreshDevicesCommand { get; }

    public RelayCommand RefreshSpeedsCommand { get; }

    public IAsyncRelayCommand StartBurnCommand { get; }

    public RelayCommand CancelBurnCommand { get; }

    public bool IsSetupEnabled => !_shell.IsBusy && !_isPreparingBurn;

    /// <summary>Exposed for the view's two-way bindings to the shared parameters, so the page
    /// can bind this view model directly like every other workspace page.</summary>
    public DiscParametersState State => _state;

    /// <summary>Workspace navigation for the page's cross-workspace links.</summary>
    public IRelayCommand<Workspace> NavigateCommand => _shell.NavigateCommand;

    /// <summary>Disc family of the material about to be written: the calibration target's
    /// family while burning a target, otherwise the open project's family. Deriving it removes
    /// the old manual switch, which could be left on the wrong family and then failed at start
    /// with only a hint line to explain why.</summary>
    public bool IsDvdBurn => UseCalibrationPattern
        ? _shell.Calibration.Target?.Parameters.Kind == CalibrationDiscKind.Dvd
        : _shell.CurrentProject?.IsDvd ?? false;

    public bool IsBluRayBurn => UseCalibrationPattern
        ? _shell.Calibration.Target?.Parameters.Kind == CalibrationDiscKind.BluRay
        : _shell.CurrentProject?.IsBluRay ?? false;

    /// <summary>Family chip in the page header; follows the material being written.</summary>
    public string FamilyLabel => UseCalibrationPattern
        ? _shell.Calibration.Target?.Parameters.Kind switch
        {
            CalibrationDiscKind.Dvd => "DVD",
            CalibrationDiscKind.BluRay => "BD",
            _ => "CD",
        }
        : _shell.CurrentProject?.FamilyLabel ?? "CD";

    private OpticalBurnMediaKind CurrentMediaKind => IsBluRayBurn
        ? OpticalBurnMediaKind.BluRayData
        : IsDvdBurn
            ? OpticalBurnMediaKind.DvdData
            : !UseCalibrationPattern && !string.IsNullOrWhiteSpace(_state.CdDataDirectory)
                ? OpticalBurnMediaKind.CdData : OpticalBurnMediaKind.CdAudio;

    /// <summary>Device→speeds→confirm gating: not busy, device chosen, checkbox ticked.</summary>
    private bool CanStartBurn()
        => !_shell.IsBusy
            && !_isPreparingBurn
            && SelectedDevice is not null
            && ConfirmChecked;

    private void InvalidateConfirmation()
    {
        _burnPreparationRevision++;
        ConfirmChecked = false;
        UpdateActionState();
    }

    partial void OnSelectedDeviceChanged(OpticalBurnDevice? value)
    {
        InvalidateConfirmation();
        _ = RefreshWriteSpeedsAsync();
    }

    partial void OnSelectedSpeedChanged(BurnWriteSpeedOption? value)
    {
        InvalidateConfirmation();
        UpdateActionState();
    }

    partial void OnConfirmCheckedChanged(bool value) => UpdateActionState();

    partial void OnUseCalibrationPatternChanged(bool value) => OnFamilyInputsChanged();

    /// <summary>A source change (project switch, calibration target, calibration switch) moves
    /// the derived family, so confirmation, summary and speeds all have to re-derive.</summary>
    public void OnCalibrationTargetChanged() => OnFamilyInputsChanged();

    private void OnFamilyInputsChanged()
    {
        OnPropertyChanged(nameof(IsDvdBurn));
        OnPropertyChanged(nameof(IsBluRayBurn));
        OnPropertyChanged(nameof(FamilyLabel));
        InvalidateConfirmation();
        UpdateSourceSummary();
        UpdateActionState();
        _ = RefreshWriteSpeedsAsync();
    }

    public void UpdateSourceSummary()
    {
        string identity;
        if (UseCalibrationPattern)
        {
            CalibrationTarget? target = _shell.Calibration.Target;
            if (target is null)
            {
                SourceTitle = "[EN]calibration[EN]";
                SourceDetails = "[EN]Assisted Calibration[EN]，[EN]Burn。";
                identity = "calibration:none";
            }
            else
            {
                CalibrationParameters p = target.Parameters;
                SourceTitle = $"calibration[EN] · {FamilyLabel} · {target.Id[..8]}";
                string encoding = p.Kind switch
                {
                    CalibrationDiscKind.BluRay => $"Bit Length {p.LinearDensity:0.######} nm · "
                        + (p.BluRayInvertMapping ? "Invert 3T/6T" : "Standard 3T/6T")
                        + $" · [EN] LBA {p.DrawingStartSector}–{(p.DrawingEndSectorExclusive == 0 ? p.Sectors : p.DrawingEndSectorExclusive) - 1}",
                    CalibrationDiscKind.Dvd => $"Bit Length {p.LinearDensity:0.######} nm",
                    _ => $"Linear Velocity {p.LinearDensity:0.######} mm/s · "
                        + (_shell.Calibration.CdInterleave ? "Delayed interleaving" : "[EN]interleaving"),
                };
                SourceDetails = $"[EN] {p.InnerRadiusMm:0.######}–{p.OuterRadiusMm:0.######} mm"
                    + $" · {p.Sectors} sectors · {encoding}\n"
                    + "[EN]calibration[EN]。";
                identity = $"calibration:{target.Id}:{p}:{_shell.Calibration.CdInterleave}";
            }
        }
        else if (IsDvdBurn)
        {
            string dataSuffix = string.IsNullOrWhiteSpace(_state.DvdDataDirectory)
                ? string.Empty
                : _state.DvdFilesAtOuterRing ? "；Files located at Outer Ring，[EN]" : "；Files located at Inner Ring，[EN]";
            SourceTitle = _design.HasLayers
                ? "[EN]"
                : "[EN]Design[EN]Import[EN]";
            SourceDetails = _design.HasLayers
                ? "[EN]" + dataSuffix
                : "[EN]。" + dataSuffix;
            identity = string.Join("\u001f", "dvd", _design.CompositeRevision, _state.DvdTotalSectors,
                _state.DvdInnerRadius, _state.DvdOuterRadius,
                _state.DvdPitchLinear, _state.DvdPitchQuadratic, _state.DvdPitchCubic,
                _state.DvdDataDirectory, _state.DvdVolumeLabel, _state.DvdFilesAtOuterRing,
                _state.ToneDitherStrength, _state.ToneBrightness, _state.ToneSrgbLinearization);
        }
        else if (IsBluRayBurn)
        {
            string dataSuffix = string.IsNullOrWhiteSpace(_state.BdDataDirectory)
                ? string.Empty
                : _state.BdFilesAtOuterRing ? "；Files located at Outer Ring，[EN]" : "；Files located at Inner Ring，[EN]";
            SourceTitle = _design.HasLayers
                ? "[EN]"
                : "[EN]Design[EN]Import[EN]";
            string polarity = _state.BdInvertMapping ? "Invert 3T/6T" : "Standard 3T/6T";
            SourceDetails = _design.HasLayers
                ? $"[EN] · {polarity}" + dataSuffix
                : $"[EN]。 · {polarity}" + dataSuffix;
            identity = string.Join("\u001f", "bd", _design.CompositeRevision, _state.BdTotalSectors,
                _state.BdInnerRadius, _state.BdOuterRadius, _state.BdDataDirectory,
                _state.BdVolumeLabel, _state.BdInvertMapping, _state.BdFilesAtOuterRing,
                _state.ToneDitherStrength, _state.ToneBrightness, _state.ToneSrgbLinearization);
        }
        else
        {
            SourceTitle = _design.HasLayers
                ? "[EN]"
                : "[EN]Design[EN]Import[EN]";
            // The encoding is part of the material actually written, and the burn page has
            // no switch of its own: surfacing it here keeps the streamed bytes explainable.
            string encoding = string.IsNullOrWhiteSpace(_state.CdDataDirectory)
                ? _state.CdInterleave ? "CD audio track · [EN]Delayed interleaving" : "CD audio track · [EN]interleaving"
                : $"CD Data Disc · Files located at {(_state.CdFilesAtOuterRing ? "Outer Ring" : "Inner Ring")}";
            SourceDetails = _design.HasLayers
                ? $"[EN] · {encoding}"
                : $"[EN]。 · {encoding}";
            identity = string.Join("\u001f", "cd", _design.CompositeRevision, _state.CdSectors,
                _state.CdInnerRadius, _state.CdOuterRadius, _state.CdInterleave,
                _state.CdDataDirectory, _state.CdVolumeLabel, _state.CdFilesAtOuterRing,
                _state.ToneDitherStrength, _state.ToneLevels, _state.ToneBrightness,
                _state.ToneSrgbLinearization);
        }

        if (!string.Equals(identity, _sourceIdentity, StringComparison.Ordinal))
        {
            _sourceIdentity = identity;
            InvalidateConfirmation();
        }
    }

    private void UpdateActionState() => StartBurnCommand.NotifyCanExecuteChanged();

    internal async Task RefreshDevicesAsync()
    {
        if (_shell.IsBusy)
        {
            return;
        }

        Devices = null;
        DeviceStatusText = "[EN]Recorder…";
        try
        {
            IReadOnlyList<OpticalBurnDevice> devices =
                await _opticalDiscBurner.GetDevicesAsync();
            Devices = devices;
            SelectedDevice = devices.Count == 0 ? null : devices[0];
            DeviceStatusText = devices.Count == 0
                ? "[EN] IMAPI2 [EN] CD/DVD/BD Recorder。"
                : $"[EN] {devices.Count} [EN]Recorder";
        }
        catch (Exception exception)
        {
            Devices = null;
            SelectedDevice = null;
            DeviceStatusText = "[EN]Recorderfailed：" + exception.Message;
        }
        finally
        {
            UpdateActionState();
        }
    }

    internal async Task RefreshWriteSpeedsAsync()
    {
        if (_shell.IsBusy)
        {
            return;
        }

        int revision = ++_burnWriteSpeedRefreshRevision;
        OpticalWriteSpeed? previousSpeed = SelectedSpeed?.Speed;
        Speeds = [BurnWriteSpeedOption.Automatic];
        SelectedSpeed = BurnWriteSpeedOption.Automatic;

        if (SelectedDevice is not OpticalBurnDevice device)
        {
            IsSpeedComboEnabled = false;
            IsSpeedRefreshEnabled = false;
            SpeedStatusText = "[EN]Recorder。";
            return;
        }

        OpticalBurnMediaKind mediaKind = CurrentMediaKind;
        IsSpeedComboEnabled = false;
        IsSpeedRefreshEnabled = false;
        SpeedStatusText = "[EN]Disc Media[EN]Burn[EN]…";
        try
        {
            IReadOnlyList<OpticalWriteSpeed> speeds =
                await _opticalDiscBurner.GetSupportedWriteSpeedsAsync(
                    device.Id,
                    mediaKind);
            if (revision != _burnWriteSpeedRefreshRevision)
            {
                return;
            }

            List<BurnWriteSpeedOption> options = [BurnWriteSpeedOption.Automatic];
            options.AddRange(speeds.Select(speed => new BurnWriteSpeedOption(
                speed,
                FormatBurnWriteSpeed(speed, mediaKind))));
            Speeds = options;
            int selectedIndex = previousSpeed is null
                ? 0
                : options.FindIndex(option => option.Speed == previousSpeed);
            SelectedSpeed = selectedIndex < 0 ? options[0] : options[selectedIndex];
            SpeedStatusText = speeds.Count == 0
                ? "[EN]Disc Media[EN]，[EN]Burn[EN]。"
                : $"[EN]Disc Media[EN] {speeds.Count} [EN]；[EN] "
                    + $"{FormatBurnWriteSpeed(speeds[0], mediaKind)}，[EN]Recorder[EN]。";
        }
        catch (Exception exception)
        {
            if (revision == _burnWriteSpeedRefreshRevision)
            {
                SpeedStatusText =
                    "[EN]Disc Media[EN]，[EN]Burn[EN]：" + exception.Message;
            }
        }
        finally
        {
            if (revision == _burnWriteSpeedRefreshRevision)
            {
                IsSpeedComboEnabled = true;
                IsSpeedRefreshEnabled = true;
            }
        }
    }

    private static string FormatBurnWriteSpeed(
        OpticalWriteSpeed speed,
        OpticalBurnMediaKind mediaKind)
    {
        string rotation = speed.RotationTypeIsPureCav ? " · CAV" : string.Empty;
        return $"{speed.GetMultiplier(mediaKind):0.#}×"
            + $" · {speed.GetMegabytesPerSecond(mediaKind):0.0} MB/s{rotation}";
    }

    private async Task StartStreamBurnAsync()
    {
        if (_shell.IsBusy)
        {
            _shell.ShowToast("[EN]", "[EN]。", ToastKind.Info);
            return;
        }

        bool ownsBusyState = false;
        _isPreparingBurn = true;
        OnPropertyChanged(nameof(IsSetupEnabled));
        UpdateActionState();
        try
        {
            if (SelectedDevice is not OpticalBurnDevice device)
            {
                throw new ArgumentException("Please select Recorder。");
            }

            if (!ConfirmChecked)
            {
                throw new ArgumentException("[EN]Burn[EN]。");
            }

            bool dvd = IsDvdBurn;
            bool bluRay = IsBluRayBurn;
            bool calibration = UseCalibrationPattern;
            int preparationRevision = _burnPreparationRevision;
            OpticalBurnMediaKind mediaKind = CurrentMediaKind;
            BurnWriteSpeedOption selectedWriteSpeed = SelectedSpeed ?? BurnWriteSpeedOption.Automatic;
            OpticalBurnRequest request;
            string contentDescription;
            if (calibration)
            {
                CalibrationTarget target = _shell.Calibration.Target
                    ?? throw new ArgumentException("[EN]Assisted Calibration[EN]。");
                bool interleave = _shell.Calibration.CdInterleave;
                if (!_shell.Calibration.EnsureSessionSavedForBurn())
                {
                    return;
                }

                if (!ReferenceEquals(target, _shell.Calibration.Target)
                    || interleave != _shell.Calibration.CdInterleave)
                {
                    throw new InvalidOperationException("calibration[EN]，[EN]Save[EN]Burn。");
                }

                request = CreateCalibrationBurnRequest(target, interleave, device.Id, selectedWriteSpeed.Speed);
                string family = target.Parameters.Kind switch
                {
                    CalibrationDiscKind.Dvd => "DVD",
                    CalibrationDiscKind.BluRay => "BD",
                    _ => "CD",
                };
                contentDescription = $"{family} calibration[EN] · {target.Id[..8]}"
                    + $" · {target.Parameters.Sectors} sectors · {request.ContentLength / (1024.0 * 1024.0):F1} MiB";
            }
            else
            {
                // Streaming burns the same export-quality composite the file path writes, so
                // what the read-back preview verified is the material that lands on the disc.
                string compositePath = await _design.EnsureExportCompositeAsync();
                if (bluRay)
                {
                    BluRayDiscParameters disc = ReadBluRayParameters();
                    string dataDirectory = _state.BdDataDirectory.Trim();
                    BluRayIsoPlan plan = BluRayIsoGenerator.PrepareDrawing(
                        disc,
                        dataDirectory.Length == 0 ? null : dataDirectory,
                        string.IsNullOrWhiteSpace(_state.BdVolumeLabel)
                            ? "BD_IMAGE"
                            : _state.BdVolumeLabel.Trim(),
                        filesAtOuterRing: dataDirectory.Length != 0 && _state.BdFilesAtOuterRing);
                    ToneProfile tone = _state.BluRayTone;
                    bool invert = _state.BdInvertMapping;
                    request = new OpticalBurnRequest(
                        device.Id,
                        OpticalBurnMediaKind.BluRayData,
                        plan.ContentLength,
                        (output, cancellationToken) =>
                        {
                            BluRayGray8Raster raster = BluRayImageLoader.Load(
                                compositePath, tone, cancellationToken);
                            BluRayImagePayloadMapping mapping = new(
                                disc, raster, new BluRayRunLengthMapping(invert));
                            BluRayIsoGenerator.GenerateToStream(
                                output, plan, mapping, progress: null, cancellationToken);
                        },
                        selectedWriteSpeed.Speed);
                    contentDescription = $"BD-R · {disc.TotalSectors} sectors"
                        + $" · {plan.ContentLength / (1024.0 * 1024.0):F1} MiB"
                        + $" · [EN] LBA {plan.DrawingStartSector}–{plan.DrawingEndSectorExclusive - 1}"
                        + (plan.HasFileSystem ? $" · [EN]：{(_state.BdFilesAtOuterRing ? "Outer Ring" : "Inner Ring")}" : string.Empty)
                        + (invert ? " · Invert 3T/6T" : " · Standard 3T/6T");
                }
                else if (dvd)
                {
                    DvdStreamingOptions options = ReadDvdStreamingOptions();
                    string dataDirectory = _state.DvdDataDirectory.Trim();
                    DvdHybridStreamingPlan? hybridPlan = dataDirectory.Length == 0
                        ? null
                        : DvdStreamingGenerator.PrepareHybrid(
                            dataDirectory,
                            options,
                            string.IsNullOrWhiteSpace(_state.DvdVolumeLabel)
                                ? "DISC_IMAGE"
                                : _state.DvdVolumeLabel.Trim(),
                            filesAtOuterRing: _state.DvdFilesAtOuterRing);
                    request = new OpticalBurnRequest(
                        device.Id,
                        OpticalBurnMediaKind.DvdData,
                        options.ContentLength,
                        (output, cancellationToken) =>
                        {
                            if (hybridPlan is null)
                            {
                                DvdStreamingGenerator.Generate(
                                    compositePath,
                                    output,
                                    options,
                                    cancellationToken: cancellationToken);
                            }
                            else
                            {
                                DvdStreamingGenerator.GenerateHybrid(
                                    compositePath,
                                    output,
                                    options,
                                    hybridPlan,
                                    cancellationToken: cancellationToken);
                            }
                        },
                        selectedWriteSpeed.Speed);
                    contentDescription = hybridPlan is null
                        ? $"DVD · {options.TotalSectors} sectors · {options.ContentLength / (1024.0 * 1024.0):F1} MiB"
                        : $"DVD Hybrid Disc · {hybridPlan.FileCount} [EN]（{(_state.DvdFilesAtOuterRing ? "Outer Ring" : "Inner Ring")}）"
                            + $" · [EN] LBA {hybridPlan.DrawingStartLba}–{hybridPlan.DrawingEndLbaExclusive - 1}"
                            + $" · {options.ContentLength / (1024.0 * 1024.0):F1} MiB";
                }
                else
                {
                    CdDiscParameters parameters = ReadCdGeneratedParameters();
                    request = CreateCdBurnRequest(
                        compositePath,
                        parameters,
                        _state.CdDataDirectory,
                        _state.CdVolumeLabel,
                        _state.CdFilesAtOuterRing,
                        _state.CdInterleave,
                        _state.Tone,
                        device.Id,
                        selectedWriteSpeed.Speed);
                    contentDescription = request.MediaKind == OpticalBurnMediaKind.CdData
                        ? $"CD Data Disc（DAO） · Files located at {(_state.CdFilesAtOuterRing ? "Outer Ring" : "Inner Ring")}"
                        : "CD audio track";
                    contentDescription += $" · {parameters.Sectors} sectors · {request.ContentLength / (1024.0 * 1024.0):F1} MiB";
                }
            }

            // In-app danger modal; default focus sits on the refusing button.
            bool confirmed = await _shell.ConfirmAsync(
                "[EN]streamingBurn",
                $"[EN]：{device.DisplayName}\n{contentDescription}\n"
                    + $"[EN]：{selectedWriteSpeed.DisplayName}\n\n"
                    + "[EN]。[EN]Cancel[EN]Disc Media[EN]。[EN]？",
                "[EN]Burn");
            if (!confirmed)
            {
                return;
            }

            if (_shell.IsBusy || preparationRevision != _burnPreparationRevision || !ConfirmChecked)
            {
                BurnStatusText = "Burn[EN]，[EN]。";
                return;
            }

            ownsBusyState = true;
            _shell.SetBusy(true);
            IsBurnRunning = true;
            CancellationTokenSource burnCancellation = new();
            _burnCancellation = burnCancellation;
            // The burn reports real percentages, so it drives the job dock's bar instead of
            // showing a second progress surface inside this page.
            _shell.BeginBurnDockJob(request.MediaKind, request.ContentLength);
            BurnProgressValue = 0;
            BurnStatusText = "[EN]streamingBurn，[EN]。";
            _shell.AppendLog(
                $"\n[{DateTime.Now:HH:mm:ss}] [EN]streamingBurn：{contentDescription}；"
                + $"[EN]={device.DisplayName}；[EN]={selectedWriteSpeed.DisplayName}。\n");
            Progress<OpticalBurnProgress> progress = new(value =>
            {
                if (!IsBurnRunning || !ReferenceEquals(_burnCancellation, burnCancellation))
                {
                    return;
                }

                _shell.ReportBurnProgress(value);
                BurnProgressValue = _shell.JobProgressValue;
            });
            OpticalBurnResult result = await _opticalDiscBurner.BurnAsync(
                request,
                progress,
                burnCancellation.Token);
            BurnProgressValue = 100;
            BurnStatusText = "Burning complete，[EN]Optical Disc。";
            _shell.CompleteDockJob("completed：streamingBurn " + contentDescription);
            _shell.AppendLog(
                $"[{DateTime.Now:HH:mm:ss}] streamingBurning complete：{result.BytesWritten} bytes，"
                + $"[EN] {result.Elapsed.TotalSeconds:F1} seconds"
                + (result.ActualWriteSpeed is null
                    ? "。\n"
                    : $"，[EN]={FormatBurnWriteSpeed(result.ActualWriteSpeed, mediaKind)}。\n"));
            ConfirmChecked = false;
            _shell.ShowToast("streamingBurning complete", "streamingBurn[EN]completed，[EN]Optical Disc。", ToastKind.Success);
        }
        catch (OperationCanceledException)
        {
            BurnStatusText = "[EN]Cancel；Drive[EN]。";
            _shell.AbortDockJob("[EN]Cancel：streamingBurn", expandLog: false);
            _shell.AppendLog(
                $"[{DateTime.Now:HH:mm:ss}] [EN]CancelstreamingBurn；[EN]Disc Media[EN]。\n");
        }
        catch (Exception exception)
        {
            BurnStatusText = "Burn[EN]completed，[EN]Error[EN]。";
            _shell.AbortDockJob("failed：streamingBurn", expandLog: true);
            _shell.AppendLog($"[{DateTime.Now:HH:mm:ss}] streamingBurning failed：{exception.Message}\n");
            _shell.ShowToast(
                "streamingBurn[EN]completed",
                exception.Message + "\n\n[EN]，[EN]Disc Media[EN]。",
                ToastKind.Error);
        }
        finally
        {
            _burnCancellation?.Dispose();
            _burnCancellation = null;
            IsBurnRunning = false;
            InvalidateConfirmation();
            _isPreparingBurn = false;
            if (ownsBusyState)
            {
                _shell.SetBusy(false);
            }

            OnPropertyChanged(nameof(IsSetupEnabled));
            UpdateActionState();
        }
    }

    // Build the layout before physical writing and capture all generation options.
    internal static OpticalBurnRequest CreateCdBurnRequest(
        string imagePath,
        CdDiscParameters parameters,
        string? dataDirectory,
        string volumeLabel,
        bool filesAtOuterRing,
        bool interleave,
        ToneProfile tone,
        string deviceId,
        OpticalWriteSpeed? writeSpeed)
    {
        parameters.Validate();
        ToneProfile capturedTone = tone.Normalized();
        if (string.IsNullOrWhiteSpace(dataDirectory))
        {
            return new OpticalBurnRequest(deviceId, OpticalBurnMediaKind.CdAudio, parameters.TotalBytes,
                (output, token) => CdTrackGenerator.GenerateToStream(imagePath, output, parameters,
                    interleave, cancellationToken: token, audioByteOrder: CdAudioByteOrder.LittleEndian,
                    tone: capturedTone), writeSpeed);
        }

        CdDataLayoutPlan plan = CdDataImageGenerator.PrepareLayout(dataDirectory.Trim(), parameters,
            string.IsNullOrWhiteSpace(volumeLabel) ? "CD_IMAGE" : volumeLabel.Trim(), filesAtOuterRing);
        return new OpticalBurnRequest(deviceId, OpticalBurnMediaKind.CdData, checked(parameters.Sectors * 2048),
            (output, token) => CdDataImageGenerator.GenerateToStream(imagePath, output, parameters, plan,
                cancellationToken: token, tone: capturedTone), writeSpeed);
    }

    // Request construction is separate from physical writing so the captured
    // calibration content can also be validated with an ordinary memory stream.
    internal static OpticalBurnRequest CreateCalibrationBurnRequest(
        CalibrationTarget target,
        bool cdInterleave,
        string deviceId,
        OpticalWriteSpeed? writeSpeed)
    {
        ArgumentNullException.ThrowIfNull(target);
        if (target.Parameters.Kind == CalibrationDiscKind.BluRay)
        {
            BluRayDiscParameters disc = CalibrationViewModel.BluRayParameters(target.Parameters);
            BluRayPatternRangeMapping mapping = CalibrationViewModel.BluRayPatternMapping(target);
            return new OpticalBurnRequest(deviceId, OpticalBurnMediaKind.BluRayData, disc.ContentLength,
                (output, token) => BluRayStreamingGenerator.GenerateToStream(
                    output,
                    new BluRayStreamingOptions(disc, 0, disc.TotalSectors),
                    mapping,
                    progress: null,
                    cancellationToken: token),
                writeSpeed);
        }

        if (target.Parameters.Kind == CalibrationDiscKind.Dvd)
        {
            DvdStreamingOptions options = CalibrationViewModel.DvdOptions(target);
            options.Validate();
            return new OpticalBurnRequest(deviceId, OpticalBurnMediaKind.DvdData, options.ContentLength,
                (output, token) => DvdStreamingGenerator.GeneratePattern(target.Sample, output, options,
                    cancellationToken: token), writeSpeed);
        }

        CdDiscParameters parameters = CalibrationViewModel.CdParameters(target);
        parameters.Validate();
        return new OpticalBurnRequest(deviceId, OpticalBurnMediaKind.CdAudio, parameters.TotalBytes,
            (output, token) => CdTrackGenerator.GeneratePatternToStream(target.Sample, output, parameters,
                cdInterleave, cancellationToken: token, audioByteOrder: CdAudioByteOrder.LittleEndian), writeSpeed);
    }

    private void CancelStreamBurn()
    {
        CancelBurnCommand.NotifyCanExecuteChanged();
        BurnStatusText = "[EN]Burn，[EN]Disc Media…";
        _burnCancellation?.Cancel();
    }

    private CdDiscParameters ReadCdGeneratedParameters()
    {
        CdDiscParameters parameters = new(
            ParameterParser.ParsePositiveDouble(_state.CdInnerRadius, "CD Inner Radius"),
            ParameterParser.ParsePositiveDouble(_state.CdOuterRadius, "CD Outer Radius"),
            ParameterParser.ParsePositiveLong(_state.CdSectors, "CD Sector count"));
        parameters.Validate();
        return parameters;
    }

    private BluRayDiscParameters ReadBluRayParameters()
    {
        long totalSectors = ParameterParser.ParsePositiveLong(_state.BdTotalSectors, "Blu-rayTotal Sectors");
        if (totalSectors > uint.MaxValue)
        {
            throw new ArgumentOutOfRangeException("Blu-rayTotal Sectors", "Total SectorsexceedsBlu-rayEngine supported range。");
        }

        BluRayDiscParameters disc = new(
            checked((uint)totalSectors),
            1,
            ParameterParser.ParsePositiveDouble(_state.BdInnerRadius, "Blu-rayInner Radius"),
            ParameterParser.ParsePositiveDouble(_state.BdOuterRadius, "Blu-rayOuter Radius"));
        disc.Validate();
        return disc;
    }

    private DvdStreamingOptions ReadDvdStreamingOptions()
    {
        int totalSectors = ParameterParser.ParsePositiveInt(_state.DvdTotalSectors, "DVD Total Sectors");
        DvdStreamingOptions options = new(
            checked((uint)totalSectors),
            ParameterParser.ParsePositiveDouble(_state.DvdInnerRadius, "DVD Inner Radius"),
            ParameterParser.ParsePositiveDouble(_state.DvdOuterRadius, "DVD Outer Radius"),
            PitchLinear: ParameterParser.ParseDouble(_state.DvdPitchLinear, "DVD Track Pitch[EN]"),
            PitchQuadratic: ParameterParser.ParseDouble(_state.DvdPitchQuadratic, "DVD Track Pitch[EN]"),
            PitchCubic: ParameterParser.ParseDouble(_state.DvdPitchCubic, "DVD Track Pitch[EN]"),
            Tone: _state.DvdTone);
        options.Validate();
        return options;
    }

    public sealed record BurnWriteSpeedOption(
        OpticalWriteSpeed? Speed,
        string DisplayName)
    {
        public static BurnWriteSpeedOption Automatic { get; } =
            new(null, "[EN]（[EN]，recommended）");
    }
}
