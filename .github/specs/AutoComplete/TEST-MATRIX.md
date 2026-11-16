# SfAutoComplete — Test Matrix

Goal: automate each Phase 1 API contract listed in `API.md`; Phase 2 API cases are explicitly P1 and gate that phase. This is a proposed test plan, not measured coverage; implementation and a shipping API baseline are not yet present.

| Layer | Tooling | Scope |
|-------|---------|-------|
| L1 Unit | xUnit + bUnit | Filtering, value/text, parameters, templates, events |
| L2 Integration | bUnit / HtmlRenderer | Async cancel, EditContext, SSR markup, parameter churn |
| L3 Playwright | E2E | Type-ahead, keyboard, popup, remote mock, clear |
| L4 Axe | Playwright + axe-core | Routes below; 0 critical/serious |
| L5 Visual | Screenshots | Closed/open/loading/no-results/RTL/disabled |
| L6 Build | `dotnet build` / publish | Build, XML docs, nullable, trim (implementation gate) |

### Phase and priority gates

- **Phase 1 / P0:** all P0 U/I/P/axe/build IDs required before Phase 1 acceptance; browser/hosting coverage is in §8.
- **Phase 2 / P1:** P1 cases gate Phase 2 delivery only; they are not MVP requirements.
- **Phase 1:** `HighlightFirstItem` is active-option highlighting only; it does not autofill. `TextChanged` is part of Phase 1 two-way binding. `MaxItems`, grouping, virtualization, `ItemHeight`, `PopupHeight`, and prefix/suffix adornments are Phase 2.
- Build IDs are planned checks, not currently measurable; do not mark them passed without a real build.

---

## data-testid table

| testid | Required |
|--------|----------|
| autocomplete-root | Yes |
| autocomplete-input | Yes |
| autocomplete-clear | Yes when ClearButton |
| autocomplete-popup | Yes when open |
| autocomplete-list | Yes when open |
| autocomplete-option | Yes per item (`data-index`) |
| autocomplete-loading | Yes when loading |
| autocomplete-no-results | Yes when empty |
| autocomplete-chevron | When ShowPopupButton |

---

## L1 — Unit (U-AC-xxx)

