# Historical experiment and POC traceability

**Status:** Documentation reconciliation only. EXP-001 through EXP-004 remain **unexecuted**; the later POC-001 charter and its 21 acceptance scenarios are owner-approved for planning but **not executed**. No additional scenario or implementation authorization is created here.

**Sources:** [Architecture-discovery extraction](../archive/conversations/architecture-discovery.md), [recovery and compatibility discussion](../archive/conversations/recovery-and-compatibility.md), [original consolidated charter](../archive/charters/architecture-and-poc-execution-charter.md), [approved POC kickoff](../archive/charters/poc-001-engineering-kickoff-charter.md), and [three historical review reports](../archive/reviews/).

This is an **editorial cross-reference**, not a claim that the original experiment charters contained POC-SCN references. "Adjacent/partial" means one later POC criterion may exercise a related subset; it is **not equivalent coverage** or a passed scenario. `D-01`–`D-20` are later charter **deferral aliases**, not historical experiment IDs. Unmapped work remains on the longer-term backlog rather than silently removed.

## Approval and wording confidence by experiment

| Experiment | Original evidence | Status and limits |
| --- | --- | --- |
| EXP-001 | Configuration synchronization, seven **retrospective test themes**; original charter/IDs/text not recovered | Planning baseline from carried-forward discussion. Do **not** call the seven themes verified original SCNs. Unexecuted. |
| EXP-002 | Jim explicitly approved the four workstreams and 12-scenario charter; `SCN-01` through `SCN-12` were reported in later summary | Original verbatim scenario texts and exact pairing of each numbered ID to its assertion **not recovered**. Unexecuted. |
| EXP-003 | Jim explicitly approved the consolidated four-workstream charter and **20 numbered scenarios**, directing that they remain unexecuted | The discovery extraction preserves `SCN-001`–`SCN-020` statements. Unexecuted. |
| EXP-004 | Assistant consolidated four workstreams and 20 numbered scenarios under Jim's earlier **blanket acceptance/delegation** | No separate user message expressly ratifying the final 20-scenario charter was recovered. Later broad architecture and POC approvals do not recreate that missing individual vote. Unexecuted. |

## EXP-001 — seven retrospective themes (no verified scenario identifiers)

- Authenticated/version-aware central revision validation and atomic activation (adjacent POC-SCN-05; remaining D-03/D-05).
- Interrupted transfer/write preserving last-known-good snapshot (adjacent POC-SCN-05; remaining D-05).
- Offline restart loading only eligible protected cached configuration (adjacent POC-SCN-06; remaining D-03/D-08).
- Standalone/local profiles independent of the central service (adjacent POC-SCN-06; remaining D-03).
- Rejection of local security-policy overrides (adjacent POC-SCN-05/07; remaining D-05).
- Stale revision and rollback rejection (adjacent POC-SCN-05; remaining D-05).
- Tenant/organization boundaries preserved (adjacent POC-SCN-07; remaining D-03/D-20).

These are **thematic reconstructions**, not a seven-item original acceptance test roster. Research into full vs incremental snapshots, optional push, fleet reconciliation, migrations and live central delivery remains outside the initial POC.

## EXP-002 — 12 reported IDs, assertions not individually verified

**Original identifiers reported:** `EXP-002 SCN-01` through `EXP-002 SCN-12` (using two-digit local SCN numbering). The original charter's exact **ID-to-assertion association cannot be verified**. It would be incorrect to say, for example, that a particular archived draft topic definitely was original `SCN-08`.

**Approved workstreams:** A credential/device binding, B offline authorization, C rotation/revocation, D emergency grants and security audit.

**Recovered summary-level topics (not individually assigned to IDs):**

