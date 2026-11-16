# AD-001 — Desktop and server application support

**Status:** Approved in the carried-forward architecture baseline  
**Approval basis:** User-selected alternative A, immediately recorded as Decision 1 approved by the assistant; not a user-specified numbered Option A approval.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Whether the manager serves interactive desktop applications, server applications, or both.

## Decision

Both desktop and server applications; provider-qualified framework and OS capabilities.

## Alternatives considered

A both desktop and server (**recommended**); B server only; C desktop only.

## Rationale

A common management contract can serve interactive and unattended applications without duplicating provider policy. Hosting-model support is separate from evidence that a particular provider, runtime, operating system, or authentication mechanism is usable.

## Consequences and limitations

- Consumers may use the same conceptual profile, authorization and acquisition model in desktop and server hosts.
- Each provider/runtime/OS combination still needs its own compatibility and security qualification; the library's API alone does not establish support.
- AD-019, AD-033 and AD-034 narrow the initially broad platform aspiration; macOS remains a qualification candidate.

## Traceability

**Approval history:** At 20:55:52Z Jim stated: “The library should support both desktop and server applications. Continue architecture discovery with the next decision.” At 20:56:02Z the assistant recorded “Decision 1 approved.” **Class:** user-selected plus assistant-recorded, **not** a literal numbered Option A approval.

**Requirements and scenarios:** AD-019/033/034; POC-SCN-04, POC-SCN-21 (later topical links, **not original numbered trace**). No identified supersession.

**Historical evidence limit:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  

**Sources:**
- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
