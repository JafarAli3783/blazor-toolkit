# Product Requirements Document – SfToolbar  
**Syncfusion Blazor Toolkit**  

| Field | Value |
|-------|--------|
| **Component** | `SfToolbar` |
| **Namespace** | `Syncfusion.Blazor.Toolkit` |
| **Repo** | https://github.com/syncfusion/blazor-toolkit |
| **License** | MIT |
| **TFMs** | net8.0 / net9.0 / net10.0 |
| **Render modes** | Static SSR, Interactive Server, Interactive WebAssembly, Interactive Auto |
| **Version** | 1.0 (Draft) |
| **Status** | Approved |
| **Doc version** | 2.0 |
| **Last Updated** | 2026-10-30 |

---

## 1. Problem Statement

Enterprise and open-source Blazor applications need a production-grade, flexible **command surface** for application command bars, editor toolbars, grid/list toolbars, mobile adaptive toolbars, and vertical side toolbars.  

Competitors (Telerik UI for Blazor Toolbar, DevExpress DxToolbar, Fluent UI Toolbar, MudBlazor MudToolBar, Ignite UI Toolbar, Radzen, Syncfusion EJ2 Toolbar, and modern Office Command Bar patterns) already ship mature solutions. The Toolkit currently has button, dropdown, and layout primitives but **no first-class Toolbar**.  

**Gap**: An industrial-strength, open-source, Blazor-native Toolbar that is fully accessible (WCAG 2.2 AA release gate, AAA target), AOT/trimming-safe, CSS-isolation compatible, high-contrast ready, RTL-ready, zero commercial dependency, and competitive with or superior to the above libraries.

---

## 2. Vision & Goals

### Vision
Provide the best open-source Blazor Toolbar available—enterprise-ready out of the box, zero commercial dependency, minimal JavaScript, complete accessibility, and excellent developer experience.

### Primary Goals

| ID | Goal |
|----|------|
| G1 | Ship `SfToolbar` with horizontal & vertical orientation, full item types (Button, Toggle, Separator, Spacer, Group, SplitButton, DropDownButton, MenuButton, Radio/Check groups), templates, and data-binding |
| G2 | Robust overflow handling: Popup, Scrollable, MultiRow, Extended modes with priority-based overflow |
| G3 | Full keyboard navigation + WAI-ARIA toolbar pattern |
| G4 | Enabled / Visible state management per item |
| G5 | Templates for custom content |
| G6 | WCAG 2.2 AA release gate and full WAI-ARIA toolbar pattern (AAA is a target with no gate, ADR-007) |
| G7 | Windows forced-colors + High Contrast themes |
| G8 | CSS isolation + `SfThemeRoot` / theme tokens |
| G9 | RTL-safe layout and localization/globalization |
| G10 | **0 build warnings** (including CS1591 via complete XML docs), 0 trim/AOT/analyzer warnings |
| G11 | Bundle impact ≤ 15 KB gzipped (JS interop only when strictly necessary for measurement) |
| G12 | Feature parity or superiority vs primary competitors (≥ 95 % checklist coverage) |

### Non-Goals (v1.0)
- Full Office-style Ribbon (tabs + contextual tabs) → future `SfRibbon`
- Built-in global command registry / keyboard-shortcut service (community extension)
- Virtualization of > 500 items (document as future enhancement after benchmarks)
- CardView-style data virtualization or complex nested ribbons

---

## 3. Target Users & Use Cases

| Persona | Typical Use Case |
|---------|------------------|
| Enterprise Blazor developer | Replace Telerik / DevExpress toolbar in line-of-business apps |
| Open-source maintainer | Need a production-grade free toolbar |
| Accessibility-focused team | Must pass internal WCAG 2.2 AA audits |
| WASM / AOT team | Must have zero trim warnings and small payload |

**Primary scenarios**:
- Application command bars
- Editor toolbars (Rich Text, Spreadsheet, Diagram)
- Grid / TreeList / Scheduler toolbars
- Mobile-responsive adaptive toolbars
- Vertical side toolbars
- Dashboard action bars
- Profile / settings toolbars

---

