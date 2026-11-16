# SfSidebar — Technical Specification
## Syncfusion® Toolkit for Blazor

| Field | Value |
|-------|--------|
| **Component** | `SfSidebar` |
| **Namespace** | `Syncfusion.Blazor.Toolkit` |
| **Spec version** | 2.1 |
| **Status** | Approved for implementation |
| **Public contract** | `API.md`, `API-xml.md` |
| **Product requirements** | `PRD.md` |
| **Test contract** | `TEST-MATRIX.md` |

This document is the only home for detailed technical, behavioral, and implementation requirements. `PRD.md` states the product goal. `API.md` lists the public surface. `TEST-MATRIX.md` maps tests onto the section numbers and rule codes defined here.

Keywords **must**, **must not**, and **may** are normative.

---

## 1. Scope and rule codes

### 1.1 In scope (v1)

Overlay, Push, and Shrink modes; Left, Right, Start, and End positioning; mini rail; responsive breakpoint behavior; two-way open state; header, body, and footer templates; optional `TargetContent`; animation; accessibility; RTL; CSS isolation.

### 1.2 Out of scope (v1)

- A data-bound item collection. The panel body is composed only through `ChildContent`. `HeaderTemplate`, `FooterTemplate`, and `TargetContent` stay.
- Persistence of the open state (local storage or equivalent).
- AppBar clip modes. Only a documented stacking order is required.
- A first-party navigation menu.
- A mandatory layout parent.

### 1.3 Rule-code scheme

| Prefix | Section | Meaning |
|--------|---------|---------|
| `M-O*` | §4.1 | Overlay mode |
| `M-P*` | §4.2 | Push mode |
| `M-S*` | §4.3 | Shrink mode |
| `M-N*` | §4.4 | Mini rail and occupied width |
| `M-F*`, `M-B*` | §4.5 | `Fixed` positioning and `BackdropClass` |
| `P*` | §5 | Position and RTL |
| `R*` | §6 | Responsive state machine |
| `O*` | §7 | Open state, methods, events, navigation |
| `A*` | §8 | Accessibility |

A test that cites a code cites the rule in that section. A test that cites `§n.n` cites that section.

---

## 2. DOM contract

`SfSidebar` renders one layout host and one panel. `Id`, `CssClass`, and `HtmlAttributes` land on the panel, never on the host. The panel is the `aria-controls` target.

```text
div.e-sidebar-container                         layout host (internal)
  div.e-sidebar#{Id}                          panel; CssClass and HtmlAttributes land here
    div.e-sidebar-header                        only when HeaderTemplate is set
    div.e-sidebar-body                          always; hosts ChildContent
    div.e-sidebar-footer                        only when FooterTemplate is set
  div.e-sidebar-target                          only when TargetContent is set (§3.2.A)
  div.e-sidebar-backdrop                        only when the backdrop rule in §4.1 applies
```

| Element | Classes | Notes |
|---------|---------|-------|
| Host | `e-sidebar-container` | Internal. Not a public styling hook. |
| Panel | `e-sidebar`, plus the resolved side, mode, open, and mini classes | Public hook. Receives `id`, `CssClass`, `HtmlAttributes`. |
| Header / body / footer | `e-sidebar-header`, `e-sidebar-body`, `e-sidebar-footer` | Body is always rendered. Header and footer are omitted when their template is null. |
| Target | `e-sidebar-target` | Omitted when `TargetContent` is null (§3.2.B). |
| Backdrop | `e-sidebar-backdrop` | A non-focusable `div`. `aria-hidden="true"`. Not a labelled button. |

The component must not emit `data-testid`. Sample pages may put `data-testid` on consumer-owned elements only: the toggle, a navigation link, and a main-content control. Component-owned elements are selected by the classes above.

Dynamic lengths reach the host as CSS custom properties only: `--e-sidebar-width`, `--e-sidebar-mini-width`, `--e-sidebar-occupied-width`, `--e-sidebar-duration`. The component must not build inline `transform`, `margin`, `padding`, or `width` strings in C#.

