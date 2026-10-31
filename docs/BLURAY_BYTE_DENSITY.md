# Single Layer BD-R：bytes [EN] 

2026-10-24。 [EN]  ISO/IEC 30190:2021， [EN]  13.15–13.18、Figure 40/41， [EN]  EDC、scrambling、LDC/BIS、DC、17PP  [EN] 。 [EN] Single Layer [EN] 。

** [EN] ： [EN] 。**  [EN] bytes [EN]  **19.20% / 38.61%**； [EN] interleaving [EN]  DC  [EN] ， [EN]  **15.95% / 43.37%**。 [EN]  19.41  [EN]  27.42  [EN] ， [EN]  41%。 [EN] ， [EN] Brightness [EN] OK。 [EN]  **3T / 6T  [EN] **， [EN] 。

##  [EN]  3T / 6T  [EN] 

 [EN]  958,272 channel bits  [EN] ， [EN]  modulation ONE  [EN]  3T  [EN]  6T  [EN] ** [EN] **。mark  [EN]  space  [EN] ； [EN]  NRZI  [EN] ， [EN]  ` [EN]  run  [EN]  /  [EN]  run  [EN] `  [EN] 。

|  [EN]  | scrambling [EN]  Q |  [EN]  run  [EN]  |  [EN]  run  [EN]  |  [EN]  |
|---|---|---:|---:|---:|
|  [EN] （0–127）， [EN]  3T | `AA` | 265,136 | 85.4164% | 264,946–265,186 |
|  [EN] （128–255）， [EN]  6T | `44` | 116,575 | 62.6862% | 116,470–116,659 |

 [EN]  PSN `0x100000`  [EN]  256  [EN] bytes [EN] 。6T  [EN]  `22`  [EN]  62.7744%， [EN]  116,402  [EN]  6T， [EN]  `44`， [EN]  `44`。 [EN]  `0x100000`、`0x234560`、`0x6D3A00`、`0xCA73E0`  [EN] ，`44`  [EN]  6T  [EN]  116,559.5， [EN]  `11`  [EN]  116,526.5  [EN]  `22`  [EN]  116,457； [EN] 。

 [EN]  `BluRayRunLengthMapping`  [EN]  128  [EN]  `AA` / `44`， [EN] ；`BluRayImagePayloadMapping`  [EN] ，streaming [EN] scrambling [EN]  host payload。 [EN] 、EDC、ECC、BIS、DC  [EN]  run  [EN] ， [EN] “ [EN]  3T / 6T” [EN]  3T / 6T。 [EN] ， [EN] Brightnesscalibration。

 [EN]  greedy DC  [EN] ； [EN]  `all-bytes.json`  [EN]  `Cluster.RunCounts`。 [EN]  RUB  [EN] 、 [EN] ， [EN] scrambling [EN]  ECC  [EN] 。 [EN] [Blu-ray [EN] ](ADDING_BLURAY.md)。

##  [EN] 

-  [EN]  = modulation ONE  [EN]  / channel-bit  [EN] 。ONE  [EN]  NRZI  [EN] ，cannot [EN]  NRZI  [EN]  ONE  [EN] 。
- Q  [EN] **scrambling [EN]  payload**。host payload  [EN]  `Q XOR scrambling [EN] `； [EN]  host bytes [EN] 。
-  [EN]  17PP  [EN]  DC、ECC、BIS、 [EN] ； [EN] standard [EN] Status [EN] 。
-  [EN]  65,536 host bytes  [EN] ， [EN]  `496 × 1932 = 958272` channel bits， [EN]  EDC、LDC parity、BIS、DC、 [EN] ； [EN]  run-in/out/Guard3， [EN]  run-in  [EN]  DSV。
-  [EN]  PSN  [EN]  `0x100000`， [EN]  flags  [EN]  user control data  [EN] 。 [EN]  `0x234560`、`0x6D3A00`、`0xCA73E0`  [EN] 。
-  [EN]  greedy DC  [EN] ： [EN] 。 [EN] Recorder [EN] ； [EN]  0、 [EN]  1、 [EN]  DC  [EN] ， [EN] Burn [EN] 。

