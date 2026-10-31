using System.Windows;
using System.Windows.Input;
using DiscImageStudio.ViewModels;
using Microsoft.Win32;

namespace DiscImageStudio;

/// <summary>The app's second window: new-project creation and project-settings editing share
/// one dialog. The view model does the validation; this class only wires pickers, the close
/// path and Escape.</summary>
public partial class ProjectDialogWindow : Window
{
    public ProjectDialogWindow(ProjectDialogViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        viewModel.ShowPresetSaveDialog = () => PresetSaveWindow.Show(this);
        viewModel.PickSaveDirectory = PickDirectory;
        viewModel.CloseWithConfirm = () => DialogResult = true;
        viewModel.ConfirmPresetSwitch = tile => PresetSwitchConfirm.ShowAsync(
            "[EN]",
            $"[EN]“{tile.Title}”[EN]，[EN]。[EN]？",
            "[EN]");
        DataContext = viewModel;

        SourceInitialized += (_, _) => WindowCorners.Apply(this);
        PreviewKeyDown += (_, args) =>
        {
            // Escape answers the overwrite guard first; only an unguarded Escape closes.
            if (args.Key == Key.Escape && PresetSwitchConfirm.HandleKeyDown(args.Key))
            {
                args.Handled = true;
                return;
            }

            if (args.Key == Key.Escape)
            {
                Close();
            }
        };
    }

    public ProjectDialogViewModel ViewModel { get; }

    private string? PickDirectory(string initialDirectory)
    {
        OpenFolderDialog dialog = new()
        {
            Title = "[EN]Save[EN]",
            InitialDirectory = initialDirectory,
        };
        return dialog.ShowDialog(this) == true ? dialog.FolderName : null;
    }

    private void Cancel_Click(object sender, RoutedEventArgs e) => Close();
}
