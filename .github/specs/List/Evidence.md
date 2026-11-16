# SfList — Spec Evidence
## Syncfusion Blazor Toolkit

| Field | Value |
|---|---|
| Component | SfList family |
| Spec path | `.github/specs/List/` |
| Implementation | Not started. `src/Components/Lists/` does not exist. |
| Branch | _Pending_ |
| Date | _Pending_ |
| Evidence status | **Pending and non-normative.** No result in this file is a pass. |

This template maps only to in-scope stories `US-01`–`US-22` and to test IDs retained in `TEST-MATRIX.md`.

---

## Verdict

Pending. Do not claim that the implementation matches the specification. There is no implementation and no runtime result.

---

## 1. Spec behavior

| ID | Story | Requirement | Test IDs | Result |
|---|---|---|---|---|
| S-01 | US-11 | Empty, loading, and error precedence | U-001, U-002, U-003 | _Pending_ |
| S-02 | US-02 | Selector wins over field name; keys stay stable | U-015, U-016, U-089 | _Pending_ |
| S-03 | US-03 | Templates and slots | U-022, U-024, U-025 | _Pending_ |
| S-04 | US-04 | Single selection, bind, and cancel | U-042, U-046, U-047 | _Pending_ |
| S-05 | US-05 | Multiple selection, range, and SelectAll | U-043, U-050, U-052 | _Pending_ |
| S-06 | US-06 | Checks independent of selection | U-062, U-063 | _Pending_ |
| S-07 | US-07 | Disabled items and disabled root | U-049, U-075 | _Pending_ |
| S-08 | US-08 | Grouping | U-011, U-036 | _Pending_ |
| S-09 | US-09 | Nested expansion and nested keyboard access | U-065, U-066, P-020, U-123 | _Pending_ |
| S-10 | US-10 | Navigation stays role=list | U-118, A-002 | _Pending_ |
| S-11 | US-01 | Role follows SelectionMode | U-115, U-116, U-117 | _Pending_ |
| S-12 | US-14 | RTL from ancestor dir | P-037, P-038 | _Pending_ |
| S-13 | US-12 | Virtualization keeps off-screen selection | U-099, U-100 | _Pending_ |
| S-14 | US-21 | SSR and hydration ids and roles | P-051 | _Pending_ |
| S-15 | US-22 | Disposal is idempotent | U-090 | _Pending_ |
| S-16 | US-20 | Consumer collection replacement preserves identity | U-031 | _Pending_ |

Sorting, drag-and-drop, and component-owned persistence are non-goals. They have no evidence rows.

---

## 2. Public API

| Item | Contract | Result |
|---|---|---|
| Members | Match `API.md` exactly, including checks, loading, expansion, and typed selectors | _Pending_ |
| XML | `API-xml.md` names the same public types and members as `API.md` | _Pending_ |
| Attributes | `AdditionalAttributes` with `CaptureUnmatchedValues` | _Pending_ |
| Excluded | No sort, drag, reorder, persistence, `HtmlAttributes`, or `EnableRtl` parameter | _Pending_ |
| Focus | Proposed roving tabindex, not yet accepted in implementation review | _Pending_ |

---

## 3. Test status

No List test project exists. Do not record pass, fail, or skip counts.

| Suite | What to run later | Result |
|---|---|---|
| bUnit | Retained U and I rows | _Pending_ |
| Playwright | Retained P rows on Chromium, Firefox, and WebKit | _Pending_ |
| axe | A rows | _Pending_ |
| Visual | V rows | _Pending_ |
| Build | B-001, B-002, B-003 | _Pending_ |
| Performance | PERF-001 | _Pending_ |
| Screen reader | SR rows | _Pending_ |

---

## 4. Evidence catalog (EV-001–EV-022)

| ID | Story | Requirement | Result |
|---|---|---|---|
| EV-001 | US-01 | Static list semantics | _Pending_ |
| EV-002 | US-02 | Data-bound text and selector precedence | _Pending_ |
| EV-003 | US-03 | Templates and slots | _Pending_ |
| EV-004 | US-04 | Single selection | _Pending_ |
| EV-005 | US-05 | Multiple selection | _Pending_ |
| EV-006 | US-06 | Checkable list | _Pending_ |
| EV-007 | US-07 | Disabled behavior | _Pending_ |
| EV-008 | US-08 | Grouping | _Pending_ |
| EV-009 | US-09 | Nested expansion and nested keyboard access | _Pending_ |
| EV-010 | US-10 | Navigation role | _Pending_ |
| EV-011 | US-11 | Empty, loading, and error | _Pending_ |
| EV-012 | US-12 | Virtualization | _Pending_ |
| EV-013 | US-13 | Programmatic API | _Pending_ |
| EV-014 | US-14 | RTL | _Pending_ |
| EV-015 | US-15 | Localization | _Pending_ |
| EV-016 | US-16 | Density and public CSS | _Pending_ |
| EV-017 | US-17 | Forced Colors and dark theme | _Pending_ |
| EV-018 | US-18 | Responsive layout | _Pending_ |
| EV-019 | US-19 | Assistive-technology transcripts | _Pending_ |
| EV-020 | US-20 | Dynamic identity-preserving updates | _Pending_ |
| EV-021 | US-21 | SSR and hydration | _Pending_ |
| EV-022 | US-22 | Disposal | _Pending_ |

Performance and assistive-technology packages, when collected, belong under `.github/evidences/performance/` and `.github/accessibility/list/`. Neither package exists for List.

---

## 5. Runtime record

Not run. Leave this section blank until source and tests exist.

| Suite | Result |
|---|---|
| bUnit | _Pending_ |
| Playwright | _Pending_ |
| axe | _Pending_ |
| Visual | _Pending_ |
| Build | _Pending_ |
| Performance | _Pending_ |

---

## 6. Notes

- Spec path is `.github/specs/List/`, not `docs/list/` and not `.github/specs/Lists/`.
- Axe does not prove NVDA, Narrator, or JAWS behavior.
- Any later N/A for Auto render mode, AOT, or platform high contrast must be written here after a real run. Do not invent one now.

---

## 7. Release checklist

- [ ] EV-001–EV-022 passed or waived in writing
- [ ] No open P0 or P1
- [ ] API reviewed; `API.md` and `API-xml.md` name the same members
- [ ] Samples executable
- [ ] Section 5 filled with measured results
- [ ] Two maintainer approvals
- [ ] Assistive-technology package stored
- [ ] Performance package stored

None of these boxes may be checked in this revision.

---

## 8. How to complete this document later

1. Implement the component and the retained tests.
2. Record branch, date, and environment.
3. Replace `_Pending_` only with a measured Passed, Passed with note, or Failed.
4. Do not add evidence rows for sorting, drag-and-drop, or persistence unless the PRD changes first.
