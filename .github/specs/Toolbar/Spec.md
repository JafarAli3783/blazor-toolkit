# Technical Specification – SfToolbar  
**Syncfusion Blazor Toolkit**  

| Field | Value |
|-------|--------|
| **Document Status** | Approved (no implementation yet; see [Evidence.md](Evidence.md)) |
| **Prefix** | `TB` |
| **Component** | `SfToolbar` |
| **Namespace** | `Syncfusion.Blazor.Toolkit` |
| **Target Frameworks** | .NET 8 / .NET 9 / .NET 10 |
| **License** | MIT |
| **Repo** | https://github.com/syncfusion/blazor-toolkit |
| **Render modes** | Static SSR, Interactive Server, Interactive WebAssembly, Interactive Auto |
| **Version** | 2.0 |

---

## 1. Purpose

Define the complete technical design for the open-source `SfToolbar` component so that an engineer or AI coding assistant can implement it with minimal additional clarification.  

The component must be:
- Blazor-native
- AOT / trimming-safe (zero warnings)
- WCAG 2.2 AA conformant as the release gate, with AAA as a non-gated target (ADR-007)
- CSS-isolation compatible with **scoped ID** support
- Competitive with (or superior to) Telerik UI for Blazor Toolbar, DevExpress DxToolbar, Fluent UI Toolbar / CommandBar, MudBlazor MudToolBar, Ignite UI Toolbar, Radzen, and Syncfusion EJ2 Toolbar
- Zero commercial dependency
- Bundle impact ≤ 15 KB gzipped (JS interop only when strictly necessary)
- Built exclusively by composing components that already ship in the Syncfusion Blazor Toolkit (no commercial Syncfusion packages, no third-party UI libraries, and no raw HTML interactive controls when a Toolkit primitive exists)

---

## 2. Component Architecture Overview

```
SfToolbar (root)
│
├── ToolbarItemCollection          (internal observable collection)
│   ├── ToolbarItem
│   ├── ToolbarGroup               (role="group")
│   ├── ToolbarSeparator           (role="separator")
│   ├── ToolbarSpacer
│   └── ToolbarTemplateItem
│
├── OverflowManager                (internal)
│   ├── VisibilityCalculator
│   ├── PrioritySorter
│   └── OverflowPopupHost
│
└── LayoutEngine
    ├── CSS Flexbox (row / column)
    └── Minimal ResizeObserver interop (or pure CSS container queries if feasible)
```

### Core Responsibilities

| Component / Service       | Responsibility |
|---------------------------|----------------|
| `SfToolbar`               | Owns orientation, overflow mode, alignment, focus management, ARIA, public API, CSS isolation root |
| `ToolbarItem`             | Individual command – implemented by composing Toolkit primitives only |
| `ToolbarGroup`            | Semantic + visual grouping |
| `ToolbarSeparator`        | Visual divider |
| `ToolbarSpacer`           | Flexible space |
| `ToolbarTemplateItem`     | Arbitrary content that still participates in overflow |
| `OverflowManager`         | Calculates visible vs overflowed items |
| `LayoutEngine`            | Flexbox layout + size observation |

---

## 3. Public Component Model

### 3.1 Core Components

- `SfToolbar`
- `ToolbarItem`
- `ToolbarGroup`
- `ToolbarSeparator`
- `ToolbarSpacer`
- `ToolbarTemplateItem`

### 3.2 Supporting Models

- `ToolbarItemModel`
- `ToolbarOverflowSettings`
- `ToolbarTemplateContext`
- `ToolbarItemClickEventArgs`

### 3.3 Enumerations

- `ToolbarOrientation`        (Horizontal, Vertical)
- `ToolbarAlignment`          (Start, Center, End, Justify)
- `ToolbarOverflowMode`       (Scrollable, Popup, MultiRow, Extended)
- `ToolbarOverflowOption`     (Show, Hide, None)
- `ToolbarItemType`           (Button, Toggle, Split, DropDown, Menu, Separator, Spacer, Template)
- `ToolbarItemDisplayMode`    (IconOnly, TextOnly, IconAndText)

### 3.4 Phase and API contract

The Phase column of the registry in section 22 is the only authority for which requirement ships in which release. The meanings of P0, P1 and P2, and the status vocabulary, are defined once in the introduction of section 22 and in ADR-013. This section does not repeat them.

---

## 4. State Management

### 4.1 Item Registration Lifecycle

1. Child implements `IToolbarItem`.
2. In `OnInitialized` the child calls `Parent.Register(this)`.
3. Parent adds the item to `ToolbarItemCollection` and subscribes to change notifications.
4. When any relevant parameter changes (`Enabled`, `Visible`, `Overflow`, `Priority`, `Selected`, etc.) the child calls `NotifyStateChanged()`.
5. In `Dispose` the child calls `Parent.Unregister(this)` and releases resources.

### 4.2 Overflow Recalculation Triggers

- Container size change (ResizeObserver or container query)
- Item collection changed (add / remove / clear)
- Any item `Visible`, `Enabled`, `Overflow`, or `Priority` changed
- `Orientation` or `OverflowMode` changed
- Explicit call to `RefreshOverflowAsync()`

Recalculation is debounced (default ≤ 16 ms) and executed on the renderer’s synchronization context.

### 4.3 Command State Tracking

- Toggle items expose two-way bindable `Selected`.
- Items that share the same `GroupName` form a radio group (only one may be selected).
- Disabled or hidden items are excluded from tab order and from overflow measurement.

### 4.4 Disposal Patterns

- Every registered item must unregister itself.
- Event handlers and JS interop references must be released in `Dispose`.
- No lingering references that prevent garbage collection.

---

## 5. Rendering Strategy

### 5.1 Main Toolbar

- Pure CSS Flexbox (`display: flex`, `flex-direction: row | column`).
- Gap controlled by CSS custom properties.
- Alignment mapped to `justify-content` / `align-items`.

### 5.2 Conditional Rendering

- Items with `Overflow = Hide` never appear in the main bar.
- Items with `Visible = false` are not rendered at all.
- Disabled items remain in the DOM but are non-interactive and skipped by keyboard navigation.

### 5.3 Template Rendering

- Declarative items use `ChildContent` or `Template`.
- Data-bound items (Phase 2 / P1) use `ItemTemplate` of type `RenderFragment<ToolbarTemplateContext>`.
- Context exposes `Item` and `IsOverflow`.
- `ToolbarGroup` uses ordinary `ChildContent`; group-level templates are not part of this API.

### 5.4 Overflow Rendering

- Overflowed items are rendered inside a lightweight popup (`role="menu"`).
- Overflow button appears only when at least one item is overflowed.
- Popup supports keyboard navigation and closes on selection (configurable).
- Overflow button and any interactive items inside the popup must be built from Toolkit primitives only.

### 5.5 Responsive Rendering

