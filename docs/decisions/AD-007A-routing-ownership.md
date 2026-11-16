# AD-007A — Hybrid provider-native-first routing ownership

**Status:** Approved in the carried-forward architecture baseline  
**Approval basis:** Direct user numbered Option C approval.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Avoid replacing sound provider-native routing with a generic coordinator that lacks provider semantics.

## Decision

Option C: Provider-native routing first; library-managed routing only when safe and appropriate.

## Alternatives considered

A provider-native only; B library-managed only; C hybrid/provider-native-first.

## Rationale

Provider-native routing can preserve protocol-specific guarantees that a generic selector may not understand. Library-managed selection is useful only when it respects the provider's topology and the caller's policy and consistency requirements.

## Consequences and limitations

- Native routing remains authoritative where it already satisfies the requested behavior.
- Library failover must be conditional on provider capability and required consistency; it cannot manufacture replica freshness.
- The later routing and consistency decisions (AD-023/024) add constraints rather than reversing this ownership choice.

## Traceability

**Approval history:** At 22:14:50Z Jim stated: “I approve Architecture Decision 7A, Option C: hybrid provider-native-first routing, with provider-neutral routing and resilience policies and library-managed implementations only where appropriate.” **Class:** direct numbered Option C.

**Requirements and scenarios:** AD-023/024; EXP-003 SCN-001–003. No reversal.

**Historical evidence limit:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  

**Sources:**
- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
