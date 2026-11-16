# Data Source Manager — PR #2 Architecture and Approval-History Review

**Review date:** November 15, 2026 (America/Los_Angeles)  
**Repository:** https://github.com/infoconex/datasource-manager  
**Pull request:** https://github.com/infoconex/datasource-manager/pull/2  
**Immutable candidate reviewed:** `c3c691b42556261a9a73e5dab0bce788682956b9`  
**Review type:** Documentation-only comparison against the architectural conversation and recovered historical conversation context.  
**Changes made:** None to GitHub, source, commits, experiments, or PRs. This file is a review artifact, not an amendment or approval.

## Executive assessment

**The PR is substantially faithful to the later approved architecture, but the early-decision evidence is more recoverable than its register claims.** The PR head matched the supplied candidate SHA. Eight documentation files were inspected: `README.md`, `docs/decisions/README.md`, `docs/requirements/POC-001.md`, three archived conversation extracts, and two archived charters.

The existing register treats **AD-001–AD-003 as wholly unrecoverable** and **AD-004–AD-008 as carry-forward summaries without original approval quotations**. Targeted retrieval of the original architectural discussion recovered identifiable decisions and contemporaneous user wording for all these areas, though **AD-002's final approval and complete historical alternatives for some early decisions remain unresolved**. The existing archive files need not be retroactively edited: add a new dated evidence supplement and amend the *active* decision index by review.

The PR correctly contains all **21 `POC-SCN-01`–`POC-SCN-21` acceptance criteria** and 21 completion-increment traceability rows; those are not missing. It also retains the previously extracted `EXP-003` and `EXP-004` scenario tables within `docs/archive/conversations/architecture-discovery.md`, along with substantial limitations concerning offline trust, SQL Server pooling, framework compatibility, native cancellation, and audit independence. The principal remaining work is approval provenance and traceability, not a rewrite of the accepted architecture.

### Evidence standard and limitations

| Marker | What it proves | Limitation |
|---|---|---|
| **R — retrieved original-message context** | Original user message text, assistant option summaries, and UTC message timestamps recovered from the earlier Data Source Manager architectural discussion through conversation-history retrieval. | Retrieval is selective. Some assistant options are short recovered summaries rather than their complete verbatim original prompt. Do not manufacture longer option text. |
| **V — directly visible original user message** | Approval text in the conversation from which the archive was extracted, e.g., AD-024/026/027/028 and EXP-003; reproduced in the archive. | A direct approval of a numbered decision is stronger than generic agreement or a later handoff. |
| **A — prior archival extraction** | Existing immutable conversation extraction under `docs/archive/conversations/` or the prior ChatGPT Library extract. | A later reconstructed archive is not itself a verbatim original transcript and can contain historical gaps now partly recoverable. |
| **G — GitHub candidate** | Exact PR documentation at the candidate SHA. | Documentation statements are compared with conversation evidence; no runtime behavior or experimental claims were tested. |

When a user message **asserts a requirement** without saying “approve,” the finding identifies it as a requirement assertion or user-selected direction, not a numbered direct approval. When the original assistant said a decision was recorded, that is recorded separately. No recovered fact is silently promoted to a user-ratified ADR. Times below are **UTC on November 15, 2026**, except references to later November 16 activity.

## Findings index

