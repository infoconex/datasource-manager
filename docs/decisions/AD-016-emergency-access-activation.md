# AD-016 — Emergency activation

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Authorizing emergency access when normal authorization has expired or control plane is unavailable.

## Alternatives considered

Options A/B unavailable.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Online authorization preferred; explicitly pre-authorized operator-activated offline access and separately approved service-specific automated modes on eligible managed devices; no automatic conversion of expired normal authorization; device binding, limits, expiry, audit; conservative customer-owned defaults.

## Rationale

Constrains exceptional authority to intentionally provisioned cases (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 16, Option C: policy-driven emergency activation, preferring online authorization, allowing explicitly pre-authorized operator-activated offline access and separately approved service-specific automated emergency modes on eligible managed systems. No automatic conversion of expired normal authorization, with device binding, limited scope, expiration and auditing. Conservative customer-owned defaults.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-002-D; exact SCN mapping unavailable.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decisions 17–18 impose durable audit and time evidence.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-016 extraction, lines 188–197](../archive/conversations/architecture-discovery.md#L188-L197)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
