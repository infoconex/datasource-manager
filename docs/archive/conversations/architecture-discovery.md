# Data Source Manager — Conversation Architecture Extraction

**Purpose:** Portable record of architectural decisions, requirements, acceptance scenarios, approval evidence, and gaps from this source conversation.  
**Source scope:** Only material visible in this conversation and its explicit carry-forward summaries. This is **not** an independent review of GitHub, other Data Source Manager conversations, or provider implementations.  
**Record date:** 2026-11-15 (America/Los_Angeles, the client-facing date).  
**Mutation status:** Extraction only. No GitHub modifications, code, or experiments.

## Evidence and interpretation rules

- **Direct explicit approval:** The user's message names the numbered decision and selected option.
- **Conversational assent:** The user agrees to a recommendation without naming the decision number; the assistant subsequently records it as approved. This is weaker than a direct explicit approval.
- **Blanket acceptance:** The user says, “I accept all your remaining recommendations.” It applies clearly to the then-visible recommendation for Decision 29. It authorizes the assistant to choose subsequent recommendations, but does not supply item-specific user approval text for decisions formulated afterward.
- **Assistant-selected under delegation:** The assistant subsequently selected Decisions 30–33 and described them as architectural recommendations accepted under the standing approval. They were **not individually presented to, or explicitly ratified by, the user** in this source conversation.
- **Carry-forward summary only:** A prior segment was summarized in conversation context, but the original user's approval and full alternatives are unavailable here. Record the reported decision without inventing missing details.
- **Unknown / unavailable:** The source does not contain enough information. A mention of an “Option C” does not establish the contents of Options A and B.

**Naming caution:** The subject labels below are editorial summaries, **not purported originally assigned ADR titles**. The original identifiers are “Architecture Decision 9,” etc., with sub-identifiers 7A, 7B, and 7C where reported. No `FR-` or `CAP-` requirement IDs were assigned in this visible source. Requirements below are narrative statements, not newly numbered requirements.

## Decision status index

| Original identifier | Subject (editorial) | Status in this source | Evidence |
|---|---|---|---|
| Architecture Decisions 1–3 | Not available | Unknown | Mentioned only by aggregate “1–33” statements; no individual detail |
| Architecture Decision 4, Option C | Offline policy | Reported as approved; direct evidence unavailable | Carry-forward summary |
| Architecture Decision 5, Option C | Identity | Reported as approved; direct evidence unavailable | Carry-forward summary |
| Architecture Decision 6, Option C | Connection authentication | Reported as approved; direct evidence unavailable | Carry-forward summary |
| Architecture Decision 7A, Option C | Routing ownership | Reported as approved; direct evidence unavailable | Carry-forward summary |
| Architecture Decision 7B, Option C | Supported topologies | Reported as approved; direct evidence unavailable | Carry-forward summary |
| Architecture Decision 7C, Option C | Managed connections | Reported as approved; direct evidence unavailable | Carry-forward summary |
| Architecture Decision 8, Option C | Layered API | Reported as approved; direct evidence unavailable | Carry-forward summary |
| Architecture Decisions 9–24, Option C | Configuration, trust, security, routing, resilience | **Direct explicit approvals** | Sixteen user messages reproduced below |
| Architecture Decision 25, revised Option C | Coordinated resilience, no Polly | **Conversational assent; assistant-recorded approval** | User “Agreed”; preceding exchange and later assistant statement |
| Architecture Decisions 26–28, Option C | Telemetry, breaker isolation, leases | **Direct explicit approvals** | Three user messages reproduced below |
| Architecture Decision 29, Option C | Capability contracts | **Blanket acceptance** | User “I accept all your remaining recommendations,” after Option C presented |
| Architecture Decisions 30–33 | Adapter registration, isolation, errors, compatibility | **Assistant-selected under delegation; not individually user-ratified** | Assistant's subsequent consolidated table |

## Individual decision records

### Architecture Decisions 1–3 — unavailable

- **Problem:** Not recoverable from this source.
- **Alternatives:** Not recoverable.
- **Selected approach / rationale:** Not recoverable.
- **Approval:** No individual approval text available. Later assistant messages referred generally to “Architecture Decisions 1–33,” but that does not establish these three decisions' contents or proof of approval.
- **Related requirements / scenarios:** Cannot be safely mapped.
- **Revisions / supersession:** Unknown.

### Architecture Decision 4, Option C — offline policy

- **Problem:** Regulating use of cached/offline configurations across different deployment trust levels.
- **Alternatives:** Details of Options A/B unavailable.
- **Selected approach:** Per-profile configurable offline policy constrained by organization policy, with conservative customer-owned defaults.
- **Rationale:** Permits necessary offline operation without bypassing centrally imposed limits (analytical summary).
- **Approval:** Reported as approved in the carry-forward summary, but the original user approval text is **not available** in this source.
- **Requirements / scenarios:** Offline policy constraints; relevant to EXP-002 offline-grant workstream. Individual EXP-002 acceptance-scenario mappings are unavailable.
- **Later refinement:** Decisions 14, 16, and 18 specify strict expiry, exceptional emergency access, and trusted time validation; they refine, not expressly supersede, Decision 4.

### Architecture Decision 5, Option C — identity

- **Problem:** Authorizing access for interactive users, services, or both.
- **Alternatives:** Unavailable.
- **Selected approach:** Policy-driven identity based on users, applications, or both, with organization/profile authorization.
- **Rationale:** Works across desktop and service deployments while preserving profile-level control (analytical summary).
- **Approval:** Reported approved in carry-forward summary; original approval quote unavailable.
- **Requirements / scenarios:** Identity authorization before acquisition or capability disclosure; EXP-004 SCN-004 and EXP-003 SCN-008 are later related tests, not original scenarios for Decision 5.
- **Later refinement:** Decisions 6, 9, 11, 14, 16, 29.

