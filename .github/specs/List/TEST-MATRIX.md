# TEST-MATRIX – SfList
## Syncfusion Blazor Toolkit

**Version:** 4.0  
**Status:** Proposed. No SfList tests exist yet.  
**Authority:** Every row traces to `US-01`–`US-22`. A PRD non-goal is not a required test. Sorting, drag-and-drop, component reorder, and component-owned persistence are out of v1 and have no required IDs.

**Projects, when implementation starts**

- Unit and render: `tests/Syncfusion.Blazor.Toolkit.BUnitTest`
- Browser: `tests/Syncfusion.Blazor.Playwright.Test`

**CI, when those projects contain List tests**

```text
dotnet restore
dotnet build ./src/Syncfusion.Blazor.Toolkit.slnx -c Release
dotnet test tests/Syncfusion.Blazor.Toolkit.BUnitTest -c Release --logger trx
dotnet test tests/Syncfusion.Blazor.Playwright.Test -c Release
```

**Fail on, after implementation:** P0 or P1 failure, any compiler or analyzer warning, axe critical or serious, sample console errors.

---

## Layer summary

| Layer | Tooling | Minimum | Coverage |
|---|---|---:|---|
| L1 Unit | xUnit + bUnit | 70 | Render, bind, selection, check, expand, virtualization, dispose |
| L2 Integration | bUnit | 8 | Independent lists, refresh, nested isolation |
| L3 UI | Playwright | 40 | Keyboard, pointer, responsive, RTL, SSR |
| L4 Accessibility | Playwright + axe | 20 | Roles, states, Forced Colors, nested controls |
| L5 Visual | Playwright screenshots | 20 | In-scope variants only |
| L6 Build | dotnet build | 3 | Warnings, XML docs, nullable |
| **Total** | | **161** | |

P0 browser coverage, once tests exist: Chromium, Firefox, and WebKit.

---

## Stable test hooks

| testid | Purpose |
|---|---|
| list-root | List root |
| list-item | Item root |
| list-item-text | Primary text |
| list-item-secondary | Secondary text |
| list-group | Group |
| list-header | Header |
| list-footer | Footer |
| list-subheader | Subheader |
| list-divider | Divider |
| list-empty | Empty state |
| list-loading | Loading state |
| list-error | Error state |
| list-checkbox | Check control |
| list-expand | Expand control |

There is no drag-handle hook in v1.

---

## 1. Traceability

| Story | Area | Test IDs |
|---|---|---|
| US-01 | Static list | U-005, U-115, A-001 |
| US-02 | Data-bound text | U-006, U-016, U-021 |
| US-03 | Templates and slots | U-022, U-025, U-026 |
| US-04 | Single select | U-042, U-044, U-046, P-001, P-013 |
| US-05 | Multiple select | U-043, U-045, U-050, U-051, U-052, P-002, P-003, P-015 |
| US-06 | Checkable | U-061, U-062, U-063, P-004, A-007 |
| US-07 | Disabled | U-049, U-064, U-075, A-008 |
| US-08 | Grouped | U-011, U-023, U-036, A-005 |
| US-09 | Nested expand | U-065, U-066, U-070, P-005, P-020, P-021, A-006 |
| US-10 | Navigation | U-118, A-002 |
| US-11 | Empty, loading, error | U-001, U-002, U-003, A-009, A-010, A-011 |
| US-12 | Virtualization | U-099, U-100, U-102, P-046, P-048 |
| US-13 | Programmatic API | U-052, U-053, U-102 |
| US-14 | RTL | U-097, P-037, P-038, A-012 |
| US-15 | Localization | U-125 |
| US-16 | Density | U-017, U-018, V-002 |
| US-17 | Forced Colors and dark | P-041, P-042, A-014, V-014, V-015 |
| US-18 | Responsive | P-026, P-031, V-017 |
| US-19 | Assistive technology | SR-001, SR-003, SR-004, SR-007, SR-008, SR-009 |
| US-20 | Dynamic updates | U-029, U-030, U-031, U-055 |
| US-21 | SSR and hydration | P-051 |
| US-22 | Disposal | U-090 |

