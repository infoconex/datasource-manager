# AD-021 — Hybrid health monitoring

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Determining health without intrusive tests or conflating it with permission.

## Alternatives considered

Options A/B unavailable.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Provider-native and passive signals by default; optional bounded active probes under org/profile policy; conservative customer-owned defaults; separate health, authorization, breaker states.

## Rationale

Controls monitoring overhead and respects ownership/trust boundaries (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 21, Option C: policy-driven hybrid health monitoring using provider-native and passive signals by default, optional bounded active probes under organization/profile policy, conservative customer-owned defaults, and separate health, authorization, and circuit-breaker states.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-003 SCN-012–014.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decision 22 limits shared intelligence; Decision 27 scopes breakers.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-021 extraction, lines 238–247](../archive/conversations/architecture-discovery.md#L238-L247)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
