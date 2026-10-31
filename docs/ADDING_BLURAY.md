# Blu-ray [EN] （Single Layer BD-R）

Blu-ray [EN]  `src/DiscImageStudio.BluRay`， [EN]  Core  [EN]  `src/DiscImageStudio.Iso`， [EN]  CD/DVD  [EN] 。 [EN]  ISO/IEC 30190:2021， [EN]  **120 mm、Single Layer 25 GB BD-R**； [EN] Dual Layer、BDXL、BD-RE  [EN] Blu-ray [EN] 。

##  [EN] 

Blu-ray [EN] ， [EN] （CD / DVD / BD）。Open BD  [EN] ：

- **Design**： [EN]  BD  [EN] Outer Radius [EN] ； [EN] “Accompanying Files” [EN] Select Folder [EN] Inner Ring／Outer Ring [EN] ， [EN] Export [EN] ； [EN] Tone [EN]  2  [EN] 、sRGB  [EN] 、Brightness [EN]  3T/6T polarity。
- ** [EN] **：Design [EN] /measured [EN] 、Tone [EN] polarity [EN]  3T/6T  [EN] ； [EN]  ISO  [EN]  AA/44  [EN] bytes， [EN] polarity， [EN] Brightness。
- **Export**： [EN]  BD ISO（ [EN]  UDF 2.01  [EN] ）；Select Folder [EN] Inner Ring [EN] Outer Ring， [EN] Inner Ring。 [EN] Save， [EN] directory [EN]  `<iso>.json` sidecar  [EN] 。
- **Burn**： [EN]  ISO  [EN]  MMC  [EN] ， [EN] Save [EN] ； [EN] Cancel。
- **calibration**：BD  [EN] ，Savesectors、 [EN] 、polarity、 [EN]  ISO  [EN] ；fitting [EN] Track Pitch [EN]  BD  [EN] 。

BD  [EN]  CD/DVD  [EN]  `disc-presets.json`（schema 4） [EN]  `bluRayPresets`  [EN] 。 [EN] 「standard 25GB Single Layer BD」「 [EN]  BD-R 10x」 [EN] 「Verbatim BD-R (64099)」 [EN] ； [EN] Project Settings [EN] Save。

##  [EN] 

- Single Layer [EN]  12,219,392  [EN]  2048-byte  [EN] sectors， [EN]  25,025,314,816 bytes；32 sectors [EN]  65,536-byte cluster。
-  [EN] Sector countmust [EN]  32  [EN] Single Layer [EN] ；Outer Radius [EN]  60 mm。
-  [EN] Burn [EN] Total Sectors；Burn [EN] ， [EN] sectors [EN] 。
-  [EN] Track Pitch 0.320 µm， [EN] Bit Length 74.5 nm， [EN]  0°。

##  [EN]  ISO

`BluRayIsoGenerator`  [EN]  UDF 2.01 directory [EN]  extent， [EN]  32 sectors [EN] 。Inner Ring [EN] ，Outer Ring [EN] ； [EN] 、 [EN] 。 [EN]  `TotalSectors × 2048`。

-  [EN] Select Folder： [EN] ， [EN] 。 [EN]  `.iso`  [EN] ， [EN] cannotBrowse。
- Select Folder： [EN]  UDF 2.01， [EN]  4 GiB  [EN] ；`--file-position inner|outer`  [EN] ， [EN]  `inner`，`outer` must [EN]  `--data-dir`。 [EN] 、 [EN] 、 [EN] 。
-  [EN] pathmust [EN] folder [EN] ， [EN] cannot [EN] 。Cancel [EN] failed [EN]  ISO。
-  [EN] succeeded [EN]  `<iso>.json`（`format: bd-r-image-v1`）：Total sectors、 [EN] Outer Radius、 [EN] 、3T/6T polarity、`ToneProfile`、 [EN] 、UDF  [EN] 、 [EN] 。 [EN]  ISO  [EN] ； [EN]  sidecar  [EN]  ISO  [EN] 。

 [EN] bytes，cannot [EN] scrambling； [EN] sectors [EN] ， [EN] 。UDF  [EN] ， [EN] 。 [EN] 。GUI  [EN] Design [EN]  sidecar  [EN] （ [EN] ） [EN] ， [EN] ； [EN]  ISO  [EN] 。