---

## 2. L1 Unit

| ID | Story | Scenario | Priority |
|---|---|---|---|
| U-001 | US-11 | Null DataSource shows EmptyTemplate; role=list when None | P0 |
| U-002 | US-11 | IsLoading shows LoadingTemplate and hides items | P0 |
| U-003 | US-11 | HasError wins over IsLoading | P0 |
| U-004 | US-11 | Empty sequence shows EmptyTemplate | P0 |
| U-005 | US-01 | Declarative items render | P0 |
| U-006 | US-02 | DataSource-only items render | P0 |
| U-007 | US-02 | Mixed declarative and data order is deterministic | P1 |
| U-008 | US-03 | Header-only composition | P0 |
| U-009 | US-03 | Footer-only composition | P0 |
| U-010 | US-03 | Header plus items | P0 |
| U-011 | US-08 | Group renders | P0 |
| U-012 | US-08 | Subheader per group | P1 |
| U-013 | US-01 | Divider between regions | P1 |
| U-014 | US-03 | Header, groups, items, divider, and footer | P0 |
| U-015 | US-02 | ItemKey stays stable across refresh | P0 |
| U-016 | US-02 | TextSelector wins over TextField | P0 |
| U-017 | US-16 | Dense class applied | P0 |
| U-018 | US-16 | Comfortable is the default | P0 |
| U-019 | US-16 | CssClass appended on root | P0 |
| U-020 | US-16 | AdditionalAttributes splatted on root | P0 |
| U-021 | US-02 | TextField text renders | P0 |
| U-022 | US-03 | ItemTemplate overrides default chrome | P0 |
| U-023 | US-08 | GroupTemplate renders | P0 |
| U-024 | US-03 | HeaderTemplate and FooterTemplate | P0 |
| U-025 | US-03 | Leading and trailing slots | P0 |
| U-026 | US-03 | IconSelector wins over IconField | P0 |
| U-027 | US-03 | SecondaryText renders | P1 |
| U-028 | US-18 | Long text wraps or truncates without overflow | P1 |
| U-029 | US-20 | Insert updates items and keeps matching selection | P0 |
| U-030 | US-20 | Remove drops only the removed identity | P0 |
| U-031 | US-20 | Consumer collection replacement preserves selection by identity | P0 |
| U-032 | US-09 | Nested button inside an item stays in tab order | P0 |
| U-033 | US-12 | 100 non-virtualized items render | P1 |
| U-034 | US-11 | Null templates do not throw | P0 |
| U-035 | US-02 | Empty text displays an empty primary | P1 |
| U-036 | US-08 | GroupField groups correctly | P0 |
| U-037 | US-09 | ChildItemsSelector wins over ChildItemsField | P0 |
| U-038 | US-02 | Unknown field name falls back and warns in Development | P1 |
| U-039 | US-02 | Duplicate keys are last-wins | P1 |
| U-040 | US-03 | Markup content is encoded unless the consumer passes MarkupString | P1 |
| U-041 | US-01 | Mode None has no aria-selected | P0 |
| U-042 | US-04 | Mode Single selects one | P0 |
| U-043 | US-05 | Mode Multiple selects many | P0 |
| U-044 | US-04 | SelectedValue bind updates | P0 |
| U-045 | US-05 | SelectedValues bind snapshots the input | P0 |
| U-046 | US-04 | SelectionChanging runs before commit | P0 |
| U-047 | US-04 | Cancel blocks SelectionChanged | P0 |
| U-048 | US-04 | SelectionChanged runs after commit | P0 |
| U-049 | US-07 | Disabled item is never selected | P0 |
| U-050 | US-05 | Shift range includes enabled items only | P0 |
| U-051 | US-05 | Ctrl or Cmd toggles in Multiple | P0 |
| U-052 | US-13 | SelectAll selects enabled items in Multiple and is a no-op otherwise | P0 |
| U-053 | US-13 | ClearSelection clears and is a no-op when mode is None | P0 |
| U-054 | US-04 | Controlled value is not overwritten silently | P0 |
| U-055 | US-20 | Selection survives a DataSource refresh by key | P0 |
| U-056 | US-04 | Single mode clears only through the clear API | P1 |
| U-057 | US-04 | OnItemClick includes the item | P0 |
| U-058 | US-04 | OnItemClick fires once per activation | P0 |
| U-059 | US-11 | Loading suppresses activation | P0 |
| U-060 | US-04 | Event order is changing, bind, then changed | P0 |
| U-061 | US-06 | CheckMode None hides check UI | P0 |
| U-062 | US-06 | CheckMode Multiple binds CheckedValues | P0 |
| U-063 | US-06 | Checked is independent of Selected | P0 |
| U-064 | US-07 | Disabled item is not checkable | P0 |
| U-065 | US-09 | Expanded shows NestedList | P0 |
| U-066 | US-09 | ExpansionChanging cancel keeps the previous state | P0 |
| U-067 | US-09 | DefaultExpanded applies only when Expanded is not bound | P0 |
| U-068 | US-09 | ExpandAsync and CollapseAsync follow the pipeline | P0 |
| U-069 | US-09 | Expand keyboard path has a unit mirror | P1 |
| U-070 | US-09 | Nested depth 1 to 3 renders | P0 |
| U-071 | US-06 | Check and select on the same item stay independent | P0 |
| U-072 | US-06 | CheckedValuesChanged fires | P0 |
| U-073 | US-09 | ExpandedChanged fires after commit | P0 |
| U-074 | US-09 | Collapsed children are removed from the accessibility tree | P1 |
| U-075 | US-07 | Disabled root blocks check and expand | P0 |
| U-084 | US-16 | Null or empty CssClass is safe | P0 |
| U-085 | US-18 | Height and MaxHeight are applied | P1 |
| U-086 | US-07 | Disabled root | P0 |
| U-087 | US-01 | AriaLabel and AriaLabelledBy | P0 |
| U-088 | US-12 | ItemKey supplies @key | P0 |
| U-089 | US-02 | ValueSelector wins over ValueField | P0 |
| U-090 | US-22 | DisposeAsync twice does not throw | P0 |
| U-091 | US-07 | DisabledSelector wins over DisabledField | P0 |
| U-092 | US-02 | Comparer equality | P0 |
| U-093 | US-12 | EnableVirtualization is one-way for the lifetime | P0 |
| U-094 | US-21 | Supplied Id is preserved | P0 |
| U-095 | US-09 | Cyclic depth above 32 stops safely | P1 |
| U-096 | US-21 | Generated ids are unique | P1 |
| U-097 | US-14 | Ancestor dir=rtl is honored; no EnableRtl parameter | P0 |
| U-098 | US-16 | CaptureUnmatchedValues on AdditionalAttributes | P0 |
| U-099 | US-12 | Virtualized DOM is much smaller than item count | P0 |
| U-100 | US-12 | Off-screen selection is retained | P0 |
| U-101 | US-12 | Missing identity warns and uses fallback equality | P0 |
| U-102 | US-13 | ScrollIntoViewAsync is safe when the item is not realized | P1 |
| U-115 | US-01 | None uses role=list | P0 |
| U-116 | US-04 | Single uses role=listbox | P0 |
| U-117 | US-05 | Multiple sets aria-multiselectable | P0 |
| U-118 | US-10 | Href list stays role=list | P0 |
| U-119 | US-04 | aria-selected | P0 |
| U-120 | US-07 | aria-disabled | P0 |
| U-121 | US-09 | aria-expanded | P0 |
| U-122 | US-06 | aria-checked when checkable | P0 |
| U-123 | US-09 | Roving tabindex 0 and -1; nested controls remain tabbable | P0 |
| U-124 | US-11 | aria-busy when loading | P0 |
| U-125 | US-15 | Empty and loading strings come from resources | P1 |
| U-126 | US-01 | posinset and setsize when set | P1 |

