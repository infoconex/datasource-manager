# AD-020 — Retry scope

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Which failures and operations Data Source Manager may retry without replaying side effects.

## Decision

Focused connection-acquisition retries; optional provider-aware operation-level resilience only for explicitly safe operations; no blind transaction/write/transfer/message replay; coordinate budgets and breakers.

## Alternatives considered

Options A/B unavailable.

## Rationale

Connection acquisition failures can often be retried within a bounded policy, whereas repeating a transaction, file transfer or message may duplicate irreversible effects. Keeping the core focused on acquisition avoids making application-level idempotency assumptions.

## Consequences and limitations

- Acquisition retries are bounded and coordinate with provider retry budgets and circuit breakers.
- Operation-level resilience is optional and only applies when provider-aware evidence establishes that an operation is safe to repeat.
- Uncertain write, transaction, transfer or message outcomes are surfaced; the manager does not replay them blindly.

## Traceability

**Approval history:** “I approve Architecture Decision 20, Option C: a focused connection-management core with bounded connection-acquisition retries, plus optional provider-aware operation-level resilience only for explicitly safe operations. No blind transaction, write, transfer, or message replay; coordinate retry budgets and circuit breakers across layers.”

**Requirements and scenarios:** EXP-003 SCN-006–011.

**Related decisions and refinements:** Decision 25 specifies coordinated deadlines and no Polly; it does not expand unsafe retry scope.

**Sources:**
- [Architecture discovery, original AD-020 extraction, lines 228–237](../archive/conversations/architecture-discovery.md#L228-L237)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
