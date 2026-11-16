# AD-014 — Normal offline expiry and emergency exception

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Offline authorization after its normal expiry and exceptional continuity needs.

## Alternatives considered

Options A/B unavailable.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Strict normal authorization expiry; separately provisioned, optional, time-bounded, audited emergency access for eligible managed systems; no implicit grace; conservative customer-owned defaults.

## Rationale

Emergency access cannot silently extend ordinary authorization (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 14, Option C: strict normal offline authorization expiry with a separate, optional, explicitly provisioned, time-bounded and audited emergency-access capability for eligible managed systems. No implicit grace period; conservative customer-owned defaults.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-002-B and EXP-002-D; exact SCN mappings unavailable.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decisions 16–18 define activation, audit durability, and trusted expiration validation.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-014 extraction, lines 168–177](../archive/conversations/architecture-discovery.md#L168-L177)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
