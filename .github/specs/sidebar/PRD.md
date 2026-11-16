# Product Requirements Document (PRD)
## SfSidebar — Syncfusion® Toolkit for Blazor

| Field | Value |
|-------|--------|
| **Component name** | `SfSidebar` |
| **Display name** | Sidebar |
| **Namespace** | `Syncfusion.Blazor.Toolkit` |
| **Repository** | https://github.com/syncfusion/blazor-toolkit |
| **License** | MIT |
| **Package** | `Syncfusion.Blazor.Toolkit` |
| **Target TFMs** | `net8.0`, `net9.0`, `net10.0` |
| **Render modes** | Interactive Server, Interactive WebAssembly, Interactive Auto; static SSR for initial paint only |
| **Document version** | 2.0 |
| **Status** | Proposed — ready for implementation |
| **Related Toolkit systems** | `SfThemeRoot`, CSS isolation, High Contrast / forced-colors themes, sample browser |

---

## 1. Executive summary

The Syncfusion Blazor Toolkit does not yet ship a Sidebar/Drawer. Competing Blazor libraries (MudBlazor, Telerik, DevExpress, Radzen, Ant Design Blazor, and others) already provide mature side-panel patterns used in almost every multi-page app layout.

**SfSidebar** must be an industrial, best-in-class open-source Sidebar that:

- Matches or exceeds the **mode matrix** of the strongest competitors (Overlay, Push, Shrink, Mini, Responsive).
- **Leads** on accessibility (WCAG 2.2 **AAA target**, AA mandatory), Windows high-contrast / forced-colors, CSS isolation, RTL, localization, and zero build warnings.
- Fits Toolkit architecture: single root namespace, theme emission via `SfThemeRoot`, `.razor.css` isolation, samples, tests, and accessibility evidence under `.github/accessibility/`.

---

## 2. Problem statement

### 2.1 User problem

Application developers building Blazor Server/WASM apps need a side panel for:

- Primary app navigation (links, hierarchical menus composed by the consumer).
- Secondary/contextual UI (filters, help, settings).
- Responsive behavior: persistent on desktop, overlay on mobile.
- Optional mini “rail” of icons when collapsed.

Without a Toolkit Sidebar, developers either pull a third-party layout stack, copy incomplete CSS, or use commercial components—undermining the Toolkit’s “complete lightweight OSS UI” value.

### 2.2 Product gap

| Area | Current Toolkit | Gap |
|------|-----------------|-----|
| Layout / popup | `SfDialog`, `SfTooltip` | No docked side panel |
| Navigation shell | Samples only | No reusable Sidebar primitive |
| A11y bar | WCAG 2.2 AA aim (repo statement) | Sidebar needs explicit AAA-oriented design |
| Contrast | High Contrast + forced-colors in 2.x | Must apply to Sidebar surfaces |

### 2.3 Why now

Toolkit 2.0 consolidated namespaces, CSS isolation, and theme root. Adding Sidebar on that foundation avoids a second migration and demonstrates the new styling/a11y model on a high-visibility layout component.

---

## 3. Goals and non-goals

### 3.1 Goals (v1)

| ID | Goal | Measurable outcome |
|----|------|--------------------|
| G1 | Ship `SfSidebar` with Overlay, Push, Shrink modes | All three modes in samples + tests |
| G2 | Mini rail + responsive breakpoint behavior | Configurable width/breakpoint; documented defaults |
| G3 | Left/Right and logical Start/End positioning | Correct under `dir="rtl"` |
| G4 | Programmatic and declarative open state | `@bind-IsOpen`, `OpenAsync` / `CloseAsync` / `ToggleAsync` |
| G5 | Templates for header, body, footer; optional target content | Parity with enterprise TargetContent/DrawerContent patterns |
| G6 | Accessibility | WCAG 2.2 AA pass; AAA checklist completed; NVDA, Narrator, JAWS smoke notes filed |
| G7 | Windows contrast | Forced-colors + High Contrast theme tokens applied |
| G8 | CSS isolation | No global style leakage; scoped `.razor.css` |
| G9 | i18n | RTL. v1 ships no new localizable chrome strings (`API.md`, Localization) |
| G10 | Engineering quality | **Zero** compiler/analyzer warnings; CI green |

