# Architecture decision register

**Record date:** November 15, 2026 (Pacific time)  
**Source:** [architecture-discovery extraction](../archive/conversations/architecture-discovery.md), [SQL recovery and compatibility extraction](../archive/conversations/recovery-and-compatibility.md), [final architecture review extraction](../archive/conversations/final-architecture-review.md), and the two [approved planning charters](../archive/charters/architecture-and-poc-execution-charter.md).  
**Current disposition:** AD-001 through AD-035 and POC-001 were affirmed/approved by Jim. No experiment has run.

## Provenance rules

1. This is a **reconciled index**, not invented verbatim ADRs. The three conversation files and two charters under `docs/archive/` are preserved unchanged as source evidence. Their original statuses reflect when they were written.
2. An **inherited approval** means Jim explicitly carried forward the prior approved decision set; it does not establish a missing individual transcript. **Direct numbered approval** means the source conversation extraction quotes the user's numbered approval. **Conversational assent**, **blanket acceptance**, and **assistant-selected under delegation** are separate evidence strengths.
3. The full original standalone wording for AD-001–AD-003 remains unavailable. AD-004–AD-008 have recovered *summaries*, but not all original alternatives/approval transcripts. AD-009–AD-033 have more extensive recoverable provenance; where a source flags an analytical summary rather than the original text, that qualification remains.
4. AD-034, AD-035, and all 21 POC scenarios were first written in a charter labeled **proposed**. Jim's **later explicit approval** governs their current status; we preserve the historical proposed header unchanged. The [final-review extraction](../archive/conversations/final-architecture-review.md) documents that approval transition. This approval alone did not authorize executing experiments.
5. `REQ-01` through `REQ-20` and `D-01` through `D-20` are **new traceability aliases** introduced in the consolidated charter, not recovered original requirement IDs.
6. The recovered decision/topic names below are *editorial labels* drawn from the source extraction, not asserted historical titles. No unsupported original option wording or source attribution is manufactured.

## Decision inventory

All IDs below are currently in the **approved architectural baseline**. The evidence column distinguishes how each individual decision was originally recorded.

| ID | Recovered subject (editorial) | Individual approval/source evidence |
| --- | --- | --- |
| AD-001 | Not recoverable | Inherited approval; original individual content unavailable |
| AD-002 | Not recoverable | Inherited approval; original individual content unavailable |
| AD-003 | Not recoverable | Inherited approval; original individual content unavailable |
| AD-004 | Offline policy by profile and trust tier | Carry-forward approval; no direct original quote |
| AD-005 | User/application identity and authorization | Carry-forward approval; no direct original quote |
| AD-006 | Provider-appropriate authentication strategies | Carry-forward approval; no direct original quote |
| AD-007 | 7A routing ownership; 7B topologies; 7C managed connection ownership | Carry-forward approvals; subdecisions recorded |
| AD-008 | Layered capability API | Carry-forward approval; no direct original quote |
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

**Subdecision preservation:** AD-007 contains three recorded sub-identifiers: **7A** (routing ownership), **7B** (supported topologies), and **7C** (managed connections). Their original per-option wording is not fully available.

**Compatibility clarification:** AD-033 establishes matrix-based qualification; AD-034 adds explicit framework commitments, including supported `.NET Framework 4.8/Windows` and `.NET 10/Windows+Linux`, `.NET 11` qualification, `.NET 8` best effort, and no `.NET 6` support.

**Pooling clarification:** AD-035 permits optional capability-based coordination over *native* pooling. It does **not** authorize a new physical pool or implementing the coordinator in POC-001. The POC compares native recovery against a narrowly scoped `SqlConnection.ClearPool` test-harness intervention.

## Requirements and acceptance

- [POC-001: exact 21 approved acceptance scenarios and traceability](../requirements/POC-001.md).
- [Consolidated architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md) §§ 5, 7–12: approved scope, `REQ-01..20` aliases, `D-01..20` deferrals, historical EXP-001..004 summaries, security stopping rules.
- [POC-001 engineering kickoff](../archive/charters/poc-001-engineering-kickoff-charter.md) §§ 8–10: exact criteria, increment ownership, evidence, and I0–I6 sequence.
- None of `EXP-001` through `EXP-004` was executed. Their broader obligations remain deferred, not cancelled.

## Recording future decisions

1. Capture each new proposed decision in `docs/decisions/` with unique ID, context/problem, alternatives actually considered, recommendation, consequences, requirement/scenario references, source links, and proposed status.
2. Record Jim's actual approval or rejection and date **without rewriting the earlier proposal**. Keep direct approval distinct from delegation or inference.
3. Add a supersession reference in *both* old and new decisions; never silently edit historical reasoning.
4. Link any resulting functional scenario to requirements, issue, test, evidence and verification status; use one issue and one PR per coherent increment.
5. Do not claim a scenario passed until real evidence exists. Changes to approved security guarantees, framework support or POC scope require explicit renewed owner approval.
6. Recover missing original AD-001–AD-008 primary records if located; add them as immutable references, then amend this index through review. The absence of verbatim originals is **open documentation debt**, not a reason to invent their contents.

## Boundaries

This documentation capture changes **no** architecture choice, product requirement, security policy, implementation authorization, provider behavior, or experiment status. No relationship to Analytics Dashboard is implied.
