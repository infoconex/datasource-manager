# AD-013 — Credential cache portability

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Whether credentials can be moved between devices or identities.

## Alternatives considered

Options A/B unavailable.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Default caches bound to approved local security contexts; centrally managed credentials re-provision after enrollment; optional controlled encrypted recovery for locally managed profiles.

## Rationale

Prevents copying a cache from becoming credential portability (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 13, Option C: credential caches bound to approved local security contexts by default, centrally managed credentials re-provisioned after device enrollment, and optional controlled encrypted recovery for locally managed profiles.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-002-A cache protection/recovery; exact related SCNs unavailable.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decision 19 adds OS-specific security capability requirements.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-013 extraction, lines 158–167](../archive/conversations/architecture-discovery.md#L158-L167)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
