# SfMenu – Competitive Matrix

## Syncfusion Blazor Toolkit

**Version:** 1.0  
**Status:** Research only. Not a requirement source.  
**Authority:** `PRD.md` owns product scope. `API.md` owns public members. This file is supporting evidence only.  
**Last updated:** 2026-11-16

---

## 1. Purpose

This matrix compares the planned **SfMenu** component against major Blazor Menu implementations.  
It is used to identify parity gaps and opportunities for differentiation. It does **not** define requirements.

---

## 2. Competitors Evaluated

| Competitor                          | Type                  | Notes |
|-------------------------------------|-----------------------|-------|
| MudBlazor `MudMenu`                 | Open source (MIT)     | Popular, activator-based |
| Telerik UI for Blazor `TelerikMenu` | Commercial            | Strong data-binding & enterprise features |
| Radzen Blazor `RadzenMenu`          | Open source (MIT)     | Clean declarative model |
| DevExpress Blazor `DxMenu`          | Commercial            | Adaptive / responsive focus |
| Syncfusion Blazor Menu Bar          | Commercial            | Mature feature set (Enterprise) |
| Fluent UI Blazor Menu               | Open source           | Microsoft reference implementation |

---

## 3. Feature Comparison Matrix

| Feature Area                          | Toolkit Target (SfMenu) | MudBlazor | Telerik | Radzen | DevExpress | Syncfusion Enterprise | Fluent UI |
|---------------------------------------|--------------------------|-----------|---------|--------|------------|-----------------------|-----------|
| **Orientation** |
| Horizontal (Menubar)                  | Yes                      | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| Vertical                              | Yes                      | Partial   | Yes     | Yes    | Yes        | Yes                   | Yes       |
| **Data Binding** |
| Hierarchical data                     | Yes                      | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| Flat data (ParentId style)            | Yes                      | Limited   | Yes     | Limited| Yes        | Yes                   | Limited   |
| Declarative items                     | Yes                      | Yes       | Limited | Yes    | Yes        | Yes                   | Yes       |
| **Item Features** |
| Icons                                 | Yes                      | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| Separators                            | Yes                      | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| Disabled items                        | Yes                      | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| Item templates                        | Yes                      | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| Navigation (Url / Href)               | Yes                      | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| **Interaction** |
| Open on Click                         | Yes                      | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| Open on Hover                         | Yes                      | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| Programmatic Open / Close             | Yes                      | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| Close on item select                  | Yes                      | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| **Keyboard & Accessibility** |
| Full arrow-key navigation             | Yes (strong)             | Good      | Good    | Good   | Good       | Good                  | Strong    |
| Home / End support                    | Yes                      | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| Type-ahead navigation                 | Yes                      | Partial   | Yes     | Yes    | Yes        | Yes                   | Yes       |
| WAI-ARIA Menu / Menubar pattern       | Yes (target depth)       | Partial   | Good    | Good   | Good       | Good                  | Strong    |
| `aria-haspopup` / `aria-expanded`     | Yes                      | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| Focus management                      | Yes (explicit)           | Good      | Good    | Good   | Good       | Good                  | Strong    |
| **Popup & Positioning** |
| Collision detection / flip            | Yes                      | Basic     | Yes     | Basic  | Yes        | Yes                   | Yes       |
| Nested submenu positioning            | Yes                      | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| **Platform & Quality** |
| RTL support                           | Yes (via `dir`)          | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| Forced Colors / High Contrast         | Yes (target)             | Partial   | Good    | Partial| Good       | Good                  | Strong    |
| CSS isolation                         | Yes                      | Yes       | Yes     | Yes    | Yes        | Yes                   | Yes       |
| AOT / Trim friendly                   | Strong focus             | Good      | Good    | Good   | Good       | Commercial            | Good      |
| MIT license / No commercial lock-in   | Yes                      | Yes       | No      | Yes    | No         | No                    | Yes       |
| **Related Components** |
| Separate ContextMenu component        | Yes (planned later)      | Combined  | Separate| Separate| Separate  | Separate              | Separate  |

**Legend**  
- **Yes** = Supported  
- **Partial** = Limited or incomplete support  
- **Strong / Good / Basic** = Qualitative assessment of depth or quality  

---

## 4. Summary by Competitor

| Competitor              | Strengths                                      | Weaknesses / Gaps                              | Relevance to Toolkit |
|-------------------------|------------------------------------------------|------------------------------------------------|----------------------|
| **MudBlazor**           | Simple API, activator pattern, popular         | Weaker menubar semantics, combined ContextMenu | Good baseline        |
| **Telerik**             | Excellent data binding, show/hide control      | Commercial                                     | High parity target   |
| **Radzen**              | Clean declarative model, good keyboard         | Less enterprise depth                          | Good open-source ref |
| **DevExpress**          | Adaptive behavior, solid accessibility         | Commercial                                     | High parity target   |
| **Syncfusion Enterprise** | Mature feature set, hamburger, animation     | Commercial, heavier                            | Internal parity ref  |
| **Fluent UI**           | Strong accessibility alignment with Microsoft  | Different design language                      | Accessibility reference |

---

## 5. Opportunity Areas (Where Toolkit can lead)

1. **Accessibility depth**  
   Most correct and best-documented WAI-ARIA Menu/Menubar implementation among Blazor libraries, backed by axe + screen reader evidence.

2. **Clean architecture**  
   Clear separation between `SfMenu` and a future `SfContextMenu`.

3. **AOT / Trim & modern Blazor**  
   First-class support for .NET 8/9/10, minimal JS interop, and zero trim warnings.

4. **Toolkit consistency**  
   Reuse of `SfThemeRoot`, popup infrastructure, and existing primitives.

5. **Developer experience**  
   Both declarative (`SfMenuItem`) and strong data-binding support with selector precedence, matching patterns already used in `SfList`.

---

## 6. Features Explicitly Out of Scope for v1

These appear in some competitors but are **not** required for SfMenu v1:

- Full ContextMenu behavior
- Mega-menu layouts
- Checkable / multi-select menu items
- Built-in search / filtering
- Hamburger / adaptive collapse (can be evaluated later)
- Virtualization of very large menus
- Drag-and-drop reordering

---