# Data Source Manager — PR #2 Architecture Evidence Review

**Review date:** 2026-11-15 (America/Los_Angeles)  
**Repository:** https://github.com/infoconex/datasource-manager  
**PR:** https://github.com/infoconex/datasource-manager/pull/2  
**Candidate SHA verified:** `c3c691b42556261a9a73e5dab0bce788682956b9`  
**Scope:** Documentation and approval-history review only; no GitHub changes or experiment execution.

## Summary and method

At review time PR #2 was **open** and its head matched the requested immutable SHA. Its **eight changed documentation files** were read at that SHA. The active requirement file preserves all **21** `POC-SCN-01` through `POC-SCN-21` scenarios, and all 21 scenario-to-increment rows. Nothing in this review alleges that a POC ran or that a provider was verified.

**Overall assessment:** The later architecture and POC scope are represented accurately in substance. The significant deficiencies are **historical provenance for AD-001–AD-008**, one omitted explicit early requirement, ambiguous EXP-004 approval strength, incomplete historical experiment-scenario traceability, and one offline-revocation wording qualification.

### Evidence/provenance labels

- **U — original user message recovered from conversation history.** This gives the user's expressed choice, but does not necessarily mean a numbered formal vote.
- **A — original assistant prompt or contemporaneous recording recovered from history.** Option descriptions below are abbreviated to the extent recovered, not presented as full original wording.
- **X — existing archived conversation extraction at the candidate SHA.** An extraction is a later synthesis, not necessarily a verbatim complete chat.
- **G — actual PR file at the candidate SHA.** This shows what the proposed GitHub documentation currently claims.

History retrieval was selective. In particular, **AD-002 has no independently recovered final individual vote**. The user's later acknowledgment that the AD-001–033 baseline was established does not manufacture a missing original approval transcript. No new historical decision ID, alternative, requirement ID, or acceptance-scenario ID is assigned here.

## Finding index

| Finding | Decision / area | Assessment | Required correction |
| --- | --- | --- | --- |
| F01 | AD-001 | Original topic, alternatives and selected direction recoverable | Restore early user direction and precise approval strength |
| F02 | AD-002 | Original alternatives recoverable; final individual choice unresolved | Document the proposal without claiming its recommended option won |
| F03 | AD-003 | Managed/customer-owned trust requirement recoverable | Restore the trust distinction and recorded status |
| F04 | Unnumbered early requirement | Both multiple stores **and** multiple profiles omitted | Record as an accepted, unnumbered requirement |
| F05 | AD-004 | Offline options and explicit Option C choice recoverable | Restore direct approval and conservative defaults |
| F06 | AD-005 | Direct numbered Option C approval recoverable | Restore identity alternatives and distinct authorization boundary |
| F07 | AD-006 | Direct numbered Option C approval recoverable | Restore auth alternatives and store/strategy separation |
| F08 | AD-007A | Direct approval of native-first hybrid routing recoverable | Give the subdecision its own evidence row |
| F09 | AD-007B | Direct approval of phased topology support recoverable | Restore topology deferrals and conditional multi-primary |
| F10 | AD-007C | Direct approval of guarded connection-string export recoverable | Preserve escape-hatch restrictions and limitations |
| F11 | AD-008 | Direct layered-capability approval recoverable | Restore core/extension rationale and alternatives |
| F12 | EXP-004 | Planning approval is portrayed more categorically than original evidence | Distinguish blanket delegation from individual charter ratification |
| F13 | EXP-001–004 | Original scenarios exist partly in archives but lack active itemized disposition | Trace to POC/deferred/unmapped, retaining original IDs |
| F14 | POC-SCN-09 | Standalone wording could imply instantaneous offline revocation | Clarify known versus unreachable revocation without altering approved wording |

## Detailed findings

### F01 — AD-001: deployment/application scope

**Problem:** Scope of desktop versus server consumers. **Alternatives (A, 20:52:46Z):** A = desktop and server (recommended); B = server only; C = desktop only.

**Original evidence (U, 20:55:52Z):** Jim: “The library should support both desktop and server applications. Continue architecture discovery with the next decision.” **Contemporaneous assistant response (A, 20:56:02Z):** “Decision 1 approved.” The user selected a clear direction but did not literally state a numbered Option A approval.

