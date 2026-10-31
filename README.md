<div align="center">

![Banner](docs/images/DiscImageStudio_Banner_2.png)

<h2> [EN] Optical Discdisc surface [EN] Burn [EN] </h2>

Disc Image Studio  [EN]  Windows  [EN] Optical Discdisc surface [EN] Burn [EN] ， [EN]  DVD / CD / Blu-ray Optical Disc [EN] visible to the naked eye [EN] 。

![.NET 版本](https://img.shields.io/badge/.NET-10.0-512bd4?style=flat-square)
![运行平台](https://img.shields.io/badge/Platform-Windows%2010%2F11-0078d6?style=flat-square)
![开发语言](https://img.shields.io/badge/Language-C%23-68217A?style=flat-square)
![GitHub Repo size](https://img.shields.io/github/repo-size/JiaFeiMiao-K-Cat/DiscImageStudio?style=flat-square&color=3cb371)
![贡献欢迎](https://img.shields.io/badge/PRs-Welcome-brightgreen?style=flat-square)
[![许可证：GPL-3.0-or-later](https://img.shields.io/badge/License-GPL--3.0--or--later-blue?style=flat-square)](LICENSE)

</div>

---

##  [EN] 

![](docs/images/case1.jpg)

![](docs/images/case2.jpg)

---

##  [EN] 

Disc Image Studio  [EN]  CD、DVD  [EN] Single Layer BD-R Optical Discphysical layer [EN] ，Burn [EN] Optical Discdisc surface [EN] visible to the naked eye [EN] 。

##  [EN] 

![](docs/images/tab-0.png)

![](docs/images/tab-3-2.png)

![](docs/images/tab-1.png)

---

##  [EN] 

从 [GitHub Releases](https://github.com/JiaFeiMiao-K-Cat/DiscImageStudio/releases)  [EN]  Release EXE， [EN] ；EXE  [EN]  .NET  [EN] 。

### 1. New Project

 [EN] Home [EN]  CD、DVD  [EN] Blu-ray， [EN] Output location [EN] 。

### 2. Designdisc surface

 [EN] Design [EN] Import [EN] ， [EN] completed [EN] ， [EN] 「Tone」 [EN] Dither、Gamma、Brightness [EN] Grayscale [EN] 。

### 3.  [EN] Export

 [EN] disc surface [EN] ， [EN] Export [EN]  ISO / RAW / WAV+CUE， [EN] Disc Media。

On-The-Fly Burning [EN] ， [EN] 。

##  [EN] 

### Optical Disc [EN] 

- **CD-DA  [EN] **： [EN] Export [EN]  WAV audio track [EN]  CUE， [EN]  cdrecord, ImgBurn [EN] Burn [EN] ； [EN] Export RAW audio track。 [EN]  [CD Burn [EN] ](docs/CD_AUDIO_COMPATIBILITY.md)。
- **CD  [EN] **： [EN] Accompanying Folder [EN]  ISO9660/Joliet  [EN] ， [EN] Inner Ring／Outer Ring [EN] ； [EN] audio track。
- **DVD  [EN] **： [EN] Export ISO Pure Artwork Disc [EN] Hybrid Disc， [EN] Inner Ring [EN] Outer Ring。
- **Blu-ray [EN] **：Single Layer BD-R 25 GB， [EN]  UDF 2.01  [EN] 。 [EN]  [ADDING_BLURAY.md](docs/ADDING_BLURAY.md)。
- **Accompanying Files**：CD／DVD／Blu-ray [EN] Design [EN] Save [EN] folder [EN] Inner Ring／Outer Ring [EN] ， [EN] Export [EN] ； [EN] Save。
- ** [EN] **：Hybrid Disc [EN] Design [EN] （ [EN] ）。
- ** [EN] grayscale [EN] **：CD  [EN]  DVD  [EN] ，CD  [EN]  `0D / AA`，DVD scrambling [EN]  `A5 / 92`。 [EN]  [PHYSICAL_MODEL_AUDIT.md](docs/PHYSICAL_MODEL_AUDIT.md)。
- **grayscaleDither [EN] **： [EN]  `0/255`  [EN]  PNG； [EN] Open [EN] 、 [EN]  PNG Export。 [EN] [ [EN] ](tools/FourLevelDither/README.md)。
- **DVD  [EN] Track Pitch [EN] **： [EN] Track Pitch [EN] ， [EN] 、 [EN] Assisted Calibration [EN] 。 [EN]  [DVD_ENGINE.md](docs/DVD_ENGINE.md)。
- **Disc Media [EN] **： [EN]  JSON +  [EN]  JSON  [EN] ， [EN]  CD／DVD／BD。 [EN] [ [EN] ](docs/DISC_PRESETS.md)。

### Assisted Calibration

Disc Image Studio  [EN] Assisted Calibration [EN] ， [EN] calibration，Assisted Calibration [EN] OK [EN] disc surface [EN]  10<sup>-6</sup>  [EN]  10<sup>-14</sup>。 [EN] Track Pitch， [EN] radial line [EN] ； [EN] Assisted Calibration [EN] Track Pitch [EN] Burn [EN] ， [EN] 。

|  [EN]  ·  [EN] Track Pitch |  [EN]  ·  [EN] Track Pitch |
| --- | --- |
| ![ [EN]  DVD  [EN] ： [EN] ](docs/images/verbatim-dvd-calibration-before.jpg) | ![ [EN]  DVD  [EN] ： [EN] ](docs/images/verbatim-dvd-calibration-after.jpg) |
| `P20261004-133519.jpg` | `P20261004-135416.jpg` |


 [EN] [Assisted Calibration [EN] ](docs/CALIBRATION.md)。

### Burn

- ** [EN] **： [EN] Export [EN]  ISO / RAW  [EN] Burn [EN] Burn。
- ** [EN] streamingBurn（ [EN] ）**：CD、DVD  [EN]  BD-R  [EN] Burn， [EN] Save [EN] ；BD-R  [EN]  MMC  [EN] 。
- ** [EN] Blank Media！**

###  [EN] 

-  [EN] ： [EN] Open GUI； [EN] 。
-  [EN] ：CD、DVD  [EN] Blu-ray [EN]  `IOpticalDiscModule`  [EN] ， [EN] directory [EN] ， [EN] [ [EN] ](docs/ARCHITECTURE.md)。

##  [EN] 

- Windows 10 2004（2004/20H1，19041） [EN] ， [EN]  Windows 11。
-  [EN] ：.NET 10 SDK（`global.json`  [EN]  10.0.x）； [EN]  GUI  [EN]  .NET 10 Windows  [EN] 。Release EXE  [EN] ， [EN]  .NET。
- “On-The-Fly Burning” [EN]  Windows  [EN]  CD / DVD / BD Recorder [EN] Disc Media；BD-R  [EN] Single Layer [EN] 。

##  [EN] 

```powershell
dotnet build DiscImageStudio.slnx --configuration Release
dotnet run --project src/DiscImageStudio.App --configuration Release
```

 [EN] ：

```powershell
dotnet run --project src/DvdImageSolver --configuration Release -- selftest
dotnet run --project tests/DiscImageStudio.ArchitectureTests --configuration Release
```

 [EN] 、CI  [EN]  EXE、Release  [EN] 、MSIX  [EN] [ [EN] ](docs/RELEASING.md)。

##  [EN] 

 [EN] Open GUI， [EN] ：

|  [EN]  |  [EN]  |
| --- | --- |
| `solve` |  [EN] （CW  [EN] ） [EN]  DVD  [EN] ， [EN] Dither [EN]  |
| `encode` |  [EN]  DVD ECC  [EN]  NRZI channel bits |
| `calibrate` | calibration [EN] ： [EN]  DVD  [EN] ， [EN] measured [EN] disc surface |
| `simulate` |  [EN] measured [EN] Generated DVD ISO  [EN]  |
| `selftest` |  [EN]  DVD  [EN] OK [EN]  |
| `cd-generate` |  [EN] Accompanying Files [EN]  WAV + CUE / RAW audio track； [EN]  `--data-dir`  [EN]  CD Data Disc ISO |
| `cd-preview-warp` | calibration [EN] ： [EN] measured [EN]  CD  [EN]  |
| `cd-preview-track` |  [EN] calibration [EN]  WAV  [EN]  RAW CD-DA audio track（ [EN] ） |
| `bd-generate` |  [EN]  BD-R ISO， [EN]  `<iso>.json` sidecar |
| `bd-info` / `bd-probe` / `bd-encode` | Export BD  [EN] 、 [EN]  ECC  [EN]  |

 [EN] 。

##  [EN] 

```text
src/DiscImageStudio.Core/     [EN] 、 [EN] / [EN] 、 [EN] directory
src/DiscImageStudio.Imaging/ CD/DVD/BD  [EN] Dither [EN] 
src/DiscImageStudio.Burning/ Windows IMAPI2  [EN] 、 [EN] Burn [EN] 
src/DiscImageStudio.Cd/      CD-DA  [EN]  CD  [EN] 
src/DiscImageStudio.Dvd/     DVD  [EN] 
src/DiscImageStudio.BluRay/  BD-R  [EN] 、17PP/ECC、3T/6T  [EN] 、streaming [EN]  ISO
src/DiscImageStudio.Iso/     UDF 2.01 / ISO9660  [EN] 
src/DiscImageStudio.App/     WPF GUI、 [EN] 
src/DvdImageSolver/           [EN]  DVD  [EN] / [EN] 
tests/                        [EN] 
packaging/                   MSIX  [EN] 
tools/                        [EN] 
docs/                         [EN] 、 [EN] 、 [EN] 、 [EN] 
```

##  [EN] 

|  [EN]  |  [EN]  |
| --- | --- |
| [ARCHITECTURE.md](docs/ARCHITECTURE.md) |  [EN] 、 [EN]  |
| [DVD_ENGINE.md](docs/DVD_ENGINE.md) | DVD NRZI  [EN] 、 [EN]  |
| [CD_AUDIO_COMPATIBILITY.md](docs/CD_AUDIO_COMPATIBILITY.md) | CD audio track [EN] 、bytes [EN] ghosting [EN]  |
| [ADDING_BLURAY.md](docs/ADDING_BLURAY.md) | Blu-ray [EN] 、 [EN] /Burn [EN]  |
| [DISC_PRESETS.md](docs/DISC_PRESETS.md) |  [EN] Disc Media [EN]  JSON  [EN]  |
| [CALIBRATION.md](docs/CALIBRATION.md) |  [EN] rectification（ [EN] Disc Media [EN] Spindle Hole Edge）、 [EN] calibration [EN]  DVD  [EN] Track Pitchfitting |
| [PHYSICAL_MODEL_AUDIT.md](docs/PHYSICAL_MODEL_AUDIT.md) | CD / DVD  [EN]  |
| [VALIDATION.md](docs/VALIDATION.md) |  [EN] 、 [EN]  |
| [RELEASING.md](docs/RELEASING.md) | GitHub Release、MSIX  [EN] 、 [EN]  |
| [CHANGELOG.md](CHANGELOG.md) |  [EN]  |

##  [EN] standard

Disc Image Studio  [EN] ：

|  [EN]  | standard [EN]  |  [EN]  |
| --- | --- | --- |
| CD-R | [ECMA-394，第 1 版，2010 年 12 月](https://ecma-international.org/publications-and-standards/standards/ecma-394/) — *Recordable Compact Disc Systems CD-R Multi-Speed*（[ [EN]  PDF](https://ecma-international.org/wp-content/uploads/ECMA-394_1st_edition_december_2010.pdf)） | CD-R  [EN] 、 [EN]  CD-DA  [EN] ； [EN]  CD-DA audio track。 |
| DVD 公共格式 / DVD-ROM | [ECMA-267，第 3 版，2001 年 4 月](https://ecma-international.org/publications-and-standards/standards/ecma-267/) — *120 mm DVD – Read-only disk*（[ [EN]  PDF](https://ecma-international.org/wp-content/uploads/ECMA-267_3rd_edition_april_2001.pdf)） | DVD  [EN] 、ECC、EFMPlus  [EN]  G  [EN] ； [EN]  ECMA-359。 |
| DVD-R | [ECMA-359，第 1 版，2004 年 12 月](https://ecma-international.org/publications-and-standards/standards/ecma-359/) — *80 mm (1,46 Gbytes per side) and 120 mm (4,70 Gbytes per side) DVD Recordable Disk (DVD-R)*（[ [EN]  PDF](https://ecma-international.org/wp-content/uploads/ECMA-359_1st_edition_december_2004.pdf)） | Single Layer DVD-R  [EN] 、sectors、 [EN] ；standard [EN] ， [EN] Dual Layer。 |
| BD-R | [ISO/IEC 30190:2021，第 3 版，2021 年 1 月](https://www.iso.org/standard/80770.html) — 120 mm Single Layer（25.0 GB） [EN] Dual Layer（50.0 GB） [EN]  BD  [EN]  |  [EN] Single Layer 25 GB  [EN] 、sectors [EN] 、 [EN] ； [EN] Dual Layer [EN] 。 |

CD 公共编码部分还参考了 [ECMA-130，第 2 版（CD-ROM，1996）](https://ecma-international.org/publications-and-standards/standards/ecma-130/)。

## Burn [EN] 

- Disc Image Studio  [EN] ；“On-The-Fly Burning” [EN]  Windows  [EN]  IMAPI2， [EN] Blank Media。
- “On-The-Fly Burning” [EN] ， [EN] 、 [EN] Burn [EN] ， [EN] ， [EN] 。Burn [EN] 、 [EN] Disc Media [EN] ！
-  [EN] Disc Media、Recorder、 [EN] 。
-  [EN] folder [EN] Start Burning [EN] directory [EN] ； [EN] file size [EN] ， [EN] Disc Media [EN] 。
- BD-R  [EN] spare area [EN] ； [EN] Disc Media [EN] cannot [EN] 。

##  [EN] 

- Disc Image Studio  [EN] 、 [EN] 、 [EN] ， [EN] [ [EN] ](PRIVACY.md)。
-  [EN]  Issue  [EN] ， [EN] [ [EN] ](SECURITY.md) [EN]  GitHub  [EN] 。

##  [EN] 

 [EN] 。 [EN] 、 [EN] 、 [EN]  Pull Request  [EN] [ [EN] ](CONTRIBUTING.md)。

##  [EN] 

 [EN]  [GNU GPL v3.0 or later](LICENSE)（`GPL-3.0-or-later`）。CD interleaving [EN]  CDImage  [EN] ， [EN]  GPL  [EN] ； [EN] 。 [EN] ， [EN]  [ [EN] ](LICENSE-NOTICE.md)  [EN]  [ [EN] ](THIRD-PARTY-NOTICES.txt)； [EN] "About" [EN] 。

##  [EN] 

感谢 [arduinocelentano 的 CDImage 项目](https://github.com/arduinocelentano/cdimage)， [EN]  CD audio track [EN] disc surface [EN] 。 [EN]  CD interleaving [EN] ，CD disc surface [EN] 。CDImage  [EN] 。

---

## Star History

<a href="https://www.star-history.com/?repos=jiafeimiao-k-cat%2Fdiscimagestudio&type=date&legend=top-left">
 <picture>
   <source media="(prefers-color-scheme: dark)" srcset="https://api.star-history.com/chart?repos=jiafeimiao-k-cat/discimagestudio&type=date&theme=dark&legend=top-left" />
   <source media="(prefers-color-scheme: light)" srcset="https://api.star-history.com/chart?repos=jiafeimiao-k-cat/discimagestudio&type=date&legend=top-left" />
   <img alt="Star History Chart" src="https://api.star-history.com/chart?repos=jiafeimiao-k-cat/discimagestudio&type=date&legend=top-left" />
 </picture>
</a>
