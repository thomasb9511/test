#  [EN] 

 [EN] 。 [EN] 、 [EN] ； [EN] Burn [EN] Recorder、 [EN] Disc Media。

##  [EN] 

Recent [EN] ：2026-10-28， [EN] 、calibration [EN]  Verbatim BD-R (64099)  [EN] （ [EN]  `3088802`、`49a0e4d`、`46e2c53`），Windows、.NET SDK 10.0.400（ [EN]  10.0.11），Release  [EN] 。 [EN]  solution  [EN] （0 Warning、0 Error） [EN] ； [EN]  Exe harness， [EN]  `dotnet test`。

calibrationBurn [EN] Completed [EN] 、 [EN]  DVD  [EN] 。Verbatim  [EN] ， [EN]  GUI  [EN]  CLI  [EN] 、Sector count、polarity [EN] ， [EN] 。v1.3.3  [EN] ／ [EN]  45  [EN] ； [EN] Burn [EN] 。

 [EN] ：BD calibration [EN] 、 [EN] 、polarity [EN] 、 [EN] Cancel；CD calibration [EN] 、interleaving [EN] bytes [EN] ，CD  [EN] Outer Ring [EN] ／SIMD bytes [EN] ；DVD  [EN] 、 [EN] 、 [EN] bytes [EN] 。

 [EN] directory [EN] ：

```powershell
dotnet restore DiscImageStudio.slnx
dotnet build DiscImageStudio.slnx --configuration Release --no-restore
dotnet run --project tests/DiscImageStudio.ArchitectureTests --configuration Release --no-build
dotnet run --project src/DvdImageSolver --configuration Release --no-build -- selftest
dotnet run --project src/DiscImageStudio.App --configuration Release --no-build -- selftest
./tests/Test-ReleaseTooling.ps1
```

 [EN] ：

- CD/DVD： [EN] 、Dither、sRGB Gamma、 [EN] streaming [EN] 、SIMD  [EN] 。
- CD  [EN] ：ISO9660/Joliet  [EN] 、 [EN] Outer Ring [EN] Save、 [EN] 、 [EN] sectors [EN] 、 [EN] 。
- CD  [EN]  DAO：Mode 1 EDC  [EN]  P/Q  [EN] 、 [EN] bytes [EN] 、Import [EN] 、 [EN]  Q  [EN]  CRC、 [EN]  Seek  [EN] 、 [EN] Outer Ring ISO  [EN] ； [EN]  359,845 sectors， [EN] Recorder [EN] audio track [EN] 。 [EN]  IMAPI  [EN] ， [EN] Burn [EN] 。
- BD：17PP/EDC/Reed-Solomon、3T/6T  [EN] polarity、 [EN] 、UDF 2.01、 [EN]  4 GiB  [EN] 、sidecar  [EN] invalid [EN] 。
- DVD/BD  [EN] ： [EN] Inner Ring [EN] 、Outer Ring ISO9660/Joliet  [EN]  UDF directory [EN] 、 [EN] 、 [EN] disc surface [EN] 、 [EN]  Seek  [EN] 、 [EN] Cancel [EN] ， [EN] 。
-  [EN] ： [EN]  schema 2  [EN]  schema 1  [EN] 、 [EN]  schema 4  [EN]  schema  [EN] 、`ProjectSession`  [EN]  BD apply/capture。
- Burn： [EN] 、 [EN] 、 [EN] 、 [EN] 、Cancel [EN] ， [EN] Recorder。
- streamingBurn [EN] ： [EN] ，CD audio track／ [EN] 、DVD、BD  [EN] ， [EN] invalid [EN] 、3 seconds [EN] 、finalize disc / close session [EN] ， [EN] 。
- calibrationBurn [EN] ：CD/DVD/BD  [EN] Save [EN] ，BD Bit Length、polarity [EN] ， [EN] 、 [EN] ， [EN] Burn [EN] 。
- calibration： [EN] Track Pitch、BD  [EN] polarity、 [EN] rectification、 [EN] fitting、 [EN] Save [EN] 、 [EN] 。
-  [EN] ：CD/DVD/BD  [EN] 、 [EN] 。
-  [EN] ： [EN] Outer RingDesign [EN]  sidecar  [EN] 、DVD  [EN] Track Pitch [EN] 、 [EN] invalid [EN] 、Errordirectory/ [EN] Notice、 [EN] Reset [EN] 。 [EN]  ISO  [EN] 。

