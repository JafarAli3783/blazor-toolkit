# PRD.md — Syncfusion Blazor Toolkit Chips
## Product Requirements Document

| Field | Value |
|-------|--------|
| **Product** | Syncfusion Blazor Toolkit |
| **Component** | `SfChip`, `SfChipSet&lt;TItem&gt;` |
| **Version** | 1.0-proposed |
| **Status** | Approved for implementation planning |
| **Aligned documents** | Spec.md, API.md, API-xml.md, TEST-MATRIX.md, TRACEABILITY.md, sample-preparer.md, Evidence.md, competitive-matrix.md |
| **Namespace** | `Syncfusion.Blazor.Toolkit` |

---

## 1. Product background

Modern Blazor applications need compact visual tokens for:

- Faceted search and product filters  
- Single-choice option groups  
- Removable selected-value tokens  
- Quick actions and assistive commands  
- Navigation shortcuts  
- Status and informational tags  

Teams today assemble these from buttons, badges, spans, and ad-hoc CSS. The result is inconsistent keyboard behavior, incorrect ARIA roles (passive tags announced as buttons), unnamed remove icons, and missing focus restoration after deletion.

The Syncfusion Blazor Toolkit requires a **first-class Chips primitive** that:

- Matches Toolkit architecture (naming, CSS isolation, theme tokens, samples, tests)  
- Applies **correct semantics per chip mode**  
- Avoids heavyweight per-chip component dependencies  
- Is production-ready, accessible, and warning-free  

---

## 2. Problem statement

1. **Semantic confusion** — Informational tags implemented as `&lt;button&gt;` or `role="option"` confuse assistive technologies.  
2. **Removal hazards** — Close glyphs without accessible names; focus lost after remove.  
3. **Selection ambiguity** — Filter (multi) vs choice (single) vs action (no selection) mixed in one control without a mode model.  
4. **API incoherence** — Forcing a text input into the base chip component couples IME, validation, and form concerns to every chip set.  
5. **Layout fragility** — No standard wrap / scroll / collapse contract for toolbars and narrow layouts.  
6. **Performance risk** — Embedding full Button/Avatar/Tooltip instances per chip does not scale.  
7. **Evidence gaps** — Competitors document features; fewer publish focus-restore and forced-colors requirements as testable contracts.

---

## 3. Goals

| ID | Goal |
|----|------|
| G-01 | Ship `SfChip` and `SfChipSet&lt;TItem&gt;` as Toolkit-native components |
| G-02 | Enforce mode-correct elements and roles (passive ≠ button) |
| G-03 | Support None / Single / Multiple selection with cancelable events |
| G-04 | Support removable chips with localized names and focus restoration |
| G-05 | Support data binding, templates, empty/loading/error on sets |
| G-06 | Support Wrap / Scroll / Collapse overflow |
| G-07 | Meet WCAG 2.2 AA for component-controlled behavior; AAA where feasible |
| G-08 | Integrate selectable sets with EditContext when needed |
| G-09 | Zero compiler, analyzer, nullable, and XML-doc warnings for public API |
| G-10 | ≥150 automated tests; ≤8 high-value samples; release evidence model |

---

## 4. Non-goals (v1)

| ID | Non-goal |
|----|----------|
| NG-01 | Built-in token text field inside `SfChip` / core `SfChipSet` |
| NG-02 | Drag-and-drop reorder |
| NG-03 | Overflow popup or menu panel |
| NG-04 | Default list virtualization for wrapping chips |
| NG-05 | Select-all command |
| NG-06 | Required dependency on `SfButton`, `SfBadge`, `SfAvatar`, `SfTooltip` per chip |
| NG-07 | Default `role="listbox"` on chip sets |

---

## 5. Target users

- Blazor application developers (Server, WebAssembly, interactive SSR)  
- Design-system and component authors extending Toolkit  
- Accessibility-conscious product teams  
- International product teams (RTL, localized chrome strings)  
- Mobile and keyboard-only end users (indirect)

---

## 6. User needs

| Need | Description |
|------|-------------|
| Correct semantics | Passive chips not exposed as controls |
| Predictable selection | Single vs multi clearly separated |
| Safe removal | Named control, cancelable event, focus restore |
| Composition for tokens | Host input + chip set, not forced input API |
| Theming | Filled/outlined, sizes, shapes, Toolkit tokens |
| Responsive rows | Wrap, scroll, or collapse on narrow widths |
| Testability | Observable events, stable keys, automation hooks |
| Documentation | Spec-level behavior, not only marketing samples |

---

## 7. Primary use cases