- Copied cache fails under wrong device/security identity; lost context demands re-enrollment; local secret recovery only through explicit protected mechanism (adjacent POC-SCN-08; D-04/D-06).
- Offline authorization expiry, restart, time rollback or unverifiable time fails closed (adjacent POC-SCN-06/09; D-08).
- Active credential rotation/revocation closes new admissions and handles existing sessions/native pools honestly (adjacent POC-SCN-09/13 only; active transition **deferred** D-07).
- SQL uncertain commit result is not automatically retried (adjacent POC-SCN-19; remainder D-14).
- Emergency access uses an independent bounded grant and pre-access durable audit; repeated audit delivery is idempotent (POC-SCN-10 proves **audit boundary/failure-denial only**; actual emergency flow and deduplication **deferred** D-09).
- Customer-owned devices do not receive centrally managed shared secrets without an explicitly approved trust mechanism (adjacent POC-SCN-07/08; real-environment trust and enrollment D-04/D-20).

The consolidated charter's numbered EXP-002 `SCN-01`–`SCN-12` descriptions are **later reconstructed summaries with unverified exact number assignment**, not primary-verbatim scenario evidence. Keep its archive unchanged as a historical snapshot and resolve this when the original EXP-002 charter is found.

## EXP-003 — numbered scenarios and their POC relationships

EXP-003 charter was **explicitly approved for planning** with 20 scenarios. All remain unexecuted. The statements below are transcribed from the [discovery extraction](../archive/conversations/architecture-discovery.md); cross-references are this document's conservative editorial assessment.

| Original EXP-003 ID | Historical acceptance statement | Related POC-001 (not equivalent) | Remaining scope / disposition |
| --- | --- | --- | --- |
| EXP-003 SCN-001 | Provider-native routing is preferred when it satisfies the requested policy. | — | D-15; native provider routing evaluation deferred |
| EXP-003 SCN-002 | Priority failover selects only eligible endpoints. | POC-SCN-15 (isolation only) | D-15; priority and alternative-endpoint failover deferred |
| EXP-003 SCN-003 | Round-robin, weighted round-robin, and local least-active policies behave predictably where supported. | — | D-15; round-robin/weighted/least-active deferred |
| EXP-003 SCN-004 | Read replicas cannot be selected when consistency or freshness requirements are unmet or unverifiable. | — | D-15; replica freshness and consistency deferred |
| EXP-003 SCN-005 | Existing sessions and transactions retain required endpoint affinity. | — | D-15; session/transaction affinity deferred |
| EXP-003 SCN-006 | Acquisition attempts and delays remain within applicable deadlines and budgets. | POC-SCN-14/16 | D-14; wider provider deadline budgets deferred |
| EXP-003 SCN-007 | Concurrent failures cannot cause uncontrolled aggregate retries. | POC-SCN-16 | D-14; aggregate retry behavior beyond fixture deferred |
| EXP-003 SCN-008 | Authentication, authorization, and TLS policy failures do not trigger inappropriate retries or failover. | POC-SCN-12/15/16 | D-14/D-20; other protocols deferred |
| EXP-003 SCN-009 | Circuit-breaker failures remain isolated to the appropriate failure domain. | POC-SCN-15 | D-16; full failure-domain matrix deferred |
| EXP-003 SCN-010 | Half-open recovery allows bounded, policy-compliant trials. | POC-SCN-15 (breaker boundary only) | D-16; bounded half-open trials deferred |
| EXP-003 SCN-011 | Cancellation limitations and uncertain outcomes are reported; no unsafe operation replay occurs. | POC-SCN-13/19 | D-19; all protocols/operations deferred |
| EXP-003 SCN-012 | Provider-native and passive health signals are interpreted without conflating authorization failures with endpoint unavailability. | POC-SCN-15/17 (partial) | D-14/D-17; comprehensive health interpretation deferred |
| EXP-003 SCN-013 | Customer-owned deployments do not perform unsolicited active probes. | — | D-20; explicit no-unsolicited-probe proof deferred |
| EXP-003 SCN-014 | Authorized active probes respect configured limits and destination restrictions. | — | D-20; authorized active probes deferred |
| EXP-003 SCN-015 | Stale or untrusted shared health observations cannot impose global blocking. | — | D-17; shared-health trust boundary deferred |
| EXP-003 SCN-016 | Local routing and monitoring continue when shared monitoring is unavailable. | POC-SCN-17 (exporter boundary only) | D-17; shared-monitoring outage behavior deferred |
| EXP-003 SCN-017 | Standard .NET instrumentation exposes useful routing, acquisition, retry, and health diagnostics. | POC-SCN-17 | D-17; expanded instrumentation deferred |
| EXP-003 SCN-018 | Default telemetry excludes secrets, customer payloads, and sensitive identifiers and controls cardinality. | POC-SCN-08/17 | D-17; privacy/cardinality breadth deferred |
| EXP-003 SCN-019 | Missing or failing telemetry exporters do not interrupt normal connection operations. | POC-SCN-17 | D-17; full exporter matrix deferred |
| EXP-003 SCN-020 | Mandatory security auditing remains independent of operational telemetry. | POC-SCN-10/17 | D-09/D-17; durable audit system deferred |

