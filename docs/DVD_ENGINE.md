# DVD NRZI  [EN] 

 [EN]  16  [EN]  DVD  [EN] sectors [EN]  ECC Block， [EN]  NRZI pit/land  [EN] 。

 [EN] ：

- Single LayerDisc Media Data Zone，Sector Information  [EN]  `0x00`；
- DVD-R Data Frame  [EN]  RSV  [EN]  `0x00`；
-  [EN]  ECC Block  [EN]  LBA， [EN] sectors [EN]  `LBA + 1 ... LBA + 15`；
- `PSN = PSN offset + LBA`， [EN]  offset  [EN]  `0x30000`；
- DSV  [EN]  Stream 1；
- `pit = 0 =  [EN] `，`land = 1 =  [EN] `；
-  [EN]  32768 bytes， [EN]  16  [EN]  2048-byte payload。

 [EN]  ID、IED、 [EN]  RSV、EDC、 [EN] scrambling、RS-PC PO/PI、PO  [EN] interleaving、EFMPlus  [EN] / [EN] 、SYNC/DSV  [EN]  NRZI  [EN] 。

 [EN] [Grayscale [EN] ](../tools/DvdGrayProbe/README.md) [EN]  `FastDispersionImageWriter.WriteScrambledCodewordPatternStream`， [EN]  payload  [EN] scrambling Q， [EN]  `P = Q XOR mask`。 [EN] grayscale [EN] ， [EN]  `64/E4`  [EN] Dither [EN] ； [EN] 。 [EN]  ECC/EFM， [EN] Brightness。 [EN]  ECC/EFM  [EN] ， [EN]  payload、 [EN] 、 [EN] Cancel。

##  [EN] 

 [EN]  Windows  [EN]  .NET 10 SDK； [EN]  .NET 10 Windows  [EN] ：

```powershell
dotnet build DvdImageSolver.slnx --configuration Release
dotnet run --project src/DvdImageSolver --configuration Release -- selftest
```

 [EN] ：

- ECMA-267  [EN] ；
- ID、IED、RSV  [EN]  EDC；
- scrambling [EN] ；
- 208  [EN]  PI  [EN]  172  [EN]  PO  [EN] ；
- 619008  [EN]  NRZI  [EN] 、OK [EN]  RLL(2,10)  [EN] ；
- 16-bit [EN] pit/land [EN] grayscale、 [EN] DSV [EN] ；
-  [EN] SYNC Frame [EN] grayscale、SYNC [EN] 、 [EN] State/DSV/ [EN] bit [EN] ；
-  [EN] EFMPlus [EN] Status [EN] bit [EN] SYNC [EN] ；
- state-control [EN] DVD [EN] ， [EN] 619008-bit [EN] ；
- dispersion [EN] `0x92/0xA5`scrambling [EN] 、 [EN] scramblingISO payload [EN] ；
-  [EN]  ISO9660  [EN] 、Path Table、 [EN] directory、payload LBA  [EN] 。
-  [EN] calibration PNG  [EN]  ECC Block  [EN] 。
- Inner Ring ISO9660/Joliet  [EN] 、Unicode  [EN] directory [EN] Outer Ring [EN] 。

##  [EN] 

 [EN]  NRZI  [EN] ：

```text
0  [EN]  P    pit， [EN] 
1  [EN]  L    land， [EN] 
?          [EN] 
```

 [EN] 。 [EN] must [EN] ：

- 38688  [EN] ： [EN] sectors， [EN]  `--target-sector 0..15`  [EN]  ECC Block  [EN] ；
- 619008  [EN] ： [EN]  ECC Block。

SYNC、RLL、EDC  [EN]  ECC  [EN] ， [EN]  bit  [EN] 。`full` [EN] NRZI bits [EN] ； [EN] `state-control` [EN] ， [EN] pit/land [EN] Error， [EN] land [EN] 0 [EN] 16 [EN] grayscale [EN] 。 [EN] payload [EN] ， [EN] channel [EN] 。