- Layout reacts to **container size**, not only viewport size.
- Supports mobile, tablet, and desktop breakpoints.

### 5.6 Null-safe & Trimming-safe Rules

- No reflection on user models.
- All templates are compile-time `RenderFragment`s.
- No dynamic code generation that would break AOT.

### 5.7 Stable Test Hooks

Every major element must expose a stable `data-testid` (see Test Matrix):

- `toolbar-root`
- `toolbar-item`
- `toolbar-button` / `toolbar-toggle` / `toolbar-separator` / `toolbar-spacer` / `toolbar-group`
- `toolbar-overflow-button` / `toolbar-overflow-popup` / `toolbar-overflow-item`
- etc.

Prefer `data-testid` + ARIA roles for all automated tests.

### 5.8 Component Reuse

The Toolbar composes components that already ship in the Toolkit and adds no commercial or third-party UI dependency (`TB-CMP-070`). Overflow entries are built from `SfButton` inside the inline toolbar popup (`TB-OVF-170`, ADR-006). The Toolbar does not use `SfDialog` or `SfTooltip` for that popup.

`SfButtonGroup` is not used for layout. `SfCheckBox`, `SfRadioButton` and `SfSwitch` appear only in templates or in the radio and check item types (`TB-CMP-100`, ADR-014).

Raw HTML is allowed only for non-interactive structure such as separators, spacers and layout wrappers. Reusing Toolkit components keeps behavior, accessibility, theming and CSS isolation consistent with the rest of the Toolkit.

---

## 6. Overflow Algorithm (Responsive-First)

```
1. Measure available content-box size of the toolbar.
2. Stable-sort items by:
   a. OverflowOption (Show → None → Hide)
   b. Priority (ascending)
   c. Original declaration order
3. Greedily place items while remaining space ≥ item size + gap.
4. Mark all remaining items as Overflowed.
5. If any Overflowed items exist → show Overflow button.
6. In RTL mode, measurement and placement are mirrored.
```

### Supported Modes

| Mode         | Behavior |
|--------------|----------|
| `Scrollable` | Single line with horizontal/vertical scrolling |
| `Popup`      | Overflow items move into a “More” menu (**default recommended**) |
| `MultiRow`   | Overflow items wrap onto additional rows |
| `Extended`   | Extra rows are collapsed behind an expand button |

**Measurement strategy**: Prefer pure CSS container queries where feasible. Fall back to a minimal ResizeObserver + `getBoundingClientRect` interop only when required for accurate overflow calculation. JS surface must remain as small as possible.

---

## 7. Framework-Specific Overrides (Blazor Toolkit)

The registry in section 22 owns every rule. This table only points at the ids.

| Concern | Registry ids |
|---|---|
| JavaScript surface | `TB-OVF-110`, `TB-SEC-040` |
| AOT and trimming | `TB-CMP-050`, `TB-CMP-080` |
| CSS isolation | `TB-ISO-010` to `TB-ISO-050` |
| Theme | `TB-THM-010` to `TB-THM-020` |
| Render modes | `TB-CMP-020`, `TB-LIF-020` to `TB-LIF-050` |
| Focus management | `TB-KBD-110` |
| Commercial dependencies | `TB-CMP-070` |
| Bundle budget | `TB-PRF-050` |
| Composition | `TB-OVF-170`, `TB-CMP-100`, ADR-006, ADR-014 |

### 7.1 CSS Isolation and Scoped ID Concept

The testable rules are `TB-ISO-010` to `TB-ISO-050`, `TB-THM-010` to `TB-THM-020` and `TB-A11Y-130`. This section explains the concept behind them.

**Scoped ID concept.** The root element of `SfToolbar` exposes a stable identity made of three parts: the Toolkit class `e-toolbar`, the optional consumer `Id` and `CssClass`, and the scope attribute that Blazor adds (for example `b-aaaaaaaaaa`). Tests and styles target this identity, so they stay valid when several toolbars share a page.

**Why descendant selectors must survive isolation.** Blazor adds the scope attribute to elements the component renders. Items, the overflow button and the popup are styled with descendant selectors from the root. Those selectors must still match once the attribute is present. Theme tokens and forced-colors rules apply only inside the intended theme scope (`SfThemeRoot` or `SfThemeScope`).

**Implementation guidance.**
- Write component CSS with isolation in mind from the first commit.
- Prefer structured class names over `::deep`.
- Use logical properties and CSS custom properties for RTL and theming.

---

## 8. Accessibility Specification

### 8.1 Required ARIA Roles & Attributes

| Element            | Role / Attribute                          |
|--------------------|-------------------------------------------|
| Root               | `role="toolbar"`, `aria-orientation`, `aria-label` / `aria-labelledby` |
| Group              | `role="group"`, `aria-label`              |
| Separator          | `role="separator"`                        |
| Overflow button    | `aria-haspopup="menu"`, `aria-expanded`, `aria-controls` |
| Overflow popup     | `role="menu"`                             |
| Menu items         | `role="menuitem"`                         |
| Toggle items       | `aria-pressed`                            |
| Disabled item      | `aria-disabled="true"`                    |

### 8.2 Keyboard Interactions (Mandatory)

| Key              | Action |
|------------------|--------|
| `Tab` / `Shift+Tab` | Enter or leave the toolbar (single tab stop) |
| `Right` / `Down` | Move to next enabled item (orientation-aware) |
| `Left` / `Up`    | Move to previous enabled item |
| `Home`           | Move to first enabled item |
| `End`            | Move to last enabled item |
| `Enter` / `Space`| Activate the focused item |
| `Escape`         | Close overflow menu or nested menu |

### 8.3 Focus Management

- Roving `tabindex` (only one item has `tabindex="0"` at a time).
- Focus is restored to the last focused item when returning to the toolbar.
- Disabled and hidden items are skipped.
- Overflow menu participates in the keyboard flow.

### 8.4 Screen Reader Support

Screen-reader validation is manual. It runs against [MANUAL-VALIDATION.md](MANUAL-VALIDATION.md). A named reviewer must sign off before release; the reviewer is currently unassigned (status: Pending).

Required announcements:
- Overflow open and close
- Toggle state changes (`aria-pressed`)
- Disabled state

### 8.5 High Contrast & Forced Colors

- Uses system colors (`Canvas`, `Highlight`, `ButtonText`, etc.).
- Must work under Windows High Contrast and the `forced-colors` media query.
- Styles must remain correct under CSS isolation.

**Release gate:** WCAG 2.2 AA. AAA is a target with no gate (see [ADR-007](adr/ADR-007-accessibility-target.md)).

### 8.6 Accessibility Sample Pages (required for CI)

The accessibility host serves 12 routes. The list and the phase of each route live in [ADR-010](adr/ADR-010-accessibility-route-list.md). Requirements `TB-SMP-020` and `TB-SMP-030` make them a release gate. These pages are the source of truth for axe-core and screen-reader validation.

