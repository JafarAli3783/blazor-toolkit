# TEST-MATRIX.md  
# SfToolbar — Test Matrix  
## Syncfusion Toolkit for Blazor

| Field | Value |
|-------|--------|
| **Component** | `SfToolbar` family |
| **Matrix version** | 2.1 |
| **Status** | Approved (tests written; see [Evidence.md](Evidence.md) for the measured run) |
| **Goal** | 100 % public-feature automated coverage; CI is release gate; zero mandatory manual testing |
| **Repository** | https://github.com/syncfusion/blazor-toolkit |

**Measured on 2026-11-10:** bUnit Toolbar filter 343 passed and 0 failed. Playwright Toolbar 70 passed, including the 17 visual baselines. axe-core Toolbar 13 passed with zero violations. The traceability gate reports 90 of 90 scenarios traced with 0 missing and 0 duplicate. The gaps that remain open are listed in [Evidence.md](Evidence.md) section 6.

**Contract phases:** see `Spec.md` for the phase of every requirement. Phase labels in each case row are authoritative. Scenario-to-requirement links live in [COVERAGE.md](COVERAGE.md), not in this file.

## How to read this matrix

Each layer is checked by a different mechanism.

- bUnit scenarios (`U-TB-*`, `I-TB-*`) are table rows. The harness gate `component-traceability` reads those rows and fails when no `.cs` or `.razor` test under `tests/` names the id, or when an id appears twice.
- Playwright, axe, visual and build scenarios (`P-TB-*`, `P-AXE-TB-*`, `V-TB-*`, `B-TB-*`) are bullet lines. The gate ignores bullets, so it does not measure whether those tests exist (ADR-015).
- Screen-reader scenarios (`SR-TB-*`) are in [MANUAL-VALIDATION.md](MANUAL-VALIDATION.md) and need a named reviewer (ADR-017).
- Requirement links for every scenario are in [COVERAGE.md](COVERAGE.md). No requirement id appears in a table row of this file, because the gate would treat it as a scenario.

---

## 1. Layer summary

| Layer | Tooling | Planned (approx.) | Priority focus |
|-------|---------|-------------------|----------------|
| L1 Unit | xUnit + bUnit | ~80–100 | Logic, parameters, overflow algorithm, state, rendering |
| L2 Integration | bUnit | ~10–15 | Multi-item, parameter churn, collection changes, null safety |
| L3 UI / E2E | Playwright | ~45–60 | Keyboard, mouse, touch, overflow, responsive, menus |
| L4 A11y | Playwright + axe-core | ~12–15 | Zero critical/serious; full ARIA + screen-reader paths |
| L5 Visual | Playwright screenshots | ~12–15 | Baselines for themes, overflow, RTL, orientations |
| L6 Build | `dotnet build` + analyzers | 4 | 0 warnings, 0 CS1591, nullable clean, AOT/trim clean |

---

## 2. data-testid hooks (mandatory stable selectors)

| testid | Element |
|--------|---------|
| `toolbar-root` | `SfToolbar` root element |
| `toolbar-item` | Individual toolbar item container |
| `toolbar-button` | Standard button item |
| `toolbar-toggle` | Toggle button item |
| `toolbar-separator` | Separator |
| `toolbar-spacer` | Spacer |
| `toolbar-group` | Group container |
| `toolbar-split` | SplitButton |
| `toolbar-dropdown` | DropDownButton |
| `toolbar-menubutton` | MenuButton |
| `toolbar-overflow-button` | Overflow (“More”) button |
| `toolbar-overflow-popup` | Overflow popup / menu |
| `toolbar-overflow-item` | Item inside overflow popup |
| `toolbar-radio-group` | Radio group |
| `toolbar-check-group` | Check group |
| `toolbar-template-item` | Custom / templated item |

All interactive elements must also be reachable via role-based queries (`role="toolbar"`, `role="button"`, `role="menuitem"`, etc.).

---

## 3. L1 Unit tests (bUnit + xUnit)