`dispersion` [EN] pit/land [EN] ， [EN] EFMPlus [EN] 。 [EN] scrambling [EN] bytes`Q=0xA5/0x92`， [EN] Status [EN] 5/2 [EN] transition。 [EN] Brightness0–127 [EN] A5、128–255 [EN] 92， [EN] Brightness [EN] 0/255。 [EN] 66 [EN] B9 [EN] Grayscale。NRZI [EN] transition [EN] 。

 [EN] Dither [EN] grayscale [EN] `0/255`（ [EN] ）， [EN] calibration [EN] Recentpixels [EN] ， [EN] pixels [EN] ； [EN] grayscale、 [EN] 。 [EN] CD/DVD [EN] Copy [EN] ， [EN] Dither， [EN] grayscale [EN] 。`full` [EN] `state-control` [EN] 。

##  [EN] 

 [EN]  PNG、JPEG、BMP、TIFF  [EN]  GIF：

```powershell
dotnet run --project src/DvdImageSolver --configuration Release -- solve `
  --image picture.png `
  --total-sectors 2295104 `
  --iso-output solved-disc.iso `
  --output payload.bin `
  --lba 0 `
  --psn-offset 0x30000 `
  --inner-radius-mm 24 `
  --outer-radius-mm 58 `
  --channel-bit-nm 133.3 `
  --start-angle-deg 0 `
  --spiral-direction ccw `
  --image-threshold 128 `
  --alpha-threshold 1 `
  --iterations 10000 `
  --constraint-output mapped-target.txt `
  --channel-output channel.bin
```

 [EN]  `--total-sectors`  [EN] Disc Media [EN]  2048-byte  [EN] ； [EN]  `--total-blocks`。 [EN] sectors 38688 channel bits、`--channel-bit-nm`  [EN] OK [EN] 。 [EN] Outer Radius [EN] Track Pitch [EN] Track Pitch [EN] 。

###  [EN] Track Pitch

DVD  [EN] 、streaming [EN] 、 [EN] 、ISO  [EN] Assisted Calibration [EN]  `DvdTrackGeometry`。 [EN]  `x=(r-ri)/(ro-ri)`， [EN] Track Pitch [EN] ：

```text
p(x) = a0 + a1*x + a2*x² + a3*x³                 [mm]
     = p0 * (1 + c1*x + c2*x² + c3*x³)
dr/dθ = p(x)/(2π)
```

 [EN] 。 [EN]  `--pitch-linear`、`--pitch-quadratic`、`--pitch-cubic`  [EN]  `c1,c2,c3`； [EN]  `a0=p0`  [EN] ， [EN]  `ai=p0*ci`。 [EN] Outer Radius [EN] ， [EN] 。 [EN]  μm  [EN] ， [EN]  `x`， [EN]  mm  [EN] 。

 [EN]  `L=∫sqrt(1+(2πr/p(r))²)dr`， [EN]  `θ(r)=∫2π/p(r)dr`； [EN] Track Pitchcannot [EN]  `(r-ri)/b`  [EN] 。 [EN] Track Pitch [EN] ， [EN] 。 [EN] Track Pitch [EN] ， [EN] 。

 [EN]  `solve`  [EN]  `--pitch-linear 0.02 --pitch-quadratic -0.03 --pitch-cubic 0.015`。 [EN] ， [EN] Disc Media [EN] measured [EN] 。`calibrate`  [EN] ， [EN]  `--actual-pitch-linear`、`--actual-pitch-quadratic`、`--actual-pitch-cubic`  [EN] ； [EN]  `--generated-pitch-*`  [EN] 。`simulate`  [EN]  `--pitch-*`  [EN] Disc Media [EN] 。

 [EN]  JSON  [EN] Track Pitch [EN] ，calibration [EN] Save [EN] 、 [EN] Outer Radius、Sector count [EN] Bit Length， [EN] 。 [EN] fitting [EN] 。

 [EN] ：

