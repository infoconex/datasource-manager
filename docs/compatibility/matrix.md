# Compatibility evidence matrix

This document distinguishes a **foundation package-load smoke** from the provider/OS qualification mandated by [AD-034](../decisions/AD-034-framework-compatibility.md) and [POC-SCN-04/21](../requirements/POC-001.md).

| Host/runtime | Foundation verification | POC/provider support |
| --- | --- | --- |
| Windows x64, .NET Framework 4.8 | Non-SDK C# 7.3 consumer must restore/build/execute local `netstandard2.0` packages | Not yet qualified; no real provider/authorization |
| Windows x64, .NET 10 | Restore/build/run local modern consumer and NUnit | Not yet qualified; no real provider/authorization |
| Linux x64, .NET 10 | Restore/build/run local modern consumer and NUnit | Not yet qualified; no real provider/authorization |
| Windows/Linux, .NET 11 | Deferred compatibility smoke | Not automatically officially supported |
| .NET 8 | Possible best-effort binary compatibility, no required foundation smoke | No official support commitment |
| .NET 6 | Not tested | Unsupported |
| macOS | Not tested | Future provider/OS-specific qualification |

Every future qualification cell must record SDK and runtime patches, OS/architecture, provider and native dependencies, TLS/authentication setup, restore/compile/load/operate/dispose separately. A pass for one provider must not be generalized to another; security guarantees fail closed if capabilities cannot be established.