| ID | Scenario | Expected | Priority |
|----|----------|----------|----------|
| `U-TB-001` | Default render | `toolbar-root` present, horizontal orientation, empty or default classes | P0 |
| `U-TB-002` | Empty toolbar | Renders without error, no items | P0 |
| `U-TB-003` | Single item | Item rendered correctly | P0 |
| `U-TB-004` | Multiple items | All items rendered in declaration order | P0 |
| `U-TB-005` | Orientation Horizontal | `e-toolbar-horizontal` (or equivalent) applied | P0 |
| `U-TB-006` | Orientation Vertical | `e-toolbar-vertical` applied | P0 |
| `U-TB-007` | Item types – Button | Correct element + classes | P0 |
| `U-TB-008` | Item types – Toggle | Correct element + `aria-pressed` support | P0 |
| `U-TB-009` | Item types – Separator | `role="separator"` | P0 |
| `U-TB-010` | Item types – Spacer | Spacer element present | P0 |
| `U-TB-011` | Item types – Group | `role="group"` + children | P0 |
| `U-TB-012` | SplitButton / DropDownButton / MenuButton (Phase 2) | Correct structure & ARIA | P1 |
| `U-TB-013` | Radio / Check groups (Phase 2) | Mutual exclusion / multi-select behavior | P1 |
| `U-TB-014` | Root-level Enabled API absence | Public API inventory does not expose toolbar-wide Enabled; no runtime behavior is claimed | P0 |
| `U-TB-015` | Enabled=false (item) | Single item disabled, skipped in keyboard flow | P0 |
| `U-TB-016` | Visible=false (item) | Item removed from DOM and overflow calculation | P0 |
| `U-TB-017` | CssClass / HtmlAttributes | Applied to root and items | P1 |
| `U-TB-018` | Width / Height through HtmlAttributes | Consumer-provided style values reach the root element | P0 |
| `U-TB-019` | OverflowMode = Popup | Correct mode class / behavior flag | P0 |
| `U-TB-020` | OverflowMode = Scrollable | Correct mode | P0 |
| `U-TB-021` | OverflowMode = MultiRow (Phase 2) | Correct mode | P1 |
| `U-TB-022` | OverflowMode = Extended (Phase 2) | Correct mode | P1 |
| `U-TB-023` | Priority-based overflow sorting | Stable sort: Show → None → Hide, then Priority ascending, then declaration order | P0 |
| `U-TB-024` | Overflow calculation – all items fit | No overflow button | P0 |
| `U-TB-025` | Overflow calculation – partial overflow | Correct items moved | P0 |
| `U-TB-026` | Overflow calculation – all items overflowed | Overflow button present, popup contains all | P0 |
| `U-TB-027` | Templates – ChildContent | Renders | P0 |
| `U-TB-028` | Templates – ItemTemplate (data-bound, Phase 2) | Renders per item | P1 |
| `U-TB-029` | Templates – nested / custom (Phase 2 nested menus) | Renders without error | P1 |
| `U-TB-030` | Events – OnItemClick / OnClick | Callback fires with correct args | P0 |
| `U-TB-031` | Events – OnOverflowOpen / Close (Phase 2) | Callbacks fire | P1 |
| `U-TB-032` | Two-way bind Selected (Toggle/Radio) | Binding updates | P0 |
| `U-TB-033` | GroupName mutual exclusion (Phase 2) | Only one selected in radio group | P1 |
| `U-TB-034` | Dynamic collection – Add / Remove / Insert / Clear / Replace | UI and internal state update | P0 |
| `U-TB-035` | Item registration / unregistration | OnInitialized / Dispose correct | P0 |
| `U-TB-036` | Duplicate registration handling | No crash, deterministic behavior | P1 |
| `U-TB-037` | RTL flag | Direction / classes applied | P0 |
| `U-TB-038` | Localization – overflow tooltip / aria-label | Culture-specific strings | P1 |
| `U-TB-039` | Zero-width / very small container | Graceful overflow | P1 |
| `U-TB-040` | Rapid parameter churn | No exception, final state correct | P1 |
| `U-TB-041` | Disposal | No memory leaks, handlers detached, JS refs released | P0 |
| `U-TB-042` | Disabled overflow button when nothing to overflow | Button hidden or disabled | P1 |
| `U-TB-043` | AriaLabel on root | `aria-label` applied | P0 |
| `U-TB-044` | Data-bound Items collection (Phase 2) | Renders from collection | P1 |
| `U-TB-045` | Mixed declarative + data-bound | Deterministic rendering | P1 |
| `U-TB-046` | Separator & Spacer ignored in keyboard flow | Correct skipping | P0 |
| `U-TB-047` | Focusable only enabled + visible items | Roving tabindex set correctly | P0 |
| `U-TB-048` | Default OverflowMode | Matches Spec (Popup recommended) | P0 |
| `U-TB-049` | Alignment parameter values | Start, Center, End, and Justify map to documented layout | P0 |
| `U-TB-050` | Item DisplayMode values | IconOnly, TextOnly, and IconAndText render as documented | P0 |
| `U-TB-051` | SEC escaping | `Text`, `IconCss`, `Tooltip`, `Badge` set to `<img onerror>` render escaped, no `img` element | P0 |
| `U-TB-052` | SEC attribute escaping | Quotes and angle brackets in `Id` and `Tooltip` do not break attributes | P0 |
| `U-TB-053` | SEC raw HTML limits | Source scan finds `MarkupString` only in popup container, separators, spacers | P0 |
| `U-TB-054` | Click cancel on Toggle | `Cancel=true` keeps `Selected`; `OnItemClick` still fires | P0 |
| `U-TB-055` | Click cancel on Menu | `Cancel=true` keeps nested popup closed (Split, DropDown, Menu) | P1 |
| `U-TB-056` | Toggle without cancel | Click flips `Selected` and raises `SelectedChanged` | P0 |
| `U-TB-057` | Overflow popup composition | Popup is inline `role="menu"`; entries are `SfButton` with `role="menuitem"`, `tabindex`, `data-testid` | P0 |
| `U-TB-058` | Root role and orientation | `role="toolbar"` and `aria-orientation` for both orientations | P0 |
| `U-TB-059` | Overflow button ARIA | `aria-haspopup="menu"`, `aria-expanded`, `aria-controls` match popup id | P0 |
| `U-TB-060` | Parameter defaults | Documented defaults for every item and group component | P0 |
| `U-TB-061` | Public methods | `RefreshOverflowAsync`, `FocusAsync`, `GetVisibleItems`, `GetOverflowItems` work | P0 |
| `U-TB-062` | Interactive first render | Measurement module initializes exactly once | P0 |
| `U-TB-063` | Disposal with disconnected circuit | `DisposeAsync` swallows `JSDisconnectedException` | P0 |
| `U-TB-064` | Late callbacks after dispose | Resize and click callbacks after dispose are no-ops | P0 |
| `U-TB-065` | Duplicate ids | Duplicate `Id` values render without throwing, deterministic order | P0 |
| `U-TB-066` | Invalid input | Invalid enum, negative priority, zero-width container do not throw | P0 |
| `U-TB-067` | Recalculation triggers | Each trigger in Spec section 4.2 recalculates once within the debounce | P0 |
| `U-TB-068` | RTL inheritance | `EnableRtl=null` inherits direction from parent | P0 |
| `U-TB-069` | Granular rendering | An item state change re-renders only that item | P1 |
| `U-TB-070` | Click order | Item `OnClick` runs before toolbar `OnItemClick` with the item id | P0 |
| `U-TB-100` | Consumer icon class preserved | The toolbar does not override the consumer's icon font class on `.e-btn-icon` (Sample Browser visual fix) | P0 |
| `U-TB-101` | Popup placement respects clipping ancestors | In Popup mode the popup opens above when the room below is clipped by a scrollable ancestor and stays below when it fits (Sample Browser visual fix) | P0 |
| `U-TB-102` | Nested menu placement | The DropDown / Split / Menu nested popup flips above the trigger when there is no room below (Sample Browser visual fix) | P0 |
| `U-TB-103` | Extended mode expand control | The three-dot expand control is visible at the inline end of the bar, toggles `e-toolbar-expanded`, and never opens a popup (Sample Browser visual fix) | P0 |
| `U-TB-104` | Scrollable chevron navigation | The two chevrons render only when content overflows, are disabled at the start and the end of the range, drive the scroll position, and listen for pointer events so press-and-hold scrolls continuously (ADR-020) | P0 |