---

## 3. Content model

### 3.1 Regions and templates

| Rule | Requirement |
|------|-------------|
| Body | `ChildContent` renders inside `.e-sidebar-body`. Null content renders an empty body. |
| Header | `HeaderTemplate` renders inside `.e-sidebar-header` only when set. |
| Footer | `FooterTemplate` renders inside `.e-sidebar-footer` only when set. |
| Composition | v1 has no item, data-source, or template-per-item parameter. |

### 3.2 Target content

| Section | Condition | Requirement |
|---------|-----------|-------------|
| §3.2.A | `TargetContent` is set | Render `.e-sidebar-target` and place the fragment inside it. Push and Shrink measure this element. |
| §3.2.B | `TargetContent` is null | Do not render `.e-sidebar-target`. The consumer owns the adjacent content and may offset it with the published CSS variables. |

---

## 4. Modes

`Mode` is `SidebarMode`. The default is `Overlay`. Changing `Mode` at runtime replaces the mode class on the next render.

The **effective mode** is `Mode`, unless §6 says the viewport has forced Overlay.

### 4.1 Overlay — `M-O1` to `M-O7`

| Code | Rule |
|------|------|
| M-O1 | The panel has `e-sidebar-overlay` and paints above the target. It does not change the target's flow size. |
| M-O2 | A backdrop renders only when the effective mode is Overlay, the panel is open, and `ShowBackdrop` is `true`. `ShowBackdrop="false"` renders no backdrop. |
| M-O3 | The backdrop covers the host, sits below the panel, and does not receive focus. |
| M-O4 | An open Overlay panel with a backdrop is modal: `role="dialog"` and `aria-modal="true"` (§8.1). |
| M-O5 | A pointer activation of the backdrop closes the panel when `CloseOnOverlayClick` is `true` (default) and `IsEnabled` is `true`. Otherwise the activation is ignored. |
| M-O6 | Escape closes an open Overlay panel when `CloseOnEscape` is `true` (default), `IsEnabled` is `true`, and focus is inside the host. Focus then returns to the opener (§8.3). |
| M-O7 | Opening a modal Overlay panel moves focus into the panel. Tab and Shift+Tab cycle inside it until it closes (§8.3). |

Push and Shrink never render a backdrop and never trap focus, regardless of `ShowBackdrop`.

### 4.2 Push — `M-P1` to `M-P4`

| Code | Rule |
|------|------|
| M-P1 | The panel has `e-sidebar-push`. Opening it offsets `.e-sidebar-target` along the inline axis by the occupied width. |
| M-P2 | Push renders no backdrop. |
| M-P3 | Push does not trap focus. Tab can leave the panel and reach the target. |
| M-P4 | Two instances, one `Start` and one `End`, may be open together. Each offsets its own target. Their panels must not overlap. |

### 4.3 Shrink — `M-S1` to `M-S3`

| Code | Rule |
|------|------|
| M-S1 | The panel has `e-sidebar-shrink`. Opening it reduces the inline size of `.e-sidebar-target` by the occupied width. |
| M-S2 | Shrink renders no backdrop and does not trap focus. |
| M-S3 | Shrink with `EnableMini` keeps the rail in the document flow at `MiniWidth` while closed. |

### 4.4 Occupied width and mini — `M-N1` to `M-N3`

| State | Occupied width | Panel classes |
|-------|----------------|---------------|
| Open | `Width` (default `280px`) | `e-sidebar-open` |
| Closed, `EnableMini=false` | `0px` | neither `e-sidebar-open` nor `e-sidebar-mini` |
| Closed, `EnableMini=true` | `MiniWidth` (default `64px`) | `e-sidebar-mini` |