-  [EN] Disc Media [EN] ， [EN] ， [EN] ；
-  [EN] Inner Radius [EN]  0°  [EN] ，0°  [EN] ； [EN] ， [EN]  `--spiral-direction cw`  [EN] ；
-  [EN]  pit， [EN]  land；grayscale [EN]  `--image-threshold`  [EN] ；
- alpha  [EN]  `--alpha-threshold`  [EN] ；
- `--lba`  [EN] ， [EN]  LBA  [EN]  16  [EN]  sector；
- `--constraint-output`  [EN] ， [EN] Export [EN]  619008-symbol  [EN] 。

##  [EN] 

```powershell
dotnet run --project src/DvdImageSolver --configuration Release -- solve `
  --target target.txt `
  --output payload.bin `
  --lba 0 `
  --psn-offset 0x30000 `
  --initial-state 1 `
  --initial-dsv 0 `
  --initial-level land `
  --target-sector 0 `
  --iterations 10000 `
  --mutation-bytes 4 `
  --seed 1 `
  --channel-output channel.bin
```

 [EN] ：

- `--lba`：ECC Block  [EN]  LBA， [EN]  16  [EN]  LBA；
- `--psn-offset`： [EN]  `0x`  [EN] ， [EN]  `0x30000`；
- `--initial-state`：EFMPlus Status 1  [EN]  4；
- `--initial-dsv`： [EN]  ECC Block  [EN]  DSV；
- `--initial-level`： [EN] Status `pit`  [EN]  `land`；
- `--seed-payload`： [EN]  32768-byte  [EN] ； [EN] OK [EN] ；
- `--initial zero`： [EN]  payload；
- `--channel-output`： [EN]  NRZI  [EN] ， [EN] 8 [EN]  MSB-first  [EN] 。

`--target`  [EN]  `--image`  [EN] 。 [EN] must [EN]  `--total-sectors`  [EN]  `--total-blocks`。

### State-control [EN] grayscale [EN] 

 [EN] payload [EN] `--algorithm full`， [EN] `exact`。 [EN] bytes [EN] Delete； [EN] ：

```powershell
dotnet run --project src/DvdImageSolver --configuration Release -- solve `
  --image picture.png `
  --total-sectors 2297888 `
  --output payload.bin `
  --algorithm state-control `
  --bridge-bytes 2 `
  --beam-width 8 `
  --retry-beam-width 32 `
  --retry-frame-fraction 0.25 `
  --batch-frames 8 `
  --batch-candidates 4 `
  --search-lanes 1 `
  --iterations 3
```

state-control [EN] 91-byte Sync Frame [EN] 。EDC、PI、PO、 [EN] SYNC [EN] State、DSV [EN] pit/land [EN] ； [EN] bytes [EN] ， [EN] 。 [EN] `EFMPlus state ×  [EN]  ×  [EN] DSV` [EN] / [EN] bytes [EN] 。 [EN] Stream [EN] Status [EN] bytes； [EN] `--beam-width` [EN] path。 [EN] `--bridge-bytes` [EN] payloadbytes [EN] ， [EN] DSVbytes [EN] ， [EN] 256 [EN] 。

 [EN] 65536 [EN] 16-bit [EN] pit [EN] land [EN] ：

- 16 [EN] NRZI [EN] land [EN] ， [EN] 0 [EN] 16 [EN] 17 [EN] grayscale；
-  [EN] pit/land；
-  [EN] DSV [EN] ；
-  [EN] ， [EN] RLL [EN] 。

bytes [EN] EFMPlus [EN] grayscale [EN] `|DSV|`， [EN] ` [EN] grayscale [EN]  × 16 +  [EN] |DSV|`。 [EN] grayscale [EN] 15 [EN] DSV [EN] ， [EN] DSV [EN] grayscale [EN] bytes [EN] 。 [EN] DSV -256..256bytes [EN] ； [EN] exceeds [EN] DSV [EN] ， [EN] 。 [EN] bytes [EN] scrambling [EN] 、 [EN] EFMPlus [EN] recording-framebytes； [EN] ISO [EN] payload [EN] scrambling [EN] ， [EN] 。

 [EN] EFMPlus [EN] ， [EN] 16 [EN] channel levels。 [EN] beampath [EN] SaveStream 1 [EN] Stream 2， [EN] Error [EN] 。SYNC [EN] / [EN] 、Stream 1 [EN] 、 [EN] DSV [EN] ； [EN] Sync Frame [EN] 91bytes [EN] ， [EN] DSV [EN] SYNC。 [EN] 、grayscale [EN] ； [EN] `--channel-output` [EN] bit [EN] 。

