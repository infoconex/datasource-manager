# Data Source Manager — Architectural Decision and Scenario Extraction

**Record purpose:** Transfer the architectural content established or discussed in this conversation into the current Data Source Manager engineering discussion for reconciliation.  
**Conversation coverage:** Data Source Manager architectural review, SQL Server pooled-connection recovery, legacy .NET consumers, optional pool coordination, POC planning, and new-chat handoff, through November 15, 2026 (Pacific time).  
**Nature of record:** Conversation extraction, **not** a newly approved architecture charter or an executed experiment.  
**Repository operations:** None performed as part of this extraction.

## 1. Evidence and approval conventions

This chat begins **after** most architectural decisions were made in a preceding conversation. Accordingly, the original decision texts and approval messages for AD-001–AD-033 are not all present here. The user expressly reported that those decisions were complete and listed their approved constraints. The project conversation context also quotes selected earlier approvals, but that material is distinguished below from approval given directly in this chat.

| Classification | Meaning |
|---|---|
| **Prior-approved, reported** | The user says it was approved before this conversation; verbatim original decision/approval may not be available here. |
| **Previously approved, quoted in project context** | Prior approval wording appears in the available project-conversation context; it was not issued afresh in this chat. |
| **Confirmed here** | The user directly accepted the material requirement in this chat. |
| **Recommended, not formally approved** | The assistant proposed it; neither a general “Continue” nor a request to consider it is treated as formal approval. |
| **Unresolved** | Requires a material product choice or missing source evidence. |

**Important:** No unverified alternatives, acceptance-scenario identifiers, vote history, or final technical configuration have been reconstructed as facts.

## 2. Approved architectural baseline carried into this chat

The opening user request states: “We have completed Architecture Decisions 1–33 and prepared EXP-001 through EXP-004 planning.” It then expressly identifies the following as **approved constraints**:

- SOLID and hexagonal architecture, with explicit interfaces.
- Dependency-free core and optional provider adapters.
- Capability-based managed leases and provider-native pooling.
- No Polly or third-party resilience framework in the core.
- Version-aware configuration synchronization.
- Trust-aware credential protection.
- Strict offline expiry and fail-closed security.
- Consistency-aware routing.
- Bounded retries.
- Failure-domain-aware circuit breakers.
- Privacy-first built-in .NET telemetry.
- Explicit trusted provider registration.
- Versioned capability contracts.
- Structured errors.

The product vision specified the following sources and deployment modes:

| Area | Stated scope |
|---|---|
| Data sources | SQL Server, PostgreSQL, MySQL, SQLite, FTP, FTPS, SFTP, SMTP, SMB/UNC. |
| Configuration | Centrally managed and local. |
| Devices | Managed and customer-owned. |
| Security | Credentials, rotation, offline authorization, controlled emergency access. |
| Operations | Routing, resilience, monitoring, and telemetry. |

No stable individual requirement IDs (such as `FR-###`) were assigned to these requirements **in this conversation**. The descriptions above must not be mistaken for new or superseding requirements.

## 3. Decision-by-decision extraction

### AD-001 through AD-025 — Prior-approved decisions, full texts unavailable

- **Decision IDs/titles:** User confirms Decisions 1–25 belong to the approved 1–33 set. Their individual titles and mappings are not established in the visible conversation.
- **Problems and alternatives:** Not recoverable from this chat without inventing details.
- **Selected approaches:** Only the cross-cutting approved baseline in §2 is available; it cannot be assigned reliably to individual IDs.
- **Approval status/evidence:** **Prior-approved, reported** by the user's opening statement that Decisions 1–33 were completed and approved constraints were carried forward.
- **Related requirements:** §2, pending reconciliation with the original decision inventory.
- **Related scenarios/revisions:** No individual scenario mapping or supersession established here.

### AD-026 — Privacy-first telemetry