---

## 4. L2 Integration tests (bUnit)

| ID | Scenario | Priority |
|----|----------|----------|
| `I-TB-001` | Multiple toolbars on same page | P1 |
| `I-TB-002` | Null / empty templates safe | P0 |
| `I-TB-003` | Parameter churn + re-render | P1 |
| `I-TB-004` | Collection change while overflow open | P0 |
| `I-TB-005` | Enable/Disable toggle at runtime | P0 |
| `I-TB-006` | Visible toggle at runtime | P0 |
| `I-TB-007` | Orientation change at runtime | P1 |
| `I-TB-008` | OverflowMode change at runtime | P1 |
| `I-TB-009` | Nested interactive content (buttons inside template) | P0 |
| `I-TB-010` | Toolbar inside other layout components | P1 |
| `I-TB-011` | Concurrent item add/remove | P1 |
| `I-TB-012` | Culture / RTL change at runtime | P1 |
| `I-TB-013` | Static SSR render with item markup, no events | P0 |
| `I-TB-014` | Prerender to interactive handover keeps item state | P0 |
| `I-TB-015` | Auto mode transition keeps `@bind-Selected` state | P0 |

---

## 5. L3 Playwright UI / E2E tests

Presence of this layer is not measured by the component-traceability gate (ADR-015). Format: id, priority, scenario.