GUI  [EN] ：

```powershell
dotnet run --project src/DiscImageStudio.App --configuration Release --no-build -- ui-snapshot --output artifacts/validation/home.png --tab 0
dotnet run --project src/DiscImageStudio.App --configuration Release --no-build -- ui-snapshot --output artifacts/validation/export-bd.png --tab 3 --project sample.discproj
dotnet run --project src/DiscImageStudio.App --configuration Release --no-build -- ui-snapshot --output artifacts/validation/preview-bd.png --tab 2 --project sample.discproj --live-input image.png --live-disc bd --live-mode calibrate
dotnet run --project src/DiscImageStudio.App --configuration Release --no-build -- ui-snapshot --output artifacts/validation/burn-bd.png --tab 4 --project sample.discproj --burn-source calibration --burn-progress write
```

`--burn-progress`  [EN]  `write`、`buffer`、`finalize`， [EN] ， [EN] Burn。2026-10-28  [EN]  BD calibration [EN]  800×650  [EN] 、 [EN] finalize disc / close sessionStatus； [EN] 、 [EN] 、 [EN] 。 [EN]  DVD  [EN] ， [EN] Burn。

`build`  [EN] directory [EN]  DVD  [EN] 、 [EN] sectors CD  [EN] Home [EN] 。 [EN]  EXE  [EN] [ [EN] ](RELEASING.md)。

 [EN]  DVD/BD  [EN] Design [EN] 、Outer RingExport [EN] Outer Ring [EN] ， [EN]  8  [EN] ；DVD/ [EN]  45  [EN] 。

Design [EN]  DVD、BD、CD、 [EN] folder、18  [EN] 、 [EN]  7  [EN] Status； [EN] ， [EN] ， [EN]  0 Warning、0 Error。

v1.3.0  [EN]  `Build-Release.ps1`  [EN]  .NET 10  [EN] ： [EN] directory [EN]  EXE，Burn [EN] 、DVD  [EN] 、 [EN] sectors RAW/WAV/CUE、Close CUE  [EN]  WPF  [EN] 。 [EN]  .NET / Windows Desktop 10.0.11， [EN] 。

v1.3.2  [EN] 、DVD  [EN] 、 [EN]  45  [EN] 。 [EN] Blu-ray [EN] polarity [EN] ， [EN] DeleteRecent [EN] ； [EN]  25%–1200%  [EN] 、 [EN] Reset。 [EN] New CD、Blu-ray、DVD Project Settings [EN]  18  [EN] Design [EN]  4  [EN] 。

##  [EN] 

 [EN] Burn。 [EN] 、 [EN] Brightness [EN] Burnsucceeded [EN] ；Blu-ray [EN] 。

v1.3.1  [EN]  CD Data Disc DAO  [EN] Burn； [EN] 、 [EN]  EXE  [EN] 、audio track/CUE、 [EN] Outer Ring ISO  [EN] 。

已经记录的 DVD 三次Track Pitch实拍与参数见 [README 中的前后对比](../README.md#Assisted Calibration [EN] )。 [EN]  [PHYSICAL_MODEL_AUDIT.md](PHYSICAL_MODEL_AUDIT.md)， [EN] ，cannot [EN] 。

 [EN] 、Recorder [EN] 、Disc Media [EN] 、 [EN] 、 [EN] 、 [EN] /Burn [EN] ， [EN] Disc Media。