- **Problem:** Instrument manager activity without exposing sensitive operational/security data or imposing a core third-party instrumentation dependency.
- **Alternatives considered:** An Option C was selected; the definitions of Options A and B are not present here.
- **Selected approach:** Policy-driven, privacy-first telemetry using built-in .NET instrumentation; safe default metrics, traces, and events; application-controlled collection and export; explicitly authorized richer diagnostics; low-cardinality attributes; independent security auditing.
- **Rationale:** Useful observability with minimal core dependency and privacy exposure.
- **Approval:** **Previously approved, quoted in project context.** Earlier user wording: “I approve Architecture Decision 26, Option C...” This conversation additionally treats privacy-first .NET telemetry as approved.
- **Related requirements:** Telemetry, audit separation, optional collection/export, low cardinality.
- **Related proposed POC scenarios:** POC-013. No original EXP-003 scenario identifiers are available here.
- **Revisions:** No superseding decision. Later analysis reinforced that telemetry cannot leak secrets, high-cardinality tenant identifiers, or private connection data.

### AD-027 — Failure-domain-aware circuit breakers

- **Problem:** Prevent a failure for one endpoint, tenant, or credential/security context from unnecessarily disabling healthy alternatives.
- **Alternatives considered:** Option C selected; A and B not described here.
- **Selected approach:** Local breakers that distinguish endpoint availability from tenant/profile/security-context failures; bounded half-open recovery; policy-respecting trial acquisitions; independent healthy alternatives; bounded state retention.
- **Rationale:** Contain failures at the correct boundary without cascading cross-tenant outages.
- **Approval:** **Previously approved, quoted in project context.** Earlier user wording: “I approve Architecture Decision 27, Option C...”
- **Related requirements:** Resilience, isolation, bounded recovery, no unauthorized health probes.
- **Related proposed POC scenarios:** POC-011, POC-012, POC-015; earlier EXP-003 scenarios remain unspecified here.
- **Revisions:** SQL Server restart discussion added a concrete test case; did not supersede the decision.

### AD-028 — Capability-based managed leases

- **Problem:** Offer consistent policy-controlled acquisition without falsely claiming all provider resources or operations are interchangeable or fully controllable.
- **Alternatives considered:** Option C selected; A and B not described here.
- **Selected approach:** Capability-based managed leases, provider-appropriate typed resources and operation scopes, explicit disposal, provider-native pooling, lifecycle tracking, and honest limitations on controlling exposed native operations.
- **Rationale:** Preserve native provider capabilities while keeping admission and ownership explicit.
- **Approval:** **Previously approved, quoted in project context.** Earlier user wording: “I approve Architecture Decision 28, Option C...”
- **Related requirements:** Explicit interfaces, provider-neutral acquisition, native typed resources, disposal and lifecycle.
- **Related proposed POC scenarios:** POC-001–003, POC-009–010, POC-020–021.
- **Revisions:** Optional pool coordination was later proposed **above** native pooling, not as a replacement.

### AD-029 through AD-033 — Reported prior approvals, limited attribution

The prior conversation summary describes the remaining Decision 29–33 topics as: versioned supported/available/authorized capabilities; trusted explicit adapter registration; dependency-free core with optional adapter packages; structured/redacted errors; and explicit framework/OS/provider compatibility with security fail-closed behavior.

**Caution:** This record does **not** certify the exact number-to-title pairing, original problem statements, option labels, alternatives, or approval quotes for AD-029–AD-033. Those details require the original decisions. The topics themselves are repeated as approved constraints in the opening message.

| Topic reported for the AD-029–AD-033 group | Requirement and reason | Proposed POC relation |
|---|---|---|
| Versioned capabilities | Distinguish provider support, environmental availability, and current authorization. | POC-003, POC-021. |
| Explicit trusted registration | Prevent centrally synchronized configuration from loading arbitrary executable adapters. | POC-002. |
| Optional adapter packages | Core should not depend on every provider driver or protocol library. | POC-001, POC-009. |
| Structured, redacted errors | Distinguish unsupported, unavailable, unauthorized, expired, cancelled, and uncertain failures without exposing secrets. | POC-003, POC-007–008, POC-012, POC-021. |
| Compatibility matrix | State framework, OS, provider, and security support explicitly; unsupported security configurations fail closed. | POC-014, POC-018. |