**GitHub gap (G):** `docs/decisions/README.md` calls AD-001 wholly “Not recoverable.” **Correction:** Record *both desktop and server applications*, all three shortened options, the exact user direction, and **user selection + assistant-recorded approval**. Link to AD-019/AD-034; desktop support does not independently certify every operating system or framework. **Related later verification:** `POC-SCN-04`, `POC-SCN-21`; EXP-004 framework/consumer cases. **Revision:** Platform/runtime qualification in AD-019/034 narrows unsupported compatibility assumptions, not the core desktop/server requirement.

### F02 — AD-002: configuration and credential storage

**Problem:** Who owns configuration/credential storage. **Original proposed alternatives (A, 20:56:02Z):** A = pluggable storage (recommended); B = built-in SQLite; C = consumer-managed storage.

**Original evidence (U, 21:03:52Z):** Instead of voting for A, B or C, Jim explained the existing XML/XSD/DataTable configuration manager, encrypted credential distribution and local offline cache, and requested a reassessment. **Assistant continuation (A, 21:04:15Z):** Reframed central configuration management, credential management, and the consuming library.

**GitHub gap (G):** AD-002 is “Not recoverable” even though its original question and alternatives are partly known. The register's blanket “approved baseline” is **not** independent evidence that the original proposed A was chosen. **Correction:** Name the original proposal and alternatives, record the user-requested redesign, and mark **final individual disposition unverified**. Link later AD-006/009–013 as subsequent refinements. Do **not** conflate F04's separate Option C with this numbered question. **Adjacent POC:** `POC-SCN-05`–`08`; exact original AD-002 acceptance IDs not established.

### F03 — AD-003: managed and customer-owned trust tiers

**Problem:** A single trust model cannot safely cover managed hosts and customer-controlled devices.

**Original evidence (U, 21:23:30Z):** Jim: “The library must support both trusted managed systems and customer-owned systems. Continue the architecture discussion, explain the security implications, and ask the next question.” **Assistant (A, 21:23:52Z):** “Decision 3 recorded,” then distinguished managed workload identity/protected caches from customer-owned trust and exposure limits. Original AD-003 alternatives and a numbered user vote were **not** recovered.

**GitHub gap (G):** Register says AD-003's subject is unrecoverable. **Correction:** Restore this direct requirement and **assistant-recorded decision**, explicitly stating that a hostile customer-owned device cannot be treated as a trusted security boundary. Cross-reference AD-004/011/013/018/019. **Related:** `POC-SCN-07`–`10` and EXP-002 trust/credential workstreams. **Revision:** Later decisions add safeguards; no verified withdrawal of customer-owned support.

### F04 — unnumbered accepted requirement: plural stores and profiles

**Problem:** Independent management of credentials and connection profiles, including more than one instance of each.

**Original evidence (U, 21:29:58Z):** Jim: “I choose Option C: support both multiple credential stores and multiple connection profiles, keeping the abstractions separate. Continue architecture discovery.” **Alternatives (A):** A = multiple credential stores; B = multiple connection profiles; C = both. The assistant immediately recorded the selection; **the original numbered AD association is not recovered**.

**GitHub gap (G):** None of the eight changed PR files contains the explicit requirement “multiple credential stores” or “multiple connection profiles.” **Correction:** Add an **accepted unnumbered architectural requirement** with the original quote and separate abstractions, cross-linked to AD-006 and AD-009–013. Do not assign it to AD-002 by inference. Existing `POC-SCN-05`–`08` test adjacent storage/security properties, but none explicitly proves simultaneous multiple stores and profiles; mark specific acceptance coverage **unmapped/deferred**, not failed or silently satisfied.

### F05 — AD-004: offline policy by profile and trust tier

**Problem:** Make centrally managed resources usable offline where authorized without converting cached configuration into unlimited permission.

**Alternatives (A, 21:30:10Z):** A = cache config only, require central credential authorization; B = cache protected config/credentials and accept delayed revocation; C = per-profile offline policy constrained by organization policy (recommended).

**Original evidence (U, 21:31:03Z):** “I approve offline policy Option C: configurable per-profile offline policies, subject to organization-wide restrictions, with conservative defaults on customer-owned systems. Continue architecture discovery.” The assistant's next response recorded **AD-004 approved**, with default online authorization for customer-owned, centrally managed credentials.

