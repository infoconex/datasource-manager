# AD-007C — Managed acquisition with authorized raw-export exception

**Status:** Approved in the carried-forward architecture baseline  
**Approval class:** Direct user numbered Option C approval.  
**Historical source limitation:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  
**Implementation state:** Decision only; experiments remain unexecuted.

## Context and problem

Preserve policy/lifecycle control while allowing exceptional legacy/native use.

## Alternatives considered

A connection strings as primary; B only managed connections; C managed connections primary, raw connection-string export only when explicitly authorized.

## Selected approach

Option C: Policy-controlled managed acquisitions by default, with explicitly authorized exceptional connection-string export.

## Rationale

Default is policy-controlled managed leases. Raw connection-string export is an **exceptional authorized escape hatch**, not a default or equivalent managed API. After export the library cannot reliably enforce destination routing, leased-resource disposal, in-flight operations, telemetry or immediate revocation of arbitrary caller-owned native connections.

## Consequences and limits

Implementation must honor the risk and capability qualifications stated above and in the subsequently approved security, routing, and compatibility decisions. No unexecuted test is counted as verification.

## Approval evidence

At 22:16:32Z Jim stated: “I approve Architecture Decision 7C, Option C: managed connections as the primary API, with explicitly authorized connection-string export and clear disclosure of routing limitations.” **Class:** direct numbered Option C.

**Classification:** Direct user numbered Option C approval.

## Related requirements and acceptance scenarios

AD-028; EXP-004 lease scenarios (adjacent only). POC-SCN-11/13 **do not test raw export**. A dedicated future security review and acceptance proof are deferred/unmapped; POC-001 does not authorize building this feature. AD-028 refines lease expectations, does not silently erase the exception.

This is a topical relationship, not proof of a recovered original numbered test mapping. See [POC-001](../requirements/POC-001.md) and [historical experiment traceability](../requirements/experiment-traceability.md).

## Related decisions and supersession

AD-028; EXP-004 lease scenarios (adjacent only). POC-SCN-11/13 **do not test raw export**. A dedicated future security review and acceptance proof are deferred/unmapped; POC-001 does not authorize building this feature. AD-028 refines lease expectations, does not silently erase the exception.

No later source documents a formal repeal of this decision. The cited decisions refine or limit its application; original user wording is not silently rewritten.

## Evidence sources

- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [Decision register](README.md)