- **Approval status:** **Prior-approved, reported** as part of Decisions 1–33, not separately reapproved in this conversation.
- **Revision:** AD-034 was subsequently proposed to make .NET Framework 4.8 consumer support explicit. It does not replace the broader compatibility policy.

### AD-034 — Consumer framework compatibility (proposed identifier/title, requirement confirmed)

- **Problem:** A Data Source Manager library targeting only modern .NET could not be consumed by existing .NET Framework 4.8 enterprise applications; newer APIs may be unavailable on older targets.
- **Alternatives discussed:** Target only `net10.0`; use .NET Standard 2.0 portable contracts; or multi-target portable and runtime-specific assemblies. Exact package/TFM selection is **not settled**.
- **Selected product requirement:** Official support for .NET Framework 4.8 consumers.
- **Rationale:** Enterprise adoption without forcing a legacy application runtime upgrade, while keeping public acquisition semantics consistent.
- **Approval:** **Confirmed here.** Assistant asked directly: “Do you want .NET Framework 4.8 applications to be officially supported consumers of Data Source Manager?” User replied: “Yes, and we should consider offering a connect pool manager if wanted.” This confirms **.NET Framework 4.8 support**, not any particular multi-target implementation.
- **Additional recommendations (not separately approved):** .NET 10 LTS as primary modern target; .NET 11 where compatible; .NET 8 compatibility desirable but runtime out of support; no official .NET 6 support; use compatible provider-specific builds.
- **Related requirements:** Same public API semantics across supported runtimes; explicit compatibility matrix; fail-closed platform security behavior.
- **Related proposed POC scenarios:** POC-014, POC-018.
- **Revisions/supersession:** No approved exact TFM strategy or superseding decision. AD-034 is the **proposed** identifier assigned during this chat, not evidence of a formal decision-record merge.

### AD-035 — Optional provider-native pool coordination (proposed, not formally approved)

- **Problem:** Operators may want pooled-connection recovery, targeted invalidation, bounded admission, monitoring, and credential-rotation coordination beyond provider defaults, particularly after SQL Server restarts.
- **Alternatives actually discussed:**
  - **A:** Native provider pooling only, without additional coordination.
  - **B:** Build a new Data Source Manager physical connection pool.
  - **C:** Optional coordinator layered over provider-native pools.
- **Recommendation:** **Option C**. Keep native drivers responsible for physical pooling. Make coordination opt-in and capability-reported; do not introduce a third-party pooling framework into the core.
- **Rationale:** Offer operational control without duplicating established SqlClient/Npgsql/MySqlConnector mechanics or forcing extra infrastructure on default consumers.
- **User evidence/status:** **Exploration requested, no formal approval of Option C.** User wrote, “Yes, and we should consider offering a connect pool manager if wanted.” Later user wrote “Continue,” which does not constitute approval. Assistant repeatedly marked AD-035 as recommended/pending approval.
- **Related requirements:** Optional configuration, bounded admission, health and diagnostics, targeted clearing/draining, credential rotation, tenant/security-context isolation, no duplicate retry budgets.
- **Related proposed POC scenarios:** POC-015–017, POC-019–021.
- **Revisions/supersession:** Refinement of AD-028; explicitly **not** an authorization to replace provider-native physical pools. The actual public `IConnectionPoolManager` interface was only illustrated and **not approved**.

## 4. Established problems, findings, and unresolved security boundaries