---

## 9. Performance Guidance

| Scenario                        | Target |
|---------------------------------|--------|
| 100 items – layout + render     | < 16 ms |
| Dynamic add/remove of 20 items  | < 10 ms |
| Resize / overflow recalculation | Debounced ≤ 16–32 ms |
| First meaningful paint impact   | < 5 ms |
| Memory                          | Items must fully unregister and dispose |

### Recommendations

- Prefer fine-grained `StateHasChanged` on individual items.
- Avoid re-creating `RenderFragment` instances on every render.
- Virtualization is **not** required for v1; document as a future enhancement for extremely large command sets (> 200–500 items).

---

## 10. Localization, Globalization & RTL

- All built-in strings (overflow button tooltip, aria-labels, etc.) go through the Toolkit localization system.
- `EnableRtl` can be set locally or inherited from a parent cascade.
- Layout, overflow placement, and arrow-key direction reverse in RTL.
- Culture changes must update any localized text without full re-creation of the component.
- RTL must function correctly with CSS isolation and scoped styles (use logical properties).

---

## 11. Theming & Styling

- Light, Dark, and High-Contrast themes via CSS custom properties from `SfThemeRoot` / `SfThemeScope`.
- No hard-coded colors in component logic.
- Optional size variants (Small / Medium / Large) via CSS classes.
- **Fully compatible with CSS isolation and scoped identifiers** (see Section 7.1).
- Root class follows Toolkit conventions (e.g. `.e-toolbar`).
- Consumer `CssClass` and `HtmlAttributes` are applied on the root without breaking isolation.
- Because interactive items reuse Toolkit primitives such as `SfButton`, theming and high-contrast behavior are inherited automatically.

---

## 12. Browser & Platform Support

**Browsers**
- Chrome / Chromium (latest 2 versions)
- Edge (latest 2 versions)
- Firefox (latest 2 versions)
- Safari / WebKit (latest 2 versions)

**Hosting models**
- Static SSR (non-interactive)
- Interactive Server
- Interactive WebAssembly
- Interactive Auto

**Quality gates (mandatory)**
- Zero trim / AOT warnings
- Zero analyzer warnings
- Zero build warnings (including CS1591)
- Zero runtime console errors
- Zero accessibility warnings in CI (axe-core critical/serious = 0)
- CSS isolation verified
- High Contrast / forced-colors verified

---

## 13. Internal Interfaces (Non-Public)

```csharp
internal interface IToolbarItem : IDisposable
{
    string Id { get; }
    ToolbarOverflowOption Overflow { get; }
    int Priority { get; }
    bool Visible { get; }
    bool Enabled { get; }
    RenderFragment Render(bool isOverflow);
    void NotifyStateChanged();
}
```

These interfaces exist only to support the registration and overflow system. They are **not** part of the public API.

---

## 14. Alignment with PRD & Test Matrix

This specification incorporates:

- The feature scope of the PRD release phases.
- The PRD non-goals (Ribbon, global command registry, heavy virtualization).
- The PRD success metrics (performance, accessibility, bundle size, zero warnings).
- The automated test expectations in [TEST-MATRIX.md](TEST-MATRIX.md).
- Mandatory `data-testid` hooks and accessibility sample routes (ADR-010).

Test presence is measured by the harness gate component-traceability; TRACEABILITY.md is generated (see ADR-015).

---

## 15. Future Extension Points (Out of Scope for v1)

- Full Office-style Ribbon (`SfRibbon`) built on top of Toolbar primitives
- Command personalization / user reordering with persistence
- Global command registry + keyboard shortcut service
- Virtualization for extremely large command sets
- Touch-specific overflow gestures

---

## 16. Implementation Notes for AI / Engineers

1. Start with the public API surface defined in `API.md` and `API-xml.md`.
2. Implement item registration and the overflow calculator first—these are the most complex parts.
3. Keep JavaScript interop to an absolute minimum; prefer CSS container queries when possible.
4. **Implement all styles with CSS isolation and scoped IDs from the beginning** (Section 7.1).
5. Write unit tests for every public parameter and every overflow mode × priority combination.
6. Provide the accessibility sample pages listed in Section 8.6 and wire them into the axe-core test host.
7. Validate accessibility with axe-core (zero critical/serious) and complete the manual screen-reader validation (section 8.4) before considering the feature complete.
8. Ensure the component produces no trim / AOT / analyzer warnings when published with `PublishTrimmed=true` and `PublishAot=true`.
9. Follow the Definition of Done in `TEST-MATRIX.md` — no mandatory manual test gate.
10. Reuse only Toolkit components and follow section 5.8 (`TB-CMP-070`, `TB-OVF-170`, `TB-CMP-100`).


## 17. Sample Browser contract (six demos)

The six demos and their descriptions are defined only in [sample-preparer.md](sample-preparer.md). The accessibility routes are listed in [ADR-010](adr/ADR-010-accessibility-route-list.md).

---

## 18. Security

- Every consumer string (`Text`, `IconCss`, `Tooltip`, `Badge`, `Id`) is rendered through Razor escaping. No `MarkupString` receives these values (`TB-SEC-010`, `TB-SEC-020`).
- `CssClass` and `HtmlAttributes` are trust-boundary inputs. The consumer must not fill them from untrusted data (`TB-SEC-030`).
- The component uses no `eval`, `new Function` or inline script, so a strict Content Security Policy works (`TB-SEC-040`, `TB-SEC-050`).
- Interop calls check a disposed flag and catch `JSDisconnectedException` (`TB-SEC-060`).
- Raw HTML is limited to non-interactive structure (`TB-SEC-070`, ADR-006).

## 19. Lifecycle and Static SSR handover

- Items register with the parent on initialization and unregister on dispose (`TB-LIF-010`).
- Static SSR renders markup only. Overflow degrades to wrapping or scrolling by CSS (`TB-LIF-020`, ADR-012).
- The first interactive render starts measurement once (`TB-LIF-030`). The prerender-to-interactive handover reconciles markup and does not recreate item state (`TB-LIF-040`).
- State lives in parameters, so an Auto-mode move from Server to WebAssembly keeps it (`TB-LIF-050`).
- `DisposeAsync` clears interop references and tolerates a disconnected circuit. A disposed flag turns late callbacks into no-ops (`TB-LIF-060`, `TB-LIF-070`).

## 20. Compatibility

- Target frameworks: net8.0, net9.0, net10.0 (`TB-CMP-010`).
- Render modes: Static SSR, Server, WebAssembly, Auto (`TB-CMP-020`).
- Browsers: latest two versions of Chromium, Edge, Firefox and WebKit (`TB-CMP-030`).
- Public API changes are additive (`TB-CMP-040`). Trim and AOT publish is warning-free (`TB-CMP-050`).

## 21. Validation