## 4. Success Metrics

| Metric | Target |
|--------|--------|
| Feature coverage vs primary competitors (Telerik, DevExpress, MudBlazor, Fluent, Radzen, EJ2) | ≥ 95 % |
| Automated test coverage of public API | 100 % |
| Statement coverage on Toolbar types | ≥ 85 % |
| axe-core critical / serious issues | 0 |
| NVDA / Narrator / JAWS critical issues | 0 |
| Trim / AOT warnings | 0 |
| Build / analyzer warnings (incl. CS1591) | 0 |
| Resize + overflow recalculation (100 items) | < 16 ms |
| First meaningful paint impact | < 5 ms |
| Bundle impact (gzipped, JS interop only when needed) | ≤ 15 KB |

**Accessibility test-host routes**: 12 routes, defined in [ADR-010](adr/ADR-010-accessibility-route-list.md).

---

## 5. Release Phases

### Phase 1 – MVP (must-have) – P0
- Horizontal & vertical orientation
- Core items: Button, Toggle, Separator, Spacer, Group
- Overflow modes: Popup & Scrollable
- Priority-based overflow
- Full keyboard navigation + ARIA toolbar pattern
- Declarative content (`ChildContent`) and per-item templates
- Item Enable / Disable / Visible state
- RTL skeleton
- Basic theming, CSS isolation and forced-colors support (ADR-008)

### Phase 2 – Completeness – P1
- MultiRow & Extended overflow modes
- Advanced items: SplitButton, DropDownButton, MenuButton (including their documented single-level nested interactions)
- Radio / Check groups
- Data-binding (`Items` collection / `ToolbarItem` models)
- Localization & Globalization
- Theme tokens
- Overflow events (`OnOverflowOpen`, `OnOverflowClose`)
- Hoverable / focus management refinements

### Phase 3 – Delight & Polish – P2
- Nested multi-level command menus beyond the Phase 2 item behavior
- Toolbar personalization API (show/hide items, reorder – optional)
- Search-box integration sample
- Mobile gesture refinements
- Performance polish & optional virtualization study
- Full accessibility samples and documentation
- CHANGELOG, PR merge readiness

### Phase 0 (Pre-implementation; not a release phase)
- Finalize Spec, public API surface, competitor matrix, XML-doc sign-off

---

## 6. Quality Gates (Mandatory)

- Windows High Contrast / forced-colors mode
- CSS isolation with scoped styles
- Scoped CSS IDs
- Responsive (mobile / tablet / desktop)
- Browser matrix: Chrome, Edge, Firefox, Safari (latest 2 major versions)
- Hosting models: Static SSR, Interactive Server, Interactive WebAssembly, Interactive Auto
- No runtime console errors
- No accessibility warnings in CI (axe-core)
- Complete XML documentation (0 CS1591 warnings)
- RTL + localization for any built-in strings
- Zero trim / AOT / analyzer warnings

---

## 7. Dependencies & Constraints

- **No dependency** on commercial Syncfusion.Blazor packages
- Prefer pure Blazor; JS interop **only** for ResizeObserver / measurement (or pure CSS container queries if feasible)
- Must reuse existing Toolkit primitives (`SfButton`, theme system, `SfThemeRoot`) where possible; `SfDropDownButton` and `SfMenu` do not ship in the Toolkit (ADR-014)
- Namespace: `Syncfusion.Blazor.Toolkit`
- MIT license
- Target frameworks: net8.0 / net9.0 / net10.0

---

## 8. API Surface Expectations (High-level – detailed in Spec)

### Root Component
- `SfToolbar`
  - Orientation (Horizontal / Vertical)
  - OverflowMode (Popup | Scrollable in Phase 1; MultiRow | Extended in Phase 2)
  - Priority / OverflowOption
  - CssClass
  - AriaLabel
  - Declarative child items in Phase 1; `Items` collection / `ItemTemplate` in Phase 2
  - `ChildContent` / per-item templates
  - Events: `OnItemClick` in Phase 1; `OnOverflowOpen` / `OnOverflowClose` in Phase 2

