# SfAppBar — Technical Specification

**Component:** SfAppBar  
**Namespace:** Syncfusion.Blazor.Toolkit  
**Version:** 1.0  

**Cross References:**  
PRD.md, API.md, API-xml.md, TEST-MATRIX.md, Evidence.md, sample-preparer.md, competitive-matrix.md

---

# Table of Contents

1. [Architecture Overview](#1-architecture-overview)
2. [Component Tree](#2-component-tree)
3. [Toolkit Primitive Reuse](#3-toolkit-primitive-reuse)
4. [State Management](#4-state-management)
5. [Rendering Strategy](#5-rendering-strategy)
6. [Layout & Positioning](#6-layout--positioning)
7. [Regions & Content Model](#7-regions--content-model)
8. [Overflow Behavior](#8-overflow-behavior)
9. [Keyboard & Focus Model](#9-keyboard--focus-model)
10. [Accessibility](#10-accessibility)
11. [Theming & CSS Contracts](#11-theming--css-contracts)
12. [JS Interop Boundaries](#12-js-interop-boundaries)
13. [Performance](#13-performance)
14. [AOT, Trimming & Framework Requirements](#14-aot-trimming--framework-requirements)
15. [data-testid Contracts](#15-data-testid-contracts)
16. [Error & Edge Cases](#16-error--edge-cases)
17. [Phase Separation](#17-phase-separation)
18. [Non-Goals (Technical)](#18-non-goals-technical)
19. [Future Enhancements](#19-future-enhancements)
20. [Requirement ID Index](#20-requirement-id-index)

---

# 1. Architecture Overview

```text
SfAppBar (root: header | footer)
│
├── Leading Region (menu toggle, back, custom)
├── Branding Region (logo, product name)
├── Title Region (page/screen title)
├── Content Region (search, custom middle content)
├── Action Region (role=toolbar; SfButton / SfButtonGroup)
│   ├── SfAppBarItem*
│   └── SfAppBarSpacer*
└── Overflow Region (Phase 2; measurement-driven)
    └── SfAppBarOverflow
```

**S-AB-ARCH-01**  
SfAppBar SHALL be a pure Blazor component inheriting Toolkit base patterns (`SfBaseComponent` or equivalent).

**S-AB-ARCH-02**  
SfAppBar MUST NOT depend on commercial Syncfusion.Blazor packages.

---

# 2. Component Tree

| Type | Role | Phase |
|------|------|--------|
| SfAppBar | Root container | MVP |
| SfAppBarItem | Action or content unit | MVP (basic) / Phase 2 (priority) |
| SfAppBarSpacer | Flexible spacer | MVP |
| SfAppBarOverflow | Overflow host | Phase 2 |

Additional types are allowed only when justified in **API.md**.

---

# 3. Toolkit Primitive Reuse

| Concern | Primitive | Decision | Justification |
|----------|------------|-----------|---------------|
| Commands | SfButton | **MUST reuse** | Available, accessible, themed |
| Icon-only | SfButton + IconCss | **MUST reuse** | SfIconButton not in Toolkit |
| Groups | SfButtonGroup | **SHOULD reuse** | Available |
| Overflow menu | SfDialog or lightweight panel | **Temporary** | SfMenu not available; document as Phase 3 swap |
| Tooltips | SfTooltip | **SHOULD reuse** | Icon-only accessible names |
| Theme | SfThemeRoot | **MUST integrate** | Standard Toolkit path |
| Identity | Template | **Template only** | SfAvatar not available |

**S-AB-REUSE-01**  
Automated tests **U-AB-200 through U-AB-203** MUST verify SfButton and theme integration paths.

---

# 4. State Management

| State | Owner | Persistence | Notes |
|---------|--------|------------|--------|
| Responsive / breakpoint | SfAppBar | In-memory | From viewport width |
| Overflow open/closed | SfAppBarOverflow | In-memory | Interactive only |
| Layout mode | Parameter | Parameter | Static / Fixed / Sticky |
| Position | Parameter | Parameter | Top / Bottom |
| Density | Parameter | Parameter | Comfortable / Compact |
| Resize generation | Internal | Counter | Debounced measure |
| Last focused action | Toolbar focus manager | In-memory | Roving tabindex |
| Fixed offset applied | CSS + optional class | CSS | Documented contract |

**S-AB-STATE-01**  
Overflow and measurement state MUST be inert under Static SSR (no JS).

**S-AB-STATE-02**  
Parameter changes MUST trigger deterministic re-render without reflection.

---

# 5. Rendering Strategy

## 5.1 Static SSR

- Render full semantic structure (`header`/`footer`, regions, buttons, anchors).
- No `ResizeObserver`.
- Overflow renders all items or honors explicit defaults.
- Interactive attributes may exist but remain inactive until hydration.

## 5.2 Interactive Server / WASM / Auto

- Attach measurement after first render when `EnableOverflow=true`.
- Debounce resize operations (≤100 ms).
- Recompute visible and overflow items.
- Preserve focus where possible during recomputation.

## 5.3 Template Rendering

- `RenderFragment` parameters render within declared regions.
- Child components (`SfAppBarItem`) register through cascading `AppBarContext`.

**S-AB-RND-01**  
Templates MUST render correctly in Static SSR without interactive dependencies.

---

# 6. Layout & Positioning

## 6.1 Position (S-AB-LAY-01)

| AppBarPosition | Element | Landmark |
|----------------|---------|-----------|
| Top | `<header>` | banner (implicit) |
| Bottom | `<footer>` | contentinfo (implicit) |

## 6.2 Mode (S-AB-LAY-02)

| AppBarMode | CSS | Behavior |
|------------|-----|----------|
| Static | `position: relative` | Document flow |
| Fixed | `position: fixed; top/bottom: 0` | Viewport pinned |
| Sticky | `position: sticky; top/bottom: 0` | Sticks within scrolling ancestor |

For fixed positioning, host applications SHOULD provide content offsets through:

```css
--sf-appbar-offset
```

or equivalent padding utilities.

**S-AB-LAY-03**  
Density classes:

```css
sf-appbar-comfortable
sf-appbar-compact
```

**S-AB-LAY-04**  
Elevation SHALL be controlled through:

```css
--sf-appbar-elevation
```

and modifier classes.

---

# 7. Regions & Content Model

**S-AB-REG-01**  
Default LTR region order:

```text
Leading → Branding → Title → Content → Spacer → Actions → Overflow Trigger
```

**S-AB-REG-02**  
RTL layouts SHALL mirror the inline axis.

**S-AB-REG-03**  
`SfAppBarSpacer` SHALL consume remaining free space using:

```css
flex-grow: 1;
```

**S-AB-REG-04**  
`AppBarContext` SHALL expose:

- Density
- Mode
- Position
- RegisterItem()
- UnregisterItem()

---

# 8. Overflow Behavior

**S-AB-OVR-01** *(Phase 2)*

When `EnableOverflow=true`:

1. Measure action-region width and item widths.
2. Keep visible items in original order until space is exhausted.
3. Move remaining items into overflow.
4. Display overflow trigger if overflow count > 0.

**S-AB-OVR-02**  
`Priority` parameter (integer, lower value = retained longer) MAY be assigned to `SfAppBarItem`.

**S-AB-OVR-03**  
Overflow panel MUST:

- Support keyboard navigation.
- Close on Escape.
- Follow focus-loss behavior aligned with dialog patterns.

**S-AB-OVR-04**  
JavaScript SHALL be limited to measurements. Layout decisions MUST remain in C#.

---

# 9. Keyboard & Focus Model

**S-AB-KBD-01**

Action region SHALL implement the WAI-ARIA Toolbar pattern.

| Key | Behavior |
|------|----------|
| Tab / Shift+Tab | Enter or leave toolbar |
| Right Arrow | Next control |
| Left Arrow | Previous control |
| Home | First control |
| End | Last control |
| Enter | Activate focused control |
| Space | Activate focused control |

RTL SHALL reverse Left/Right behavior appropriately.

**S-AB-KBD-02**

Disabled controls:

- Remain present in the DOM.
- May remain discoverable by screen readers.
- MUST be skipped during roving arrow navigation.

**S-AB-KBD-03**

Overflow trigger SHALL participate in toolbar navigation order.

---

# 10. Accessibility

| Spec ID | Requirement |
|----------|-------------|
| S-AB-A11Y-01 | Toolbar container uses `role="toolbar"` and accessible name |
| S-AB-A11Y-02 | Root uses semantic header/footer landmarks |
| S-AB-A11Y-03 | Keyboard support per Section 9 |
| S-AB-A11Y-04 | Visible focus indicator ≥ 3:1 contrast |
| S-AB-A11Y-05 | Icon-only buttons MUST provide `aria-label` |
| S-AB-A11Y-06 | Support high-contrast theme tokens |
| S-AB-A11Y-07 | Support `forced-colors: active` |
| S-AB-A11Y-08 | Respect `prefers-reduced-motion: reduce` |
| S-AB-A11Y-09 | Use RTL logical properties |

**S-AB-A11Y-10**  
The component MUST NOT implement a combobox pattern.

### Screen Reader Validation Targets

- NVDA
- Narrator
- JAWS

Automation is recommended; manual validation is optional and not a release gate.

---

# 11. Theming & CSS Contracts

**S-AB-CSS-01**

CSS isolation file:

```text
SfAppBar.razor.css
```

**S-AB-CSS-02**

BEM-style CSS classes:

```css
.sf-appbar
.sf-appbar--top
.sf-appbar--bottom
.sf-appbar--static
.sf-appbar--fixed
.sf-appbar--sticky
.sf-appbar--comfortable
.sf-appbar--compact
.sf-appbar__leading
.sf-appbar__branding
.sf-appbar__title
.sf-appbar__content
.sf-appbar__actions
.sf-appbar__overflow
```

**S-AB-CSS-03**

Theme tokens:

```css
--sf-appbar-bg
--sf-appbar-fg
--sf-appbar-border
--sf-appbar-height-comfortable
--sf-appbar-height-compact
--sf-appbar-elevation
--sf-appbar-padding-inline
```

**S-AB-CSS-04**  
CSS isolation MUST use scoped selectors and MUST NOT leak globally.

---

# 12. JS Interop Boundaries

| API | Purpose | Phase | Required |
|------|---------|--------|----------|
| ObserveResize(element) | Viewport/container resize | Phase 2 | EnableOverflow |
| MeasureElements(ids) | Measure item widths | Phase 2 | EnableOverflow |
| Disconnect() | Cleanup | Phase 2 | Dispose |

**S-AB-JS-01**  
JavaScript MUST NOT be responsible for:

- Click handling
- Theming
- ARIA management

**S-AB-JS-02**  
All JS modules MUST be trimming and AOT safe.

Requirements:

- Static JS identifiers
- No dynamic assembly loading
- No reflection-based dispatch

---

# 13. Performance

| Metric | MVP Target | Stretch |
|----------|-----------|----------|
| Actions without overflow | ≤ 50 | ≥ 100 |
| Initial render (50 actions) | ≤ 16 ms preferred budget | Profile in CI |
| Resize recalculation | Debounced ≤ 100 ms | — |
| Overflow recalculation | O(n) | Minimal re-render |

**S-AB-PERF-01**

Avoid excessive per-item `ComponentBase` overhead where possible.

Guideline:

- Use registration patterns for public API clarity.
- Keep rendering efficient.
- Minimize unnecessary re-renders.

---

# 14. AOT, Trimming & Framework Requirements

| Requirement | Spec ID |
|-------------|---------|
| IsAotCompatible = true | S-AB-AOT-01 |
| IsTrimmable = true | S-AB-AOT-02 |
| No reflection APIs | S-AB-AOT-03 |
| No dynamic code generation | S-AB-AOT-04 |
| Nullable enabled; zero warnings | S-AB-QL-01 |
| CS1591 documentation complete | S-AB-QL-02 |
| CSS isolation with scoped IDs | S-AB-QL-03 |
| SfThemeRoot integration | S-AB-QL-04 |

### Browser Support

- Chrome (latest two versions)
- Edge (latest two versions)
- Firefox (latest two versions)
- Safari (latest two versions)

### Render Mode Support

| Render Mode | Requirement |
|-------------|-------------|
| Static SSR | Supported |
| Interactive Server | Supported |
| WASM | Supported |
| Auto | Supported |

Overflow functionality is progressively enhanced in interactive modes.

---

# 15. data-testid Contracts

| data-testid | Element |
|-------------|----------|
| sf-appbar | Root |
| sf-appbar-leading | Leading region |
| sf-appbar-branding | Branding region |
| sf-appbar-title | Title region |
| sf-appbar-content | Content region |
| sf-appbar-actions | Actions toolbar |
| sf-appbar-overflow | Overflow host |
| sf-appbar-overflow-trigger | Overflow trigger button |
| sf-appbar-item-{id} | Item by Id |
| sf-appbar-spacer | Spacer |

**S-AB-TESTID-01**

`data-testid` values MUST remain stable across releases unless a major version introduces breaking changes.

---

# 16. Error & Edge Cases

| Case | Expected Behavior |
|--------|-------------------|
| Zero actions | Render regions only; omit toolbar role |
| Empty title | Omit title node or render empty fragment |
| EnableOverflow in SSR | Render all items without error |
| Invalid Density enum | Compile-time prevented |
| Extremely long title | CSS ellipsis and accessible full text |
| 100+ actions | Must not throw; Phase 3 optimization target |

---

# 17. Phase Separation

| Feature | MVP | Phase 2 | Phase 3 |
|----------|-----|---------|---------|
| Top/Bottom positioning | ✓ | | |
| Static/Fixed/Sticky modes | ✓ | | |
| Regions, Spacer, Item | ✓ | | |
| SfButton commands | ✓ | | |
| Toolbar accessibility | ✓ | | |
| Density, Theme, RTL, HC | ✓ | | |
| Overflow measurement | | ✓ | |
| Templates | | ✓ | |
| Priority overflow | | ✓ | |
| 100+ actions support | | | ✓ |
| Contextual AppBar | | | ✓ |

---

# 18. Non-Goals (Technical)

The following are explicitly out of scope:

- Ribbon interfaces
- Multi-row toolbars
- Docking systems
- Built-in router mega menus
- Commercial Syncfusion package dependencies
- Manual QA release gates

---

# 19. Future Enhancements

Potential future investments:

- Replace overflow panel with SfMenu.
- Add SfAvatar helper region.
- Add contextual SectionOutlet-based AppBar support.
- Persist overflow priorities and action groups.
- Enhanced adaptive layout algorithms.

---

# 20. Requirement ID Index

```text
S-AB-ARCH-*
S-AB-REUSE-*
S-AB-STATE-*
S-AB-RND-*
S-AB-LAY-*
S-AB-REG-*
S-AB-OVR-*
S-AB-KBD-*
S-AB-A11Y-*
S-AB-CSS-*
S-AB-JS-*
S-AB-PERF-*
S-AB-AOT-*
S-AB-QL-*
S-AB-TESTID-*
```

### Traceability

- Requirements map to `R-AB-*` entries in **PRD.md**.
- Validation evidence maps to corresponding entries in **Evidence.md**.
- Automated and manual verification paths are defined in **TEST-MATRIX.md**.

---