- `P-TB-001` (P0): Basic horizontal toolbar structure
- `P-TB-002` (P0): Vertical toolbar structure
- `P-TB-003` (P0): Keyboard – Tab / Shift+Tab enter & leave
- `P-TB-004` (P0): Keyboard – Arrow keys (horizontal)
- `P-TB-005` (P0): Keyboard – Arrow keys (vertical)
- `P-TB-006` (P0): Keyboard – Home / End
- `P-TB-007` (P0): Keyboard – Enter / Space activate
- `P-TB-008` (P0): Keyboard – Escape closes overflow / menus
- `P-TB-009` (P0): Focus management – roving tabindex
- `P-TB-010` (P0): Focus – skip disabled & hidden items
- `P-TB-011` (P0): Focus – restore after overflow close
- `P-TB-012` (P0): Focus – move into overflow popup
- `P-TB-013` (P0): Mouse – click item
- `P-TB-014` (P0): Mouse – toggle selected state
- `P-TB-015` (P1): Mouse – SplitButton primary vs secondary (Phase 2)
- `P-TB-016` (P0): Mouse – open / close overflow
- `P-TB-017` (P0): Overflow popup – correct items present
- `P-TB-018` (P0): Overflow popup – closes on select / Escape / outside click
- `P-TB-019` (P1): Touch – tap items & overflow (mobile viewport)
- `P-TB-020` (P0): Adaptive resize desktop → tablet → mobile
- `P-TB-021` (P0): Dynamic add/remove while overflow open
- `P-TB-022` (P1): Menu / DropDown / Split nested keyboard navigation (Phase 2)
- `P-TB-023` (P0): Toggle visual + state
- `P-TB-024` (P1): Radio group exclusive selection (Phase 2)
- `P-TB-025` (P1): Check group multi-selection (Phase 2)
- `P-TB-026` (P1): Theme switch Light / Dark
- `P-TB-027` (P1): High Contrast / forced-colors
- `P-TB-028` (P0): RTL layout + overflow placement
- `P-TB-029` (P0): RTL keyboard direction
- `P-TB-030` (P1): Mobile viewport overflow + touch targets
- `P-TB-031` (P1): Tablet viewport MultiRow / adaptive
- `P-TB-032` (P0): Desktop full visibility
- `P-TB-033` (P0): Disabled toolbar non-interactive
- `P-TB-034` (P0): Separator / Spacer non-focusable
- `P-TB-035` (P0): Template item interaction
- `P-TB-036` (P0): Overflow button aria-expanded toggles
- `P-TB-037` (P1): Rapid resize stress
- `P-TB-038` (P0): All items overflowed state
- `P-TB-039` (P0): No items overflowed – overflow button hidden
- `P-TB-040` (P0): Browser matrix smoke (Chromium, Firefox, WebKit)
- `P-TB-041` (P0): Render mode: Static SSR route renders markup, no measurement
- `P-TB-042` (P0): Render mode: Interactive Server, measurement runs once
- `P-TB-043` (P0): Render mode: Interactive WebAssembly
- `P-TB-044` (P0): Render mode: Interactive Auto, state kept across transition
- `P-TB-045` (P0): Touch target size at least 24 px on desktop
- `P-TB-046` (P0): Touch target size at least 44 px on mobile viewport
- `P-TB-047` (P0): Strict CSP page: no violations while operating
- `P-TB-048` (P0): No style leakage into host page
- `P-TB-049` (P0): Performance budgets: 100 items render, 20 add/remove, debounce, paint
- `P-TB-050` (P0): Sample Browser `/navigations/toolbar` shows six demos
- `P-TB-051` (P1): Escape closes nested menu and returns focus to owner
- `P-TB-052` (P1): Click cancel stops Split/DropDown/Menu open in browser
- `P-TB-053` (P0): Scrollable mode single line with scroll
- `P-TB-054` (P1): Nested menu arrow navigation and roles

