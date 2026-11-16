# Traceability (TB)

This file is generated. Do not edit it by hand.

Command: `python scripts/traceability/generate_traceability.py --spec-dir <spec-dir> --prefix TB --tasks <tasks-dir>`

The generator claims only that the links are derived and complete: every Must requirement has an acceptance criterion, a task and a test, and every criterion, task and test cites a valid requirement id. It does not claim that any test exists or passes. The harness gate `component-traceability` makes that claim.

| Requirement | Level | Phase | AC | Task | Tests | Manual |
| --- | --- | --- | --- | --- | --- | --- |
| `TB-API-010` | M | P0 | `AC-TB-001` | `T-002` | `B-TB-005` |  |
| `TB-API-020` | M | P0 | `AC-TB-002` | `T-002` | `U-TB-001`, `U-TB-005`, `U-TB-006`, `I-TB-007`, `P-TB-002`, `V-TB-002` |  |
| `TB-API-030` | M | P0 | `AC-TB-002` | `T-002` | `U-TB-001`, `U-TB-048` |  |
| `TB-API-040` | M | P0 | `AC-TB-002` | `T-002` | `U-TB-049` |  |
| `TB-API-050` | M | P0 | `AC-TB-003` | `T-002` | `U-TB-017`, `U-TB-018` |  |
| `TB-API-060` | M | P0 | `AC-TB-004` | `T-002` | `U-TB-030`, `U-TB-070`, `P-TB-013` |  |
| `TB-API-070` | M | P0 | `AC-TB-005` | `T-002` | `U-TB-061` |  |
| `TB-API-080` | M | P0 | `AC-TB-006` | `T-002` | `U-TB-014`, `B-TB-008` |  |
| `TB-API-090` | M | P0 | `AC-TB-007` | `T-002` | `U-TB-060` |  |
| `TB-API-100` | M | P0 | `AC-TB-007` | `T-002` | `U-TB-032` |  |
| `TB-API-110` | M | P0 | `AC-TB-007` | `T-002` | `U-TB-060` |  |
| `TB-API-120` | M | P0 | `AC-TB-006` | `T-002` | `B-TB-008` |  |
| `TB-API-130` | M | P0 | `AC-TB-007` | `T-002` | `U-TB-060` |  |
| `TB-API-140` | M | P0 | `AC-TB-007` | `T-002` | `U-TB-060` |  |
| `TB-API-150` | M | P0 | `AC-TB-008` | `T-002` | `U-TB-054` |  |
| `TB-API-160` | M | P0 | `AC-TB-006` | `T-002` | `B-TB-008` |  |
| `TB-API-170` | M | P0 | `AC-TB-006` | `T-002` | `U-TB-019`, `U-TB-020`, `I-TB-008` |  |
| `TB-API-180` | M | P0 | `AC-TB-010` | `T-002` | `B-TB-002` |  |
| `TB-API-190` | M | P0 | `AC-TB-001` | `T-002` | `B-TB-005` |  |
| `TB-API-200` | R | P0 | `AC-TB-003` | `T-002` | `U-TB-017` |  |
| `TB-API-210` | M | P1 | `AC-TB-018` | `T-006` | `U-TB-044` |  |
| `TB-API-220` | M | P1 | `AC-TB-018` | `T-006` | `U-TB-028` |  |
| `TB-API-230` | M | P1 | `AC-TB-070` | `T-006` | `U-TB-038` |  |
| `TB-API-240` | M | P1 | `AC-TB-070` | `T-006` | `U-TB-031` |  |
| `TB-API-250` | M | P1 | `AC-TB-070` | `T-006` | `U-TB-012` |  |
| `TB-API-260` | M | P1 | `AC-TB-070` | `T-006` | `U-TB-028` |  |
| `TB-ITM-010` | M | P0 | `AC-TB-011` | `T-002` | `U-TB-003`, `U-TB-004`, `P-TB-001` |  |
| `TB-ITM-020` | M | P0 | `AC-TB-011` | `T-002` | `U-TB-002`, `V-TB-014` |  |
| `TB-ITM-030` | M | P0 | `AC-TB-012` | `T-002` | `U-TB-007` |  |
| `TB-ITM-040` | M | P0 | `AC-TB-013` | `T-002` | `U-TB-008`, `P-TB-023` |  |
| `TB-ITM-050` | M | P0 | `AC-TB-008` | `T-002` | `U-TB-032`, `U-TB-056`, `P-TB-014` |  |
| `TB-ITM-060` | M | P0 | `AC-TB-012` | `T-002` | `U-TB-009`, `U-TB-010` |  |
| `TB-ITM-070` | M | P0 | `AC-TB-012` | `T-002` | `U-TB-011` |  |
| `TB-ITM-080` | M | P0 | `AC-TB-014` | `T-002` | `U-TB-016`, `I-TB-006` |  |
| `TB-ITM-090` | M | P0 | `AC-TB-014` | `T-002` | `U-TB-015`, `I-TB-005`, `P-TB-033`, `V-TB-006` |  |
| `TB-ITM-100` | M | P0 | `AC-TB-015` | `T-002` | `U-TB-050` |  |
| `TB-ITM-110` | M | P0 | `AC-TB-015` | `T-002` | `U-TB-050` |  |
| `TB-ITM-120` | M | P0 | `AC-TB-015` | `T-002` | `U-TB-049` |  |
| `TB-ITM-130` | M | P0 | `AC-TB-016` | `T-002` | `U-TB-027`, `U-TB-029`, `I-TB-002`, `I-TB-009`, `P-TB-035`, `V-TB-012` |  |
| `TB-ITM-140` | M | P0 | `AC-TB-011` | `T-002` | `U-TB-034`, `I-TB-004`, `I-TB-011`, `P-TB-021` |  |
| `TB-ITM-150` | M | P0 | `AC-TB-004` | `T-002` | `U-TB-030`, `U-TB-070` |  |
| `TB-ITM-160` | M | P0 | `AC-TB-008`, `AC-TB-009` | `T-002` | `U-TB-054`, `U-TB-056`, `P-TB-052` |  |
| `TB-ITM-170` | M | P0 | `AC-TB-008` | `T-002` | `U-TB-055` |  |
| `TB-ITM-180` | M | P1 | `AC-TB-017` | `T-006` | `U-TB-013`, `U-TB-033`, `P-TB-024`, `V-TB-013` |  |
| `TB-ITM-190` | M | P1 | `AC-TB-017` | `T-006` | `U-TB-012`, `U-TB-102`, `P-TB-015`, `V-TB-011` |  |
| `TB-ITM-200` | M | P1 | `AC-TB-018` | `T-006` | `U-TB-028`, `U-TB-044`, `U-TB-045` |  |
| `TB-ITM-210` | M | P1 | `AC-TB-017` | `T-006` | `U-TB-013`, `P-TB-025` |  |
| `TB-ITM-220` | O | P2 |  | `T-006` | `U-TB-029` |  |
| `TB-ITM-230` | O | P2 |  | `T-006` |  |  |
| `TB-OVF-010` | M | P0 | `AC-TB-019` | `T-003` | `U-TB-023` |  |
| `TB-OVF-020` | M | P0 | `AC-TB-019` | `T-003` | `U-TB-025`, `P-TB-017` |  |
| `TB-OVF-030` | M | P0 | `AC-TB-020` | `T-003` | `U-TB-024`, `P-TB-039` |  |
| `TB-OVF-040` | M | P0 | `AC-TB-021` | `T-003` | `U-TB-057`, `U-TB-101`, `V-TB-003` |  |
| `TB-OVF-050` | M | P0 | `AC-TB-022` | `T-003` | `U-TB-020`, `U-TB-104`, `P-TB-053`, `V-TB-004` |  |
| `TB-OVF-051` | M | P0 | `AC-TB-072` | `T-003` | `U-TB-104` |  |
| `TB-OVF-060` | M | P0 | `AC-TB-023` | `T-003` | `U-TB-067`, `P-TB-037` |  |
| `TB-OVF-070` | M | P0 | `AC-TB-023` | `T-003` | `U-TB-067` |  |
| `TB-OVF-080` | M | P0 | `AC-TB-024` | `T-003` | `P-TB-020`, `P-TB-032` |  |
| `TB-OVF-090` | M | P0 | `AC-TB-025` | `T-003` | `P-TB-016`, `P-TB-018` |  |
| `TB-OVF-100` | M | P0 | `AC-TB-020` | `T-003` | `U-TB-026`, `P-TB-038`, `V-TB-015` |  |
| `TB-OVF-110` | M | P0 | `AC-TB-026` | `T-003` | `B-TB-006` |  |
| `TB-OVF-120` | M | P0 | `AC-TB-027` | `T-003` | `P-TB-028` |  |
| `TB-OVF-130` | M | P1 | `AC-TB-028` | `T-006` | `U-TB-021`, `P-TB-031`, `V-TB-005` |  |
| `TB-OVF-140` | M | P1 | `AC-TB-028` | `T-006` | `U-TB-022`, `U-TB-103` |  |
| `TB-OVF-150` | M | P1 | `AC-TB-029` | `T-006` | `U-TB-031` |  |
| `TB-OVF-160` | R | P1 |  | `T-006` | `U-TB-042` |  |
| `TB-OVF-170` | M | P0 | `AC-TB-021` | `T-003` | `U-TB-057`, `U-TB-100`, `U-TB-102` |  |
| `TB-KBD-010` | M | P0 | `AC-TB-030` | `T-002` | `P-TB-003` |  |
| `TB-KBD-020` | M | P0 | `AC-TB-031` | `T-002` | `P-TB-004` |  |
| `TB-KBD-030` | M | P0 | `AC-TB-032` | `T-002` | `P-TB-005` |  |
| `TB-KBD-040` | M | P0 | `AC-TB-031` | `T-002` | `P-TB-029` |  |
| `TB-KBD-050` | M | P0 | `AC-TB-033` | `T-002` | `P-TB-006` |  |
| `TB-KBD-060` | M | P0 | `AC-TB-033` | `T-002` | `P-TB-007` |  |
| `TB-KBD-070` | M | P0 | `AC-TB-034` | `T-002` | `P-TB-008`, `P-TB-051` |  |
| `TB-KBD-080` | M | P0 | `AC-TB-035` | `T-002` | `U-TB-046`, `P-TB-010`, `P-TB-034` |  |
| `TB-KBD-090` | M | P0 | `AC-TB-034` | `T-002` | `P-TB-011` |  |
| `TB-KBD-100` | M | P0 | `AC-TB-034` | `T-002` | `P-TB-012` |  |
| `TB-KBD-110` | M | P0 | `AC-TB-026` | `T-002` | `B-TB-006` |  |
| `TB-KBD-120` | M | P1 | `AC-TB-036` | `T-006` | `P-TB-022`, `P-TB-054` |  |
| `TB-A11Y-010` | M | P0 | `AC-TB-037` | `T-002` | `U-TB-058` |  |
| `TB-A11Y-020` | M | P0 | `AC-TB-037` | `T-002` | `U-TB-006`, `U-TB-058` |  |
| `TB-A11Y-030` | M | P0 | `AC-TB-037` | `T-002` | `U-TB-043` |  |
| `TB-A11Y-040` | M | P0 | `AC-TB-030` | `T-002` | `U-TB-047`, `P-TB-009` |  |
| `TB-A11Y-050` | M | P0 | `AC-TB-030` | `T-002` | `P-TB-011` |  |
| `TB-A11Y-060` | M | P0 | `AC-TB-038` | `T-002` | `U-TB-059`, `U-TB-103`, `P-TB-036` |  |
| `TB-A11Y-070` | M | P0 | `AC-TB-021` | `T-002` | `U-TB-057` |  |
| `TB-A11Y-080` | M | P0 | `AC-TB-039` | `T-007` | `P-AXE-TB-001`, `P-AXE-TB-002`, `P-AXE-TB-003`, `P-AXE-TB-004`, `P-AXE-TB-005`, `P-AXE-TB-006`, `P-AXE-TB-007`, `P-AXE-TB-008`, `P-AXE-TB-009`, `P-AXE-TB-010`, `P-AXE-TB-011`, `P-AXE-TB-012` |  |
| `TB-A11Y-090` | M | P0 | `AC-TB-039` | `T-007` | `P-AXE-TB-001` |  |
| `TB-A11Y-100` | M | P0 | `AC-TB-040` | `T-004` | `P-TB-045` |  |
| `TB-A11Y-110` | M | P0 | `AC-TB-040` | `T-004` | `P-TB-019`, `P-TB-030`, `P-TB-046`, `P-AXE-TB-012`, `V-TB-010` |  |
| `TB-A11Y-120` | M | P0 | `AC-TB-041` | `T-004` | `P-AXE-TB-004` |  |
| `TB-A11Y-130` | M | P0 | `AC-TB-041` | `T-004` | `P-TB-027`, `P-AXE-TB-011`, `V-TB-008` |  |
| `TB-A11Y-140` | M | P0 | `AC-TB-042` | `T-007` |  | `SR-TB-001`, `SR-TB-002`, `SR-TB-003`, `SR-TB-004` |
| `TB-A11Y-150` | R | P0 |  | `T-007` |  | `SR-TB-004` |
| `TB-A11Y-160` | M | P1 | `AC-TB-043` | `T-006` | `P-TB-054` | `SR-TB-005` |
| `TB-RTL-010` | M | P0 | `AC-TB-044` | `T-004` | `U-TB-037`, `V-TB-007` |  |
| `TB-RTL-020` | M | P0 | `AC-TB-044` | `T-004` | `U-TB-068` |  |
| `TB-RTL-030` | M | P0 | `AC-TB-027` | `T-004` | `P-TB-028` |  |
| `TB-RTL-040` | M | P0 | `AC-TB-045` | `T-004` | `B-TB-007` |  |
| `TB-RTL-050` | M | P1 | `AC-TB-046` | `T-006` | `I-TB-012` |  |
| `TB-THM-010` | M | P0 | `AC-TB-045` | `T-004` | `B-TB-007` |  |
| `TB-THM-020` | M | P0 | `AC-TB-045` | `T-004` | `B-TB-007` |  |
| `TB-THM-030` | M | P0 | `AC-TB-047` | `T-004` | `U-TB-001`, `U-TB-005`, `U-TB-006` |  |
| `TB-THM-040` | M | P0 | `AC-TB-041` | `T-004` | `P-TB-026`, `V-TB-001`, `V-TB-009` |  |
| `TB-THM-050` | O | P1 |  | `T-006` | `U-TB-100` |  |
| `TB-ISO-010` | M | P0 | `AC-TB-045` | `T-004` | `B-TB-007` |  |
| `TB-ISO-020` | M | P0 | `AC-TB-048` | `T-004` | `I-TB-010`, `P-TB-048` |  |
| `TB-ISO-030` | M | P0 | `AC-TB-048` | `T-004` | `U-TB-101`, `I-TB-001` |  |
| `TB-ISO-040` | M | P0 | `AC-TB-003` | `T-004` | `U-TB-017` |  |
| `TB-ISO-050` | R | P0 | `AC-TB-045` | `T-004` | `B-TB-007` |  |
| `TB-LIF-010` | M | P0 | `AC-TB-049` | `T-005` | `U-TB-035` |  |
| `TB-LIF-020` | M | P0 | `AC-TB-050` | `T-005` | `I-TB-013`, `P-TB-041` |  |
| `TB-LIF-030` | M | P0 | `AC-TB-051` | `T-005` | `U-TB-062`, `P-TB-042` |  |
| `TB-LIF-040` | M | P0 | `AC-TB-051` | `T-005` | `I-TB-014`, `P-TB-042` |  |
| `TB-LIF-050` | M | P0 | `AC-TB-052` | `T-005` | `I-TB-015`, `P-TB-044` |  |
| `TB-LIF-060` | M | P0 | `AC-TB-053` | `T-005` | `U-TB-063` |  |
| `TB-LIF-070` | M | P0 | `AC-TB-053` | `T-005` | `U-TB-064` |  |
| `TB-LIF-080` | M | P0 | `AC-TB-049` | `T-005` | `U-TB-041` |  |
| `TB-LIF-090` | M | P0 | `AC-TB-054` | `T-005` | `U-TB-036`, `U-TB-065` |  |
| `TB-LIF-100` | M | P0 | `AC-TB-054` | `T-005` | `U-TB-039`, `U-TB-066` |  |
| `TB-LIF-110` | R | P1 | `AC-TB-055` | `T-006` | `U-TB-040`, `I-TB-003` |  |
| `TB-SEC-010` | M | P0 | `AC-TB-056` | `T-005` | `U-TB-051` |  |
| `TB-SEC-020` | M | P0 | `AC-TB-056` | `T-005` | `U-TB-051`, `U-TB-052` |  |
| `TB-SEC-030` | M | P0 | `AC-TB-057` | `T-005` | `B-TB-008` |  |
| `TB-SEC-040` | M | P0 | `AC-TB-026` | `T-005` | `B-TB-006` |  |
| `TB-SEC-050` | M | P0 | `AC-TB-058` | `T-005` | `P-TB-047` |  |
| `TB-SEC-060` | M | P0 | `AC-TB-053` | `T-005` | `U-TB-063` |  |
| `TB-SEC-070` | M | P0 | `AC-TB-057` | `T-005` | `U-TB-053` |  |
| `TB-PRF-010` | M | P0 | `AC-TB-059` | `T-003` | `P-TB-049` |  |
| `TB-PRF-020` | M | P0 | `AC-TB-059` | `T-003` | `P-TB-049` |  |
| `TB-PRF-030` | M | P0 | `AC-TB-059` | `T-003` | `P-TB-049` |  |
| `TB-PRF-040` | M | P0 | `AC-TB-059` | `T-003` | `P-TB-049` |  |
| `TB-PRF-050` | M | P0 | `AC-TB-060` | `T-003` | `B-TB-006` |  |
| `TB-PRF-060` | R | P0 | `AC-TB-061` | `T-003` | `U-TB-069` |  |
| `TB-I18-010` | M | P1 | `AC-TB-046` | `T-006` | `U-TB-038` |  |
| `TB-I18-020` | M | P1 | `AC-TB-046` | `T-006` | `I-TB-012` |  |
| `TB-CMP-010` | M | P0 | `AC-TB-062` | `T-005`, `T-008` | `B-TB-001` |  |
| `TB-CMP-020` | M | P0 | `AC-TB-063` | `T-005` | `P-TB-041`, `P-TB-042`, `P-TB-043`, `P-TB-044` |  |
| `TB-CMP-030` | M | P0 | `AC-TB-064` | `T-005` | `P-TB-040` |  |
| `TB-CMP-040` | M | P0 | `AC-TB-001` | `T-005` | `B-TB-005` |  |
| `TB-CMP-050` | M | P0 | `AC-TB-062` | `T-005` | `B-TB-004` |  |
| `TB-CMP-060` | M | P0 | `AC-TB-062` | `T-005`, `T-008` | `B-TB-001`, `B-TB-003` |  |
| `TB-CMP-070` | M | P0 | `AC-TB-057` | `T-005` | `B-TB-005` |  |
| `TB-CMP-080` | M | P0 | `AC-TB-057` | `T-005` | `B-TB-004` |  |
| `TB-CMP-090` | M | P0 | `AC-TB-064` | `T-005`, `T-009` | `P-TB-040` |  |
| `TB-CMP-100` | M | P0 | `AC-TB-057` | `T-005` | `B-TB-005` |  |
| `TB-SMP-010` | M | P0 | `AC-TB-065` | `T-009` | `P-TB-050` |  |
| `TB-SMP-020` | M | P0 | `AC-TB-039` | `T-007` | `P-AXE-TB-001`, `P-AXE-TB-002`, `P-AXE-TB-003`, `P-AXE-TB-004`, `P-AXE-TB-005`, `P-AXE-TB-006`, `P-AXE-TB-007`, `P-AXE-TB-008`, `P-AXE-TB-009`, `P-AXE-TB-010`, `P-AXE-TB-011`, `P-AXE-TB-012` |  |
| `TB-SMP-030` | M | P0 | `AC-TB-039` | `T-007` | `P-AXE-TB-001` |  |
| `TB-SMP-040` | M | P0 | `AC-TB-066` | `T-007` | `U-TB-001`, `U-TB-007`, `U-TB-057` |  |
| `TB-SMP-050` | M | P1 | `AC-TB-066` | `T-006` | `U-TB-012` |  |
| `TB-SMP-060` | R | P0 | `AC-TB-067` | `T-009` |  |  |
| `TB-TST-010` | M | P0 | `AC-TB-068` | `T-007`, `T-008` | `B-TB-008` |  |
| `TB-TST-020` | M | P0 | `AC-TB-068` | `T-007` | `B-TB-008` |  |
| `TB-TST-030` | M | P0 | `AC-TB-068` | `T-007` | `U-TB-023` |  |
| `TB-TST-040` | M | P0 | `AC-TB-069` | `T-007`, `T-008` | `B-TB-008` |  |
| `TB-TST-050` | M | P0 | `AC-TB-069` | `T-007` | `B-TB-008` |  |
| `TB-TST-060` | M | P0 | `AC-TB-069` | `T-007` | `V-TB-001`, `V-TB-002`, `V-TB-003`, `V-TB-004`, `V-TB-005`, `V-TB-006`, `V-TB-007`, `V-TB-008`, `V-TB-009`, `V-TB-010`, `V-TB-011`, `V-TB-012`, `V-TB-013`, `V-TB-014`, `V-TB-015` |  |
| `TB-TST-070` | M | P0 | `AC-TB-069` | `T-007` | `B-TB-008` |  |
| `TB-TST-080` | M | P0 | `AC-TB-071` | `T-007` |  | `SR-TB-001`, `SR-TB-002`, `SR-TB-003`, `SR-TB-004`, `SR-TB-005` |
