#  [EN] Disc Media [EN] 

Disc Media [EN] ：

-  [EN] ，Save [EN] 。
-  [EN] ， [EN] Save [EN] 、 [EN] ：

```text
%LOCALAPPDATA%\DiscImageStudio\disc-presets.json
```

 [EN] “Custom CD Profile”“Custom DVD Profile” [EN] “Custom Blu-ray Profile” [EN] 。 [EN] Copy [EN] ， [EN] 。

 [EN] Project Settings [EN] ：「 [EN] Save [EN] 」 [EN] ， [EN] ；New Project [EN] directory [EN] ， [EN] 「Recent」「CD」「DVD」「Blu-ray」 [EN] 。

Project Settings [EN] ： [EN] ， [EN] ，Cancel [EN] 。New Project [EN] Project Settings [EN] “Custom” [EN] Delete，Delete [EN] Refresh [EN] ； [EN]  JSON（ [EN] 、 [EN] 、 [EN] ） [EN] 。

##  [EN] 

-  [EN]  `id`  [EN] ， [EN] 。
-  [EN]  `id`  [EN] ， [EN] 。
- `disabledCdPresetIds`、`disabledDvdPresetIds`  [EN]  `disabledBluRayPresetIds`  [EN] 。
-  [EN] ， [EN]  ID  [EN] 。

## Add DVD  [EN] 

 [EN]  `dvdPresets`  [EN] Copy [EN] ， [EN]  `id`、 [EN] 。 [EN] ：

```json
{
  "id": "verbatim-dvd-r-azo-43533",
  "displayName": "Verbatim DVD-R AZO (43533) [Calibrated]",
  "description": "Verbatim DVD-R AZO 43533  [EN] calibration [EN] ：23.9914606277–57.9648936579 mm， [EN]  2,297,888  sectors； [EN] Track Pitch [EN] 。",
  "totalSectors": 2297888,
  "innerRadiusMm": 23.991460627731737,
  "outerRadiusMm": 57.964893657925366,
  "channelBitLengthNm": 133.3,
  "pitchLinear": -3.9256854319227684E-05,
  "pitchQuadratic": 6.964795915429256E-05,
  "pitchCubic": -4.670918950137523E-05
}
```

DVD  [EN]  `totalSectors` must be greater than 0  [EN]  16  [EN] ， [EN]  ECC Block  [EN] streamingBurn [EN] 。`channelBitLengthNm`  [EN] ， [EN] 。

 [EN]  Verbatim DVD  [EN]  `calibration-f2f851f7.calibration.json`， [EN] 。

`pitchLinear`、`pitchQuadratic`、`pitchCubic`  [EN] Track Pitch [EN] ， [EN]  0， [EN] 。 [EN]  `p(x)=p0*(1+pitchLinear*x+pitchQuadratic*x²+pitchCubic*x³)`，`x=(r-innerRadiusMm)/(outerRadiusMm-innerRadiusMm)`。 [EN] ；`p0`  [EN] ， [EN]  μm  [EN] 。 [EN]  `0≤x≤1`  [EN] Track Pitchmust [EN] ，cannot [EN] 。 [EN] Unsaved [EN] Custom [EN] Status， [EN] Track Pitch [EN] 。

## Add CD  [EN] 

 [EN]  `cdPresets`  [EN] Copy [EN] ， [EN]  `id`、 [EN] 、Sector count [EN] Outer Radius。 [EN] ：

```json
{
  "id": "cd-74",
  "displayName": "Standard 74-min CD",
  "description": "ECMA-130／ISO/IEC 10149 standard [EN]  1200 mm/s；120 mm  [EN] 、 [EN]  74 minutes，333,000 sectors（24.5–56.8 mm）。",
  "sectors": 333000,
  "innerRadiusMm": 24.5,
  "outerRadiusMm": 56.8,
  "linearVelocityMmPerSecond": 1200
}
```

## AddBlu-ray [EN] 

 [EN]  `bluRayPresets`  [EN] Copy [EN] ， [EN]  `id`、 [EN] 。 [EN] ：

```json
{
  "id": "bd-r-ritek-10x",
  "displayName": "Ritek BD-R 10x [Calibrated]",
  "description": "measured [EN] ：Inner Radius 23.988221 mm、Outer Radius 58.023235 mm、12,219,392 sectors。",
  "totalSectors": 12219392,
  "innerRadiusMm": 23.98822105616562,
  "outerRadiusMm": 58.023234731100764,
  "invertMapping": false
}
```

BD  [EN]  `totalSectors` must be greater than 0、 [EN]  32  [EN] Single Layer [EN]  12,219,392；Outer Radius [EN]  60 mm。`invertMapping`  [EN]  3T/6T polarity， [EN] Design [EN] Tone [EN] 。

 [EN]  `bd-r-verbatim-64099`（Verbatim BD-R (64099)） [EN]  `disc-presets.json`  [EN] Saved [EN] 「Verbatim 64099」 [EN] ， [EN] ：Inner Radius `23.987042157339335` mm、Outer Radius `57.987960341783236` mm、`12,219,392` sectors、`invertMapping: false`。GUI  [EN] 。

##  [EN] 

 [EN] 、 [EN] 、 [EN] Outer Radius [EN]  DVD channel bit  [EN] ， [EN] ， [EN]  1200 mm/s（ECMA-130）、0°、57.5 mm  [EN]  133.3 nm。

 [EN]  JSON  [EN] ， [EN] ， [EN] 。 [EN] 。

## i18n  [EN] 

 [EN]  `fallbackLanguage`、`displayNameResourceKey`  [EN]  `descriptionResourceKey`。 [EN]  `displayName`  [EN]  `description`； [EN] ， [EN] ， [EN]  JSON  [EN] 。 [EN] 。

##  [EN] 

-  [EN]  `"schemaVersion": 4`， [EN]  `cdPresets`、`dvdPresets`、`bluRayPresets`、 [EN]  `fallbackLanguage`。 [EN]  `"schemaVersion": 2`  [EN]  `3`； [EN]  BD directory [EN]  BD  [EN] ，Save [EN]  4。
-  [EN]  `id` must [EN] ；`__manual__`  [EN] “Unsaved [EN] Custom [EN] ”Status [EN]  ID，cannot [EN]  JSON。
-  [EN] ； [EN] ， [EN] Disc Media [EN] 。
-  [EN] 、`linearVelocityMmPerSecond`  [EN]  `channelBitLengthNm` must be a finite positive number， [EN] Outer Radiusmust [EN] Inner Radius。
- 文件允许 `//`  [EN]  `/* ... */`  [EN] 。
-  [EN] invalid， [EN] succeeded [EN] ， [EN] 。
