#  [EN] 

##  [EN] 

 [EN]  `main`  [EN] ， [EN]  Pull Request  [EN] 。 [EN]  `main`  [EN] ； [EN] 。

 [EN] directory [EN]  `Directory.Build.props`  [EN] 。 [EN] ：

|  [EN]  |  [EN]  |  [EN]  |
| --- | --- | --- |
|  [EN]  | patch | `1.0.26` → `1.0.27` |
|  [EN]  | minor | `1.0.26` → `1.1.0` |
|  [EN] 、 [EN]  | major | `1.0.26` → `2.0.0` |

 [EN]  `VersionPrefix`  [EN]  `A.B.C`， [EN]  `VersionSuffix`  [EN] ； [EN]  `VersionSuffix`  [EN]  `alpha.N`、`beta.N`  [EN]  `rc.N`， [EN]  `N`  [EN] 。 [EN]  `VersionPrefix=1.0.27`、`VersionSuffix=rc.1`  [EN]  `1.0.27-rc.1`， [EN]  `VersionPrefix`。 [EN]  `VersionSuffix`。

GitHub Actions  [EN] ， [EN]  `vA.B.C`  [EN]  `vA.B.C-rc.N`  [EN] 。 [EN]  EXE  [EN] ； [EN]  `A.B.C.0`。 [EN]  `0..65534`， [EN]  .NET  [EN] ； [EN]  Microsoft Store  [EN] must [EN]  `0`，MSIX  [EN]  `A.B.C.0`。

## GitHub Actions  [EN]  EXE

###  [EN] 

1.  [EN]  GPL-3.0-or-later  [EN] 、 [EN] 。 [EN] ， [EN]  Release  [EN] ， [EN]  EXE/MSIX  [EN] ； [EN]  GitHub  [EN] 。 [EN]  .NET  [EN]  [ [EN] ](../THIRD-PARTY-NOTICES.txt)。 [EN] 、 [EN] ， [EN] “About” [EN] ； [EN]  [LICENSE-NOTICE.md](../LICENSE-NOTICE.md)。
2. 在功能分支修改 `Directory.Build.props` 的 `VersionPrefix`（预发布同时设置 `VersionSuffix`），并把本次内容从 `CHANGELOG.md` 的 `Unreleased` 整理到对应版本段。保留 `## Unreleased`， [EN] 。
3. 版本段标题must使用 `## [1.0.27] - YYYY-MM-DD`  [EN]  `## [1.0.27-rc.1] - YYYY-MM-DD`  [EN] ， [EN] ， [EN] cannot be empty. [EN] 。
4.  [EN]  PR， [EN]  `build`  [EN]  `main`。 [EN]  push  [EN] must [EN] ， [EN] must [EN] ， [EN] 。
5. GitHub Actions completed [EN] 、 [EN]  Release  [EN] ； [EN] 。

 [EN]  `Directory.Build.props`  [EN] ：

```xml
<VersionPrefix>1.0.27</VersionPrefix>
<VersionSuffix></VersionSuffix>
```

同时在 `CHANGELOG.md` 中新增非空的 `## [1.0.27] - YYYY-MM-DD`  [EN] ， [EN]  `main`  [EN]  `v1.0.27`  [EN] 。 [EN]  `VersionSuffix`  [EN]  `rc.1`， [EN]  `1.0.27-rc.1`。

###  [EN] 

`.github/workflows/release.yml`  [EN]  `main`  [EN]  `Directory.Build.props`  [EN]  `CHANGELOG.md`  [EN] ， [EN]  push ** [EN] ， [EN] ** [EN] 。 [EN]  push  [EN] ； [EN]  `Unreleased`  [EN]  Release。

 [EN] ， [EN] 、 [EN]  Changelog  [EN] ， [EN]  `origin/main`， [EN]  `build.yml`  [EN] 。 [EN]  EXE、 [EN] ， [EN] 。

GitHub Actions  [EN]  .NET  [EN]  Windows x64  [EN]  EXE， [EN]  .NET。 [EN]  EXE  [EN] directory [EN] ， [EN] 、 [EN] sectors RAW/WAV  [EN]  GUI  [EN] ， [EN] ， [EN]  SHA-256。GitHub Release  [EN]  EXE， [EN] ：

```text
DiscImageStudio-v1.0.27-win-x64.exe
```

SHA-256  [EN]  Release  [EN] ， [EN] 。 [EN]  `GITHUB_TOKEN`  [EN]  **GitHub Release  [EN] **， [EN] （PAT）。 [EN]  prerelease  [EN] ； [EN] 。 [EN] ， [EN]  Microsoft Store  [EN] 。