---

## 3. L2 Integration

| ID | Story | Scenario | Priority |
|---|---|---|---|
| I-001 | US-04 | Two lists keep independent selection | P0 |
| I-002 | US-20 | DataSource swap does not throw | P0 |
| I-003 | US-11 | Null, data, then null follows template precedence | P0 |
| I-004 | US-11 | Loading toggle is safe | P0 |
| I-005 | US-04 | Parent re-render does not reset uncontrolled selection | P0 |
| I-006 | US-09 | Nested list selection is isolated | P0 |
| I-007 | US-12 | Group and virtualization together | P1 |
| I-010 | US-11 | Error, recover, then select | P0 |

---

## 4. L3 Playwright

| ID | Story | Scenario | Priority |
|---|---|---|---|
| P-001 | US-04 | Pointer single select | P0 |
| P-002 | US-05 | Pointer multiple toggle | P0 |
| P-003 | US-05 | Pointer range | P0 |
| P-004 | US-06 | Checkbox check | P0 |
| P-005 | US-09 | Expand and collapse nested list | P0 |
| P-008 | US-18 | Touch activation | P1 |
| P-009 | US-09 | Nested button is isolated from item activation | P0 |
| P-010 | US-11 | Loading suppresses click | P0 |
| P-011 | US-09 | Tab enters the list and can reach nested controls | P0 |
| P-012 | US-09 | Shift+Tab leaves without a trap | P0 |
| P-013 | US-04 | ArrowDown moves roving focus and selects in Single | P0 |
| P-014 | US-04 | ArrowUp | P0 |
| P-015 | US-05 | Ctrl+A selects enabled items | P0 |
| P-016 | US-05 | Home and End | P0 |
| P-017 | US-05 | PageUp and PageDown | P1 |
| P-018 | US-04 | Enter and Space follow the mode table | P0 |
| P-019 | US-04 | Type-ahead within 500 ms | P1 |
| P-020 | US-09 | ArrowRight expands | P0 |
| P-021 | US-09 | ArrowLeft collapses | P0 |
| P-023 | US-04 | Escape clears selection | P1 |
| P-024 | US-17 | Focus is visible | P0 |
| P-025 | US-09 | Keyboard matrix includes nested interactive content and excludes drag keys | P0 |
| P-026 | US-18 | 320px usable | P0 |
| P-027 | US-18 | Mobile portrait | P1 |
| P-028 | US-18 | Mobile landscape | P1 |
| P-029 | US-18 | Tablet | P1 |
| P-030 | US-18 | Desktop | P1 |
| P-031 | US-18 | 400% zoom | P0 |
| P-032 | US-18 | Internal scroll does not trap focus | P0 |
| P-033 | US-16 | Default theme | P0 |
| P-034 | US-17 | Dark theme | P0 |
| P-035 | US-17 | Runtime theme switch | P1 |
| P-036 | US-16 | Density spacing | P1 |
| P-037 | US-14 | RTL render from ancestor dir | P0 |
| P-038 | US-14 | RTL arrows reversed | P0 |
| P-039 | US-14 | RTL keyboard | P0 |
| P-040 | US-14 | RTL focus | P0 |
| P-041 | US-17 | Forced Colors selected state | P0 |
| P-042 | US-17 | Forced Colors focus | P0 |
| P-043 | US-17 | High contrast light | P1 |
| P-044 | US-17 | High contrast dark | P1 |
| P-045 | US-17 | Reduced motion skips expand animation | P0 |
| P-046 | US-12 | Virtualized 1000-item scroll | P0 |
| P-047 | US-12 | Off-screen selection retained | P0 |
| P-048 | US-12 | DOM node count limited | P0 |
| P-049 | US-13 | ScrollIntoViewAsync | P1 |
| P-051 | US-21 | Hydration has no role or id mismatch | P0 |
| P-052 | US-04 | Chromium P0 suite | P0 |
| P-053 | US-04 | Firefox P0 suite | P0 |
| P-054 | US-04 | WebKit P0 suite | P0 |
| P-055 | US-02 | Directory sample | P1 |
| P-057 | US-12 | Grouped virtualized sample | P1 |
| P-058 | US-06 | Multiple selection plus checks | P0 |
| P-059 | US-09 | Nested navigation sample | P1 |
| P-060 | US-11 | Loading, then data, then select | P0 |
| PERF-001 | US-12 | Virtualized metrics recorded as median and p95, or a documented deviation | P1 |