### Architecture Decision 6, Option C — connection authentication

- **Problem:** Supporting heterogeneous provider authentication without embedding one credential model in the core.
- **Alternatives:** Unavailable.
- **Selected approach:** Per-profile shared, user-specific, integrated, certificate, and passwordless connection authentication; authentication strategies and secret stores remain separate.
- **Rationale:** Provider-appropriate authentication with testable boundaries (analytical summary).
- **Approval:** Reported approved in carry-forward summary; original approval quote unavailable.
- **Requirements / scenarios:** Authentication strategy selection and authorization; EXP-003 SCN-008 and EXP-004 SCN-019 relate to secure failure handling. No earlier mapped acceptance IDs available.
- **Later refinement:** Decisions 11–13 address secret delivery, rotation, and cache portability.

### Architecture Decision 7A, Option C — routing ownership

- **Problem:** Dividing routing responsibility between database/provider facilities and the library.
- **Alternatives:** Unavailable.
- **Selected approach:** Hybrid routing, provider-native first; provider-neutral policy, library-managed selection only where appropriate.
- **Rationale:** Avoids duplicating established provider mechanisms (analytical summary).
- **Approval:** Reported approved in carry-forward summary; direct quote unavailable.
- **Requirements / scenarios:** EXP-003 SCN-001–003.
- **Later refinement:** Decisions 23 and 24 make algorithms and consistency constraints explicit.

### Architecture Decision 7B, Option C — supported topology

- **Problem:** Handling different data-source deployment topologies without premature sharding machinery.
- **Alternatives:** Unavailable.
- **Selected approach:** Extensible topology supporting standalone, active/passive, and primary/read-replica initially; provider-coordinated multi-primary where supported; independent databases/sharding deferred.
- **Rationale:** Captures common high-availability arrangements while deferring advanced strategies (analytical summary).
- **Approval:** Reported approved in carry-forward summary; direct quote unavailable.
- **Requirements / scenarios:** EXP-003 SCN-001–005.
- **Later refinement:** Decisions 23–24 restrict routing and consistency guarantees; no explicit supersession.

### Architecture Decision 7C, Option C — managed connections

- **Problem:** Whether to return managed connections or expose connection strings.
- **Alternatives:** Full earlier choices unavailable.
- **Selected approach:** Managed connections primary; raw connection string export only when explicitly authorized, with limitations disclosed.
- **Rationale:** Retains lifecycle, security, and policy control (analytical summary).
- **Approval:** Reported approved in carry-forward summary; direct quote unavailable.
- **Requirements / scenarios:** EXP-004 SCN-001–002 and SCN-011–015; raw export restrictions are not assigned a separate SCN in the visible EXP-004 charter.
- **Later refinement:** Decision 28 specifies managed leases, provider-appropriate resource access, and disposal.

### Architecture Decision 8, Option C — layered capability API

- **Problem:** Providing a usable cross-provider API without collapsing unlike protocols into a false common operation model.
- **Alternatives:** Unavailable.
- **Selected approach:** Layered, capability-based API; focused core with optional provider-specific operational extensions.
- **Rationale:** Preserves provider-specific functionality while keeping shared policy concerns central (analytical summary).
- **Approval:** Reported approved in carry-forward summary; direct quote unavailable.
- **Requirements / scenarios:** EXP-004 SCN-001–005, SCN-010.
- **Later refinement:** Decisions 28–29 specify leases and capability contracts.

### Architecture Decision 9, Option C — configuration ownership