1. Multi-select **product filters** on catalog pages  
2. Single-select **choice** groups (density, sort, priority)  
3. **Removable tokens** representing selected users/tags (input composed by host)  
4. **Action chips** for “Save view”, “Clear filters”  
5. **Navigation chips** for related links  
6. **Status / informational** chips on detail headers  

## 8. Secondary use cases

- Suggestion chips that raise host events  
- Templated chips with avatar + metadata  
- Filter toolbars with collapse “+N more”  
- Form-bound filter selection with validation  
- RTL localized filter bars  

---

## 9. Functional requirements

| ID | Requirement | Priority |
|----|-------------|----------|
| FR-01 | Provide standalone `SfChip` | P0 |
| FR-02 | Provide `SfChipSet&lt;TItem&gt;` with DataSource and declarative children | P0 |
| FR-03 | Support ChipType modes per Spec mode table | P0 |
| FR-04 | Support SelectionMode None/Single/Multiple | P0 |
| FR-05 | SelectionChanging (cancel) then SelectionChanged | P0 |
| FR-06 | Removable chips; Removing (cancel) then Removed | P0 |
| FR-07 | Focus restoration after removal per Spec algorithm | P0 |
| FR-08 | ItemKey and field selectors / ChipFields | P0 |
| FR-09 | ChipTemplate, Leading, Trailing, Remove, Empty, Loading, Error templates | P0 |
| FR-10 | OverflowMode Wrap, Scroll, Collapse | P0 |
| FR-11 | Disabled and ReadOnly at chip and set level | P0 |
| FR-12 | Variant, Size, Shape styling | P1 |
| FR-13 | EnableRtl and localized remove/overflow strings | P0 |
| FR-14 | Programmatic Select/Clear/Focus/Remove/Overflow methods | P1 |
| FR-15 | EditContext integration for selectable sets | P1 |
| FR-16 | SSR-safe markup; interactive handlers in interactive modes | P0 |
| FR-17 | No per-chip Toolkit Button dependency | P0 |

---

## 10. Accessibility goals

| ID | Goal |
|----|------|
| A-01 | Correct native element per mode |
| A-02 | Accessible name for every interactive chip |
| A-03 | Remove control name pattern `Remove {chip name}` (localized) |
| A-04 | Keyboard matrix per Spec |
| A-05 | Visible focus; forced-colors state not color-only |
| A-06 | NVDA, Narrator, JAWS evidence process |
| A-07 | axe critical/serious = 0 on registered routes |

---

## 11. Performance goals

| ID | Goal |
|----|------|
| P-01 | Lightweight chip root (native elements) |
| P-02 | Stable @key from ItemKey |
| P-03 | Proposed targets for 50–100 chips; measure before claim |
| P-04 | Dispose JS observers; idempotent DisposeAsync |

---

## 12. Compatibility goals

Blazor Server, WebAssembly, static SSR (markup), interactive SSR, Auto if repo supports; trimming/AOT per Toolkit norms; JS-disabled passive display.

---

## 13. Developer-experience goals

- API consistent with Card/List/Accordion (`CssClass`, `AriaLabel`, `EnableRtl`, templates)  
- Complete XML documentation  
- Eight realistic samples maximum  
- Explicit token composition guidance  
- Narrative only: MaxChips does not truncate DataSource; host owns add validation.

---

## 14. Competitive positioning

Deliver **equal feature coverage** on declarative chips, filter/choice, removable tokens, templates, and keyboard support versus MudBlazor, Ant Design Blazor Tag, DevExpress TagBox tokens, and Telerik patterns, and **exceed** typical practice on:

- Passive vs interactive semantics  
- Focus restoration after removal  
- Cancelable remove/selection events as first-class  
- Documented overflow + collapse focus policy  
- Explicit non-coupling of token text input from base chip API  

---

## 15. User stories and acceptance criteria

### US-01 — Informational chip
**As a** developer **I want** non-interactive chips **so that** tags are not announced as buttons.  
**AC:**

- Root is not `&lt;button&gt;` and has no button role  
- Not in tab order  
- Text or ChildContent visible  
- CHIP-U-001 and CHIP-A-001 pass  

### US-02 — Action chip
**As a** user **I want** to activate a command with pointer and keyboard.  
**AC:**

- Renders as `button type="button"`  
- Enter/Space activate; OnClick fires  
- Disabled blocks activation  
- CHIP-U-010, CHIP-P-001 pass  

### US-03 — Filter chips
**As a** shopper **I want** to toggle multiple filters.  
**AC:**

- `aria-pressed` reflects state  
- Multiple selection updates SelectedValues  
- SelectionChanging can cancel  
- CHIP-U-020, CHIP-U-050–055 pass  