Rendering must not throw on bad input. Duplicate item ids, an invalid enum value, a negative `Priority` and a zero-width container render deterministically (`TB-LIF-090`, `TB-LIF-100`). The overflow algorithm treats a negative `Priority` as a lower value, so the item stays visible longer.

## 22. Requirement registry

Each row is one testable sentence. MUST maps to level M, SHOULD to R and MAY to O. Phases are P0 (first release), P1 (next) and P2 (later). The ID prefix is `TB`. IDs are never renumbered or reused. A withdrawn requirement keeps its row. The last column, Status, uses the ADR-013 values. A row moves to Implemented only when its feature works and its automated tests pass in the current session, and to Verified only when the layer in the Verification column has passed and the result is recorded in [Evidence.md](Evidence.md). A row that needs a person stays Approved until that person signs.

The verification column names a test layer from the spec-kit test architecture. [TEST-MATRIX.md](TEST-MATRIX.md) lists the test ids and [TRACEABILITY.md](TRACEABILITY.md) links every row to ACs, tasks and tests.

### Public API (API)

| ID | Level | Phase | Requirement | Verification | Status |
| --- | --- | --- | --- | --- | --- |
| `TB-API-010` | M | P0 | `SfToolbar` MUST live in namespace `Syncfusion.Blazor.Toolkit` and derive from `SfBaseComponent`. | L6 public API inventory | Implemented |
| `TB-API-020` | M | P0 | `SfToolbar.Orientation` MUST default to `Horizontal` and accept `Horizontal` or `Vertical`. | L1 bUnit assertion | Verified |
| `TB-API-030` | M | P0 | `SfToolbar.OverflowMode` MUST default to `Popup` (ADR-001). | L1 bUnit assertion | Verified |
| `TB-API-040` | M | P0 | `SfToolbar.Align` MUST default to `Start` and accept `Start`, `Center`, `End`, `Justify` (ADR-002). | L1 bUnit assertion | Verified |
| `TB-API-050` | M | P0 | `SfToolbar` MUST expose `CssClass`, `HtmlAttributes`, `AriaLabel`, `EnableRtl` (`bool?`, default `null`) and `ChildContent` parameters. | L1 bUnit assertion | Verified |
| `TB-API-060` | M | P0 | `SfToolbar.OnItemClick` MUST be an `EventCallback<ToolbarItemClickEventArgs>` that fires for every item click. | L1 bUnit assertion | Verified |
| `TB-API-070` | M | P0 | `SfToolbar` MUST expose `RefreshOverflowAsync()`, `FocusAsync()`, `GetVisibleItems()` and `GetOverflowItems()`. | L1 bUnit assertion | Verified |
| `TB-API-080` | M | P0 | `SfToolbar` MUST NOT expose a toolbar-wide `Enabled` parameter (ADR-005). | L6 public API inventory | Verified |
| `TB-API-090` | M | P0 | `ToolbarItem` MUST expose `Id`, `Text`, `IconCss`, `IconPosition`, `Type`, `Enabled`, `Visible`, `Selected`, `Overflow`, `Priority`, `Tooltip`, `Badge`, `CssClass`, `DisplayMode`, `GroupName`, `ChildContent`, `Template` and `OnClick`. | L1 bUnit assertion | Verified |
| `TB-API-100` | M | P0 | `ToolbarItem.Selected` MUST support `@bind-Selected` through a `SelectedChanged` callback. | L1 bUnit assertion | Verified |
| `TB-API-110` | M | P0 | `ToolbarItem` defaults MUST be `Type=Button`, `Enabled=true`, `Visible=true`, `Overflow=None`, `Priority=0`, `DisplayMode=IconAndText`. | L1 bUnit assertion | Verified |
| `TB-API-120` | M | P0 | `ToolbarGroup` MUST expose `Label`, `ChildContent` and `CssClass` only; it MUST NOT expose a group template. | L6 public API inventory | Implemented |
| `TB-API-130` | M | P0 | `ToolbarSeparator` MUST expose `Visible` and `CssClass`; `ToolbarSpacer` MUST expose `CssClass`. | L1 bUnit assertion | Verified |
| `TB-API-140` | M | P0 | `ToolbarTemplateItem` MUST expose `ChildContent`, `Overflow` and `Priority`. | L1 bUnit assertion | Verified |
| `TB-API-150` | M | P0 | `ToolbarItemClickEventArgs` MUST expose `ItemId`, `Item`, `OriginalArgs` and a settable `bool Cancel` (ADR-004). | L1 bUnit assertion | Verified |
| `TB-API-160` | M | P0 | The enums `ToolbarOrientation`, `ToolbarAlignment`, `ToolbarOverflowMode`, `ToolbarOverflowOption`, `ToolbarItemType` and `ToolbarItemDisplayMode` MUST have exactly the members listed in `API.md`. | L6 public API inventory | Implemented |
| `TB-API-170` | M | P0 | `ToolbarOverflowMode` MUST define `Scrollable`, `Popup`, `MultiRow` and `Extended`. | L6 public API inventory | Verified |
| `TB-API-180` | M | P0 | Every public member MUST have XML documentation so the build reports zero CS1591 warnings. | L6 build | Implemented |
| `TB-API-190` | M | P0 | `IToolbarItem` and `ToolbarItemCollection` MUST be `internal`. | L6 public API inventory | Implemented |
| `TB-API-200` | R | P0 | `HtmlAttributes` SHOULD use `CaptureUnmatchedValues` where the Toolkit pattern does so. | L1 bUnit assertion | Verified |
| `TB-API-210` | M | P1 | `SfToolbar.Items` MUST be an `IEnumerable<ToolbarItemModel>` data source (ADR-011). | L1 bUnit assertion | Implemented |
| `TB-API-220` | M | P1 | `SfToolbar.ItemTemplate` MUST be a `RenderFragment<ToolbarTemplateContext>` used for items from `Items`. | L1 bUnit assertion | Implemented |
| `TB-API-230` | M | P1 | `SfToolbar.OverflowSettings` MUST expose `ShowOverflowButton`, `OverflowButtonIconCss`, `OverflowButtonTooltip`, `PopupCssClass` and `CloseOnSelect`. | L1 bUnit assertion | Implemented |
| `TB-API-240` | M | P1 | `SfToolbar` MUST expose `OnOverflowOpen` and `OnOverflowClose` callbacks (ADR-009). | L1 bUnit assertion | Implemented |
| `TB-API-250` | M | P1 | `ToolbarItem.Items` MUST be a `RenderFragment` of nested `ToolbarItem` used by Split, DropDown and Menu types (ADR-011). | L1 bUnit assertion | Implemented |
| `TB-API-260` | M | P1 | `ToolbarTemplateContext` MUST expose `Item` and `IsOverflow`. | L1 bUnit assertion | Implemented |

### Items and data model (ITM)