state-control [EN] ： [EN] payload [EN] `controlled-majority-error`， [EN] `controlled-gray-error`， [EN] DSV。 [EN] JSON [EN] `majority-error`/`score` [EN] channel [EN] ： [EN] Sync Frame [EN] 2 [EN] SYNC [EN] 91 [EN] ， [EN] ECC Block [EN] `416 × 93 = 38688`。 [EN] `gray-error` [EN] 38688 [EN] 。 [EN] bytes [EN] `controlledScore` [EN] `controlledGrayScore`； [EN] 。

 [EN] pass [EN] ECC Block [EN] Sync Frame [EN] controlled majority/gray [EN] ， [EN] `--retry-frame-fraction`（ [EN] 0.25） [EN] 。 [EN] warm-start [EN] ， [EN] ； [EN] EFM [EN] ， [EN] must [EN] EDC、PO、PI [EN] completed [EN] 。 [EN] ECC [EN] recording frames： [EN] payload [EN] sector、 [EN] PO [EN] PI [EN] ， [EN] ECC [EN] 。 [EN] `--batch-frames`（ [EN] 8） [EN] ， [EN] `--batch-candidates`（ [EN] 4） [EN] EFM [EN] 。 [EN] controlled [EN] 。 [EN] failed [EN] ， [EN] ； [EN] failed [EN] `--retry-beam-width`（ [EN] 32） [EN] 。 [EN] succeeded [EN] ， [EN] 。 [EN] pass [EN] 。`--retry-frame-fraction 0` [EN] pass [EN] ，`--retry-beam-width 0`Close [EN] 。

`--beam-width`、`--retry-beam-width` [EN] `--batch-candidates` [EN] ， [EN] ECC [EN] ， [EN] 。`--batch-frames` [EN] ， [EN] PO/PI [EN] ； [EN] 。`--iterations` [EN] `--iterations-per-block` [EN] pass [EN] ， [EN] 3。 [EN] `--algorithm control` [EN] ； [EN] `--frame-candidates`、`--parallel-candidates`、`--parallelism`、`--word-candidates` [EN] `--control-bytes` [EN] 。`--mutation-bytes` [EN] `full` [EN] 。

`--search-lanes 1..8` [EN] 50% [EN] 。lane 1 [EN] payload [EN] ； [EN] lane [EN] `--seed` [EN] OK [EN] payload [EN] ， [EN] `--initial-temperature` [EN] `--final-temperature` [EN] ， [EN] PO/PI [EN] 。 [EN] lane [EN] ECC [EN] ， [EN] lane [EN] ， [EN] controlled majority、gray、 [EN] `|DSV|` [EN] ， [EN] lane 1。 [EN] 1 [EN] 。 [EN] sector [EN] `--search-lanes 4 --iterations-per-block 10`； [EN] payload， [EN] payload [EN] 1。

`full/exact` [EN] payload [EN] ， [EN] `256^32768` [EN] 。 [EN] `--image-threshold` [EN] pixels [EN] ；state-control [EN] 16-bit payload [EN] ， [EN] 0 [EN] 16，8:8 [EN] 。 [EN] ， [EN] land [EN] 0/16 [EN] grayscale [EN] 。 [EN] 16 [EN] bit [EN] ； [EN] channel-bit [EN] ， [EN] `full`。

### Dispersion [EN] bytes [EN] 

`--algorithm dispersion`（ [EN] `byte-pool`） [EN] scrambling [EN] payload， [EN] ：