| ID | Title | Assert | Priority |
|----|-------|--------|----------|
| U-AC-001 | StartsWith filter case-insensitive | Matches prefix only | P0 |
| U-AC-002 | StartsWith case-sensitive | Honors flag | P0 |
| U-AC-003 | Contains filter | Substring match | P0 |
| U-AC-004 | CustomFilter invoked | Predicate results used | P0 |
| U-AC-005 | MinLength blocks search | No items / closed | P0 |
| U-AC-006 | Debounce delays SearchFunc | Fake time advance | P0 |
| U-AC-007 | Debounce 0 immediate | Search on key | P0 |
| U-AC-008 | Value/Text bind select | Both update | P0 |
| U-AC-009 | ForceSelection blur invalid | Text restored to committed text; Value preserved | P0 |
| U-AC-010 | Free text blur | Text kept; prior Value preserved | P0 |
| U-AC-011 | Clear button resets | Value default, Text and CommittedText empty; OnClear fires once | P0 |
| U-AC-012 | ResetValueOnEmptyText | Value cleared only when enabled | P0 |
| U-AC-013 | MaxItems truncates | Count ≤ max | P1 |
| U-AC-014 | HighlightFirstItem | ActiveIndex 0; input and Value unchanged | P0 |
| U-AC-015 | ItemTemplate context | Item + IsActive | P0 |
| U-AC-016 | NoResultsTemplate | Shown when empty | P0 |
| U-AC-017 | OnItemSelected fires | Args item | P0 |
| U-AC-018 | Disabled no open | IsOpen false | P0 |
| U-AC-019 | ReadOnly no edit | Input readonly | P0 |
| U-AC-020 | DisplayTextFunc used | Text from func | P0 |
| U-AC-021 | FilterType None | Unfiltered (capped) | P0 |
| U-AC-022 | Parameterized filter × case × min | Theory data | P0 |
| U-AC-023 | OpenOn modes | Type, Focus, Click, Manual have the specified triggers | P0 |
| U-AC-024 | OpenOnFocus precedence | Shortcut applies only with OpenOn=Type | P0 |
| U-AC-025 | ShowPopupButton | Optional button renders and respects Manual mode | P0 |
| U-AC-026 | MaxLength | Native input maxlength is applied | P0 |
| U-AC-027 | Name and accessible input attributes | Name, AriaLabel/LabelledBy, and TabIndex map to input | P0 |
| U-AC-028 | OnOpen timing and cancellation | Fires before transition; Cancel prevents open | P0 |
| U-AC-029 | OnClose transition semantics | Fires once after actual close, not when already closed | P0 |
| U-AC-030 | OnSearch timing | Fires after debounce/minimum check before local or remote source | P0 |
| U-AC-031 | Header and Footer templates | Both render in popup | P0 |
| U-AC-032 | LoadingTemplate | Renders while asynchronous search is pending | P0 |
| U-AC-033 | FocusAsync and BlurAsync | Focus moves to/from input | P0 |
| U-AC-034 | ClearAsync | Clears value/text, cancels search, and closes | P0 |
| U-AC-035 | HighlightMatch segments | MatchSegments identify matching and non-matching text | P0 |
| U-AC-036 | ValueExpression field identity | Correct EditContext field is identified | P0 |
| U-AC-037 | TextField resolution | Public string property resolves; DisplayTextFunc wins; invalid property/getter is surfaced | P0 |
| U-AC-038 | Missing CustomFilter | Custom mode returns no matches | P0 |
| U-AC-039 | Data/SearchFunc precedence | SearchFunc is sole source when supplied | P0 |
| U-AC-040 | SearchFunc exception | Loading resets; exception is not swallowed | P0 |
| U-AC-041 | TextChanged contract | Typing and commit-policy restoration notify binding | P0 |
| U-AC-042 | Parent parameter update | External Value/Text updates committed state | P0 |
| U-AC-043 | Escape with ForceSelection | Restores committed text; empty reset follows policy | P0 |
| U-AC-044 | Phase 2 virtualization parameters | EnableVirtualization, ItemHeight, and PopupHeight are honored | P1 |
| U-AC-045 | Phase 2 grouping | GroupBy groups suggestions as specified | P1 |
| U-AC-046 | Phase 2 adornments | PrefixTemplate and SuffixTemplate render in their slots | P1 |
| U-AC-047 | MinLength exact boundary | Search runs when query length equals MinLength | P0 |
| U-AC-048 | MinLength below boundary | Search does not run when query length is below MinLength | P0 |
| U-AC-049 | Debounce restarts on retype | Only the final query runs after the debounce interval | P0 |
| U-AC-050 | Empty Data source | Empty collection produces no matches without error | P0 |
| U-AC-051 | Null Data source | Missing local source produces no matches without error | P0 |
| U-AC-052 | DisplayTextFunc precedence | Function output is used when both it and TextField are supplied | P0 |
| U-AC-053 | Selection commits text | Selected item updates Value, Text, and CommittedText consistently | P0 |
| U-AC-054 | Empty text preserves value when reset disabled | Value and CommittedText remain unchanged | P0 |
| U-AC-055 | Empty text resets value when enabled | Value and CommittedText clear and field is notified | P0 |
| U-AC-056 | HeaderTemplate omitted | Popup renders correctly when no header is supplied | P0 |
| U-AC-057 | FooterTemplate omitted | Popup renders correctly when no footer is supplied | P0 |
| U-AC-058 | MatchSegments with multiple matches | All matching and non-matching segments preserve source text and order | P0 |

---

## L2 — Integration (I-AC-xxx)

