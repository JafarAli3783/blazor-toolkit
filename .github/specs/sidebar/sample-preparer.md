**SfSidebar — Sample preparer**

| Field              | Value                                                                 |
|--------------------|-----------------------------------------------------------------------|
| **Component**      | `SfSidebar`                                                           |
| **Host**           | `samples/Blazor.Toolkit.Samples.Client`                               |
| **Catalog route**  | `/navigations/sidebar`                                                 |
| **Demo namespace** | `Blazor.Toolkit.Samples.Client.Pages.Demos.Navigations.Sidebar`        |

This document is the official implementation specification for a complete, competitive set of `SfSidebar` demo samples.

It defines the demo structure, required files, real-world scenarios, visual design, interactions, public APIs to demonstrate, and implementation constraints. Each demo must be implemented as a production-quality sample that clearly teaches **one focused capability** while allowing live exploration of related options.

**Scope Rule (Strict)**

Only the following files may be created, renamed, or modified:

- `samples/Blazor.Toolkit.Samples.Client/Pages/Components/Navigations/Sidebar.razor` — catalog page and demo registration
- `samples/Blazor.Toolkit.Samples.Client/Pages/Demos/Navigations/Sidebar/*.razor` — the demo files listed in section 1

Do **not** modify:

- Sidebar component source code
- Any bUnit, Playwright, or accessibility test files
- Any other catalog, shared style, configuration, or sample file

**Goal**

Create a polished, modern Sidebar sample experience that is clearer and more useful than MudBlazor Drawer, Telerik Drawer, DevExpress DxDrawer, and Radzen Sidebar.

Design principles:

- **One concept per demo** — never repeat the same pattern across multiple pages.
- **Live exploration** — for enums (Mode, Position, Breakpoint, Fixed) provide runtime switchers instead of one page per value.
- **Show Toolkit strengths** — full mode matrix, Mini + icons + hover, logical Start/End, dual sidebars, TargetContent, programmatic API (including FocusAsync), clean event ordering, responsive breakpoint, Fixed vs container positioning.
- **Realistic but light** — short navigation lists, clear status, professional spacing, icons in mini rail.
- **Attractive and focused** — no visual noise, no complicated multi-step flows.

The implementation must deliver these **eight focused demo areas**:

1. Default Overlay navigation
2. Modes + Fixed (live switcher: Overlay / Push / Shrink + Fixed toggle)
3. Mini Rail (icons + EnableMini + optional hover)
4. Positions (live switcher: Left / Right / Start / End)
5. Dual Sidebars (Start + End)
6. Responsive + Breakpoint (live breakpoint selection + clear status)
7. Interaction controls (backdrop, Escape, overlay click)
8. Sidebar API & Events (Open / Close / Toggle / Focus + event log)

---

## 1. Catalog Page Structure

| Item          | Path / Value                                                                 |
|---------------|------------------------------------------------------------------------------|
| Page          | `samples/Blazor.Toolkit.Samples.Client/Pages/Components/Navigations/Sidebar.razor` |
| Demos folder  | `samples/Blazor.Toolkit.Samples.Client/Pages/Demos/Navigations/Sidebar/`      |
| Route         | `@page "/navigations/sidebar"`                                                |
| Base class    | `TocPublishingComponentBase`                                                 |

### TOC and CodePreview mapping (must be used exactly)

| TOC id              | Heading                    | Demo Component              | SourceFile                                                          |
|---------------------|----------------------------|-----------------------------|---------------------------------------------------------------------|
| —                   | Blazor Toolkit Sidebar     | `DefaultDemo`               | `Pages/Demos/Navigations/Sidebar/DefaultDemo.razor`                  |
| `modes`             | Modes                      | `ModesDemo`                 | `Pages/Demos/Navigations/Sidebar/ModesDemo.razor`                    |
| `mini-rail`         | Mini Rail                  | `MiniRailDemo`              | `Pages/Demos/Navigations/Sidebar/MiniRailDemo.razor`                 |
| `positions`         | Positions                  | `PositionsDemo`             | `Pages/Demos/Navigations/Sidebar/PositionsDemo.razor`                |
| `dual-sidebars`     | Dual Sidebars              | `DualSidebarsDemo`          | `Pages/Demos/Navigations/Sidebar/DualSidebarsDemo.razor`             |
| `responsive`        | Responsive                 | `ResponsiveDemo`            | `Pages/Demos/Navigations/Sidebar/ResponsiveDemo.razor`               |
| `interaction`       | Interaction Controls       | `InteractionControlsDemo`   | `Pages/Demos/Navigations/Sidebar/InteractionControlsDemo.razor`      |
| `api`               | Sidebar API                | `ApiDemo`                   | `Pages/Demos/Navigations/Sidebar/ApiDemo.razor`                      |

