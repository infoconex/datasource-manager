# AD-032 — Structured error contracts

**Status:** Selected by assistant under owner's blanket delegation; later carried forward  
**Approval basis:** Assistant-selected under delegated autonomy; **not** an item-specific owner approval.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Distinguishing policy denial, unsupported capability, genuine unavailability, expiry, cancellation, and uncertain remote outcomes.

## Decision

Stable structured errors distinguishing unsupported, unavailable, unauthorized, expired, cancelled, uncertain; redact sensitive details.

## Alternatives considered

Not presented to user; no option letter.

## Rationale

A consumer must tell a denied policy from a missing feature or an endpoint outage, and a timed-out remote call may have an indeterminate side effect. Structured, redacted errors make these distinctions actionable without exposing secrets.

## Consequences and limitations

- Errors distinguish unsupported, unavailable, unauthorized, expired, cancelled and uncertain outcomes.
- Provider or credential secrets cannot be embedded in public error details or diagnostic payloads.
- An uncertain remote result is reported as uncertain, not recast as safe to retry or as proof of failure.

## Traceability

**Approval history:** Assistant-selected under blanket delegation; **not individually ratified**.

**Requirements and scenarios:** EXP-004 SCN-005, SCN-010, SCN-014, and SCN-019 as relevant. The charter does not give this decision a unique dedicated scenario.

**Related decisions and refinements:** No subsequent modification recorded.

**Sources:**
- [Architecture discovery, original AD-032 extraction, lines 348–357](../archive/conversations/architecture-discovery.md#L348-L357)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
