# SfAutoComplete — Product Requirements Document

| Field | Value |
|-------|-------|
| Component | `SfAutoComplete<TItem>` |
| Namespace | `Syncfusion.Blazor.Toolkit` |
| Repository | https://github.com/syncfusion/blazor-toolkit |
| License | MIT |
| TFMs | net8.0 / net9.0 / net10.0 |
| Render modes | Static SSR (visual only), Interactive Server, Interactive WebAssembly, Interactive Auto |
| Spec version | 1.0 |
| Status | Design complete — runtime pending |

---

## 1. Problem statement

The Syncfusion Blazor Toolkit lacks a first-class **type-ahead AutoComplete** for forms and search surfaces. Developers today either:

- Pull in commercial Syncfusion.Blazor packages (license friction),
- Adopt MudBlazor / Telerik / Radzen / Blazorise / Blazored Typeahead / Havit (inconsistent a11y, AOT, or API models), or
- Hand-roll combobox behavior (fragile ARIA, race conditions on async search).

**Gap:** A pure-Blazor, MIT, AOT/trim-clean, WAI-ARIA **combobox** (list autocomplete) with clear local + remote search, cancellation, force-select vs free-text policies, and product-grade Sample Browser demos.

**Distinction from ComboBox/Select:** AutoComplete’s primary job is **type-ahead filtering**. Open-on-focus is optional; open-on-type is the default policy. Multi-select chips are **out of MVP scope**.

---

## 2. Goals

| ID | Goal | Priority | Phase |
|----|------|----------|-------|
| G1 | Deliver editable combobox with list autocomplete (WAI-ARIA APG) | P0 | MVP |
| G2 | Local filtering: StartsWith, Contains, case option, custom predicate | P0 | MVP |
| G3 | Async `SearchFunc` with `CancellationToken`, debounce, min length | P0 | MVP |
| G4 | Value/Text synchronization with **ForceSelection** vs free-text | P0 | MVP |
| G5 | Keyboard: Arrow Up/Down, Home/End, Enter, Escape, Tab policy | P0 | MVP |
| G6 | Templates: Item, NoResults, Header, Footer; match highlight | P0 | MVP |
| G7 | EditContext / validation display; Disabled / Readonly / Clear | P0 | MVP |
| G8 | CSS isolation + scoped IDs; Light/Dark/forced-colors; RTL | P0 | MVP |
| G9 | 0 build/CS1591 warnings and 100% API test coverage; trim/AOT warning-free on the trim-safe display-function path | P0 | MVP |
| G10 | ≥95% feature parity vs Mud/Telerik/Radzen on in-scope checklist | P0 | MVP |
| G11 | Virtualization, grouping, and a rendered-item limit for large local lists | P1 | Phase 2 |
| G12 | Prefix/suffix adornments | P1 | Phase 2 |
| G13 | Autofill typed text from the first match | — | Deferred; not in the v1 API |
| G14 | Multi-select chips | — | Non-goal (see §3) |

---

## 3. Non-goals

| Non-goal | Rationale |
|----------|-----------|
| Multi-select / chips | Belongs to a future MultiAutoComplete or TagBox; keeps MVP focused |
| Full ComboBox (force list-only, no free text by design as primary mode) | Separate component family; AutoComplete prioritizes type-ahead |
| Grid-inside-popup, tree hierarchy | Out of scope for form type-ahead |
| Dependency on Syncfusion.Blazor commercial packages | Toolkit is MIT and independent |
| Toolbar / menubar ARIA roles | Wrong pattern; MUST use combobox + listbox |
| Built-in remote HTTP client | App supplies `SearchFunc`; component supplies cancel + debounce |
| Declarative `<AutoCompleteItem>` as primary data model | Optional later; MVP is `Data` + `SearchFunc` |

---

## 4. Personas & scenarios

| Persona | Scenario | Acceptance flavor |
|---------|----------|-------------------|
| Form author | Country/state field; must pick from list | ForceSelection = true, validation |
| Admin filter | Filter grid by customer name | Local Contains, clear button |
| Directory lookup | Employee search against API | Async SearchFunc, loading, cancel |
| Mobile user | Type-ahead on soft keyboard | Focus stays in input; popup does not steal focus |
| A11y user | NVDA/JAWS/Narrator | aria-activedescendant, list announcements |
| Theme author | Dark + high contrast | Tokens + forced-colors |

---

## 5. Success metrics