**GitHub gap (G):** Register labels this a carry-forward approval with no direct original quote. **Correction:** Upgrade to **direct Option C approval linked by contemporaneous AD-004 assistant acknowledgment**; include original alternatives and conservative customer-owned default. Preserve AD-014/016/018 limits: no implicit grace, separate authorization grants, and fail-closed unverifiable time. **Related:** `POC-SCN-06`, `09`; EXP-002 offline cases. **Revision:** Later policies strengthen rather than repeal AD-004.

### F06 — AD-005: requesting identity and authorization

**Problem:** Support users, services, and operations requiring both principals. **Alternatives (A, 21:31:23Z):** A = user identity; B = application/workload identity; C = policy-driven either/both.

**Original evidence (U, 22:08:24Z):** “I approve Architecture Decision 5, Option C: policy-driven authentication supporting user identity, application identity, and both when required. Keep authentication provider-neutral and enforce organization and profile authorization.” This is a **direct numbered approval**.

**GitHub gap (G):** Register currently says carry-forward/no direct quote. **Correction:** Restore three alternatives, direct wording, and the distinction between **caller identity/organization-profile authorization** (AD-005) and **provider connection authentication** (AD-006). **Related:** `POC-SCN-07`; EXP-004 authorization cases. **Revision:** AD-006/009/011/029 refine, not supersede.

### F07 — AD-006: provider connection-authentication strategies

**Problem:** Providers vary in shared/user-specific credentials, integrated auth and identity mechanisms. **Alternatives (A, 22:08:43Z):** A = centrally managed secrets; B = individual/integrated identity; C = multiple strategies per profile.

**Original evidence (U, 22:09:57Z):** “I approve Architecture Decision 6, Option C: multiple authentication strategies per connection profile, including shared credentials, user-specific credentials, integrated authentication, certificates, and passwordless identities where supported. Keep authentication strategies separate from credential stores and enforce security policies. Continue architecture discovery.” **Direct numbered approval.**

**GitHub gap (G):** Carry-forward/no direct quote; original choices missing. **Correction:** Restore alternatives, approval, *strategy versus store* separation, and provider/OS/runtime qualification for certificate, OAuth and passwordless methods. **Related:** `POC-SCN-07`, `08`, `12`; EXP-003/004 auth cases. **Revision:** AD-011–013 add distribution, rotation and cache protections; none removes strategy flexibility.

### F08 — AD-007A: routing ownership

**Problem:** Avoid replacing a provider's own failover semantics with generic manager routing. **Alternatives (A, 22:13:08Z):** A = native routing; B = library-managed routing; C = provider-native-first hybrid.

**Original evidence (U, 22:14:50Z):** “I approve Architecture Decision 7A, Option C: hybrid provider-native-first routing, with provider-neutral routing and resilience policies and library-managed implementations only where appropriate.” **Direct numbered subdecision approval.**

**GitHub gap (G):** AD-007A/B/C combined and all called carry-forward. **Correction:** Add separate **AD-007A** entry, three alternatives, the quote, and explicit *conditional* library routing. Link AD-023/024 and EXP-003 routing scenarios. **Revision:** Later policies constrain routing, do not reverse native-first preference.

### F09 — AD-007B: topology boundaries and deferral

**Problem:** Differentiate safely coordinated failover from unsafe general sharding/multi-writer assumptions. **Alternatives (A, 22:15:10Z):** A = coordinated topologies first; B = all topologies including independent databases/sharding immediately; C = extensible model with coordinated topologies first, conditional provider-managed multi-primary, future independent/sharded options.

**Original evidence (U, 22:15:38Z):** “I approve Architecture Decision 7B, Option C: an extensible topology model with safe coordinated topologies implemented first, provider-managed multi-primary support where appropriate, and future extensibility for independent databases and sharding.” **Direct numbered subdecision approval.**

**GitHub gap (G):** Combined AD-007 row obscures the phased rationale. **Correction:** Add **AD-007B** with original alternatives and direct approval; explicitly defer independent database/sharding support and condition multi-primary on native/provider guarantees. Link AD-023/024, EXP-003 topology/consistency cases. **Revision:** AD-024 adds stricter consistency/affinity, not blanket multiwriter support.

### F10 — AD-007C: managed acquisition and authorized raw export