| ID | Level | Phase | Requirement | Verification | Status |
| --- | --- | --- | --- | --- | --- |
| `TB-ITM-010` | M | P0 | The toolbar MUST render declarative `ToolbarItem`, `ToolbarGroup`, `ToolbarSeparator`, `ToolbarSpacer` and `ToolbarTemplateItem` children in declaration order. | L1 bUnit assertion | Verified |
| `TB-ITM-020` | M | P0 | An empty toolbar MUST render its root without throwing and without items. | L1 bUnit assertion | Verified |
| `TB-ITM-030` | M | P0 | A `Button` item MUST render as a Toolkit `SfButton`. | L1 bUnit assertion | Verified |
| `TB-ITM-040` | M | P0 | A `Toggle` item MUST render `aria-pressed` equal to `Selected`. | L1 bUnit assertion | Verified |
| `TB-ITM-050` | M | P0 | A `Toggle` item click MUST flip `Selected` and raise `SelectedChanged` unless `Cancel` is set. | L1 bUnit assertion | Verified |
| `TB-ITM-060` | M | P0 | A separator MUST render with `role="separator"` and a spacer MUST render as a non-interactive flexible element. | L1 bUnit assertion | Verified |
| `TB-ITM-070` | M | P0 | A group MUST render `role="group"` with `aria-label` from `Label` and contain its children. | L1 bUnit assertion | Verified |
| `TB-ITM-080` | M | P0 | An item with `Visible=false` MUST NOT be rendered and MUST be excluded from overflow measurement. | L1 bUnit assertion | Verified |
| `TB-ITM-090` | M | P0 | An item with `Enabled=false` MUST stay in the DOM with `aria-disabled="true"` and MUST NOT raise click callbacks. | L1 bUnit assertion | Verified |
| `TB-ITM-100` | M | P0 | `DisplayMode` `IconOnly`, `TextOnly` and `IconAndText` MUST render icon, text or both; `IconOnly` MUST keep `Text` as the accessible name. | L1 bUnit assertion | Verified |
| `TB-ITM-110` | M | P0 | `Tooltip` MUST be supplemental and MUST NOT replace `Text` as the accessible name. | L1 bUnit assertion | Verified |
| `TB-ITM-120` | M | P0 | `Align` values MUST map to documented logical layout: `Start`, `Center`, `End`, `Justify`. | L1 bUnit assertion | Verified |
| `TB-ITM-130` | M | P0 | A `Template` or `ToolbarTemplateItem` MUST render its content and take part in overflow. | L1 bUnit assertion | Verified |
| `TB-ITM-140` | M | P0 | The toolbar MUST handle add, remove, insert, clear and replace of items at runtime and update the DOM. | L2 bUnit integration | Verified |
| `TB-ITM-150` | M | P0 | `OnItemClick` MUST fire after the item-level `OnClick` and receive the clicked item id (ADR-004). | L1 bUnit assertion | Verified |
| `TB-ITM-160` | M | P0 | Setting `ToolbarItemClickEventArgs.Cancel` MUST stop the default action: a Toggle keeps `Selected`, and a Split, DropDown or Menu does not open. | L1 bUnit assertion | Verified |
| `TB-ITM-170` | M | P0 | `OnItemClick` MUST still fire after the item `OnClick` when `Cancel` is set. | L1 bUnit assertion | Verified |
| `TB-ITM-180` | M | P1 | `GroupName` MUST make items with the same name mutually exclusive. | L1 bUnit assertion | Verified |
| `TB-ITM-190` | M | P1 | Split, DropDown and Menu items MUST render with `aria-haspopup` and `aria-expanded` and open nested items. | L1 bUnit assertion | Verified |
| `TB-ITM-200` | M | P1 | Items from `Items` MUST render through `ItemTemplate` or default item rendering, and mixed declarative plus data-bound content MUST render deterministically. | L1 bUnit assertion | Verified |
| `TB-ITM-210` | M | P1 | Check groups MUST allow multi-selection. | L1 bUnit assertion | Verified |
| `TB-ITM-220` | O | P2 | Nested command menus deeper than one level MAY be supported. | L3 Playwright | Approved |
| `TB-ITM-230` | O | P2 | A personalization API (show, hide, reorder) MAY be offered. | L1 bUnit assertion | Approved |
| `TB-ITM-240` | O | P2 | Withdrawn: Ribbon, global command registry and virtualization above 500 items are non-goals for v1. | Not applicable | Approved |

### Overflow (OVF)

| ID | Level | Phase | Requirement | Verification | Status |
| --- | --- | --- | --- | --- | --- |
| `TB-OVF-010` | M | P0 | Overflow MUST order items by `Overflow` (Show, None, Hide), then `Priority` ascending, then declaration order. | L1 bUnit assertion | Verified |
| `TB-OVF-020` | M | P0 | The algorithm MUST place items greedily while remaining space is at least item size plus gap and mark the rest overflowed. | L1 bUnit assertion | Verified |
| `TB-OVF-030` | M | P0 | The overflow button MUST render only when at least one item is overflowed. | L1 bUnit assertion | Verified |
| `TB-OVF-040` | M | P0 | In `Popup` mode overflowed items MUST appear in an inline popup with `role="menu"` rendered by the toolbar (ADR-006). | L1 bUnit assertion | Verified |
| `TB-OVF-050` | M | P0 | In `Scrollable` mode the bar MUST stay on one line and scroll. The native scrollbar is hidden; two chevrons at the inline ends move the scroll position and are disabled at the start and the end (ADR-020). Native touch swipe and mouse wheel continue to work. | L3 Playwright | Verified |
| `TB-OVF-051` | M | P0 | The Scrollable chevrons MUST be hidden when nothing overflows, MUST be disabled when the scroll position is at the corresponding edge of the range, and MUST listen for `pointerdown`, `pointerup`, `pointerleave` and `pointercancel` so press-and-hold scrolls continuously. | L1 bUnit assertion | Verified |
| `TB-OVF-060` | M | P0 | Overflow MUST be recalculated on container resize, item collection change, item `Visible`/`Enabled`/`Overflow`/`Priority` change, `Orientation`/`OverflowMode` change and `RefreshOverflowAsync()`. | L1 bUnit assertion | Verified |
| `TB-OVF-070` | M | P0 | Recalculation MUST be debounced to 16 ms or less on the renderer synchronization context. | L1 bUnit assertion | Verified |
| `TB-OVF-080` | M | P0 | Overflow MUST react to container size, not viewport size. | L3 Playwright | Verified |
| `TB-OVF-090` | M | P0 | The popup MUST close on item selection when `CloseOnSelect` is true, on `Escape` and on outside click. | L3 Playwright | Verified |
| `TB-OVF-100` | M | P0 | When all items are overflowed the popup MUST contain all items and the overflow button MUST be present. | L3 Playwright | Verified |
| `TB-OVF-110` | M | P0 | JavaScript MUST be limited to `ResizeObserver` and `getBoundingClientRect` measurement, with CSS container queries preferred where sufficient. | L6 interop audit | Approved |
| `TB-OVF-120` | M | P0 | Overflow MUST mirror measurement and placement in RTL. | L3 Playwright | Verified |
| `TB-OVF-130` | M | P1 | `MultiRow` mode MUST wrap overflowing items onto additional rows. | L3 Playwright | Verified |
| `TB-OVF-140` | M | P1 | `Extended` mode MUST collapse extra rows behind a three-dot expand control pinned to the inline end of the bar. The control MUST carry the localized `Expand` / `Collapse` label, MUST set `aria-expanded`, and MUST toggle the `e-toolbar-expanded` class on the root. | L3 Playwright | Verified |
| `TB-OVF-150` | M | P1 | `OnOverflowOpen` and `OnOverflowClose` MUST fire when the popup opens and closes. | L1 bUnit assertion | Verified |
| `TB-OVF-160` | R | P1 | The overflow button SHOULD be hidden or disabled when nothing overflows. | L1 bUnit assertion | Verified |
| `TB-OVF-170` | M | P0 | The overflow popup interactive entries MUST be built from `SfButton` (ADR-006). | L1 bUnit assertion | Verified |

