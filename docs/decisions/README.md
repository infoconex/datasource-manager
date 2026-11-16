# Architecture decision register

**Record date:** November 15, 2026 (Pacific time)  
**Source:** [architecture-discovery extraction](../archive/conversations/architecture-discovery.md), [SQL recovery and compatibility extraction](../archive/conversations/recovery-and-compatibility.md), [final architecture review extraction](../archive/conversations/final-architecture-review.md), and the two [approved planning charters](../archive/charters/architecture-and-poc-execution-charter.md).  
**Current disposition:** Jim affirmed the AD-001–AD-035 architectural baseline and approved POC-001 planning. **AD-002 has now been prospectively confirmed as refined Option A on November 15, 2026**, without claiming the original individual vote was recovered. Other historical approval classes remain distinct. No experiment or POC scenario has run.

## Provenance rules

1. This is a **reconciled index**, not invented verbatim ADRs. The three conversation files and two charters under `docs/archive/` are preserved unchanged as source evidence. Their original statuses reflect when they were written.
2. An **inherited approval** means Jim explicitly carried forward the prior approved decision set; it does not establish a missing individual transcript. **Direct numbered approval** means the source conversation extraction quotes the user's numbered approval. **Conversational assent**, **blanket acceptance**, and **assistant-selected under delegation** are separate evidence strengths.
3. The three subsequent [conversation-specific reviews](../archive/reviews/) recover earlier evidence for AD-001 and AD-003, the *original proposal but not its individual historical vote* for AD-002, and directly selected options/approvals for AD-004–AD-008 (including AD-007A/B/C). The reviews are **retrospective evidence**, not retroactively authored original ADRs. See the [decision evidence and qualification index](decision-evidence.md) for precise provenance and remaining gaps.
4. AD-034, AD-035, and all 21 POC scenarios were first written in a charter labeled **proposed**. Jim's **later explicit approval** governs their current status; we preserve the historical proposed header unchanged. The [final-review extraction](../archive/conversations/final-architecture-review.md) documents that approval transition. This approval alone did not authorize executing experiments.
5. `REQ-01` through `REQ-20` and `D-01` through `D-20` are **new traceability aliases** introduced in the consolidated charter, not recovered original requirement IDs.
6. The recovered decision/topic names below are *editorial labels* drawn from conversation and review evidence, not asserted historical titles. No unsupported option wording or approval is manufactured. Historical `EXP-*` status and draft POC numbering are distinguished in the [experiment trace](../requirements/experiment-traceability.md).

## Decision inventory

**Canonical record:** Each decision below has its own file; this table is **navigation and evidence classification only**, not a substitute for the decision's context, alternatives, rationale, consequences and approval history. AD-007A/B/C are three independently numbered subdecisions; there is no invented standalone AD-007 choice.

All IDs below are currently in the **approved architectural baseline**. The evidence column distinguishes how each individual decision was originally recorded.