| ID | Area | Finding | Priority | Original authority |
|---|---|---|---|---|
| F-01 | AD-001 | Deployment-mode decision, options, and user selection can be recovered | High: history | User direction + assistant recording |
| F-02 | AD-002 | Original storage alternatives recoverable; no supported proof of selecting recommended option | High: approval ambiguity | Assistant proposal only; eventual disposition unresolved |
| F-03 | AD-003 | Managed vs customer-owned trust decision recoverable | High: history/security | User requirement + assistant recording |
| F-04 | Unnumbered | Explicit acceptance of **both** multiple credential stores and multiple profiles absent | High: requirement | Direct user selection, not safely mapped to AD-002 |
| F-05 | AD-004 | Three offline alternatives and approval wording recoverable | High: security/history | User explicit Option C + assistant AD-4 recording |
| F-06 | AD-005 | Identity alternatives and direct numbered approval recoverable | High: history | Direct numbered Option C |
| F-07 | AD-006 | Authentication alternatives and direct numbered approval recoverable | High: security/history | Direct numbered Option C |
| F-08 | AD-007A | Routing alternatives and direct numbered approval recoverable | High: history | Direct numbered Option C |
| F-09 | AD-007B | Topology alternatives and direct numbered approval recoverable | High: consistency/history | Direct numbered Option C |
| F-10 | AD-007C | Managed-versus-export alternatives and direct numbered approval recoverable | High: security/history | Direct numbered Option C |
| F-11 | AD-008 | Layered API alternatives and direct numbered approval recoverable | High: history | Direct numbered Option C |
| F-12 | EXP-004 | Blanket acceptance/delegation is overstated as a separate charter approval | Medium: provenance | Blanket acceptance, not separate finalized-charter ratification |
| F-13 | EXP-001–004 | Historical scenario obligations lack an active per-scenario traceability index | Medium: traceability | Approved planning scope; source-specific strengths vary |
| F-14 | POC-SCN-09 | Standalone scenario text can imply impossible immediate offline revocation knowledge | Medium: security clarity | Qualified by AD-014/018 and POC charter |

## Detailed findings and recommended documentation corrections

### F-01 — AD-001: original deployment decision is no longer wholly unknown

**Current PR:** `docs/decisions/README.md`, decision inventory row `AD-001`, says “Not recoverable / Inherited approval; original individual content unavailable.” The archived discovery extraction likewise says Decisions 1–3 are unavailable.

**Original discussion evidence (R):** At **20:52:46Z**, the assistant presented **Architecture Decision 1** with three alternatives: **A, both desktop and server applications (recommended); B, server-only; C, desktop-only.** At **20:55:52Z**, Jim replied: **“The library should support both desktop and server applications. Continue architecture discovery with the next decision.”** At **20:56:02Z**, the assistant expressly acknowledged **“Decision 1 approved”**, adding a provider-neutral design and provider-qualified Windows/Linux/macOS direction.

**Meaning:** A concrete user selection and assistant-recorded approval are recoverable, but the user's reply did **not** literally say “I approve Architecture Decision 1, Option A.” The recovered alternatives are abbreviated historical labels, not a claim to reproduce the complete original prompt.

**Correction:** Replace the “not recoverable” row with **“AD-001 — deployment/application host scope: both desktop and server; user-selected recommendation, recorded approved by assistant.”** Add the three recovered short alternatives and user quotation in a provenance appendix. Link to AD-019 and AD-034: the earlier provider-qualified aspiration toward macOS **does not override** the later explicit **.NET Framework 4.8/Windows**, **.NET 10/Windows+Linux**, and further-qualification framework/OS matrix. Preserve the distinction between an application type requirement and a runtime support promise.

**Related requirement/scenario (later links, not original mappings):** Both interactive and unattended consumers; `POC-SCN-04`, `POC-SCN-21`; `EXP-004 SCN-016`–`SCN-020`. **Supersession:** No identified repeal of desktop/server support; later AD-019/034 constrain claims of platform support.

### F-02 — AD-002: proposed configuration/credential storage alternatives found, final disposition not proven

**Current PR:** `docs/decisions/README.md` labels AD-002 “Not recoverable,” yet its introductory sentence says all AD-001–035 were affirmed/approved. The archive does not include the first proposed AD-002 alternatives.

