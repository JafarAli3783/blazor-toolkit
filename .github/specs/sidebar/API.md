### API list
# SfSidebar API Reference (Proposed)

> Contract for implementation and docs. Types live under `Syncfusion.Blazor.Toolkit`.

## Component

### `SfSidebar`

Collapsible side panel for navigation or secondary content.

```razor
<SfSidebar @bind-IsOpen="_open"
           Mode="SidebarMode.Push"
           Position="SidebarPosition.Start"
           EnableMini="true"
           Width="280px"
           MiniWidth="64px">
    <HeaderTemplate>...</HeaderTemplate>
    <ChildContent>...</ChildContent>
    <FooterTemplate>...</FooterTemplate>
    <TargetContent>
        @Body
    </TargetContent>
</SfSidebar>
```

---

## Enums

### `SidebarMode`

| Name | Description |
|------|-------------|
| `Overlay` | Panel overlays content; optional backdrop. |
| `Push` | Panel pushes content along the inline axis. |
| `Shrink` | Panel reduces available width of target content (dock). |

### `SidebarPosition`

| Name | Description |
|------|-------------|
| `Left` | Physical left. |
| `Right` | Physical right. |
| `Start` | Inline-start (left in LTR, right in RTL). **Default.** |
| `End` | Inline-end (right in LTR, left in RTL). |

### `SidebarBreakpoint` (or reuse shared Toolkit breakpoint if one exists)

| Name | Typical min-width (doc only) |
|------|------------------------------|
| `None` | Responsive off |
| `Xs` | 0 |
| `Sm` | 576px |
| `Md` | 768px (default) |
| `Lg` | 992px |
| `Xl` | 1200px |
| `Xxl` | 1400px |
| `Always` | Always use “desktop” behavior |

---

## Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `IsOpen` | `bool` | `false` | Whether the sidebar is expanded/open. |
| `IsOpenChanged` | `EventCallback<bool>` | — | Two-way bind support. |
| `Mode` | `SidebarMode` | `Overlay` | Overlay, Push, or Shrink. |
| `Position` | `SidebarPosition` | `Start` | Edge docking; Start/End respect RTL. |
| `Width` | `string` | `"280px"` | Expanded width (CSS length). |
| `MiniWidth` | `string` | `"64px"` | Width when mini/collapsed rail is shown. |
| `EnableMini` | `bool` | `false` | When closed, show mini rail instead of fully hidden. |
| `OpenMiniOnHover` | `bool` | `false` | Expand from mini on pointer hover (desktop). |
| `Responsive` | `bool` | `true` | Enable breakpoint-based behavior. |
| `Breakpoint` | `SidebarBreakpoint` | `Md` | Below: mobile (typically Overlay/closed); at/above: persistent mode. |
| `CloseOnOverlayClick` | `bool` | `true` | Overlay mode: click backdrop closes. |
| `CloseOnEscape` | `bool` | `true` | Close on Escape when focus is in scope. |
| `CloseOnNavigate` | `bool` | `true` | When using two-way bind, close on `NavigationManager` location change. |
| `ShowBackdrop` | `bool` | `true` | Render backdrop in Overlay mode. |
| `BackdropClass` | `string?` | `null` | Extra classes on backdrop. |
| `Duration` | `int` | `300` | Animation duration in ms; honor `prefers-reduced-motion`. |
| `EnableAnimation` | `bool` | `true` | Toggle transition. |
| `Fixed` | `bool` | `true` | `position: fixed` vs absolute within container. |
| `CssClass` | `string?` | `null` | Additional classes on root. |
| `Id` | `string?` | auto | Host id; used for `aria-labelledby` patterns. |
| `AriaLabel` | `string?` | `null` | Accessible name when no visible header. |
| `AriaLabelledBy` | `string?` | `null` | ID of labeling element. |
| `Role` | `string?` | auto | Override role (`dialog` / `complementary` / `navigation`). |
| `HtmlAttributes` | `Dictionary<string, object>?` | `null` | Additional attributes splat on root. |
| `ChildContent` | `RenderFragment?` | `null` | Main panel body. |
| `HeaderTemplate` | `RenderFragment?` | `null` | Optional header. |
| `FooterTemplate` | `RenderFragment?` | `null` | Optional footer. |
| `TargetContent` | `RenderFragment?` | `null` | Main page content; sized/translated for Push/Shrink. |
| `IsEnabled` | `bool` | `true` | When false, ignore user open/close (still shows current state). |

