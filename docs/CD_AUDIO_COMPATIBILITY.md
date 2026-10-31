# CD audio track [EN] 、bytes [EN] ghosting [EN] 

## Accompanying Files [EN] 

CD  [EN] Design [EN] Export [EN] Accompanying Folder [EN] ， [EN]  ISO9660/Joliet  [EN] ， [EN]  `.iso`； [EN] folderpath [EN]  WAV audio track。 [EN] Inner Ring [EN] Outer Ring， [EN] Inner Ring， [EN] Save。 [EN] ，Outer Ring [EN] ， [EN] ， [EN] 。

```powershell
DiscImageStudio.exe cd-generate --input picture.png --output cd-image.iso `
  --data-dir "D:\Accompanying Files" --volume-label CD_IMAGE --file-position outer
```

ISO  [EN]  `Sector count × 2048`， [EN]  CD-ROM Mode 1  [EN] Burn。 [EN] On-The-Fly Burning [EN]  ISO  [EN] ； [EN] Burn [EN] Burn [EN] 。 [EN] interleaving [EN]  CUE  [EN] audio track [EN] 。 [EN]  CD-ROM scrambling [EN] ，Accompanying Files [EN] 。

CD Data DiscOn-The-Fly Burning [EN] audio track [EN]  DAO  [EN]  lead-out  [EN] ， [EN]  ATIP calibration [EN] Sector count [EN] 。 [EN]  ISO  [EN]  Mode 1  [EN] sectors， [EN] ； [EN]  359,845  [EN] sectors， [EN]  TAO  [EN] 。DAO  [EN] audio track [EN]  3 sectors [EN]  overburn  [EN] ， [EN] 。

数据轨使用 IMAPI 小端主通道约定：在standard Mode 1 sectors上补齐 EDC、P/Q 纠错码并scrambling，保持同步头 `00 FF…FF 00` 的bytes顺序。CD-ROM 物理编码的相邻bytes交换与转为小端的交换相抵消；这一点也与 cdrdao 的 [RAW 编码和设备bytes序转换](https://github.com/cdrdao/cdrdao/blob/master/dao/dao.cc)  [EN] 。 [EN] Outer Ring [EN]  ISO  [EN] 。

Design [EN] 、Tone [EN]  `.iso.json`  [EN] （ [EN] ）。 [EN] 、Tone [EN] ； [EN]  ISO  [EN] 。 [EN] ， [EN] Burn [EN] 。

## recommended [EN] 

 [EN]  `cd-track.wav`， [EN]  `cd-track.cue`。WAV  [EN]  PCM：44.1 kHz、16  [EN] 、 [EN] ， [EN] 。 [EN] directory， [EN]  CUE  [EN] 。CUE  [EN] ：Export [EN] Cancel [EN] “ [EN] Export CUE  [EN] ”， [EN]  `--cue false`， [EN]  WAV。

| Burn [EN]  |  [EN]  |
| --- | --- |
| cdrecord | `cdrecord dev= [EN]  speed= [EN]  -audio "cd-track.wav"`， [EN] Add `-swab` |
| ImgBurn |  [EN] “Write image file to disc” [EN] Open `cd-track.cue` |
|  [EN] streamingBurn |  [EN]  PCM  [EN] ， [EN]  WAV  [EN] ， [EN] audio track |
|  [EN]  RAW  [EN]  |  [EN]  `.raw`；`cdrecord -audio "cd-track.raw"`  [EN]  `-swab` |

输出后缀决定真实格式，只接受 `.wav` 和 `.raw`。cannot通过Rename把旧 RAW 变成 WAV；must重新生成。WAV 的配套 CUE 使用 `FILE "cd-track.wav" WAVE`，不使用 `BINARY`。Unicode 文件名使用带 BOM 的 UTF-8 CUE，支持空格和中文。ImgBurn 作者曾验证这种 CUE 的 Unicode 文件名支持，并指出早期 2.5.0.0 的相关问题在 2.5.1.0 修复。[ImgBurn 作者说明](https://forum.imgburn.com/topic/13526-unicode-filename-problem-in-cue-file/)

 [EN] （ [EN] measured [EN] ）：

```powershell
DiscImageStudio.exe cd-generate --input picture.png --output cd-track.wav --interleave true
```

`--cue`（ [EN]  `true`） [EN]  WAV  [EN]  CUE；`.raw`  [EN]  CUE。

WAV  [EN]  `Sector count × 2352 + 44`； [EN] 、 [EN] streamingBurn [EN]  `Sector count × 2352`。 [EN] Disc Mediaaudio tracksectors， [EN] 。

## Tone（Dither、sRGB  [EN] 、Grayscale [EN] Brightness）

CD  [EN] bytes [EN]  6.8 µm  [EN] disc surface [EN] ； [EN] ， [EN] bytes [EN] 。 [EN] “ [EN] bytes [EN] ” [EN] “ [EN] ”， [EN] bytes [EN] 。

|  [EN]  |  [EN]  |
| --- | --- |
| Dither [EN]  0–100% | 0%  [EN]  128  [EN] （ [EN] ）；100%  [EN] bytes [EN] ， [EN] bytes [EN]  |
| Grayscale [EN] （ [EN]  CD） | 2  [EN]  `0x0D` / `0xAA`；4  [EN]  `0x0D` / `0x10` / `0x63` / `0xAA`（`0x0D`  [EN] 、`0xAA`  [EN] ） |
| sRGB  [EN] （Gamma） |  [EN]  sRGB  [EN] Dither； [EN] ， [EN]  |
| Brightness |  [EN] Grayscale， [EN]  −64…+64（0..255  [EN] ） |

 [EN] （`cd-generate`  [EN]  `cd-preview-warp`  [EN] ）：

```powershell
DiscImageStudio.exe cd-generate --input picture.png --output cd-track.wav `
  --tone-dither 1 --tone-levels 2 --tone-brightness 0 --tone-gamma false
```

 [EN]  `--tone-dither 0 --tone-levels 2 --tone-brightness 0 --tone-gamma false`， [EN] bytes [EN] 。New Project [EN] Design [EN] 「Tone」 [EN]  75% / 2  [EN] ； [EN]  `tone`  [EN]  0%  [EN] ，Save [EN]  `tone`  [EN] 。Export [EN] ， [EN] NoticeTone [EN] Design [EN] 。

