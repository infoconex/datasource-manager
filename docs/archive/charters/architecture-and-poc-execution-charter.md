# Data Source Manager — Consolidated Architecture and POC Execution Charter

**Prepared:** November 15, 2026 (America/Los_Angeles)  
**Version:** Proposed 1.0 — planning only  
**Disposition:** **Not approved for engineering or execution**  
**Requested approval:** AD-34, AD-35, and the POC-001 charter as a single gated plan.  
**Scope authorization:** This document does not authorize implementation, experiments, infrastructure provisioning, repository changes, publication, or releases.

## 1. Evidence and governance

### 1.1 Decision provenance

* **Previously approved:** AD-001–AD-033; high-level architectural principles enumerated in the project handoff; EXP-001–EXP-004 experiment charters **approved for planning but never executed**.
* **Recoverable historical detail:** EXP-001's seven thematic configuration cases (without original IDs); EXP-002's four workstreams and SCN-01–12; EXP-003's four workstreams and SCN-001–020; EXP-004's four workstreams and SCN-001–020. These are summarized in §5, not presented as verbatim archival copies.
* **New proposals, not prior decisions:** AD-34, AD-35, the proposed runtime qualification rules, all `POC-SCN-*` acceptance criteria, measurements, gates, and deferrals in this document.
* **Unavailable historical record:** Full original wording for all 33 ADs, every original EXP-001 scenario identifier, and a canonical numbered requirement register. This charter does not fabricate them. All `REQ-*` labels below are **new traceability aliases** for the user-provided requirements; they do not supersede any future original identifiers.

### 1.2 Authoritative information versus unproven claims

**Documentation-backed:** .NET Standard 2.0 is a compatibility bridge for .NET Framework 4.8 and modern .NET; Microsoft recommends modern TFMs plus .NET Standard when needed; package validation detects cross-TFM API drift; SqlClient retains separate physical pools, can detect broken connections, and exposes targeted `ClearPool`; it cannot promise a successful checkout and execution through every outage; `Microsoft.Data.Sqlite` supports native pooling and executes its async ADO.NET operations synchronously; SSH.NET documents support for .NET Framework 4.6.2+, .NET Standard 2.0, and modern .NET, and offers fingerprint verification. See §14.

**Must be measured:** actual .NET Framework 4.8 consumer compatibility and dependency resolution; cross-runtime semantic parity; restart behavior across a selected SqlClient version and SQL Server configuration; reconnect latency; native versus policy-assisted recovery; safe cancellation and disposal of concrete adapters; credential cache portability/tamper reaction; atomic file activation on each test OS; provider resource usage.

**Explicit inference/limitation:** No ordinary user-space library on an adversarial customer-owned device can guarantee perfect clock integrity, non-extractable secrets, or immediate revocation while disconnected. Strong anti-rollback guarantees require a trustworthy clock/state anchor, hardware-backed root of trust, or online authority. POC-001 shall prove fail-closed behavior for *detectable or unverifiable* conditions in the stated threat model, not an impossible guarantee against a fully compromised host.

## 2. Approved architecture reaffirmed

1. SOLID, hexagonal architecture with explicit inbound and outbound interfaces; domain/core business rules do not depend on provider SDKs or resilience frameworks.
2. Independent optional provider adapters, explicitly and trustfully registered; no ambient plugin discovery or implicit loading.
3. Versioned capabilities distinguish **supported**, **currently available**, and **authorized**; unsupported critical security or consistency features fail closed.
4. Capability-based managed leases, provider-appropriate typed resources, explicit disposal, policy-controlled acquisition, and truthful limits on exposed native operations.
5. Provider-native pooling; no duplicate physical pool. No Polly or third-party resilience dependency in the core.
6. Authenticated, version-aware configuration snapshots, atomic activation, ownership boundaries, last-known-good local continuity subject to authorization expiry, no invalid/stale overwrite.
7. Trust-aware secrets, guarded rotation/revocation, offline grants with strict expiry, and exceptional access only with independent authorization and auditing.
8. Consistency-aware routing, bounded and semantics-aware retries, no blind replay of uncertain operations, failure-domain-aware local circuit breakers, independent healthy alternatives.
9. Privacy-first .NET instrumentation, application-owned collection/export, independent security audit, low-cardinality labels, and structured redacted errors.
10. Explicit provider/runtime/OS/security/authentication compatibility matrices; no blanket portability assumptions.

**Important interpretation:** A *data source* is broader than a database connection. SQL/SQLite may expose `DbConnection`-style capabilities; SFTP, FTP(S), SMTP, and SMB use distinct typed operation/resource models. They share admission, authorization, lease, diagnostics and configuration contracts, not an artificial universal query/connection API.

## 3. AD-34 — Framework compatibility (recommended for formal approval)