**Problem:** Preserve manager enforcement while permitting a controlled exceptional raw connection-string use case. **Alternatives (A, 22:15:51Z):** A = connection-string-first; B = managed connections only; C = managed primary plus authorized export.

**Original evidence (U, 22:16:32Z):** “I approve Architecture Decision 7C, Option C: managed connections as the primary API, with explicitly authorized connection-string export and clear disclosure of routing limitations.” **Direct numbered subdecision approval.**

**GitHub gap (G):** Combined AD-007 row and archive summary mention export without original evidence and with limited prominence in active contracts. **Correction:** Give **AD-007C** a separate entry; make raw export expressly **exceptional and authorized**, and disclose loss of enforceable routing, lease lifecycle, monitoring and policy controls once a client holds exported material. AD-028 typed leases refine the managed default; they do not repeal the export exception. `POC-SCN-11`/`13` cover leases, **not** raw-export authorization; preserve the latter as deferred/unmapped acceptance.

### F11 — AD-008: layered capability API

**Problem:** Keep the core focused without pretending databases, file-transfer sessions, SMTP and SMB all expose identical operations. **Alternatives (A, 22:16:44Z):** A = manager-only connection API; B = comprehensive provider operations in the manager; C = layered core plus optional provider capabilities.

**Original evidence (U, 22:17:03Z):** “I approve Architecture Decision 8, Option C: layered capability-based APIs, with a focused connection-management core and optional provider-specific operational capabilities.” **Direct numbered approval.**

**GitHub gap (G):** Carry-forward/no original quote. **Correction:** Restore alternatives, direct user approval, and rationale for optional provider extensions and versioned capability discovery. Link AD-028/029 and `POC-SCN-01`–`03`, `11`; do not force SFTP/SMTP/SMB into `DbConnection` semantics. **Revision:** AD-028/029 refine, not repeal, the layered model.

### F12 — EXP-004 charter: classification of approval evidence

**Problem:** Approval for an experiment's overall direction is not always a separate affirmative vote on its *finalized* detailed charter.

**Original evidence (U/X):** After AD-028, Jim said: “I accept all your remaining recommendations.” The later assistant formulated AD-029–033 and the four-workstream/20-scenario EXP-004 charter. The archived discovery extraction explicitly warns **there was no separate user message approving the finalized EXP-004 charter**. By contrast, Jim expressly approved EXP-003's *four workstreams, 20 scenarios, research-first approach, evidence requirements and stopping rules*, keeping it unexecuted.

**GitHub gap (G):** Consolidated charter §1.1 and §5.1 group **EXP-001–004** as approved-for-planning, with EXP-004's 20 scenarios described without the delegation caveat. **Correction:** Differentiate **EXP-003 directly approved** from **EXP-004 assistant-consolidated under standing blanket delegation**, with no separately recovered post-draft owner ratification. Later approval of POC-001 is a separate event; it does not backdate an individual EXP-004 approval. Keep all four original experiments **unexecuted**.

### F13 — Original EXP scenario obligations need itemized status

**Problem:** A smaller POC does not erase the untested scenarios in earlier experiment plans.

**Original evidence (U/X):** Jim directly approved EXP-003's four workstreams and **20 scenarios** and explicitly ordered it unexecuted. The archives preserve `EXP-003 SCN-001`–`SCN-020` and `EXP-004 SCN-001`–`SCN-020`. EXP-002 was represented as four workstreams and 12 scenarios, but the complete verbatim scenario statements are not available in the extracted record. EXP-001's seven thematic cases are **unnumbered** in available evidence.

**GitHub gap (G):** `docs/requirements/POC-001.md` maps all 21 **new** POC scenarios to `REQ-*` and increments but lacks an **original EXP scenario → POC scenario / deferred D-* / unmapped** index. **Correction:** Add such an index while retaining parent experiment names to distinguish repeated `SCN-001` identifiers. For EXP-001 do not invent IDs; for EXP-002 distinguish summarized content from verbatim criteria. Mark anything not included **unexecuted and deferred/unmapped**, not implicitly satisfied by the POC. No approved POC scenario itself is missing.

### F14 — POC-SCN-09: offline revocation epistemic limit

**Problem:** A disconnected client cannot know about a newly issued server-side revocation without trusted communication or pre-delivered evidence.