Dither [EN] ** [EN] bytes [EN] ** [EN] （`globalByte`）， [EN] 。Delayed interleaving [EN] bytes [EN] ， [EN] ， [EN] 、calibration [EN] 。calibration [EN] （`GeneratePattern`） [EN] ， [EN] Dither。

audio track [EN]  `.json`  [EN]  `toneDitherStrength`、`toneLevels`、`toneBrightness`、`toneSrgbLinearization`； [EN] audio track [EN] 、interleaving [EN] 。

 [EN]  1600 px、16 samples/sector， [EN] pixels [EN] ** [EN] **。 [EN]  900 px、2 samples/sector [EN] ， [EN] ， [EN] ； [EN] disc surface [EN] Tone。 [EN] “Design [EN] ” [EN] measured [EN] ，Open Project [EN] ； [EN] measured [EN] deviation。

##  [EN] 

2026-09-12  [EN] ： [EN]  RAW， [EN]  cdrecord  [EN]  `-audio`  [EN]  `speed`  [EN] ；Add `-swab`  [EN] ghosting。 [EN]  RAW  [EN]  cdrecord  [EN] 。

 [EN] Export [EN] streamingBurn [EN]  `GenerateToStream`  [EN] ，streamingpath [EN] bytes [EN] 。 [EN] ：

|  [EN]  |  [EN]  |
| --- | --- |
| cdrecord  [EN]  `-audio` |  [EN]  |
| cdrecord  [EN]  `-audio -swab` |  [EN] ； [EN]  |
| cdrecord WAV |  [EN] ， [EN] bytes [EN]  |
| CUE  [EN]  `FILE ... BINARY` |  [EN] ；cannot [EN]  RAW  [EN]  BINARY CUE |
| IMAPI `AddTrack(IMAPI_CD_SECTOR_AUDIO, stream)` |  [EN]  16  [EN]  44.1 kHz WAV  [EN] ， [EN]  PCM |