| ID | Title | Assert | Priority |
|----|-------|--------|----------|
| I-AC-001 | SearchFunc cancel on retype | CT.IsCancellationRequested | P0 |
| I-AC-002 | Stale result ignored | UI shows latest query only | P0 |
| I-AC-003 | EditContext validation message | aria-invalid / message | P0 |
| I-AC-004 | Rapid parameter Data swap | No throw; list updates | P0 |
| I-AC-005 | Dispose cancels pending search | No post-dispose set state | P0 |
| I-AC-006 | OpenAsync / CloseAsync | State transitions | P0 |
| I-AC-007 | RefreshAsync re-queries | SearchFunc call count | P0 |
| I-AC-008 | EditContext selection and reset | Correct field notified; aria-invalid follows messages | P0 |
| I-AC-009 | Static SSR rendering | Accessible input only; no handlers, popup, or dangling ARIA ID references | P0 |
| I-AC-010 | TextChanged and restoration | Parent receives typed and restored text changes | P0 |
| I-AC-011 | SearchFunc exception lifecycle | Loading is cleared; exception reaches the configured Blazor error boundary | P0 |
| I-AC-012 | External Value/Text updates | Committed state follows authoritative parent parameters | P0 |

---

## L3 — Playwright (P-AC-xxx)

| ID | Title | Priority |
|----|-------|----------|
| P-AC-001 | Type-ahead opens popup and lists matches | P0 |
| P-AC-002 | ArrowDown/Up change active option | P0 |
| P-AC-003 | Enter selects active option | P0 |
| P-AC-004 | Escape closes popup | P0 |
| P-AC-005 | Clear button empties input | P0 |
| P-AC-006 | Remote mock: loading then results | P0 |
| P-AC-007 | Remote mock: cancel on fast typing | P0 |
| P-AC-008 | Tab selects active then moves focus | P0 |
| P-AC-009 | Click outside closes | P0 |
| P-AC-010 | Mobile viewport soft-keyboard friendly (focus stays on input) | P1 |
| P-AC-011 | Home/End move active option to first/last | P0 |
| P-AC-012 | Shift+Tab closes without selecting | P0 |
| P-AC-013 | Accessible name, selected option, and invalid field states | P0 |
| P-AC-014 | OpenOn modes and popup button interactions | P0 |
| P-AC-015 | MaxLength prevents additional input characters | P0 |
| P-AC-016 | HighlightMatch segments render without changing input text | P0 |
| P-AC-017 | Focus mode opens for a qualifying query | P0 |
| P-AC-018 | Click mode opens on input click | P0 |
| P-AC-019 | Manual mode stays closed while typing | P0 |
| P-AC-020 | Manual mode opens through OpenAsync | P0 |
| P-AC-021 | OpenOnFocus shortcut opens while typing mode is active | P0 |
| P-AC-022 | OpenOnFocus does not override Click mode | P0 |
| P-AC-023 | ShowPopupButton opens current suggestions | P0 |
| P-AC-024 | Popup button is absent when disabled | P0 |
| P-AC-025 | No-results state renders after an unmatched query | P0 |
| P-AC-026 | Loading state remains visible until remote search completes | P0 |
| P-AC-027 | Fast retype displays only the latest remote results | P0 |
| P-AC-028 | Arrow navigation updates active descendant without moving DOM focus | P0 |
| P-AC-029 | Arrow navigation keeps active index within rendered option range | P0 |
| P-AC-030 | Home and End do not alter typed input | P0 |
| P-AC-031 | Enter with no active option does not select an item | P0 |
| P-AC-032 | Tab commits active option before leaving | P0 |
| P-AC-033 | Shift+Tab leaves without selecting active option | P0 |
| P-AC-034 | Escape restores committed text in ForceSelection mode | P0 |
| P-AC-035 | Escape preserves free text when ForceSelection is disabled | P0 |
| P-AC-036 | Outside click closes popup and applies blur policy | P0 |
| P-AC-037 | Selecting an option updates the bound value and text | P0 |
| P-AC-038 | Clear button resets selection and closes popup | P0 |
| P-AC-039 | Disabled input rejects typing and popup actions | P0 |
| P-AC-040 | Read-only input permits focus but rejects text changes | P0 |
| P-AC-041 | EditForm selection clears the field validation state | P0 |
| P-AC-042 | EditForm empty-text reset notifies the bound field | P0 |
| P-AC-043 | Associated label provides the input accessible name | P0 |
| P-AC-044 | AriaLabelledBy provides the input accessible name | P0 |
| P-AC-045 | Name and TabIndex reach the rendered input | P0 |
| P-AC-046 | `aria-controls` references the rendered listbox only while open | P0 |
| P-AC-047 | `aria-selected` follows the committed suggestion | P0 |
| P-AC-048 | Prefix and suffix templates render in their Phase 2 slots | P1 |
| P-AC-049 | Grouped and virtualized results remain navigable | P1 |
| P-AC-050 | WebAssembly host completes search and selection flow | P0 |