| Item | Conversation finding or proposed clarification | Status |
|---|---|---|
| Offline expiry on customer-administered devices | A completely compromised device with administrative control over clock/storage cannot be assumed to enforce offline expiration or preserve an audit trail reliably. Trusted destination enforcement or an online broker may be necessary for stronger guarantees. | **Recommended threat-model clarification; not directly approved here.** |
| Emergency access | Previously approved constraint allows controlled emergency access; assistant proposed separately provisioned, time-bounded, managed-device-only use and audit boundaries. | **Prior-approved overall feature; detailed threat model not reapproved here.** |
| Configuration integrity | ETags/version-aware polling alone do not prove origin, authorization, or anti-rollback. Propose authenticated revisions, safe atomic activation, and last-known-good only while still authorized. | **Approved overarching sync policy; refinements recommended.** |
| Native operations | Manager controls admission and leases, but not necessarily every SQL command, file transfer, or remote operation a caller issues through native resources. | **Approved AD-028 boundary.** |
| Credential revocation | Deny new acquisitions when revocation is known; existing pooled/leased operations may continue until closed or explicitly terminated by destination/broker. | **Recommended clarification of prior security decisions.** |
| SQL Server restart | A pooled physical connection may become unusable while idle; the next acquisition/operation may discover it. Driver recovery and clearing improve behavior but do not eliminate all races. | **Observed by user, researched in this chat.** |
| Pool invalidation | Targeted native `ClearPool`/equivalent should be used only when justified; not on every generic error or as periodic maintenance. | **Recommendation.** |
| Retry safety | Native connection recovery is different from replaying SQL operations. Ambiguous writes/commits must not be blindly repeated. | **Approved no-blind-replay constraint, applied to SQL restart.** |
| Tenant/pool boundaries | Separate logical Data Source Manager profiles can map to the same driver pool if effective connection identity/configuration match. A pool clear may affect multiple logical consumers. | **New risk identified; isolation policy recommended, not formally approved.** |
| Active validation | `SELECT 1` before every checkout adds a round trip and still cannot guarantee a connection will stay alive. Passive/native recovery preferred; any active probe must be policy-authorized. | **Recommendation consistent with approved monitoring posture.** |
| Cross-framework provider support | Microsoft.Data.SqlClient current driver support includes .NET Framework 4.6.2+ and supported modern .NET; older runtimes may need different versions with support tradeoffs. | **Documented research, not a blanket promise for all providers.** |

## 5. EXP-001 through EXP-004 — status and preserved scope

The **user's opening statement** identifies EXP-001 as a planning baseline and EXP-002, EXP-003, and EXP-004 as approved, unexecuted charters. No experiment was executed in this conversation.

| Experiment | Previously established/planned work | State in this conversation | Consolidation recommendation |
|---|---|---|---|
| **EXP-001 — Configuration synchronization** | Version-aware polling, optional push refresh hints, atomic activation, interrupted-download safety, staleness/rollback recognition, centrally authoritative protected caches, separate local profiles, restricted non-security overrides, tenant separation. | Planning baseline; not executed. Full original acceptance inventory not visible. | Keep only integration-specific atomic activation and authorization tests in POC; rely on HTTP documentation for routine ETag behavior. |
| **EXP-002 — Credential and offline security** | Protection, offline authorization, rotation/revocation, emergency audit; device-copy rejection within supported trust assumptions; re-enrollment/recovery; expiry and clock rollback; no blind replay; audit durability; customer-owned restrictions. | Approved charter reported; unexecuted. Full scenario identifiers/count not visible here. | Include security-critical boundaries in POC; defer complete rotation, recovery, emergency workflows. |
| **EXP-003 — Routing/resilience/health/telemetry** | Four workstreams; **20 scenarios in prior approved charter** (identifiers/content not fully present); provider-native routing first, consistency-aware policies, bounded retry and breaker isolation, hybrid health, privacy-first telemetry. | Approved charter reported; unexecuted. | Native capabilities by documentation; POC tests restart recovery, isolation, bounded behavior and basic instrumentation. |
| **EXP-004 — API/adapters/lifecycle/compatibility** | Four workstreams; **20 scenarios in prior approved charter** (identifiers/content not fully present); public API, adapter dependencies and registration, lease/resource lifecycle, Windows/Linux/macOS/framework support. | Approved charter reported; unexecuted. | POC proves typed leases, two provider models, compatibility, lifecycle; broad adapter and OS matrix deferred. |

The proposed consolidation into POC workstreams does **not** cancel or replace approved charter content unless separately approved in the current engineering conversation.

## 6. POC-001 — Proposed charter evolution and acceptance scenarios

**POC-001 title proposed here:** Secure Provider Acquisition and Recovery.  
**Approval in this chat:** **Not explicitly granted.** The assistant proposed it and the user requested continued planning and a handoff prompt. Later engineering approval in a different conversation is outside this record's approval scope.

