# Blu-raybytes [EN] 

 [EN] Single Layer BD-R  [EN] ， [EN] 。 [EN] polarity， [EN] Burn。 [EN]  [ [EN] ](../../docs/BLURAY_BYTE_DENSITY.md)。

 [EN]  .NET 10 SDK； [EN] standard [EN]  Python standard [EN] ， [EN]  matplotlib / numpy。 [EN] directory [EN] ：

```powershell
dotnet run --project tools/BluRayByteProbe --configuration Release -- artifacts/bluray-byte-density 4
dotnet run --project tools/BluRayByteProbe --configuration Release -- --fine artifacts/bluray-byte-density

python tools/BluRayByteProbe/reference/analyze.py --output-dir artifacts/bluray-byte-density/reference
python tools/BluRayByteProbe/reference/pattern_search.py --output-dir artifacts/bluray-byte-density/reference
python tools/BluRayByteProbe/reference/robust_pattern_search.py --output-dir artifacts/bluray-byte-density/reference

dotnet run --project tools/BluRayByteProbe --configuration Release -- --verify-reference artifacts/bluray-byte-density/reference/independent-finite-vectors.json
dotnet run --project tools/BluRayByteProbe --configuration Release -- --verify-patterns artifacts/bluray-byte-density/reference/independent-pattern-vectors.json
python tools/BluRayByteProbe/plot_results.py artifacts/bluray-byte-density
```

 [EN]  256  [EN]  Q bytes， [EN]  17PP、 [EN]  DC  [EN] 、 [EN]  PSN、 [EN] scrambling [EN]  host  [EN] 、 [EN] 。 [EN] （1–16）。`--fine`  [EN] 、 [EN] ， [EN] ； [EN]  4。

Q  [EN] **scrambling [EN] **。 [EN]  host payload  [EN]  `Q XOR PSN mask`。 [EN] directory， [EN] 。

 [EN] ：

|  [EN]  |  [EN]  |
|---|---|
| `all-bytes.csv` / `.json` / `.md` |  [EN]  256 bytes； [EN] 、DC  [EN]  run  [EN]  |
| `all-bytes-density.png` | 16 × 16  [EN]  |
| `fine-patterns.json` / `.csv` | 176  [EN] / [EN] / [EN]  |
| `fine-pattern-comparison.png` | bytes [EN]  |
| `recommended-patterns.csv` |  [EN] recommended [EN]  |
| `context.json` / `periodic-context.json` |  [EN]  ECC  [EN] 、 [EN]  DC  [EN]  |
| `reference/` |  [EN] standard [EN] 、 [EN]  |
| `method.json` / `validation.json` / `fine-validation.json` |  [EN]  |

 [EN]  `496 × 1932 = 958272` channel bits， [EN] 、EDC、LDC/BIS、DC  [EN]  17PP； [EN]  run-in/out/Guard3， [EN]  run-in  [EN]  DSV。 [EN]  DC  [EN]  greedy ** [EN] ** [EN] ， [EN] ；cannot [EN] Recorder [EN]  DC  [EN] 。 [EN]  0、 [EN]  1、 [EN]  DC  [EN] ，cannot [EN] Burn [EN] 。

`FinePatternAnalysis`  [EN]  payload bit  [EN]  ECC  [EN] ， [EN] ； [EN]  65,536  [EN]  Q bytes [EN] bytes [EN] 。EDC、BIS、parity  [EN]  DC  [EN] ， [EN] 。