---

## Events

| Event | Type | Description |
|-------|------|-------------|
| `IsOpenChanged` | `EventCallback<bool>` | Open state changed. |
| `OnOpened` | `EventCallback<SidebarEventArgs>` | After open animation / state applied. |
| `OnClosed` | `EventCallback<SidebarEventArgs>` | After close. |
| `OnBreakpointChanged` | `EventCallback<bool>` | `true` when viewport is below breakpoint (mobile behavior). |

### `SidebarEventArgs`

| Property | Type | Description |
|----------|------|-------------|
| `IsOpen` | `bool` | Resulting state. |
| `Mode` | `SidebarMode` | Active mode. |

---

## Methods (instance)

Obtain via `@ref`.

| Method | Returns | Description |
|--------|---------|-------------|
| `OpenAsync()` | `Task` | Opens/expands the sidebar. |
| `CloseAsync()` | `Task` | Closes/collapses (to hidden or mini per `EnableMini`). |
| `ToggleAsync()` | `Task` | Toggles open state. |
| `FocusAsync()` | `Task` | Moves focus into the panel (Overlay). |

---

## Compatibility

Members that predate this contract stay on the public surface and add no behavior beyond their shipped documentation:

| Member | Status |
|--------|--------|
| `MediaQuery`, `EnableGestures`, `SidebarTrigger` | Legacy. Not part of v1. |
| `SidebarEventArgs.Trigger` | Retained. `IsOpen` and `Mode` are the contract members. |

---

## CSS classes (public hooks)

| Class | When |
|-------|------|
| `e-sidebar` | Root |
| `e-sidebar-open` | Open/expanded |
| `e-sidebar-mini` | Mini rail visible |
| `e-sidebar-overlay` | Overlay mode |
| `e-sidebar-push` | Push mode |
| `e-sidebar-shrink` | Shrink mode |
| `e-sidebar-left` / `e-sidebar-right` | Physical side resolved |
| `e-sidebar-backdrop` | Backdrop element |
| `e-sidebar-header` / `e-sidebar-body` / `e-sidebar-footer` | Regions. Body is always rendered. Header and footer render only when their template is set. |
| `e-sidebar-target` | Rendered only when `TargetContent` is set. |

`Id`, `CssClass`, and `HtmlAttributes` land on the panel (`div.e-sidebar`), which is also the `aria-controls` target. The layout host (`div.e-sidebar-container`) is internal.

CSS variables set on the host: `--e-sidebar-width`, `--e-sidebar-mini-width`, `--e-sidebar-occupied-width`, `--e-sidebar-duration`. The host `style` attribute holds only these four variables; layout must not be expressed as C#-built inline style strings. `Fixed` and `BackdropClass` are defined in `Spec.md` section 4.5.

Isolation: classes are on scoped elements; consumers override with `::deep`.

The component emits no `data-testid`. Sample pages may set `data-testid` on consumer-owned elements only.

Behavior rules: `Spec.md`. This file is the public surface only.

---

## Accessibility contract

| Context | Role / attributes |
|---------|-------------------|
| Overlay + modal | `role="dialog"`, `aria-modal="true"`, name via `AriaLabel` / `AriaLabelledBy` |
| Push / Shrink | `role="complementary"` or `navigation` (document), `aria-hidden` when fully closed without mini |
| Mini closed | Panel remains in a11y tree if interactive icons present |
| Backdrop | `aria-hidden="true"` |
| Toggle button (consumer) | `aria-expanded`, `aria-controls` pointing at sidebar `Id` |

---

## Localization

v1 has no built-in chrome strings and ships no resource keys. The consumer supplies the toggle label, `AriaLabel`, and `AriaLabelledBy`. `Sidebar_Open` and `Sidebar_Close` are not part of v1.

---

## Non-API requirements (engineering)

- CSS isolation `.razor.css` with scoped id.
- Windows `forced-colors` + Toolkit High Contrast tokens.
- WCAG 2.2 AAA target; AA mandatory.
- Verified with NVDA, Narrator, JAWS.
- RTL via `SidebarPosition.Start` / `End`.
- **Zero build warnings.**

---