# AD-003 — Managed and customer-owned security contexts

**Status:** Approved in the carried-forward architecture baseline  
**Approval basis:** Direct user requirement, immediately recorded as Decision 3 by the assistant; no original numbered alternative vote recovered.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

One device trust assumption cannot safely apply to both managed and customer-owned environments.

## Decision

Support both trusted managed systems and customer-owned deployments under different device trust assumptions.

## Alternatives considered

Individual original AD-003 alternative options not recovered; do **not** import AD-004 options here.

## Rationale

Managed devices may supply trusted workload identity, stronger key protection and controlled provisioning; customer-owned devices cannot be assigned the same assumptions. The model therefore separates what the library can authorize from what a potentially compromised endpoint can protect.

## Consequences and limitations

- Deployment trust must influence credential delivery, local cache policy, offline authorization and available authentication methods.
- Customer-owned access may require brokered or delegated credentials and conservative authorization defaults.
- No ordinary user-space component can promise secret protection against an attacker controlling the host.

## Traceability

**Approval history:** At 21:23:30Z Jim stated: “The library must support both trusted managed systems and customer-owned systems. Continue the architecture discussion, explain the security implications, and ask the next question.” At 21:23:52Z the assistant recorded “Decision 3 recorded.”

**Requirements and scenarios:** AD-004/011/013/018/019; POC-SCN-07–10. Later policies refine, not repeal, support for both deployment classes.

**Historical evidence limit:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  

**Sources:**
- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