**Original discussion evidence (R):** At **20:56:02Z**, the assistant introduced **“Architecture Decision 2: Configuration and Credential Storage”** with **A — pluggable storage (recommended); B — built-in SQLite storage; C — consumer-managed storage**. At **21:03:52Z**, rather than affirming A/B/C, Jim described the existing **XML/XSD/DataTable-based manager**, central configuration, distributed protected credentials, and offline cache use and asked to reconsider the design. A subsequent **21:04:15Z** assistant summary framed a redesigned separation of central configuration management, credential management, and client library. **No original user message selecting A, B, or C for this initial numbered proposal was recovered.**

**Correction:** Record **AD-002 proposed topic and original alternatives** but mark **“original choice/final approval not independently recovered; later redesigned architecture superseded or refined the *initial proposal*, exact decision succession unresolved.”** Do **not** infer “Option A approved” merely because the assistant recommended it; do **not** assign the later multiple-stores/multiple-profiles Option C to AD-002 without the missing numbered link. The aggregate later handoff “Decisions 1–33 complete” remains evidence of an inherited approved baseline, not a substitute for this missing individual disposition.

**Related requirement/scenario:** Separation of configuration and secret storage; later AD-006/009/010/011, `POC-SCN-05`–`POC-SCN-08`. **Supersession:** Initial storage proposal appears to have been reframed after the existing-system discussion; no formal supersession ID verified.

### F-03 — AD-003: managed/customer-owned deployment trust model recovered

**Current PR:** The AD-003 inventory row says the subject and individual content are unavailable; security sections document trust-tier requirements generically without restoring the original decision provenance.

**Original discussion evidence (R):** At **21:23:30Z**, Jim stated: **“The library must support both trusted managed systems and customer-owned systems. Continue the architecture discussion, explain the security implications, and ask the next question.”** At **21:23:52Z**, the assistant responded **“(Decision 3 recorded)”** and described support for both organization-managed and customer-owned systems, warning that machines are not equally trustworthy. The managed path could use approved workload identity and a protected cache; customer-owned endpoints require distinct identity/trust boundaries and preferably brokered or server-side handling for sensitive operations.

**Meaning:** This is a **direct requirement assertion plus assistant-recorded numbered decision**, **not** a direct user quotation approving “AD-003 Option C.” The retrieved next prompt concerns offline access choices subsequently approved as AD-004; those alternatives **must not** be misattributed to AD-003.

**Correction:** Fill AD-003 as **“managed and customer-owned deployment trust model,”** attribute its authority correctly, and state that original alternative sets/numbered user vote are not recovered. Cross-reference AD-004/011/013/018/019 and the existing source charter's explicit impossibility limit for a fully compromised customer-controlled host.

**Related requirement/scenario:** Different device trust tiers, credential exposure, device binding, and fail-closed protection; `POC-SCN-07`–`POC-SCN-10`, `EXP-002` workstreams A/B. **Supersession:** Later decisions strengthen device-specific restrictions; none is demonstrated to negate support for customer-owned clients.

### F-04 — unnumbered early choice: separate multiple credential stores and multiple connection profiles

**Current PR:** No inspected PR file contains the phrases “multiple credential stores” or “multiple connection profiles,” even though its provider/authentication architecture is compatible with this requirement. AD-002 and AD-006 do not preserve this historical distinction explicitly.

**Original discussion evidence (R):** At **21:29:58Z**, Jim chose: **“I choose Option C: support both multiple credential stores and multiple connection profiles, keeping the abstractions separate. Continue architecture discovery.”** The recovered options for this later question were **A — multiple credential stores; B — multiple connection profiles; C — both**. The assistant recorded that choice in its continuation. The available evidence **does not establish the question's numbered AD identifier**; specifically, it does not prove this was the original AD-002 storage vote.

**Correction:** Add a provenance entry **“Accepted architectural requirement — original decision ID unverified”** under early architecture source evidence. Record plural independent credential stores, plural connection profiles, and the boundary separating the two; cross-reference AD-006 (strategies distinct from stores), AD-009/010 (profile configuration), and AD-011–013 (credential distribution/lifecycle). Do not invent an `AD-` ID or a new historical `SCN-` ID.