### 6.1 Scope evolution

1. Initial proposal: minimal vertical slice, real **SQLite** and **SFTP** adapters, synthetic/disposable configuration authority and credentials, no production control plane.
2. Following the user's SQL Server restart experience: add a **narrow real SQL Server recovery integration scenario**, not a full SQL Server production adapter.
3. Following the user's .NET 4.8 support confirmation: add actual **.NET Framework 4.8 consumer verification** alongside modern .NET.
4. Following optional pool-manager exploration: add comparison between native/default and opt-in coordinated recovery; keep any production coordinator out of the initial mandatory implementation unless justified by evidence.
5. Last consolidation proposal: **POC-A contracts/compatibility, POC-B security/configuration, POC-C real provider lifecycle/recovery**.

### 6.2 Proposed acceptance inventory (not approved in this chat)

The following IDs were explicitly introduced by the assistant. Their wording here is condensed, preserving their original purpose.

| ID | Proposed acceptance scenario |
|---|---|
| **POC-001** | Dependency-free core operates without provider packages. |
| **POC-002** | Only explicitly trusted, registered adapters can be selected. |
| **POC-003** | Supported, available, and authorized capabilities produce distinct outcomes. |
| **POC-004** | Valid configuration revision activates atomically; invalid/stale/interrupted revision does not displace still-authorized last-known-good state. |
| **POC-005** | Tenant boundaries and security-sensitive configuration ownership cannot be overridden. |
| **POC-006** | Expired offline authorization denies acquisition, without implicit grace. |
| **POC-007** | Detectable clock rollback/tampering fails closed. |
| **POC-008** | Platform-supported credentials are protected and absent from ordinary diagnostics. |
| **POC-009** | SQLite and SFTP are acquired via consistent manager entry point while retaining appropriate native types. |
| **POC-010** | Lease disposal, cancellation and concurrency respect documented resource bounds. |
| **POC-011** | Endpoint failure remains isolated from tenant-specific authorization failure. |
| **POC-012** | Retry budgets remain bounded; uncertain operations are not replayed blindly. |
| **POC-013** | .NET instrumentation stays low-cardinality and privacy-safe. |
| **POC-014** | Windows/Linux results identify supported and unsupported platform-security capabilities. |
| **POC-015** | SQL Server pooled connection returned idle, server restarted, then reacquisition/native recovery/pool invalidation observed; recover without app restart, maintain bounded retry and safe operation semantics. |
| **POC-016** | Verify native pooling and SQL Server restart recovery with optional pool coordinator disabled. |
| **POC-017** | With optional coordination enabled, target affected pool and recover without disrupting unrelated pools. |
| **POC-018** | .NET Framework 4.8 consumer uses approved public API and acquires SQL Server lease. |
| **POC-019** | Pool invalidation does not unintentionally disrupt unrelated tenant security contexts. |
| **POC-020** | Optional coordination adds neither a second physical pool nor duplicate retry loops. |
| **POC-021** | Provider-specific pool-management capability is discoverable and unsupported controls give structured errors. |

**Important numbering distinction:** These `POC-###` identifiers were assistant proposals in **this** conversation. They are **not** the previously approved EXP-002/003/004 acceptance-scenario IDs. Do not merge or renumber them silently during consolidation. POC-015–017 overlap conceptually and may be combined after a formal review without losing their test assertions.

### 6.3 Proposed POC exclusions

- Production control-plane service or administration UI.
- All nine provider adapters.
- Full vault, credential rotation, recovery and emergency-access implementation.
- Full weighted routing, least-active routing, or advanced active monitoring.
- Mandatory export/collection framework for telemetry.
- Real customer environments and credentials.
- Full macOS and unsupported framework/provider certification.
- A custom physical SQL Server connection pool.

### 6.4 Proposed completion criteria

- Equivalent approved public semantics from .NET Framework 4.8 and .NET 10 consumers.
- No core dependency on any provider driver.
- Correct authorization, configuration, capability detection and lifecycle behavior.
- SQL Server restart recovery without consumer process restart, within documented limits.
- Bounded retries/circuit breakers; uncertain operations not replayed.
- Explicit tenant/pool isolation and safe targeted invalidation.
- Privacy-safe instrumentation and reproducible real-provider integration evidence.
- Clearly documented unsupported platform/security behavior.

