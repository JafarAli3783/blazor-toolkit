# SfToolbar scenario coverage

This file links each test scenario to the requirements it covers. It is the only place where those links live. [TEST-MATRIX.md](TEST-MATRIX.md) and [MANUAL-VALIDATION.md](MANUAL-VALIDATION.md) list the scenarios and no longer carry requirement ids.

The generator `scripts/traceability/generate_traceability.py` reads this file to build [TRACEABILITY.md](TRACEABILITY.md). The harness gate `component-traceability` does not read it. That gate reads only `TEST-MATRIX.md`, so requirement ids may appear in the table rows below.

The `Layer` column names the test layer. The `Gate` column names the mechanism that checks the scenario: `component-traceability` proves a bUnit test names the id; `not measured (ADR-015)` means no gate checks that the test exists; `manual (ADR-017)` means a named reviewer signs the scenario off.

**Run status on 2026-11-10:** the bUnit Toolbar filter, the Playwright Toolbar suite (including the visual baselines) and the axe-core Toolbar suite all pass. The `Gate` column below is unchanged, because it records which gate is responsible for the scenario, not whether the scenario ran. The scenarios that did not run are listed in [Evidence.md](Evidence.md) section 6.

| Test id | Layer | Gate | Covers |
| --- | --- | --- | --- |
| `U-TB-001` | bUnit | component-traceability | `TB-API-020`, `TB-API-030`, `TB-THM-030`, `TB-SMP-040` |
| `U-TB-002` | bUnit | component-traceability | `TB-ITM-020` |
| `U-TB-003` | bUnit | component-traceability | `TB-ITM-010` |
| `U-TB-004` | bUnit | component-traceability | `TB-ITM-010` |
| `U-TB-005` | bUnit | component-traceability | `TB-API-020`, `TB-THM-030` |
| `U-TB-006` | bUnit | component-traceability | `TB-API-020`, `TB-THM-030`, `TB-A11Y-020` |
| `U-TB-007` | bUnit | component-traceability | `TB-ITM-030`, `TB-SMP-040` |
| `U-TB-008` | bUnit | component-traceability | `TB-ITM-040` |
| `U-TB-009` | bUnit | component-traceability | `TB-ITM-060` |
| `U-TB-010` | bUnit | component-traceability | `TB-ITM-060` |
| `U-TB-011` | bUnit | component-traceability | `TB-ITM-070` |
| `U-TB-012` | bUnit | component-traceability | `TB-ITM-190`, `TB-API-250`, `TB-SMP-050` |
| `U-TB-013` | bUnit | component-traceability | `TB-ITM-180`, `TB-ITM-210` |
| `U-TB-014` | bUnit | component-traceability | `TB-API-080` |
| `U-TB-015` | bUnit | component-traceability | `TB-ITM-090` |
| `U-TB-016` | bUnit | component-traceability | `TB-ITM-080` |
| `U-TB-017` | bUnit | component-traceability | `TB-API-050`, `TB-API-200`, `TB-ISO-040` |
| `U-TB-018` | bUnit | component-traceability | `TB-API-050` |
| `U-TB-019` | bUnit | component-traceability | `TB-API-170` |
| `U-TB-020` | bUnit | component-traceability | `TB-API-170`, `TB-OVF-050` |
| `U-TB-021` | bUnit | component-traceability | `TB-OVF-130` |
| `U-TB-022` | bUnit | component-traceability | `TB-OVF-140` |
| `U-TB-023` | bUnit | component-traceability | `TB-OVF-010`, `TB-TST-030` |
| `U-TB-024` | bUnit | component-traceability | `TB-OVF-030` |
| `U-TB-025` | bUnit | component-traceability | `TB-OVF-020` |
| `U-TB-026` | bUnit | component-traceability | `TB-OVF-100` |
| `U-TB-027` | bUnit | component-traceability | `TB-ITM-130` |
| `U-TB-028` | bUnit | component-traceability | `TB-API-220`, `TB-API-260`, `TB-ITM-200` |
| `U-TB-029` | bUnit | component-traceability | `TB-ITM-130`, `TB-ITM-220` |
| `U-TB-030` | bUnit | component-traceability | `TB-API-060`, `TB-ITM-150` |
| `U-TB-031` | bUnit | component-traceability | `TB-API-240`, `TB-OVF-150` |
| `U-TB-032` | bUnit | component-traceability | `TB-API-100`, `TB-ITM-050` |
| `U-TB-033` | bUnit | component-traceability | `TB-ITM-180` |
| `U-TB-034` | bUnit | component-traceability | `TB-ITM-140` |
| `U-TB-035` | bUnit | component-traceability | `TB-LIF-010` |
| `U-TB-036` | bUnit | component-traceability | `TB-LIF-090` |
| `U-TB-037` | bUnit | component-traceability | `TB-RTL-010` |
| `U-TB-038` | bUnit | component-traceability | `TB-I18-010`, `TB-API-230` |
| `U-TB-039` | bUnit | component-traceability | `TB-LIF-100` |
| `U-TB-040` | bUnit | component-traceability | `TB-LIF-110` |
| `U-TB-041` | bUnit | component-traceability | `TB-LIF-080` |
| `U-TB-042` | bUnit | component-traceability | `TB-OVF-160` |
| `U-TB-043` | bUnit | component-traceability | `TB-A11Y-030` |
| `U-TB-044` | bUnit | component-traceability | `TB-API-210`, `TB-ITM-200` |
| `U-TB-045` | bUnit | component-traceability | `TB-ITM-200` |
| `U-TB-046` | bUnit | component-traceability | `TB-KBD-080` |
| `U-TB-047` | bUnit | component-traceability | `TB-A11Y-040` |
| `U-TB-048` | bUnit | component-traceability | `TB-API-030` |
| `U-TB-049` | bUnit | component-traceability | `TB-API-040`, `TB-ITM-120` |
| `U-TB-050` | bUnit | component-traceability | `TB-ITM-100`, `TB-ITM-110` |
| `U-TB-051` | bUnit | component-traceability | `TB-SEC-010`, `TB-SEC-020` |
| `U-TB-052` | bUnit | component-traceability | `TB-SEC-020` |
| `U-TB-053` | bUnit | component-traceability | `TB-SEC-070` |
| `U-TB-054` | bUnit | component-traceability | `TB-ITM-160`, `TB-API-150` |
| `U-TB-055` | bUnit | component-traceability | `TB-ITM-170` |
| `U-TB-056` | bUnit | component-traceability | `TB-ITM-050`, `TB-ITM-160` |
| `U-TB-057` | bUnit | component-traceability | `TB-OVF-040`, `TB-OVF-170`, `TB-A11Y-070`, `TB-SMP-040` |
| `U-TB-058` | bUnit | component-traceability | `TB-A11Y-010`, `TB-A11Y-020` |
| `U-TB-059` | bUnit | component-traceability | `TB-A11Y-060` |
| `U-TB-060` | bUnit | component-traceability | `TB-API-090`, `TB-API-110`, `TB-API-130`, `TB-API-140` |
| `U-TB-061` | bUnit | component-traceability | `TB-API-070` |
| `U-TB-062` | bUnit | component-traceability | `TB-LIF-030` |
| `U-TB-063` | bUnit | component-traceability | `TB-LIF-060`, `TB-SEC-060` |
| `U-TB-064` | bUnit | component-traceability | `TB-LIF-070` |
| `U-TB-065` | bUnit | component-traceability | `TB-LIF-090` |
| `U-TB-066` | bUnit | component-traceability | `TB-LIF-100` |
| `U-TB-067` | bUnit | component-traceability | `TB-OVF-060`, `TB-OVF-070` |
| `U-TB-068` | bUnit | component-traceability | `TB-RTL-020` |
| `U-TB-069` | bUnit | component-traceability | `TB-PRF-060` |
| `U-TB-070` | bUnit | component-traceability | `TB-ITM-150`, `TB-API-060` |
| `U-TB-100` | bUnit | component-traceability | `TB-THM-050`, `TB-OVF-170` |
| `U-TB-101` | bUnit | component-traceability | `TB-OVF-040`, `TB-ISO-030` |
| `U-TB-102` | bUnit | component-traceability | `TB-ITM-190`, `TB-OVF-170` |
| `U-TB-103` | bUnit | component-traceability | `TB-OVF-140`, `TB-A11Y-060` |
| `U-TB-104` | bUnit | component-traceability | `TB-OVF-050`, `TB-OVF-051` |
| `I-TB-001` | bUnit integration | component-traceability | `TB-ISO-030` |
| `I-TB-002` | bUnit integration | component-traceability | `TB-ITM-130` |
| `I-TB-003` | bUnit integration | component-traceability | `TB-LIF-110` |
| `I-TB-004` | bUnit integration | component-traceability | `TB-ITM-140` |
| `I-TB-005` | bUnit integration | component-traceability | `TB-ITM-090` |
| `I-TB-006` | bUnit integration | component-traceability | `TB-ITM-080` |
| `I-TB-007` | bUnit integration | component-traceability | `TB-API-020` |
| `I-TB-008` | bUnit integration | component-traceability | `TB-API-170` |
| `I-TB-009` | bUnit integration | component-traceability | `TB-ITM-130` |
| `I-TB-010` | bUnit integration | component-traceability | `TB-ISO-020` |
| `I-TB-011` | bUnit integration | component-traceability | `TB-ITM-140` |
| `I-TB-012` | bUnit integration | component-traceability | `TB-RTL-050`, `TB-I18-020` |
| `I-TB-013` | bUnit integration | component-traceability | `TB-LIF-020` |
| `I-TB-014` | bUnit integration | component-traceability | `TB-LIF-040` |
| `I-TB-015` | bUnit integration | component-traceability | `TB-LIF-050` |
| `P-TB-001` | Playwright | not measured (ADR-015) | `TB-ITM-010` |
| `P-TB-002` | Playwright | not measured (ADR-015) | `TB-API-020` |
| `P-TB-003` | Playwright | not measured (ADR-015) | `TB-KBD-010` |
| `P-TB-004` | Playwright | not measured (ADR-015) | `TB-KBD-020` |
| `P-TB-005` | Playwright | not measured (ADR-015) | `TB-KBD-030` |
| `P-TB-006` | Playwright | not measured (ADR-015) | `TB-KBD-050` |
| `P-TB-007` | Playwright | not measured (ADR-015) | `TB-KBD-060` |
| `P-TB-008` | Playwright | not measured (ADR-015) | `TB-KBD-070` |
| `P-TB-009` | Playwright | not measured (ADR-015) | `TB-A11Y-040` |
| `P-TB-010` | Playwright | not measured (ADR-015) | `TB-KBD-080` |
| `P-TB-011` | Playwright | not measured (ADR-015) | `TB-KBD-090`, `TB-A11Y-050` |
| `P-TB-012` | Playwright | not measured (ADR-015) | `TB-KBD-100` |
| `P-TB-013` | Playwright | not measured (ADR-015) | `TB-API-060` |
| `P-TB-014` | Playwright | not measured (ADR-015) | `TB-ITM-050` |
| `P-TB-015` | Playwright | not measured (ADR-015) | `TB-ITM-190` |
| `P-TB-016` | Playwright | not measured (ADR-015) | `TB-OVF-090` |
| `P-TB-017` | Playwright | not measured (ADR-015) | `TB-OVF-020` |
| `P-TB-018` | Playwright | not measured (ADR-015) | `TB-OVF-090` |
| `P-TB-019` | Playwright | not measured (ADR-015) | `TB-A11Y-110` |
| `P-TB-020` | Playwright | not measured (ADR-015) | `TB-OVF-080` |
| `P-TB-021` | Playwright | not measured (ADR-015) | `TB-ITM-140` |
| `P-TB-022` | Playwright | not measured (ADR-015) | `TB-KBD-120` |
| `P-TB-023` | Playwright | not measured (ADR-015) | `TB-ITM-040` |
| `P-TB-024` | Playwright | not measured (ADR-015) | `TB-ITM-180` |
| `P-TB-025` | Playwright | not measured (ADR-015) | `TB-ITM-210` |
| `P-TB-026` | Playwright | not measured (ADR-015) | `TB-THM-040` |
| `P-TB-027` | Playwright | not measured (ADR-015) | `TB-A11Y-130` |
| `P-TB-028` | Playwright | not measured (ADR-015) | `TB-OVF-120`, `TB-RTL-030` |
| `P-TB-029` | Playwright | not measured (ADR-015) | `TB-KBD-040` |
| `P-TB-030` | Playwright | not measured (ADR-015) | `TB-A11Y-110` |
| `P-TB-031` | Playwright | not measured (ADR-015) | `TB-OVF-130` |
| `P-TB-032` | Playwright | not measured (ADR-015) | `TB-OVF-080` |
| `P-TB-033` | Playwright | not measured (ADR-015) | `TB-ITM-090` |
| `P-TB-034` | Playwright | not measured (ADR-015) | `TB-KBD-080` |
| `P-TB-035` | Playwright | not measured (ADR-015) | `TB-ITM-130` |
| `P-TB-036` | Playwright | not measured (ADR-015) | `TB-A11Y-060` |
| `P-TB-037` | Playwright | not measured (ADR-015) | `TB-OVF-060` |
| `P-TB-038` | Playwright | not measured (ADR-015) | `TB-OVF-100` |
| `P-TB-039` | Playwright | not measured (ADR-015) | `TB-OVF-030` |
| `P-TB-040` | Playwright | not measured (ADR-015) | `TB-CMP-030`, `TB-CMP-090` |
| `P-TB-041` | Playwright | not measured (ADR-015) | `TB-CMP-020`, `TB-LIF-020` |
| `P-TB-042` | Playwright | not measured (ADR-015) | `TB-CMP-020`, `TB-LIF-030`, `TB-LIF-040` |
| `P-TB-043` | Playwright | not measured (ADR-015) | `TB-CMP-020` |
| `P-TB-044` | Playwright | not measured (ADR-015) | `TB-CMP-020`, `TB-LIF-050` |
| `P-TB-045` | Playwright | not measured (ADR-015) | `TB-A11Y-100` |
| `P-TB-046` | Playwright | not measured (ADR-015) | `TB-A11Y-110` |
| `P-TB-047` | Playwright | not measured (ADR-015) | `TB-SEC-050` |
| `P-TB-048` | Playwright | not measured (ADR-015) | `TB-ISO-020` |
| `P-TB-049` | Playwright | not measured (ADR-015) | `TB-PRF-010`, `TB-PRF-020`, `TB-PRF-030`, `TB-PRF-040` |
| `P-TB-050` | Playwright | not measured (ADR-015) | `TB-SMP-010` |
| `P-TB-051` | Playwright | not measured (ADR-015) | `TB-KBD-070` |
| `P-TB-052` | Playwright | not measured (ADR-015) | `TB-ITM-160` |
| `P-TB-053` | Playwright | not measured (ADR-015) | `TB-OVF-050` |
| `P-TB-054` | Playwright | not measured (ADR-015) | `TB-KBD-120`, `TB-A11Y-160` |
| `P-AXE-TB-001` | Playwright axe | not measured (ADR-015) | `TB-A11Y-080`, `TB-A11Y-090`, `TB-SMP-020`, `TB-SMP-030` |
| `P-AXE-TB-002` | Playwright axe | not measured (ADR-015) | `TB-A11Y-080`, `TB-SMP-020` |
| `P-AXE-TB-003` | Playwright axe | not measured (ADR-015) | `TB-A11Y-080`, `TB-SMP-020` |
| `P-AXE-TB-004` | Playwright axe | not measured (ADR-015) | `TB-A11Y-080`, `TB-A11Y-120`, `TB-SMP-020` |
| `P-AXE-TB-005` | Playwright axe | not measured (ADR-015) | `TB-A11Y-080`, `TB-SMP-020` |
| `P-AXE-TB-006` | Playwright axe | not measured (ADR-015) | `TB-A11Y-080`, `TB-SMP-020` |
| `P-AXE-TB-007` | Playwright axe | not measured (ADR-015) | `TB-A11Y-080`, `TB-SMP-020` |
| `P-AXE-TB-008` | Playwright axe | not measured (ADR-015) | `TB-A11Y-080`, `TB-SMP-020` |
| `P-AXE-TB-009` | Playwright axe | not measured (ADR-015) | `TB-A11Y-080`, `TB-SMP-020` |
| `P-AXE-TB-010` | Playwright axe | not measured (ADR-015) | `TB-A11Y-080`, `TB-SMP-020` |
| `P-AXE-TB-011` | Playwright axe | not measured (ADR-015) | `TB-A11Y-080`, `TB-A11Y-130`, `TB-SMP-020` |
| `P-AXE-TB-012` | Playwright axe | not measured (ADR-015) | `TB-A11Y-080`, `TB-A11Y-110`, `TB-SMP-020` |
| `SR-TB-001` | Manual | manual (ADR-017) | `TB-A11Y-140`, `TB-TST-080` |
| `SR-TB-002` | Manual | manual (ADR-017) | `TB-A11Y-140`, `TB-TST-080` |
| `SR-TB-003` | Manual | manual (ADR-017) | `TB-A11Y-140`, `TB-TST-080` |
| `SR-TB-004` | Manual | manual (ADR-017) | `TB-A11Y-140`, `TB-A11Y-150`, `TB-TST-080` |
| `SR-TB-005` | Manual | manual (ADR-017) | `TB-A11Y-160`, `TB-TST-080` |
| `V-TB-001` | Visual | not measured (ADR-015) | `TB-TST-060`, `TB-THM-040` |
| `V-TB-002` | Visual | not measured (ADR-015) | `TB-TST-060`, `TB-API-020` |
| `V-TB-003` | Visual | not measured (ADR-015) | `TB-TST-060`, `TB-OVF-040` |
| `V-TB-004` | Visual | not measured (ADR-015) | `TB-TST-060`, `TB-OVF-050` |
| `V-TB-005` | Visual | not measured (ADR-015) | `TB-TST-060`, `TB-OVF-130` |
| `V-TB-006` | Visual | not measured (ADR-015) | `TB-TST-060`, `TB-ITM-090` |
| `V-TB-007` | Visual | not measured (ADR-015) | `TB-TST-060`, `TB-RTL-010` |
| `V-TB-008` | Visual | not measured (ADR-015) | `TB-TST-060`, `TB-A11Y-130` |
| `V-TB-009` | Visual | not measured (ADR-015) | `TB-TST-060`, `TB-THM-040` |
| `V-TB-010` | Visual | not measured (ADR-015) | `TB-TST-060`, `TB-A11Y-110` |
| `V-TB-011` | Visual | not measured (ADR-015) | `TB-TST-060`, `TB-ITM-190` |
| `V-TB-012` | Visual | not measured (ADR-015) | `TB-TST-060`, `TB-ITM-130` |
| `V-TB-013` | Visual | not measured (ADR-015) | `TB-TST-060`, `TB-ITM-180` |
| `V-TB-014` | Visual | not measured (ADR-015) | `TB-TST-060`, `TB-ITM-020` |
| `V-TB-015` | Visual | not measured (ADR-015) | `TB-TST-060`, `TB-OVF-100` |
| `B-TB-001` | Build | not measured (ADR-015) | `TB-CMP-060`, `TB-CMP-010` |
| `B-TB-002` | Build | not measured (ADR-015) | `TB-API-180` |
| `B-TB-003` | Build | not measured (ADR-015) | `TB-CMP-060` |
| `B-TB-004` | Build | not measured (ADR-015) | `TB-CMP-050`, `TB-CMP-080` |
| `B-TB-005` | Build | not measured (ADR-015) | `TB-CMP-070`, `TB-CMP-100`, `TB-CMP-040`, `TB-API-010`, `TB-API-190` |
| `B-TB-006` | Build | not measured (ADR-015) | `TB-PRF-050`, `TB-OVF-110`, `TB-SEC-040`, `TB-KBD-110` |
| `B-TB-007` | Build | not measured (ADR-015) | `TB-RTL-040`, `TB-THM-010`, `TB-THM-020`, `TB-ISO-010`, `TB-ISO-050` |
| `B-TB-008` | Build | not measured (ADR-015) | `TB-SEC-030`, `TB-TST-010`, `TB-TST-020`, `TB-TST-040`, `TB-TST-050`, `TB-TST-070`, `TB-API-120`, `TB-API-160`, `TB-API-080` |
