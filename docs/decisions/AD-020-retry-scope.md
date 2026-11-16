# AD-020 — Retry scope

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Which failures and operations Data Source Manager may retry without replaying side effects.

## Alternatives considered

Options A/B unavailable.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Focused connection-acquisition retries; optional provider-aware operation-level resilience only for explicitly safe operations; no blind transaction/write/transfer/message replay; coordinate budgets and breakers.

## Rationale

Connection acquisition and business operations have materially different repeatability risk (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 20, Option C: a focused connection-management core with bounded connection-acquisition retries, plus optional provider-aware operation-level resilience only for explicitly safe operations. No blind transaction, write, transfer, or message replay; coordinate retry budgets and circuit breakers across layers.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-003 SCN-006–011.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decision 25 specifies coordinated deadlines and no Polly; it does not expand unsafe retry scope.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-020 extraction, lines 228–237](../archive/conversations/architecture-discovery.md#L228-L237)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
