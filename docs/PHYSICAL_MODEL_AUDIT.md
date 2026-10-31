# CD / DVD  [EN] 

 [EN] ：2026-09-21。 [EN]  `DiscImageStudio-GitHub`  [EN] （ [EN] calibration [EN] ）， [EN]  `6c55a18`。 [EN] standard [EN] 、 [EN] ， [EN] 、 [EN] Burn [EN] 。

##  [EN] 

 [EN]  DVD sectors [EN] Error。 [EN] ， [EN] cannot [EN] standard [EN] disc surface [EN] ： [EN]  CD  [EN] ； [EN] calibration [EN] ；CD interleaving [EN] 。 [EN] Burn [EN] 。

cannot [EN] OK [EN] ， [EN]  DVD Bit Length [EN] 。

## standard [EN] 

- 官方 [ECMA-359 第一版，2004](https://ecma-international.org/wp-content/uploads/ECMA-359_1st_edition_december_2004.pdf)：Single Layer DVD-R， [EN]  §§10.7–10.9、18–23、24.2。 [EN]  PDF  [EN]  28、29、52、56  [EN] 。
- 官方 [ECMA-267 第三版，2001](https://ecma-international.org/wp-content/uploads/ECMA-267_3rd_edition_april_2001.pdf)：DVD-ROM， [EN]  §§10.6、18–21。cannot [EN] Burn [EN] 。
- 官方 [ECMA-130 第二版，1996](https://ecma-international.org/wp-content/uploads/ECMA-130_2nd_edition_june_1996.pdf)：CD-ROM  [EN]  CIRC  [EN] ，§§8.6、11.3–11.4、19.4、 [EN]  C。audio track [EN]  CD-ROM  [EN] 。
- 官方 [ECMA-394 第一版，2010](https://ecma-international.org/wp-content/uploads/ECMA-394_1st_edition_december_2010.pdf)：CD-R， [EN] 、 [EN]  Red Book  [EN] ，§§1.2、2.4–2.5。 [EN]  Red Book  [EN] ， [EN]  CD  [EN] 。

ECMA-359  [EN] ， [EN] standard [EN] ，cannot [EN] measured [EN] ：

|  [EN]  |  [EN]  |  [EN]  |
|---|---|---|
|  [EN]  | 23.9–24.0 mm | 10.7.1.2， [EN]  48.0 mm， [EN]  −0.2/+0.0 mm |
| 12 cm  [EN]  |  [EN]  58.0 mm | 10.7.1.2 |
|  [EN]  | 0.74 ± 0.01 μm | 10.8 |
|  [EN] deviation |  [EN]  0.74 μm  [EN]  ±0.03 μm | 10.8 |
|  [EN] Bit Length | 133.3 ± 1.4 nm | 10.9 |
|  [EN]  PSN | 0x030000， [EN] sectors [EN]  | 24.2 |

ECMA-267  [EN]  DVD-R  [EN] ： [EN]  §10.6.1  [EN]  48.0 mm， [EN]  −0.4/+0.0 mm。cannot [EN] standard [EN] 。

##  [EN] 

DVD  [EN] sectors [EN]  `13 × 2 × (32 + 1456) = 38688`， [EN]  16 sectors ECC  [EN]  619008  [EN] 。`DvdEccBlockEncoder.cs:8`  [EN] ；sectors [EN] 、 [EN]  PO  [EN] interleaving [EN] 。

 [EN] ：

```text
CD:  L = (N / 75) × v                         [mm]
DVD: L = N × 38688 × channelBitLengthNm × 10^-6 [mm]
```

`CdDiscParameters.cs:59–75`  [EN] ，`ArchimedeanSpiral.cs:33–70,115–120`  [EN] 。 [EN]  `pitch = π(ro²−ri²)/L`、`θ = 2L(r−ri)/(ro²−ri²)`。CD  [EN]  0.000135°，cannot [EN] 。DVD  [EN] 、nanometers [EN] mm [EN] Error。

DVD-R  [EN]  linking  [EN] ；§24.2  [EN] sectors [EN] 。 [EN]  ECC  [EN] 。

##  [EN] ： [EN]  CD 80 minutes [EN] 

`src/DiscImageStudio.Core/Presets/built-in-disc-presets.json:6–12`  [EN]  359849 sectors、24.5–56.8 mm、1200 mm/s。 [EN] ：

|  [EN]  |  [EN] （μm） |
|---|---:|
| CD 80 minutes [EN]  | 1.432856 |
| CD 74 minutes [EN]  | 1.548384 |
|  [EN]  CD measured [EN]  | 1.492598 |
| Verbatim CD measured [EN]  | 1.500257 |
| DVD 12 cm  [EN]  | 0.739837 |
| Verbatim DVD-R measured [EN]  | 0.738304 |

ECMA-130 §11.3  [EN]  1.5–1.7 μm；§11.4  [EN]  1200–1400 mm/s。CD80  [EN] cannot [EN] 。 [EN]  24.5 mm  [EN] cannot [EN]  §8.6  [EN] （24.8–25.0 mm）。

 [EN] ， [EN]  CD-R Disc Media [EN] 。 [EN] measured [EN]  1200 mm/s， [EN] 。cannot [EN] standard [EN] measured [EN] 。

##  [EN] ：standard [EN] 

`ImageTargetMapper.cs:58–77`、`FastDispersionImageWriter.cs:345–365`  [EN] 、 [EN] Bit Length [EN] 。DVD  [EN]  45956.06  [EN] 。standard [EN] ， [EN]  58 mm  [EN] ， [EN] 。

 [EN] （ [EN] 、 [EN] ）：

- DVD Bit Length [EN]  10 ppm， [EN]  165.44°。
- DVD Bit Length [EN]  133.33  [EN]  133.3 nm， [EN]  10.34037  [EN] 。
- DVD Inner Radius [EN] Outer Radius [EN]  0.001 mm， [EN]  −201.76°。

 [EN] ， [EN] 。133.33 nm  [EN] standard [EN] ；133.3 nm  [EN] Bit Length。 [EN] 。

##  [EN] ： [EN] radial linecannot [EN] 

`CalibrationTarget.cs:468–473`  [EN] Linear Velocity／Bit Length，`CalibrationCrossFitter.cs:73`  [EN] fitting [EN] ； [EN] concentric circles [EN] 。

 [EN] ： [EN]  DVD `(ri=24, ro=58, bit=133.33)`， [EN]  `(24,58,133.3)`。 [EN] fittingBit Length [EN]  133.33， [EN]  `(24.00540257,58.01305620)`， [EN] ， [EN]  25–57 mm  [EN] （2049  [EN] residual [EN]  2.04×10^-10 rad）。 [EN]  ±0.02 mm Search Range [EN] 。 [EN] ， [EN] 。

 [EN] residual [EN] Bit Length [EN] 。 [EN] ， [EN] “ [EN] ”。 [EN] ， [EN] 、 [EN] ； [EN] fitting [EN] cannot [EN] 。

##  [EN] ：CD interleaving [EN] ， [EN] 

`CddaInterleaver.cs:8–16`  [EN]  ECMA-130  [EN]  C.4  [EN] path [EN] ， [EN] Error [EN] interleaving。 [EN]  PCM  [EN] standard [EN]  CIRC  [EN]  24  [EN] path：10 sectors [EN]  20856  [EN] ， [EN]  111  [EN] 。

 [EN] ：

- **OK [EN] ：** [EN]  1332  [EN] bytes； [EN]  108  [EN]  1332  [EN] bytes [EN] 。`CddaInterleaver.cs:46–55`  [EN]  Flush  [EN] sectors [EN] ， [EN] sectors [EN] 。 [EN] 。
- ** [EN] ：**111  [EN]  C.4  [EN] ， [EN]  15.102 ms，1200 mm/s  [EN]  18.122 mm  [EN] 。 [EN] Burn [EN] ， [EN] ， [EN] 。 [EN]  ATIP、INDEX 01  [EN] ， [EN] cannot [EN] 。

`CdTrackGenerator.cs:229–246`  [EN]  globalByte  [EN] ， [EN] calibration [EN] 。 [EN]  CIRC/EFM。 [EN] ，cannot [EN] disc surface [EN] 。

##  [EN] ：Burn [EN] 

`WindowsImapiBurner.cs:151–166,377–390`  [EN]  IMAPI  [EN] 、 [EN] Status [EN] ， [EN] 。 [EN] Single Layer ID（`DvdDataFrameBuilder.cs:41`） [EN] Single Layer [EN] 。

 [EN] Dual Layer DVD、DVD-RAM  [EN] 。IMAPI  [EN] ， [EN] ； [EN] Status。Dual Layer [EN] 、 [EN] Bit Length [EN] 。

可用微软的 [CurrentPhysicalMediaType](https://learn.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_currentphysicalmediatype)  [EN]  [ [EN] ](https://learn.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_media_physical_type)  [EN] 。

##  [EN] 

1.  [EN] ， [EN] standard [EN] 、measured [EN] ； [EN]  CD80  [EN] 。 [EN] ， [EN] 。
2.  [EN]  CD interleaving、audio track [EN] Burn [EN] ； [EN] ， [EN] Sector count [EN] 。
3.  [EN] calibration [EN] 。 [EN] measuredresidual [EN] ， [EN] ／ [EN] 。
4.  [EN] 。

 [EN] Burn [EN] Brightness [EN] 。 [EN] standard [EN] 、 [EN] 、 [EN] 、 [EN]  CIRC  [EN] path [EN] ； [EN] 。

 [EN] directory `tmp/standards-audit/`：`circ-audit.py`、`circ-audit-result.json`、`geometry-audit.py`、`geometry-audit-result.json`， [EN]  PDF  [EN] 。