### 3.2 Non-goals (v1)

| ID | Non-goal | Rationale |
|----|----------|-----------|
| NG1 | First-party hierarchical `SfNavMenu` product | Compose with `NavLink` / future menu; avoid scope explosion |
| NG2 | Mandatory proprietary Layout parent | Consumers must be able to use standalone panel |
| NG3 | Multi-pane IDE docking (arbitrary splitters) | Dual left+right sidebars only |
| NG4 | Persistence service (localStorage) as default | Optional parameter only if low-cost; not required for v1 GA |
| NG5 | Visual parity with Syncfusion commercial Blazor Sidebar | Toolkit is independent MIT surface |
| NG6 | Data-grid-style virtualization of thousands of nav items | Out of scope for panel chrome |

---

## 4. Personas and jobs-to-be-done

| Persona | Job | Success looks like |
|---------|-----|--------------------|
| **App developer** | Wire MainLayout with toggle in header | < 15 minutes from package to working sidebar |
| **Enterprise UI engineer** | Overlay mobile + Push desktop + Mini | One component, parameters only |
| **Accessibility specialist** | Keyboard + SR pass | Documented roles, focus, escape, no accidental traps |
| **Global product team** | Arabic/Hebrew RTL + translated chrome | Start/End + resources |
| **Design system owner** | Theme and contrast | Tokens + forced-colors without forked CSS |

---

## 5. Primary user scenarios

### S1 — Classic app shell (desktop)

1. Developer places `SfSidebar` with `Mode="Push"` or `Shrink`, `IsOpen="true"`.
2. Header contains a menu button that toggles `@bind-IsOpen`.
3. Main content sits in `TargetContent` (or adjacent markup with documented offset).
4. Sidebar shows brand + `NavLink` list in `ChildContent`.

### S2 — Mobile overlay drawer

1. Viewport below breakpoint → effective mode Overlay (or closed until opened).
2. User opens via menu control; backdrop appears; focus moves into panel.
3. User selects a link → optional auto-close; focus returns to opener.
4. Escape or backdrop click closes when enabled.

### S3 — Mini navigation rail

1. `EnableMini="true"`; collapsed state shows icons only at `MiniWidth`.
2. Toggle expands to `Width`; optional hover expand on desktop.
3. Tooltips on icons are consumer responsibility (document pattern with `SfTooltip` or `title`).

### S4 — Right-side contextual panel

1. `Position="End"` or `Right`; mode Overlay or Push.
2. Content is filters/help, not primary nav (`role` guidance in Spec).

### S5 — Dual sidebars

1. Left nav (Start) + right tools (End) coexist.
2. Z-index and focus rules documented; only one Overlay modal at a time recommended.

### S6 — Static SSR first paint

1. Initial HTML reflects `IsOpen` and width without JS.
2. Toggle requires interactive render mode; no console errors if non-interactive.

---

## 6. Functional requirements

### 6.1 Modes

| Requirement | Detail |
|-------------|--------|
| FR-M1 | Support **Overlay**: panel stacks above content; optional backdrop; does not resize content flow by default. |
| FR-M2 | Support **Push**: panel open state translates/offsets main content along the inline axis. |
| FR-M3 | Support **Shrink**: panel open state reduces the flex/grid basis of main content (docked). |
| FR-M4 | Mode is a public enum parameter; changing mode at runtime updates classes and layout behavior. |

### 6.2 Position

| Requirement | Detail |
|-------------|--------|
| FR-P1 | Physical **Left** and **Right**. |
| FR-P2 | Logical **Start** and **End** resolving with document/element `dir` / RTL. |
| FR-P3 | Default **Start**. |

### 6.3 Open state