| Code | Rule |
|------|------|
| M-N1 | A fully closed panel occupies `0px`, is translated fully off its edge, and is removed from the accessibility tree (§8.2). |
| M-N2 | A mini panel occupies `MiniWidth`, stays in the accessibility tree, and keeps its interactive children focusable. |
| M-N3 | `OpenMiniOnHover` (default `false`) expands a collapsed mini panel while the pointer is over it, on a desktop viewport only. Leaving the panel collapses it again unless it was opened explicitly. Keyboard users expand it only through the toggle or the public methods. |

### 4.5 Fixed and BackdropClass — `M-F1` to `M-F3`, `M-B1` to `M-B2`

Definitions follow the parameter descriptions in `API.md` (`Fixed`: `position: fixed` vs absolute within container; `BackdropClass`: extra classes on backdrop).

| Code | Rule |
|------|------|
| M-F1 | `Fixed` is a `bool` and defaults to `true`. |
| M-F2 | `Fixed=true` positions the panel with `position: fixed` against the viewport. `Fixed=false` positions it with `position: absolute` inside the layout host (`div.e-sidebar-container`), which is the containing block. |
| M-F3 | The backdrop uses the same reference as the panel: it covers the viewport when `Fixed=true` and the layout host when `Fixed=false`. `Fixed` does not change the DOM structure (§2), the occupied width (§4.4), the open state, the ARIA attributes, or the focus rules. |
| M-B1 | `BackdropClass` is a `string?` and defaults to `null`. Its space-separated class names are appended to `div.e-sidebar-backdrop` after the built-in class. `null`, empty, or whitespace appends nothing. |
| M-B2 | `BackdropClass` never decides whether the backdrop renders (that is M-O2), never changes the backdrop's `aria-hidden="true"`, and is not applied to any other element. |

---

## 5. Position and RTL

`Position` defaults to `Start`. Logical values resolve against `GlobalOptions.EnableRtl` from the toolkit service. The component also honors a `dir` attribute on the host when the sample sets one; the service flag is the resolution input for unit tests.

| Position | LTR (`EnableRtl=false`) | RTL (`EnableRtl=true`) | Class |
|----------|-------------------------|------------------------|-------|
| `Left` | left | left | `e-sidebar-left` |
| `Right` | right | right | `e-sidebar-right` |
| `Start` | left | right | resolved class |
| `End` | right | left | resolved class |

| Code | Rule |
|------|------|
| P1 | `Left` always resolves to the physical left edge. |
| P2 | `Start` resolves to the inline-start edge. |
| P3 | `End` resolves to the inline-end edge, including under `dir="rtl"`. |
| P4 | `Right` always resolves to the physical right edge. |

---

## 6. Responsive behavior

### 6.1 Inputs

| Input | Default | Effect |
|-------|---------|--------|
| `Responsive` | `true` | Enables the state machine. `false` keeps `Mode` at every width. |
| `Breakpoint` | `Md` | Viewport width below this value is mobile. |

`SidebarBreakpoint` widths are exact, not ranges:

| Value | Threshold |
|-------|-----------|
| `None` | Responsive adaptation is off. `Mode` is kept. |
| `Xs` | `0px` |
| `Sm` | `576px` |
| `Md` | `768px` |
| `Lg` | `992px` |
| `Xl` | `1200px` |
| `Xxl` | `1400px` |
| `Always` | Desktop behavior at every width. Never falls back to Overlay. |

### 6.2 Viewport source

The viewport comes from one `matchMedia` listener registered for the active threshold, plus one `resize` listener. The component registers both after first render and removes both on dispose. Static SSR and prerender paint from parameters only; the first interactive render reconciles to the real viewport. A short first-paint difference on a narrow viewport is expected and must settle within one frame of hydration.

### 6.3 State machine — `R1` to `R4`