维护者在 GitHub 的 [Releases 页面](https://github.com/JiaFeiMiao-K-Cat/DiscImageStudio/releases)  [EN] 、 [EN] 、EXE  [EN] ， [EN] ， [EN] 。 [EN]  SHA-256， [EN]  Release  [EN] ：

```powershell
Get-FileHash .\DiscImageStudio-v1.0.27-win-x64.exe -Algorithm SHA256
```

### failed [EN] 

 [EN] failed [EN]  Actions  [EN] ， [EN]  GitHub Actions  [EN]  `main`  [EN]  `release`  [EN] 。 [EN] ， [EN]  `main`  [EN] ， [EN] 。

 [EN] ， [EN] must [EN] ， [EN]  Release must [EN] 。 [EN]  Release、 [EN] ； [EN] ， [EN]  `main`  [EN] ， [EN] ， [EN]  `rc.1` → `rc.2`。 [EN]  `main`  [EN] ， [EN] failed [EN] ， [EN] 。 [EN] ， [EN] 。

 [EN]  GitHub  [EN]  `main`  [EN] ， [EN]  Pull Request  [EN]  `build`  [EN] ； [EN]  `v*`  [EN] ， [EN] 、Delete。 [EN] ， [EN] 。

##  [EN]  EXE  [EN] 

 [EN] directory [EN]  GitHub Actions  [EN] ：

```powershell
powershell -ExecutionPolicy Bypass -File packaging/Build-Release.ps1
```

 [EN]  `Directory.Build.props`  [EN] 。 [EN]  `1.0.26`  [EN] ， [EN] directory [EN]  `artifacts/release/v1.0.26/`。 [EN]  `win-x64` EXE， [EN]  `DiscImageStudio-v1.0.26-win-x64.exe`  [EN]  `SHA256SUMS.txt`； [EN]  Release  [EN] ， [EN]  Release  [EN] 。 [EN]  Changelog  [EN] ， [EN]  GitHub Release； [EN] must [EN] 。

## Microsoft Store MSIX

MSIX  [EN] 。 [EN]  Partner Center  [EN] ， [EN]  Product identity  [EN] Copy：

- Package/Identity/Name
- Package/Identity/Publisher
- Package/Properties/PublisherDisplayName

 [EN] ：

```powershell
powershell -ExecutionPolicy Bypass -File packaging/Build-MSIX.ps1 `
  -IdentityName "Partner Center Identity Name" `
  -Publisher "CN=Partner Center Publisher" `
  -PublisherDisplayName "Publisher display name" `
  -DisplayName "Reserved product name"
```

 [EN]  `-Version`  [EN] ， [EN]  `Directory.Build.props`  [EN]  `A.B.C.0`。 [EN] ， [EN]  `-Version "1.0.26.0"`； [EN]  EXE  [EN] ， [EN] 。Microsoft Store  [EN]  `-rc.1`  [EN] ； [EN]  Store  [EN] 。

 [EN]  GitHub Actions  [EN]  `package-msix`  [EN] ，`version`  [EN] 。 [EN]  `build.yml`  [EN]  CI， [EN]  MSIX  [EN]  Actions  [EN] ； [EN]  GitHub Release。 [EN]  Store MSIX  [EN] ； [EN] ， [EN]  Publisher  [EN] 。

##  [EN] 

 [EN]  Publisher  [EN] ， [EN] ：

```text
artifacts/certificates/DiscImageStudio-Test.cer
```

 [EN]  `Build-MSIX.ps1 -CertificateThumbprint <thumbprint>`（ [EN] ） [EN] 。 [EN]  `packaging/Install-TestPackage.cmd`， [EN] ：

```powershell
powershell -ExecutionPolicy Bypass -File packaging/Install-TestPackage.ps1
```

 [EN] ， [EN] Import“ [EN] / [EN] ”， [EN]  MSIX。 [EN]  PFX  [EN]  GitHub， [EN]  Release  [EN] 。

## Windows 11  [EN] （ [EN] ）

 [EN] must [EN]  OID  [EN] ，cannot [EN] 。 [EN] ：

```powershell
powershell -ExecutionPolicy Bypass -File packaging/Build-MSIX.ps1 `
  -IdentityName "12345.DiscImageStudioArchitectureTest" `
  -Publisher "CN=Disc Image Studio Test" `
  -PublisherDisplayName "Disc Image Studio Test" `
  -DisplayName "Disc Image Studio Test" `
  -Version "1.0.26.0" `
  -UnsignedDevelopmentPackage
```

 [EN]  PowerShell  [EN] ：

```powershell
Add-AppxPackage -Path ".\artifacts\msix\DiscImageStudio_1.0.26.0_x64_unsigned-dev.msix" -AllowUnsigned
```

`-UnsignedDevelopmentPackage`  [EN]  Windows 11  [EN] ； [EN]  Windows  [EN]  `-AllowUnsigned`  [EN] ， [EN] 。 [EN]  Microsoft Store  [EN] ， [EN]  Partner Center  [EN] 。

 [EN] ：

-  [EN] ，cannot [EN]  Identity  [EN] 。
-  [EN]  Windows  [EN] 、 [EN] 。
-  [EN]  Windows App Certification Kit。
-  [EN]  1366×768  [EN] 。
-  [EN]  `PRIVACY.md`  [EN]  HTTPS  [EN] 。
-  [EN] 、 [EN] 、 [EN] ， [EN]  Windows IMAPI2  [EN]  CD/DVD  [EN] Burn [EN] ； [EN] 、 [EN] Disc Media [EN] 。