**Browsers for P0**: Chromium, Firefox, WebKit (Safari).  
**Hosting models**: Interactive Server, WebAssembly, Auto must all pass P0 suite.

---

## 6. L4 Accessibility (Playwright + axe-core)

### 6.1 Automated axe gates

Presence of this layer is not measured by the component-traceability gate (ADR-015). Format: id, priority, state, route.

- `P-AXE-TB-001` (P0): Static horizontal - route `/toolbar/static`
- `P-AXE-TB-002` (P0): Vertical - route `/toolbar/vertical`
- `P-AXE-TB-003` (P0): Overflow popup open - route `/toolbar/overflow`
- `P-AXE-TB-004` (P0): Keyboard-focused toolbar - route `/toolbar/keyboard`
- `P-AXE-TB-005` (P0): Disabled items + toolbar - route `/toolbar/disabled`
- `P-AXE-TB-006` (P0): Templates + custom content - route `/toolbar/templates`
- `P-AXE-TB-007` (P0): RTL - route `/toolbar/rtl`
- `P-AXE-TB-008` (P1): MultiRow / Extended - route `/toolbar/multirow`
- `P-AXE-TB-009` (P1): Split / DropDown / Menu (Phase 2) - route `/toolbar/menus`
- `P-AXE-TB-010` (P1): Toggle + Radio + Check groups - route `/toolbar/groups`
- `P-AXE-TB-011` (P0): Forced colors / high contrast - route `/toolbar/highcontrast`
- `P-AXE-TB-012` (P0): Mobile viewport - route `/toolbar/mobile`

L4 is **not done** until the sample pages exist.  
Suggested locations (mirror Card pattern):
- Accessibility samples host: `accessibility/Blazor.Toolkit.Accessibility.Samples`
- Test class: `accessibility/Blazor.Toolkit.AxeCore.Tests/Tests/ToolbarTests.cs`
- Config entry: `control: "Toolbar"` in `accessibility/config.json`

The route list is owned by [ADR-010](adr/ADR-010-accessibility-route-list.md). The wiring rows below correspond in order to the ids in the list above.

| Page | Route | ToolbarTests method | config.json |
|------|-------|---------------------|-------------|
| Static | `/toolbar/static` | `Toolbar_static` | Toolbar `/toolbar/static` |
| Vertical | `/toolbar/vertical` | `Toolbar_vertical` | Toolbar `/toolbar/vertical` |
| Overflow | `/toolbar/overflow` | `Toolbar_overflow` | Toolbar `/toolbar/overflow` |
| Keyboard | `/toolbar/keyboard` | `Toolbar_keyboard` | Toolbar `/toolbar/keyboard` |
| Disabled | `/toolbar/disabled` | `Toolbar_disabled` | Toolbar `/toolbar/disabled` |
| Templates | `/toolbar/templates` | `Toolbar_templates` | Toolbar `/toolbar/templates` |
| RTL | `/toolbar/rtl` | `Toolbar_rtl` | Toolbar `/toolbar/rtl` |
| MultiRow | `/toolbar/multirow` | `Toolbar_multirow` | Toolbar `/toolbar/multirow` |
| Menus | `/toolbar/menus` | `Toolbar_menus` | Toolbar `/toolbar/menus` |
| Groups | `/toolbar/groups` | `Toolbar_groups` | Toolbar `/toolbar/groups` |
| High contrast | `/toolbar/highcontrast` | `Toolbar_highcontrast` | Toolbar `/toolbar/highcontrast` |
| Mobile | `/toolbar/mobile` | `Toolbar_mobile` | Toolbar `/toolbar/mobile` |