```text
 [EN] Brightness   0..127 -> Q = 0xA5 ->  [EN] 5 [EN] transition ->  [EN] 0
 [EN] Brightness 128..255 -> Q = 0x92 ->  [EN] 2 [EN] transition ->  [EN] 255
ISO payload P = Q XOR sector scrambler byte
```

 [EN] payload [EN] 16 [EN] channel bits [EN] disc surface [EN] ， [EN] ， [EN] `--constraint-step` [EN] `--image-threshold` [EN] ；`--image-threshold` [EN] `full/state-control` [EN] 。ID、IED、 [EN] RSV、EDC、PI、PO [EN] SYNC [EN] standard [EN] ； [EN] 619008 [EN] NRZI bits， [EN] recording frames [EN] ， [EN] EFMPlus state、DSV [EN] pit/land [EN] ECC Block。

#### ToneDither

 [EN] ， [EN] payloadbytes [EN] ：

```powershell
--tone-dither 1 --tone-levels 2 --tone-brightness 0
```

- `--tone-dither 0..1`：0  [EN]  `--image-threshold`  [EN] ；1  [EN] bytesDither [EN] ， [EN] grayscale [EN] 。
- `--tone-levels`：DVD  [EN] ， [EN]  2。
- `--tone-brightness -64..64`： [EN] grayscale。

Dither [EN] payloadbytes [EN] ， [EN] ；`simulate`  [EN]  ISO  [EN]  `0xA5/0x92`  [EN] ， [EN] Dither [EN] 。 [EN] bytes [EN] 。

 [EN] Burn [EN] 、 [EN] EFMPlus [EN] ， [EN] `--fast-output true`。 [EN] payload [EN] ， [EN] dispersion [EN] 2048-byte sector； [EN] 32 KiBscrambling [EN] `Q` [EN] ISObytes`P`， [EN] Data Frame、EDC、PI、PO [EN] Recording Frame， [EN] EFMPlus、DSV [EN] pit/landStatus。JSON [EN] `exactEccEfmReplay` [EN] `false` [EN] `finalBoundary` [EN] `null`。 [EN] Burn [EN] ：Recorder [EN] 2048-byte sector [EN] 。

```powershell
& ".\src\DvdImageSolver\bin\Release\net10.0-windows\DvdImageSolver.exe" solve `
  --image target.png `
  --total-sectors 2297888 `
  --iso-output "R:\full-disc-fast.iso" `
  --fill-sectors 2297888 `
  --lba 0 `
  --psn-offset 0x30000 `
  --inner-radius-mm 24 `
  --outer-radius-mm 58 `
  --channel-bit-nm 133.3 `
  --algorithm dispersion `
  --fast-output true `
  --fast-parallelism 0 `
  --initial zero
```

`--fast-parallelism 0` [EN] ECC Block payload， [EN] LBA [EN] ； [EN] `1..64` [EN] CPU [EN] 。 [EN] bytes [EN] 。

 [EN] streaming [EN]  SIMD  [EN] 。 [EN]  payload  [EN] ， [EN]  SYNC/ECC  [EN] 。 [EN] Track Pitch [EN] ， [EN]  Newton/Hermite  [EN] ； [EN] 。 [EN] ， [EN] pixels [EN] path [EN] ； [EN] Grayscale、 [EN] ， [EN] Track Pitch [EN] 。 [EN] Track Pitch、 [EN]  SIMD  [EN] 。 [EN] Track Pitch [EN] path [EN] measured [EN] ， [EN] 。 [EN]  `double`， [EN] 。

 [EN]  API  [EN]  `MultiBlockSolveOptions.UseSimdSampling = false`  [EN] path， [EN] ； [EN]  `true`， [EN]  GUI  [EN] 。 [EN] path [EN]  payload/ [EN] 、 [EN] Track Pitch [EN] 、 [EN] pixels [EN] 、 [EN] 、 [EN] 。 [EN]  LBA  [EN]  payload bytes [EN] ； [EN] 。

 [EN] Track Pitch [EN] completed [EN] Inner Radius [EN] 、 [EN] Track Pitch [EN] ， [EN]  Newton  [EN] 。 [EN] path [EN]  `double`  [EN] 、 [EN] ， [EN] 。 [EN] 、 [EN] ； [EN] ， [EN]  `UseSimdSampling`  [EN] 。

`payload-transition-class-error=0` [EN] payload [EN] `0xA5/0x92` [EN] ， [EN] 、ECC [EN] SYNC [EN] transition [EN] 。 [EN] JSON [EN] `dispersionPool.levels` [EN] 、Qbytes、 [EN] Brightness； [EN] 。

 [EN] ：

- `payload.bin`：16  [EN] 2048-bytesectors [EN] ；
- `payload.bin.json`：PSN、 [EN] / [EN] Status、 [EN] 、 [EN] ；
-  [EN]  `channel.bin`：77376-byte  [EN]  NRZI  [EN] 。

##  [EN] Burn ISO

`solve`  [EN]  ISO， [EN]  32768-byte payload：

```powershell
dotnet run --project src/DvdImageSolver --configuration Release -- solve `
  --image picture.png `
  --total-sectors 2295104 `
  --iso-output solved-disc.iso `
  --lba 0 `
  --iterations 10000
```

 [EN]  `--total-sectors`  [EN]  ISO  [EN]  logical sector  [EN] 。 [EN]  `--iso-sectors`：