##  [EN]  256 bytes [EN] 

 [EN]  Q bytes， [EN]  DC/ECC  [EN] ：

|  [EN]  17PP  [EN]  | bytes [EN]  |
|---|---:|
| 1/6 = 16.6667% | 28 |
| 1/4 = 25% | 92 |
| 1/3 = 33.3333% | 100 |
| 5/12 = 41.6667% | 36 |

 [EN]  **80  [EN] bytes [EN] **。DC  [EN] ， [EN] cannot [EN] 。

| Q |  [EN]  17PP |  [EN]  greedy |  [EN]  PSN  [EN]  |  [EN]  |
|---|---:|---:|---:|---|
| `09` | 16.6667% | 19.1997% | 19.1962–19.2080% |  [EN] bytes |
| `11` | 16.6667% | 19.4820% | 19.4447–19.4820% |  [EN]  6T， [EN]  run  [EN]  |
| `22` | 16.6667% | 19.3505% | 19.3242–19.3510% |  [EN]  |
| `3D` | 41.6667% | 38.4602% | 38.4428–38.4739% |  [EN] bytes |
| `7A` | 41.6667% | 38.5486% | 38.5409–38.5525% |  [EN] bytes |
| `9E` | 41.6667% | 38.6143% | 38.6014–38.6260% |  [EN] bytes |
| `00` | 33.3333% | 32.8615% | 32.8412–32.8668% |  [EN]  |
| `FF` | 33.3333% | 32.5332% | 32.5332–32.5639% |  [EN]  `00`  [EN]  |

`55/AA`  [EN]  32.30% / 32.39%， [EN] 。 [EN] scrambling， [EN]  14  [EN]  host  [EN]  29.37–29.67%， [EN] 。

 [EN] ：[CSV](../artifacts/bluray-byte-density/all-bytes.csv)、[ [EN] ](../artifacts/bluray-byte-density/all-bytes.md)、[256 bytes [EN] ](../artifacts/bluray-byte-density/all-bytes-density.png)。

##  [EN] 

17PP  [EN]  2/4/6/8  [EN] ， [EN]  modulation bit  [EN] 。bytes [EN] ，cannot [EN] 。

|  [EN]  |  [EN]  | bytes [EN]  |  [EN]  17PP  [EN]  |  [EN]  run |
|---|---:|---|---:|---|
| `0001` | 4 | `11` | 16.6667% |  [EN]  6T |
| `00111101` | 8 | `3D` | 41.6667% | 3  [EN]  2T、2  [EN]  3T |
| `001111` | 6 | `3C F3 CF` | 44.4444% | 3  [EN]  2T、1  [EN]  3T |
| `0000101101110010` | 16 | `0B 72` | **12.5%** |  [EN]  8T |
| `0111011110` | 10 | `77 9D E7 79 DE` | **46.6667%** | 6  [EN]  2T、1  [EN]  3T |

 [EN]  17PP  [EN]  run  [EN]  2T–8T， [EN]  2T。 [EN]  `1/8`， [EN]  `7/(6×2+3)=7/15`； [EN]  16  [EN]  10  [EN] 。 [EN]  9T，cannot [EN] 。

 [EN]  29.1667% / 33.3333%。6  [EN]  `001111`  [EN]  44.4444%， [EN]  NRZI  [EN]  4/9  [EN] ， [EN]  DC  [EN] 。 [EN]  16  [EN] ， [EN] 。

 [EN] 。**cannot [EN]  host bytes， [EN] cannot [EN]  payload  [EN]  Q  [EN] interleaving。**  [EN]  6  [EN]  payload  [EN]  Q， [EN]  33.43–34.39%； [EN]  ECC  [EN]  40.64–40.75%。

## DC  [EN] 

 [EN]  155 ECC bytes  [EN]  1240 raw bits； [EN]  25  [EN] ， [EN]  45  [EN]  DC bit， [EN]  28  [EN] 。 [EN]  `j=8×EccColumn+bitWithinByte`， [EN]  bit 0  [EN]  MSB：