**Related requirement/scenario:** Multiple-store/multiple-profile association and policy-aware secret resolution. Existing `POC-SCN-05`–`POC-SCN-08` exercise adjacent boundaries, **but none explicitly verifies several stores and several profiles concurrently**. Mark that exact acceptance coverage as a **deferred/unmapped requirement**, not a POC defect or newly approved POC criterion.

### F-05 — AD-004: original offline-policy alternatives and acceptance recovered

**Current PR:** AD-004 is marked “Carry-forward approval; no direct original quote,” with no original alternatives in `docs/decisions/README.md` or archived extraction.

**Original discussion evidence (R):** At **21:30:10Z** the assistant offered **A — cache configuration only, central access for new credential-dependent connections; B — protected config/credential caching for offline access, accepting delayed revocation; C — policy-driven per-profile offline access under organization restrictions (recommended)**. At **21:31:03Z**, Jim wrote: **“I approve offline policy Option C: configurable per-profile offline policies, subject to organization-wide restrictions, with conservative defaults on customer-owned systems. Continue architecture discovery.”** At **21:31:23Z**, the assistant marked **“Architecture Decision 4 approved”**, explicitly recording default **online authorization for centrally managed credentials on customer-owned systems**, with only policy-approved exceptions.

**Correction:** Upgrade evidence category to **“direct user Option C approval (without the numeric ID in the user sentence), mapped by the immediate assistant AD-4 acknowledgment.”** Include the shortened original alternatives, direct quote, and conservative customer-owned default. Preserve AD-014/016/018 refinements: **cached configuration never equals perpetual authorization**, centrally managed acquisitions require valid grants, no automatic expiry grace, customer-owned clocks cannot magically provide trustworthy rollback resistance.

**Related requirement/scenario:** Offline-policy scope; `EXP-002 SCN-04`, `SCN-05` in the later charter summary; `POC-SCN-06`, `POC-SCN-09`. **Supersession:** AD-014/016/018 refine but no explicit replacement of AD-004.

### F-06 — AD-005: identity and authorization has a direct numbered vote

**Current PR:** AD-005 says “Carry-forward approval; no direct original quote” and omits alternatives.

**Original discussion evidence (R):** The assistant at **21:31:23Z** presented **A — user identity (OIDC/OAuth2, interactive-client emphasis); B — application/workload identity (service/managed identity/certificate emphasis); C — policy-driven identity that can require either or both**. At **22:08:24Z**, Jim approved: **“I approve Architecture Decision 5, Option C: policy-driven authentication supporting user identity, application identity, and both when required. Keep authentication provider-neutral and enforce organization and profile authorization.”**

**Correction:** Classify as a **direct numbered Option C approval**, add the recovered alternatives, and distinguish identity of the *requesting user/application* and its organization/profile authorization from the **provider connection-authentication mechanism** decided in AD-006. Do not imply one universal authorization identity or credential flow.

**Related requirement/scenario:** Per-profile identity and authorization; `EXP-004 SCN-004`–`SCN-005`, `POC-SCN-07`. **Supersession:** AD-006, AD-009/011 and AD-029 specialize, not repeal, the chosen identity policy.

### F-07 — AD-006: provider-authentication alternatives and direct approval recovered

**Current PR:** AD-006 is summarized as provider-appropriate auth with no original quote or alternatives.

**Original discussion evidence (R):** At **22:08:43Z**, the assistant considered **A — centrally managed credentials; B — individual identity connections (integrated auth/OAuth/workload identity); C — multiple strategies by connection profile**, covering shared/user-specific secrets, integrated auth, OAuth/delegation, workload identities, certificates, and passwordless options where supported. At **22:09:57Z**, Jim approved: **“I approve Architecture Decision 6, Option C: multiple authentication strategies per connection profile, including shared credentials, user-specific credentials, integrated authentication, certificates, and passwordless identities where supported. Keep authentication strategies separate from credential stores and enforce security policies. Continue architecture discovery.”**

