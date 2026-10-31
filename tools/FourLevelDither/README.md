#  [EN] Dither [EN] 

 [EN]  Windows  [EN] ， [EN]  **0、255**  [EN]  PNG。DVD  [EN]  CD  [EN] ， [EN] pixels [EN] 。 [EN]  `FourLevelDither.exe`， [EN] 。

##  [EN] 

1.  [EN]  `FourLevelDither.exe`， [EN] “Open [EN] ” [EN] 。
2.  [EN] “DVD  [EN] ” [EN] “CD  [EN] ”， [EN] ； [EN] 。 [EN] “100% pixels [EN] ” [EN] Dither [EN] 。
3. “sRGB Gamma [EN] ” [EN] Close， [EN] ； [EN] ， [EN] Status。
4.  [EN] “Save [EN]  PNG”， [EN] 。Close [EN]  `- [EN] Dither.png`  [EN] ， [EN]  `- [EN] Dither-sRGB.png`， [EN] 。 [EN] path。

 [EN] Optical Disc [EN] Gamma [EN] ， [EN] Dither [EN] 。 [EN] ， [EN] Open [EN] Dither [EN] ， [EN] 。

 [EN]  PNG、JPEG、BMP、TIFF、GIF  [EN] 。Export [EN]  Gray8 PNG， [EN] pixels [EN]  DPI；invalid DPI  [EN]  96。 [EN] Save [EN] pixels [EN] 。

##  [EN] Optical Disc [EN] 

 [EN] ， [EN]  Rec.709  [EN]  RGB  [EN] Brightness， [EN] ， [EN] ** [EN]  Floyd–Steinberg  [EN] **： [EN] ， [EN] Brightness [EN] Recent [EN] ， [EN] Brightness [EN] pixels。

|  [EN]  | PNG /  [EN] grayscale [EN]  | DVD scrambling [EN]  Q byte | CD byte |
| --- | ---: | --- | --- |
| 0–127 | 0 | `0xA5` | `0x0D` |
| 128–255 | 255 | `0x92` | `0xAA` |

 [EN] CloseGamma [EN] ， [EN] grayscale 128  [EN]  `128 / 255 = 50.2%`  [EN] pixels， [EN] 。Dither [EN] ； [EN] Gamma [EN] ， [EN]  0  [EN]  255。

### sRGB Gamma [EN] 

 [EN] ， [EN]  RGB  [EN] standard sRGB  [EN] Brightness， [EN]  Rec.709  [EN] Brightness、 [EN] 。 [EN] pixels [EN] ， [EN] Optical Disc [EN] Grayscale。

 [EN] grayscale 128  [EN]  21.6%  [EN] Brightness， [EN]  21.6%  [EN] pixels； [EN] Close [EN] 。 [EN] Save [EN] 。Close [EN] ， [EN] 。

 [EN]  CD、DVD  [EN]  BD  [EN] Live Preview [EN] “ [EN] （ [EN] Dither）” [EN] “sRGB Gamma [EN] ” [EN] ， [EN] Close。 [EN] ， [EN] 、streamingBurn [EN] ； [EN] Export PNG。Optical Disc [EN]  CD/DVD  [EN] 。

 [EN]  CD/DVD  [EN] Copy [EN] ， [EN] ， [EN] Dither [EN]  `0/255`， [EN] Brightness。 [EN] path。

 [EN]  `DiscImageStudio.Imaging.GrayscaleDither`  [EN] grayscale [EN] 。 [EN]  `FourLevelDither` API  [EN] ， [EN]  CLI  [EN] 。

##  [EN] 

```powershell
#  [EN] ， [EN]  DVD  [EN] ； [EN] must [EN]  .png， [EN] cannot [EN] 
.\FourLevelDither.exe --input original.jpg --output result.png

#  [EN]  DVD  [EN]  CD； [EN]  0/255  [EN] 
.\FourLevelDither.exe --input original.jpg --output dvd-result.png --mode dvd
.\FourLevelDither.exe --input original.jpg --output cd-result.png --mode cd

#  [EN] Close [EN]  sRGB Gamma [EN] ； [EN]  --gamma  [EN]  none
.\FourLevelDither.exe --input original.jpg --output result-none.png --gamma none
.\FourLevelDither.exe --input original.jpg --output result-srgb.png --gamma srgb

#  [EN] Open [EN] 
.\FourLevelDither.exe original.jpg

#  [EN] （ [EN]  --help）
.\FourLevelDither.exe -h
```

##  [EN] 

 [EN] directory [EN]  .NET 10 SDK：

```powershell
dotnet run --project tools/FourLevelDither --configuration Release

dotnet publish tools/FourLevelDither/FourLevelDither.csproj --configuration Release --runtime win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true --output artifacts/FourLevelDither/win-x64
```

 [EN]  `FourLevelDither.exe`  [EN]  .NET 10  [EN] ； [EN] ， [EN]  .NET 10 Windows  [EN] 。