### Item Types / Building Blocks
- `ToolbarItem`
- Button, ToggleButton, Separator, Spacer, Group
- SplitButton, DropDownButton, MenuButton (Phase 2)
- RadioGroup / CheckGroup (Phase 2)
- Custom template items

### Key Behaviors
- Priority-based overflow (lower priority items move to overflow first)
- Keyboard navigation (Arrow keys, Home/End, Enter/Space, Tab/Shift+Tab)
- Focus management and roving tabindex
- ARIA roles: `toolbar`, `group`, `separator`, `button`, etc.
- Clickable items vs nested interactive elements (document event handling / stopPropagation strategy)

---

## 9. Accessibility Requirements

- Full WAI-ARIA Authoring Practices Toolbar Pattern
- WCAG 2.2 AA release gate; AAA is a target with no gate (ADR-007)
- Keyboard-only operable
- Screen reader support (NVDA, Narrator, JAWS, VoiceOver)
- High Contrast / forced-colors
- Focus indicators visible in all themes
- `aria-disabled`, `aria-pressed` (for toggles), `aria-haspopup`, `aria-expanded` as appropriate
- Loading / busy states (if applicable) with `aria-busy`
- Proper labeling of overflow popup / menu

---

## 10. Theming, Styling & Layout

- CSS isolation compatible
- Consume tokens from `SfThemeRoot` / design system
- Variants support via CSS classes / theme tokens
- High Contrast and forced-colors ready
- RTL layout (logical properties preferred)
- Responsive behavior (overflow adapts to container size)
- Elevation / shadow only when required by theme (not forced)

---

## 11. Risks & Mitigations

| Risk | Mitigation |
|------|------------|
| Measurement complexity (overflow) | Prefer ResizeObserver only when necessary; evaluate pure CSS container queries first; isolate JS interop |
| Clickable / interactive items vs nested buttons | Clear documentation + event stopPropagation guidance; role strategy documented in Spec |
| API sprawl from many item types | Fixed, well-documented set of item types + free-form template escape hatch |
| Performance with many items | Benchmark early; document virtualization as future; keep overflow recalc < 16 ms for 100 items |
| A11y regressions | Automated axe + manual screen-reader checklist in CI and PR template |
| Bundle size creep | Strict budget (≤ 15 KB gzipped); tree-shakable; JS only for measurement |

---

## 12. Open Questions (to be resolved in Spec)

1. Exact measurement strategy (pure CSS container queries vs ResizeObserver vs hybrid).
2. Overflow popup composition: resolved to an inline lightweight popup built from `SfButton` (ADR-006).
3. Default overflow mode: resolved to `Popup` (ADR-001).
4. Data-bound `Items` and declarative children: resolved, both are kept (ADR-011).
5. Level of personalization API in v1 (show/hide/reorder) vs later.
6. Integration points with future `SfRibbon`.

---

## 13. Competitor Feature Checklist (Target ≥ 95 %)

Must cover core capabilities present in:
- Telerik UI for Blazor Toolbar
- DevExpress DxToolbar
- Fluent UI Toolbar / CommandBar
- MudBlazor MudToolBar
- Radzen Toolbar
- Syncfusion EJ2 Toolbar
- Office-style adaptive command bars

Key areas: orientation, overflow modes, item types, templates, data-binding, keyboard/ARIA, theming, RTL, disable/visible, events, responsive behavior.

---

## 14. Documentation & Samples Deliverables

- Complete XML docs on all public APIs
- Accessibility samples (12 routes, ADR-010)
- Responsive demos (mobile / tablet / desktop)
- Vertical toolbar sample
- Overflow priority demo
- Template & custom item demo
- RTL + High Contrast demos
- Integration samples (with Grid, Editor, etc. where relevant)

### Six Sample Browser demos

The six demos are defined only in [sample-preparer.md](sample-preparer.md). Accessibility routes are listed in [ADR-010](adr/ADR-010-accessibility-route-list.md).

---

**Document Owner**: Toolkit Team  
**Status**: Approved  
**Next Step**: Create detailed Technical Specification (API reference, ARIA mapping, overflow algorithm, measurement strategy, competitor gap analysis).