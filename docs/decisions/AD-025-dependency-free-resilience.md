# AD-025 — Coordinated resilience, without Polly

**Status:** Approved in the carried-forward baseline; conversational assent to revised Option C  
**Approval basis:** Conversational assent after user rejected Polly; **not a direct numbered user vote**.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Preventing duplicate provider/library retries, cascading load, and missed timeouts while preserving a dependency-free core.

## Decision

Revised Option C; no broad operation replay; no unsafe consistency downgrade; no dependency on Polly. Optional provider drivers isolated from dependency-free core.

## Alternatives considered

**A** provider-managed retry/timeouts exclusively (consistent core API harder); **B** library-managed retry with configurable provider retries disabled (some provider behavior opaque); **C** coordinated hybrid with one bounded logical acquisition deadline, per-acquisition attempt cap, aggregate retry budget, jitter, transient classification, concurrency/breaker coordination, and conservative outer retries. After a user objection, the recommendation was **revised C** using standard .NET and provider-native mechanisms, with no Polly or other third-party resilience framework.

## Rationale

A driver and outer library may both retry, multiplying attempts and prolonging an outage if budgets are independent. Coordinating logical deadlines, attempt caps and transient classification provides bounded resilience using standard .NET and provider-native mechanisms without adding Polly or a general-purpose resilience framework.

## Consequences and limitations

- One logical acquisition budget must account for inner provider behavior, outer attempts, jitter, concurrency and breaker state.
- Some provider retries are opaque; the library must document and test the limits of coordinating them rather than assert complete control.
- The dependency-free core does not replay unsafe operations or relax routing consistency to recover availability.

## Traceability

**Approval history:** User said “I don’t want to take a dependency on a 3rd party library like Polly”; later asked “Is Polly a Microsoft library?”; after the assistant recommended the dependency-free approach, user replied **“Agreed.”** The next assistant message interpreted that as approval: “Architecture Decision 25 is approved in its revised form.” **No user message explicitly states “I approve Architecture Decision 25, Option C.”**

**Requirements and scenarios:** EXP-003 SCN-006–011.

**Related decisions and refinements:** **Material revision within Decision 25:** Polly and `Microsoft.Extensions.Resilience`-as-Polly-wrapper removed from the core recommendation. This is not a reversal of Decision 20.

**Sources:**
- [Architecture discovery, original AD-025 extraction, lines 278–287](../archive/conversations/architecture-discovery.md#L278-L287)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