### 6.2 Accessibility Checklist (must pass – automated + manual)

- [ ] `role="toolbar"` + `aria-orientation` present on root
- [ ] Roving `tabindex` implemented correctly
- [ ] Groups expose `role="group"` + optional `aria-label`
- [ ] Separators expose `role="separator"`
- [ ] Overflow button has `aria-haspopup`, `aria-expanded`, `aria-controls`
- [ ] Disabled items correctly announced and skipped in keyboard flow
- [ ] Toggle buttons expose `aria-pressed`
- [ ] Screen reader announces overflow open/close and toggle state (manual, MANUAL-VALIDATION.md)
- [ ] High-contrast / forced-colors renders usable colors
- [ ] Focus indicators visible on all interactive items
- [ ] No critical or serious axe violations in CI
- [ ] Keyboard-only operation of every interactive feature
- [ ] Escape closes overflow and nested menus
- [ ] Home/End move to first/last focusable item

### 6.3 Screen-reader validation

Screen-reader scenarios `SR-TB-001` to `SR-TB-005` are manual checks. They live in [MANUAL-VALIDATION.md](MANUAL-VALIDATION.md) with a named reviewer and status (ADR-017).


---

## 7. L5 Visual baselines (Playwright screenshots)

Each baseline has an id. Presence of this layer is not measured by the component-traceability gate (ADR-015). Format: id, phase, baseline name.

- `V-TB-001` (P0): toolbar-basic-horizontal
- `V-TB-002` (P0): toolbar-vertical
- `V-TB-003` (P0): toolbar-overflow-popup
- `V-TB-004` (P0): toolbar-overflow-scrollable
- `V-TB-005` (P1): toolbar-multirow
- `V-TB-006` (P0): toolbar-disabled
- `V-TB-007` (P0): toolbar-rtl
- `V-TB-008` (P0): toolbar-highcontrast
- `V-TB-009` (P0): toolbar-dark
- `V-TB-010` (P0): toolbar-mobile
- `V-TB-011` (P1): toolbar-with-menus
- `V-TB-012` (P0): toolbar-templates
- `V-TB-013` (P1): toolbar-groups
- `V-TB-014` (P0): toolbar-empty
- `V-TB-015` (P0): toolbar-all-overflowed

Capture on Chromium (primary) + key states on Firefox/WebKit for P0.

---

## 8. L6 Build & Analyzer gates

Presence of this layer is not measured by the component-traceability gate (ADR-015).

- `B-TB-001`: 0 build warnings
- `B-TB-002`: 0 CS1591 (complete XML docs)
- `B-TB-003`: Nullable reference types clean
- `B-TB-004`: 0 trim / AOT / IL linker warnings
- `B-TB-005`: No commercial packages; `SfButtonGroup` not used; additive public API; `IToolbarItem` internal
- `B-TB-006`: JS surface audit: only ResizeObserver and getBoundingClientRect; no eval; bundle at most 15 KB gzipped
- `B-TB-007`: CSS lint: logical properties, custom properties, no color literals, scoped, no needless `::deep`
- `B-TB-008`: Docs and coverage review: trust-boundary docs, public member coverage, 85 percent statements, traceability checks, API inventory

---

## 9. Responsive Testing Matrix

| Viewport | Width Range | Key Validations | Priority |
|----------|-------------|-----------------|----------|
| Mobile | < 576 px | Overflow behavior, touch targets ≥ 44 px, vertical orientation | P0 |
| Tablet | 576 – 992 px | Adaptive item movement, MultiRow if enabled | P1 |
| Desktop | > 992 px | Full item visibility, alignment, spacing | P0 |

Tests must resize browser or container and assert correct overflow mode and item placement.

---

## 10. Browser & Hosting Model Matrix

| Browser | Versions | Static SSR | Server | WASM | Auto |
|---------|----------|------------|--------|------|------|
| Chrome / Chromium | Latest 2 | P0 static route | ✅ | ✅ | ✅ |
| Edge | Latest 2 | P0 static route | ✅ | ✅ | ✅ |
| Firefox | Latest 2 | P0 static route | ✅ | ✅ | ✅ |
| Safari / WebKit | Latest 2 | P0 static route | ✅ | ✅ | ✅ |

