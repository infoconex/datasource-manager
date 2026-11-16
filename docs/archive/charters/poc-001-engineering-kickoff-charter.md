# Data Source Manager: POC-001 Engineering Kickoff Charter

**Status:** Recommended for owner approval; planning only  
**Prepared:** November 15, 2026 (Pacific time)  
**POC:** POC-001, Secure Provider Acquisition and Recovery  
**Authoritative baseline:** [Data Source Manager - Consolidated Architecture and POC Execution Charter](https://chatgpt.com/library?file_id=libfile_6ee44f7d106c8191b9bcd4bf2c8f1e6f&account_id=personal)  
**Authority:** AD-001 through AD-035 and all 21 POC-SCN criteria are approved by Jim after the source charter's original proposed-status header was written. This kickoff does not amend them.  
**Boundary:** No repository operations, implementation, experiments, infrastructure provisioning, PR, merge, release, or publication authorized by this charter.

## 1. Decision and evidence ledger

| Class | Determination |
| --- | --- |
| **Previously approved** | SOLID and explicit ports, dependency-free core, independent registered adapters, versioned capabilities, managed typed leases, provider-native pooling, strict authorization, authenticated revisions, bounded acquisition retry, no replay of uncertain work, failure-domain breakers, safe telemetry, AD-34 framework matrix, AD-35 optional pool coordination only after comparative evidence. |
| **Previously approved POC** | Workstreams A/B/C, POC-SCN-01 through 21 exactly as reproduced in section 8, three selected providers, SQL Server restart proof, defined safety/stopping criteria, deferred work. |
| **Documentation-backed** | .NET 10 LTS and .NET 11 STS are currently supported; .NET 8 exited support on Nov. 10, 2026. SqlClient has native pooling and targeted `ClearPool`, but may fail initially after restart. SQLite pooling is native and Sqlite asynchronous ADO.NET calls execute synchronously. SSH.NET 2026.0.x supports net462, netstandard2.0 and modern .NET. See section 13. |
| **New recommendations** | One repository with independently packed adapter projects; first vertical increment confined to core contracts and consumer compilation; candidate package versions in section 4; reproducible, isolated real-provider test topology; issue/PR per increment; scenario ownership mapping in section 9. |
| **Unverified until actual runs** | Consumer assembly binding and TFM resolution, Linux device-context protection, native cryptography delivery, trust-anchor portability, cancellation timing, SQL recovery sequence/latency/physical-login counts, provider-specific transitive dependencies, and strict compatibility of built packages. |

**Historical provenance qualification:** The source charter notes that the full original wording of AD-001 to AD-033, the original EXP-001 numbering, and an original numbered requirement register were unavailable at consolidation. The `REQ-01` through `REQ-20` names in the source are *new traceability aliases*, not reconstructed historical requirement IDs. Preserve any subsequently recovered original record without silently rewriting this approved POC.

## 2. Scope, readiness, and owner gates

**Workstream A - Contracts and compatibility:** portable common acquisition and admission; trusted adapter registration; versioned capability states; managed typed leases; actual consumer/API/package qualification.

**Workstream B - Configuration and security:** authenticated strictly advancing revisions; transactional activation and last-known-good; local/managed policy separation; tenant boundaries; protected credentials; time- and trust-bounded offline grant; fail-closed results; separate audit.

**Workstream C - Real providers and recovery:** actual SQLite and SFTP resources; narrow SQL Server test adapter/harness; disposal and contention; bounded acquisition retries; failure-domain separation; safe instrumentation; native recovery and isolated `ClearPool` comparison.

**Explicitly deferred:** production management service, all other adapters (PostgreSQL, MySQL, FTP/FTPS, SMTP, SMB/UNC), enterprise vault, production emergency access and credential rotation, generalized operations and query model, topology-aware failover, full pool-coordination implementation, full audit-delivery system, all distributed/fleet concerns. Do not treat deferral as rejection.

**Remaining prerequisites before implementation:**

1. Identify technical implementation owner and independent security reviewer; Jim remains product/architecture approval authority unless delegated.
2. Archive approved charter and any original AD/EXP records immutably; publish one versioned traceability index in the future repository after permission is granted. Record explicit source/approval provenance.
3. Have the security reviewer sign the POC threat model (trust tiers, root/admin compromise out of guarantee, clock source/reboot, network/server trust, filesystem rollback, key handling, audit ordering).
4. Select supported, patched Windows x64 and Linux x64 images; select actual .NET SDK/runtime patch versions and lock all packages/transitives/images by version and checksum/digest.
5. Approve a disposable, private SQL Server Developer test instance and SFTP host, dedicated test credentials, test certificates, restart control, monitored costs, and cleanup rules.
6. Ensure a representative non-SDK `net48` consumer can build and execute on Windows, including NuGet resolution, redirects and C# 7.3 code. No reliance on compile-only claims.

These are execution-entry checks, not unanswered product-design questions. If any proves impossible, return to Jim before weakening security or portability semantics.

## 3. Repository and project recommendation

Recommend a **new dedicated `datasource-manager` repository only after explicit authorization**. Keep provider packages physically independent in the same solution to allow one cohesive POC without a mono-package runtime dependency. Do not add every future provider as an empty project.

```text
DataSourceManager.slnx
Directory.Build.props
Directory.Packages.props
global.json
nuget.config
src/
  DataSourceManager.Abstractions/       # public DTOs, ports, errors, leases; netstandard2.0
  DataSourceManager.Core/               # pure admission/policy state; netstandard2.0
  DataSourceManager.Configuration/      # authenticated snapshot and cache adapter
  DataSourceManager.Security/           # platform credential/grant/audit adapters
  DataSourceManager.Diagnostics/        # optional .NET-native measurements, no exporter
  DataSourceManager.Adapters.Sqlite/    # Microsoft.Data.Sqlite only here
  DataSourceManager.Adapters.Sftp/      # SSH.NET only here
  DataSourceManager.Adapters.SqlServer/ # narrowly scoped SQL POC test adapter
tests/
  DataSourceManager.Core.Tests/
  DataSourceManager.Configuration.Tests/
  DataSourceManager.Security.Tests/
  DataSourceManager.Adapters.Sqlite.Tests/
  DataSourceManager.Adapters.Sftp.Tests/
  DataSourceManager.Adapters.SqlServer.Tests/
  DataSourceManager.Acceptance.Tests/
  Consumers/Net48LegacyConsumer/       # actual non-SDK .NET Framework 4.8 project
  Consumers/Net10Consumer/             # used on Windows and Linux
  Consumers/Net11SmokeConsumer/        # compatibility qualification only
  Fixtures/                             # signed synthetic, tampered and denial fixtures
docs/
  decisions/
  requirements/
  capabilities/
  security/
  compatibility/
  evidence/
eng/                                    # verification and future infra scripts
```

The tree is a **responsibility map**, not a requirement to create every project on day one. Start with Abstractions, Core, Core.Tests, and the three consumer harnesses. Add a package/project when an accepted scenario first requires it. No empty interface projects, general DI container, service host, embedded server, custom pool, or resilience framework.

Keep one source file per cohesive domain type or behavior, tests by scenario, `nullable` and analyzer settings where supported, deterministic builds, package lock files, a single pinned SDK and centrally maintained package versions. Use test-driven changes and Microsoft conventions. CI executes the same scripts engineers run locally. Each future increment gets one traceable issue and one branch/PR; no unapproved merges.

### Dependency direction

`Consumers -> public Abstractions + composition -> Core -> Abstractions` is conceptual; Core must depend **only on Abstractions/BCL** and never on any provider, platform-security implementation, test package or diagnostics exporter. Outbound implementations depend inward on ports. Adapter-specific types must not leak into portable core packages. Optional adapters are deliberately referenced by the application's explicit composition code, not loaded by scanning.

### Target frameworks

- Abstractions and pure Core: **netstandard2.0** only initially. This minimizes asset drift and supports .NET Framework 4.8.
- Adapter/infrastructure projects: **netstandard2.0;net10.0** only where a real API/dependency advantage exists; otherwise netstandard2.0 alone. Pack and test the chosen actual assets. Do not add net48/net11 assemblies for symmetry.
- Consumer apps/tests: **net48**, **net10.0**, and separate **net11.0 smoke** as in section 5.
- Public semantics must be the same regardless of which asset NuGet chooses. Enable compatible-framework and baseline API/package validation once multi-target assets exist. Support and runtime execution are not inferred from TFM declarations.

## 4. API boundaries and dependency selection

### Initial public boundary (provisional names, stable semantics)

| Boundary | Responsibility and minimum contract | Exclusion |
| --- | --- | --- |
| `IDataSourceManager` inbound port | Acquire one approved typed capability from an explicit profile, caller/tenant context, deadline, and cancellation token; return managed lease **or typed failure**. | Query execution, connection string construction by caller, generic file/message operations. |
| `IDataSourceCapabilityCatalog` inbound port | Discover semantic capability ID/version, support, live availability and authorization as separately reportable values, without opening a remote connection. | Assumption that availability implies authorization. |
| `IManagedLease<TResource> : IDisposable` | Expose an approved provider-appropriate resource within the lease, track ownership, synchronous idempotent dispose, and truthful lifetime state. | Implying disposal cancels a remote transaction or transfer already underway. |
| `IProviderAdapter` outbound port | Explicitly registered factory/descriptor; capability query; provider-specific acquisition and cleanup. | Runtime plugin search, arbitrary assembly loading, secretly shared global adapter instance. |
| `IConfigurationSnapshotStore`, `IConfigurationVerifier` | Authenticated revision validation and atomic activation with last-known-good, scoped ownership. | Full remote configuration service and push protocol. |
| `IAuthorizationPolicy`, `ITrustedTimeSource`, `IProtectedCredentialStore` | Guard new admissions, strict offline expiry, known protection context and safe credential supply. | Claims that a hostile offline OS cannot forge time or extract keys. |
| `ISecurityAuditSink` | Independent security event acceptance for audit-required actions and explicit persistence failure. | Replacing audit with traces or claiming future delivery/deduplication is implemented. |

Names are engineering suggestions, **not new architectural decisions**. API shape decisions before first implementation: use `Task` and `CancellationToken` supported across targets; single typed redacted outcome taxonomy; `IDisposable` as guaranteed lease baseline; no `IAsyncDisposable` obligation; no provider DTO in core. Native SQLite/SQL may bind to a database-specific `DbConnection` lease in an optional adapter contract; SFTP uses a distinct, deliberately narrow `ISftpSession` resource. Do not claim a universal `DbConnection` interface for file transports. Keep public semantic capabilities versioned and reject unrecognized required versions.

Typed failures include at least `UnsupportedProvider`, `UnsupportedCapability`, `TemporarilyUnavailable`, `Unauthorized`, `InvalidConfiguration`, `UntrustedEndpoint`, `CredentialUnavailable`, `AuthorizationExpired`, `AdmissionDeadlineExceeded`, `TransientEndpointFailure`, and `IndeterminateOperation`. Operational cancellation is not a claim of remote cancellation. Return safe identifiers; redact secrets, raw hostnames where policy disallows them, connection strings, raw tenant information, private keys, and stack internals from ordinary errors/diagnostics. Ensure allocation and disposal concurrency are bounded by design, not just benchmarked later.

### Provider dependency candidates (as of kickoff)

| Provider | Recommended version candidate | Why | Before pin is final |
| --- | --- | --- | --- |
| SQLite | `Microsoft.Data.Sqlite` **10.0.15** | Microsoft-maintained, MIT, netstandard2.0 package; aligns with supported .NET 10 instead of unnecessarily selecting 11.0.0. Native pooling; package depends on SQLitePCLRaw and native SQLite. | Validate exact resolved native SQLite binaries/RIDs/architecture, notices, vulnerabilities and net48 runtime resolution. Do not confuse `Password=` with real database encryption. |
| SFTP | `SSH.NET` **2026.0.1** | Maintained upstream, MIT, net462/netstandard2.0/modern assets; Nov. 14 hardening patch; older 2025.x contains a published pre-auth memory DoS. | Verify transitive crypto packages, host-key event behavior and SFTP resource cleanup on real net48/net10; no TOFU default; test pinned key and mismatch. |
| SQL Server | `Microsoft.Data.SqlClient` **7.1.2** | Official Microsoft client, MIT, net462/netstandard2.0/modern assets, Nov. 2026 current GA servicing; native pooling and `ClearPool`. | Verify complex transitive graph, native SNI on Windows, managed SNI on Linux, assembly redirects, TLS defaults, client/server compatibility and pool switch behavior on every mandatory host. |

These are **candidate exact direct versions**, not a claim that dependency restoration or security scanning has been performed. The POC lockfile/SBOM must preserve resolved transitive versions; review package signatures/maintainer/release provenance and direct/native notices. Use GA packages only, no floating versions or pre-release source feeds. Keep SQL Entra extension, EF Core, Polly, SSH.NET pre-release feeds, third-party DI/exporters and Testcontainers **out of the first POC** unless a demonstrated gap demands them. Microsoft SQL container Developer edition is for nonproduction test/development and requires accepted licensing terms.

For instrumentation, use `System.Diagnostics.Metrics.Meter` and `ActivitySource` with BCL/package support verified on net48. Keep instrumentation implementation in an outer project; do not add OpenTelemetry SDK/exporters to Core. Default labels are static small enums or approved bounded pseudonymous config IDs; no endpoint, tenant or credential values.

## 5. Mandatory real consumer and OS matrix

| Host | A: core contracts/package | B: configuration/security | C: SQLite/SFTP | SQL restart and reacquire | Status policy |
| --- | --- | --- | --- | --- | --- |
| Windows x64, **.NET Framework 4.8**, old-style app/C# 7.3 | **Gate** build, restore, load and API | **Gate** including Windows protected data and offline restart | **Gate**, including native packaging and host-key tests | **Gate**, full native/recovery and scoped comparison | Official support candidate; must pass |
| Windows x64, **.NET 10 LTS** | **Gate** | **Gate** | **Gate** | **Gate**, same SQL fixture/protocol | Official support candidate; must pass |
| Linux x64, **.NET 10 LTS** | **Gate** | **Gate** under separately stated trusted-key/test-context assumptions; fail closed if unavailable | **Gate**, including native SQLite | Run real SQL acquisition/recovery when auth/TLS fixture permits; record cell separately | Official support for qualified capabilities; do not overclaim Windows-only protection |
| Windows x64, **.NET 11** | Smoke: load/public API/dispose | Smoke of supported safe outcomes | Smoke where feasible | Optional smoke, not a second mandatory restart campaign | Compatibility qualification, no official support promise |
| Linux x64, **.NET 11** | Smoke | Smoke only where trusted context exists | Smoke where feasible | Optional smoke | Compatibility qualification |
| .NET 8 | Non-gating best-effort smoke if inexpensive | No security support promise | No support commitment | Not required | Support ended Nov. 10, 2026 |
| .NET 6 / macOS / arm64 | Out of POC mandatory matrix | Not qualified | Not qualified | Not qualified | No implied support |

Use supported patch versions and report OS build/distribution, architecture, runtime/SDK, actual assembly asset, package lock hash, native components, SQL server build, TLS/cipher/certificate mode, auth mechanism and test date. Compilation, NuGet restore, runtime load, physical connection, lease dispose and security-outcome equivalence are **distinct checks**. Unsupported or unexecuted cells must be visibly marked as such. A single Windows service version or SQL container test cannot imply all Windows/SQL Server versions are supported.

## 6. Disposable integration topology and threat model

**Design (no infrastructure authorized to create yet):**

1. One private, disposable **Linux x64 SQL Server 2025 Developer Edition container or VM** with a pinned image digest and persisted test DB across *service restarts*. It must be reachable privately by both Windows and Linux client harness hosts. Use an isolated test account with least database privileges; keep a different administrative account in the independent test supervisor. No production datasets, endpoints, or shared SQL servers. Verify EULA, resource needs, supported Linux x64 CPU, and TLS configuration.
2. One disposable **OpenSSH SFTP server** in the same isolated test network. Pre-generate and independently distribute a pinned host public key/fingerprint to the verifier fixture. A second key or controlled rotation simulates hostile/mismatched identity. Use synthetic files and a restricted test-only principal. Pin server/container version and image digest if containerized.
3. One **SQLite file database** per run created under a disposable per-test directory, not an in-memory shortcut for scenarios involving real file use, native libraries or pooling. Configure real file permissions. Clean up DB, WAL/SHM, pooled handles and temporary files only after all leases close.
4. **Windows x64 legacy consumer**, **Windows x64 .NET 10 consumer**, and **Linux x64 .NET 10 consumer** in the private test network. Run net11 smoke on available approved Windows/Linux hosts. GitHub-hosted Windows/Linux machines do not by themselves provide a private cross-OS server network; use ephemeral self-hosted runners or an approved isolated network arrangement. Do not expose server ports to the public internet to accommodate CI.
5. Separate **test controller** manages server stop/start, independent readiness detection (`SELECT 1` from a distinct process/client), retry window and evidence capture. It must not share the application's connection pool or cause application restarts. Side-channel server-ready signal is timestamped separately from first successful client acquisition.
6. **Security fixture signer** is distinct from test-client verification keys; caches, grant revisions, clock anchor and credentials are synthetic. On Windows prefer OS Data Protection scope tied to correct user/security context. For Linux POC, an out-of-cache protected test key/host security service can demonstrate copied-cache refusal, but it must be labelled a bounded, non-root adversary test, *not* TPM-grade binding or protection from a compromised host. Reject acquisition when keys or trusted time are absent.

**Scope boundaries:** pinned test CA and valid server name, mandatory encryption and real certificate verification (`TrustServerCertificate=False`); no disabled host verification, unrestricted SASL/password workarounds, production credentials, internet-visible test services, or permanent secrets. Prefer standard OpenSSH and the Microsoft SQL Developer image; no provider mocks in acceptance evidence for 11/12/18/20. Deterministic mocks/fakes are appropriate for pure policy unit tests and failure injection, not substitutes for real-provider checks.

**Threat-model signoff must explicitly address:** malicious configuration/signature/rollback, compromised lower-trust override, cross-tenant identity forgery, copied offline cache, wrong user/machine secret, host-key MITM, offline clock rollback and filesystem snapshot, audit sink denial, credential revocation while disconnected, failed server restart, pooled connection identity collision, ambiguous SQL commit, and telemetry leakage. Guaranteed behavior is **fail closed for detectable/unverifiable states under stated trust assumptions**, not perfect security on a hostile offline administrator-controlled device. Distinguish authorization *grant* validity from configuration *snapshot* validity.

## 7. Automated verification and SQL fault protocol

### Test pyramid and controls

- **Pure unit tests** for capability state, provider registration, positive/negative policy decisions, bounded deadline/admission accounting, failure classification, breaker domain keys, redacted error mapping, idempotent disposal, and no replay. Deterministic virtual/injected clock and fault ports.
- **Configuration/security contract tests** for signature, stale/rolled-back revision, interrupted file activation, tenant override, key context, grant expiry after reboot and negative audit persistence. Verify no partial state or unauthorized access. For atomic replace, test actual platform filesystem and crash points; do not assume identical semantics of Windows and POSIX APIs.
- **Actual provider tests** for SQLite file/lock/native pooling, SFTP pinned/mismatched host key and disposal, SQL connection opens and restarts. Run initial behavior and repeat fault cases enough to report variance; at least five controlled restart trials per mandatory Windows runtime cell is an initial recommended observation target, not a latency SLA or an accepted architectural requirement.
- **Public contract tests** from actual old-style net48 consumer and net10 consumer, package/api validation, dependency graph and absence of provider references in core. Verify `System.Diagnostics.DiagnosticSource` instrumentation on real net48 as well as modern .NET.
- **CI gates**: formatting/analyzers, build, unit tests, public API/package comparison, scenario coverage/traceability completeness, offline dependency audit and license/SBOM, secret scanning, .NET 10 Linux and Windows tests, real net48 Windows tests, security-negative tests, then isolated real-provider job. Reserve restart/fault workloads for explicit controlled integration CI, not arbitrary unit-test parallelism. CI must not pass if mandatory evidence is absent.

### SQL restart protocol (POC-SCN-18, 19, 20)

1. Fix same client binary/runtime, SQL server build, canonical connection string, TLS/auth identity, `Min Pool Size`, `Max Pool Size`, native `ConnectRetryCount`, `Pool Blocking Period`, and supported pooling feature switches. Record selected 7.1.x `Connection Idle Timeout` and V1/V2 behavior only if present; begin with documented defaults and then a narrow controlled variation if needed. Do **not** enable any SQL command-level retry provider.
2. Open and test several SQL connections, then dispose/return them to **one known native pool identity**. Confirm pooling with supported diagnostics as available; do not claim knowledge of undocumented exact pool internals.
3. Restart the SQL service using the independent controller while keeping the **same client process** alive. Observe first attempted reuse, failure type, native reconnect and pool blocking, without hiding an initial failure.
4. Independently establish SQL-ready timestamp. Use a sequence of **new, separately caller-authorized acquisition requests**, each with bounded admission deadline and at most one manager-level repeat on transient acquisition error. Do not keep one request alive for the full outage. Record time from server-ready to first successful new harmless `SELECT`.
5. Inject a separate interrupted command/commit with an operation marker. At uncertainty, return `IndeterminateOperation`, prove no manager/driver command replay, and reconcile outcome later with explicit test-controller read. Do not infer failed commit simply from a dropped connection.
6. Reset the fixture, perform a native-only baseline, then independently repeat using **scoped `SqlConnection.ClearPool` in the test harness** after an observed matching-pool failure. Never call `ClearAllPools` and never install the future coordinator. Confirm same pool key and absence of unrelated tenant collateral effects; if real isolation cannot be shown, report that limit rather than creating a logical-tenant purge API.
7. Compare successful first-recovery fraction, total failures, server-ready-to-success distribution, native login churn, pool blocking intervals, active lease counts, retry counts (driver vs manager), and possible collateral impacts. Document unavailable server counters as unmeasured. No invented fixed recovery SLA; **eventual in-process recovery on both Windows net48 and net10 is mandatory**.

One manager retry means at most **two manager acquisition invocations total** per caller acquisition. Exclude authentication, policy, TLS, host-key trust, signature, revoked/expired grant, and unknown work outcomes from retry. Respect cancellation at manager-owned boundaries while admitting that provider-native calls may continue. Circuit breakers are local and partitioned by verified endpoint vs tenant/profile/security context; no global breaker on one tenant's denied authentication.

## 8. Exact approved acceptance scenarios (preserved)

The following acceptance text is reproduced from the approved charter. The original abbreviated IDs `02` through `21` mean `POC-SCN-02` through `POC-SCN-21`. All negative cases require typed, redacted, auditable outcomes. No wording below is a newly invented requirement.

| ID | Approved acceptance criterion | Workstream |
| --- | --- | --- |
| **POC-SCN-01** | With zero adapters registered, core loads without provider packages and an acquisition request returns explicit `UnsupportedProvider`; no dynamic/ambient provider loading occurs. A dependency graph and test prove this. | A |
| **POC-SCN-02** | Register only trusted SQLite/SFTP/SQL test adapters; duplicate, unknown, or untrusted registration is rejected. Independent provider package references are recorded. | A |
| **POC-SCN-03** | Query versioned provider capabilities without opening a connection and distinguish `Unsupported`, `TemporarilyUnavailable`, and `Unauthorized`; security-critical missing capabilities fail closed. | A |
| **POC-SCN-04** | Same consumer-visible contract succeeds on real .NET Framework 4.8/Windows and .NET 10/Windows/Linux hosts, with .NET 11 compatibility smoke. Package and API validation show no contract drift; compile/load/operate/dispose and dependency resolution are recorded separately. | A |
| **POC-SCN-05** | A valid authenticated, strictly newer configuration revision activates as one complete snapshot; invalid signature, malformed payload, prohibited override, stale version or interrupted write preserves the last valid snapshot without partial activation. Record old/new revision and crash point. | B |
| **POC-SCN-06** | After application restart and simulated central outage, locally configured profiles still work and centrally managed profiles work **only** while their separate authorization grants remain valid. Never interpret cached configuration as permanent authorization. | B |
| **POC-SCN-07** | Tenant/organization/profile ownership and security-sensitive configuration precedence are enforced; a cross-tenant or lower-trust override cannot affect any acquisition or secret. | B |
| **POC-SCN-08** | The test protected credential is not readable from copied cache on a different security context; loss of protection context produces an explicit fail-closed outcome; ordinary logs, exception text, metrics and traces contain no secrets/connection strings. | B |
| **POC-SCN-09** | Expired, invalid-signature, revoked, rollback-detected or unverifiable-time offline grant denies **new centrally managed acquisitions** with no implicit grace period. Reboot/restart tests document the exact trust/time assumptions, not an unsupported guarantee against a hostile host. | B |
| **POC-SCN-10** | Security event outcomes are delivered through a separate audit port, never substituted by ordinary diagnostic telemetry. For audit-required actions, injected audit-persistence failure denies the action rather than asserting successful auditing. Audit delivery/idempotency mechanisms remain later-scope. | B |
| **POC-SCN-11** | Using one acquisition model, a SQLite adapter returns a SQLite-appropriate typed resource and an SFTP adapter returns an SFTP-appropriate typed resource. Missing provider-specific operations explicitly report unavailable capabilities; neither is coerced into `DbConnection`. | A/C |
| **POC-SCN-12** | SFTP accepts the configured authentic host key and rejects a changed/untrusted host key **before trusted use**; credential and host-key errors are not treated as transient endpoint outages. Capture test-endpoint identity only in safe/redacted form. | C |
| **POC-SCN-13** | Every acquired SQLite/SFTP/SQL resource is tracked and disposed on normal, exception, cancellation and concurrent paths; final active managed lease count is zero after all scopes close; repeated dispose is safe. A cancellation result does not falsely assert remote SFTP/SQL work stopped. | C |
| **POC-SCN-14** | Admission has a bounded queue/concurrency limit; when full, excess calls fail within their caller-specified admission deadline without creating unbounded queued tasks. Provider calls past admission may exceed cooperative cancellation; expose that limitation. | C |
| **POC-SCN-15** | Inject one endpoint-down condition and one tenant/authentication failure. Failure-domain state prevents one bad tenant/security context from opening a global endpoint breaker or blocking independently healthy acquisitions; no retry on authentication/TLS/policy denial. | C |
| **POC-SCN-16** | Acquire-level retry only: maximum **one manager-level repeat** after initial transient acquisition failure, subject to a caller deadline and provider retry settings; no command, upload, SMTP operation, or transaction is silently replayed. Count physical/native attempts separately to detect multiplicative retries. | C |
| **POC-SCN-17** | Low-cardinality .NET meter/trace/events report admission, disposal, selected failure domains and recovery timing with safe configuration IDs; exporter/observer failures do not prevent normal eligible acquisition. Security audit remains separate. | C |
| **POC-SCN-18** | On .NET Framework 4.8/Windows and .NET 10/Windows, fill and return SQL connections to a native SqlClient pool, restart SQL Server without restarting client, reacquire, and eventually complete a new harmless read after the server is ready. Record stale-checkout failures, driver recovery, native pool invalidation, elapsed times and all errors. An initial acquisition failure is permissible; recovery without application restart is mandatory. | C |
| **POC-SCN-19** | Induce interruption at/near SQL command execution or transaction commit. Report an explicit **indeterminate operation outcome** when the result cannot be established. Assert no manager or configured driver **command-level** retry/replay occurs; only a new caller-authorized operation may execute. | C |
| **POC-SCN-20** | Against the same documented restart fixture compare (a) native pooling/recovery alone with (b) a test-harness **scoped `SqlConnection.ClearPool`** after observed failure. Record successful first recovery, failures, recovery latency, hard-connect churn and collateral pool impact. Do not build AD-35 coordinator; recommend implementation only if it demonstrably adds value and can be safely scoped. | C |
| **POC-SCN-21** | The run records exact library/provider versions, runtimes, Windows/Linux distributions, authentication/TLS modes, native binaries, pooling settings, CPU architecture, SQL version, test sequence, logs redacted, and pass/fail/limitations for each matrix cell. Any unsupported or untested cell is visibly marked, never silently declared supported. | A/B/C |

## 9. Requirements-to-architecture-to-increment traceability

`REQ-*` identifiers and deferred `D-*` obligations are the source charter's explicit aliases. The table assigns each scenario its **completion increment**, not the first increment in which a fixture may be introduced.

| Scenario | Completion increment | Requirement aliases | Architecture authority or theme | Evidence owner |
| --- | --- | --- | --- | --- |
| 01 | I1 | REQ-01 | Dependency-free core; trusted ports | Contracts/API |
| 02 | I4 | REQ-01 | Explicit trusted registration | Adapters + contracts |
| 03 | I2 | REQ-01, REQ-10 | Versioned capability and fail-closed policy | Contracts/API |
| 04 | I6 | REQ-18 | **AD-34** | Compatibility |
| 05 | I3 | REQ-03, REQ-05 | Authenticated revision/atomic activation | Configuration |
| 06 | I3 | REQ-03, REQ-08 | Offline last-known-good versus separate authorization | Configuration + security |
| 07 | I3 | REQ-05, REQ-20 | Ownership/override | Security |
| 08 | I3 | REQ-04, REQ-06, REQ-17 | Trust-aware protection/redaction | Security + diagnostics |
| 09 | I3 | REQ-04, REQ-07, REQ-08 | Strict expiry/rollback/known revocation | Security |
| 10 | I3 | REQ-09, REQ-20 | Independent security audit | Security |
| 11 | I4 | REQ-02, REQ-10, REQ-11 | **AD-28** typed leases | Adapters |
| 12 | I4 | REQ-06, REQ-20 | Host key trust/fail closed | SFTP |
| 13 | I5 | REQ-07, REQ-11, REQ-12, REQ-19 | **AD-28**, native disposal/lease accounting | All providers |
| 14 | I5 | REQ-11, REQ-14 | Bounded admission/deadlines | Core + provider |
| 15 | I5 | REQ-14, REQ-15, REQ-16, REQ-20 | **AD-27** failure domains | Resilience |
| 16 | I5 | REQ-14 | Bounded acquisition-only retry | Resilience |
| 17 | I5 | REQ-17 | **AD-26** privacy-first diagnostics | Diagnostics |
| 18 | I6 | REQ-02, REQ-12, REQ-14 | **AD-34** and native SQL recovery | SQL test |
| 19 | I6 | REQ-14, REQ-19, REQ-20 | No uncertain operation replay | SQL test |
| 20 | I6 | REQ-12, REQ-13 | **AD-35** measure-only | SQL test |
| 21 | I6 | REQ-17, REQ-18 | **AD-34**, compatibility/evidence | Verification |

The source charter's deferred obligations **D-01 through D-20 remain unchanged**, including D-02 for remaining provider families, D-08 for stronger trusted clocks/anti-rollback, D-09 for full emergency audit, D-13 for any future pool coordinator, and D-18 for the extended OS/auth/driver matrix. The original EXP-001 through EXP-004 scenarios also remain in their deferred roadmap; none is represented as executed by POC planning.

## 10. Implementation increments and dependencies

| Stage | Scope | Acceptance for stage completion | Dependency |
| --- | --- | --- | --- |
| **I0: execution preflight** | Record baseline, owner, security signoff, chosen direct/transitive versions, private infrastructure proposal, CI feasibility and signed test fixture identities. | Threat-model review signed; all prerequisite decisions and test host access scoped and approved; no unsafe default. | Separate implementation authorization first. |
| **I1: smallest initial increment** | `Abstractions`, pure `Core`, explicit zero-adapter behavior and minimal actual legacy/modern consumer compile/load/dispose harness. | **POC-SCN-01 passes**; no provider dependency in core; typed unsupported result; initial `net48` and `net10` consumer contract proof; test-first and independent review. POC-SCN-04 is *not* yet declared complete. | I0. |
| **I2: capability/admission skeleton** | Trusted registry and versioned capability state using controlled test adapter doubles; safe result model and basic lease. | POC-SCN-03 passes including unauthorized and unavailable distinctions; positive/negative registry tests exist; no untrusted reflection loading. POC-SCN-02 remains incomplete until real adapters. | I1. |
| **I3: configuration/security vertical slice** | Authenticated local/fixture revisions, atomic activation, last-known-good, owner boundaries, protected secret and strict offline grant, independent audit port. | **POC-SCN-05 through 10 pass** on applicable mandatory hosts and their real security contexts; negative evidence and redaction; any critical fail-closed defect stops work. | I2 + reviewed threat model. |
| **I4: SQLite/SFTP actual adapters** | Independently packaged SQLite/SFTP, real host-key test, typed resource, explicit registration. | **POC-SCN-02, 11, 12 pass** using real providers; native package dependency resolution; denied trust is not retried. | I3 (no bypass of policy). |
| **I5: lifecycle/resilience/diagnostics** | Narrow SQL adapter, three-provider resource tracking, bounded admission, endpoint vs context breaker, single-repeat acquire retry, .NET telemetry. | **POC-SCN-13 through 17 pass** on real resources; no leak/replay/unbounded growth; audit separate. | I4. |
| **I6: SQL recovery/compatibility close** | Controlled SQL restart and uncertain commit; scoped native `ClearPool` harness comparison; full OS/package/API matrix and evidence review. | **POC-SCN-04, 18 through 21 pass** at mandatory gates, comparative result for 20 (including defensible *no benefit*), completed all-21 matrix, independent reviewer and owner decision. | I5 + approved private test infrastructure. |

**Why I1 is smallest:** it falsifies the riskiest foundational assumption (one dependency-neutral contract usable by an old .NET Framework client and modern .NET) before any crypto, configuration engine or live provider infrastructure. It does **not** pretend to satisfy provider-registration or compatibility scenarios in full. Workstream B and C then build on precisely the same admission seam.

## 11. Evidence format, verification gates, and stopping rules

Each test result shall include: `POC-SCN` ID, `REQ-*` aliases, test name, exact assertion, fixture reference and config revision, build/assembly/package and native binary versions, runner OS/architecture/runtime, setup and isolated-fault protocol, actual versus expected result, redacted error code, metrics/audit samples as appropriate, observed limitations, cleanup outcome, and independent reviewer signoff. Tag each conclusion `Documentation-backed`, `Observed`, or `Inference`.

For the SQL comparison report: native-only and scoped-clear cases share the same pinned SQL build, connection string identity, server readiness definition, host hardware class and run conditions. Report distribution rather than one cherry-picked timing. The decision on AD-35 after POC is **build next**, **defer**, or **reject**; evidence of no measurable value is a valid reason to defer, not a failed scenario.

**Immediate containment/stop:** any exposed secret/key/connection string; accepted untrusted SFTP key; unauthorized cross-tenant resource access; tampered/expired/rolled-back grant admitted; misleading audit success; unknown SQL operation automatically replayed; uncontrolled queues/leases/retries; unauthorized cross-pool clearing; infrastructure exposure or a permission restriction. Preserve redacted evidence, isolate test services and return to the owner/security reviewer. Do not continue by reducing a requirement.

**Architecture decision gate:** security contract impossible on a supported host, no credible offline trusted time/context, irreconcilable TFM public API drift, unsafe shared native pool identity, or driver behavior incompatible with bounded/no-replay semantics. Surface the gap for explicit approval.

**Final POC gate:** all **21** approved scenarios evaluated and traceable; safety/portability mandatory gates, especially **01-10, 12-19 and 21**, pass; both Windows `net48` and Windows `net10` restart-recovery without client restart pass; SQL uncertainty never replayed; no critical/high unmitigated security issues; no unbounded resource use; matrix and dependency/SBOM complete; explicit AD-35 value decision and deferred backlog reviewed. Scenario 20 can report no added benefit without POC failure. Implementation completion does not itself authorize merging, tagging, release, publication or next-phase work.

## 12. Risk and mitigation register

| Priority | Risk | Engineering treatment |
| --- | --- | --- |
| Critical | Offline clock/state rollback on customer-owned hostile device | Explicit trust-tier model, injected trusted-time boundary, protected monotonic evidence where available, fail-closed unverifiable state; no false hardware-security promise. |
| Critical | SFTP trust bypass | Independently provisioned pinned key, fail closed on mismatch before trusted use, negative real-server test, no TOFU. |
| Critical | Silent SQL command replay after lost commit acknowledgment | Disable driver command retry features and prevent manager command replay; observable `IndeterminateOperation`; explicit reconciliation outside manager. |
| High | SQL native pool shared across logical tenants | Normalize pool keys, use separate credentials where isolation required; do not promise tenant-scoped `ClearPool` for shared physical key; reject unsafe intervention. |
| High | SQL driver has extensive transitive/runtime dependencies | Pin entire graph, license/SBOM audit, actual old-style Windows runtime loading, redirects, TLS/native SNI qualification. |
| High | Linux protection differs from Windows DPAPI | Test honest host/key assumptions, deny if trusted context absent, no weaker success path by OS. |
| High | Provider-native retries multiply library attempts | Count manager, driver and physical connection attempts independently; no blanket operation replay. |
| High | Config writes fail after rename but before durability | Platform crash-point fault injection and last-known-good atomic semantics; report limits of filesystem operations. |
| High | SQL infrastructure inaccessible to Windows CI | Require approved private cross-OS network before I6, separate supervisor credentials, no public port exposure. |
| Medium | SQLite async methods block threads / native pooling keeps file handles | Admit this limitation, test bounded concurrency and cleanup; don't promise native async cancellation. |
| Medium | Added contracts become generic lowest-common-denominator | Typed adapter capabilities and explicit unavailability; no universal query/stream API. |
| Medium | 2026 package versions were only researched, not restored/scanned | Confirm GA signatures/license/native assets and package lock/SBOM as I0 entry work. |

## 13. Primary documentation and provider sources

Research performed before execution; source pages are current as of this kickoff. Package pages prove available metadata, not actual local resolution or runtime behavior.

1. Microsoft [.NET releases and support](https://learn.microsoft.com/en-us/dotnet/core/releases-and-support); [.NET Standard](https://learn.microsoft.com/en-us/dotnet/standard/net-standard); [package validation](https://learn.microsoft.com/en-us/dotnet/fundamentals/package-validation/overview).
2. Microsoft [SqlClient releases](https://learn.microsoft.com/en-us/sql/connect/ado-net/microsoft-data-sqlclient-release-notes); [provider support](https://learn.microsoft.com/en-us/sql/connect/ado-net/download-microsoft-sqlclient-data-provider); [SQL connection pooling](https://learn.microsoft.com/en-us/sql/connect/ado-net/sql-server-connection-pooling); [`ClearPool`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection.clearpool); [configuration options](https://learn.microsoft.com/en-us/sql/connect/ado-net/connection-options).
3. NuGet [`Microsoft.Data.SqlClient` 7.1.2](https://www.nuget.org/packages/Microsoft.Data.SqlClient/7.1.2), including native SNI and transitive package groups.
4. Microsoft [SQLite connection strings and pooling](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/connection-strings); [async limitations](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/async). NuGet [`Microsoft.Data.Sqlite` 10.0.15](https://www.nuget.org/packages/Microsoft.Data.Sqlite/10.0.15), including SQLitePCLRaw/native package dependencies.
5. SSH.NET [repository / framework support](https://github.com/sshnet/SSH.NET), [2026.0.1 release](https://github.com/sshnet/SSH.NET/releases/tag/2026.0.1), [host-key examples](https://github.com/sshnet/SSH.NET/blob/develop/docfx/examples.md), [pre-auth memory issue and fixed versions](https://github.com/sshnet/SSH.NET/security/advisories/GHSA-h5q6-2gr6-3g3m), and [NuGet version](https://www.nuget.org/packages/SSH.NET/2026.0.1).
6. Microsoft [SQL Server Linux Docker test instructions](https://learn.microsoft.com/en-us/sql/linux/install-upgrade/quickstart-install-docker) and [Developer Edition nonproduction licensing](https://learn.microsoft.com/en-us/sql/linux/sql-server-linux-configure-environment-variables).
7. Microsoft [metrics API for .NET Framework](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.metrics.meter), [metrics instrumentation](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/metrics-instrumentation).

## 14. Consolidated recommendation and approval gate

**Approve** this engineering charter as the implementation blueprint for POC-001 while maintaining the original architecture and all 21 scenario criteria unchanged. First implementation authority should be limited to **I0 and I1**: preflight/versions/security readiness plus dependency-free core contracts and representative Windows net48/net10 consumer tests. Subsequent increments should be separately reviewed at their security and provider evidence gates under the approved POC charter.

**No implementation action has been performed.** No repository created or modified, no experiment executed, no infrastructure provisioned, no PR opened, no merge/tag/release/publication carried out. A future instruction from Jim authorizing I0/I1 is required before starting.

Suggested owner authorization:

> I approve the POC-001 Engineering Kickoff Charter and authorize implementation of I0 and I1 only, including creating the dedicated Data Source Manager repository and the minimal contracts/consumer test foundation. Preserve AD-001 through AD-035 and all 21 acceptance scenarios. Do not provision SQL/SFTP infrastructure, run provider experiments, implement later increments, merge, tag, release, or publish without my separate approval.