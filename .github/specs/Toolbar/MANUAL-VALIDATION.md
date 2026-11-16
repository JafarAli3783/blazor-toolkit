# SfToolbar manual validation

This file lists the scenarios that a person must check with a real screen reader. No automated gate can run them. The harness gate does not read this file.

Each scenario needs a named reviewer before release sign-off (`TB-TST-080`, ADR-017). Scenario-to-requirement links are also recorded in [COVERAGE.md](COVERAGE.md).

The automated part of the accessibility work is done: the axe-core suite passes over the 12 ADR-010 routes with zero critical and serious violations, and the keyboard, focus and overflow behaviour is covered by the Playwright suite. The rows below are the part no tool can replace.

| ID | Scenario | Tools | Priority | Covers | Reviewer | Status |
| --- | --- | --- | --- | --- | --- | --- |
| `SR-TB-001` | Toolbar role & orientation announced | NVDA, Narrator, JAWS | P0 | `TB-A11Y-140` | Unassigned (name required before release sign-off) | Pending |
| `SR-TB-002` | Item labels & disabled state | NVDA, Narrator, JAWS | P0 | `TB-A11Y-140` | Unassigned (name required before release sign-off) | Pending |
| `SR-TB-003` | Toggle pressed/unpressed | NVDA, Narrator | P0 | `TB-A11Y-140` | Unassigned (name required before release sign-off) | Pending |
| `SR-TB-004` | Overflow button expanded/collapsed | NVDA, Narrator | P0 | `TB-A11Y-140`, `TB-A11Y-150` | Unassigned (name required before release sign-off) | Pending |
| `SR-TB-005` | Nested menu navigation (Phase 2) | NVDA, Narrator | P1 | `TB-A11Y-160` | Unassigned (name required before release sign-off) | Pending |

## Sign-off

The release owner assigns one named person to each scenario. That person signs off the scenario, not a team or a role.

For each scenario the reviewer records the following in [Evidence.md](Evidence.md) under Manual reviews:

- The screen reader and its version, for example NVDA 2025.1.
- The browser and its version, for example Firefox 130.
- The date of the check.
- The result: Pass or Fail.

A scenario is ready for release when its Reviewer cell holds a name and its Status is Pass. A P0 scenario with status Pending or Fail blocks release. A P1 scenario belongs to Phase 2 and blocks only the Phase 2 release.