### Keyboard (KBD)

| ID | Level | Phase | Requirement | Verification | Status |
| --- | --- | --- | --- | --- | --- |
| `TB-KBD-010` | M | P0 | `Tab` and `Shift+Tab` MUST enter and leave the toolbar through a single tab stop. | L3 Playwright keyboard | Verified |
| `TB-KBD-020` | M | P0 | `ArrowRight` MUST move focus to the next enabled item in a horizontal LTR toolbar and `ArrowLeft` to the previous. | L3 Playwright keyboard | Verified |
| `TB-KBD-030` | M | P0 | In a vertical toolbar `ArrowDown` MUST move to the next enabled item and `ArrowUp` to the previous (ADR-003). | L3 Playwright keyboard | Verified |
| `TB-KBD-040` | M | P0 | In RTL a horizontal toolbar MUST reverse `ArrowLeft` and `ArrowRight`. | L3 Playwright keyboard | Verified |
| `TB-KBD-050` | M | P0 | `Home` MUST move focus to the first enabled item and `End` to the last. | L3 Playwright keyboard | Verified |
| `TB-KBD-060` | M | P0 | `Enter` and `Space` MUST activate the focused item. | L3 Playwright keyboard | Verified |
| `TB-KBD-070` | M | P0 | `Escape` MUST close the overflow popup or an open nested menu. | L3 Playwright keyboard | Verified |
| `TB-KBD-080` | M | P0 | Focus MUST skip disabled, hidden, separator and spacer elements. | L3 Playwright keyboard | Verified |
| `TB-KBD-090` | M | P0 | After the overflow popup closes, focus MUST return to the overflow button. | L3 Playwright keyboard | Verified |
| `TB-KBD-100` | M | P0 | Opening the overflow popup MUST move focus into the popup, and arrow keys MUST navigate its entries. | L3 Playwright keyboard | Verified |
| `TB-KBD-110` | M | P0 | Focus management MUST use C# roving tabindex with no external JavaScript focus library. | L6 interop audit | Approved |
| `TB-KBD-120` | M | P1 | Nested Split, DropDown and Menu entries MUST support arrow-key navigation, and `Escape` MUST return focus to the owner. | L3 Playwright keyboard | Verified |

### Accessibility (A11Y)

| ID | Level | Phase | Requirement | Verification | Status |
| --- | --- | --- | --- | --- | --- |
| `TB-A11Y-010` | M | P0 | The root MUST render `role="toolbar"`. | L1 bUnit assertion | Verified |
| `TB-A11Y-020` | M | P0 | The root MUST render `aria-orientation` equal to the orientation. | L1 bUnit assertion | Verified |
| `TB-A11Y-030` | M | P0 | The root MUST have an accessible name from `AriaLabel` or `aria-labelledby`. | L1 bUnit assertion | Verified |
| `TB-A11Y-040` | M | P0 | Exactly one item MUST have `tabindex="0"` and all others `tabindex="-1"` at any time. | L1 bUnit assertion | Verified |
| `TB-A11Y-050` | M | P0 | Focus MUST be restored to the last focused item when the user returns to the toolbar. | L3 Playwright keyboard | Verified |
| `TB-A11Y-060` | M | P0 | The overflow button MUST render `aria-haspopup="menu"`, `aria-expanded` and `aria-controls`. | L1 bUnit assertion | Verified |
| `TB-A11Y-070` | M | P0 | Overflow entries MUST render `role="menuitem"`. | L1 bUnit assertion | Verified |
| `TB-A11Y-080` | M | P0 | Every sample route listed in ADR-010 MUST report zero axe-core critical or serious violations. | L4 axe scan | Verified |
| `TB-A11Y-090` | M | P0 | The release gate MUST be WCAG 2.2 AA; AAA is a target only (ADR-007). | L4 axe scan | Verified |
| `TB-A11Y-100` | M | P0 | Interactive targets MUST be at least 24 by 24 CSS px (WCAG 2.2 SC 2.5.8). | L3 Playwright bounding box | Verified |
| `TB-A11Y-110` | M | P0 | On a mobile viewport (under 576 px) interactive targets MUST be at least 44 by 44 CSS px. | L3 Playwright bounding box | Verified |
| `TB-A11Y-120` | M | P0 | The focus indicator MUST have a contrast ratio of at least 3:1 against adjacent colors (WCAG 2.2 SC 1.4.11) in light, dark and forced-colors themes. | L4 contrast check | Approved |
| `TB-A11Y-130` | M | P0 | Under `forced-colors: active` the toolbar MUST use system colors and keep item boundaries and focus visible (ADR-008). | L5 visual forcedColors | Verified |
| `TB-A11Y-140` | M | P0 | Screen readers MUST announce toolbar role and orientation, item names, disabled state, toggle state and overflow expanded state. | Manual: named reviewer (MANUAL-VALIDATION.md) | Approved |
| `TB-A11Y-150` | R | P0 | Overflow open and close SHOULD be announced to assistive technology. | Manual: named reviewer (MANUAL-VALIDATION.md) | Approved |
| `TB-A11Y-160` | M | P1 | Nested menu navigation MUST be announced with correct roles. | Manual: named reviewer (MANUAL-VALIDATION.md) | Approved |

### Right-to-left (RTL)

