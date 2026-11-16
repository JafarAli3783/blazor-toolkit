---

# competitive-matrix.md

---

# Competitive Matrix — Blazor Sidebar / Drawer Components

**Product under design:** Syncfusion Blazor Toolkit `SfSidebar`  
**Document version:** 2.0  
**Goal:** Industrial best-in-class OSS Sidebar; match strongest functional patterns; **lead** on a11y, contrast, CSS isolation, RTL.

## 1. Competitor set

### Tier A — Primary benchmarks

| Rank | Library | Component | URL | License model |
|------|---------|-----------|-----|---------------|
| 1 | MudBlazor | Drawer | https://www.mudblazor.com/components/drawer | MIT |
| 2 | Telerik UI for Blazor | Drawer | https://www.telerik.com/blazor-ui/documentation/components/drawer/overview | Commercial |
| 3 | DevExpress Blazor | DxDrawer | https://docs.devexpress.com/Blazor/404362/components/layout/drawer | Commercial |
| 4 | Radzen Blazor | Sidebar (+ PanelMenu) | https://blazor.radzen.com/layout | MIT |
| 5 | Ant Design Blazor | Layout Sider | https://antblazor.com/en-US/components/layout/ | MIT |

### Tier B — Secondary references

| Rank | Library | Component | URL |
|------|---------|-----------|-----|
| 6 | Blazorise | Sidebar / LayoutSider | https://blazorise.com/docs/extensions/sidebar |
| 7 | HAVIT Blazor | HxSidebar | https://havit.blazor.eu/components/HxSidebar |
| 8 | Blazor Bootstrap | Sidebar | https://docs.blazorbootstrap.com/components/sidebar |
| 9 | Material.Blazor | MBDrawer | https://material-blazor.com/docs/Material.Blazor/Components/Drawer/MBDrawer.html |
| 10 | Majorsoft | Navigation-related | https://github.com/majorimi/blazor-components |

---

## 2. Feature matrix (detailed)

Legend: ✅ Supported | 🟡 Partial / via other components | ❌ Absent or weak | ⭐ Required for SfSidebar v1

### 2.1 Display modes

| Feature | Mud | Telerik | DX | Radzen | Ant | Blazorise | HAVIT | BB | MB | **SfSidebar** |
|---------|-----|---------|----|--------|-----|-----------|-------|----|----|---------------|
| Overlay / temporary | ✅ | ✅ | ✅ Overlap | ✅ Overlay | 🟡 | ✅ | ✅ | ✅ | ✅ | ⭐ ✅ |
| Push / persistent shift | ✅ Persistent | ✅ Push | 🟡 | 🟡 | 🟡 | 🟡 | 🟡 | 🟡 | 🟡 | ⭐ ✅ |
| Shrink / compress content | 🟡 layout | 🟡 | ✅ Shrink | 🟡 | ✅ width | 🟡 | 🟡 | 🟡 | 🟡 | ⭐ ✅ |
| Mini / collapsed rail | ✅ Mini variant | ✅ MiniMode | ✅ Mini | ✅ icon sidebar | ✅ collapsedWidth | 🟡 | 🟡 | 🟡 | 🟡 | ⭐ ✅ |
| Responsive variant | ✅ Responsive | 🟡 | ✅ | ✅ | ✅ breakpoint | 🟡 | 🟡 | 🟡 | 🟡 | ⭐ ✅ |
| Hover expand mini | ✅ OpenMiniOnHover | 🟡 | 🟡 | 🟡 | 🟡 | ❌ | ❌ | ❌ | ❌ | ⭐ ✅ optional |

### 2.2 Position & layout

| Feature | Mud | Telerik | DX | Radzen | Ant | **SfSidebar** |
|---------|-----|---------|----|--------|-----|---------------|
| Left / Right | ✅ | ✅ | ✅ | ✅ | ✅ | ⭐ ✅ |
| Start / End (RTL logical) | ✅ Anchor Start/End | 🟡 Start | 🟡 | ✅ | 🟡 | ⭐ ✅ |
| Fixed positioning | ✅ | 🟡 | 🟡 | 🟡 | 🟡 | ⭐ ✅ |
| Optional TargetContent / DrawerContent | 🟡 MudLayout | ✅ | ✅ | ✅ Layout | ✅ Layout | ⭐ ✅ optional |
| Works **without** framework Layout | 🟡 discouraged | ✅ | ✅ | 🟡 | 🟡 | ⭐ ✅ |
| Dual sidebars | ✅ | 🟡 | 🟡 | ✅ | 🟡 | ⭐ ✅ |
| AppBar clip modes | ✅ ClipMode | ❌ | ❌ | ❌ | ❌ | ❌ v1 (no AppBar) |

### 2.3 State & API