```powershell
--target target.txt --iso-output solved-disc.iso --iso-sectors 2295104
```

New [EN]  ISO9660  [EN]  `SOLVED.BIN`  [EN] ， [EN]  16  [EN]  2048-byte sector  [EN]  `--lba ... --lba+15`。 [EN]  LBA  [EN]  0  [EN] ， [EN]  ISO9660 system area， [EN]  `SOLVED.BIN`  [EN] 。 [EN]  NTFS  [EN] ， [EN] ； [EN]  `total-sectors × 2048`，Burn [EN] 。

 [EN]  ISO  [EN]  16  [EN]  sector：

```powershell
dotnet run --project src/DvdImageSolver --configuration Release -- solve `
  --image picture.png `
  --total-sectors 2295104 `
  --iso-template original.iso `
  --iso-output solved-disc.iso `
  --lba 32 `
  --iterations 10000
```

 [EN] must [EN]  2048  [EN] ； [EN] ， [EN]  sector  [EN] must [EN]  `--total-sectors`。 [EN] directory、 [EN]  UDF/ISO  [EN]  sector  [EN] ， [EN]  extent。New [EN]  ISO  [EN]  ISO9660 volume descriptor sectors 16、17。

ISO  [EN] Save [EN]  2048-byte  [EN] ， [EN]  619008-bit raw channel stream。standard DVD Recorder [EN]  ID、EDC、ECC、EFMPlus  [EN]  NRZI； [EN] ， [EN]  state、DSV  [EN]  pit/land  [EN] Burn [EN] 。

###  [EN] Disc Media [EN]  sector  [EN] 

`--fill-sectors`  [EN] 16 [EN] ， [EN]  `--lba`  [EN]  ECC Block， [EN]  state、DSV、pit/land  [EN] 。sector  [EN] must [EN] 16 [EN] 。 [EN] 2297888 sectors [EN] Disc Media， [EN] ：

```powershell
dotnet run --project src/DvdImageSolver --configuration Release -- solve `
  --image picture.png `
  --total-sectors 2297888 `
  --iso-output full-disc.iso `
  --fill-sectors 2297888 `
  --lba 0 `
  --psn-offset 0x30000 `
  --inner-radius-mm 24 `
  --outer-radius-mm 58 `
  --channel-bit-nm 133.3 `
  --constraint-step 16 `
  --algorithm state-control `
  --bridge-bytes 2 `
  --beam-width 8 `
  --retry-beam-width 32 `
  --retry-frame-fraction 0.25 `
  --batch-frames 8 `
  --batch-candidates 4 `
  --search-lanes 1 `
  --iterations-per-block 3 `
  --initial-state 1 `
  --initial-dsv 0 `
  --initial-level land
```

 [EN] 1600 [EN]  sectors  [EN] ：

