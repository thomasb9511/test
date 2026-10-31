# DVD 64 / E4 Grayscale [EN] 

 [EN]  **Verbatim DVD-R AZO 43533**  [EN] ： [EN]  `A5 / 66 / B9 / 92`  [EN] ， [EN]  `64`、`E4`  [EN]  `66`  [EN] 、Dither [EN] ， [EN]  `64`  [EN]  `E4`  [EN] 。 [EN] ， [EN] Burn。

 [EN]  byte  [EN]  **DVD scrambling [EN]  Q bytes**。 [EN]  Q； [EN] Recent [EN] ， [EN] grayscale [EN] 。

##  [EN] 

 [EN]  Windows  [EN]  .NET 10 SDK。 [EN]  `6000 × 6000`  [EN] grayscale PNG； [EN]  `(2880, 1920)`、 [EN]  `640 × 640`  [EN] 。 [EN]  Gray8  [EN]  `0 / 85 / 170 / 255`， [EN] grayscale [EN] 。 [EN] 、 [EN] Dither [EN] ， [EN] 。

 [EN] directory [EN] ， [EN]  `four-level-6000.png`  [EN] path；`prepare`  [EN] directorymust [EN] ：

```powershell
dotnet run --project tools/DvdGrayProbe --configuration Release -- prepare --source "four-level-6000.png" --output-dir "artifacts/dvd-gray-probe-64-e4"

dotnet run --project tools/DvdGrayProbe --configuration Release -- generate --prepared "artifacts/dvd-gray-probe-64-e4" --output "artifacts/dvd-gray-probe-64-e4/burn.iso" --parallelism 8

dotnet run --project tools/DvdGrayProbe --configuration Release -- verify --prepared "artifacts/dvd-gray-probe-64-e4" --iso "artifacts/dvd-gray-probe-64-e4/burn.iso"
```

 [EN] ：

|  [EN]  |  [EN]  |
|---|---|
| `burn.iso` |  [EN] Burn [EN] ，2,297,888  [EN]  2048-byte sectors， [EN]  4,706,074,624 bytes |
| `burn.iso.json` |  [EN]  |
| `probe.json` |  [EN] 、 [EN]  |
| `atlas.q8` | 6000 × 6000  [EN]  Q  [EN]  |
| `code-map.png` |  [EN]  Q bytes [EN] ； [EN] disc surface [EN] Brightness |
| `nominal-preview.png` |  [EN] grayscale [EN] ； [EN] ，cannot [EN] Burn [EN]  |

`burn.iso`  [EN] sectors [EN] ，cannot [EN] 。Burn [EN] Burn [EN]  **“ [EN]  / Write image file to disc”**  [EN] ； [EN] 。 [EN]  43533 Disc Media， [EN] Recorder [EN] ， [EN] 。

** [EN]  PNG  [EN] grayscale [EN] 。**  [EN] ， [EN]  `64`、`E4`  [EN] 。

##  [EN] 

 [EN]  12  [EN]  12  [EN]  30°  [EN] ， [EN] ：

```text
1-66  2-64  3-E4  |  4-64  5-E4  6-66  |  7-E4  8-66  9-64  |  10-66  11-E4  12-64
```

 [EN] ， [EN]  `A5 /  [EN]  / B9 / 92`。 [EN] ， [EN] disc surface [EN] 。 [EN] Optical Disc [EN] ：

|  [EN]  |  [EN]  |
|---|---|
| 24.5–25.6 mm | Inner Ring [EN] ： [EN]  15°  [EN] ，`A5、66、64、E4、B9、92`  [EN]  |
| 26.0–28.1 mm |  [EN]  Floyd–Steinberg  [EN] ； [EN] ， [EN]  byte |
| 28.5–30.5 mm | `64 / E4`  [EN] ； [EN]  25%、50%、75%  [EN]  `64`， [EN]  `E4` |
|  [EN]  37.5 mm |  [EN]  12.8 mm  [EN]  |
| 45.8–47.5 mm |  [EN]  `A5`  [EN]  |
| 47.8–49.5 mm |  [EN]  `B9`  [EN]  |
| 49.8–51.5 mm |  [EN]  `92`  [EN]  |
| 52.2–57.3 mm | Outer Ring [EN] ， [EN] Inner Ring [EN] ， [EN]  byte  [EN]  |

 [EN] ：**25%、50%、75%  [EN] **， [EN]  byte。 [EN]  FS  [EN] 。

 [EN] pixels [EN] ，`0 / 85 / 170 / 255`  [EN] grayscale； [EN] Brightness。 [EN]  **20 µm**， [EN] Dither [EN] ， [EN]  Q bytes [EN] 。

 [EN] Dither PNG。 [EN]  `(2880, 1920)`、 [EN]  `640 × 640`  [EN] ， [EN] 、 [EN] Dither。 [EN]  `24.13% / 23.90% / 22.74% / 29.24%`， [EN] ； [EN]  `85`  [EN]  byte  [EN] 。

 [EN]  144  [EN] 、4,216,432  [EN] pixels： [EN] ， [EN] deviation [EN]  **0.501  [EN] **，`64/E4`  [EN] deviation [EN]  **0.197  [EN] **， [EN]  Q bytes。 [EN] directory [EN]  `mixture-measurements.csv`  [EN]  `mixture-measurements.json`。ISO  [EN] ， [EN]  9  [EN] bytes [EN]  2,359,296  [EN]  payload  [EN]  Q； [EN] ， [EN] disc surface [EN] Burn [EN] 。

##  [EN] 

 [EN] ， [EN] ； [EN] Optical Disc， [EN] 。 [EN] ， [EN] “ [EN] ” [EN] “ [EN] ”。

 [EN] ： [EN]  `A5`、`B9`  [EN] ； [EN] ； [EN] ；`64 / E4`  [EN] 、 [EN] 。 [EN]  `B9`  [EN]  `A5`、`92`  [EN] 。

 [EN]  `0 =  [EN] ，1 =  [EN] ，2 =  [EN] `  [EN] ：

|  [EN]  |  [EN]  A5  [EN]  |  [EN]  B9  [EN]  |  [EN] 、 [EN]  |  [EN]  |  [EN]  |
|---|---|---|---|---|---|
| 66 | | | | | |
| 64 | | | | | |
| E4 | | | | | |

 [EN]  `64 / E4`  [EN]  25%、50%、75%  [EN] ， [EN] 。 [EN] ， [EN] 。

##  [EN] 

 [EN]  43533  [EN] ：

-  [EN] ：`23.991460627731737 mm`
-  [EN] ：`57.964893657925366 mm`
- Sector count：`2297888`
-  [EN] Bit Length [EN] ：`133.3 nm`
- Track Pitch [EN] ：`[-3.9256854319227684E-05, 6.964795915429256E-05, -4.670918950137523E-05]`
-  [EN] ：`6000 × 6000`， [EN]  `120 × 120 mm`

 [EN] Disc Media [EN] ； [EN] Brightness [EN] 。
