# AD-010 — Configuration synchronization

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Keeping local configuration consistent through disconnections and updates.

## Decision

Version-aware polling as reliable sync; optional push notifications trigger refresh; atomic activation and offline reconciliation.

## Alternatives considered

Options A/B unavailable.

## Rationale

A polling baseline works even when a push channel disconnects or notifications are missed. Push events can shorten update latency, but a versioned refresh and atomic activation are necessary to avoid applying partial or older policy.

## Consequences and limitations

- Updates must be version-aware and activate atomically; an older or partial configuration cannot replace a newer complete one.
- Push notifications trigger re-fetch rather than becoming the sole source of truth.
- Offline clients continue with only the previously authorized and valid local state, then reconcile when connectivity returns.

## Traceability

**Approval history:** “I approve Architecture Decision 10, Option C: version-aware polling as the reliable synchronization mechanism, with optional push notifications that trigger refresh, atomic configuration activation, and offline reconciliation.”

**Requirements and scenarios:** Version monotonicity, atomic cache activation, reconciliation; EXP-001. Exact SCNs unavailable.

**Related decisions and refinements:** Decision 12 requires secret-version refresh; no supersession.

**Sources:**
- [Architecture discovery, original AD-010 extraction, lines 128–137](../archive/conversations/architecture-discovery.md#L128-L137)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