```powershell
--fill-sectors 1600
```

 [EN]  LBA 0  [EN] 1599 [EN] 1600 [EN]  sector；`--total-sectors`  [EN] ， [EN] 。 [EN]  `--lba`  [EN] 0， [EN]  sector， [EN]  `(lba + fill-sectors) × 2048`。

 [EN]  ISO9660 descriptor  [EN]  sector， [EN] Burn [EN] 2048-byte/sector [EN] ， [EN]  ISO9660  [EN] 。`--constraint-step` [EN] payload [EN] ；state-control [EN] payload [EN] 。 [EN] ， [EN] 16-bit channel [EN] ， [EN] 、 [EN] SYNC [EN] 。 [EN] disc surface [EN] ， [EN] `--constraint-step 16`， [EN] payload [EN] ；`32` [EN] ，`256` [EN] 1/16 [EN] payload [EN] ， [EN] majority error [EN] 。 [EN] 143618 [EN] ECC Blocks， [EN] 160 [EN] 1600 sectors [EN] 。

dispersion [EN] payload [EN] ， [EN] `--constraint-step` [EN] ； [EN] 。

##  [EN] 

 [EN] `--data-dir` [EN] 。 [EN] directory [EN] directory [EN] standard ISO9660 + Joliet  [EN] 。`--file-position inner`（ [EN] ） [EN] Inner Ring， [EN] ；`--file-position outer`  [EN] ， [EN] 、 [EN] 。 [EN]  16-sector ECC Block  [EN] ， [EN] ， [EN] 。 [EN]  ISO  [EN]  Windows  [EN] Optical Disc [EN] Open，Joliet directory [EN] 。

```powershell
dotnet run --project src/DvdImageSolver --configuration Release -- solve `
  --image picture.png `
  --data-dir ".\disc-files" `
  --file-position outer `
  --iso-output hybrid-disc.iso `
  --total-sectors 2297888 `
  --volume-label MY_DISC `
  --inner-radius-mm 24 `
  --outer-radius-mm 58
```

 [EN] `--algorithm dispersion --fast-output true`， [EN] Outer Ring。 [EN] `--fast-output false`： [EN] Inner Ring [EN] ， [EN] Outer Ring [EN]  EFMPlus state、DSV  [EN]  pit/land， [EN] 。 [EN] Inner Ring [EN] 。

GUI Design [EN] “Accompanying Files” [EN] Select Folder， [EN] “ [EN] ：Inner Ring／Outer Ring”；Export [EN] 。 [EN] Save， [EN] streamingBurn。streamingpath [EN]  dispersion： [EN] directory [EN] ， [EN] disc surface [EN] 、 [EN] ， [EN]  ISO；Outer Ring [EN] ， [EN] 。 [EN] completed [EN] file size [EN] ，streaming [EN] 。 [EN] ， [EN] 。

 [EN] `--lba` [EN] `--fill-sectors`， [EN] Disc Media [EN] 。`--drawing-start-lba N`  [EN] ， [EN] must [EN] ， [EN] `--psn-offset` [EN] 16 sectors。`--file-position outer` must [EN]  `--data-dir`  [EN] 。

 [EN]  ISO9660  [EN] directory [EN]  Joliet Unicode  [EN] ； [EN] cannot [EN] 4 GiB， [EN] directory [EN] ，`--data-dir` [EN] / [EN] 。

##  [EN] calibration [EN] 

calibration [EN] CD [EN] ： [EN] channel [EN] ， [EN] “ [EN] ” [EN] ， [EN] “ [EN] ”。 [EN] pixels [EN] ， [EN] Track Pitch [EN] ， [EN] pixels [EN] Recent [EN] 。

```powershell
dotnet run --project src/DvdImageSolver --configuration Release -- calibrate `
  --image picture.png `
  --output calibration-preview.png `
  --total-sectors 2297888 `
  --generated-inner-radius-mm 24 `
  --generated-outer-radius-mm 58 `
  --actual-inner-radius-mm 24.2 `
  --actual-outer-radius-mm 57.8 `
  --channel-bit-nm 133.3 `
  --spiral-direction ccw `
  --image-threshold 128 `
  --alpha-threshold 1 `
  --preview-size 2048 `
  --samples-per-sector 16