---

## 5. L4 Accessibility

| ID | Story | Scenario | Priority |
|---|---|---|---|
| A-001 | US-01 | None uses role=list | P0 |
| A-002 | US-10 | Href list uses role=list | P0 |
| A-003 | US-04 | Single uses listbox | P0 |
| A-004 | US-05 | Multiple is multiselectable | P0 |
| A-005 | US-08 | Grouped structure | P0 |
| A-006 | US-09 | Nested expanded | P0 |
| A-007 | US-06 | Checked state | P0 |
| A-008 | US-07 | Disabled state | P0 |
| A-009 | US-11 | Empty | P0 |
| A-010 | US-11 | Loading | P0 |
| A-011 | US-11 | Error | P0 |
| A-012 | US-14 | RTL | P0 |
| A-013 | US-17 | Dark | P1 |
| A-014 | US-17 | Forced Colors | P0 |
| A-015 | US-12 | Virtualized viewport | P0 |
| A-017 | US-09 | Keyboard-only, including nested controls | P0 |
| A-018 | US-17 | Focus visible | P0 |
| A-019 | US-17 | Contrast | P0 |
| A-021 | US-17 | Reduced motion | P0 |
| SR-001 | US-19 | NVDA list or listbox and selection | P0 |
| SR-003 | US-19 | Narrator expand | P0 |
| SR-004 | US-19 | JAWS check | P0 |
| SR-007 | US-19 | JAWS multiple selection | P0 |
| SR-008 | US-19 | NVDA empty and loading | P0 |
| SR-009 | US-19 | Tree snapshot after select | P0 |
| SR-010 | US-19 | Tree snapshot after consumer collection replacement | P0 |