Rules for the catalog page:

- Register each demo exactly once with a matching `Description` + `CodePreview` pair.
- Use the exact TOC heading and TOC id shown above.
- Keep the component introduction as the first section (no TOC id).
- Update `TocItems` so it contains exactly the entries above, in order.
- Remove every obsolete / repetitive registration from the previous sample set.

---

## 2. Detailed Demo Specifications

### 2.1 DefaultDemo.razor

**Purpose**  
Introduce the component with the most common pattern: a clean Overlay navigation drawer.

**Real-world scenario**  
Primary application navigation that overlays the working surface.

**Visual design**
- Left-side panel (≈ 260–280 px).
- Header with short title (e.g. “Navigation”).
- Simple list of items (text or icon + text).
- Optional short footer.
- Target content with a primary toggle button and 1–2 sentences of explanation.
- `Fixed="false"` so the demo stays inside the preview area.

**Interaction**  
Toggle opens / closes the overlay. Default backdrop and Escape behaviour are active.

**Main APIs highlighted**  
Default `Mode="SidebarMode.Overlay"`, `@bind-IsOpen`, `HeaderTemplate`, `ChildContent`, `FooterTemplate`, `TargetContent`.

**Catalog Description (use exactly)**

```razor
<Description>
    <Header>
        <h1 id="blazor-toolkit-sidebar-component">Blazor Toolkit Sidebar Component</h1>
    </Header>
    <Content>
        The <code>SfSidebar</code> is a collapsible side panel for navigation or secondary tools.
        The default mode is <code>SidebarMode.Overlay</code>: the panel floats above content and can show a backdrop.
    </Content>
</Description>
```

---

### 2.2 ModesDemo.razor

**Purpose**  
Demonstrate all three layout modes **and** Fixed vs container positioning in one interactive sample.

**Real-world scenario**  
Choosing the right layout behaviour for a desktop shell vs a mobile drawer, and deciding whether the panel should be fixed to the viewport or contained inside a layout region.

**Visual design**
- Segmented buttons or radio group for Mode: Overlay | Push | Shrink.
- Separate toggle / checkbox for `Fixed` (default off / false for the preview).
- Same sidebar instance; only the `Mode` and `Fixed` values change.
- Live description that updates according to the selected mode:
  - Overlay → “Covers content, optional backdrop”
  - Push → “Shifts content horizontally”
  - Shrink → “Reduces content width”
- Clear note for Fixed:
  - `Fixed="false"` (default in demos) → panel is positioned inside the demo container
  - `Fixed="true"` → panel is positioned against the viewport
- Target content area shows the visual difference.

**Interaction**  
Changing Mode or Fixed immediately updates the layout. Sidebar can be open or closed while switching.  
When Fixed is turned on, the panel may leave the preview bounds — this is intentional and must be called out in the UI text so users understand the difference.

**Main APIs highlighted**  
`Mode` (Overlay / Push / Shrink), `Fixed`.

**Catalog Description (use exactly)**

```razor
<Description>
    <Header>
        <h2 id="modes">Modes</h2>
    </Header>
    <Content>
        Switch between <code>Overlay</code>, <code>Push</code>, and <code>Shrink</code> at runtime.
        Overlay covers content, Push shifts it, and Shrink reduces the available width of the target area.
        Use the Fixed toggle to compare viewport-fixed positioning with container-contained positioning.
    </Content>
</Description>
```

---

### 2.3 MiniRailDemo.razor

**Purpose**  
Showcase the mini rail with icons — a strong differentiator.

**Real-world scenario**  
Modern app shell that collapses to an icon rail (Dashboard, Projects, Team, Settings).

**Visual design**
- `Mode="SidebarMode.Shrink"` + `EnableMini="true"`.
- Expanded width ≈ 280 px, `MiniWidth` ≈ 64–72 px.
- Collapsed state shows **only icons**; expanded state shows icon + label.
- Optional checkbox: “Open mini on hover”.
- Target content displays current occupied width (“280 px” / “72 px”).
- `Fixed="false"`.