- **Problem:** Ownership and local editability of centrally managed versus standalone profiles.
- **Alternatives:** Options A/B not preserved.
- **Selected approach:** Explicit configuration ownership: centrally managed profiles with protected read-only caches, standalone locally managed profiles, restricted non-security overrides.
- **Rationale:** Prevents local security-policy drift while allowing practical standalone use (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 9, Option C: explicit configuration ownership supporting centrally managed profiles with protected read-only caches, standalone locally managed profiles, and restricted non-security overrides.”
- **Requirements / scenarios:** Configuration authority and limited overrides; EXP-001 planning baseline. Exact EXP-001 SCN identifiers/text unavailable.
- **Later refinement:** Decision 10 provides synchronization and atomic activation; no supersession.

### Architecture Decision 10, Option C — configuration synchronization

- **Problem:** Keeping local configuration consistent through disconnections and updates.
- **Alternatives:** Options A/B unavailable.
- **Selected approach:** Version-aware polling as reliable sync; optional push notifications trigger refresh; atomic activation and offline reconciliation.
- **Rationale:** Polling is the dependable mechanism while push improves timeliness (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 10, Option C: version-aware polling as the reliable synchronization mechanism, with optional push notifications that trigger refresh, atomic configuration activation, and offline reconciliation.”
- **Requirements / scenarios:** Version monotonicity, atomic cache activation, reconciliation; EXP-001. Exact SCNs unavailable.
- **Later refinement:** Decision 12 requires secret-version refresh; no supersession.

### Architecture Decision 11, Option C — trust-aware credential delivery

- **Problem:** Secret distribution across managed versus customer-owned devices.
- **Alternatives:** Options A/B unavailable.
- **Selected approach:** Central secret stores, platform-protected caches, optional device-specific encryption, brokered/delegated customer-owned access; shared centrally managed credentials not sent to customer-owned devices by default.
- **Rationale:** Reduces secret exposure across trust boundaries (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 11, Option C: trust-aware credential delivery using central secret stores, platform-protected local caches, optional device-specific encryption, and brokered or delegated access for customer-owned systems. Shared centrally managed credentials must not be distributed to customer-owned devices by default.”
- **Requirements / scenarios:** EXP-002-A credential protection; individual EXP-002 SCN mapping unavailable.
- **Later refinement:** Decisions 12–13 handle rotation, binding, and recovery.

### Architecture Decision 12, Option C — credential rotation

- **Problem:** Coordinating credential changes without taking ownership of every destination's rotation process.
- **Alternatives:** Options A/B unavailable.
- **Selected approach:** External rotation default; optional provider-specific rotation; core version refresh, cache invalidation, pool transitions, offline expiration, and audit.
- **Rationale:** Fits established secret-management systems and preserves separation of responsibilities (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 12, Option C: external credential rotation by default, with optional provider-specific rotation capabilities. Core responsibilities include version refresh, cache invalidation, pool transitions, offline expiration, and auditing.”
- **Requirements / scenarios:** EXP-002-C rotation/revocation; EXP-004 SCN-013 later exercises lifecycle interactions.
- **Later refinement:** Decision 15 distinguishes planned rotation from security revocation.

### Architecture Decision 13, Option C — credential cache portability

- **Problem:** Whether credentials can be moved between devices or identities.
- **Alternatives:** Options A/B unavailable.
- **Selected approach:** Default caches bound to approved local security contexts; centrally managed credentials re-provision after enrollment; optional controlled encrypted recovery for locally managed profiles.
- **Rationale:** Prevents copying a cache from becoming credential portability (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 13, Option C: credential caches bound to approved local security contexts by default, centrally managed credentials re-provisioned after device enrollment, and optional controlled encrypted recovery for locally managed profiles.”
- **Requirements / scenarios:** EXP-002-A cache protection/recovery; exact related SCNs unavailable.
- **Later refinement:** Decision 19 adds OS-specific security capability requirements.

### Architecture Decision 14, Option C — normal offline expiry and emergency exception

- **Problem:** Offline authorization after its normal expiry and exceptional continuity needs.
- **Alternatives:** Options A/B unavailable.
- **Selected approach:** Strict normal authorization expiry; separately provisioned, optional, time-bounded, audited emergency access for eligible managed systems; no implicit grace; conservative customer-owned defaults.
- **Rationale:** Emergency access cannot silently extend ordinary authorization (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 14, Option C: strict normal offline authorization expiry with a separate, optional, explicitly provisioned, time-bounded and audited emergency-access capability for eligible managed systems. No implicit grace period; conservative customer-owned defaults.”
- **Requirements / scenarios:** EXP-002-B and EXP-002-D; exact SCN mappings unavailable.
- **Later refinement:** Decisions 16–18 define activation, audit durability, and trusted expiration validation.

### Architecture Decision 15, Option C — active connection lifecycle

- **Problem:** Handling active resources during rotation, revocation, and emergency expiration.
- **Alternatives:** Options A/B unavailable.
- **Selected approach:** Policy-driven lifecycle: graceful planned rotation, aggressive security revocation, strict emergency expiry, provider-aware pool handling, explicit reporting of termination limitations and uncertain operations.
- **Rationale:** Planned maintenance and security events require different interruption behavior (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 15, Option C: policy-driven connection lifecycle management, with graceful planned rotation, aggressive security revocation, strict emergency-access expiration, provider-aware pool handling, and explicit reporting of termination limitations and uncertain operations.”
- **Requirements / scenarios:** EXP-002-C; EXP-004 SCN-012–015.
- **Later refinement:** Decision 28 clarifies leased native resources cannot guarantee retrospective control over arbitrary in-flight operations.

### Architecture Decision 16, Option C — emergency activation

- **Problem:** Authorizing emergency access when normal authorization has expired or control plane is unavailable.
- **Alternatives:** Options A/B unavailable.
- **Selected approach:** Online authorization preferred; explicitly pre-authorized operator-activated offline access and separately approved service-specific automated modes on eligible managed devices; no automatic conversion of expired normal authorization; device binding, limits, expiry, audit; conservative customer-owned defaults.
- **Rationale:** Constrains exceptional authority to intentionally provisioned cases (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 16, Option C: policy-driven emergency activation, preferring online authorization, allowing explicitly pre-authorized operator-activated offline access and separately approved service-specific automated emergency modes on eligible managed systems. No automatic conversion of expired normal authorization, with device binding, limited scope, expiration and auditing. Conservative customer-owned defaults.”
- **Requirements / scenarios:** EXP-002-D; exact SCN mapping unavailable.
- **Later refinement:** Decisions 17–18 impose durable audit and time evidence.

### Architecture Decision 17, Option C — durable emergency audit

- **Problem:** Preventing emergency access without a reliable accountability record while offline.
- **Alternatives:** Options A/B unavailable.
- **Selected approach:** Protected, durable local recording of critical emergency events **before** access; fail closed if required persistence unavailable; idempotent online reconciliation; operational telemetry separately governed.
- **Rationale:** An emergency authorization must not outlive or bypass its audit evidence (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 17, Option C: require durable protected local recording of security-critical emergency-access events before granting access, fail closed when required persistence is unavailable, reconcile idempotently when online, and keep ordinary operational telemetry separately governed.”
- **Requirements / scenarios:** EXP-002-D; EXP-003 SCN-020 later tests audit/telemetry separation.
- **Later refinement:** Decision 26 retains independent telemetry and no collector dependence.

### Architecture Decision 18, Option C — offline time validation

- **Problem:** Trustworthiness of offline grant expiry when local time can be altered.
- **Alternatives:** Options A/B unavailable.
- **Selected approach:** Central/destination enforcement online; signed grants and validated protected time evidence on trusted managed devices offline; fail closed if time cannot be verified; customer-owned clocks untrusted.
- **Rationale:** Prevents clock tampering from extending offline authority (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 18, Option C: trust-aware offline expiration validation, preferring central or destination enforcement when online, evaluating signed grants and validated protected time evidence on trusted managed devices, failing closed when time cannot be verified, and treating customer-owned local clocks as untrusted.”
- **Requirements / scenarios:** EXP-002-B; exact SCN mapping unavailable.
- **Later refinement:** None explicitly superseding; Decision 19 makes support OS-capability dependent.

### Architecture Decision 19, Option C — operating-system security capabilities

- **Problem:** Preserving security requirements across Windows, Linux, and macOS differences.
- **Alternatives:** Options A/B unavailable.
- **Selected approach:** OS-neutral core, capability-based security adapters, representative Windows/Linux experiments first, macOS architectural target pending verification, fail closed when required capabilities unsupported.
- **Rationale:** Cross-platform API support must not imply equivalent platform security guarantees (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 19, Option C: an operating-system-neutral core with capability-based security adapters, representative Windows and Linux experiments first, macOS as a supported architectural target subject to verification, and explicit fail-closed handling for unsupported security requirements.”
- **Requirements / scenarios:** EXP-002-A/B cross-platform security; EXP-004 SCN-016–019.
- **Later refinement:** Decision 33 applies the same compatibility principle to protocol adapters.

### Architecture Decision 20, Option C — retry scope

- **Problem:** Which failures and operations Data Source Manager may retry without replaying side effects.
- **Alternatives:** Options A/B unavailable.
- **Selected approach:** Focused connection-acquisition retries; optional provider-aware operation-level resilience only for explicitly safe operations; no blind transaction/write/transfer/message replay; coordinate budgets and breakers.
- **Rationale:** Connection acquisition and business operations have materially different repeatability risk (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 20, Option C: a focused connection-management core with bounded connection-acquisition retries, plus optional provider-aware operation-level resilience only for explicitly safe operations. No blind transaction, write, transfer, or message replay; coordinate retry budgets and circuit breakers across layers.”
- **Requirements / scenarios:** EXP-003 SCN-006–011.
- **Later refinement:** Decision 25 specifies coordinated deadlines and no Polly; it does not expand unsafe retry scope.

### Architecture Decision 21, Option C — hybrid health monitoring

- **Problem:** Determining health without intrusive tests or conflating it with permission.
- **Alternatives:** Options A/B unavailable.
- **Selected approach:** Provider-native and passive signals by default; optional bounded active probes under org/profile policy; conservative customer-owned defaults; separate health, authorization, breaker states.
- **Rationale:** Controls monitoring overhead and respects ownership/trust boundaries (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 21, Option C: policy-driven hybrid health monitoring using provider-native and passive signals by default, optional bounded active probes under organization/profile policy, conservative customer-owned defaults, and separate health, authorization, and circuit-breaker states.”
- **Requirements / scenarios:** EXP-003 SCN-012–014.
- **Later refinement:** Decision 22 limits shared intelligence; Decision 27 scopes breakers.

### Architecture Decision 22, Option C — local versus shared health

- **Problem:** Avoiding global blocking based on stale or untrusted observations.
- **Alternatives:** Options A/B unavailable.
- **Selected approach:** Local health and breaker decisions by default; optional scoped shared advisory observations; no automatic global blocking from stale/untrusted data; authoritative endpoint restrictions only by configuration policy; local operation continues if monitoring unavailable.
- **Rationale:** A distant observation should not become an unreviewed enforcement decision (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 22, Option C: local health and circuit-breaker decisions by default, optional scoped shared health intelligence for aggregation and advisory use, no automatic global blocking from untrusted or stale observations, authoritative endpoint restrictions through configuration policy, and continued operation without shared monitoring.”
- **Requirements / scenarios:** EXP-003 SCN-015–016.
- **Later refinement:** Decision 27 defines failure-domain breaker isolation.

### Architecture Decision 23, Option C — routing algorithms

- **Problem:** How much endpoint selection belongs to library-managed routing.
- **Alternatives:** Options A/B unavailable.
- **Selected approach:** Extensible provider-neutral policies, provider-native first; initial library-managed priority failover, round-robin, weighted round-robin, and locally scoped least-active only where suitable; defer adaptive/sharding.
- **Rationale:** Addresses common routing needs without advanced balancing systems (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 23, Option C: extensible provider-neutral routing policies, provider-native selection first, and initial library-managed priority failover, round-robin, weighted round-robin, and locally scoped least-active selection only where appropriate. Defer advanced adaptive and sharding strategies.”
- **Requirements / scenarios:** EXP-003 SCN-001–003.
- **Later refinement:** Decision 24 constrains eligible destinations by consistency and authorization.

### Architecture Decision 24, Option C — consistency-aware routing

- **Problem:** Preventing a healthy but stale or wrong-role destination from silently satisfying a stronger caller request.
- **Alternatives:** Prior conversation summary describes A as eventual-consistency routing for all reads, B as profile-level primary-first, C as explicit policy-driven consistency; full original option text unavailable.
- **Selected approach:** Explicit acquisition intent; conservative primary-capable default; replica eligibility constrained by org/profile; verifiable freshness; session affinity; no silent downgrade.
- **Rationale:** Availability must not override required consistency (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 24, Option C: policy-driven consistency-aware routing with explicit connection intent, conservative primary-capable defaults, replica eligibility constrained by organization/profile policy, verifiable freshness requirements, session affinity, and no silent consistency downgrade.”
- **Requirements / scenarios:** EXP-003 SCN-002, SCN-004–005.
- **Later refinement:** Decision 25 requires retries to preserve these constraints.

### Architecture Decision 25, revised Option C — coordinated resilience, without Polly

- **Problem:** Preventing duplicate provider/library retries, cascading load, and missed timeouts while preserving a dependency-free core.
- **Alternatives actually presented:** **A** provider-managed retry/timeouts exclusively (consistent core API harder); **B** library-managed retry with configurable provider retries disabled (some provider behavior opaque); **C** coordinated hybrid with one bounded logical acquisition deadline, per-acquisition attempt cap, aggregate retry budget, jitter, transient classification, concurrency/breaker coordination, and conservative outer retries. After a user objection, the recommendation was **revised C** using standard .NET and provider-native mechanisms, with no Polly or other third-party resilience framework.
- **Selected approach:** Revised Option C; no broad operation replay; no unsafe consistency downgrade; no dependency on Polly. Optional provider drivers isolated from dependency-free core.
- **Rationale:** Bounded predictable resilience without building or importing a general-purpose resilience framework (analytical summary).
- **Approval evidence — weaker than direct numbered approval:** User said “I don’t want to take a dependency on a 3rd party library like Polly”; later asked “Is Polly a Microsoft library?”; after the assistant recommended the dependency-free approach, user replied **“Agreed.”** The next assistant message interpreted that as approval: “Architecture Decision 25 is approved in its revised form.” **No user message explicitly states “I approve Architecture Decision 25, Option C.”**
- **Requirements / scenarios:** EXP-003 SCN-006–011.
- **Revision:** **Material revision within Decision 25:** Polly and `Microsoft.Extensions.Resilience`-as-Polly-wrapper removed from the core recommendation. This is not a reversal of Decision 20.

### Architecture Decision 26, Option C — privacy-first telemetry

- **Problem:** Useful monitoring without secret exposure, unbounded dimensions, exporter coupling, or replacing security audit.
- **Alternatives actually presented:** **A** minimal failure/state diagnostics, application builds rest; **B** comprehensive detailed telemetry by default; **C** policy-driven privacy-first built-in .NET instrumentation, safe baseline and opt-in rich data.
- **Selected approach:** Built-in .NET metrics/traces/events, application-controlled collection/export, low-cardinality attributes, sensitive data excluded by default, independent mandatory security auditing, no third-party telemetry dependency in core.
- **Rationale:** Vendor-neutral enterprise observability with minimal disclosure and coupling (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 26, Option C: policy-driven privacy-first telemetry using built-in .NET instrumentation, safe default metrics/traces/events, application-controlled collection and export, explicitly authorized richer diagnostics, low-cardinality attributes, independent security auditing, and no third-party telemetry dependency in the core.”
- **Requirements / scenarios:** EXP-003 SCN-017–020.
- **Later refinement:** Reinforces Decision 17's separate audit journal; no supersession.

### Architecture Decision 27, Option C — circuit-breaker failure domains

- **Problem:** Preventing one tenant/profile/credential fault from disabling healthy endpoints or other callers.
- **Alternatives actually presented:** **A** profile-scoped breaker (can disable healthy endpoints in profile); **B** endpoint-scoped breaker (can mix tenant/auth failures); **C** failure-domain-aware isolation and bounded recovery.
- **Selected approach:** Local failure-domain-aware isolation by endpoint/profile/tenant/security context as appropriate; distinguish transient availability from auth/config failures; bounded half-open trials, policy-respecting acquisitions, independent healthy alternatives, bounded state retention.
- **Rationale:** Precise isolation without cross-tenant health poisoning (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 27, Option C: failure-domain-aware local circuit-breaker isolation, distinguishing endpoint availability from tenant/profile/security-context failures, bounded half-open recovery, policy-respecting trial acquisitions, independent healthy alternatives, and bounded state retention.”
- **Requirements / scenarios:** EXP-003 SCN-007, SCN-009–010, SCN-016.
- **Later refinement:** Refines Decisions 21, 22, and 25; no supersession.

### Architecture Decision 28, Option C — capability-based managed leases

- **Problem:** Whether the manager or consuming application owns native provider resources, and what lifecycle control is realistic.
- **Alternatives actually presented:** **A** return provider-native resources after validation; application owns disposal; **B** manager hides native resources and provides all operations, expanding into an ORM/file/messaging framework; **C** managed leases with typed provider resources and appropriate operation scopes.
- **Selected approach:** Policy-controlled acquisition; managed leases; typed resources, operation scopes, explicit disposal, provider-native pooling, lifecycle tracking, honest limitations on controlling native operations.
- **Rationale:** Balances strong acquisition policy and visibility with provider-native usability (analytical summary).
- **Approval — direct user quote:** “I approve Architecture Decision 28, Option C: capability-based managed leases with policy-controlled acquisition, provider-appropriate typed resources and operation scopes, explicit lease disposal, provider-native pooling, lifecycle tracking, and honest limitations on controlling exposed native operations.”
- **Requirements / scenarios:** EXP-004 SCN-001–002, SCN-011–015.
- **Later refinement:** Decision 29 specifies how available lease capabilities are described.

### Architecture Decision 29, Option C — layered provider capability contracts

- **Problem:** Determining capability support/availability/permission across unrelated protocols without late surprises or false universal interfaces.
- **Alternatives actually presented:** **A** attempt operation and discover support at runtime; **B** universal capability interface where unsupported methods throw; **C** explicit capability contracts distinguishing supported, available, and authorized.
- **Selected approach recommended:** Stable versioned interfaces, static capability validation where possible, authorized runtime verification where necessary, no unsolicited customer-owned probes, explicitly unknown state, fail-closed unverifiable required security/consistency, typed failure categories, optional adapter dependencies.
- **Rationale:** Early validation and accurate cross-provider capability behavior without fabricating uniform operations (analytical summary).
- **Approval evidence — blanket, not numbered:** Immediately after Option C was recommended, user said, **“I accept all your remaining recommendations.”** The assistant subsequently recorded “Decision 29, Option C is accepted.” There is **no individual “Decision 29, Option C” user approval sentence**.
- **Requirements / scenarios:** EXP-004 SCN-003–005, SCN-010, SCN-019.
- **Later refinement:** Decisions 30–33 were subsequently selected by assistant under the broad delegation; not independently ratified.

### Architecture Decision 30 — explicit adapter registration

- **Problem:** Activation of untrusted or unexpected provider assemblies.
- **Alternatives:** Not presented to user; no option letter in source.
- **Assistant-selected approach:** Explicit registration of trusted adapters; no automatic loading of arbitrary assemblies.
- **Rationale:** Controlled dependency and execution boundaries (analytical summary).
- **Approval:** Assistant-selected **after** user's broad “all remaining recommendations” delegation. **Not individually reviewed or expressly approved** in source.
- **Requirements / scenarios:** EXP-004 SCN-006, SCN-008.
- **Later revision:** None shown.

### Architecture Decision 31 — dependency isolation

- **Problem:** Avoiding optional provider packages becoming core/transitive requirements for all consumers.
- **Alternatives:** Not presented to user; no option letter.
- **Assistant-selected approach:** Dependency-free core; provider-specific drivers/dependencies only in optional adapter packages.
- **Rationale:** Minimizes compatibility and maintenance burden (analytical summary).
- **Approval:** Assistant-selected under blanket delegation; **not individually ratified**. Related principle was expressly discussed and user said “Agreed” earlier, but this numbered decision was formulated later.
- **Requirements / scenarios:** EXP-004 SCN-006–007, SCN-009, SCN-020.
- **Later revision:** No subsequent revision shown.

### Architecture Decision 32 — structured error contracts

- **Problem:** Distinguishing policy denial, unsupported capability, genuine unavailability, expiry, cancellation, and uncertain remote outcomes.
- **Alternatives:** Not presented to user; no option letter.
- **Assistant-selected approach:** Stable structured errors distinguishing unsupported, unavailable, unauthorized, expired, cancelled, uncertain; redact sensitive details.
- **Rationale:** Consumers need actionable categories without leaking secrets (analytical summary).
- **Approval:** Assistant-selected under blanket delegation; **not individually ratified**.
- **Requirements / scenarios:** EXP-004 SCN-005, SCN-010, SCN-014, and SCN-019 as relevant. The charter does not give this decision a unique dedicated scenario.
- **Later revision:** None shown.

### Architecture Decision 33 — compatibility matrices

- **Problem:** Avoiding false claims that all operating systems, target frameworks, and providers support identical features.
- **Alternatives:** Not presented to user; no option letter.
- **Assistant-selected approach:** Explicit framework/OS/provider capability matrices; unsupported security requirements fail closed.
- **Rationale:** Compatibility must be verified against provider and platform reality (analytical summary).
- **Approval:** Assistant-selected under blanket delegation; **not individually ratified**.
- **Requirements / scenarios:** EXP-004 SCN-016–020.
- **Later revision:** Extends, does not supersede, Decision 19.

## Requirements established in narrative form (no original FR/CAP IDs)

The following are **requirements inferred or directly stated in the approvals and charters**, collected without assigning new identifiers. Any final requirement IDs must be assigned by the consolidating engineering conversation, not silently treated as original IDs here.

| Requirement cluster | Source decisions | Meaning and constraints | Related scenario IDs where text exists |
|---|---|---|---|
| Configuration ownership | 9–10 | Central authority/read-only protected caches versus standalone local profiles; limited nonsecurity overrides; version-aware polling, optional push refresh, atomic activation, offline reconciliation | EXP-001: IDs unavailable |
| Identity and access | 5–6, 11, 14, 16, 29 | User/app/both identity, profile authorization, provider-specific auth, no privilege by fallback or discovery | EXP-003 SCN-008; EXP-004 SCN-004–005 |
| Credential trust and lifecycle | 11–13, 15, 19 | Secret-store delivery, protect/bind local caches, no shared central credentials on customer-owned by default; external rotation and local invalidation; OS capability checks | EXP-002: individual IDs unavailable; EXP-004 SCN-013, SCN-019 |
| Normal offline and emergency authorization | 4, 14, 16–18 | Strict normal expiry; pre-provisioned bounded emergency path only where eligible; durable pre-access audit; verified time and fail-closed gaps | EXP-002: individual IDs unavailable; EXP-003 SCN-020 |
| Managed resource acquisition | 7C, 8, 15, 28 | Managed leases, typed provider resources and operation scopes, lifecycle/disposal, provider-native pooling; no unconditional guarantee about in-flight termination | EXP-004 SCN-001–002, SCN-011–015 |
| Topology, routing and consistency | 7A–7B, 23–24 | Provider-native first, limited library routing algorithms, primary-capable defaults, policy-gated replicas, freshness and session affinity; no silent downgrade | EXP-003 SCN-001–005 |
| Retry and circuit-breaker safety | 20, 25, 27 | Connection-acquisition bounded retries, aggregate budgets, safe-operation exception only, no blind replay, isolated breakers and recovery, no Polly core dependency | EXP-003 SCN-006–011 |
| Health and shared intelligence | 21–22 | Passive/provider-native default, opt-in bounded probes, separated health/auth/breaker, local decisions, advisory shared observations | EXP-003 SCN-012–016 |
| Privacy and audit | 17, 26 | No secret leakage in telemetry; application-owned export, low cardinality, durable critical audit independent of telemetry | EXP-003 SCN-017–020 |
| Adapter extensibility | 8, 19, 28–33 | Capability-based contracts, optional isolated drivers, explicit adapter registration, stable redacted errors, verified OS/framework/provider support | EXP-004 SCN-001–010, SCN-016–020 |

### Provider and deployment scope stated during discovery

- Data sources: SQL Server, PostgreSQL, MySQL, SQLite, FTP, FTPS, SFTP, SMTP, SMB/UNC.
- Deployment modes: centrally managed and standalone locally managed configurations; trusted managed and customer-owned machines; interactive applications and service workloads.
- Cross-platform direction: OS-neutral core, representative Windows and Linux verification, macOS target pending proof, security guarantees fail closed if missing.
- Technical preference: Microsoft guidance first, SOLID/hexagonal interfaces, provider-native connection pooling/routing where supported, minimal core dependencies; third-party provider drivers may be isolated in adapters, but **no Polly or general-purpose third-party resilience/telemetry framework in the core**.
- The scope does **not** authorize a general-purpose ORM, mail client, FTP client, generalized resilience platform, global routing authority, advanced adaptive balancing, or sharding implementation.

## EXP-001 — configuration synchronization planning baseline

- **Status visible here:** Planning baseline; no full charter or independently verified scenario list supplied.
- **Related approvals:** Decisions 9–10.
- **Known conceptual themes:** Central/local profile ownership, protected cache, version-aware polling, optional push-triggered refresh, atomic configuration activation, offline reconciliation.
- **Acceptance identifiers and exact texts:** Not available. **Do not invent them.**
- **Execution:** Nothing executed in this source conversation.

## EXP-002 — credential, offline security and emergency access

- **Status:** Charter explicitly approved by user, **kept unexecuted**.
- **Direct user evidence:** “I approve the consolidated EXP-002 experiment charter, including its four workstreams, acceptance scenarios, research-first approach, stopping conditions, and exclusions. Keep EXP-002 unexecuted. Continue architectural discovery with EXP-003: routing, resilience, monitoring, and telemetry. Do not begin implementation.”
- **Four workstreams from carry-forward summary:**
  - `EXP-002-A`: Credential/cache protection on Windows and Linux; DPAPI vs service protection vs per-device envelope/re-enrollment and recovery.
  - `EXP-002-B`: Offline grant signatures, protected time, reboot/rollback/snapshot behavior.
  - `EXP-002-C`: Planned rotation/revocation, pool transitions, in-flight sessions/transaction outcome uncertainty, with representative SqlClient/Npgsql behavior.
  - `EXP-002-D`: Offline emergency grants and durable protected audit journals/transactional outbox, fail-closed persistence, idempotent reconciliation.
- **Scenario identifiers:** A carry-forward summary reported **12 acceptance scenarios, `SCN-01` through `SCN-12`**. The complete texts and per-workstream mapping are **not present** in the recoverable conversation. Do not reconstruct them as if quoted.
- **Research and stop conditions:** Research established guidance first; experiment only to resolve uncertainty; explicit stop on unavailable security evidence/unsafe assumptions; no implementation.

## EXP-003 — routing, resilience, health monitoring, telemetry

- **Status:** Consolidated charter **explicitly approved**, **unexecuted**.
- **Direct user evidence:** “I approve the consolidated EXP-003 experiment charter, including its four workstreams, 20 acceptance scenarios, research-first approach, evidence requirements, stopping conditions, completion criteria, and exclusions. Keep EXP-003 unexecuted. Continue architectural discovery with EXP-004. Do not begin implementation.”
- **Workstreams:** `EXP-003-A` Routing/consistency; `EXP-003-B` resilience/failure isolation; `EXP-003-C` health monitoring; `EXP-003-D` monitoring/telemetry.
- **Scenario identifiers and original charter wording:**

| ID | Acceptance scenario |
|---|---|
| SCN-001 | Provider-native routing is preferred when it satisfies the requested policy. |
| SCN-002 | Priority failover selects only eligible endpoints. |
| SCN-003 | Round-robin, weighted round-robin, and local least-active policies behave predictably where supported. |
| SCN-004 | Read replicas cannot be selected when consistency or freshness requirements are unmet or unverifiable. |
| SCN-005 | Existing sessions and transactions retain required endpoint affinity. |
| SCN-006 | Acquisition attempts and delays remain within applicable deadlines and budgets. |
| SCN-007 | Concurrent failures cannot cause uncontrolled aggregate retries. |
| SCN-008 | Authentication, authorization, and TLS policy failures do not trigger inappropriate retries or failover. |
| SCN-009 | Circuit-breaker failures remain isolated to the appropriate failure domain. |
| SCN-010 | Half-open recovery allows bounded, policy-compliant trials. |
| SCN-011 | Cancellation limitations and uncertain outcomes are reported; no unsafe operation replay occurs. |
| SCN-012 | Provider-native and passive health signals are interpreted without conflating authorization failures with endpoint unavailability. |
| SCN-013 | Customer-owned deployments do not perform unsolicited active probes. |
| SCN-014 | Authorized active probes respect configured limits and destination restrictions. |
| SCN-015 | Stale or untrusted shared health observations cannot impose global blocking. |
| SCN-016 | Local routing and monitoring continue when shared monitoring is unavailable. |
| SCN-017 | Standard .NET instrumentation exposes useful routing, acquisition, retry, and health diagnostics. |
| SCN-018 | Default telemetry excludes secrets, customer payloads, and sensitive identifiers and controls cardinality. |
| SCN-019 | Missing or failing telemetry exporters do not interrupt normal connection operations. |
| SCN-020 | Mandatory security auditing remains independent of operational telemetry. |

**Evidence requirements in original charter:** research records with source/version/applicability; provider-capability matrix; scenario results (verified/documented/inconclusive/unsupported); failure analysis; telemetry/privacy assessment; architectural recommendations. Representative Windows/Linux, SQL Server and PostgreSQL where needed, synthetic deterministic tests first. Real infrastructure limitations cannot be marked as passes.

**Stopping conditions/exclusions:** Stop when docs resolve question, infrastructure unavailable, unsafe real/customer interaction required, provider cannot enforce guarantees, or outcome uncertain. Excludes production components, general resilience framework/Polly, sharding/adaptive routing, blind operation replay, global authoritative health, unrestricted probes, telemetry servers/dashboards, reimplemented pooling, and execution of EXP-002.

## EXP-004 — public API, provider adapters, resource lifecycle, compatibility

- **Status:** Assistant consolidated a 4-workstream, 20-scenario **planning charter after** the user's blanket acceptance of remaining recommendations. **No separate user message explicitly approves that finalized charter.** It was not executed.
- **Workstreams:** `EXP-004-A` Public API; `EXP-004-B` provider adapters; `EXP-004-C` resource lifecycle; `EXP-004-D` compatibility.
- **Scenario identifiers and original charter wording:**

| ID | Acceptance scenario |
|---|---|
| SCN-001 | Applications acquire resources through explicit, testable interfaces. |
| SCN-002 | Provider-native resources retain their useful type-specific behavior. |
| SCN-003 | Unsupported capabilities can be identified without unnecessary connections. |
| SCN-004 | Policy restrictions cannot be bypassed through capability discovery. |
| SCN-005 | Unknown security or consistency guarantees do not silently degrade. |
| SCN-006 | An application can install only the adapters it needs. |
| SCN-007 | Provider dependencies do not become dependencies of the core. |
| SCN-008 | Unregistered or untrusted adapters cannot be activated implicitly. |
| SCN-009 | Provider-specific upgrades do not require unrelated core API changes. |
| SCN-010 | Missing provider capabilities produce explicit, actionable failures. |
| SCN-011 | Lease disposal correctly delegates to provider-specific cleanup or pooling. |
| SCN-012 | Active leases are accounted for without claiming control over arbitrary native operations. |
| SCN-013 | Planned credential rotation and security revocation follow Decision 15. |
| SCN-014 | Cancellation does not incorrectly imply the remote operation was terminated. |
| SCN-015 | Concurrent acquisition and disposal do not compromise lifecycle state. |
| SCN-016 | Representative Windows and Linux capabilities have documented results. |
| SCN-017 | macOS support assumptions are explicitly identified for later verification. |
| SCN-018 | Provider and framework version limitations are documented. |
| SCN-019 | Unsupported platform security requirements fail closed. |
| SCN-020 | Provider selection includes dependency health, licensing, security maintenance, and support considerations. |

**Research-first plan:** Consult .NET/provider documentation; remove redundant experiments; test controlled contracts; run representative integrations only where gaps matter; record versions, observed limits, cancellation uncertainty. No general ORM/FTP/mail/resilience framework, untrusted dynamic plugin loader, replacement pooling, unsupported fallbacks, or customer-system experiments.

## Inter-experiment trace and cross-cutting requirements

| Topic | Primary experiment(s) | Dependencies / caution |
|---|---|---|
| Profile ownership, cache versions, atomic sync | EXP-001 | Core config and policy baseline for all other workstreams |
| Secret protection, offline grants, emergency access | EXP-002 | Decisions 11–19; critical audit must not be replaced by EXP-003 telemetry |
| Routing, failover, consistency, retry budgets | EXP-003 | Decisions 20, 23–25, 27; acquisition rules depend on configuration and authorization |
| Health, shared intelligence, telemetry | EXP-003 | Decisions 21–22, 26; local health advisory is not authority |
| Managed leases and provider capabilities | EXP-004 | Decisions 7C, 8, 28–33; native APIs may limit revocation guarantees |
| Cross-platform support and dependency inventory | EXP-002 / EXP-004 | Security required capabilities must be verified on target OS/framework, not inferred |

## Explicit unresolved and provenance gaps for consolidation

1. **Architecture Decisions 1–3:** No individual texts or approvals in this source.
2. **Architecture Decisions 4–8 (including 7A–7C):** The carry-forward summary reports the selected approaches, but the complete original alternatives and approval texts are absent.
3. **Architecture Decisions 9–23:** Direct C approvals exist, but Options A/B were not reproduced here; do not invent their wording. Decision 24's A/B options are available only as a short carry-forward summary.
4. **Architecture Decision 25:** Conversational “Agreed” and assistant interpretation support the revised recommendation, but there is no direct numbered approval quote. The no-Polly revision is material.
5. **Architecture Decision 29:** Blanket approval applies to the then-visible Option C recommendation, but no individual numbered assent exists.
6. **Architecture Decisions 30–33:** They were drafted and selected by the assistant **after** the blanket acceptance; distinguish authorized automatic selection from express item-specific user ratification.
7. **EXP-002:** The 12 scenario identifiers are reported but the exact scenario statements are missing. Retrieve the original charter from the original conversation or other approved source before treating them as authoritative text.
8. **EXP-001:** No complete charter or scenario identifiers available here.
9. **EXP-004:** Its 20 scenario texts are visible, but no separate user approval of the finalized charter is available.
10. **Requirements governance:** There are no source-assigned `FR-`/`CAP-` identifiers. The narrative requirements table is traceability preparation, not a substitute for formal requirements.
11. **Verification status:** These records are primarily architectural approvals and **experiment plans**, not experimentally validated behaviors. Do not infer that the experiments were executed.
12. **Later conversations:** A different project chat may have evolved POC planning, repository creation, or approvals. This extraction intentionally does not merge those later records or claim what GitHub currently contains.

## Suggested import note for the current engineering conversation

> Treat this file as a **source-conversation extraction**. Preserve decision numbers, option selections, explicit approval quotes, EXP-003 and EXP-004 SCN identifiers, and the evidence categories. Reconcile with any other Data Source Manager conversation/repository records before declaring the canonical ADR and requirement set. Do not fabricate missing early decision content, EXP-002 acceptance text, or item-specific approvals for Decisions 30–33. This handoff grants no authority to modify GitHub or implement code.