| Code | Rule |
|------|------|
| R1 | On load, a viewport below the breakpoint uses the effective mode Overlay and starts closed, even when `IsOpen` was set. Crossing the threshold either way raises `OnBreakpointChanged`. The argument is `true` when the viewport is below the breakpoint. |
| R2 | Crossing from desktop to mobile while open closes the panel and raises `IsOpenChanged(false)`, then `OnClosed`. |
| R3 | Crossing from mobile to desktop never opens the panel. `IsOpen` stays `false` until the consumer opens it. |
| R4 | `Responsive=false`, `Breakpoint=None`, and `Breakpoint=Always` do not change the effective mode. Dispose removes the listeners; a later viewport change must not invoke a handler. |

`R3` in the test index also covers disposal (`U-RES-006`). Both the no-auto-open rule and the dispose rule are required.

---

## 7. Open state, methods, and events

### 7.1 Binding

| Code | Rule |
|------|------|
| O1 | `IsOpen` and `IsOpenChanged` support `@bind-IsOpen`. Every open-state change raises `IsOpenChanged` with the new value. |
| O2 | `IsEnabled=false` blocks user-initiated changes only: backdrop activation, Escape, hover expansion, and gestures. `OpenAsync`, `CloseAsync`, `ToggleAsync`, and a new `IsOpen` parameter value still apply. |
| O3 | `CloseOnNavigate` (default `true`) subscribes to `NavigationManager.LocationChanged` only when `IsOpenChanged` has a delegate. A location change while open requests close. `false` does not subscribe. Dispose unsubscribes. |
| O4 | `IsOpenChanged` is raised before `OnOpened` or `OnClosed`. A one-way `IsOpen` without a callback is not written back; consumers use `@bind-IsOpen`. |

### 7.2 Methods

| Method | Behavior |
|--------|----------|
| `OpenAsync()` | Sets open. Raises `IsOpenChanged(true)` and then `OnOpened` when the state changes. |
| `CloseAsync()` | Sets closed (hidden, or mini when `EnableMini`). Raises `IsOpenChanged(false)` and then `OnClosed` when the state changes. |
| `ToggleAsync()` | Flips the open state and raises the same pair. |
| `FocusAsync()` | Returns `Task`. Moves focus to the panel. Completes without throwing when the panel is not focusable. |

Calling a method when the panel is already in the requested state does not raise events.

### 7.3 Event ordering and timing

1. Apply the new open state and recompute classes and variables.
2. Raise `IsOpenChanged`.
3. When `EnableAnimation` is `false`, or the user prefers reduced motion, raise `OnOpened` or `OnClosed` immediately.
4. Otherwise raise `OnOpened` or `OnClosed` after `Duration` milliseconds (default `300`). A newer state change cancels the pending callback.
5. `OnBreakpointChanged` is independent and fires only on a threshold crossing.

`SidebarEventArgs` carries `IsOpen` and the effective `Mode`. It does not carry a trigger string.

---

## 8. Accessibility

### 8.1 Roles — `A1`, `A2`

| Condition | Role | Extra attributes |
|-----------|------|------------------|
| Effective Overlay, open, backdrop shown | `dialog` | `aria-modal="true"` |
| Push, Shrink, or non-modal Overlay | `navigation` | no `aria-modal` |
| `Role` set | the supplied value | wins over the resolved role |

| Code | Rule |
|------|------|
| A1 | `AriaLabel` sets `aria-label`. `AriaLabelledBy` sets `aria-labelledby` and takes precedence for the accessible name. A modal panel should have one of the two. |
| A2 | The resolved role follows the table above. `Role` replaces it and nothing else. |
| A3 | The panel must not emit `aria-expanded`. The consumer's toggle owns `aria-expanded` and `aria-controls`, pointing `aria-controls` at the panel `Id`. |

### 8.2 Hidden state and backdrop

- Fully closed without mini: the panel has `aria-hidden="true"`.
- Open, or closed with mini: the panel does not have `aria-hidden="true"`.
- The backdrop always has `aria-hidden="true"` and has no accessible name.

### 8.3 Focus