**Correction:** Promote to **direct numbered approval**; restore shorter alternative summaries and the separate **authentication-strategy vs credential-store** boundary. Explicitly qualify optional methods by provider/OS/runtime capability and authorization; a listed auth method is **not** a universal compatibility guarantee.

**Related requirement/scenario:** Configurable per-profile auth selection, no credential-policy bypass; `EXP-003 SCN-008`, `EXP-004 SCN-019`, `POC-SCN-07`, `POC-SCN-08`, `POC-SCN-12`. **Supersession:** Later AD-011–013 add credential distribution/rotation/protection; no reversal found.

### F-08 — AD-007A: routing ownership options and direct vote recovered

**Current PR:** AD-007A/B/C are compressed into one inventory row with “carry-forward approvals”; the original 7A alternatives and approval evidence are not represented.

**Original discussion evidence (R):** At **22:13:08Z**, assistant options were **A — provider-native routing; B — library-managed routing; C — hybrid, provider-native first**. At **22:14:50Z**, Jim approved: **“I approve Architecture Decision 7A, Option C: hybrid provider-native-first routing, with provider-neutral routing and resilience policies and library-managed implementations only where appropriate.”**

**Correction:** Give `AD-007A` a separate subdecision row and evidence paragraph; restore the three alternative labels and direct numbered approval. Explain that **library-managed routing is conditional**, not a mandatory replacement for native failover. Link later AD-023 algorithms and AD-024 consistency policy.

**Related requirement/scenario:** Routing delegation, provider-native preference; `EXP-003 SCN-001`–`SCN-003`. **Supersession:** AD-023/024 add constraints without expressly superseding 7A.

### F-09 — AD-007B: topology choices and phased implementation recovered

**Current PR:** Combined AD-007 inventory does not show why advanced independent-database routing and sharding were deferred; the archive has only an analytical summary.

**Original discussion evidence (R):** At **22:15:10Z**, the assistant compared **A — coordinated topologies first (standalone, active/passive, primary/read-replica); B — all topologies up front, including independently writable databases and partition-aware routing; C — extensible topology that delivers the A cases first, allows provider-managed multi-primary where safe, and defers sharding/independent routing**. At **22:15:38Z**, Jim approved: **“I approve Architecture Decision 7B, Option C: an extensible topology model with safe coordinated topologies implemented first, provider-managed multi-primary support where appropriate, and future extensibility for independent databases and sharding.”**

**Correction:** Add an `AD-007B` individual row, original choice comparison, direct approval, and **explicit deferral** for independent-database/partition-aware routing and sharding. Clarify that provider-managed multi-primary is conditional on provider guarantees; no blanket library-managed multi-writer promise. Cross-reference AD-024 replica freshness/affinity and AD-023 routing algorithms.

**Related requirement/scenario:** `EXP-003 SCN-001`–`SCN-005`. **Supersession:** None; later routing/consistency decisions make this topology policy more restrictive.

### F-10 — AD-007C: raw connection-string export is an exceptional escape hatch

**Current PR:** One combined AD-007 row and archive summary note managed connections and explicit export, but omit the original alternatives and individual approval evidence. The high-level charter emphasizes typed leases without highlighting the **export exception** in its core summary.

**Original discussion evidence (R):** At **22:15:51Z**, assistant compared **A — connection strings first; B — managed connections only; C — managed connections plus explicitly authorized export**. At **22:16:32Z**, Jim approved: **“I approve Architecture Decision 7C, Option C: managed connections as the primary API, with explicitly authorized connection-string export and clear disclosure of routing limitations.”**

