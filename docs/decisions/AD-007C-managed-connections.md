# AD-007C — Managed acquisition with authorized raw-export exception

**Status:** Approved in the carried-forward architecture baseline  
**Approval basis:** Direct user numbered Option C approval.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Preserve policy/lifecycle control while allowing exceptional legacy/native use.

## Decision

Option C: Policy-controlled managed acquisitions by default, with explicitly authorized exceptional connection-string export.

## Alternatives considered

A connection strings as primary; B only managed connections; C managed connections primary, raw connection-string export only when explicitly authorized.

## Rationale

Managed acquisition keeps policy checks and lease lifecycle under the library's control while still permitting an exceptional escape hatch for callers that must construct native resources themselves. Export is a distinct, explicitly authorized capability, not an equivalent managed API.

## Consequences and limitations

- After raw connection-string export, the library cannot reliably enforce routing, lease disposal, in-flight operation control, telemetry or immediate revocation of caller-owned connections.
- Consumers must not interpret export as a guarantee that their native connections receive the managed lease protections.
- A separate security review and acceptance proof for export remain deferred; POC-SCN-11/13 do not validate this exception.

## Traceability

**Approval history:** At 22:16:32Z Jim stated: “I approve Architecture Decision 7C, Option C: managed connections as the primary API, with explicitly authorized connection-string export and clear disclosure of routing limitations.” **Class:** direct numbered Option C.

**Requirements and scenarios:** AD-028; EXP-004 lease scenarios (adjacent only). POC-SCN-11/13 **do not test raw export**. A dedicated future security review and acceptance proof are deferred/unmapped; POC-001 does not authorize building this feature. AD-028 refines lease expectations, does not silently erase the exception.

**Historical evidence limit:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  

**Sources:**
- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