---

## L4 — Axe (P-AXE-AC-xxx)

Routes (Sample or test host) — **exactly 10 accessibility test samples**:

| ID | Route | Priority |
|----|-------|----------|
| P-AXE-AC-001 | `/autocomplete/static` — static SSR output | P0 |
| P-AXE-AC-002 | `/autocomplete/popup-open` | P0 |
| P-AXE-AC-003 | `/autocomplete/disabled` | P0 |
| P-AXE-AC-004 | `/autocomplete/loading` | P0 |
| P-AXE-AC-005 | `/autocomplete/rtl` | P0 |
| P-AXE-AC-006 | `/autocomplete/templates` | P0 |
| P-AXE-AC-007 | `/autocomplete/no-results` | P0 |
| P-AXE-AC-008 | `/autocomplete/label-associated` — visible label | P0 |
| P-AXE-AC-009 | `/autocomplete/active-option` — active descendant and selected state | P0 |
| P-AXE-AC-010 | `/autocomplete/invalid` — EditContext invalid field | P0 |

**Pass criteria:** 0 critical, 0 serious.

---

## L5 — Visual (V-AC-xxx)

| ID | Snapshot | Priority |
|----|----------|----------|
| V-AC-001 | Closed default | P0 |
| V-AC-002 | Open with selection highlight | P0 |
| V-AC-003 | Loading | P0 |
| V-AC-004 | No results | P0 |
| V-AC-005 | RTL open | P0 |
| V-AC-006 | Disabled | P0 |

---

## L6 — Build (B-AC-xxx)

| ID | Check | Priority |
|----|-------|----------|
| B-AC-001 | `dotnet build` 0 warnings | P0 |
| B-AC-002 | CS1591 = 0 on implemented public API | P0 |
| B-AC-003 | Nullable enable clean | P0 |
| B-AC-004 | WASM trim publish has 0 AutoComplete warnings with `DisplayTextFunc` | P1 |
| B-AC-005 | AOT sample publish uses `DisplayTextFunc` and is warning-clean (where pipeline supports) | P1 |

---

## Definition of Done

- All Phase 1 / P0 IDs in L1–L6 green  
- L4 axe clean on listed routes  
- L5 baselines reviewed once then CI-stable  
- Phase 2 / P1 IDs green before Phase 2 acceptance  
- No mandatory manual test gate  
- Do not report coverage or passes until the component exists and the identified test is implemented and executed.

---

## Accessibility test mapping

| Checklist item | Test IDs |
|----------------|----------|
| Accessible name (`label`, `AriaLabel`, or `AriaLabelledBy`) | U-AC-027, P-AC-013, P-AC-043..044, P-AXE-AC-001, P-AXE-AC-008 |
| `role=combobox`, `aria-autocomplete=list`, `aria-expanded` | P-AC-001, P-AC-013, P-AXE-AC-001..010 |
| `aria-controls` only points to a rendered listbox | I-AC-009, P-AC-046, P-AXE-AC-001..002, P-AXE-AC-009 |
| `aria-activedescendant` points to the active option | P-AC-002, P-AC-011, P-AC-028, P-AXE-AC-002, P-AXE-AC-009 |
| `aria-selected` reflects the selected suggestion | P-AC-013, P-AC-047, P-AXE-AC-002, P-AXE-AC-009 |
| `aria-invalid` and EditContext field state | I-AC-003, I-AC-008, P-AC-013, P-AC-041..042, P-AXE-AC-003, P-AXE-AC-010 |
| Keyboard map (arrows, Enter, Escape, Tab, Home/End, Shift+Tab) | P-AC-002..004, P-AC-008, P-AC-011..012 |
| Focus remains on input while active option changes | P-AC-002, P-AC-010 |
| Static SSR has no interactive controls, popup, or dangling ARIA IDs | I-AC-009, P-AXE-AC-001 |