**Interaction**  
Toggle expands / collapses. When hover is enabled, pointer over the rail expands it temporarily.

**Main APIs highlighted**  
`EnableMini`, `MiniWidth`, `OpenMiniOnHover`, icon-based rail content.

**Catalog Description (use exactly)**

```razor
<Description>
    <Header>
        <h2 id="mini-rail">Mini Rail</h2>
    </Header>
    <Content>
        Enable <code>EnableMini</code> to keep a compact icon rail visible when the sidebar is closed.
        Optionally turn on <code>OpenMiniOnHover</code> for desktop pointer expansion.
    </Content>
</Description>
```

---

### 2.4 PositionsDemo.razor

**Purpose**  
Teach physical vs logical positioning with a live switcher.

**Real-world scenario**  
Secondary tools or filters that can appear on either edge and must respect RTL.

**Visual design**
- Button group or radios: Left | Right | Start | End.
- Single sidebar instance whose `Position` changes at runtime.
- Short note that appears when Start/End is selected: “Logical positions follow reading direction (including RTL).”
- Target content explains the difference between physical and logical edges.
- `Fixed="false"`.

**Interaction**  
Changing the position moves the panel immediately.

**Main APIs highlighted**  
`Position` enum (Left / Right / Start / End).

**Catalog Description (use exactly)**

```razor
<Description>
    <Header>
        <h2 id="positions">Positions</h2>
    </Header>
    <Content>
        Choose <code>Left</code> or <code>Right</code> for fixed physical edges, or <code>Start</code> / <code>End</code> for logical edges that follow the reading direction (including RTL).
    </Content>
</Description>
```

---

### 2.5 DualSidebarsDemo.razor

**Purpose**  
Show two independent sidebars on opposite edges — a clear competitive advantage.

**Real-world scenario**  
Primary navigation on the start edge + contextual tools / settings on the end edge.

**Visual design**
- Start-edge sidebar: app navigation with icons (e.g. Store, Library, Community).
- End-edge sidebar: secondary tools (Profile, Orders, History).
- Center content with two distinct buttons: “Toggle Start” and “Toggle End”.
- Both panels can be open at the same time without overlapping.
- Prefer `Mode="SidebarMode.Push"` for both so the center content reacts cleanly.
- `Fixed="false"` on both instances.

**Interaction**  
Each sidebar has its own open state and can be toggled independently.

**Main APIs highlighted**  
Multiple `SfSidebar` instances, different `Position` values, independent state.

**Catalog Description (use exactly)**

```razor
<Description>
    <Header>
        <h2 id="dual-sidebars">Dual Sidebars</h2>
    </Header>
    <Content>
        Place one sidebar on the start edge and another on the end edge.
        Each instance keeps its own open state and can be toggled independently.
    </Content>
</Description>
```

---

### 2.6 ResponsiveDemo.razor

**Purpose**  
Properly demonstrate responsive behaviour and the full breakpoint surface.

**Real-world scenario**  
Navigation that is persistent on desktop and becomes an overlay drawer on mobile.

**Visual design**
- `Responsive` toggle (on by default).
- Live Breakpoint selector covering the important values: `Sm`, `Md`, `Lg`, `Xl` (and optionally `None` / `Always` for contrast).
- Prominent status panel that always shows:
  - Current breakpoint setting
  - Whether the viewport is currently below the breakpoint
  - Effective mode (Overlay when below, configured mode when above)
  - Open state
- Clear instructional text:
  - “Resize the browser (or use device mode) to cross the selected breakpoint.”
  - “Below the breakpoint the sidebar switches to Overlay and closes. Returning to a larger viewport never auto-opens it.”
- Optional “Navigate away” button to demonstrate `CloseOnNavigate`.
- `Fixed="false"`.

**Interaction**  
User changes Breakpoint and/or resizes the viewport. Status text and panel behaviour update immediately. `OnBreakpointChanged` must be wired and reflected in the status panel.

**Main APIs highlighted**  
`Responsive`, `Breakpoint` (multiple values), `OnBreakpointChanged`, `CloseOnNavigate`.

**Catalog Description (use exactly)**

```razor
<Description>
    <Header>
        <h2 id="responsive">Responsive</h2>
    </Header>
    <Content>
        Enable <code>Responsive</code> and choose a <code>Breakpoint</code>.
        Below the threshold the sidebar switches to overlay behaviour and starts closed.
        <code>OnBreakpointChanged</code> reports the transition. Resize the browser to see the change.
    </Content>
</Description>
```

