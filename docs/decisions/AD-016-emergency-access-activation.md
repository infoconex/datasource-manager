# AD-016 — Emergency activation

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Authorizing emergency access when normal authorization has expired or control plane is unavailable.

## Decision

Online authorization preferred; explicitly pre-authorized operator-activated offline access and separately approved service-specific automated modes on eligible managed devices; no automatic conversion of expired normal authorization; device binding, limits, expiry, audit; conservative customer-owned defaults.

## Alternatives considered

Options A/B unavailable.

## Rationale

Loss of connectivity cannot itself grant new privileges. An emergency mode must be authorized and constrained in advance, with separate treatment for operator invocation and service-specific automation.

## Consequences and limitations

- Offline activation is limited to deliberately pre-authorized grants bound to an eligible managed device and explicit limits.
- Service-automated emergency use needs its own approval; expiry of ordinary access never converts automatically to emergency access.
- Activation requires enforceable expiry and audit, with conservative customer-owned defaults.

## Traceability

**Approval history:** “I approve Architecture Decision 16, Option C: policy-driven emergency activation, preferring online authorization, allowing explicitly pre-authorized operator-activated offline access and separately approved service-specific automated emergency modes on eligible managed systems. No automatic conversion of expired normal authorization, with device binding, limited scope, expiration and auditing. Conservative customer-owned defaults.”

**Requirements and scenarios:** EXP-002-D; exact SCN mapping unavailable.

**Related decisions and refinements:** Decisions 17–18 impose durable audit and time evidence.

**Sources:**
- [Architecture discovery, original AD-016 extraction, lines 188–197](../archive/conversations/architecture-discovery.md#L188-L197)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