上述 cdrecord 行为及 BINARY 定义来自 [cdrecord 官方手册](https://cdrtools.sourceforge.net/private/man/cdrecord/cdrecord.1.html)；IMAPI  [EN]  [Microsoft  [EN]  AUDIO sectors [EN] ](https://learn.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_cd_sector_type)。ImgBurn  [EN] succeededBurn `FILE ... WAVE` CUE  [EN] 。[ImgBurn WAVE CUE  [EN] ](https://forum.imgburn.com/topic/25173-extract-only-session-two-from-audio-cd/page/2/)

这里的 `AudioSectorType = 0` 是 IMAPI 枚举的 AUDIO 值，不是把audio track写成物理 Mode 0。`IRawCDImageCreator::AddTrack` 当前只支持 AUDIO 类型。[Microsoft AddTrack 文档](https://learn.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagecreator-addtrack)

##  [EN] 

 [EN]  `CddaInterleaver`  [EN] bytes [EN] 。 [EN]  16  [EN] bytes， [EN] bytes [EN] 。 [EN] cannot [EN] ， [EN] cannot [EN] 。

 [EN] ， [EN] ， [EN] bytes [EN]  `+73`  [EN] bytes， [EN]  `-73`  [EN] bytes。 [EN] ； [EN] ， [EN] Drive CIRC  [EN] 。

 [EN] ， [EN] completed [EN]  2352 bytessectors [EN] bytes [EN] ： [EN]  RAW  [EN] ；WAV  [EN]  IMAPI  [EN] 。WAV  [EN] bytes [EN] ，streaming [EN] 。

##  [EN] must [EN] Delayed interleaving

 [EN] bytes i  [EN]  `i + offset(i % 24)`：interleaving [EN]  28×D（D=4） [EN] ， [EN]  24 bytes， [EN]  72  [EN]  2592  [EN] （ [EN] ）。 [EN] bytes [EN] ， [EN] —— [EN]  60000 sectors、900 px  [EN] ， [EN]  17.5%  [EN] pixels [EN] ， [EN] " [EN] "。

 [EN]  `cd-preview-track`  [EN] （`--deinterleave`， [EN]  `true`）： [EN] bytes i  [EN]  `i + CddaInterleaveTable.FileOffsetFor(i % 24)`， [EN]  2592 bytes [EN] 。 [EN]  `CddaInterleaver`  [EN]  `CddaInterleaveTable`， [EN] 。

 [EN] ： [EN] ， [EN] bytes [EN] （1318–1332 bytes， [EN]  sectors）， [EN] 。 [EN] audio track [EN] Outer Ring， [EN] audio track [EN] Sector count [EN] 。

`cd-generate`  [EN] audio track [EN]  `<track>.json`（`format: cd-da-track-v1`， [EN]  r0/r1/Sector count/Linear Velocity/ [EN] / [EN] Outer Radius/ [EN] interleaving）。 [EN] audio track [EN] calibration [EN] interleaving [EN] ， [EN] Import [EN] audio track [EN] 。

## calibration [EN] ： [EN] 

`cd-preview-warp`  [EN] path [EN] ， [EN] “calibration [EN] ” [EN] ： [EN] audio track， [EN] —— [EN]  i  [EN] bytes [EN] ，measured [EN] bytes [EN] disc surface [EN] （`--actual-r0`、`--actual-r1`， [EN]  24.3 / 56.6 mm）。 [EN] ； [EN] ， [EN] measureddisc surface [EN] ， [EN] calibration [EN] 。Sector count、Linear Velocity、 [EN] Outer Radius [EN] ， [EN]  1200 mm/s、0°、57.5 mm。

 [EN] 、 [EN] audio track， [EN] Refresh [EN] audio track [EN] （80 minutes [EN]  845 MB）， [EN] calibration [EN] 、 [EN] disc surface。

##  [EN] 

- RAW  [EN]  WAV： [EN] ，interleaving [EN] Close [EN] ，WAV  [EN]  data  [EN]  RAW  [EN]  16  [EN] bytes [EN] ； [EN] 。
- streaming [EN] ： [EN]  Seek/Position  [EN] ， [EN] bytes [EN]  WAV  [EN]  data  [EN] ， [EN] 。
- WAV  [EN] ： [EN]  RIFF  [EN]  `fmt ` / `data`， [EN] ， [EN] ， [EN] bytes [EN] ； [EN]  PCM、 [EN]  44.1 kHz、 [EN]  16  [EN] 。 [EN]  RAW  [EN] 。 [EN] bytes [EN] ， [EN]  CIRC/EFM，cannot [EN] 。
-  [EN] ： [EN] interleaving [EN] interleaving [EN] audio track，`--deinterleave true`  [EN] interleavingaudio track [EN] interleavingaudio track [EN] ， [EN]  sectors [EN] pixels [EN] pixels [EN] （900 px、 [EN] ， [EN]  24 bytes [EN]  245  [EN] ）。
- calibration [EN] ： [EN]  `(24.5, 56.8)`  [EN] audio track， [EN]  `cd-preview-warp`  [EN] （measured= [EN] 、measured=`24.3/56.6`） [EN]  `cd-preview-track`  [EN] pixels [EN] ， [EN] （900 px）；measured [EN] ， [EN] 。
- Windows  [EN] ： [EN]  `MsftRawCDImageCreator`  [EN]  300  [EN] sectors， [EN]  2448 bytes RAW  [EN] sectors， [EN] bytes [EN] 。 [EN] bytes。 [EN] Burn [EN] 、 [EN] Optical Disc。
- 2026-09-12  [EN] completed [EN] ， [EN] ghosting。 [EN] ；streaming、cdrecord、ImgBurn  [EN] measured [EN] 。

微软 `WriteMedia` 文档没有说明它内部的bytes交换实现；上述结论没有把内存实验等同于观察到设备传输时的交换。[Microsoft WriteMedia 文档](https://learn.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-writemedia)