| ID | Level | Phase | Requirement | Verification | Status |
| --- | --- | --- | --- | --- | --- |
| `TB-RTL-010` | M | P0 | `EnableRtl=true` MUST set direction to RTL on the root and mirror layout. | L1 bUnit assertion | Verified |
| `TB-RTL-020` | M | P0 | `EnableRtl=null` MUST inherit direction from the parent or application. | L1 bUnit assertion | Verified |
| `TB-RTL-030` | M | P0 | Overflow button and popup MUST sit on the logical end edge in RTL. | L3 Playwright | Verified |
| `TB-RTL-040` | M | P0 | Component CSS MUST use logical properties for direction-dependent layout. | L6 CSS lint | Approved |
| `TB-RTL-050` | M | P1 | A culture or RTL change at runtime MUST update strings and layout without recreating the component. | L2 bUnit integration | Approved |

### Theming (THM)

| ID | Level | Phase | Requirement | Verification | Status |
| --- | --- | --- | --- | --- | --- |
| `TB-THM-010` | M | P0 | Component styles MUST read colors, spacing and radii from CSS custom properties supplied by `SfThemeRoot` or `SfThemeScope`. | L6 CSS lint | Approved |
| `TB-THM-020` | M | P0 | Component logic MUST NOT contain hard-coded colors. | L6 CSS lint | Approved |
| `TB-THM-030` | M | P0 | The root MUST carry the Toolkit class `e-toolbar` plus orientation modifier classes. | L1 bUnit assertion | Verified |
| `TB-THM-040` | M | P0 | Light and Dark themes MUST render usable colors. | L5 visual | Verified |
| `TB-THM-050` | O | P1 | Size variants Small, Medium and Large MAY be offered through CSS classes. | L1 bUnit assertion | Verified |

### Style isolation (ISO)

| ID | Level | Phase | Requirement | Verification | Status |
| --- | --- | --- | --- | --- | --- |
| `TB-ISO-010` | M | P0 | Component styles MUST ship as scoped CSS (`.razor.css`) that works under the Blazor scope attribute. | L6 build | Approved |
| `TB-ISO-020` | M | P0 | Component styles MUST NOT leak into the host page. | L3 Playwright | Verified |
| `TB-ISO-030` | M | P0 | Two toolbars on one page MUST NOT affect each other. | L2 bUnit integration | Verified |
| `TB-ISO-040` | M | P0 | `CssClass` and `HtmlAttributes` MUST apply on the root without breaking scoped selectors. | L1 bUnit assertion | Verified |
| `TB-ISO-050` | R | P0 | Styles SHOULD avoid `::deep` unless required. | L6 CSS lint | Approved |

### Lifecycle, validation and disposal (LIF)

| ID | Level | Phase | Requirement | Verification | Status |
| --- | --- | --- | --- | --- | --- |
| `TB-LIF-010` | M | P0 | Each item MUST register with its parent on initialization and unregister on dispose. | L1 bUnit assertion | Verified |
| `TB-LIF-020` | M | P0 | Static SSR MUST render item markup without throwing, without events and without measurement; overflow MUST degrade to wrap or scroll through CSS (ADR-012). | L2 render-mode test | Approved |
| `TB-LIF-030` | M | P0 | The interactive first render MUST initialize measurement once. | L1 bUnit assertion | Approved |
| `TB-LIF-040` | M | P0 | The prerender to interactive handover MUST reconcile existing markup and MUST NOT recreate item state. | L2 render-mode test | Approved |
| `TB-LIF-050` | M | P0 | An Auto-mode transition from Server to WebAssembly MUST preserve item state held in parameters such as `@bind-Selected`. | L2 render-mode test | Approved |
| `TB-LIF-060` | M | P0 | `DisposeAsync` MUST release interop references and tolerate a disconnected circuit without throwing. | L1 bUnit assertion | Verified |
| `TB-LIF-070` | M | P0 | After dispose, late callbacks (resize, click) MUST be no-ops guarded by a disposed flag. | L1 bUnit assertion | Verified |
| `TB-LIF-080` | M | P0 | Disposal MUST detach event handlers and leave no reference that blocks garbage collection. | L1 bUnit assertion | Verified |
| `TB-LIF-090` | M | P0 | Duplicate item `Id` values MUST NOT throw during render and MUST behave deterministically. | L1 bUnit assertion | Verified |
| `TB-LIF-100` | M | P0 | An invalid enum value, a negative `Priority` or a zero-width container MUST NOT throw during render. | L1 bUnit assertion | Verified |
| `TB-LIF-110` | R | P1 | Rapid parameter churn SHOULD end in the correct final state without exceptions. | L2 bUnit integration | Verified |

### Security (SEC)

| ID | Level | Phase | Requirement | Verification | Status |
| --- | --- | --- | --- | --- | --- |
| `TB-SEC-010` | M | P0 | `Text`, `IconCss`, `Tooltip` and `Badge` MUST NOT reach a raw HTML sink such as `MarkupString`. | L1 bUnit assertion | Verified |
| `TB-SEC-020` | M | P0 | All consumer strings rendered into markup or attributes MUST be HTML-escaped. | L1 bUnit assertion | Verified |
| `TB-SEC-030` | M | P0 | `CssClass` and `HtmlAttributes` MUST be documented as trust-boundary inputs that the consumer must not populate from untrusted data. | L6 doc review | Verified |
| `TB-SEC-040` | M | P0 | The component MUST NOT use `eval`, `new Function` or inline script. | L6 interop audit | Verified |
| `TB-SEC-050` | M | P0 | The component MUST work under a strict Content Security Policy with no inline styles from script. | L3 Playwright CSP | Approved |
| `TB-SEC-060` | M | P0 | Interop MUST be guarded so disposed or disconnected state never throws `JSDisconnectedException`. | L1 bUnit assertion | Verified |
| `TB-SEC-070` | M | P0 | Raw HTML MUST be limited to non-interactive structure: popup container, separators and spacers (ADR-006). | L6 code review | Verified |

### Performance (PRF)

| ID | Level | Phase | Requirement | Verification | Status |
| --- | --- | --- | --- | --- | --- |
| `TB-PRF-010` | M | P0 | Layout and render of 100 items MUST complete in under 16 ms. | L3 benchmark | Approved |
| `TB-PRF-020` | M | P0 | Dynamic add or remove of 20 items MUST complete in under 10 ms. | L3 benchmark | Approved |
| `TB-PRF-030` | M | P0 | Resize recalculation MUST be debounced to 32 ms or less. | L3 benchmark | Approved |
| `TB-PRF-040` | M | P0 | First meaningful paint impact MUST be under 5 ms. | L3 benchmark | Approved |
| `TB-PRF-050` | M | P0 | Total JavaScript for the Toolbar MUST be 15 KB gzipped or less. | L6 bundle size | Approved |
| `TB-PRF-060` | R | P0 | Items SHOULD call `StateHasChanged` individually instead of re-rendering the whole toolbar. | L1 bUnit assertion | Approved |

### Internationalization (I18)

