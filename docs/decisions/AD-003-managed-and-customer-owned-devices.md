# AD-003 — Managed and customer-owned security contexts

**Status:** Approved in the carried-forward architecture baseline  
**Approval class:** Direct user requirement, immediately recorded as Decision 3 by the assistant; no original numbered alternative vote recovered.  
**Historical source limitation:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  
**Implementation state:** Decision only; experiments remain unexecuted.

## Context and problem

One device trust assumption cannot safely apply to both managed and customer-owned environments.

## Alternatives considered

Individual original AD-003 alternative options not recovered; do **not** import AD-004 options here.

## Selected approach

Support both trusted managed systems and customer-owned deployments under different device trust assumptions.

## Rationale

Managed devices may support stronger workload identity and protected caches; customer-controlled devices have different trust ceilings, may need brokered credentials and conservative default authorization. No ordinary user-space library guarantees protection on a fully compromised customer-controlled host.

## Consequences and limits

Implementation must honor the risk and capability qualifications stated above and in the subsequently approved security, routing, and compatibility decisions. No unexecuted test is counted as verification.

## Approval evidence

At 21:23:30Z Jim stated: “The library must support both trusted managed systems and customer-owned systems. Continue the architecture discussion, explain the security implications, and ask the next question.” At 21:23:52Z the assistant recorded “Decision 3 recorded.”

**Classification:** Direct user requirement, immediately recorded as Decision 3 by the assistant; no original numbered alternative vote recovered.

## Related requirements and acceptance scenarios

AD-004/011/013/018/019; POC-SCN-07–10. Later policies refine, not repeal, support for both deployment classes.

This is a topical relationship, not proof of a recovered original numbered test mapping. See [POC-001](../requirements/POC-001.md) and [historical experiment traceability](../requirements/experiment-traceability.md).

## Related decisions and supersession

AD-004/011/013/018/019; POC-SCN-07–10. Later policies refine, not repeal, support for both deployment classes.

No later source documents a formal repeal of this decision. The cited decisions refine or limit its application; original user wording is not silently rewritten.

## Evidence sources

- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [Decision register](README.md)