### US-04 — Choice chips
**As a** user **I want** a single exclusive option.  
**AC:**

- Selecting one clears others in Single mode  
- AllowEmpty respected  
- CHIP-U-050 series choice cases pass  

### US-05 — Removable token
**As a** user **I want** to remove a token and keep keyboard context.  
**AC:**

- Remove button name matches localized `Remove {0}`  
- Delete/Backspace remove when focused  
- Focus moves next, else previous, else set  
- CHIP-U-090–100, CHIP-P-030–049 pass  

### US-06 — Data-bound set
**As a** developer **I want** to bind complex items with stable keys.  
**AC:**

- ItemKey preserves selection across refresh  
- TextSelector/ValueSelector map fields  
- CHIP-U-120–129 pass  

### US-07 — Token composition
**As a** developer **I want** to add tokens from my own input.  
**AC:**

- Sample uses host `&lt;input&gt;` + ChipSet  
- No required text field parameter on SfChip  
- Duplicates rejected when AllowDuplicates false  

### US-08 — Keyboard-only filter bar
**As a** keyboard user **I want** to move and toggle filters without a mouse.  
**AC:**

- Roving tabindex; ArrowLeft/Right; RTL mirrored  
- Space toggles filter  
- CHIP-P-080–109 pass  

### US-09 — Screen reader
**As a** screen-reader user **I want** accurate names and states.  
**AC:**

- Chip name, pressed/selected, remove name announced per scripts  
- EV-CHIP-012–014 process completed  

### US-10 — RTL
**As a** user in an RTL locale **I want** mirrored chips.  
**AC:**

- EnableRtl or dir=rtl mirrors leading/trailing and arrows  
- CHIP-P-070–071 pass  

### US-11 — Responsive overflow
**As a** mobile user **I want** chips usable at 320px and 400% zoom.  
**AC:**

- Wrap/Scroll/Collapse behave per Spec  
- Collapse does not strand focus  
- CHIP-P-050–069 pass  

### US-12 — Forms
**As a** developer **I want** selected filters validated on submit.  
**AC:**

- EditContext sample shows required validation  
- CHIP-U-180–189, CHIP-P-121–125 pass  

### US-13 — SSR
**As a** developer **I want** valid prerendered markup.  
**AC:**

- Static render no throw  
- Hydrate interactive sample without role/id mismatch  
- CHIP-P-110 pass  

### US-14 — Performance hygiene
**As a** developer **I want** chips to stay light.  
**AC:**

- Default path uses native button/span/a only  
- EV-CHIP-031 reuse review approved  

---

## 16. Success metrics

| Metric | Target |
|--------|--------|
| P0/P1 automated tests | 100% pass |
| axe critical/serious | 0 |
| XML doc warnings on public API | 0 |
| Sample count | 7–8 |
| Fabricated benchmarks | Forbidden |
| Required evidence | Collected or waived in writing |

---

## 17. Risks and mitigations

| Risk | Mitigation |
|------|------------|
| Collapse measurement flakiness | SSR shows all; measure after interactive; stable test widths |
| Authors nest buttons in Action content | Spec + sample guidance |
| Confusion with MultiSelect | PRD/Spec non-goal + composition samples |
| Large collections | Document thresholds; prefer collapse/scroll/filter |
| AT variance | Scripted evidence, not axe-only claims |

---

## 18. Dependencies

- Existing Toolkit build, theme tokens, bUnit, Playwright, axe harnesses  
- Sample host navigation patterns  
- Localization resource pipeline used by Toolkit  

## 19. Assumptions

- Repo inspection may adjust child naming; behavior stays  
- Host applications own mutation of DataSource lists on Removed  
- Consumers sanitize navigation URLs  

## 20. Constraints

- No new mandatory package deps for default chrome  
- JS interop only for overflow measure/focus assist with dispose  
- Public API surface limited to API.md  

---

## 21. Release-readiness criteria

1. Spec Definition of Done satisfied  
2. TEST-MATRIX P0/P1 green on Chromium, Firefox, WebKit  
3. Required Evidence.md items Collected/Measured  
4. Samples registered and executable  
5. API + XML review approved  
6. No open P0 defects; P1 a11y defects waived only in writing  

---

## 22. Future enhancements (not v1)

- `SfInputChipSet` composite (input + chips)  
- Drag-and-drop reorder  
- Overflow menu  
- In-place edit of chip text  
- Optional virtualization strategies for non-wrapping rows  

---

## 23. Document history

| Version | Date | Notes |
|---------|------|-------|
| 1.0-proposed | 2026-11-02 | Initial PRD aligned to Phase B locks and Spec |