**Correction:** Give AD-007C a standalone record with direct numbered approval; maintain **managed policy-controlled leases as default**, with raw connection-string export **only under explicit authorization** and documented inability to enforce routing, lease, telemetry, and lifecycle controls after export. Cross-reference AD-028 rather than treating raw export as a parallel default API. The implementation behavior of export is **not proven by POC-001**, and there is no corresponding original EXP-004 scenario explicitly testing the export exception; carry it as a deferred acceptance obligation without fabricating a new approved scenario ID.

**Related requirement/scenario:** AD-028; `EXP-004 SCN-001`, `SCN-002`, `SCN-011`–`SCN-015`; POC lease tests `POC-SCN-11`, `POC-SCN-13` are adjacent only. **Supersession:** AD-028 clarifies lifecycle responsibility; does not remove the explicit authorized-export exception.

### F-11 — AD-008: layered capability API choices and direct vote recovered

**Current PR:** AD-008 is only “Layered capability API / carry-forward approval,” with no original alternatives or user quote.

**Original discussion evidence (R):** At **22:16:44Z**, assistant proposed **A — connection-management-only API; B — comprehensive provider-operation APIs in the manager; C — layered, capability-based API with a focused core and optional provider operational extensions**. At **22:17:03Z**, Jim approved: **“I approve Architecture Decision 8, Option C: layered capability-based APIs, with a focused connection-management core and optional provider-specific operational capabilities.”**

**Correction:** Mark direct numbered Option C approval, restore alternative labels and rationale, and make explicit that **provider-specific features are optional independent extensions**, not all mandatory in the dependency-free core. Preserve distinction between typed `DbConnection` where appropriate and typed FTP/SFTP/SMTP/SMB resources, as already described in the source charter. Link AD-028/029 capability reporting and trusted registration.

**Related requirement/scenario:** `EXP-004 SCN-001`–`SCN-005`, `SCN-010`; `POC-SCN-01`–`POC-SCN-03`, `POC-SCN-11`. **Supersession:** AD-028/029 refine the chosen model; no repeal found.

### F-12 — EXP-004 approval strength is presented too broadly

**Current PR:** `docs/archive/charters/architecture-and-poc-execution-charter.md` §1.1 says `EXP-001`–`EXP-004` charters were **approved for planning**; §5.1 calls the EXP-004 scenarios “approved 20 scenarios.” The active decision index references the archived experiments as approved. The archived discovery extraction, however, preserves an important narrower distinction.

**Original discussion evidence (V/A):** Jim stated **“I accept all your remaining recommendations”** after the AD-028 decision and recommendation to continue architectural discovery. The assistant then formulated AD-029–033 and the `EXP-004` four-workstream/20-scenario charter. The archived discovery record explicitly states: **“No separate user message explicitly approves that finalized charter.”** Conversely, the source conversation contains the expressly numbered approval for EXP-003: **“I approve the consolidated EXP-003 experiment charter, including its four workstreams, 20 acceptance scenarios ... Keep EXP-003 unexecuted.”**

**Correction:** In **new active explanatory documentation**, distinguish **“EXP-003 explicitly approved for planning, unexecuted”** from **“EXP-004 assistant-consolidated under prior blanket acceptance/standing delegation; no separate finalized-charter ratification on record.”** Avoid reinterpreting the blanket acceptance as a later verbatim signature on the 20 scenarios. The broad program/POC-001 charter was later approved, but that is a distinct event and does not retroactively create missing individual EXP-004 approval text.

**Related requirement/scenario:** `EXP-004 SCN-001`–`SCN-020` (archived, not executed). **Revision/supersession:** POC-001 selects a smaller proof subset and defers the remainder; does not erase the EXP-004 plan. No separate superseding EXP-004 charter approval found.

### F-13 — historical experiment scenarios exist in archive but lack active original-to-POC traceability

