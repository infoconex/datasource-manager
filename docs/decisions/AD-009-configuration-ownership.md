# AD-009 — Configuration ownership

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Ownership and local editability of centrally managed versus standalone profiles.

## Alternatives considered

Options A/B not preserved.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Explicit configuration ownership: centrally managed profiles with protected read-only caches, standalone locally managed profiles, restricted non-security overrides.

## Rationale

Prevents local security-policy drift while allowing practical standalone use (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 9, Option C: explicit configuration ownership supporting centrally managed profiles with protected read-only caches, standalone locally managed profiles, and restricted non-security overrides.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

Configuration authority and limited overrides; EXP-001 planning baseline. Exact EXP-001 SCN identifiers/text unavailable.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decision 10 provides synchronization and atomic activation; no supersession.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-009 extraction, lines 118–127](../archive/conversations/architecture-discovery.md#L118-L127)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
