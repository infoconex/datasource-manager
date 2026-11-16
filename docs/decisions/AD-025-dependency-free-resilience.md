# AD-025 — Coordinated resilience, without Polly

**Status:** Approved in the carried-forward baseline; conversational assent to revised Option C  
**Approval evidence class:** Conversational assent after user rejected Polly; **not a direct numbered user vote**.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Preventing duplicate provider/library retries, cascading load, and missed timeouts while preserving a dependency-free core.

## Alternatives considered

**A** provider-managed retry/timeouts exclusively (consistent core API harder); **B** library-managed retry with configurable provider retries disabled (some provider behavior opaque); **C** coordinated hybrid with one bounded logical acquisition deadline, per-acquisition attempt cap, aggregate retry budget, jitter, transient classification, concurrency/breaker coordination, and conservative outer retries. After a user objection, the recommendation was **revised C** using standard .NET and provider-native mechanisms, with no Polly or other third-party resilience framework.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Revised Option C; no broad operation replay; no unsafe consistency downgrade; no dependency on Polly. Optional provider drivers isolated from dependency-free core.

## Rationale

Bounded predictable resilience without building or importing a general-purpose resilience framework (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

User said “I don’t want to take a dependency on a 3rd party library like Polly”; later asked “Is Polly a Microsoft library?”; after the assistant recommended the dependency-free approach, user replied **“Agreed.”** The next assistant message interpreted that as approval: “Architecture Decision 25 is approved in its revised form.” **No user message explicitly states “I approve Architecture Decision 25, Option C.”**

**Evidence classification:** Conversational assent after user rejected Polly; **not a direct numbered user vote**.

## Related requirements and acceptance scenarios

EXP-003 SCN-006–011.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

**Material revision within Decision 25:** Polly and `Microsoft.Extensions.Resilience`-as-Polly-wrapper removed from the core recommendation. This is not a reversal of Decision 20.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-025 extraction, lines 278–287](../archive/conversations/architecture-discovery.md#L278-L287)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