| Requirement | Detail |
|-------------|--------|
| FR-O1 | `IsOpen` + `IsOpenChanged` for two-way binding. |
| FR-O2 | Methods `OpenAsync`, `CloseAsync`, `ToggleAsync` on component ref. |
| FR-O3 | One-way `IsOpen` without callback must not be overwritten by internal close paths without invoking callback when bind is used—follow Blazor bind conventions (document: prefer `@bind-IsOpen`). |
| FR-O4 | Optional **CloseOnNavigate** when bound: listen to `NavigationManager.LocationChanged` and close. |
| FR-O5 | **CloseOnOverlayClick** and **CloseOnEscape** (defaults true in Overlay). |

### 6.4 Mini

| Requirement | Detail |
|-------------|--------|
| FR-N1 | `EnableMini`: when “closed”, width = `MiniWidth` instead of 0 / off-screen fully. |
| FR-N2 | Expanded width = `Width`. |
| FR-N3 | Optional `OpenMiniOnHover` for pointer devices only; keyboard users use explicit toggle. |

### 6.5 Responsive

| Requirement | Detail |
|-------------|--------|
| FR-R1 | `Responsive` flag + `Breakpoint` enum/value. |
| FR-R2 | Below breakpoint: prefer Overlay behavior and/or start closed (exact policy in Spec § Responsive state machine). |
| FR-R3 | Fire `OnBreakpointChanged` when crossing threshold. |
| FR-R4 | Use resize observation consistent with Toolkit patterns; no memory leaks on dispose. |

### 6.6 Content model

| Requirement | Detail |
|-------------|--------|
| FR-C1 | `ChildContent` — main panel body. |
| FR-C2 | `HeaderTemplate`, `FooterTemplate` optional. |
| FR-C3 | `TargetContent` optional — hosts page content for integrated Push/Shrink. |
| FR-C4 | No required data-bound item collection in v1 (composition via ChildContent). |

### 6.7 Animation

| Requirement | Detail |
|-------------|--------|
| FR-A1 | CSS transitions for transform/width; `Duration` in ms. |
| FR-A2 | `prefers-reduced-motion: reduce` → instantaneous; `OnOpened` / `OnClosed` follow immediately (Spec §7.3). |
| FR-A3 | `EnableAnimation` master switch. |

### 6.8 Theming & styling

| Requirement | Detail |
|-------------|--------|
| FR-T1 | CSS isolation; public structural classes documented in API.md. |
| FR-T2 | Design tokens via Toolkit theme (light/dark/high-contrast). |
| FR-T3 | `@media (forced-colors: active)` rules for borders, focus, backdrop. |
| FR-T4 | `CssClass`, `HtmlAttributes`, region class hooks. |

### 6.9 Accessibility (product-level)

| Requirement | Detail |
|-------------|--------|
| FR-X1 | Correct role strategy per mode (dialog vs complementary/navigation)—see Spec. |
| FR-X2 | Accessible name required for dialog/overlay (`AriaLabel` / `AriaLabelledBy`). |
| FR-X3 | Focus move-in on Overlay open; restore on close; Tab cycle contained while modal. |
| FR-X4 | Escape closes when allowed; no irreversible keyboard trap (WCAG 2.1.2). |
| FR-X5 | Focus visible; focus not fully obscured (2.4.11 AA; 2.4.12 AAA where feasible). |
| FR-X6 | Manual verification notes for **NVDA, Narrator, JAWS**. |

### 6.10 Platform & quality

| Requirement | Detail |
|-------------|--------|
| FR-Q1 | No build warnings under repo analyzer rules / TreatWarningsAsErrors where enabled. |
| FR-Q2 | Works with `SfThemeRoot` placement rules (theme sibling patterns). |
| FR-Q3 | Dispose subscriptions (viewport, navigation) cleanly. |
| FR-Q4 | Nullable reference types annotated correctly. |

---

## 7. Non-functional requirements

| Category | Requirement |
|----------|-------------|
| **Performance** | No continuous rAF loops; resize debounced; minimal JS interop. |
| **Bundle** | Prefer CSS + C#; interop only for viewport/focus if unavoidable. |
| **SSR** | Correct initial markup for open/closed/mini widths. |
| **Security** | No `HTML` string injection APIs; templates are `RenderFragment` only. |
| **Compatibility** | .NET 8/9/10; modern evergreen browsers per Toolkit support statement. |
| **Documentation** | Overview, modes, mini, responsive, a11y, RTL, API reference, samples. |