Axe is not proof of assistive-technology behavior. SR rows stay pending until transcripts exist.

---

## 6. L5 Visual baselines

V-001 Default, V-002 Dense, V-003 Icons, V-004 Avatar, V-005 Multiline, V-006 Selected, V-007 Disabled, V-008 Checked, V-009 Grouped, V-010 Nested expanded, V-011 Empty, V-012 Loading, V-013 Error, V-014 Dark, V-015 Forced Colors, V-016 RTL, V-017 320px, V-018 400% zoom, V-019 Long text, V-020 Virtualized, V-022 Focus-visible, V-023 Hover.

No dragging baseline. Update only through a reviewed pull request, after implementation.

---

## 7. L6 Build

| ID | Expected | Priority |
|---|---|---|
| B-001 | 0 build warnings | P0 |
| B-002 | 0 CS1591 | P0 |
| B-003 | Nullable clean | P0 |

---

## 8. CI groups

| Group | When | Scope |
|---|---|---|
| unit | every implementation PR | L1 |
| integration | every implementation PR | L2 |
| browser | every implementation PR | L3 P0 |
| a11y | every implementation PR | L4 axe |
| visual | release branch and nightly | L5 |
| perf | nightly | PERF-001 |
| build | every implementation PR | L6 |
| screen-reader-evidence | release candidate | SR rows |

There is no sort, drag, or persistence CI group.

---

## 9. Example

### U-001

- **Story:** US-11
- **Title:** Null DataSource shows EmptyTemplate
- **Preconditions:** DataSource null, EmptyTemplate set, IsLoading and HasError false
- **Expected:** Empty region visible; role=list when SelectionMode is None
- **Automation:** bUnit, when the component exists
- **Priority:** P0
- **Result:** not run

---

## 10. Release definition of done

Not met. Implementation is not present.

- Every P0 and P1 row in this file is implemented or explicitly waived with a ticket.
- No required row depends on sorting, drag-and-drop, or component-owned persistence.
- Warnings and nullable checks are clean.
- axe has 0 critical or serious findings on A rows.
- SR evidence is stored under `.github/accessibility/list/` at release candidate.
- PERF-001 is recorded or its deviation is documented.
- XML matches `API.md`.
