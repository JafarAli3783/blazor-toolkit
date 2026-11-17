# Product Requirements Document – SfMenu

## Syncfusion Blazor Toolkit

**Version:** 1.0  
**Status:** Draft, pending API review. Not implemented.  
**Authority:** This file owns product scope. `API.md` is the only public-member contract. `Spec.md` owns behavior and must not introduce parameters. `API-xml.md` documents `API.md` and must not add members. `TEST-MATRIX.md` must not require a non-goal. `Evidence.md` is pending and non-normative until implementation.  
**Related:** Spec.md, API.md, API-xml.md, TEST-MATRIX.md, Evidence.md, competitive-matrix.md, TRACEABILITY.md

---

## 1. Product background

Syncfusion Blazor Toolkit is an MIT-licensed, open-source Blazor component set targeting .NET 8, .NET 9, and .NET 10. The Toolkit prioritizes accessibility, AOT/trim safety, CSS isolation, and reuse of shared primitives (`SfThemeRoot`, popup infrastructure, etc.).

Menu is a foundational navigation and command component required for application shells, settings surfaces, and hierarchical actions.

## 2. Problem statement

There is no Toolkit-native Menu that:

- Correctly implements the WAI-ARIA **Menu / Menubar** pattern
- Supports both horizontal (menubar) and vertical orientations
- Provides clean hierarchical data binding (flat + hierarchical)
- Delivers strong keyboard navigation, focus management, and accessibility evidence
- Reuses existing Toolkit primitives and remains free of commercial Syncfusion.Blazor dependencies
- Matches or exceeds leading Blazor Menu implementations (MudBlazor, Telerik, Radzen, DevExpress, and commercial Syncfusion Menu Bar)

## 3. User needs

| Need | Description |
|---|---|
| Hierarchical navigation | Multi-level menus with clear open/close behavior |
| Orientation | Horizontal (menubar) and Vertical layouts |
| Data binding | Flat (ParentId) and hierarchical collections |
| Accessibility | Full WAI-ARIA Menu/Menubar pattern, keyboard, screen reader support |
| Templates & icons | Item templates, icons, separators, disabled items |
| Interaction control | Open on click or hover, programmatic open/close |
| Toolkit consistency | CSS isolation, SfThemeRoot tokens, zero commercial dependencies |
| Performance & quality | AOT/trim clean, 0 warnings, measurable accessibility |

## 4. Target users

- Application developers building navigation bars, application menus, and command menus
- Teams requiring WCAG 2.2 AA compliance
- Developers targeting Blazor Server, WebAssembly, Static SSR, Interactive Server, Interactive WebAssembly, and Auto render modes

## 5. Primary use cases

1. Application top navigation (horizontal menubar)
2. Side navigation or vertical command menus
3. Hierarchical settings / options menus
4. Data-bound menus from flat or hierarchical collections
5. Icon + text menus with separators and disabled items
6. Keyboard-accessible menus used with screen readers

## 6. Secondary use cases

- Programmatic open/close
- Nested submenu positioning with collision detection
- RTL layouts
- High-contrast / Forced Colors support

## 7. Goals

| Goal | Metric |
|---|---|
| Spec coverage | Every in-scope user story maps to retained tests |
| Accessibility | axe critical + serious = 0 on defined sample routes; full Menu/Menubar keyboard support |
| Keyboard | Complete arrow-key, Home/End, Enter/Space, Escape, and type-ahead support |
| Build quality | 0 compiler, analyzer, nullable, and CS1591 warnings on net8.0 / net9.0 / net10.0 |
| Toolkit reuse | Core chrome reuses existing Toolkit primitives where feasible |
| Competitive parity | ≥ 95% of core features present in top competitors |
| Evidence | Evidence items completed or explicitly waived with rationale |

## 8. Non-goals (v1)

- Full **ContextMenu** component (separate component planned later)
- Mega-menu layouts
- Built-in search / filtering inside the menu
- Drag-and-drop reordering of menu items
- Multi-select / checkable menu items (Phase 2 candidate)
- Virtualization of extremely large menus
- Commercial Syncfusion.Blazor package dependencies
- Toolbar or AppBar replacement

## 9. Functional requirements (summary)

Member names and defaults live only in `API.md`. Behavior lives in `Spec.md`.

- `SfMenu` (primary) with support for generic `SfMenu<TItem>` if it matches Toolkit patterns
- Optional declarative `SfMenuItem` children
- Horizontal and Vertical orientation
- Hierarchical and flat data binding
- Icons, separators, disabled items
- Item templates
- Open on Click or Hover
- Full keyboard navigation per WAI-ARIA Menu/Menubar pattern
- Programmatic Open / Close / Focus methods
- RTL support via ancestor `dir`
- CSS isolation + SfThemeRoot tokens
- Collision-aware popup positioning

## 10. Accessibility goals

WCAG 2.2 AA minimum (AAA where feasible).  
Must implement the **WAI-ARIA Menu / Menubar** pattern correctly (roles: `menubar`, `menu`, `menuitem`, `separator`, `aria-haspopup`, `aria-expanded`, etc.).

Focus management, keyboard navigation, Forced Colors, and screen-reader announcements must be evidenced.

## 11. Performance goals (proposed; not measured)

| Scenario | Proposed target |
|---|---|
| Open first-level menu | Perceived latency < 16 ms |
| Nested submenu open | Smooth, no layout thrashing |
| Large hierarchical menu (moderate depth) | Interactive |

## 12. Compatibility goals

| Surface | Goal |
|---|---|
| TFMs | net8.0, net9.0, net10.0 |
| Render modes | Static SSR (visual), Interactive Server, Interactive WebAssembly, Interactive Auto |
| Trimming / AOT | Clean |
| Browsers | Latest 2 versions of Chrome, Edge, Firefox, Safari |

## 13. Success metrics

- All in-scope user stories have corresponding tests
- 0 axe critical/serious issues on the 10 defined routes
- 0 build / analyzer / CS1591 / trim warnings
- Competitive matrix shows clear parity or leadership on core Menu features
- Two maintainer approvals

## 14. Risks and mitigations

| Risk | Mitigation |
|---|---|
| Incorrect ARIA pattern | Strict adherence to WAI-ARIA Menu/Menubar APG + axe + manual SR testing |
| Popup positioning / collision | Reuse or extend existing Toolkit popup infrastructure |
| Focus loss on open/close | Explicit focus management tests |
| Scope creep into ContextMenu | Explicit non-goal |

## 15. Future enhancements (not v1)

- Separate ContextMenu component
- Checkable / multi-select items
- Mega-menu support
- Built-in search
- Advanced virtualization

---