**Current PR:** The active `docs/requirements/POC-001.md` accurately preserves **exactly 21 POC acceptance scenarios** and their 21 completion-increment rows. The source charter §5.1 enumerates historical scenario **summaries**, and the archived discovery extraction records exact `EXP-003 SCN-001`–`SCN-020` and `EXP-004 SCN-001`–`SCN-020` content. However, no active table traces **each original experiment scenario** to `POC-SCN-*`, a `D-*` deferral, or “unmapped/not yet scheduled.” The EXP-001 original IDs and exact EXP-002 original charter statements were not fully recoverable.

**Original discussion evidence (V/A):** Jim explicitly approved the `EXP-003` charter's **four workstreams, 20 acceptance scenarios, research-first approach, evidence requirements, stopping conditions, completion criteria, and exclusions**, and directed **“Keep EXP-003 unexecuted.”** EXP-002 was expressly approved with **four workstreams and 12 scenarios** but the earlier extraction warns that full original statements and specific mappings were unavailable. The `EXP-004` exact 20 scenarios were later documented under assistant delegation, with the approval caveat in F-12.

**Correction:** Add a separate **historical experiment-to-POC traceability index** while preserving all original experiment IDs and using their parent experiment to disambiguate duplicated `SCN-001` labels. For each known scenario, link to existing `POC-SCN-*` only when the criteria actually match, or identify a current `D-*` obligation / “unmapped, not executed.” List the seven EXP-001 thematic cases as **unnumbered**, and EXP-002 `SCN-01`–`SCN-12` as **summary-level evidence requiring original-charter verification**, not newly invented exact acceptance text. Do not imply the POC's 21 scenarios are the sum total of future product requirements.

**Related requirement/scenario:** `EXP-001` unnumbered thematic cases, `EXP-002 SCN-01`–`SCN-12`, `EXP-003 SCN-001`–`SCN-020`, `EXP-004 SCN-001`–`SCN-020`; `POC-SCN-01`–`POC-SCN-21`; `D-01`–`D-20`. **Status:** Documentation trace gap, **not** omitted POC scenarios or experiment-execution evidence.

### F-14 — clarify “revoked” grant in the standalone offline acceptance criterion

**Current PR:** `docs/requirements/POC-001.md` `POC-SCN-09` requires denial for an “expired, invalid-signature, revoked, rollback-detected or unverifiable-time offline grant.” The **full charter elsewhere** properly explains that an offline device cannot observe newly issued remote revocations; the stand-alone requirements page does not repeat that exact distinction. A reader could incorrectly infer immediate revocation knowledge on a disconnected, untrusted customer machine.

**Original discussion evidence (V/A):** AD-014 selected strict offline expiration without an implicit grace; AD-018 requires signed grants/protected time evidence **only where the trust anchor can be verified**, and fail-closed behavior when required time confidence is unavailable. The original charter §11 explicitly says: **“Immediate server revocation cannot reach disconnected clients; previously issued grants remain potentially usable until expiry absent a trusted online check.”** The charter §1.2 also states that an ordinary user-space library cannot guarantee perfect clock integrity or immediate offline revocation on a compromised host.

**Correction:** Add a non-normative qualification adjacent to `POC-SCN-09`: **“‘Revoked’ means revocation already known to the client or verified through a trusted authorization source; the POC does not promise detection of a *new* remote revocation while genuinely disconnected. Offline access remains strictly bounded by verifiable grant expiry and the stated device/time trust assumptions.”** Preserve the test's current exact approved wording as an immutable quoted criterion; append the clarification outside the approved acceptance cell unless Jim formally approves a changed criterion.

**Related requirement/scenario:** `POC-SCN-06`, `POC-SCN-09`; `EXP-002 SCN-04`–`SCN-05` summary; AD-003/004/011/014/018. **Supersession:** None; clarification resolves an ambiguous read of existing criteria rather than weakening or changing security policy.

## Checked and correctly preserved — not findings