## EXP-004 — numbered scenarios and their POC relationships

The 20 original statement texts are preserved in the discovery extraction. The charter was **assistant-consolidated under previous blanket acceptance/delegation**; do **not** represent it as having a separate direct final-charter owner approval. Unexecuted. Cross-references are editorial and may be only adjacent/partial.

| Original EXP-004 ID | Historical acceptance statement | Related POC-001 (not equivalent) | Remaining scope / disposition |
| --- | --- | --- | --- |
| EXP-004 SCN-001 | Applications acquire resources through explicit, testable interfaces. | POC-SCN-11 | D-10; full public API matrix deferred |
| EXP-004 SCN-002 | Provider-native resources retain their useful type-specific behavior. | POC-SCN-11 | D-02/D-10; other provider resource types deferred |
| EXP-004 SCN-003 | Unsupported capabilities can be identified without unnecessary connections. | POC-SCN-03 | D-10; provider-specific capability expansion deferred |
| EXP-004 SCN-004 | Policy restrictions cannot be bypassed through capability discovery. | POC-SCN-03/07 | D-10/D-20; complete policy bypass suite deferred |
| EXP-004 SCN-005 | Unknown security or consistency guarantees do not silently degrade. | POC-SCN-03/09 | D-10; wider consistency guarantees deferred |
| EXP-004 SCN-006 | An application can install only the adapters it needs. | POC-SCN-01/02 | D-01/D-02; broader adapter package coverage deferred |
| EXP-004 SCN-007 | Provider dependencies do not become dependencies of the core. | POC-SCN-01/02 | D-01; wider package dependency proof deferred |
| EXP-004 SCN-008 | Unregistered or untrusted adapters cannot be activated implicitly. | POC-SCN-02 | D-01; adapter trust and governance expansion deferred |
| EXP-004 SCN-009 | Provider-specific upgrades do not require unrelated core API changes. | — | D-01/D-10; independent upgrade evolution deferred |
| EXP-004 SCN-010 | Missing provider capabilities produce explicit, actionable failures. | POC-SCN-03/11 | D-10; full capability catalogue deferred |
| EXP-004 SCN-011 | Lease disposal correctly delegates to provider-specific cleanup or pooling. | POC-SCN-13/18 | D-12; other provider pooling/cleanup deferred |
| EXP-004 SCN-012 | Active leases are accounted for without claiming control over arbitrary native operations. | POC-SCN-13 | D-11; unmanaged native-operation tracking limitations remain |
| EXP-004 SCN-013 | Planned credential rotation and security revocation follow Decision 15. | POC-SCN-09/13 (partial) | D-07; real rotation/revocation with live sessions deferred |
| EXP-004 SCN-014 | Cancellation does not incorrectly imply the remote operation was terminated. | POC-SCN-13/19 | D-19; other remote protocols deferred |
| EXP-004 SCN-015 | Concurrent acquisition and disposal do not compromise lifecycle state. | POC-SCN-13 | D-11; wider lifecycle concurrency deferred |
| EXP-004 SCN-016 | Representative Windows and Linux capabilities have documented results. | POC-SCN-04/21 | D-18; extended matrix deferred |
| EXP-004 SCN-017 | macOS support assumptions are explicitly identified for later verification. | — | D-18; macOS qualification deferred |
| EXP-004 SCN-018 | Provider and framework version limitations are documented. | POC-SCN-04/21 | D-18; provider framework/version breadth deferred |
| EXP-004 SCN-019 | Unsupported platform security requirements fail closed. | POC-SCN-03/08/09 | D-18/D-20; full platform security fail-closed matrix deferred |
| EXP-004 SCN-020 | Provider selection includes dependency health, licensing, security maintenance, and support considerations. | POC-SCN-21 (version inventory only) | D-01/D-18; licensing/support/security maintenance review deferred |