## Route-to-test wiring and six demo descriptions

| Demo route | Sample description | Test IDs |
|---|---|---|
| `/autocomplete/default` | Type-ahead selection from a local list with clear support for common form fields. | U-AC-001..003, U-AC-008, P-AC-001..005 |
| `/autocomplete/remote-search` | Debounced asynchronous search with cancellation and loading state for directory-style lookups. | U-AC-006..007, U-AC-030, U-AC-039..040, I-AC-001..002, I-AC-011, P-AC-006..007 |
| `/autocomplete/templates` | Customize suggestion rows, empty state, and popup chrome with match highlighting. | U-AC-015..016, U-AC-031..032, U-AC-035, P-AC-016, P-AXE-AC-006 |
| `/autocomplete/force-selection` | Compare required list selection with free text and form validation. | U-AC-009..012, U-AC-041..043, I-AC-003, I-AC-008, I-AC-010 |
| `/autocomplete/large-list` | Type-ahead over a large local collection with a suggestion limit; virtualization is Phase 2. | U-AC-013, U-AC-044..045 (Phase 2 / P1 only) |
| `/autocomplete/form-states` | Validation, disabled and read-only states, and right-to-left layout for production forms. | U-AC-018..019, U-AC-027, I-AC-003, I-AC-008, P-AXE-AC-003, P-AXE-AC-005 |

The demo routes are sample-browser wiring; the `/autocomplete/*` axe routes above are separate accessibility-host pages and each maps one-to-one to its `P-AXE-AC-*` ID.

## Browser and hosting coverage

| Browser engine | Versions | Hosting modes | Scope |
|---|---|---|---|
| Chromium (Chrome/Edge) | Current and previous major | Interactive Server, WebAssembly, Auto | Every P0 L3 case |
| Firefox | Current and previous major | Interactive Server, WebAssembly, Auto | Every P0 L3 case |
| WebKit (Safari) | Current and previous major | Interactive Server, WebAssembly, Auto | Every P0 L3 case |
| Chromium static host | Current | Static SSR | I-AC-009 and P-AXE-AC-001 only |

P1 browser coverage may use Chromium unless a feature-specific compatibility defect requires more. Static SSR is not an interactive-host alias: it must be rendered without an interactive render mode.

## Runtime results template

| Gate / suite | IDs | Browser / host | Run date / commit | Pass / total | Result / evidence |
|---|---|---|---|---|---|
| bUnit L1 | `U-AC-*` | N/A | — | — | Pending implementation |
| Integration L2 | `I-AC-*` | HtmlRenderer + interactive test host | — | — | Pending implementation |
| Playwright L3 | `P-AC-*` | Chromium / Server | — | — | Pending implementation |
| Playwright P0 matrix | `P-AC-*` | Chromium, Firefox, WebKit × Server, WASM, Auto | — | — | Pending implementation |
| Axe L4 | `P-AXE-AC-*` | Axe host routes | — | — | Pending implementation |
| Visual L5 | `V-AC-*` | Chromium | — | — | Pending implementation |
| Build L6 | `B-AC-*` | `net10.0` implementation build | — | — | Pending implementation |

## Counting rule

| Test category | Defined case IDs | Count |
|---|---|---:|
| Unit tests | `U-AC-*` | 58 |
| Integration tests | `I-AC-*` | 12 |
| **BUnit tests (unit + integration)** | `U-AC-*`, `I-AC-*` | **70** |
| Playwright tests | `P-AC-*` | 50 |
| Accessibility tests (axe) | `P-AXE-AC-*` | **10** |
| Visual tests | `V-AC-*` | 6 |
| Build tests | `B-AC-*` | 5 |
| **Total defined test cases** | All unique case rows in L1–L6 | **141** |

Count each uniquely identified case row in L1–L6 once. Do not count section headings, checklist bullets, route-to-test references, repeated citations, runtime-template suite rows, or unexpanded theory data. These are planned specification cases, not a claim that the tests have been implemented or run.