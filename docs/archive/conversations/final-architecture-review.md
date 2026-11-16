# Data Source Manager — Conversation Decision, Requirement and Scenario Extraction

**Scope:** This conversation's final architecture review, charter preparation, owner approval, and subsequent new-chat kickoff prompt.  
**Captured:** November 15, 2026, America/Los_Angeles.  
**Purpose:** Evidence-preserving handoff for consolidation into the Data Source Manager engineering record.  
**Method:** Extracted from the actual messages and the [consolidated charter](https://chatgpt.com/library?file_id=libfile_6ee44f7d106c8191b9bcd4bf2c8f1e6f&account_id=personal) created in this conversation. The charter is a **reconstructed synthesis**, not the original text of AD-001–033 or EXP-001–004.

## 1. Summary of provenance and approval

| Record | Status when introduced | Evidence of later status | Current status in *this* conversation |
|---|---|---|---|
| AD-001–AD-033 | Presented by Jim as previously approved in the opening request | Jim's opening request explicitly said "Architecture Decisions 1–33 established" and listed approved principles | **Inherited approvals affirmed**, but original individual records not present here |
| AD-034 Framework Compatibility | Architectural discovery/recommendation in opening request; formal decision proposed in review | Assistant presented AD-34 for approval; Jim replied **"I approve"** to the proposed decision package | **Approved by Jim in this conversation** |
| AD-035 Optional Connection-Pool Coordination | Specifically identified as recommendation pending formal approval | Assistant presented AD-35 Option C; Jim replied **"I approve"** to the proposed package | **Approved by Jim in this conversation** |
| POC-001 Secure Provider Acquisition and Recovery | Recommended, not authorized, when opening request was received; charter authored here | Jim replied **"I approve"** after the charter and final recommendation | **Charter and 21 proposed POC scenarios approved for planning**, not executed |
| EXP-001–EXP-004 | Previously approved experiment charters, explicitly unexecuted | Opening request and charter both acknowledge history; no new experiment execution authorization | **Planning records retained**, consolidated into POC-001 without deleting deferred obligations |

**Direct approval event in this conversation:** After the assistant presented AD-34, AD-35, and the complete POC-001 charter for formal disposition, Jim said: **"I approve"**. The immediate assistant acknowledgment explicitly recorded approvals for AD-34, AD-35, POC-001, and the security qualifications. This event is later than the charter's original `Proposed 1.0` header. The header is therefore a *pre-approval snapshot*, not evidence that the decisions remain unapproved.

**Authority distinction:** The approval did **not** authorize implementation, experiment execution, infrastructure provisioning, or repository modification. Jim subsequently requested a new-chat prompt. That prompt expressly authorized **engineering kickoff planning and preparation only**, while retaining the implementation gate. No new implementation authorization was granted in this conversation.

## 2. Decision register established in this conversation

### AD-034 — Framework Compatibility

| Field | Extracted record |
|---|---|
| **Problem** | The library must support actual .NET Framework 4.8 consumers, modern .NET consumers, compatible public contracts, and native provider dependencies without promising unsupported runtime combinations. |
| **Alternatives considered** | A single `netstandard2.0` asset; `netstandard2.0` plus modern runtime-specific target(s); extra dedicated `net48`/`net11.0` assets. The discussion did **not** establish formal lettered options or a complete alternatives scoring table. |
| **Selected approach** | Officially support .NET Framework 4.8/Windows and .NET 10 LTS/Windows+Linux for initially qualified capabilities. Validate .NET 11 compatibility before separately promoting official support. Treat .NET 8 as best-effort compatibility after end of Microsoft runtime support; make no official .NET 6 commitment. Baseline `netstandard2.0;net10.0` for reusable packages **where justified**; dependency-free projects without modern implementation needs may remain `netstandard2.0` only. Add `net48` or `net11.0` assets only when actual evidence requires them. |
| **Rationale** | .NET Standard 2.0 bridges .NET Framework and modern .NET; multi-targeting supports current runtime capabilities and dependencies. NuGet API validation and actual consumer testing must guard against API/semantic differences. Framework compilation alone does not prove supported OS, driver, TLS, authentication, or native dependency behavior. |
| **Non-negotiable semantics** | Public API, capability reporting, error categories, policy enforcement, acquisition, security, and lease disposal must behave compatibly across supported TFMs. Test actual legacy consuming projects, including binding redirects and dependency graph; modern consumers on Windows/Linux; .NET 11 smoke checks. Synchronous `IDisposable` is the portable minimum, with portable async disposal evaluated rather than assumed. |
| **Approval evidence** | Jim's **"I approve"** immediately following the full charter and assistant's proposed AD-34/AD-35 disposition. The assistant explicitly recorded AD-34 as approved in its acknowledgment. |
| **Related requirements** | Newly introduced REQ-18; also REQ-01, REQ-10, REQ-11. All `REQ-*` values in this record are **new charter traceability aliases**, not historical requirement identifiers. |
| **Related scenarios** | POC-SCN-04, POC-SCN-21; EXP-004 SCN-016–020 (summarized in §4). |
| **Revision/supersession** | AD-34 was a recommendation in the opening request, then approved unchanged in this conversation. No later architecture replacement appears in this conversation. Qualification remains empirical. |

### AD-035 — Optional Connection-Pool Coordination (Option C)

| Field | Extracted record |
|---|---|
| **Problem** | After a SQL Server restart, physical connections returned to native pools may become stale. Native detection/recovery exists but cannot guarantee every future checkout is healthy; the library must recover safely without app restart, cross-tenant disruption, or unbounded/unsafe retries. |
| **Alternatives considered** | Implement a second/custom physical connection pool; rely only on native pooling and expose no management; **Option C:** optional, capability-based coordination over native pooling. These are the substantive alternatives recorded; the complete original formal option texts are not present. |
| **Selected approach** | **Option C.** Keep provider-native physical pools. Expose optional, provider-supported configuration/policy controls, bounded acquisition, targeted pool invalidation, lease draining, credential-rotation coordination, health/utilization monitoring and structured redacted diagnostics. Do not invent management features for providers without native equivalents. |
| **Rationale** | Providers already own physical sockets, pool keys, failure detection and lifetime. A second pool adds state and retry complexity; a thin optional coordinator can address policy and lifecycle gaps if measurements justify it. |
| **Constraints** | A native SQL pool is not automatically scoped by the manager's tenant label. `ClearPool` must match actual pool identity and authorization; `ClearAllPools` is excluded from routine tenant/profile operations. Checked-out connections are not forcibly terminated by pool clearing. Cancellation does not guarantee termination of remote work. Never blindly replay uncertain SQL operations or use pool clearing as generic error handling. |
| **Approval evidence** | Jim originally wrote **"AD-35 remains a recommendation pending formal approval"**; after the recommendation and charter were presented, he said **"I approve"**. The assistant recorded AD-35 as approved. |
| **Related requirements** | REQ-12, REQ-13, REQ-14; REQ-07, REQ-16, REQ-19 where coordination and failure isolation intersect. |
| **Related scenarios** | POC-SCN-16, POC-SCN-18–20; EXP-003 SCN-006–011; EXP-004 SCN-011–015. |
| **Revision/supersession** | The **architecture** is approved. Implementing the optional coordinator is **deferred** until POC-SCN-20 compares native-only recovery and a *test-harness* scoped `ClearPool`. A result of no measurable value may justify further deferral or rejection of implementation; it does **not** automatically revoke AD-35's optional architecture. |

### POC-001 — Secure Provider Acquisition and Recovery (approved experiment charter, **not** an AD)

| Field | Extracted record |
|---|---|
| **Problem** | Four unexecuted experiment charters spanned too many providers and enterprise features to prove architecture efficiently, while the cross-cutting unknowns were public API portability, trust/configuration/offline authorization and SQL restart recovery. |
| **Alternatives** | Execute EXP-001–004 as separate full experiments; implement all provider adapters and centralized infrastructure first; consolidate into the smallest risk-driven vertical slice. No lettered alternative scoring was recorded. |
| **Selected approach** | Three workstreams: **A** portable API/contracts/admission; **B** configuration, credentials and offline authorization; **C** real SQLite/SFTP resources and narrow SQL Server native pool restart/recovery. Keep all wider original experiment obligations deferred and traceable. |
| **Rationale** | Direct evidence for high-risk cross-boundary assumptions with minimal duplicated provider capabilities and infrastructure. Native SqlClient pooling and targeted pool invalidation are researched first and compared experimentally only where behavior is uncertain. |
| **Approval** | Jim's **"I approve"** after presentation of the full 21-scenario charter. This approves the charter and its security qualifications, not implementation/execution. |
| **Requirements/scenarios** | Newly labeled REQ-01–REQ-20, POC-SCN-01–POC-SCN-21 (see §3 and §4); full original experiment obligations in §4. |
| **No supersession of EXP charters** | EXP-001–EXP-004 retain their broader approved obligations. POC-001 is the first prioritized proof, not a replacement for the ultimate product scope. |

## 3. Requirement register used in this conversation

**Crucial identifier warning:** The charter itself labels **REQ-01–REQ-20 as newly assigned planning aliases**. They are **not** the original project requirement numbers. They can be cross-referenced during consolidation but must not be mistaken for historical identifiers. `D-01`–`D-20` similarly denote future/deferred obligations created in the charter.

| New alias | Requirement distilled in the charter | POC evidence | Later responsibility |
|---|---|---|---|
| REQ-01 | Provider-neutral, SOLID, hexagonal core and explicit trusted ports | 01–03 | D-01 independent adapters/governance |
| REQ-02 | All nine provider families (SQL Server, PostgreSQL, MySQL, SQLite, FTP, FTPS, SFTP, SMTP, SMB/UNC) | 11,12,18 (three only) | D-02 remaining adapters |
| REQ-03 | Central and local configuration | 05–06 | D-03 central service and reconciliation |
| REQ-04 | Customer-owned and managed device trust | 08–09 | D-04 enrollment/attestation |
| REQ-05 | Authenticated, version-aware, ownership-safe config activation | 05,07 | D-05 full sync/migration |
| REQ-06 | Credential protection and secrecy | 08,12 | D-06 production vault/PKI |
| REQ-07 | Rotation and revocation | 09,13 | D-07 active-session/pool retirement coordination |
| REQ-08 | Strict offline authorization expiry and fail-closed rollback detection | 06,09 | D-08 trusted time/anti-rollback policy |
| REQ-09 | Emergency access and independent security auditing | 10 (audit boundary) | D-09 fully audited emergency flow |
| REQ-10 | Versioned capabilities and authorization | 03,11 | D-10 expanded provider capabilities |
| REQ-11 | Managed lease lifecycle and resource disposal | 11,13,14 | D-11 long-running operations |
| REQ-12 | Provider-native pooling | 13,18,20 | D-12 other provider pooling |
| REQ-13 | Optional native pool coordination (AD-35) | 20 *comparison only* | D-13 implementation if value proven |
| REQ-14 | Safe recovery and bounded retries | 15,16,18,19 | D-14 other providers' recovery |
| REQ-15 | Consistency-aware routing/failover | 15 (limited) | D-15 replicas/weights/affinity |
| REQ-16 | Failure-domain-aware circuit breakers | 15 (limited) | D-16 advanced breaker lifecycle |
| REQ-17 | Privacy-first metrics/traces and structured safe diagnostics | 08,17,21 | D-17 collectors and exporters |
| REQ-18 | Runtime/OS/provider compatibility | 04,21 | D-18 expanded matrix |
| REQ-19 | Honest cancellation and indeterminate operation outcomes | 13,19 | D-19 other provider operations |
| REQ-20 | Fail-closed security under faults and tenant boundaries | 07–10,12,15,19 | D-20 adversarial validation |

**Original product requirements from Jim's opening request, independent of the new aliases:** central/local configuration, managed/customer-owned devices, protected/rotatable/revocable credentials, strict offline authorization, controlled emergency access, provider-aware routing/failover, connection resilience/monitoring, privacy-first telemetry, and optional native pool coordination across the nine named provider families.

## 4. Acceptance scenario register

### 4.1 POC-001 acceptance scenarios newly established and approved in this conversation

The charter formatted the first as `POC-SCN-01` and shortened the same table's remaining row labels to `02`–`21`. Full `POC-SCN-*` prefixes below are normalized references to those 21 rows, **not additional scenarios**. Wording is condensed from the original charter, with critical conditions preserved.

| ID | Workstream | Required outcome / check |
|---|---|---|
| POC-SCN-01 | A | Core loads with no adapter dependencies; unregistered acquisition explicitly fails `UnsupportedProvider`; no implicit discovery. |
| POC-SCN-02 | A | Only explicitly trusted SQLite/SFTP/SQL test adapters register; duplicate/unknown/untrusted rejected; dependencies isolated. |
| POC-SCN-03 | A | Versioned capabilities queried without acquisition; distinguish `Unsupported`, `TemporarilyUnavailable`, `Unauthorized`; no critical security downgrade. |
| POC-SCN-04 | A | Real net48/Windows and net10/Windows+Linux consumers compile/load/operate/dispose with API/package semantic parity; net11 smoke. |
| POC-SCN-05 | B | Valid authenticated newer config activates atomically; bad signature, malformed, prohibited override, stale version, interrupted write preserve last-known-good. |
| POC-SCN-06 | B | During simulated central outage/restart, local profiles remain independent; managed profiles require still-valid separate authorization. |
| POC-SCN-07 | B | Cross-tenant/profile or lower-trust security-sensitive overrides cannot alter acquisitions or secrets. |
| POC-SCN-08 | B | Protected cache copied to other security context cannot reveal credential; lost context fails closed; no secrets or raw connection strings in diagnostics. |
| POC-SCN-09 | B | Expired, invalid, revoked, rollback-detected or unverifiable-time offline grant denies **new managed acquisitions** without implicit grace; record threat-model limits. |
| POC-SCN-10 | B | Separate audit port; failure of mandatory audit persistence denies action; no false success reported through telemetry. |
| POC-SCN-11 | A/C | One admission model yields SQLite-appropriate and SFTP-appropriate typed resources; missing operations report unavailable, not generic `DbConnection`. |
| POC-SCN-12 | C | Verify authentic SFTP host key and reject untrusted/mismatched key before trusted use; no transient retry on trust/auth failure. |
| POC-SCN-13 | C | Managed SQLite/SFTP/SQL leases dispose correctly in success/exception/cancellation/concurrency paths; zero tracked leases after all scopes; no false remote-cancellation claim. |
| POC-SCN-14 | C | Bounded admission queue and concurrency; excess requests fail by admission deadline without unbounded work; document native-provider cancellation limits. |
| POC-SCN-15 | C | Endpoint outage and tenant/auth failure remain separate failure domains; no global unhealthy classification from tenant-specific fault; no retries for policy/auth/TLS. |
| POC-SCN-16 | C | Maximum one manager-level transient **acquisition** retry after the first attempt, within caller deadline and native-provider policy; zero blind operation replays; count native attempts. |
| POC-SCN-17 | C | Safe low-cardinality .NET metrics/traces/events; observer/exporter failure does not block normal acquisition; audit separate. |
| POC-SCN-18 | C | Populate SQL native pool, restart SQL Server, reacquire from same process and perform new harmless read after server ready on net48 and net10; transient first failure allowed; record native recovery. |
| POC-SCN-19 | C | Interruption at SQL execution/commit reports indeterminate outcome when necessary; no manager/driver command-level retry or replay of uncertain operation. |
| POC-SCN-20 | C | Compare native-only SQL pool restart recovery with *test-harness* targeted `ClearPool`; record latency, failure rate, hard connects and collateral effects; **do not implement coordinator**. |
| POC-SCN-21 | A/B/C | Reproducible evidence matrix: versions, OS, auth/TLS, native dependencies, settings, safe logs, scenario pass/fail/limitations; explicitly mark untested cells. |

**POC completion criteria:** Evaluate all 21, pass mandatory security/compatibility/lifecycle/recovery gates, recover SQL without process restart on both official consumer runtimes, no uncertain replay, no critical/high unresolved security weakness or unbounded resource usage, record AD-35 value decision, and seek **separate** permission for any further engineering phase.

**Stopping conditions:** Secret leaks, invalid SFTP trust accepted, cross-tenant authorization breach, offline expiry bypass, unsafe SQL replay, false audit success, uncontrolled resource/retry growth, pool clearing beyond scope, or incompatible supported-framework security semantics.

### 4.2 Preexisting experiment scenarios *referenced* but not originally authored in this conversation

These preserve **earlier charter obligations summarized in the consolidated document**. They are not evidence of new approval by Jim here, and they must not be substituted for full original archived wording when separately available.

**EXP-001 — configuration, original scenario IDs unavailable:** (1) atomic valid revision activation; (2) interrupted update retains last-known-good; (3) restart/outage loads eligible cache; (4) local independence; (5) unauthorized override rejection; (6) stale/rollback revision rejection; (7) tenant/org isolation. **Do not assign speculative EXP-001 SCN identifiers.**

**EXP-002 — security, `SCN-01`–`SCN-12`:** 01 cache copied to other device cannot decrypt; 02 lost security context re-enrollment; 03 explicitly configured encrypted local recovery only; 04 offline grant expiry denies new access; 05 rollback/reboot/snapshot unverifiable fails closed; 06 credential rotation planned transition and old pool retirement; 07 urgent revocation denies new access, reports active limitations; 08 uncertain SQL commit without replay; 09 separate valid offline emergency grant; 10 emergency denied on audit persistence failure; 11 deduplicated repeated audit delivery; 12 customer-owned device denied central shared secret absent explicit trust mechanism.

**EXP-003 — routing/resilience/health/telemetry, `SCN-001`–`SCN-020`:** 001 native routing; 002 eligible priority failover; 003 round-robin/weighted/local least-active; 004 replica freshness; 005 affinity; 006 acquisition deadline/budget; 007 bounded retries; 008 nonretryable auth/TLS; 009 failure-domain breakers; 010 half-open recovery; 011 cancellation and unknown outcomes/no replay; 012 health signals; 013 no unsolicited customer probes; 014 authorized bounded probes; 015 stale shared health cannot globally block; 016 local operation without shared monitor; 017 .NET diagnostics; 018 privacy/cardinality; 019 exporter failure isolation; 020 independent audit.

**EXP-004 — API/adapters/lifecycle/compatibility, `SCN-001`–`SCN-020`:** 001 explicit acquisition; 002 typed resources; 003 capability query without connection; 004 non-bypass policy; 005 no silent critical downgrade; 006 install only needed adapters; 007 dependency isolation; 008 trusted explicit registration; 009 adapter-only upgrade; 010 explicit missing capabilities; 011 provider-specific cleanup/native pooling; 012 truthful lease accounting; 013 rotation/revocation lifecycle; 014 cancellation not remote termination; 015 concurrent acquisition/disposal; 016 Windows/Linux results; 017 unverified macOS labeled; 018 version constraints; 019 unsupported security fail closed; 020 supported/secure/license-appropriate dependencies.

## 5. Relationship to earlier architecture decisions (do not fabricate missing records)

The opening request established AD-001–033 as an approved **inherited baseline**, without supplying each decision's original title, considered options, or individual approval transcript. The conversation explicitly named these known associations:

| Earlier ID | Recoverable title / content | Historical approval evidence available here | Related proof |
|---|---|---|---|
| **AD-026** | Privacy-first .NET-native telemetry, low-cardinality and independent audit (from carried-forward project summary) | Earlier direct quote of Jim's approval appears in provided project conversation history, **not in this chat's direct messages** | REQ-17; POC-SCN-17 |
| **AD-027** | Failure-domain-aware local circuit-breaker isolation and bounded recovery | Earlier direct quote of Jim's approval appears in provided project conversation history, **not a new approval here** | REQ-15/16; POC-SCN-15 |
| **AD-028** | Capability-based managed leases, typed resources, explicit disposal, native pooling | Earlier direct quote of Jim's approval appears in provided project conversation history | REQ-11/19; POC-SCN-11/13/19 |
| **AD-029–AD-033** | Group summarized as versioned capabilities, trusted adapter registration, dependency-free core, structured redacted errors, and compatibility matrices | Opening request states whole AD-001–033 set approved; exact per-ID text and individual approval transcript **not recovered in this conversation** | REQ-01/10/17/18; POC-SCN-01–04/21 |
| **AD-001–AD-025** | General approved principles listed in opening request, without reliable individual-ID mapping | Opening request declares them approved; **no original per-decision record in this chat** | See requirements table; do not allocate made-up AD IDs |

**No full decision entries for AD-001–033 have been reconstructed here.** In particular, the source conversation does **not** provide all their original problem statements, alternatives, exact IDs/titles, or approval evidence. Retrieve earlier conversations/decision exports before registering these as canonical detailed ADRs.

## 6. Revisions, deferrals and unresolved assumptions

| Matter | Status at end of this conversation |
|---|---|
| AD-034 and AD-035 | Proposed in opening charter, formally approved by Jim after final review. No later supersession here. |
| POC-001 | Originally recommended, now approved **as a planning charter**. Its 21 criteria are new POC acceptance scenarios, not historical EXP criteria. |
| EXP-001–004 | Consolidated/prioritized, **not canceled**. Wider unexecuted scenarios deferred to implementation roadmap. |
| SQL Server restart | Newly made **mandatory POC gate**; native pooling may raise first error; eventual recovery without restarting application mandatory; no uncertain command replay. |
| Pool manager | Optional architecture approved but **implementation remains conditional** on comparative POC evidence. |
| .NET 11 and macOS | Compatibility/specific-OS qualification not yet a blanket official support commitment. |
| Offline authorization under hostile clock | Absolute tamper-proof offline expiry on a fully compromised device is not promised; fail closed when trusted time/state is missing or suspect. Threat-model limits need explicit engineering evidence. |
| Revocation while disconnected | Immediate global revocation cannot be guaranteed while device remains offline; grant expiry provides eventual bound within stated trust assumptions. |
| Retry budgets | A POC policy of initial acquisition plus at most one **manager** retry was proposed/approved in charter; native SqlClient internal attempts must be counted separately. Not a universal production SLA. |
| Dependency versions, package graph, performance | Real-world testing and pinned versions deferred to kickoff/execution; architecture research is **not** experimental proof. |
| Post-approval next-chat prompt | Authorized **kickoff planning** only. The prompt did not grant permission to implement or execute the POC. |

## 7. Consolidation instructions for the engineering conversation

1. Treat **AD-034, AD-035 and POC-001 as formally approved in this conversation**, with Jim's unqualified approval message applying to the recommendation bundle immediately preceding it.
2. Treat the charter's earlier `Proposed 1.0` status as superseded by the later conversational approval **without rewriting historical source evidence**.
3. Preserve the prefix distinction: `EXP-002 SCN-01` is **not** `EXP-003 SCN-001`, and `POC-SCN-01` is a new first-POC scenario. Maintain a namespace per experiment and POC.
4. Treat `REQ-01`–`REQ-20` and `D-01`–`D-20` as **derived planning aliases introduced here**, not canonical preexisting requirement IDs.
5. Obtain original AD-001–033 and EXP-001–004 archives from their own conversations for authoritative detailed alternatives, approval events, and original text. Do not infer individual IDs from thematic adjacency.
6. Keep POC execution and repository mutation separate from approval of this charter. Reconcile any subsequently approved engineering changes from the **later engineering-kickoff conversation** independently; this extraction's scope ends at the new-chat prompt.
7. When persisting to GitHub, retain both source-of-truth decision records and this provenance extraction, ideally with explicit origin/approval timestamps. **This extraction itself makes no GitHub changes.**

---

**Extraction confidence:** High for this conversation's AD-034/035 proposals, approval event, POC scope and the 21 new POC-SCN rows; medium for earlier EXP scenario wording summarized in this chat; intentionally incomplete for original AD-001–033 individual records and missing EXP-001 scenario identifiers. This document should accompany—not replace—the original historical transcripts when available.