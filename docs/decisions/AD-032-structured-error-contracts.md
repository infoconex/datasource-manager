# AD-032 — Structured error contracts

**Status:** Selected by assistant under owner's blanket delegation; later carried forward  
**Approval evidence class:** Assistant-selected under delegated autonomy; **not** an item-specific owner approval.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Distinguishing policy denial, unsupported capability, genuine unavailability, expiry, cancellation, and uncertain remote outcomes.

## Alternatives considered

Not presented to user; no option letter.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Stable structured errors distinguishing unsupported, unavailable, unauthorized, expired, cancelled, uncertain; redact sensitive details.

## Rationale

Consumers need actionable categories without leaking secrets (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

Assistant-selected under blanket delegation; **not individually ratified**.

**Evidence classification:** Assistant-selected under delegated autonomy; **not** an item-specific owner approval.

## Related requirements and acceptance scenarios

EXP-004 SCN-005, SCN-010, SCN-014, and SCN-019 as relevant. The charter does not give this decision a unique dedicated scenario.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

None shown.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-032 extraction, lines 348–357](../archive/conversations/architecture-discovery.md#L348-L357)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