1. **Candidate identity:** PR #2 is open, not merged, and the observed `head_sha` is exactly `c3c691b42556261a9a73e5dab0bce788682956b9`.
2. **POC criteria:** The complete numbered `POC-SCN-01`–`POC-SCN-21` sequence and 21 scenario/increment rows are present. `REQ-01`–`REQ-20` and `D-01`–`D-20` are correctly identified as **new charter traceability aliases**, not recovered legacy requirement IDs.
3. **AD-025:** The later user objection to a core Polly dependency, Microsoft-versus-Polly clarification, and conversational **“Agreed”** are appropriately distinguished from a direct numbered AD-025 vote; the no-Polly core design is recorded.
4. **AD-029–AD-033:** The register correctly differentiates AD-029 blanket acceptance from AD-030–033 assistant selection under standing delegation; none of these is falsely presented in the decision inventory as an individual direct numbered user quote.
5. **AD-034/AD-035:** The archive accurately keeps the original *proposed* text and documents the **later owner approval**. AD-035 remains **optional pool coordination over provider-native pools**, not permission for an invented physical pool or immediate implementation. `POC-SCN-20` only compares a **test-harness targeted `SqlConnection.ClearPool`** against native recovery.
6. **Compatibility:** .NET Framework 4.8 on Windows and .NET 10 on Windows/Linux are the primary supported/qualification baseline; .NET 11 requires qualification, .NET 8 is best effort, .NET 6 unsupported, and macOS/ARM need separate proof. The PR correctly requires **real consumer validation**, not build-only claims.
7. **Failure/security:** The charters preserve acquisition-only bounded retries, no unsafe replay after uncertain SQL commit, failure-domain-aware breakers, nonfatal telemetry export, separate mandatory security audit, fail-closed protected time, and truthful limitations on terminating native/checked-out operations.
8. **Scope:** EXP-001–EXP-004 are planning and **unexecuted**. This PR is documentation only; it does not establish production authorization, implementation completion, or a relationship to the separate Analytics Dashboard repository.

## Proposed documentation update sequence (a recommendation, not an authorized change)

1. **Add an immutable “Recovered early decisions and approval evidence” supplement** containing the exact user quotations and timestamps above; identify shorter assistant alternative summaries as such. Do not rewrite the five archived Library-source documents as if they were original transcripts.
2. **Amend `docs/decisions/README.md`** to split AD-007A/B/C, add AD-001/003/004–008 recovered content and approval classifications, and mark AD-002's initial recommendation **unratified in available original evidence** pending further history recovery.
3. **Record the separately accepted multiple-stores/multiple-profiles requirement** as a distinct, unnumbered historical source item; do not force it into AD-002 without primary proof.
4. **Add a historical EXP scenario trace appendix**; keep exact known identifiers, distinguish summarized or unknown originals, and show remaining obligations as unexecuted/deferred.
5. **Add one adjacent clarification to `POC-SCN-09`** concerning *known* versus unreachable offline revocation without silently changing the owner-approved scenario wording.
6. Preserve later AD-019/023/024/028/034/035 qualifiers, original approval-strength categories, and the separate owner gate for any implementation or experiment execution.

## Reference links

- [PR #2](https://github.com/infoconex/datasource-manager/pull/2)
- [Decision register at reviewed SHA](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/decisions/README.md)
- [POC-001 requirement/scenario table at reviewed SHA](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/requirements/POC-001.md)
- [Archived architectural-discovery extraction at reviewed SHA](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/architecture-discovery.md)
- [Consolidated architecture/POC charter at reviewed SHA](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/charters/architecture-and-poc-execution-charter.md)
- [POC engineering kickoff charter at reviewed SHA](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/charters/poc-001-engineering-kickoff-charter.md)

**Review conclusion:** Request **documentation provenance corrections before relying on PR #2 as a historically complete decision record**. This does not constitute an objection to the approved product architecture or the 21 approved POC acceptance criteria. The key unresolved primary question is AD-002's final individual approval/disposition; preserve that uncertainty until the actual original decision thread is available.