**Original evidence (U/X):** AD-014 adopted strict expiry/no implicit grace; AD-018 requires fail-closed denial where required trusted time cannot be established. The architecture charter correctly says immediate server revocation cannot reach disconnected clients and unexpired prior grants can remain usable until expiry in the absence of a trusted check.

**GitHub gap (G):** Standalone `POC-SCN-09` says a “revoked” offline grant denies acquisitions. Its own traceability row clarifies “known revocation,” but the acceptance text itself could be read as promising detection of a *new, unreachable remote revocation*. **Correction:** Append a labeled clarification directly after the scenario table, **without changing the approved scenario**: “Revoked” denotes revocation already available to and verifiable by the client or an authoritative trusted check; genuine offline operation cannot detect a newly issued remote revocation. The expiry/time/device-trust boundaries remain mandatory.

## Correctly represented; preserve as-is

1. **Approval classifications beyond early history:** AD-009–024 and AD-026–028 have direct numbered recorded votes; AD-025 arose from conversational assent; AD-029 followed blanket acceptance; AD-030–033 were selected under delegated authority. These categories are usefully distinct in the PR register.
2. **AD-034 compatibility:** `.NET Framework 4.8` on Windows and `.NET 10` on Windows/Linux are the supported/qualification baseline; `.NET 11` has a compatibility smoke/qualification requirement, `.NET 8` is best-effort, `.NET 6` no support commitment; further OS/provider combinations cannot be declared verified without evidence. `POC-SCN-04`, `18`, `21` require **actual consumers**, not mere successful compilation. No unsupported promise of universal macOS/ARM or auth-mode parity should be introduced.
3. **AD-035:** Optional coordination *over provider-native pools* is approved as architecture, while **building a coordinator is deferred**. `POC-SCN-18`–`20` specifically investigate stale SQL Server pooled connections after restart, bounded acquisition recovery, uncertain-operation non-replay, and test-harness scoped `SqlConnection.ClearPool` measurement.
4. **Security:** Configuration caching is not offline authority; protected grants expire; emergency access has separate controls; audit is independent of normal telemetry; retry applies only to safely repeatable acquisition and not to uncertain SQL execution/commit; failure-domain isolation and structured redaction remain essential; native resource cancellation and draining have honest limits.
5. **POC traceability:** All 21 `POC-SCN-*` rows and 21 requirement/increment rows exist. New `REQ-01`–`REQ-20` and `D-01`–`D-20` are **charter-generated aliases**, not an invented resurrection of earlier historical IDs.
6. **Status:** The PR is documentation only. EXP-001–004 and POC-001 are not shown as executed, and PR #2 was not merged at review time. It is separate from the Analytics Dashboard repository.

## Recommended reconciliation order (not executed)

1. Add a dated provenance supplement, keeping original archived extracts immutable. Preserve recovered user wording and abbreviated assistant alternative summaries with their evidence labels.
2. Amend the decision index for AD-001–008; split 007A/007B/007C; do **not** assert that AD-002's recommended storage option was selected.
3. Record the unnumbered accepted multiple-stores/multiple-profiles requirement with unmapped acceptance coverage.
4. Qualify EXP-004 approval strength and add per-original-experiment scenario disposition.
5. Append the known-revocation qualification beside POC-SCN-09; preserve the exact approved criterion.
6. Re-review without altering AD-034/035, POC scope, delegated-vs-direct approval labels, or execution gates. Request owner authorization before implementation or experiments.

## Reviewed GitHub sources (immutable candidate)

- [PR #2](https://github.com/infoconex/datasource-manager/pull/2)
- [Architecture decision register](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/decisions/README.md)
- [POC-001 scenarios and traceability](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/requirements/POC-001.md)
- [Architecture-discovery archive](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/architecture-discovery.md)
- [Recovery and compatibility archive](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/recovery-and-compatibility.md)
- [Final architecture review archive](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/final-architecture-review.md)
- [Architecture and POC charter](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/charters/architecture-and-poc-execution-charter.md)
- [Engineering kickoff charter](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/charters/poc-001-engineering-kickoff-charter.md)

**Recommendation:** Preserve the technical architecture and approved 21-scenario POC plan, but correct the historical provenance and traceability before calling PR #2 a complete decision archive. **AD-002's original final individual disposition remains unresolved.**