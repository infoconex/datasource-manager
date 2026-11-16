# Data Source Manager

A secure, provider-neutral .NET library for centrally managed and locally configured data sources across trusted and customer-owned environments.

**Status:** Architecture and POC-001 engineering planning approved. Engineering foundation is merged; I1's first no-provider acquisition contract is being verified for `POC-SCN-01`. No I1 scenario pass is asserted before CI and review.

## Architecture and requirements

**Every architectural decision has a dedicated ADR file.** The [decision index](docs/decisions/README.md) links to each record, including original alternatives where recovered, rationale, approval evidence, consequences, requirements, acceptance scenarios, and later refinements. The historical evidence supplement is archival context—not a competing canonical decision list.

- [37 individual Architecture Decision Records (AD-001–AD-035, including AD-007A/B/C)](docs/decisions/README.md)
- [AD-002 — approved refined storage decision and historical evidence](docs/decisions/AD-002-configuration-and-credential-storage.md)
- [Historical decision evidence supplement and approval qualifications](docs/decisions/decision-evidence.md)
- [POC-001: all 21 acceptance scenarios and requirement traceability](docs/requirements/POC-001.md)
- [EXP-001–004 historical scenario-to-POC cross-reference and deferrals](docs/requirements/experiment-traceability.md)
- [Architecture and POC execution charter](docs/archive/charters/architecture-and-poc-execution-charter.md)
- [POC-001 engineering kickoff charter](docs/archive/charters/poc-001-engineering-kickoff-charter.md)

### Historical conversation source records

The three extracts are retained as historical evidence, not rewritten as independent approved decisions:

- [Architecture discovery](docs/archive/conversations/architecture-discovery.md)
- [SQL recovery and framework compatibility](docs/archive/conversations/recovery-and-compatibility.md)
- [Final architecture review and charter approval](docs/archive/conversations/final-architecture-review.md)

**Provenance warning:** Three [subsequent historical review reports](docs/archive/reviews/) recover early AD-001/003 and AD-004–008 approval evidence that was missing from the original abbreviated extracts. The **original historical AD-002 vote remains unverified**, but refined Option A was **newly approved on November 15, 2026**, without retroactively asserting an earlier vote. Original EXP-001 scenario IDs and EXP-002's exact ID-to-text mapping also remain unverified. The evidence index distinguishes direct approval, inherited affirmation and delegated selection. The original five source files are retained **unchanged**. Some archived charters retain their original pre-approval `Proposed` headers; later recorded approval controls their current POC planning status.

## Planned POC-001

The smallest proof covers portable public contracts, configuration/security, and real SQLite/SFTP integrations plus narrowly scoped SQL Server restart recovery. The library targets .NET Framework 4.8 (Windows) and .NET 10 (Windows/Linux) for supported capabilities, with .NET 11 compatibility qualification. Provider-native pooling remains authoritative; optional pool coordination is deferred pending measurement.

No dependency on or integration with the separate Analytics Dashboard project is implied.

## Governance

Use one issue and one PR per coherent increment. Record new decisions, alternatives, owner approvals and supersessions in `docs/decisions/` before implementing dependent capabilities. Preserve traceability from approved requirements to scenarios, tests and actual evidence. Do not merge, execute experiments, release, or publish packages without separate owner authorization.

## Engineering foundation (Issue #5)

The [engineering foundation index](docs/engineering/README.md) tracks project scaffolding, test and CI readiness, compatibility evidence and [foundation-only acceptance checks](docs/engineering/foundation-acceptance.md). The separate [security preflight](docs/security/threat-model.md) documents trust boundaries before any security behavior is implemented.

The [I1 acceptance evidence index](docs/requirements/POC-001.md#i1--poc-scn-01-req-01) distinguishes new acquisition-contract tests from the earlier foundation smoke. Neither the foundation nor I1 proves real-provider behavior or grants authorization to merge or publish. Independent security threat-model signoff is required **before I2** under the owner's narrow I0 exit-gate adjustment in [Issue #11](https://github.com/infoconex/datasource-manager/issues/11).