---

### 2.7 InteractionControlsDemo.razor

**Purpose**  
Let the user toggle the main dismissal flags and feel the difference immediately.

**Real-world scenario**  
Fine-tuning how an overlay sidebar responds to backdrop clicks and the Escape key.

**Visual design**
- Checkboxes / switches for `ShowBackdrop`, `CloseOnOverlayClick`, and `CloseOnEscape`.
- Overlay mode.
- Instruction text: “Open the sidebar, then try Escape or click the backdrop.”
- `Fixed="false"`.

**Interaction**  
Flags can be changed while the sidebar is open; behaviour updates at once.

**Main APIs highlighted**  
`ShowBackdrop`, `CloseOnOverlayClick`, `CloseOnEscape`.

**Catalog Description (use exactly)**

```razor
<Description>
    <Header>
        <h2 id="interaction">Interaction Controls</h2>
    </Header>
    <Content>
        Control overlay dismissal with <code>ShowBackdrop</code>, <code>CloseOnOverlayClick</code>, and <code>CloseOnEscape</code>.
        Toggle the options at runtime and test the behaviour with the keyboard and pointer.
    </Content>
</Description>
```

---

### 2.8 ApiDemo.razor

**Purpose**  
Demonstrate the full public imperative API and the event sequence — features that many competitors expose only partially.

**Real-world scenario**  
A command / tool panel driven from external buttons or other components.

**Visual design**
- Four clear buttons: OpenAsync, CloseAsync, ToggleAsync, FocusAsync.
- Live status panel:
  - Current open state
  - Last event (IsOpenChanged / OnOpened / OnClosed)
  - Trigger value when available
- Header + simple content list inside the sidebar.
- `Fixed="false"`.

**Interaction**  
Buttons call the methods on the component reference. Events update the status panel in the correct order.

**Main APIs highlighted**  
`OpenAsync`, `CloseAsync`, `ToggleAsync`, `FocusAsync`, `IsOpenChanged`, `OnOpened`, `OnClosed`.

**Catalog Description (use exactly)**

```razor
<Description>
    <Header>
        <h2 id="api">Sidebar API</h2>
    </Header>
    <Content>
        Obtain a component reference and call <code>OpenAsync</code>, <code>CloseAsync</code>, <code>ToggleAsync</code>, and <code>FocusAsync</code>.
        Observe <code>IsOpenChanged</code>, <code>OnOpened</code>, and <code>OnClosed</code> after the state changes.
    </Content>
</Description>
```

---

## 3. Global Implementation Rules

### 3.1 Design & content rules

1. **One primary concept per demo** — do not mix unrelated features beyond the intentional pairings (Mode + Fixed, Responsive + Breakpoint).
2. **Live switchers instead of duplicate pages** — Mode, Position, Breakpoint, and Fixed are explored with runtime controls.
3. **Icons in Mini rail** — collapsed state shows only icons; expanded state shows icon + label. Use simple, consistent icons available in the sample host.
4. **Fixed handling**  
   - Default in every demo: `Fixed="false"` so the panel stays inside the preview container.  
   - ModesDemo provides a live Fixed switch and explains the difference between viewport-fixed and container-contained positioning.
5. **Breakpoint handling**  
   - ResponsiveDemo must expose multiple Breakpoint values and a clear live status panel.  
   - Users must be able to change the breakpoint and resize the browser to see the effect.
6. **Light realistic content** — short lists, clear status text, no heavy data or nested menus.
7. **Consistent visual language** — spacing, typography, and colours must match the rest of the Toolkit demos.
8. **Accessibility** — consumer toggle buttons must expose `aria-expanded` and `aria-controls` pointing at the sidebar `Id`.

### 3.2 Competitive strengths to surface

Deliberately highlight these Toolkit advantages:

- Full mode matrix (Overlay + Push + Shrink) in one live demo
- Fixed vs container positioning comparison
- Mini rail with icons + optional hover
- Logical Start / End positions
- Dual independent sidebars
- Complete programmatic API including `FocusAsync`
- Clear event ordering (IsOpenChanged → OnOpened / OnClosed)
- Responsive breakpoint with explicit event and multiple threshold values

### 3.3 Styling

- Shared layout rules → `<style>` block in the catalog `Sidebar.razor`.
- Demo-specific colours / backgrounds → local `<style>` inside each demo file.
- Prefer existing Bootstrap / Toolkit tokens and CSS variables.
- No global style leakage.

