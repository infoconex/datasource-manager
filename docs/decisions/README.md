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

All IDs below are currently in the **approved architectural baseline**. The evidence column distinguishes how each individual decision was originally recorded.

| ID | Recovered subject (editorial) | Individual approval/source evidence |
| --- | --- | --- |
| AD-001 | Desktop **and** server application scope | User-selected alternative A; assistant explicitly recorded Decision 1 approved |
| AD-002 | [Pluggable configuration and credential storage, separate interfaces](AD-002-configuration-and-credential-storage.md) | **Refined Option A prospectively approved Nov 15, 2026**; original historical A/B/C vote remains unverified |
| AD-003 | Managed **and** customer-owned device trust tiers | Direct user requirement; assistant recorded Decision 3; numbered option vote not recovered |
| AD-004 | Per-profile offline policy constrained by organizational ceiling | Direct user Option C approval; assistant linked to Decision 4 |
| AD-005 | User/application identity and authorization | Direct numbered Option C approval |
| AD-006 | Per-profile provider authentication strategies, separate from credential stores | Direct numbered Option C approval |
| AD-007A | Hybrid provider-native-first routing ownership | Direct numbered Option C approval |
| AD-007B | Coordinated topologies first; multi-primary conditional; sharding deferred | Direct numbered Option C approval |
| AD-007C | Managed acquisition primary; **raw string export exceptional and authorized** | Direct numbered Option C approval; export outside POC-001 proof scope |
| AD-008 | Focused core with optional provider capabilities | Direct numbered Option C approval |
| AD-009 | Configuration ownership and overrides | Direct numbered Option C approval quoted |
| AD-010 | Version-aware configuration synchronization | Direct numbered Option C approval quoted |
| AD-011 | Trust-aware credential delivery | Direct numbered Option C approval quoted |
| AD-012 | Credential rotation responsibilities | Direct numbered Option C approval quoted |
| AD-013 | Security-context-bound credential caches | Direct numbered Option C approval quoted |
| AD-014 | Strict offline expiry and separate emergency grants | Direct numbered Option C approval quoted |
| AD-015 | Active connection lifecycle during rotation/revocation | Direct numbered Option C approval quoted |
| AD-016 | Emergency-access activation policy | Direct numbered Option C approval quoted |
| AD-017 | Durable pre-access emergency audit | Direct numbered Option C approval quoted |
| AD-018 | Trusted offline time validation | Direct numbered Option C approval quoted |
| AD-019 | Operating-system security capability policy | Direct numbered Option C approval quoted |
| AD-020 | Bounded acquisition retry and no unsafe replay | Direct numbered Option C approval quoted |
| AD-021 | Provider-native/passive health plus authorized probes | Direct numbered Option C approval quoted |
| AD-022 | Local versus shared health intelligence | Direct numbered Option C approval quoted |
| AD-023 | Provider-native-first routing algorithms | Direct numbered Option C approval quoted |
| AD-024 | Consistency-aware routing and no silent downgrade | Direct numbered Option C approval quoted |
| AD-025 | Coordinated resilience without Polly in core | Conversational assent after revision; later included in approved set |
| AD-026 | Privacy-first .NET-native telemetry | Direct numbered Option C approval quoted |
| AD-027 | Failure-domain-aware circuit breakers | Direct numbered Option C approval quoted |
| AD-028 | Capability-based managed typed leases | Direct numbered Option C approval quoted |
| AD-029 | Versioned capability support/availability/authorization | Blanket acceptance; not individually numbered |
| AD-030 | Explicit trusted adapter registration | Assistant-selected under delegation; later included in approved set |
| AD-031 | Optional provider dependency isolation | Assistant-selected under delegation; later included in approved set |
| AD-032 | Structured redacted error contracts | Assistant-selected under delegation; later included in approved set |
| AD-033 | Framework/OS/provider compatibility matrices | Assistant-selected under delegation; later included in approved set |
| AD-034 | .NET Framework 4.8 and .NET 10 framework policy | Formal approval after consolidated charter |
| AD-035 | Optional coordination over provider-native pools | Formal approval after consolidated charter; implementation deferred |

**AD-002 disposition:** The [dated AD-002 record](AD-002-configuration-and-credential-storage.md) now approves refined **Option A**: independently pluggable configuration and credential storage, multiple stores/profiles, optional adapters, consumer-provided adapters, and **no mandatory SQLite dependency** in the core. This is a **new confirmation**, not a retroactive original vote, and it does not expand or execute POC-001.

**Subdecision preservation:** AD-007 contains three distinct, directly approved sub-identifiers **AD-007A**, **AD-007B**, and **AD-007C**. Their recovered alternatives and quotations are in [decision evidence](decision-evidence.md). **AD-007C raw connection-string export** is an explicitly authorized exceptional escape hatch; subsequent routing, lease tracking, revocation, and disposal cannot be guaranteed once a caller takes native control. This export path has **not** been validated or authorized for implementation by POC-001.

**Compatibility clarification:** AD-033 establishes matrix-based qualification; AD-034 adds explicit framework commitments, including supported `.NET Framework 4.8/Windows` and `.NET 10/Windows+Linux`, `.NET 11` qualification, `.NET 8` best effort, and no `.NET 6` support.

**Pooling clarification:** AD-035 permits optional capability-based coordination over *native* pooling. It does **not** authorize a new physical pool or implementing the coordinator in POC-001. The POC compares native recovery against a narrowly scoped `SqlConnection.ClearPool` test-harness intervention.

## Requirements and acceptance

- [AD-002 — approved prospective confirmation and historical record](AD-002-configuration-and-credential-storage.md).
- [Decision evidence: original AD-001–008 alternatives, approvals and later decision-specific source links](decision-evidence.md).
- [POC-001: exact 21 approved acceptance scenarios and traceability](../requirements/POC-001.md).
- [EXP-001–004 planning and cross-experiment traceability](../requirements/experiment-traceability.md).
- [Consolidated architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md) §§ 5, 7–12: approved scope, `REQ-01..20` aliases, `D-01..20` deferrals, historical EXP-001..004 summaries, security stopping rules.
- [POC-001 engineering kickoff](../archive/charters/poc-001-engineering-kickoff-charter.md) §§ 8–10: exact criteria, increment ownership, evidence, and I0–I6 sequence.
- None of `EXP-001` through `EXP-004` was executed. Their broader obligations remain deferred, not cancelled.

## Recording future decisions

1. Capture each new proposed decision in `docs/decisions/` with unique ID, context/problem, alternatives actually considered, recommendation, consequences, requirement/scenario references, source links, and proposed status.
2. Record Jim's actual approval or rejection and date **without rewriting the earlier proposal**. Keep direct approval distinct from delegation or inference.
3. Add a supersession reference in *both* old and new decisions; never silently edit historical reasoning.
4. Link any resulting functional scenario to requirements, issue, test, evidence and verification status; use one issue and one PR per coherent increment.
5. Do not claim a scenario passed until real evidence exists. Changes to approved security guarantees, framework support or POC scope require explicit renewed owner approval.
6. Preserve and check the recovered early review evidence against primary transcripts if available, especially the missing **original historical AD-002 vote** (the current refined choice is approved), then amend this index through review. Unrecovered original option dispositions or scenario-to-ID mappings remain **open documentation debt**, not a reason to infer them.

## Boundaries

This documentation capture changes **no** architecture choice, product requirement, security policy, implementation authorization, provider behavior, or experiment status. No relationship to Analytics Dashboard is implied.
