# AD-002 — Configuration and Credential Storage

**Status:** Approved — prospective confirmation of original Option A, refined by subsequent architecture decisions  
**Decision confirmed:** November 15, 2026 (America/Los_Angeles)  
**Historical evidence status:** The original November 15 discussion's **individual final vote was not recovered**. This document records a **new, dated owner approval**, not a retroactive assertion that the original proposal was approved.  
**Related decisions:** [AD-006, AD-009–AD-013 and the unnumbered multiple-store/profile choice](decision-evidence.md)

## Problem

Data Source Manager serves both centrally managed and locally configured profiles on managed and customer-owned systems. Configuration and credentials need independent owners, storage mechanisms, protections and lifecycles. A compulsory persistence technology or combined configuration-and-secret store would limit consumers and risk collapsing distinct security responsibilities.

## Original alternatives (historical, not proof of original approval)

| Original option | Proposal | Historical evidence |
| --- | --- | --- |
| **A** | Pluggable configuration and credential storage | Recommended by the assistant; **original owner selection not recovered** |
| B | Built-in SQLite storage | Alternative; not independently chosen in recovered history |
| C | Consumer-managed storage | Alternative; not independently chosen in recovered history |

Jim's initial response discussed the existing XML/XSD/DataTable manager, centralized configuration, protected credential distribution, offline caching and the need to reconsider the architecture. It did **not** select A, B or C. The later separate choice for *both multiple credential stores and multiple connection profiles* was approved, but its original AD identifier remains unknown. See the [historical evidence record](decision-evidence.md#ad-002--configuration-and-credential-storage-original-vote-unverified-current-option-a-confirmed).

## Confirmed decision — refined Option A

Use **pluggable configuration and credential storage**, as **separate abstractions**:

1. **Pluggable configuration storage:** Define explicit configuration persistence/read ports independent of any concrete file, database or centralized service implementation.
2. **Independently pluggable credential storage:** Define a distinct credential-store boundary. Configuration and credentials must not be forced into one physical store or API.
3. **Multiple stores and profiles:** Support multiple independently configured credential stores and multiple connection profiles, preserving their separate identities, ownership and associations. This carries forward Jim's earlier independently approved requirement.
4. **Optional built-in adapters:** Provide useful storage adapters as optional components where justified by evidence and security policy.
5. **Consumer-supplied implementations:** Allow applications and organizations to provide storage adapters that conform to the approved interfaces and security constraints.
6. **No mandatory SQLite core dependency:** The provider-neutral core must not depend on SQLite as its mandatory persistence engine. A future optional SQLite-based adapter does **not** imply unprotected plaintext credential persistence.

Configuration ownership, versioning, authorization, secret protection, credential distribution, rotation and device trust remain governed by AD-006 and AD-009 through AD-013, plus later offline and emergency security decisions. A pluggable adapter **cannot bypass** organizational/profile policy, trust requirements, expiry, auditing, revocation or fail-closed handling.

## Rationale and consequences

- The default ports-and-adapters/hexagonal design supports consumer-selected persistence without binding every user to SQLite or a hosted control plane.
- Independently modeled credential stores preserve stronger secret-management mechanisms and lifecycle controls than a combined configuration persistence abstraction.
- Centrally managed profiles and customer-owned devices retain their distinct authority, trust, caching and offline-access boundaries.
- Optional adapters and consumer-managed implementations are compatible under the same verified contracts; the decision does **not** mandate shipping SQLite, a credential vault, or a central management service in POC-001.
- Concrete adapters must declare supported capabilities and undergo security/compatibility evaluation; no unsupported OS, framework or storage guarantee is implied.

## Owner approval and chronology

**Recommendation presented in the current engineering conversation (November 15, 2026):** “Option A, refined” with six explicit elements: pluggable configuration storage; independently pluggable credential storage; multiple stores/profiles; optional built-in adapters; consumer-provided implementations; no mandatory SQLite dependency in the core.

**Owner response:** Jim replied **“Yes”** directly to **“Do you approve this recommendation for AD-002?”**

**Approval class:** Direct affirmative response to a specifically enumerated prospective AD-002 recommendation. **Not** a recovered direct user approval of the original 20:56 UTC A/B/C proposal. The original historical gap remains recorded; this confirmation resolves the *current architectural disposition*.

## Traceability, limits and future changes

- **Related planning:** REQ-03/04/05/06/07, POC-SCN-05–08 and D-03/D-04/D-06/D-07 (all later charter aliases/criteria, not original AD-002 scenario IDs).
- **Coverage qualification:** POC-SCN-05–08 cover related configuration, trust and secret boundaries; none specifically proves concurrent multiple credential stores with multiple profiles. That acceptance obligation is deferred and must not be marked verified.
- **Implementation gate:** Documentation approval only. Does **not** authorize implementation, running POC-001, adding new dependencies, releasing, or merging this PR.
- **Supersession:** No formal historical supersession of the original proposal is evidenced. This **dated confirmation governs prospective AD-002 design** and does not rewrite older conversation records. Any future replacement must record its reason, approval, and explicit relationship here and in the canonical index.