---

## 8. Competitive positioning

**Primary benchmarks:** MudBlazor Drawer, Telerik Drawer, DevExpress DxDrawer, Radzen Sidebar, Ant Design Blazor Sider.

**Win themes:**

1. Full mode set in **MIT** OSS (Overlay + Push + Shrink + Mini + Responsive).
2. **Accessibility evidence** and WCAG 2.2 rigor beyond typical OSS drawers.
3. **Windows contrast** and **CSS isolation** as first-class.
4. **Start/End** RTL positioning without requiring a closed layout framework.
5. Optional **TargetContent** without mandating a full layout system.

Detailed scoring: see `competitive-matrix.md`.

---

## 9. Success metrics / acceptance

| Metric | Pass criteria |
|--------|----------------|
| Feature checklist | 100% of “SfSidebar target” column items in competitive-matrix § checklist |
| A11y | AA automated + manual SR notes committed; AAA items tracked |
| Contrast | Visual pass under Windows High Contrast / forced-colors |
| RTL | Start/End + dir=rtl sample |
| Build | 0 warnings on Sidebar projects |
| Tests | bUnit coverage for modes, bind, close paths, responsive flag classes; Playwright on Chromium, Firefox and WebKit for P0 browser rows; axe scans for the open and closed states. `TEST-MATRIX.md` is the traceable list. |
| Samples | Default, Modes, Mini, Responsive, RTL, Accessibility, Dual. At most 10 dedicated accessibility pages (the repository gate allows 10 per control). |

---

## 10. Dependencies and constraints

- Must follow Toolkit **namespace consolidation** (`Syncfusion.Blazor.Toolkit` only).
- Must use **CSS isolation** (not a return to global-only sheets).
- Must not break `SfThemeRoot` ownership/placement tests.
- Accessibility process: align with `.github/ACCESSIBILITY.md` (repo currently states AA aim; **this component’s PRD requires AAA-oriented implementation and documentation** even if org claim remains AA overall).

---

## 11. Risks and mitigations

| Risk | Impact | Mitigation |
|------|--------|------------|
| Focus trap bugs | Blocker for a11y | Shared focus utility; bUnit + manual SR |
| Push/Shrink without TargetContent | Consumer confusion | Document both integration patterns; provide sample CSS variables |
| Responsive flip fighting user bind | UX bugs | Explicit state machine in Spec; events for breakpoint |
| Scope creep (full menu tree) | Delay | ChildContent-only nav in v1 |
| Animation jank | Perceived quality | GPU-friendly transform; reduced-motion |

---

## 12. Rollout plan

| Phase | Scope | Exit criteria |
|-------|--------|----------------|
| **P0** | PRD, Spec, API, matrix approved | Sign-off on this doc set |
| **P1** | Skeleton + Overlay/Push/Shrink + IsOpen API | Unit tests green |
| **P2** | Mini, Responsive, animation, backdrop | Samples for modes |
| **P3** | A11y, contrast, RTL, localization | SR smoke notes |
| **P4** | Docs, gallery samples, CHANGELOG, PR | Merge to main |

---

## 13. Open decisions (resolve before API freeze)

| # | Question | Recommendation |
|---|----------|----------------|
| D1 | Default breakpoint | `Md` (document px in Spec; match common Blazor libs ~768–960) |
| D2 | Default mode | `Overlay` (safe for unknown layouts) or `Push` for desktop shells—**recommend Overlay** to avoid surprising layout shift |
| D3 | v1 data-bound items | **No** — ChildContent only |
| D4 | Persist open state | **Defer** unless trivial |
| D5 | AppBar clip modes (Mud ClipMode) | **Defer** — no Toolkit AppBar yet; document z-index only |

---

## 14. References

- Repo: https://github.com/syncfusion/blazor-toolkit  
- Accessibility evidence: `.github/accessibility/`
- Competitors: `competitive-matrix.md`
- Technical behavior: `Spec.md`
- Public contract: `API.md`
- Test mapping: `TEST-MATRIX.md`