## Two different POC numbering systems — do not equate by number

The [earlier recovery conversation](../archive/conversations/recovery-and-compatibility.md) proposed draft labels **`POC-001` through `POC-021`**. Those were **not approved in that conversation**. The later [approved kickoff](POC-001.md) defines **`POC-SCN-01` through `POC-SCN-21`**. Equal numeric suffixes do **not** mean equal acceptance semantics.

| Earlier, unapproved draft topic | Later, approved criterion by topic | Qualification |
| --- | --- | --- |
| `POC-015`: SQL Server restart and pooled-connection recovery | `POC-SCN-18` | Do **not** misread approved `POC-SCN-15` (failure-domain isolation) as the restart case. |
| `POC-018`: .NET Framework 4.8 consumer compatibility | `POC-SCN-04` | Approved matrix adds Windows/.NET 10/Linux and .NET 11 smoke qualification. |
| `POC-017`: enabled optional pool-coordinator behavior | `POC-SCN-20`: **test-harness-only** scoped `SqlConnection.ClearPool` comparison | Coordinator implementation removed from **initial proof** and deferred under AD-035/D-13; not an omitted or silently approved POC test. |

These are **topic correspondences, not a blanket 21-to-21 ID remapping**. Keep both historical namespaces with their respective approval states.

## Offline revocation is bounded by connectivity and trusted time

In [approved POC-SCN-09](POC-001.md) the term "revoked" refers to revocation **already known locally** or verified through a trusted authorization source. A fully disconnected device **cannot discover a newly issued remote revocation** until it reconnects (or a separately available trusted revocation channel communicates it). That limit does not extend grant expiry: new centrally managed acquisitions must still fail closed after the verifiable authorization expiry, without implicit grace, with accurate device/time trust assumptions. This is an explanation of the existing test—not a replacement of its approved wording.

## Carry-forward of obligations and next evidence gates

1. **No automatic broad implementation:** The 21 POC-SCN tests are a bounded first proof, not a complete coverage certificate for the original experiments. Keep the `D-01`–`D-20` requirements from [the consolidated charter](../archive/charters/architecture-and-poc-execution-charter.md#L159-L180) active for subsequent decisions.
2. **Provider qualifications:** SQL Server, SQLite and SFTP in POC-001 do not equal production qualification of PostgreSQL, MySQL, FTP/FTPS, SMTP or SMB/UNC.
3. **Raw string export (AD-007C):** No numbered original scenario in the recovered EXP-004 set explicitly validates an authorized raw export's policy and post-export control limits. Track as **future/unmapped security acceptance**, not as already tested by lease-disposal scenarios.
4. **Multi-store/multi-profile requirement:** The recovered direct selection that both plural stores and plural profiles remain separate has no verified original AD number; POC-SCN-05–08 do not prove simultaneous multiple-store/multiple-profile behavior. Track future acceptance without inventing a historical `SCN` ID.
5. **EXP-002 provenance:** Recover the original charter before assigning the retrospective security-topic summaries to exact `SCN-01`–`SCN-12` identifiers.
6. **EXP-004 approval:** A later approved consolidated architecture or POC charter does not retroactively create a distinct explicit approval quotation for the final assistant-compiled EXP-004 20-scenario charter.
7. **Evidence discipline:** Mark each later test verified, failed, inconclusive or unsupported based on actual evidence. No plan, approval, review, or GitHub documentation commit constitutes experiment execution.
