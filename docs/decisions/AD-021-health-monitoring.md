# AD-021 — Hybrid health monitoring

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Determining health without intrusive tests or conflating it with permission.

## Decision

Provider-native and passive signals by default; optional bounded active probes under org/profile policy; conservative customer-owned defaults; separate health, authorization, breaker states.

## Alternatives considered

Options A/B unavailable.

## Rationale

Passive and provider-native signals can reveal availability with less intrusion than periodic synthetic operations. An active probe has its own cost and permission implications and must not be confused with an authorization decision.

## Consequences and limitations

- Probes are optional, bounded and subject to organization/profile policy, especially on customer-owned devices.
- Health, breaker and authorization state remain separate: a healthy endpoint is not necessarily permitted.
- Monitoring must limit overhead and avoid invasive activity that the provider or owner has not authorized.

## Traceability

**Approval history:** “I approve Architecture Decision 21, Option C: policy-driven hybrid health monitoring using provider-native and passive signals by default, optional bounded active probes under organization/profile policy, conservative customer-owned defaults, and separate health, authorization, and circuit-breaker states.”

**Requirements and scenarios:** EXP-003 SCN-012–014.

**Related decisions and refinements:** Decision 22 limits shared intelligence; Decision 27 scopes breakers.

**Sources:**
- [Architecture discovery, original AD-021 extraction, lines 238–247](../archive/conversations/architecture-discovery.md#L238-L247)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
