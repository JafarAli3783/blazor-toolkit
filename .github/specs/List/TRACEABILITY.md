# List traceability

| Field | Value |
|---|---|
| Status | Mapping only. Not evidence and not a requirement source. |
| Contract | `PRD.md` owns scope. `API.md` owns members. `Spec.md` owns behavior. |
| Stories | `US-01`–`US-22` in `PRD.md` |
| Tests | IDs in `TEST-MATRIX.md` only |

This file does not add public members. It does not require sorting, drag-and-drop, component-owned persistence, built-in search, or horizontal layout.

Parent spec-kit identifiers, where cited by an older revision, are context. They are not acceptance criteria until a shared spec-kit package exists and a human maps them.

## In-scope map

| Story | Contract | Tests |
|---|---|---|
| US-01 Static list | `role="list"` when selection is None | U-005, U-115, A-001 |
| US-02 Data-bound text | Field name plus typed selector; selector wins | U-016, U-089 |
| US-03 Templates and slots | Item, header, footer, leading, trailing | U-022, U-025 |
| US-04 Single select | Cancellable change, then bind, then changed | U-042, U-046, P-001 |
| US-05 Multiple select | Range, toggle, select all enabled | U-043, U-050, U-052 |
| US-06 Checkable | `CheckMode` and `CheckedValues`, independent of selection | U-062, U-063 |
| US-07 Disabled | Not selectable, checkable, or expandable | U-049, U-075 |
| US-08 Grouped | Group field or selector | U-011, U-036 |
| US-09 Nested expand | Inline expand; nested controls stay in tab order | U-065, U-123, P-020 |
| US-10 Navigation | `Href` with `SelectionMode.None` | U-118, A-002 |
| US-11 Empty, loading, error | Error wins over loading | U-001, U-002, U-003 |
| US-12 Virtualization | Proposed Blazor `Virtualize` | U-099, U-100 |
| US-13 Programmatic API | Methods named in `API.md` | U-052, U-053, U-102 |
| US-14 RTL | Ancestor `dir`; no `EnableRtl` parameter | P-037, P-038 |
| US-15 Localization | Resource strings | U-125 |
| US-16 Density | Comfortable or Dense | U-017, U-018 |
| US-17 Forced Colors | State is not color-only | P-041, A-014 |
| US-18 Responsive | 320px and 400% zoom | P-026, P-031 |
| US-19 Assistive technology | Pending transcripts | SR-001, SR-009 |
| US-20 Dynamic updates | Consumer collection replacement by identity | U-031 |
| US-21 SSR and hydration | Stable ids and roles | P-051 |
| US-22 Disposal | Idempotent `DisposeAsync` | U-090 |

## Proposed, not frozen

| Topic | Proposal |
|---|---|
| Focus | Roving `tabindex` for selectable lists. Finalize during implementation review. |
| Virtualization | Blazor built-in `Virtualize` unless a later decision says otherwise. |
| Base class | Confirm against `src/Base` during implementation. Do not invent one here. |

## Explicitly not mapped to v1 tests

| Topic | Reason |
|---|---|
| Sorting | PRD non-goal |
| Drag-and-drop and component reorder | PRD non-goal |
| Component-owned persistence | PRD non-goal |
| Built-in search, filter, and select-all box | Not in `API.md` |
| Horizontal layout | PRD future enhancement |
| `HtmlAttributes` | Replaced by `AdditionalAttributes` |
| `aria-activedescendant` | Not the proposed focus model |