| Metric | Target |
|--------|--------|
| Feature checklist vs top competitors (in-scope) | ≥ 95% Supported or Exceeds |
| Public API automated coverage | 100% of public parameters/events/methods |
| axe critical/serious on L4 routes | 0 |
| Build warnings / CS1591 | 0 |
| Trim / AOT | 0 warnings on the supported `DisplayTextFunc` path; `TextField` reflection limitation documented |
| Popup interaction feel (local ≤ 1k items) | Open/filter perceived < 16 ms (CI smoke where measurable) |
| Sample Browser demos | Exactly 6 polished demos |
| Manual-only gates | None required for DoD |

---

## 6. Phased delivery

### MVP (Phase 1)

- `SfAutoComplete<TItem>` with `Value` / `Text`, `Data`, `SearchFunc`
- Filter types, debounce (default **300** ms), min length (default **0**)
- Open policy default: **Type** (also Focus optional)
- ForceSelection default **false** (free text allowed)
- Popup listbox, keyboard, clear, loading, templates
- `HighlightFirstItem` marks an option active without changing input text or `Value`; `HighlightMatch` supplies text segments
- `TextChanged` two-way binding and EditContext field integration
- A11y combobox pattern, static-SSR rendering, CSS isolation
- Tests L1–L6 green for MVP surface

### Phase 2

- Virtualization (`EnableVirtualization`, item height, page size)
- Grouping (`GroupBy`; no separate group-template API is specified)
- `MaxItems` rendered-suggestion limit
- Prefix/suffix adornment templates

### Deferred (separate decision required)

- Autofill that copies a first match into the input is not `HighlightFirstItem`, has no public parameter in this contract, and is not included in the v1 deliverables.
- Multi-select remains a separate component/PRD.

---

## 7. Quality gates

| Gate | Rule |
|------|------|
| Build | `dotnet build` 0 warnings; nullable enable; CS1591 = 0 |
| Trim/AOT | Publish WASM trim + AOT sample with `DisplayTextFunc`; 0 AutoComplete-related warnings on that path |
| Unit/Integration | All P0 test IDs green |
| Playwright | Type-ahead, keyboard, remote mock, clear |
| axe | Routes listed in TEST-MATRIX: 0 critical/serious |
| Visual | Closed/open/loading/no-results/RTL/disabled screenshots stable |
| Samples | 6 demos compile and run in Sample Browser |

---

## 8. Open questions — recommended defaults

| Question | Recommended default | Notes |
|----------|---------------------|-------|
| DebounceInterval | **300** ms | Aligns Mud (~100–300), Blazored 300, Radzen FilterDelay |
| MinLength | **0** | Open on empty if Data/Search returns items; apps set 1–2 for remote |
| OpenOn | **Type** | `OpenOnFocus=true` adds focus opening only when `OpenOn=Type`; explicit `OpenOn` mode wins otherwise |
| ForceSelection | **false** | Free text by default; form scenarios set true |
| Escape policy | Close popup; **restore committed Text** if ForceSelection else keep typed text | Documented in Spec |
| Tab policy | If highlighted option: select it; then leave focus | Matches common APG + Mud SelectValueOnTab style |
| Case sensitivity | **Insensitive** default for StartsWith/Contains | |
| Virtualization | **Phase 2** | MVP: MaxItems + honest large-list guidance |
| Multi-select | Non-goal MVP | |

---

## 9. Dependencies & constraints

- Pure Blazor preferred; JS only for: popup position/flip, scroll-into-view, ResizeObserver
- No commercial Syncfusion.Blazor references
- Align naming with Toolkit (`Sf*` prefix, parameter conventions from Card/Toolbar)
- Theme via `SfThemeRoot` tokens

---

## 10. Sample Browser contract (six demos)

| Order | Demo | Description |
|---:|---|---|
| 1 | Default | Type-ahead selection from a local list with clear support for common form fields. |
| 2 | Remote data | Debounced asynchronous search with cancellation and loading state for directory-style lookups. |
| 3 | Templates | Customize suggestion rows, empty state, and popup chrome with match highlighting. |
| 4 | Force selection | Compare required list selection with free text and form validation. |
| 5 | Large list | Type-ahead over a large local collection with a suggestion limit; virtualization is Phase 2. |
| 6 | Form and states | Validation, disabled and read-only states, and right-to-left layout for production forms. |

## 11. Document history

| Version | Date | Notes |
|---------|------|-------|
| 1.0 | 2026-10-30 | Initial clean PRD |