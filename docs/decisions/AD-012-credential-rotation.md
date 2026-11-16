# AD-012 — Credential rotation

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Coordinating credential changes without taking ownership of every destination's rotation process.

## Alternatives considered

Options A/B unavailable.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

External rotation default; optional provider-specific rotation; core version refresh, cache invalidation, pool transitions, offline expiration, and audit.

## Rationale

Fits established secret-management systems and preserves separation of responsibilities (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 12, Option C: external credential rotation by default, with optional provider-specific rotation capabilities. Core responsibilities include version refresh, cache invalidation, pool transitions, offline expiration, and auditing.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-002-C rotation/revocation; EXP-004 SCN-013 later exercises lifecycle interactions.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decision 15 distinguishes planned rotation from security revocation.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-012 extraction, lines 148–157](../archive/conversations/architecture-discovery.md#L148-L157)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