### 3.4 What to remove

- Delete or stop registering all previous repetitive samples (multiple near-identical Overlay demos, separate MiniRailWithApi, ProgrammaticNavigation, RightPosition-only, etc.).
- Do not add data-bound item collections or hierarchical menus.
- Do not simulate open-state persistence.

### 3.5. Reuse Toolkit components
   Prefer existing Syncfusion Blazor Toolkit components over native HTML elements wherever a suitable control already exists:
   - Use `SfButton` for all primary, outline, and flat actions.
   - Use `SfCheckBox` or `SfSwitch` for boolean toggles (ShowBackdrop, CloseOnEscape, OpenMiniOnHover, Fixed, Responsive, etc.).
   - Do not use native `<button>`, `<input type="checkbox">`, or `<input type="radio">` when a Toolkit equivalent is available.
   - Native elements are allowed only for very simple structural markup (e.g. plain text lists or icons) that have no Toolkit counterpart.

---

## 4. Demo File Implementation Plan

| Final demo file                | Responsibility                                                                 | Notes / replaces                                      |
|--------------------------------|---------------------------------------------------------------------------------|-------------------------------------------------------|
| `DefaultDemo.razor`            | Clean Overlay introduction                                                     | Replaces old DefaultDemo                              |
| `ModesDemo.razor`              | Live Mode switcher (Overlay / Push / Shrink) + live Fixed toggle               | New — replaces separate Push / Shrink pages           |
| `MiniRailDemo.razor`           | Shrink + EnableMini + icons + optional hover                                   | Replaces MiniRailDemo + MiniRailWithApiDemo           |
| `PositionsDemo.razor`          | Live Position switcher (Left / Right / Start / End)                            | Replaces RightPositionDemo                            |
| `DualSidebarsDemo.razor`       | Two independent sidebars (Start + End)                                         | New — primary showcase                                |
| `ResponsiveDemo.razor`         | Live Breakpoint selector + OnBreakpointChanged + status + CloseOnNavigate      | Strengthened — replaces ResponsiveNavigationDemo      |
| `InteractionControlsDemo.razor`| Live toggles for ShowBackdrop / CloseOnOverlayClick / CloseOnEscape            | Replaces InteractionControlsDemo                      |
| `ApiDemo.razor`                | OpenAsync / CloseAsync / ToggleAsync / FocusAsync + event log                  | Replaces ApiDemo + ProgrammaticNavigationDemo         |

### 4.1 File and component conventions

- Catalog page only in `Sidebar.razor`.
- Individual implementations only in the demo folder.
- Use public component APIs only.
- Keep private state and handlers inside the demo that owns the behaviour.
- Use demo-local CSS for one-off layout.
- Remove obsolete preview registrations and source files after the new set is complete.
- Preserve the existing host project and render mode.

### 4.2 Completion checklist

1. All eight final demo files exist at the expected paths.
2. `Sidebar.razor` registers exactly one preview for each demo in the required order.
3. TOC collection and every `SourceFile` match section 1 exactly.
4. Each catalog description matches section 2 exactly.
5. No source-code, test, or unrelated configuration files were changed.
6. Every demo works inside the existing sample host at `/navigations/sidebar`.
7. Mini rail uses icons; Dual Sidebars demo is visually clear and independent.
8. Modes demo provides live Mode + Fixed switchers.
9. Responsive demo provides live Breakpoint selection and a clear status panel that reacts to resize.
10. All demos default to `Fixed="false"`; Fixed behaviour is demonstrated only via the explicit switch in ModesDemo.

---

## 5. Final Acceptance Criteria

- The eight demos render correctly and look professional.
- Each demo teaches a single, clearly labelled capability with no repetition.
- Modes demo lets the user switch Overlay / Push / Shrink live and also toggle Fixed, with clear explanation of viewport-fixed vs container-contained positioning.
- Mini rail shows icons when collapsed and supports the optional hover behaviour.
- Positions demo makes the difference between physical and logical edges obvious.
- Dual Sidebars demo allows both panels to be open independently.
- Responsive demo lets the user change Breakpoint values, shows live below/above status, and reacts correctly when the browser is resized.
- Interaction Controls demo lets the user feel backdrop and Escape behaviour live.
- API demo exercises all four public methods and shows correct event order.
- The overall page is cleaner, more focused, and more competitive than the previous repetitive set and than typical competitor drawer demos.