| ID | Recovered subject (editorial) | Individual approval/source evidence |
| --- | --- | --- |
| [AD-001](AD-001-desktop-and-server-applications.md) | Desktop **and** server application scope | User-selected alternative A; assistant explicitly recorded Decision 1 approved |
| [AD-002](AD-002-configuration-and-credential-storage.md) | Pluggable configuration and credential storage, separate interfaces | **Refined Option A prospectively approved Nov 15, 2026**; original historical A/B/C vote remains unverified |
| [AD-003](AD-003-managed-and-customer-owned-devices.md) | Managed **and** customer-owned device trust tiers | Direct user requirement; assistant recorded Decision 3; numbered option vote not recovered |
| [AD-004](AD-004-offline-policy.md) | Per-profile offline policy constrained by organizational ceiling | Direct user Option C approval; assistant linked to Decision 4 |
| [AD-005](AD-005-identity-and-authorization.md) | User/application identity and authorization | Direct numbered Option C approval |
| [AD-006](AD-006-provider-authentication.md) | Per-profile provider authentication strategies, separate from credential stores | Direct numbered Option C approval |
| [AD-007A](AD-007A-routing-ownership.md) | Hybrid provider-native-first routing ownership | Direct numbered Option C approval |
| [AD-007B](AD-007B-topology-model.md) | Coordinated topologies first; multi-primary conditional; sharding deferred | Direct numbered Option C approval |
| [AD-007C](AD-007C-managed-connections.md) | Managed acquisition primary; **raw string export exceptional and authorized** | Direct numbered Option C approval; export outside POC-001 proof scope |
| [AD-008](AD-008-layered-capability-api.md) | Focused core with optional provider capabilities | Direct numbered Option C approval |
| [AD-009](AD-009-configuration-ownership.md) | Configuration ownership and overrides | Direct numbered Option C approval quoted |
| [AD-010](AD-010-configuration-synchronization.md) | Version-aware configuration synchronization | Direct numbered Option C approval quoted |
| [AD-011](AD-011-trust-aware-credential-delivery.md) | Trust-aware credential delivery | Direct numbered Option C approval quoted |
| [AD-012](AD-012-credential-rotation.md) | Credential rotation responsibilities | Direct numbered Option C approval quoted |
| [AD-013](AD-013-credential-cache-portability.md) | Security-context-bound credential caches | Direct numbered Option C approval quoted |
| [AD-014](AD-014-strict-offline-expiry.md) | Strict offline expiry and separate emergency grants | Direct numbered Option C approval quoted |
| [AD-015](AD-015-active-connection-lifecycle.md) | Active connection lifecycle during rotation/revocation | Direct numbered Option C approval quoted |
| [AD-016](AD-016-emergency-access-activation.md) | Emergency-access activation policy | Direct numbered Option C approval quoted |
| [AD-017](AD-017-durable-emergency-audit.md) | Durable pre-access emergency audit | Direct numbered Option C approval quoted |
| [AD-018](AD-018-offline-time-validation.md) | Trusted offline time validation | Direct numbered Option C approval quoted |
| [AD-019](AD-019-operating-system-security.md) | Operating-system security capability policy | Direct numbered Option C approval quoted |
| [AD-020](AD-020-retry-scope.md) | Bounded acquisition retry and no unsafe replay | Direct numbered Option C approval quoted |
| [AD-021](AD-021-health-monitoring.md) | Provider-native/passive health plus authorized probes | Direct numbered Option C approval quoted |
| [AD-022](AD-022-shared-health-intelligence.md) | Local versus shared health intelligence | Direct numbered Option C approval quoted |
| [AD-023](AD-023-routing-algorithms.md) | Provider-native-first routing algorithms | Direct numbered Option C approval quoted |
| [AD-024](AD-024-consistency-aware-routing.md) | Consistency-aware routing and no silent downgrade | Direct numbered Option C approval quoted |
| [AD-025](AD-025-dependency-free-resilience.md) | Coordinated resilience without Polly in core | Conversational assent after revision; later included in approved set |
| [AD-026](AD-026-privacy-first-telemetry.md) | Privacy-first .NET-native telemetry | Direct numbered Option C approval quoted |
| [AD-027](AD-027-failure-domain-circuit-breakers.md) | Failure-domain-aware circuit breakers | Direct numbered Option C approval quoted |
| [AD-028](AD-028-capability-based-managed-leases.md) | Capability-based managed typed leases | Direct numbered Option C approval quoted |
| [AD-029](AD-029-provider-capability-contracts.md) | Versioned capability support/availability/authorization | Blanket acceptance; not individually numbered |
| [AD-030](AD-030-trusted-adapter-registration.md) | Explicit trusted adapter registration | Assistant-selected under delegation; later included in approved set |
| [AD-031](AD-031-provider-dependency-isolation.md) | Optional provider dependency isolation | Assistant-selected under delegation; later included in approved set |
| [AD-032](AD-032-structured-error-contracts.md) | Structured redacted error contracts | Assistant-selected under delegation; later included in approved set |
| [AD-033](AD-033-compatibility-matrices.md) | Framework/OS/provider compatibility matrices | Assistant-selected under delegation; later included in approved set |
| [AD-034](AD-034-framework-compatibility.md) | .NET Framework 4.8 and .NET 10 framework policy | Formal approval after consolidated charter |
| [AD-035](AD-035-native-pool-coordination.md) | Optional coordination over provider-native pools | Formal approval after consolidated charter; implementation deferred |

