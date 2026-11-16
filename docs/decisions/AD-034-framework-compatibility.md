# AD-034 — Framework compatibility

**Status:** Approved in the consolidated final architecture review  
**Approval class:** Formal owner approval of the proposed architecture/POC package; **not** a separately preserved verbatim numbered Option vote.  
**Implementation state:** No framework-compatibility POC results have been executed.  
**Title and number:** Charter labels this AD-34; this file uses the canonical padded ID AD-034.

## Context and problem

A provider-neutral .NET library must serve legacy .NET Framework 4.8 applications and current modern .NET consumers without pretending that assembly target frameworks guarantee provider, native dependency, OS, authentication or security support.

## Alternatives considered

The [original charter](../archive/charters/architecture-and-poc-execution-charter.md) presented a concrete framework-support recommendation. A complete standalone historical A/B/C alternative comparison is **not recovered**; no competing choices are invented.

## Selected approach

- **Officially support** .NET Framework 4.8 on Windows and .NET 10 LTS on Windows and Linux **for capabilities that have been independently qualified**.
- **Qualify .NET 11** via compatibility smoke evidence; do not automatically promote it to official support.
- Treat .NET 8 as potential **best-effort binary compatibility**, not a new official support commitment; **do not support .NET 6**.
- Treat macOS as a future provider/OS-specific candidate, not an unverified support promise.
- Use `netstandard2.0` as the portable common core baseline; add `net10.0` assets to libraries/adapters only for justified API/runtime benefits. Avoid extra `net48`/`net11.0` library assets merely for symmetric TFMs.

## Rationale

The portable core and explicit provider adapters preserve one public contract while allowing modern platform-specific implementations where justified. A declaration of a target framework is insufficient evidence of actual installation, runtime loading, security behavior or provider operation.

## Consequences and compatibility limits

- Public authorization, capability, error and lease-disposal semantics must remain equivalent across packaged assets; newer frameworks may not silently relax security.
- Verify an **actual old-style .NET Framework 4.8 application**, including NuGet dependencies, C# 7.3 calling code, runtime loading, binding redirects and supported authentication where in scope.
- Verify real .NET 10 consumers on Windows/Linux and run separate .NET 11 smoke/compatibility checks.
- Independently record restore, compile, load, connect/operate and disposal; validate package/API asset parity and dependency/SBOM.
- A provider may have narrower compatibility than the library abstractions. Unverified OS/driver/native/TLS/security capability remains explicitly unsupported or unknown.
- Baseline lease contract is `IDisposable`; asynchronous disposal needs separate proven portable packaging before becoming required.

## Approval evidence

The [final architecture-review extraction](../archive/conversations/final-architecture-review.md#L13-L20) records a formal proposal of AD-034 and Jim's subsequent **“I approve”** for the decision/POC charter package. This is **later explicit package approval**, not an invented separate original numbered quotation. The preserved [charter section 3](../archive/charters/architecture-and-poc-execution-charter.md) retains the proposal's original wording, while its approved disposition is documented here.

## Related requirements and acceptance scenarios

- [Approved POC-SCN-04](../requirements/POC-001.md): real .NET Framework 4.8/Windows, .NET 10 Windows/Linux consumer compatibility and .NET 11 smoke.
- [Approved POC-SCN-21](../requirements/POC-001.md): exact runtime, provider, OS and dependency evidence.
- `REQ-18` and `D-18` are **later consolidated-charter aliases**, not original historical requirement IDs.
- Extended provider/OS/framework matrix work remains deferred. These are test plans, **not passing results**.

## Related decisions and supersession

Refines AD-001 (desktop/server consumer support), AD-019 (OS security capabilities), AD-031 (dependency isolation) and AD-033 (capability matrices); does not supersede their policy. Any later support expansion or reduction needs separate evidenced approval.

## Evidence sources

- [Original AD-34 framework policy proposal](../archive/charters/architecture-and-poc-execution-charter.md)
- [Final owner approval evidence](../archive/conversations/final-architecture-review.md)
- [Approved POC engineering kickoff compatibility matrix](../archive/charters/poc-001-engineering-kickoff-charter.md)
- [Decision register](README.md)