| Feature | Mud | Telerik | DX | Radzen | Ant | **SfSidebar** |
|---------|-----|---------|----|--------|-----|---------------|
| Two-way open/expanded | ✅ Open | ✅ Expanded | ✅ IsOpen | ✅ Expanded | ✅ collapsed | ⭐ ✅ IsOpen |
| Open / Close / Toggle methods | 🟡 | ✅ | 🟡 | ✅ Toggle | 🟡 | ⭐ ✅ |
| Auto-close on navigate | ✅ with bind | 🟡 | 🟡 | 🟡 | 🟡 | ⭐ ✅ |
| Overlay click dismiss | ✅ | ✅ | ✅ | ✅ | 🟡 | ⭐ ✅ |
| Escape dismiss | ✅ | 🟡 | 🟡 | 🟡 | 🟡 | ⭐ ✅ |
| Width parameters | ✅ | ✅ | ✅ | ✅ | ✅ | ⭐ ✅ |
| Animation duration control | 🟡 | 🟡 | 🟡 | 🟡 | 🟡 | ⭐ ✅ |
| Breakpoint event | 🟡 | 🟡 | 🟡 | 🟡 | ✅ onBreakpoint | ⭐ ✅ |

### 2.4 Content & navigation

| Feature | Mud | Telerik | DX | Radzen | Ant | **SfSidebar** |
|---------|-----|---------|----|--------|-----|---------------|
| Arbitrary ChildContent | ✅ | ✅ Template | ✅ | ✅ | ✅ | ⭐ ✅ |
| Header / Footer templates | ✅ Header | 🟡 | ✅ | 🟡 | 🟡 | ⭐ ✅ |
| Data-bound item list | 🟡 NavMenu | ✅ Data | 🟡 Menu | ✅ PanelMenu | ✅ Menu | 🟡 v1 compose |
| Nested hierarchy | via NavMenu | 🟡 | via Menu | ✅ | ✅ | 🟡 compose |
| Item templates | Nav | ✅ | 🟡 | ✅ | ✅ | 🟡 consumer |

### 2.5 Accessibility & quality (differentiation)

| Feature | Mud | Telerik | DX | Radzen | Ant | Typical Tier B | **SfSidebar** |
|---------|-----|---------|----|--------|-----|----------------|---------------|
| Documented ARIA patterns | 🟡 | 🟡 | ✅ stronger | 🟡 | 🟡 | 🟡 | ⭐ full Spec |
| Focus trap overlay | 🟡 | 🟡 | 🟡 | 🟡 | 🟡 | 🟡 | ⭐ ✅ |
| WCAG 2.2 AA evidence process | 🟡 | 🟡 | 🟡 | 🟡 | 🟡 | 🟡 | ⭐ ✅ |
| WCAG 2.2 AAA targets | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ⭐ checklist |
| NVDA + Narrator + JAWS notes | 🟡 | 🟡 | 🟡 | 🟡 | 🟡 | 🟡 | ⭐ required |
| Windows forced-colors | 🟡 | 🟡 | 🟡 | 🟡 | 🟡 | 🟡 | ⭐ ✅ |
| CSS isolation scoped | 🟡 | 🟡 | 🟡 | 🟡 | 🟡 | 🟡 | ⭐ ✅ |
| RTL first-class | ✅ | 🟡 | 🟡 | ✅ | 🟡 | 🟡 | ⭐ ✅ |
| Localization hooks | 🟡 | ✅ | ✅ | ✅ | ✅ | 🟡 | ⭐ ✅ |
| Zero-warning engineering bar | 🟡 | n/a | n/a | 🟡 | 🟡 | 🟡 | ⭐ ✅ |
| MIT / free | ✅ | ❌ | ❌ | ✅ | ✅ | ✅ | ⭐ ✅ |

---

## 3. Competitor deep notes

### 3.1 MudBlazor Drawer

**Strengths**

- Variants: Temporary, Persistent, Mini, Responsive (`DrawerVariant`).
- `Anchor` including Start/End; `Breakpoint`; `ClipMode` with AppBar (Always/Docked/Never).
- `@bind-Open` + auto-close on navigation when two-way bound.
- Ecosystem: MudLayout, MudNavMenu, elevation, color.

**Weaknesses vs SfSidebar target**

- Shrink-as-first-class mode less explicit than DevExpress.
- Accessibility/contrast evidence not a published industrial bar.
- Layout coupling expectations (drawer “must be inside MudLayout” in docs for full behavior).

**API cues to match:** Variant matrix, Anchor Start, Open bind, Mini hover, Breakpoint.

### 3.2 Telerik Drawer

**Strengths**

- Clear **Overlay vs Push**; **MiniMode**; **Position**; **Width**.
- **Data** binding, selection, ItemTemplate/Template.
- **ExpandAsync / CollapseAsync / ToggleAsync**.
- DrawerContent integration.

**Weaknesses**

- Commercial license.
- Shrink mode not primary.
- A11y/contrast leadership opportunity for Toolkit.

**API cues to match:** Methods trio, MiniMode, DrawerContent, templates.

### 3.3 DevExpress DxDrawer

**Strengths**

- **Overlap vs Shrink**; **MiniModeEnabled**; **Position**.
- **HeaderTemplate / BodyTemplate / FooterTemplate / TargetContent**.
- Responsive visibility; static SSR discussion.
- Explicit ARIA labeling guidance for overlap (`aria-label` / `aria-labelledby`).