**AD-002 disposition:** The [dated AD-002 record](AD-002-configuration-and-credential-storage.md) now approves refined **Option A**: independently pluggable configuration and credential storage, multiple stores/profiles, optional adapters, consumer-provided adapters, and **no mandatory SQLite dependency** in the core. This is a **new confirmation**, not a retroactive original vote, and it does not expand or execute POC-001.

**Subdecision preservation:** AD-007 contains three distinct, directly approved sub-identifiers **AD-007A**, **AD-007B**, and **AD-007C**. Their recovered alternatives and quotations are in [decision evidence](decision-evidence.md). **AD-007C raw connection-string export** is an explicitly authorized exceptional escape hatch; subsequent routing, lease tracking, revocation, and disposal cannot be guaranteed once a caller takes native control. This export path has **not** been validated or authorized for implementation by POC-001.

**Compatibility clarification:** AD-033 establishes matrix-based qualification; AD-034 adds explicit framework commitments, including supported `.NET Framework 4.8/Windows` and `.NET 10/Windows+Linux`, `.NET 11` qualification, `.NET 8` best effort, and no `.NET 6` support.

**Pooling clarification:** AD-035 permits optional capability-based coordination over *native* pooling. It does **not** authorize a new physical pool or implementing the coordinator in POC-001. The POC compares native recovery against a narrowly scoped `SqlConnection.ClearPool` test-harness intervention.

## Requirements and acceptance

- [Individual architecture decision index and records](README.md): all 37 decision files, including the [approved AD-002 prospective confirmation](AD-002-configuration-and-credential-storage.md).
- [Decision evidence: original AD-001–008 alternatives, approvals and later decision-specific source links](decision-evidence.md).
- [POC-001: exact 21 approved acceptance scenarios and traceability](../requirements/POC-001.md).
- [EXP-001–004 planning and cross-experiment traceability](../requirements/experiment-traceability.md).
- [Consolidated architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md) §§ 5, 7–12: approved scope, `REQ-01..20` aliases, `D-01..20` deferrals, historical EXP-001..004 summaries, security stopping rules.
- [POC-001 engineering kickoff](../archive/charters/poc-001-engineering-kickoff-charter.md) §§ 8–10: exact criteria, increment ownership, evidence, and I0–I6 sequence.
- None of `EXP-001` through `EXP-004` was executed. Their broader obligations remain deferred, not cancelled.

## Recording future decisions

1. Capture each new proposed decision in **its own file** under `docs/decisions/`, with unique ID, context/problem, alternatives actually considered, recommendation, consequences, requirement/scenario references, source links, and proposed status. Maintain a corresponding link in this index.
2. Record Jim's actual approval or rejection and date **without rewriting the earlier proposal**. Keep direct approval distinct from delegation or inference.
3. Add a supersession reference in *both* old and new decisions; never silently edit historical reasoning.
4. Link any resulting functional scenario to requirements, issue, test, evidence and verification status; use one issue and one PR per coherent increment.
5. Do not claim a scenario passed until real evidence exists. Changes to approved security guarantees, framework support or POC scope require explicit renewed owner approval.
6. Preserve and check the recovered early review evidence against primary transcripts if available, especially the missing **original historical AD-002 vote** (the current refined choice is approved), then amend this index through review. Unrecovered original option dispositions or scenario-to-ID mappings remain **open documentation debt**, not a reason to infer them.

## Boundaries

This documentation capture changes **no** architecture choice, product requirement, security policy, implementation authorization, provider behavior, or experiment status. No relationship to Analytics Dashboard is implied.