**Decision:** Officially support **.NET Framework 4.8 on Windows** and **.NET 10 LTS on Windows/Linux** for initially qualified capabilities. Treat .NET 11 as a **tested compatibility target**, to be promoted to official support only after qualification; .NET 8 as possible best-effort binary compatibility after end of runtime support; .NET 6 as unsupported. macOS remains a provider/OS-specific qualification candidate, not an untested promise.

**Packaging baseline:** `netstandard2.0;net10.0` for reusable library packages where justified, with `netstandard2.0` available to .NET Framework 4.8 consumers. A pure core without framework-specific APIs or external dependencies may remain `netstandard2.0` only. Do not add `net48` or `net11.0` assembly assets merely for symmetry. Reconsider a `net48` asset only if installation/binding/behavior evidence warrants it. Provider adapters select their own compatible assets while preserving public contractual parity.

**Constraints:**

* Identical public API meaning, errors, authorization, disposal, and capability semantics across targets. Newer TFMs must not weaken security guarantees or remove the public contract available via the fallback asset.
* Test an actual non-SDK-style or otherwise representative `net48` consumer (including NuGet dependencies, binding redirects, C# 7.3 calling code, Windows authentication where in scope), plus `net10.0` Windows/Linux consumers; run a `net11.0` consumer smoke/compatibility check.
* Use SDK API compatibility/package validation, OS compatibility analysis, real integration tests and dependency/SBOM checks; compilation or TFM selection alone is insufficient.
* Baseline minimum lease disposal contract: `IDisposable`, including exception paths. Consider asynchronous disposal only if the same portable contract can be implemented and packaged cleanly across TFMs (for example, verifying any required `Microsoft.Bcl.AsyncInterfaces` dependency); do not conditionally alter public semantics.
* TFM compatibility does **not** imply provider, driver, native dependency, TLS, OS, or authentication support. Matrix entries must be specific and evidence-backed.

**Rationale:** Microsoft's library and Azure SDK guidance explicitly recommends `netstandard2.0` plus a current modern LTS TFM when broad compatibility and current APIs are both needed; Microsoft package validation addresses compatible asset API drift. As of this review, .NET 10 and 11 are supported through November 2028; .NET 8 has exited support.

## 4. AD-35 — Optional native pool coordination (recommended for formal approval)

**Decision:** Approve an **optional, capability-discovered management layer over provider-native pooling**. Do not create physical pools or a second general retry engine. Do not require this capability in providers that have no native pool.

**Allowed, only when substantiated by a provider:** supported pool settings; bounded logical admission; scoped health/utilization estimates; targeted provider-native invalidation; coordination with credential rotation/revocation; manager-tracked lease draining; structured redacted diagnostic events.

**Not promised:** hard cancellation of operations already executing remotely; forced immediate closure of checked-out native physical connections; exact physical pool size where provider lacks an API; guaranteed rescue of a stale checkout; tenant-specific `ClearPool` where multiple tenants share the same underlying provider pool key.

**Safety requirements:**

* `ClearPool` is available for an **actual matching SqlClient pool identity** (connection string, authentication identity, credential/token identity, process), not for an arbitrary logical tenant label. Verify ownership and shared-pool blast radius before allowing invalidation.
* `ClearAllPools` is explicitly excluded from routine tenant/profile-scoped operations; privileged global maintenance, if ever supported, requires separately approved policy.
* Pool-clearing does not fix server outages or restart active operations. Draining rejects new manager admissions and waits for tracked leases; in-use physical connections may remain until returned.
* Normalize connection string construction deterministically to limit accidental pool fragmentation without collapsing distinct security contexts. Never record raw connection strings or credentials in telemetry.
* Do **not** implement the pool manager in POC-001. Compare native-only behavior with a tightly controlled *test-harness invocation* of existing `ClearPool`; promote implementation only if value, isolation, and complexity are evidenced.

## 5. Consolidation of approved but unexecuted EXP-001–004

No experiment is declared completed by this consolidation. Approved original charters remain planning records and their requirements carry into the long-term roadmap. POC-001 uses only the smallest cross-cutting proof cases.

| Prior charter | Historically recoverable scope | POC-001 subset | Still mandatory later / deliberately deferred |
|---|---|---|---|
| **EXP-001** Configuration | Authenticated/version-aware snapshots, atomic activation, interruption/cache recovery, local independence, override and stale/rollback rejection, tenant boundaries; full vs incremental snapshot research, polling with optional push | Signed/versioned fixture, atomic activation/rejection, last-known-good and offline restart, local/tenant isolation | Full central service, reconciliation at fleet scale, incremental transfer, push, migration/rollback orchestration, production configuration delivery |
| **EXP-002** Security | A credentials, B offline authorization, C rotation/revocation, D emergency audit; 12 scenarios (see below) | Protected test credentials, wrong-device failure, expiry/rollback, denied acquisition after revoked grant, audit boundary | Actual production vault/PKI, key migration/re-enrollment, full credential rotation with active sessions, emergency grants, replay-safe audit delivery |
| **EXP-003** Routing & resilience | A routing/consistency, B resilience/breakers, C health, D telemetry; 20 scenarios | One healthy/unhealthy endpoint boundary, bounded connection retry, passive health, privacy-first telemetry, SQL restart | Weighted/ranked routing, replica freshness and affinity, advanced breaker tuning, active probes, distributed health, comprehensive exporter behaviors |
| **EXP-004** API & adapters | A public API, B adapters, C lifecycle, D compatibility; 20 scenarios | Core + explicit registration, capability states, SQLite/SFTP real adapters, managed leases/disposal, net48/net10 qualification | All other provider adapters, native API exposure policy expansion, full OS matrix, package lifecycle and long-term dependency support |

### 5.1 Archived scenario preservation (summaries, not verbatim)

**EXP-001 — scenario numbering unavailable:** Seven recoverable scenarios: (1) validate and atomically activate valid central updates; (2) interrupted download retains last-known-good; (3) restart during outage loads eligible protected cache; (4) local profiles remain independent; (5) disallowed security overrides rejected; (6) stale/rolled-back revisions rejected; (7) tenant/organization boundaries remain intact.

**EXP-002 — approved 12 scenarios:** SCN-01 wrong-device copied cache cannot decrypt; 02 lost security context requires re-enrollment; 03 only explicitly authorized encrypted local recovery; 04 offline expiry denies new acquisitions; 05 clock rollback/reboot/snapshot uncertainty fails closed; 06 active credential rotation retires old pools by policy; 07 revocation stops new acquisitions and reports active-session limits; 08 failure during SQL commit reports uncertain result without replay; 09 offline emergency access requires independent valid grant; 10 failed security-audit persistence denies emergency access; 11 repeated delivery does not duplicate accepted audit events; 12 customer-owned device cannot receive centrally managed shared secret without expressly approved trust mechanism.

**EXP-003 — approved 20 scenarios:** SCN-001 provider-native routing preference; 002 priority/eligible failover; 003 round robin/weighted/local least-active; 004 replica freshness; 005 affinity; 006 acquisition deadlines; 007 bounded retries; 008 no retry for authentication/TLS; 009 failure-domain breaker isolation; 010 bounded half-open; 011 cancellation and unknown outcomes without replay; 012 health signals; 013 no unsolicited probes on customer devices; 014 bounded authorized probes; 015 stale shared health does not globally block; 016 local operation without shared monitoring; 017 .NET-native diagnostics; 018 privacy/cardinality; 019 exporter failure isolation; 020 independent audit.

**EXP-004 — approved 20 scenarios:** SCN-001 explicit testable acquisition interface; 002 typed provider behavior; 003 capability identification without connection; 004 policy non-bypass; 005 no silent security/consistency downgrade; 006 optional adapter installation; 007 dependency isolation; 008 explicit trusted registration; 009 adapter upgrades without unrelated core change; 010 explicit missing capabilities; 011 provider-specific cleanup/native pooling; 012 truthful active lease tracking; 013 rotation/revocation lifecycle; 014 cancellation not misrepresented as remote termination; 015 concurrent acquisition/disposal safety; 016 Windows/Linux results; 017 macOS assumptions flagged; 018 version support limits documented; 019 unsupported security fails closed; 020 third-party dependency support/license/security/maintenance considered.

## 6. POC-001 — Secure Provider Acquisition and Recovery

**Purpose:** Falsify or confirm the architecture's highest-risk integration and security assumptions with the smallest live vertical slice. This is not a first release, minimum viable product, or authorization to implement all planned provider features.

**Workstreams (three, sequenced):**

* **A — Portable contracts and admission:** Dependency-neutral core, explicit adapter registration, capability query, typed lease, disposal, compatibility harness.
* **B — Configuration and authorization boundary:** Signed/versioned configuration fixture, valid/invalid atomic activation, protected secret, finite offline grant, wrong-context and tamper behavior, audit contract.
* **C — Actual providers and recovery:** SQLite and SFTP resource models; a narrowly scoped SqlClient test adapter/harness for SQL Server pool restart; resource lifecycle, bounded acquisition, passive health, failure domains, safe telemetry.

**Exactly in scope:** One local configuration implementation and one simulated central update feed (fixtures, not a production service); one representative Windows trust anchor and a portable Linux substitute only where security semantics can honestly be met; an isolated SQL Server restart-capable instance; a test SFTP endpoint with pinned host key; local SQLite database. Pin exact versions before execution. Use disposable test identities and synthetic data only.

**Out of scope:** Every other provider adapter, production enterprise management service, customer device fleet, distributed control plane, generalized query/file/message operations, production secrets storage integration, mass credential rotation orchestration, emergency-access execution, global telemetry exporter, full failover planner, custom pool implementation.

## 7. New POC-001 acceptance scenarios — proposed, not historically approved

Every criterion applies to the explicitly qualified test frameworks/OSs, unless the line states otherwise. All negative scenarios must result in typed, redacted, auditable outcomes.

| ID | Exact acceptance criterion and evidence | Workstream |
|---|---|---|
| **POC-SCN-01** | With zero adapters registered, core loads without provider packages and an acquisition request returns explicit `UnsupportedProvider`; no dynamic/ambient provider loading occurs. A dependency graph and test prove this. | A |
| **02** | Register only trusted SQLite/SFTP/SQL test adapters; duplicate, unknown, or untrusted registration is rejected. Independent provider package references are recorded. | A |
| **03** | Query versioned provider capabilities without opening a connection and distinguish `Unsupported`, `TemporarilyUnavailable`, and `Unauthorized`; security-critical missing capabilities fail closed. | A |
| **04** | Same consumer-visible contract succeeds on real .NET Framework 4.8/Windows and .NET 10/Windows/Linux hosts, with .NET 11 compatibility smoke. Package and API validation show no contract drift; compile/load/operate/dispose and dependency resolution are recorded separately. | A |
| **05** | A valid authenticated, strictly newer configuration revision activates as one complete snapshot; invalid signature, malformed payload, prohibited override, stale version or interrupted write preserves the last valid snapshot without partial activation. Record old/new revision and crash point. | B |
| **06** | After application restart and simulated central outage, locally configured profiles still work and centrally managed profiles work **only** while their separate authorization grants remain valid. Never interpret cached configuration as permanent authorization. | B |
| **07** | Tenant/organization/profile ownership and security-sensitive configuration precedence are enforced; a cross-tenant or lower-trust override cannot affect any acquisition or secret. | B |
| **08** | The test protected credential is not readable from copied cache on a different security context; loss of protection context produces an explicit fail-closed outcome; ordinary logs, exception text, metrics and traces contain no secrets/connection strings. | B |
| **09** | Expired, invalid-signature, revoked, rollback-detected or unverifiable-time offline grant denies **new centrally managed acquisitions** with no implicit grace period. Reboot/restart tests document the exact trust/time assumptions, not an unsupported guarantee against a hostile host. | B |
| **10** | Security event outcomes are delivered through a separate audit port, never substituted by ordinary diagnostic telemetry. For audit-required actions, injected audit-persistence failure denies the action rather than asserting successful auditing. Audit delivery/idempotency mechanisms remain later-scope. | B |
| **11** | Using one acquisition model, a SQLite adapter returns a SQLite-appropriate typed resource and an SFTP adapter returns an SFTP-appropriate typed resource. Missing provider-specific operations explicitly report unavailable capabilities; neither is coerced into `DbConnection`. | A/C |
| **12** | SFTP accepts the configured authentic host key and rejects a changed/untrusted host key **before trusted use**; credential and host-key errors are not treated as transient endpoint outages. Capture test-endpoint identity only in safe/redacted form. | C |
| **13** | Every acquired SQLite/SFTP/SQL resource is tracked and disposed on normal, exception, cancellation and concurrent paths; final active managed lease count is zero after all scopes close; repeated dispose is safe. A cancellation result does not falsely assert remote SFTP/SQL work stopped. | C |
| **14** | Admission has a bounded queue/concurrency limit; when full, excess calls fail within their caller-specified admission deadline without creating unbounded queued tasks. Provider calls past admission may exceed cooperative cancellation; expose that limitation. | C |
| **15** | Inject one endpoint-down condition and one tenant/authentication failure. Failure-domain state prevents one bad tenant/security context from opening a global endpoint breaker or blocking independently healthy acquisitions; no retry on authentication/TLS/policy denial. | C |
| **16** | Acquire-level retry only: maximum **one manager-level repeat** after initial transient acquisition failure, subject to a caller deadline and provider retry settings; no command, upload, SMTP operation, or transaction is silently replayed. Count physical/native attempts separately to detect multiplicative retries. | C |
| **17** | Low-cardinality .NET meter/trace/events report admission, disposal, selected failure domains and recovery timing with safe configuration IDs; exporter/observer failures do not prevent normal eligible acquisition. Security audit remains separate. | C |
| **18** | On .NET Framework 4.8/Windows and .NET 10/Windows, fill and return SQL connections to a native SqlClient pool, restart SQL Server without restarting client, reacquire, and eventually complete a new harmless read after the server is ready. Record stale-checkout failures, driver recovery, native pool invalidation, elapsed times and all errors. An initial acquisition failure is permissible; recovery without application restart is mandatory. | C |
| **19** | Induce interruption at/near SQL command execution or transaction commit. Report an explicit **indeterminate operation outcome** when the result cannot be established. Assert no manager or configured driver **command-level** retry/replay occurs; only a new caller-authorized operation may execute. | C |
| **20** | Against the same documented restart fixture compare (a) native pooling/recovery alone with (b) a test-harness **scoped `SqlConnection.ClearPool`** after observed failure. Record successful first recovery, failures, recovery latency, hard-connect churn and collateral pool impact. Do not build AD-35 coordinator; recommend implementation only if it demonstrably adds value and can be safely scoped. | C |
| **21** | The run records exact library/provider versions, runtimes, Windows/Linux distributions, authentication/TLS modes, native binaries, pooling settings, CPU architecture, SQL version, test sequence, logs redacted, and pass/fail/limitations for each matrix cell. Any unsupported or untested cell is visibly marked, never silently declared supported. | A/B/C |

### 7.1 SQL Server restart test details

1. Use a dedicated disposable SQL Server instance/VM/container with restart permissions; no customer or shared production server.
2. Use one pinned supported General Availability `Microsoft.Data.SqlClient` release. Record any `Connection Idle Timeout`, pool V1/V2, `Min/Max Pool Size`, `ConnectRetryCount` and related AppContext switches **only if that release supports them**; do not assume new driver-specific options exist in all versions.
3. Fix one representative pool key and authentication identity; prefill by opening, successfully testing and closing several connections. Confirm through supported diagnostics that pooling is used (avoid treating implementation details as contractual guarantees).
4. Restart server while clients stay alive. Check first reuse; capture whether SqlClient reconnects internally, clears a pool, returns an error, or experiences its built-in pool blocking period.
5. When server readiness is established externally, repeat **new bounded acquisition attempts** until a harmless `SELECT` succeeds or stop policy fires. Use a separate test case for uncertain in-flight work; never use the latter as a reason to replay.
6. Repeat with targeted `ClearPool` as a controlled, optional **harness** intervention, never `ClearAllPools` by default. Log direct dependency/native diagnostic provenance for measured effects.
7. Run on .NET Framework 4.8 and .NET 10; include .NET 10 Linux compatibility as a separate recorded matrix cell if the selected SQL Server instance/authentication configuration supports it.
8. Never assert deterministic latency across arbitrary SQL Server restart or recovery durations. Measure time from **verified server-ready** to successful new acquisition; first POC goal is eventual in-process recovery with bounded individual attempts, not an invented universal SLA.

### 7.2 Retry and deadline policy for this experiment

* Proposed library-level maximum: **two acquisition invocations** total (initial + one retry) for eligible transient acquisition errors, *never* for unknown operation outcome, rejected credentials/certificates/SSH host keys, policy denial or unauthenticated configuration.
* Respect caller-provided deadline and cancellation at every manager-owned boundary. Do not claim that native provider calls can always be interrupted on every TFM.
* Document native SqlClient retries separately; avoid installing an extra SqlClient configurable command retry provider. The configured combination must not cause an unbounded or unexpectedly multiplied series of attempts.
* Distinguish **outage duration** from a single failed acquisition. Recovery is demonstrated by independently requested acquisitions made after server readiness, not by indefinitely holding one request open.
* No arbitrary throughput or millisecond pass threshold is set before baseline workload measurements. Unbounded queue growth, retries, leases or memory usage are unconditional failures.

## 8. Requirements → architecture → scenarios traceability

The `REQ-*` names below are newly assigned planning aliases, not retrospective historical requirement IDs. **D** denotes a later mandatory verification obligation; absence from POC-001 does not cancel the requirement.

| New requirement alias | Basis in approved architecture | POC-001 proof | Deferred obligation |
|---|---|---|---|
| REQ-01 Provider-neutral core / SOLID / explicit ports | Dependency-free core, hexagonal, trusted registration (AD-028–033 group) | 01, 02, 03 | D-01 governance/independent adapters |
| REQ-02 All nine provider families | Independent adapters, typed capabilities | 11, 12, 18 (SQLite, SFTP, SQL only) | D-02 PostgreSQL, MySQL, FTP, FTPS, SMTP, SMB/UNC |
| REQ-03 Centrally managed + local profiles | Versioned sync, local independence | 05, 06 | D-03 central management and reconciliation |
| REQ-04 Customer-owned + managed devices | Trust-aware secrets / fail closed | 08, 09 (simulated contexts) | D-04 real device enrollment/attestation |
| REQ-05 Config integrity, version, override boundaries | Version-aware atomic snapshots | 05, 07 | D-05 fleet synchronization, migrations |
| REQ-06 Credential protection | Platform-appropriate secrets boundary | 08, 12 | D-06 production vault/HSM/PKI support |
| REQ-07 Rotation + revocation | Authorized acquisition + lifecycle | 09, 13 (new admissions only) | D-07 active credential transition and pool retirement |
| REQ-08 Strict offline expiry | Valid grant, rollback detection, fail closed | 06, 09 | D-08 trusted clock/anti-rollback threat-model choices |
| REQ-09 Emergency access + independent audit | Separate grants/audit | 10 (audit boundary only) | D-09 emergency flow and durable deduplicated audit |
| REQ-10 Capability versioning + policy enforcement | AD-028–033 group | 03, 11 | D-10 provider-specific feature expansion |
| REQ-11 Resource lease and disposal | AD-028 | 11, 13, 14 | D-11 provider-specific long operations |
| REQ-12 Native pooling | Pool ownership remains provider | 13, 18, 20 | D-12 other provider pool qualification |
| REQ-13 Optional pool coordinator | AD-35 **proposed** | 20 (measure only) | D-13 optional coordinator if justified |
| REQ-14 Connection recovery / bounded retries | Approved resilience, no blind replay | 15, 16, 18, 19 | D-14 other providers' recovery cases |
| REQ-15 Consistency-aware routing/failover | Approved routing, failure isolation (AD-027) | 15 (one simple isolation case) | D-15 weights, replicas, affinity and topology |
| REQ-16 Failure-domain circuit breakers | AD-027 | 15 | D-16 half-open, retention, advanced edge cases |
| REQ-17 Privacy-first diagnostics | AD-026 / structured errors | 08, 17, 21 | D-17 complete exporter/collector/audit integration |
| REQ-18 Framework/OS/provider compatibility | AD-033 group, AD-34 **proposed** | 04, 21 | D-18 extended OS/auth/driver matrix |
| REQ-19 Honest cancellation + operation outcome | AD-028 and retry safety | 13, 19 | D-19 all file/message provider operations |
| REQ-20 Trust and security under failures | Fail-closed security, redacted errors | 07–10, 12, 15, 19 | D-20 threat model and adversarial production validation |

## 9. Prerequisites and run evidence

**Before kickoff authorization:** Owner approves AD-34/35 and charter; named accountable engineering owner; capture the previously approved AD-001–033 and original EXP-001–004 texts as immutable historical inputs if available; clarify trust model limits; declare provider selection and versions; approve isolated test infrastructure and access boundaries; sign off threat model for the POC scope.

**Execution-ready inputs (after approval only):**

1. Framework hosts: .NET Framework 4.8 supported Windows client; .NET 10 Windows and Linux; .NET 11 smoke environment. Include a representative old-style consuming project and modern consumer; check compatibility/license/support of exact packages.
2. Test assets: disposable local SQLite database, isolated SFTP endpoint with known host key, isolated restartable SQL Server with no shared customer data; controlled test identity and revocable test credentials.
3. Security fixtures: a separately controlled test signer/verifier, signed versioned grant, intentionally invalid/tampered records, protected cache with distinct device/user contexts and audit-sink failure injection. No real privileged secrets in fixtures.
4. Test protocol: deterministic order and recorded assumptions, repeatability plan, independent SQL readiness signal, per-run audit/diagnostic redaction checks, initial/native recovery comparison, explicit abort and cleanup plan.
5. Verification: unit tests for core policy and config; integration tests against real SQLite/SFTP/SQL; package/API compatibility analysis; actual consuming-host tests; static dependency/licensing/security checks; structured results tied to scenarios and requirements.

**Evidence per scenario:** test name and acceptance assertion; objective record of command/setup or procedure; OS/runtime/SDK, package and server versions; input fixture ID/revision (not secret value); observed expected/actual outcome; redacted error category; trace/metric snapshot where relevant; cleanup and any unresolved limitation; independent reviewer decision. Distinguish **documentation established**, **test observed**, and **inference** on every material conclusion.

**Benchmarks:** collect baseline acquisition durations, restart-to-ready, ready-to-recovered, error counts, lease counts, bounded queue sizes, retry counts including provider-native retries, physical login churn where measurable, and output labels/cardinality. Report distributions and conditions; do not turn unmeasured budgets into advertised SLAs.

## 10. Stopping conditions and exit gates

**Stop immediately and contain** if: leaked credentials/connection strings/private keys, untrusted host key accepted, unauthorized cross-tenant acquisition, expiry bypass, rollback/tamper accepted contrary to policy, any operation replayed after ambiguous commit, lost audit-critical event claimed successful, uncontrolled retry/queue/lease growth, pool clearing beyond isolated authorized scope, exposure of production/test infrastructure outside approved boundaries, provider crash affects core security isolation, or an authorization/permission restriction is encountered.

**Pause and return for architecture decision** if: a supported consumer cannot satisfy the same security contract; offline authorization depends on unavailable trusted time/secret protection; native SqlClient behavior makes the approved safe retry contract impossible; a public API would need incompatible per-TFM semantics; or tenant-scoped coordination cannot be guaranteed without shared-pool blast radius. A failed mandatory proof is **not** a reason to weaken the requirement silently.

**POC completion requires:**

* All 21 proposed POC-SCN criteria evaluated with recorded pass/fail/limitations; all **mandatory** critical safety and portability gates pass, especially 01–10, 12–19, 21.
* SQL Server restart recovery passes on both .NET Framework 4.8 and .NET 10 without restarting the client; original transient failure may be observed, and no uncertain operation is replayed.
* No unresolved critical/high security issue; no unbounded resource acquisition or leak; full evidence and normalized compatibility matrix.
* AD-35 value decision explicitly recorded as **build next / defer / reject** based on comparative data; POC-SCN-20 may conclude "no benefit" without failing POC.
* Reviewed architecture fit-gap, required decision changes, follow-on backlog, dependency inventory, known risks and supporting citations. Owner must separately authorize any engineering phase after completion.

## 11. Contradictions, gaps, complexity and risk register

| Risk / finding | Severity | Architectural treatment and decision needed |
|---|---|---|
| Strict offline expiry versus hostile device clock/snapshot | **Critical** | Cannot promise absolute offline enforcement on fully compromised device. Deny when trusted time/state cannot be established; define device trust tier, allowed offline lifetime and acceptable residual physical compromise risk. |
| Offline revocation versus no connectivity | **High** | Immediate server revocation cannot reach disconnected clients; previously issued grants remain potentially usable until expiry absent a trusted online check. Default to shortest justified grants and deny upon new acquisitions after known revocation. |
| Credential rotation versus pooled active sessions | **High** | A rotated secret does not instantly terminate existing physical server sessions. Coordinate new admission, provider clearing, lease drain and honest active-session limits; deeper proof later. |
| Tenant logical isolation versus shared SQL physical pool | **High** | Pool keys and security identity—not tenant label—determine native scope. Pool-clearing authorization must reject or escalate shared scopes, not pretend targeted isolation. |
| Silent SQL command retries versus uncertain commit | **Critical** | Disable command-level automatic replay in POC; preserve indeterminate result and caller-driven reconciliation/idempotency for future. |
| Multiple nested retry mechanisms | **High** | Explicitly count native driver and library attempts; no generic additional retry on arbitrary operations or authentication errors. |
| `netstandard2.0` compile versus real `net48` execution | **High** | Legacy binding redirects, native crypto/TLS, disposal shims and driver versions require real consuming-host tests. |
| SFTP trust versus convenience defaults | **Critical** | Approved pinned host key/CA, fail closed on mismatch, no trust-on-first-use without explicit separately approved policy. |
| SQLite async API and file semantics | **Medium** | SQLite provider async APIs are synchronous; avoid marketing cancellation/concurrency properties it lacks; test locks, cleanup and native pooling honestly. |
| OS portability and SMB/UNC, authentication differences | **Medium/High** | Provider-by-provider matrix; Windows UNC behavior is not automatically a cross-platform SMB implementation. |
| Generic provider interfaces becoming lowest-common-denominator | **High** | Keep common admission/capabilities/lease boundary; typed per-provider operation contracts and separately negotiated features. |
| Telemetry leaks / high cardinality / exporter backpressure | **High** | Allowed attributes only, no raw endpoint/connection string/tenant identifiers without approved policy, independent security audit, observer failure isolation. |
| Massive experiment scope dilutes falsifiability | **Medium** | Three workstreams, two general-purpose adapters and one targeted SQL restart case. Reuse Microsoft/provider functionality; expand only after measurable gap. |

## 12. Deferred capability backlog — never construed as rejection

1. PostgreSQL, MySQL, FTP, FTPS, SMTP, SMB/UNC adapters, per-provider TLS/auth/downgrade, native lifetime and resource semantics.
2. Full central configuration service, API, push/poll fleet reconciliation, sophisticated incremental synchronization, migration and local profile conflict handling.
3. Production HSM/DPAPI/Key Vault or customer key management integration, device enrollment/attestation, production secret rotation and revoke propagation, forensic/audit delivery.
4. Emergency access lifecycle: issuance, separate offline grant, bounded scope, durable mandatory audit, deduplication, incident review.
5. Weighted/round-robin/least-active provider-aware routing, replica freshness, consistency enforcement, session affinity, wide-area failure alternatives.
6. Complete breaker policies, shared passive/active monitoring with authorization, half-open trials, long-lived state retention and stale-state handling.
7. Optional pool manager implementation, *conditional* on POC-001 native-versus-targeted-purge evidence; cross-provider management surface only where native providers permit.
8. Enterprise operations, configuration UX/CLI, broad performance/scalability testing, cross-process/fleet reliability, full OS/ARM/macOS qualification, packaging/release pipeline and production hardening.

## 13. Execution sequence and explicit owner gates

0. **Now — planning-only owner decision:** Approve/revise AD-34, AD-35, and this consolidated charter; confirm that acceptable offline security means *fail closed under defined trusted time/context assumptions*, not an impossible guarantee against a fully hostile device.
1. **Following separate engineering kickoff authorization:** Capture immutable decision/source baseline, pin provider versions, decide disposable infrastructure and threat model; define one issue/PR as appropriate to project's governance after repository strategy is authorized.
2. **A:** Implement smallest portable contract and compatibility harness; stop at a core/API incompatibility before deeper work.
3. **B:** Prove config, secret and offline authorization boundaries with negative cases; stop on any leakage/authorization weakness.
4. **C1:** Prove SQLite/SFTP distinct typed leases, disposal and trust validation.
5. **C2:** Perform real SQL Server restart sequence native-only on both supported runtimes; establish safe bounded reacquisition, no operation replay and failure isolation.
6. **C3:** Perform one narrowly scoped test-harness `ClearPool` comparison; decide whether AD-35 needs implementation.
7. Review outcomes, update requirements matrix, register required architectural changes, and seek **separate** authorization for the post-POC engineering backlog. No automatic merge/release/publication approval is conferred.

### Approval wording (suggested)

> I approve AD-34 and AD-35 as recommended and approve the consolidated POC-001 Architecture and Execution Charter for planning and later engineering kickoff preparation. I acknowledge the stated limits of offline authorization on untrusted customer-owned devices. This approval does not, by itself, authorize implementation, experiment execution, repository changes, infrastructure provisioning, merge, release or publication. Request separate authorization before beginning POC-001.

## 14. Primary documentation consulted

1. Microsoft, [.NET releases and support](https://learn.microsoft.com/en-us/dotnet/core/releases-and-support) and [Microsoft .NET lifecycle](https://learn.microsoft.com/en-us/lifecycle/products/microsoft-net-and-net-core).
2. Microsoft, [.NET Standard overview](https://learn.microsoft.com/en-us/dotnet/standard/net-standard); [Cross-platform library targeting](https://learn.microsoft.com/en-us/dotnet/standard/library-guidance/cross-platform-targeting); [NuGet package compatibility rules](https://learn.microsoft.com/en-us/dotnet/standard/library-guidance/nuget-package-compatibility-rules); [API compatibility tools](https://learn.microsoft.com/en-us/dotnet/fundamentals/apicompat/overview).
3. Microsoft Azure SDK, [.NET SDK design guidelines — target frameworks](https://azure.github.io/azure-sdk/dotnet_introduction.html).
4. Microsoft, [Microsoft.Data.SqlClient supported releases and TFMs](https://learn.microsoft.com/en-us/sql/connect/ado-net/download-microsoft-sqlclient-data-provider?view=sql-server-ver17); [SQL Server connection pooling](https://learn.microsoft.com/en-us/sql/connect/ado-net/sql-server-connection-pooling?view=sql-server-ver17); [ClearPool API](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection.clearpool?view=sqlclient-dotnet-7.1); [Connection options](https://learn.microsoft.com/en-us/sql/connect/ado-net/connection-options?view=sql-server-ver17); [Configurable retry](https://learn.microsoft.com/en-us/sql/connect/ado-net/configurable-retry-logic?view=sql-server-ver17).
5. Microsoft, [Microsoft.Data.Sqlite connection strings and pooling](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/connection-strings); [SQLite async limitations](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/async).
6. SSH.NET project, [supported frameworks and SFTP](https://github.com/sshnet/SSH.NET); [host-key verification examples](https://github.com/sshnet/SSH.NET/blob/develop/docfx/examples.md).
7. Microsoft, [Data Protection overview](https://learn.microsoft.com/en-us/aspnet/core/security/data-protection), [application secret architecture](https://learn.microsoft.com/en-us/azure/well-architected/security/application-secrets), and [Metrics Meter framework support](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.metrics.meter).

---

**Final recommendation:** Approve AD-34 and AD-35 with the qualifications above. Approve POC-001 as the smallest sufficient cross-boundary proof, retaining every broader experiment obligation as a future traceable requirement. Do **not** interpret this planning approval as permission to begin execution.