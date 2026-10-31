# Contributing to Disc Image Studio

 [EN]  Disc Image Studio。 [EN] ； [EN] 、 [EN] 、 [EN] 、 [EN] 。

##  [EN] 

 [EN]  GitHub Issues  [EN] ， [EN] ：

-  [EN] （ [EN]  / MSIX  [EN] ）， [EN]  Windows  [EN] 。
-  [EN] 、 [EN] 。
-  [EN] 。

Burn [EN] Recorder [EN] 、 [EN] Disc Media [EN] / [EN] ： [EN] measured [EN] ， [EN] 。

 [EN] ** [EN] ** [EN]  Issue  [EN] ， [EN] [ [EN] ](SECURITY.md) [EN]  GitHub  [EN] 。

 [EN]  Issues： [EN] 、 [EN] ， [EN] 。

##  [EN] 

- Windows 10 2004+  [EN]  Windows 11。
- .NET 10 SDK； [EN]  `global.json`  [EN]  `10.0.x`， [EN]  `dotnet`  [EN] 。
-  [EN] ， [EN] 。

```powershell
git clone < [EN]  fork  [EN] >
cd DiscImageStudio
dotnet build DiscImageStudio.slnx --configuration Release
dotnet run --project src/DiscImageStudio.App --configuration Release
```

##  [EN] 

 [EN] [ [EN] ](docs/ARCHITECTURE.md)。 [EN] ： [EN] Optical Disc [EN] ， [EN] 。 [EN] ：

1.  [EN]  CD/DVD/ [EN] Blu-ray [EN] 、 [EN] 、sectors [EN]  `DiscImageStudio.Core`  [EN] 。
2.  [EN]  GUI  [EN] Status， [EN]  `DiscJobRequest`； [EN] 。
3.  [EN] cannot [EN] Cancel [EN] ，`SupportsCancellation` must [EN]  `false`。
4.  [EN]  ID  [EN] ，directory [EN] 。
5.  [EN] must [EN]  `DiscCommandDescriptor`， [EN] directory [EN] 。

##  [EN] 

-  [EN] 、 [EN] ； [EN] Warning、 [EN] Error。
-  [EN] ； [EN] Add [EN] 。
- Delete [EN] ， [EN]  Issue  [EN]  PR  [EN] 。
-  [EN] 、 [EN]  / PFX  [EN] 。

##  [EN] 

Pull Request  [EN] must [EN] ：

```powershell
dotnet build DiscImageStudio.slnx --configuration Release
dotnet run --project src/DvdImageSolver --configuration Release -- selftest
dotnet run --project tests/DiscImageStudio.ArchitectureTests --configuration Release
```

 [EN] ， [EN] ：

-  [EN] 、streamingBurn [EN] Disc Media [EN] ， [EN]  [VALIDATION.md](docs/VALIDATION.md)  [EN] 。
-  [EN]  GUI  [EN] ， [EN] ， [EN]  `docs/images/`。
- Delayed interleaving、EFMPlus、ECC  [EN] ，`selftest`  [EN] 。

##  [EN]  Pull Request

1. Fork（ [EN]  `main`  [EN] ） [EN] ， [EN] ， [EN] 。
2.  [EN] ； [EN] 、 [EN] ， [EN] 。 [EN]  emoji！
3. PR  [EN] 、 [EN] ； [EN] ， [EN]  `CHANGELOG.md`  [EN]  Unreleased  [EN]  `docs/`  [EN] 。
4.  [EN]  GitHub Actions  [EN]  `build`  [EN] 。

 [EN] （ [EN] 、 [EN]  UI  [EN] 、Burn [EN] ） [EN]  Issue  [EN]  Draft PR  [EN] ， [EN] 。

##  [EN] 

 [EN]  `main`  [EN] ， [EN] 、 [EN] 、 [EN] 。 [EN]  `CHANGELOG.md`  [EN]  `Unreleased`； [EN]  PR  [EN]  `Directory.Build.props`  [EN] ， [EN]  `main`  [EN]  GitHub Actions  [EN]  Release  [EN] 。 [EN]  push  [EN]  Release。 [EN] 、 [EN] 、 [EN] [ [EN] ](docs/RELEASING.md)。

##  [EN] 

 [EN]  [GNU GPL v3.0 or later](LICENSE)（`GPL-3.0-or-later`）。 [EN] ， [EN] 。 [EN] 、 [EN] ， [EN] ， [EN]  [ [EN] ](THIRD-PARTY-NOTICES.txt)； [EN]  [LICENSE-NOTICE.md](LICENSE-NOTICE.md)。