```

`--samples-per-sector` [EN] ， [EN] 1–4096， [EN] 16；DVD [EN] sector [EN] 5.16 mm [EN] ，16 [EN] 0.32 mm [EN] 。 [EN] 32 [EN] 64 [EN] pixels [EN] ， [EN] 。 [EN] ； [EN] 0° [EN] ， [EN] calibration。 [EN]  `calibration-preview.png.json`， [EN] `mappingMode` [EN] `forward-channel-splat-average`， [EN] 、 [EN] 、 [EN] 。 [EN] Recorder [EN] 。

calibration [EN] 。 [EN] ， [EN]  `--lba`  [EN]  `--fill-sectors`， [EN] disc surface [EN] 。

##  [EN]  ISO  [EN] 

`calibrate`  [EN] ， [EN] " [EN] 、 [EN] measured [EN] " [EN] ； [EN] 128，`--image-threshold` [EN] 。`simulate`  [EN]  ISO  [EN] ： [EN]  payload bytes [EN]  DVD scrambling [EN] `0xA5/0x92`， [EN] 0/255， [EN] measured [EN] disc surface。 [EN] ， [EN] `0x66` [EN] 0、`0xB9` [EN] 85； [EN] 。 [EN]  cdimage  [EN] —— [EN]  ISO  [EN] ， [EN] measured [EN] 。

```powershell
dotnet run --project src/DvdImageSolver --configuration Release -- simulate `
  --iso drawing.iso `
  --output readback-preview.png `
  --inner-radius-mm 24.2 `
  --outer-radius-mm 57.8 `
  --preview-size 2048 `
  --samples-per-sector 16
```

`--total-sectors`、`--lba`  [EN] `--fill-sectors` [EN] `drawing.iso.json`（ [EN] LBA [EN] Sector count）， [EN] sidecar [EN] ISO [EN] 、 [EN] LBA 0 [EN] 。`--samples-per-sector` [EN]  sectors [EN] payloadbytes [EN] （1–2048， [EN] 16）。scrambling [EN] 66/B9 [EN] bytes [EN] 。 [EN] ， [EN] sidecar [EN] ；ISO [EN] PI/PO [EN] 。 [EN] `readback-preview.png.json`， [EN] `mappingMode` [EN] `payload-scramble-classify-splat`， [EN] 、 [EN] 。

 [EN] ： [EN]  `FastDispersionImageWriter`  [EN]  `PayloadDirectChannelOffset + 8`（16  [EN] ） [EN] ， [EN] ， [EN]  8  [EN] （ [EN]  1 µm  [EN] ）。 [EN] 、 [EN] scrambling [EN] ， [EN] " [EN] " [EN] " [EN] " [EN] ， [EN] 。

 [EN]  ISO  [EN]  sidecar  [EN]  `imageMapping.totalSectors`、`innerRadiusMm`、`outerRadiusMm`  [EN] calibration [EN] ： [EN] Import [EN] Disc Media [EN] ， [EN] 。

##  [EN] 

 [EN] path [EN] ， [EN] 、Cancel [EN] Export [EN] ：

- ** [EN] **（ [EN] ，`simulate`） [EN]  ISO， [EN] measured [EN] ， [EN] bytes。
- **Design [EN] **（calibration [EN] ， [EN] ，`calibrate`） [EN] ， [EN] /measured [EN] 。 [EN]  ISO， [EN] Refresh [EN] ； [EN] measured [EN] ， [EN] —— [EN] 。

calibration [EN] Design [EN] ， [EN] ， [EN] 。

##  [EN] 

```powershell
dotnet run --project src/DvdImageSolver --configuration Release -- encode `
  --input payload.bin `
  --output channel.bin `
  --lba 0 `
  --psn-offset 0x30000 `
  --initial-state 1 `
  --initial-dsv 0 `
  --initial-level land
```

 [EN]  PSN must [EN] 16 [EN] ； [EN] ， [EN]  ECC Block  [EN] 。

##  [EN] 

`Encoding/EfmPlusTables.Generated.cs`  [EN]  ECMA-267 Annex G  [EN] 。 [EN]  PDF  [EN] ：

```powershell
python tools/generate_efm_tables.py ECMA-267.pdf src/DvdImageSolver/Encoding/EfmPlusTables.Generated.cs
```