| ID | Level | Phase | Requirement | Verification | Status |
| --- | --- | --- | --- | --- | --- |
| `TB-I18-010` | M | P1 | Built-in strings (overflow tooltip, aria-labels) MUST come from the Toolkit localization system. | L1 bUnit assertion | Verified |
| `TB-I18-020` | M | P1 | A culture change MUST update localized strings without recreating the component. | L2 bUnit integration | Verified |

### Compatibility (CMP)

| ID | Level | Phase | Requirement | Verification | Status |
| --- | --- | --- | --- | --- | --- |
| `TB-CMP-010` | M | P0 | The component MUST build and run on net8.0, net9.0 and net10.0. | L6 build | Approved |
| `TB-CMP-020` | M | P0 | The component MUST work in Static SSR, Interactive Server, Interactive WebAssembly and Interactive Auto. | L3 render-mode matrix | Approved |
| `TB-CMP-030` | M | P0 | The component MUST work in the latest two versions of Chromium, Edge, Firefox and WebKit. | L3 Playwright | Approved |
| `TB-CMP-040` | M | P0 | Public API additions MUST be additive and MUST NOT break shipped Toolkit APIs. | L6 public API compat | Approved |
| `TB-CMP-050` | M | P0 | A trimmed and AOT publish MUST produce zero trim or AOT warnings. | L6 build | Approved |
| `TB-CMP-060` | M | P0 | The build MUST report zero warnings and zero analyzer warnings, and nullable analysis MUST be clean. | L6 build | Approved |
| `TB-CMP-070` | M | P0 | The component MUST NOT reference commercial Syncfusion packages or third-party UI libraries. | L6 project references | Verified |
| `TB-CMP-080` | M | P0 | The component MUST NOT use reflection over consumer models. | L6 build | Verified |
| `TB-CMP-090` | M | P0 | Zero runtime console errors MUST appear on every sample route. | L3 Playwright | Approved |
| `TB-CMP-100` | M | P0 | `SfButtonGroup` MUST NOT be used for toolbar layout; `SfCheckBox`, `SfRadioButton` and `SfSwitch` MUST appear only in templates or radio and check item types (ADR-014). | L6 code review | Verified |

### Samples (SMP)

| ID | Level | Phase | Requirement | Verification | Status |
| --- | --- | --- | --- | --- | --- |
| `TB-SMP-010` | M | P0 | The Sample Browser MUST ship exactly the six demos listed in `sample-preparer.md` under `/navigations/toolbar`. | L3 Playwright | Approved |
| `TB-SMP-020` | M | P0 | The accessibility host MUST serve the 12 routes of ADR-010. | L4 axe scan | Verified |
| `TB-SMP-030` | M | P0 | Every route MUST be wired into `accessibility/config.json` and `ToolbarTests.cs`. | L4 axe scan | Verified |
| `TB-SMP-040` | M | P0 | Markup MUST expose the `data-testid` hooks `toolbar-root`, `toolbar-item`, `toolbar-button`, `toolbar-toggle`, `toolbar-separator`, `toolbar-spacer`, `toolbar-group`, `toolbar-overflow-button`, `toolbar-overflow-popup`, `toolbar-overflow-item` and `toolbar-template-item`. | L1 bUnit assertion | Verified |
| `TB-SMP-050` | M | P1 | Markup MUST expose the `data-testid` hooks `toolbar-split`, `toolbar-dropdown`, `toolbar-menubutton`, `toolbar-radio-group` and `toolbar-check-group`. | L1 bUnit assertion | Verified |
| `TB-SMP-060` | R | P0 | Samples SHOULD demonstrate CSS isolation usage. | L6 doc review | Approved |

### Test infrastructure (TST)

| ID | Level | Phase | Requirement | Verification | Status |
| --- | --- | --- | --- | --- | --- |
| `TB-TST-010` | M | P0 | Every public parameter, event and method MUST appear in at least one automated test. | L6 coverage review | Approved |
| `TB-TST-020` | M | P0 | Statement coverage on Toolbar types MUST be 85 percent or higher. | L6 coverage | Approved |
| `TB-TST-030` | M | P0 | The overflow algorithm MUST have combinatorial tests across mode, priority, visibility and enabled state. | L1 bUnit theory | Verified |
| `TB-TST-040` | M | P0 | Every P0 case MUST be green before Phase 1 acceptance and every P1 case before Phase 2 acceptance. | CI gate | Approved |
| `TB-TST-050` | M | P0 | Every bug fix MUST ship with a new automated regression test. | CI review | Approved |
| `TB-TST-060` | M | P0 | Visual baselines MUST pass on Chromium, with key P0 states on Firefox and WebKit. | L5 visual | Verified |
| `TB-TST-070` | M | P0 | `TRACEABILITY.md` MUST be generated from the registry, ACs, tasks and `COVERAGE.md` and be current, and the harness gate `component-traceability` MUST report zero missing and zero duplicate bUnit scenarios (ADR-015). | L6 generator check and harness gate | Verified |
| `TB-TST-080` | M | P0 | Manual validation scenarios (SR-TB-*) MUST have a named reviewer before release sign-off. | Manual: named reviewer (MANUAL-VALIDATION.md) | Approved |

## 23. Status log

| Date | Status | Note |
| --- | --- | --- |
| 2026-11-02 | Approved | Registry, ADR-001 to ADR-014 and acceptance criteria added. No implementation exists. |
| 2026-11-03 | Approved | ADR-015 to ADR-017: single traceability gate, test framework alignment, manual validation; duplicate sections replaced by pointers. |
| 2026-11-02 | Approved | ADR-018: library and samples move to Navigations; registry gains a Status column; two navigation entries allowed in the Sample Browser. No requirement text changed except two route strings. |
| 2026-11-04 | Implemented | Phase 2 bUnit rows (`TB-API-210`–`260`, `TB-ITM-180`–`210`, `TB-OVF-130`–`160`) marked Implemented after `Navigations.Toolbar` net8.0: 299 passed, 0 failed. Playwright and axe rows stay Approved. Not Verified. |
| 2026-11-10 | Verified | 111 rows moved to Verified after a full run: bUnit Toolbar filter 343 passed and 0 failed, Playwright Toolbar 70 passed including 17 visual baselines, axe-core Toolbar 13 passed with zero violations on the 12 ADR-010 routes, and the Toolbar sources build with zero Toolbar warnings. The traceability gate reports 90 of 90 scenarios traced with 0 missing and 0 duplicate, and the traceability generator reports no findings. The runs and the ten defects fixed in the same revision are recorded in [Evidence.md](Evidence.md). The 43 rows that stay Approved are the ones whose named layer needs a person, a missing host or a gate that did not run; they are listed in Evidence.md section 6. No requirement text changed. |

---

**Document Owner**: Toolkit Team  
**Status**: Approved  
**Related Documents**: `PRD.md`, `TEST-MATRIX.md`, `API.md`, `API-xml.md`