```text
DCbefore(j) = j < 25 ? 0 : 1 + floor((j - 25) / 45)

 [EN]  DC  [EN] ：
index = RecordingFrame × 1268 + j + DCbefore(j)
Qbit = pattern[(index + phase) % period]

 [EN]  DC  [EN] ：
index = j < 25 ? j : (j - 25) % 45
Qbit = pattern[(index + phase) % period]
```

DC  [EN] ， [EN] ， [EN] 。 [EN] ，DC  [EN] /Recorder [EN] 。EDC、BIS、parity  [EN] cannot [EN] ， [EN] 。

 [EN]  Q  [EN] ， [EN]  payload byte， [EN] scrambling。 [EN]  `Map(luminance, position)`  [EN]  RecordingFrame/EccColumn； [EN]  8  [EN] ， [EN] bytes。

| recommended [EN]  |  [EN]  | phase |  [EN]  greedy |  [EN]  PSN  [EN]  |  [EN]  DC  [EN]  |
|---|---|---:|---:|---:|---:|
| 16  [EN]  `0000101101110010` | DC  [EN]  | 2 | **15.9500%** | 15.9405–15.9500% | 15.9278–17.0720% |
| 6  [EN]  `001111` |  [EN]  DC  [EN]  | 3 | **40.8172%** | 40.8158–40.8315% | 41.0010–41.4603% |
| 10  [EN]  `0111011110` | DC  [EN]  | 4 | **43.3670%** | 43.3662–43.3713% | 42.1870–43.3904% |

phase  [EN]  0  [EN] ， [EN] 。 [EN] ； [EN]  phase  [EN] ， [EN] 。

6  [EN]  40.7929–40.8172%， [EN] 。 [EN]  16/10  [EN] ； [EN]  30%–32%。DC  [EN] ， [EN] Recorder [EN] 。

recommended [EN] ， [EN]  inter-transition run  [EN]  **52.65%  [EN]  8T**；recommended [EN]  **79.14%  [EN]  2T**。 [EN] 。 [EN]  greedy  [EN]  NRZI  [EN]  50%， [EN] cannot [EN]  bit  [EN]  0/1  [EN] 。

![ [EN] ](../artifacts/bluray-byte-density/fine-pattern-comparison.png)

##  [EN] 

 [EN] Disc Media、Burn [EN] ， [EN] 、 [EN] 、Outer Radius [EN] ：

1.  [EN] ：16  [EN] 、DC  [EN] 、phase 2。
2.  [EN] ：10  [EN] 、DC  [EN] 、phase 4。
3.  [EN] ：6  [EN] 、 [EN]  DC  [EN] 、phase 3。
4. bytes [EN] ：`09`、`11`、`9E`；`00`  [EN] 。

 [EN] ， [EN] 。 [EN] bytes [EN] ， [EN] Brightness [EN] 。 [EN] Burn， [EN] 。

##  [EN] 

- 独立 Python 实现按standard Figure 41 转录；与 C#  [EN]  256  [EN] bytes [EN] 、298  [EN] 。
-  [EN]  2–16  [EN]  131,068  [EN] ， [EN]  preceding bit， [EN]  262,136  [EN] ； [EN]  14,694  [EN] 。 [EN] Search Range。
-  [EN]  256 bytes； [EN] bytes 8  [EN]  DC mask × 31  [EN]  × 2  [EN]  termination。
-  [EN]  176  [EN] / [EN] / [EN] ， [EN]  120  [EN] 。 [EN]  65,536  [EN]  Q bytes [EN]  ECC  [EN] 。
-  [EN] 、run  [EN]  RLL  [EN] ； [EN]  RUB path [EN] 。 [EN]  2T–8T  [EN]  run； [EN]  9T。

 [EN]  [BluRayByteProbe](../tools/BluRayByteProbe/README.md)。 [EN]  `artifacts/bluray-byte-density/`， [EN]  artifacts directory [EN] ； [EN] 。 [EN]  3T / 6T  [EN] 。