### 6.5 Proposed stopping conditions

- Mandatory security contract cannot be met on the intended platform.
- Framework target forces incompatible public semantics.
- Native typed resource semantics cannot be reconciled with the proposed public API.
- Pool coordination produces no value beyond native mechanisms or violates isolation.
- Unbounded retry/resource growth, unsafe operation replay, or unauthorized acquisition is observed.
- Validation would require production customer data/credentials or falsely claim uncompromisable offline endpoints.
- Additional experimentation only reproduces authoritative driver behavior without changing a decision.

## 7. Evidence-based research findings raised in the chat

The assistant researched official Microsoft and provider documentation. These references support technical **findings**, not project approval history:

- Microsoft SqlClient pooling, stale connection detection, and pool clearing: <https://learn.microsoft.com/en-us/sql/connect/ado-net/sql-server-connection-pooling>
- Microsoft SqlClient connection recovery options: <https://learn.microsoft.com/en-us/sql/connect/ado-net/connection-options>
- Microsoft SqlClient configurable retry logic: <https://learn.microsoft.com/en-us/sql/connect/ado-net/configurable-retry-logic>
- Microsoft SqlClient supported target frameworks: <https://learn.microsoft.com/en-us/sql/connect/ado-net/sqlclient-driver-support-lifecycle>
- .NET Standard library compatibility: <https://learn.microsoft.com/en-us/dotnet/standard/net-standard>
- Npgsql data sources and native pooling: <https://www.npgsql.org/doc/basic-usage.html>
- Npgsql failover and routing: <https://www.npgsql.org/doc/failover-and-load-balancing.html>
- Npgsql documentation on pooled connection liveness: <https://www.npgsql.org/doc/faq.html>
- MySqlConnector pooling options: <https://mysqlconnector.net/connection-options/>
- .NET telemetry APIs: <https://learn.microsoft.com/en-us/dotnet/core/diagnostics/observability-with-otel>
- Windows-only DPAPI behavior: <https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.protecteddata>
- .NET framework/runtime support lifecycle: <https://dotnet.microsoft.com/en-us/platform/support/policy>

No experiment was run to validate these behaviors for the intended Data Source Manager implementation.

## 8. Approval and reconciliation checklist for the current engineering conversation

1. Retrieve full approved AD-001–AD-033 texts, exact option definitions, original acceptance scenarios and approval comments; reconcile against §§2–3. Do not treat this extraction as their replacement.
2. Record **.NET Framework 4.8 support as user-confirmed**; verify exact portable/core/adapter TFMs before calling the technical implementation approved.
3. Present **AD-035 Option C** for formal approval or rejection. The user asked to *consider* a pool manager, not to approve the coordinator design.
4. Make explicit the trust model for fully customer-administrated offline devices and how strong expiry/security guarantees are enforced.
5. Resolve whether tenant boundaries require physical pool isolation, logical policy isolation, or a configurable combination; document impact on shared pool invalidation.
6. Map already-approved EXP charters and their exact scenario IDs to POC-001–021 without losing any approved requirement or silently changing identifiers.
7. Decide whether the SQL Server restart work belongs inside the first POC or as a separate tightly scoped evidence gate, preserving the smallest useful proof.
8. Confirm the final research-only vs executable scope and obtain explicit owner authorization before experiments, implementation, GitHub edits, publication, or release.

## 9. Final provenance statement

This record contains **one directly confirmed new product requirement** in this chat (.NET Framework 4.8 consumer support), **one actively explored but unapproved architectural option** (AD-035 Option C), several documented refinements to earlier approved decisions, and a **proposed** POC-001 acceptance inventory. Prior approvals of AD-001–AD-033 and EXP-001–EXP-004 are reported or quoted from earlier project context and are not re-created or independently certified here.

It is intentionally suitable for **consolidation and discrepancy review**, not for automatic implementation authorization.