| Step | Requirement |
|------|-------------|
| Move in | Opening a modal Overlay panel moves focus to the first focusable descendant, or to the panel itself when none exists. The panel then has `tabindex="-1"`. |
| Trap | While the modal panel is open, Tab from the last focusable descendant moves to the first, and Shift+Tab from the first moves to the last. Focus must not reach content outside the panel. |
| Restore | Closing returns focus to the element that opened the panel, when that element is still connected. |
| Escape | Escape follows M-O6 and then runs restore. |
| Docked | Push and Shrink do not move focus and do not trap it. |

### 8.4 Automated scan policy

Routes that render each state must have zero serious or critical axe findings. The Sidebar allowlist is empty. Because the scan loads a URL and does not click, open states need their own routes (§13 of `TEST-MATRIX.md`).

### 8.5 Assistive-technology notes

Manual NVDA, Narrator, and JAWS notes are filed under `.github/accessibility/`. They are evidence, not a merge gate. The merge gate is the automated matrix.

---

## 9. Styling

### 9.1 Isolation

Layout and color live in the component's scoped stylesheet. Consumers override with `::deep`. Tokens come from the toolkit theme. `@media (forced-colors: active)` must set a visible border and focus outline and must not rely on a background color alone. `@media (prefers-reduced-motion: reduce)` completes transitions immediately.

### 9.2 CSS variables

| Variable | Source | Example |
|----------|--------|---------|
| `--e-sidebar-width` | `Width` | `280px` |
| `--e-sidebar-mini-width` | `MiniWidth` | `64px` |
| `--e-sidebar-occupied-width` | §4.4 | `0px`, `64px`, or `280px` |
| `--e-sidebar-duration` | `Duration` | `300ms` |

The variables are set on the host. Scoped rules consume them. No other inline style is required for layout.

---

## 10. Platform

| Dimension | v1 rule |
|-----------|---------|
| TFMs | `net8.0`, `net9.0`, `net10.0`. Full CI on `net10.0`. Smoke tests on `net8.0`. `net9.0` compiles in the multi-target build. |
| Render modes, CI-gated | Static SSR and Interactive Server. |
| Render modes, supported, not CI-gated | Interactive WebAssembly and Interactive Auto. |
| Browsers | Chromium, Firefox, and WebKit are mandatory for every P0 Playwright row. |
| Namespace | `Syncfusion.Blazor.Toolkit` only. |

Static SSR must emit the correct open, closed, and mini markup from parameters without JavaScript. Toggle, focus trap, and responsive reconciliation require an interactive render.

---

## 11. Lifecycle and disposal

- `NavigationManager.LocationChanged` is subscribed only while O3 applies, and is unsubscribed in `DisposeAsync`.
- The viewport listeners from §6.2 are removed in `DisposeAsync`.
- A pending animation callback (§7.3) is cancelled in `DisposeAsync`.
- After dispose, a location change or a viewport change must not update state and must not raise an event.

---

## 12. Edge cases

| Case | Required behavior |
|------|-------------------|
| `IsEnabled=false` | User dismissal is ignored (O2). The visual state does not change. |
| Rapid toggling | 100 `ToggleAsync` calls with animation off finish in the toggled state and do not throw. |
| Dual sidebars | Two instances with distinct `Id` values render both panels (M-P4). |
| Null templates | Header and footer regions are absent. The body region is present and empty. |
| Missing `Id` | The component generates a stable id for the panel for the lifetime of the instance. |
| Gesture | A horizontal swipe may request open or close only when `IsEnabled` is `true`. It is not part of the v1 test contract. |

---

## 13. Build quality

### 13.9 Warnings and nullability

- The Sidebar sources build with zero warnings and zero errors under the repo analyzer rules.
- Nullable reference types are annotated. The build introduces no new `CS86xx` diagnostics.
- Public signatures match `API.md`. The public-API baseline is updated intentionally and only for this surface.