**Weaknesses**

- Commercial.
- Push naming differs (Overlap/Shrink mental model).

**API cues to match:** TargetContent, template regions, mini, ARIA docs.

### 3.4 Radzen Sidebar + PanelMenu

**Strengths**

- Layout integration; **Expanded**; **Position** Left/Right/Start/End; **Responsive**; **FullHeight**.
- PanelMenu: nested items, keyboard navigation, display styles.

**Weaknesses**

- Sidebar is layout-centric; mode matrix less complete than Mud/Telerik drawer.
- Hierarchy lives in PanelMenu, not Sidebar itself.

**API cues to match:** Start/End, Responsive inside layout, nested nav via composition.

### 3.5 Ant Design Blazor Sider

**Strengths**

- `collapsed` / `collapsedWidth` / `breakpoint` / `collapsible` / `trigger` patterns familiar to Ant users.
- Theme light/dark on sider.

**Weaknesses**

- Overlay/push semantics less central in Blazor docs than pure collapse width.

**API cues to match:** Breakpoint callbacks, collapsed width.

### 3.6 Tier B (summary)

Useful for alternate API naming and Material patterns; generally thinner mode matrices and less enterprise template structure. SfSidebar should not under-shoot Tier A on modes while exceeding all tiers on a11y/contrast/isolation.

---

## 4. Benchmark checklist (acceptance)

Copy into QA plan; **all must pass for v1**.

### Modes & layout

- [ ] Overlay with backdrop  
- [ ] Push offsets target content  
- [ ] Shrink compresses target content  
- [ ] Mini rail at MiniWidth  
- [ ] Left, Right, Start, End  
- [ ] Dual Start + End instance sample  
- [ ] Standalone without Layout parent  
- [ ] TargetContent integrated layout  

### Behavior

- [ ] `@bind-IsOpen`  
- [ ] OpenAsync / CloseAsync / ToggleAsync  
- [ ] CloseOnOverlayClick  
- [ ] CloseOnEscape  
- [ ] CloseOnNavigate (when enabled)  
- [ ] Responsive breakpoint switch + event  
- [ ] OpenMiniOnHover optional  
- [ ] prefers-reduced-motion respected  

### Content

- [ ] ChildContent  
- [ ] HeaderTemplate / FooterTemplate  
- [ ] Sample with NavLink hierarchy  

### Accessibility

- [ ] Dialog naming on modal overlay  
- [ ] Focus in on open, restore on close  
- [ ] Focus trap while modal  
- [ ] Keyboard-only operable  
- [ ] NVDA smoke  
- [ ] Narrator smoke  
- [ ] JAWS smoke  
- [ ] Landmark guidance documented  

### Platform quality

- [ ] Windows forced-colors / High Contrast  
- [ ] CSS isolation (scoped)  
- [ ] RTL sample  
- [ ] Localization for built-in strings (if any)  
- [ ] Zero build warnings  
- [ ] Static SSR initial paint  

---

## 5. Gap analysis → SfSidebar priorities

| Priority | Gap in market | SfSidebar response |
|----------|---------------|--------------------|
| P0 | Incomplete OSS mode matrix (Push+Shrink+Overlay+Mini+Responsive) | Implement full matrix |
| P0 | Weak published a11y evidence | Spec + SR notes + AAA checklist |
| P0 | Forced-colors often ignored | Explicit CSS + theme tokens |
| P1 | Layout lock-in | Standalone + optional TargetContent |
| P1 | RTL logical positions inconsistent | Start/End default story |
| P2 | Data-bound items | Defer; compose NavLink/PanelMenu-style consumer UI |

---

## 6. Scoring summary (qualitative)

| Library | Modes | API polish | Nav features | A11y proof | OSS | **Overall vs target** |
|---------|-------|------------|--------------|------------|-----|------------------------|
| MudBlazor | 9/10 | 8/10 | 8/10 | 5/10 | 10 | Strong OSS baseline |
| Telerik | 8/10 | 9/10 | 9/10 | 5/10 | 0 | Strong enterprise API |
| DevExpress | 9/10 | 9/10 | 7/10 | 6/10 | 0 | Best TargetContent/ARIA docs |
| Radzen | 7/10 | 8/10 | 9/10 | 5/10 | 10 | Best Start/End + menu |
| Ant Blazor | 7/10 | 7/10 | 8/10 | 5/10 | 10 | Familiar collapse model |
| **SfSidebar target** | **10** | **9** | **7 (compose)** | **10** | **10** | **Best balanced OSS** |

---

## 7. References

- MudBlazor Drawer API / variants / clip mode docs  
- Telerik Drawer overview (modes, mini, methods, templates)  
- DevExpress DxDrawer (overlap/shrink, templates, ARIA)  
- Radzen Sidebar / Layout / PanelMenu  
- Ant Design Layout.Sider API  
- Syncfusion Toolkit ACCESSIBILITY.md, DEVELOPMENT.md, CHANGELOG 2.0 (CSS isolation, theme root, contrast)