All P0 L3 and interactive L4 tests must pass on the matrix above. Static SSR is validated without interactivity on the static route; it is not counted as an interactive mode.

---

## 11. RTL & Localization Testing

| Aspect | Validation | Priority |
|--------|------------|----------|
| Layout | Items, groups, overflow button mirror correctly | P0 |
| Overflow placement | “More” button and popup position correct in RTL | P0 |
| Keyboard | Arrow keys reverse direction | P0 |
| Measurement | Width calculation respects RTL | P1 |
| Culture change | Overflow tooltip & aria-labels update | P1 |
| Dynamic culture + RTL switch | No residual LTR strings or layout breakage | P1 |

---

## 12. Automation Coverage Requirements

| Target | Requirement |
|--------|-------------|
| Public API | 100 % covered by unit or UI tests |
| Critical user journeys | 100 % automated |
| Accessibility | axe-core (zero critical/serious) + keyboard scripts in CI; screen-reader checks by a named reviewer (ADR-017) |
| Regression | Every bug fix ships with a new automated test |
| CI/CD | Full suite on every PR (Server + WASM at minimum) |
| Manual effort | Screen-reader scenarios in MANUAL-VALIDATION.md need a named reviewer (ADR-017); nothing else is manual |

---

## 13. Test Implementation Notes

1. Prefer **bUnit** for logic, state, rendering, and overflow algorithm assertions.  
2. Prefer **Playwright** for real browser interaction, keyboard, focus, overflow, responsive, and visual.  
3. Use **data-testid** + role-based queries; avoid brittle CSS selectors.  
4. Mock `ResizeObserver` in unit tests; use real browser resizing in Playwright.  
5. Keep tests independent – no shared mutable state.  
6. Tag tests: `[Trait("Category", "Overflow")]`, `[Trait("Category", "Accessibility")]`, `[Trait("Category", "Keyboard")]`, etc.  
7. Fail the build on any axe-core critical or serious violation.  
8. Store Playwright traces, videos, and screenshots on failure.  
9. Every public parameter, event, and method must appear in at least one automated test.  
10. Overflow algorithm must be covered by combinatorial unit tests (Mode × Priority × Visibility × Enabled).

---

## 14. Definition of Done (Testing)

A phase / the component is considered complete only when:

- All P0 cases are green before Phase 1 acceptance; all P1 cases are green before Phase 2 acceptance.
- axe-core reports **zero** critical or serious issues on all listed samples.  
- Keyboard navigation verified; screen-reader announcements verified by a named reviewer.  
- Visual baselines updated and passing.  
- Build / analyzer / AOT / trim gates pass (0 warnings).  
- Manual scenarios are limited to MANUAL-VALIDATION.md.  
- XML documentation complete (CS1591 clean).  
- Regression tests for any fixed bugs are merged.  
- Sample pages required by L4 exist and are wired into `config.json` + `ToolbarTests.cs`.
- The harness gate component-traceability reports zero missing and zero duplicate scenarios (bUnit layers only, ADR-015). TRACEABILITY.md is generated and current (`python scripts/traceability/generate_traceability.py --check`). Manual scenarios in MANUAL-VALIDATION.md have a named reviewer before release sign-off (ADR-017).
- WCAG 2.2 AA is the gate; AAA is not gated (ADR-007).

## 15. Sample Browser contract

The six demos are defined only in [sample-preparer.md](sample-preparer.md).

---

## 16. Render-mode matrix

Each bullet lists the test ids that run in that render mode. "All P0" means every test with priority P0 in sections 3 to 6.

- Static SSR: `P-TB-041`, `I-TB-013`, `P-AXE-TB-001`, `P-AXE-TB-007`, `U-TB-051`, `U-TB-052` (markup only; no interaction tests).
- Interactive Server: all P0, `P-TB-042`, `I-TB-014`.
- Interactive WebAssembly: all P0, `P-TB-043`.
- Interactive Auto: all P0, `P-TB-044`, `I-TB-015`.

bUnit tests (U and I) run once per target framework: net8.0, net9.0 and net10.0.

---

**Document Owner**: Toolkit Team  
**Status**: Approved
