# AD-006 — Multiple provider connection authentication strategies

**Status:** Approved in the carried-forward architecture baseline  
**Approval basis:** Direct user numbered Option C approval.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Provider protocols and deployment environments need different authentication mechanisms.

## Decision

Option C: Per-profile connection authentication selection, separate from credential-store abstractions.

## Alternatives considered

A centrally managed credentials; B individual identity-based connections; C per-profile selection among multiple strategies.

## Rationale

SQL, file-transfer, messaging and network-share providers have different authentication capabilities. Choosing an authentication strategy per profile avoids pretending one mechanism is supported by every driver while keeping stored secret material independent of the way it is presented.

## Consequences and limitations

- Adapters must check the selected strategy against their actual provider, runtime, OS and policy capabilities.
- A credential-store implementation does not dictate a single provider authentication scheme.
- An unavailable required authentication mechanism must be reported, not silently replaced by a weaker one.

## Traceability

**Approval history:** At 22:09:57Z Jim stated: “I approve Architecture Decision 6, Option C: multiple authentication strategies per connection profile, including shared credentials, user-specific credentials, integrated authentication, certificates, and passwordless identities where supported. Keep authentication strategies separate from credential stores and enforce security policies. Continue architecture discovery.” **Class:** direct numbered Option C.

**Requirements and scenarios:** AD-011–013; POC-SCN-07/08/12; EXP-003 SCN-008. Later lifecycle decisions refine.

**Historical evidence limit:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  

**Sources:**
- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
