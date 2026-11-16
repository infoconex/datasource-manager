# AD-035 — Optional provider-native pool coordination

**Status:** Approved as **optional architectural capability**; implementation explicitly deferred  
**Approval class:** Formal owner approval of the proposed architecture/POC package; **not** a recovered separate historic numbered quotation.  
**Implementation state:** No optional pool coordinator has been implemented or proven.  
**Title and number:** Charter uses AD-35; this file uses canonical AD-035.

## Context and problem

The user reported real SQL Server native connection-pool stale-checkout failures after restarting SQL Server: returned physical connections could be unusable on later acquisition. A library-level coordinator might shorten recovery in some driver/runtime combinations but could also clear unrelated tenant pools or fragment physical connection identities. Provider-native pooling must remain the primary owner of physical connections.

## Alternatives considered

The charter recommends an **optional capability-based coordination layer over provider-native pooling**, not a replacement pool. Full original standalone Option A/B comparison is **not recovered** in the preserved final charter; no alternatives are fabricated. SQL recovery measurement precedes any product implementation choice.

## Selected approach

- Retain provider-native pooling as authoritative; **do not** build another physical pool or general retry engine.
- Expose management capabilities **only when a provider supports and authorizes them**, such as bounded admission, scoped health/utilization estimates, tracked-lease drain, provider-native targeted invalidation and credential-rotation coordination.
- Report diagnostics in structured, redacted form; do not record connection strings or credentials.
- **Do not implement** the coordinator in POC-001. Compare native recovery alone with a narrow, controlled **test-harness-only** invocation of actual `SqlConnection.ClearPool`; decide later whether implementation adds measurable, safely scoped value.

## Rationale

Native pooling often already handles invalidation and reconnect behavior; first measure real driver recovery under identical controlled conditions across the mandatory Windows runtime matrix. A manager cannot truthfully promise physical connection control where native providers expose none.

## Consequences and security/operational limits

- Pool identity is determined by **actual provider/native pool key** (connection string representation, authentication/security identity, token/credential identity and process), **not a logical tenant label**. Do not clear a shared physical pool under a false tenant-isolation assumption.
- Routine tenant/profile-scoped `ClearAllPools` is excluded. Any privileged global maintenance would require separate approval.
- `ClearPool` does not restore a down SQL Server or cancel in-flight remote operations. Draining tracks manager-controlled leases, not arbitrary external connections.
- Provider pool statistics and hard cancellation may be unavailable; expose limitations rather than claim exact physical pool control.
- Normalize connection identity deterministically **without combining distinct security contexts**.
- A first stale checkout failure can be acceptable in a recovery test; eventual new harmless acquisition **without restarting the client** is the required recovery behavior.
- An uncertain SQL command/transaction result must **never** be blindly replayed.

## Approval evidence

The [final architecture-review extraction](../archive/conversations/final-architecture-review.md#L13-L20) records the owner's **“I approve”** of the proposed AD-035/POC decision package. This later explicit approval authorizes the **architectural option**, not implementation, test infrastructure or a general native pool manager.

## Related requirements and acceptance scenarios

- [POC-SCN-18](../requirements/POC-001.md): native SQL Server restart/reacquire recovery with an actual pool.
- [POC-SCN-19](../requirements/POC-001.md): indeterminate SQL operation outcome without manager replay.
- [POC-SCN-20](../requirements/POC-001.md): native-only versus **test-harness scoped** `ClearPool` comparison; no implementation of AD-035 coordinator.
- `REQ-12`, `REQ-13`, `D-12` and `D-13` are later charter planning aliases, not historical original IDs.
- No experiment is yet executed. A “no measurable benefit” result can justify deferral rather than being mislabeled a failure.

## Related decisions and supersession

Refines AD-015 (resource lifecycle), AD-020 (retry scope), AD-025 (bounded recovery) and AD-028 (managed leases). Does not supersede provider-native pool ownership. After POC-001, a separately approved decision may **build next**, **defer**, or **reject** implementation based on observed value and isolation risk.

## Evidence sources

- [Original AD-35 proposal and safety limits](../archive/charters/architecture-and-poc-execution-charter.md)
- [Formal owner approval summary](../archive/conversations/final-architecture-review.md)
- [POC-001 test protocol and owner gates](../archive/charters/poc-001-engineering-kickoff-charter.md)
- [Decision register](README.md)