`BluRayIsoGenerator.Prepare`  [EN] folder、 [EN]  UDF 2.01 directory [EN]  extent。Inner Ring [EN]  32 sectors，Outer Ring [EN]  32 sectors。 [EN]  288 sectors， [EN] 。 [EN]  API  [EN] folder [EN] ；must [EN] ， [EN]  640 sectors。

 [EN] /streaming [EN] path。 [EN] directory [EN] 。 [EN]  64  [EN] ， [EN]  `0x3ffff800` bytes [EN]  extent， [EN]  128 KiB  [EN] ； [EN] file size [EN] Disc Media [EN] ， [EN]  4 GiB  [EN] 。DVD  [EN]  ISO9660/Joliet path [EN] 。

UDF 实现依据 [ECMA-167](https://ecma-international.org/publications-and-standards/standards/ecma-167/)  [EN]  [ECMA TR/112-4（UDF 2.01）](https://ecma-international.org/wp-content/uploads/ECMA_TR-112-4_1st_edition_december_2023.pdf)， [EN] 。 [EN] ， [EN] Blu-ray [EN] 。

## Tone [EN] polarity

BD  [EN] Tone [EN] completed：sRGB  [EN]  → Brightness [EN]  → bytes [EN] Dither → 128  [EN] 。 [EN] 、Burn [EN] ， [EN]  250  [EN]  payload bytes [EN] 。

`BluRayRunLengthMapping`  [EN] ： [EN]  3T  [EN]  `AA`， [EN]  6T  [EN]  `44`；`InvertMapping`  [EN] 。 [EN] ， [EN]  3T/6T， [EN] measured [EN] polarity。 [EN] calibration [EN] ；polarity [EN]  `ToneProfile` Save。

## 3T / 6T  [EN] 

 [EN]  `BluRayImageLoader`  [EN] ， [EN]  `BluRayImagePayloadMapping`  [EN] 。 [EN] ， [EN] Disc Media [EN] ， [EN] 。 [EN]  EDC  [EN] 、LDC interleaving、BIS  [EN] 、DC  [EN] 、 [EN]  run-in； [EN]  2:3  [EN]  byte  [EN] ， [EN]  17PP  [EN] 。

内建 `BluRayRunLengthMapping` 先以 128 分界，再返回scrambling域 `AA` 或 `44`。选择依据是同样 958,272 channel bits 的完整簇中，相邻 modulation ONE 间隔为 3T / 6T 的次数，mark 与 space 都计入，不是某一种电平的占空比。基准 PSN `0x100000` 的 256 重复bytes扫描中，`AA` 有 265,136 个 3T，`44` 有 116,575 个 6T，分别为目标次数最高；四地址复核仍保留强偏向，但不保证每个地址均排名第一。细节见[bytes分析](BLURAY_BYTE_DENSITY.md# [EN] -3t--6t- [EN] )。

 [EN]  `IBluRayLuminanceMapping.Map`  [EN] ， [EN] Brightness [EN]  byte  [EN] scrambling [EN]  byte。 [EN] ， [EN]  `IBluRayPayloadMapping.FillScrambledPayload`， [EN] sectors [EN]  2048  [EN]  byte  [EN] ， [EN]  `BluRayStreamingGenerator`； [EN] sectors、PSN  [EN] Disc Media [EN] 。

`BluRayDiscModule`  [EN] ， [EN]  WPF；App  [EN]  CLI  [EN]  `BluRayImageLoader.Load`。 [EN]  API  [EN] 。`BluRayConstantByteMapping`  [EN] 。 [EN] calibration [EN]  `BluRayIsoGenerator`  [EN] Burn [EN] 。

 [EN]  [bytes [EN] ](BLURAY_BYTE_DENSITY.md)。`tools/BluRayByteProbe`  [EN]  256 bytes [EN] ； [EN] ， [EN] bytes。 [EN] polarity。

##  [EN] 

```powershell
#  [EN] Single Layer [EN] ， [EN] Export JSON
dotnet run --project src/DiscImageStudio.App -- bd-info --output bd-parameters.json

#  [EN]  ISO（1024 sectors [EN] ， [EN] ）
dotnet run --project src/DiscImageStudio.App -- bd-generate --input image.png --output bd-test.iso --total-sectors 1024 --invert true

#  [EN]  UDF Inner Ring [EN]  ISO
dotnet run --project src/DiscImageStudio.App -- bd-generate --input image.png --output bd-image.iso --data-dir C:\Files --volume-label BD_IMAGE

# Tone：Dither、Brightness、sRGB  [EN] 
dotnet run --project src/DiscImageStudio.App -- bd-generate --input image.png --output bd-tone.iso --tone-dither 0.75 --tone-gamma true --tone-brightness -4

#  [EN]  ECC  [EN] 
dotnet run --project src/DiscImageStudio.App -- bd-probe --byte 0xA6 --sectors 32 --output bd-probe.bin
dotnet run --project src/DiscImageStudio.App -- bd-encode --input bd-probe.bin --psn 0x100000 --output bd-ecc.bin
```

`bd-generate`  [EN]  `--preset`  [EN]  `bd-r-sl-25gb`、`bd-r-ritek-10x`  [EN]  `bd-r-verbatim-64099`；`--total-sectors`、`--r0`、`--r1`、`--start-angle`  [EN] 。`--invert`  [EN]  `true`/`false`。`bd-generate`  [EN]  `--start-sector` / `--sectors`  [EN] ； [EN]  `bd-probe`。

`bd-probe`  [EN]  `--byte`  [EN]  0..255  [EN]  `0x00`..`0xFF`， [EN]  32  [EN] 。`bd-encode`  [EN] must [EN]  65,536 bytes， [EN]  76,880 bytes  [EN]  ECC cluster， [EN]  17PP、DC-control  [EN] ，cannot [EN] Burn [EN] 。

##  [EN] 

|  [EN]  | ISO/IEC 30190:2021 |
| --- | --- |
| 2048-byte payload + 4-byte EDC | §13.2–13.3 |
| 16-bit LFSR，PSN bits 19..5  [EN] ； [EN]  data frame  [EN]  | §13.4 |
| LDC RS(248,216)，304  [EN] interleaving | §13.5–13.8 |
|  [EN] 、RS(9,5)、BIS RS(62,30)  [EN]  | §13.9–13.14 |
| 17PP、DC-control  [EN]  | §13.15–13.17 |
| Recording unit spacing | §14 |
|  [EN] Track Pitch 0.320 µm | §15.4.3 |
| Single Layer PSN 0x00100000..0x00CA73FF | §17 |
| Single Layer [EN]  381,856 clusters | §19 |

 [EN] ** [EN] scrambling [EN]  payload**。 [EN]  EDC， [EN]  2052-byte data frame scrambling；EDC、 [EN] 、 [EN] 、 [EN] cannot [EN] bytes [EN] 。

`BluRayRecordingFrameEncoder`  [EN]  28  [EN]  DC  [EN] 。`BluRayRecordingUnitEncoder`  [EN]  run-in、496  [EN] 、run-out  [EN]  Guard3  [EN] ， [EN]  modulation bit / NRZI level  [EN]  byte  [EN] 。 [EN]  `BluRayGreedyDcControlEncoder`： [EN]  0  [EN] ， [EN] ； [EN]  `SuboptimalDcControlDecisions`  [EN] 。 [EN] ， [EN] standard [EN]  DC  [EN] ， [EN] Recorder [EN] 。CLI  [EN]  `bd-encode`  [EN] ExportOK [EN]  ECC  [EN] ， [EN] Burn [EN] 。

`BluRayTrackGeometry`  [EN] Track Pitch [EN] ， [EN] Total sectors [EN] Outer Radius [EN] Track Pitch； [EN] sectors [EN] Outer Radius。 [EN] ， [EN] Disc Media [EN] （§9.8、§15.3）； [EN]  Y  [EN] 。 [EN]  recording unit  [EN]  `2760 + 496 × 1932 + 1104 = 962136` channel bits，Bit Length 74.5 nm。`bd-probe`  [EN] 。 [EN]  Guard3  [EN]  recording unit  [EN] 。

 [EN]  24–58 mm  [EN] ， [EN] Disc Media [EN] measured [EN] 。 [EN] streamingBurn [EN]  BD-R  [EN] 、 [EN] spare area [EN]  `sector → PSN`  [EN] 。 [EN] 、 [EN] Contrast [EN] calibration； [EN] Burn ISO  [EN] spare area [EN] 。

##  [EN] spare areastreamingBurn

`IDiscFormat2Data`  [EN]  BD-R  [EN] spare area [EN]  11,826,176 sectors， [EN]  12,219,392 sectors [EN]  768 MiB。Blu-ray [EN]  `IDiscRecorder2Ex.SendCommandSendDataToDevice`  [EN]  LBA 0  [EN]  `WRITE(10)`， [EN]  32 sectors（64 KiB）， [EN]  200 seconds， [EN] 。 [EN] 。 [EN] Burn [EN]  `Write`、`FORMAT UNIT`  [EN] spare area [EN] 。

 [EN]  `IWriteEngine2`  [EN] ， [EN] 、Refresh [EN]  `WriteSection`  [EN] 。 [EN] failed [EN]  LBA、Sector count、 [EN] 、HRESULT  [EN]  Sense。 [EN] OK， [EN] 。

failed [EN] Recent 8  [EN] succeeded [EN] ， [EN] 、 [EN] 。 [EN]  Sense  [EN] “ [EN]  Sense  [EN] ”； [EN] cannot [EN] Disc Media [EN] Error。`0x8007048F`  [EN]  Windows  [EN] 。 [EN]  200 seconds [EN] seconds [EN] failed， [EN] ， [EN] 、 [EN]  USB  [EN] ，cannot [EN] 。 [EN] Burn [EN] ， [EN] 。

 [EN] Disc Media [EN] ， [EN]  MMC  [EN]  profile、Disc Media [EN] 、 [EN] 。must [EN] 、 [EN] Single Layer BD-R SRM， [EN]  0  [EN] ， [EN] ； [EN] 、 [EN] ， [EN] Total Sectors。 [EN] Total Sectors [EN]  2048 bytes [EN] ，UDF  [EN] 、 [EN] ； [EN] sectors。

 [EN] completed [EN] Refresh [EN] 、Close [EN] ， [EN]  BD-R  [EN]  finalize  [EN]  6 finalize disc / close session。Cancel [EN] ；Cancel [EN] failed [EN] Refresh [EN] ， [EN] completed [EN] succeeded [EN] finalize disc / close session。 [EN] succeeded [EN] completed，failed [EN] ，Error [EN] ； [EN] succeeded [EN] 。 [EN] finalize disc / close session [EN] completed。 [EN] spare area [EN] ； [EN] Disc Media [EN] cannot [EN] 。

BD  [EN] Recorder [EN] ， [EN] ， [EN] disc surface [EN] ； [EN] succeeded [EN] Refresh [EN] finalize disc / close sessioncompleted [EN] 。4×  [EN]  18 MB/s（1× = 4.5 MB/s）， [EN]  MB/s，cannot [EN] ； [EN] Disc Media [EN] 。

 [EN] ； [EN] 。 [EN]  10 seconds [EN] ， [EN] （ [EN] ） [EN]  WRITE  [EN] （ [EN] ）， [EN] 。 [EN] 、 [EN] Refresh [EN] ； [EN] cannot [EN] ， [EN] cannot [EN]  USB  [EN] disc surface [EN] 。

 [EN]  8  [EN] 、16  [EN] （1 MiB） [EN] ，completed [EN] 。 [EN]  3T/6T  [EN] scrambling XOR  [EN]  SIMD， [EN] ； [EN] bytes [EN] Disc Media [EN] 。 [EN] ， [EN] calibration [EN] ；Custom [EN] 。 [EN] ， [EN] Burn [EN] 。

 [EN]  1024 sectors（2 MiB） [EN]  UDF  [EN] ； [EN]  12,219,392 sectors [EN] ， [EN]  ISO。 [EN] Burn [EN] 。

实现依据：[微软发送数据与命令超时接口](https://learn.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-sendcommandsenddatatodevice)、[libburn MMC  [EN] ](https://dev.lovelyhq.com/libburnia/libburn/src/branch/master/libburn/mmc.c)、[libburn  [EN] ](https://dev.lovelyhq.com/libburnia/libburn/src/branch/master/libburn/spc.h)。

##  [EN] 

 [EN]  17PP/EDC/Reed-Solomon、 [EN]  RUB  [EN] 、 [EN] 、 [EN] 、ISO/UDF、 [EN]  4 GiB  [EN] 、 [EN] Burn [EN] 、 [EN] 、sidecar  [EN] Cancel。 [EN]  UDF  [EN]  1024 sectors， [EN]  ISO  [EN]  2 MiB； [EN] ， [EN]  4 GiB  [EN] （ [EN]  1 MiB）， [EN] ， [EN]  ISO。 [EN] 。 [EN] Burn [EN] ， [EN] disc surface [EN] Brightness [EN] polarity。
