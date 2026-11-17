# SfMenu – Behavior Specification

## Syncfusion Blazor Toolkit

**Version:** 1.0  
**Status:** Proposed behavior. Not implementation-ready and not implemented.  
**Authority:** `PRD.md` owns scope. `API.md` owns public members. This file owns behavior and must not introduce a parameter that `API.md` does not name.  
**Last updated:** 2026-11-16

---

## 1. Summary

`SfMenu` is a hierarchical navigation and command menu component that supports both horizontal (menubar) and vertical orientations. It implements the WAI-ARIA **Menu / Menubar** pattern.

The component supports:

- Declarative `SfMenuItem` children and/or data-bound items
- Flat (ParentId-style) and hierarchical data
- Icons, separators, disabled items, and item templates
- Click or Hover open modes
- Full keyboard navigation and focus management
- Collision-aware popup positioning for submenus

Public types live in the `Syncfusion.Blazor.Toolkit` namespace. Exact member lists are defined only in `API.md`.

Intended source location (when implementation starts): `src/Components/Menu/` (folder does not exist yet).

---

## 2. Scope

### In v1

- Horizontal (menubar) and Vertical orientation
- Hierarchical nested menus
- Flat and hierarchical data binding
- Icons, separators, disabled items
- Item templates
- Open on Click or Hover
- Programmatic open / close / focus
- Full WAI-ARIA Menu / Menubar keyboard support
- RTL via ancestor `dir`
- CSS isolation and `SfThemeRoot` tokens
- Basic collision detection / flip for submenus

### Out of v1

- Full ContextMenu component (separate future component)
- Mega-menu layouts
- Checkable / multi-select items
- Built-in search or filtering
- Drag-and-drop reordering
- Virtualization of very large menus
- Commercial Syncfusion.Blazor dependencies

---

## 3. Semantic roles (WAI-ARIA)

| Orientation / Level | Role | Notes |
|---|---|---|
| Root – Horizontal | `menubar` | Top-level horizontal menu |
| Root – Vertical | `menu` | Top-level vertical menu |
| Submenu popup | `menu` | |
| Menu item | `menuitem` | |
| Separator | `separator` | |
| Item with submenu | `menuitem` + `aria-haspopup="menu"` + `aria-expanded` | |

The component must **not** use `listbox`, `tree`, or `toolbar` roles for the core Menu pattern.

---

## 4. Rendering rules

- Both declarative `SfMenuItem` children and data-bound items are supported.
- When both are present, declarative children are rendered first, followed by data-bound items (deterministic order).
- Every item must have a stable identity for `@key` and focus management.
- Separators are non-interactive and exposed with `role="separator"`.
- Disabled items are not activatable and receive `aria-disabled="true"`.
- Empty menus render no items (no built-in empty state required in v1).

---

## 5. Orientation

- `Orientation.Horizontal` (default) → root uses `role="menubar"`.
- `Orientation.Vertical` → root uses `role="menu"`.
- Orientation affects layout direction and keyboard arrow key mapping.

---

## 6. Open / Close behavior

| Trigger | Behavior |
|---|---|
| Click (default) | Opens on pointer click / tap |
| Hover | Opens on pointer enter (desktop); click still works for touch |
| Programmatic | `OpenAsync`, `CloseAsync` methods |
| Item selection | Closes the menu hierarchy by default (configurable later if needed) |
| Escape | Closes the current submenu or the whole menu |
| Outside click / focus loss | Closes the menu |

Submenus open on the same trigger as the root (Click or Hover) unless overridden by future settings.

---

## 7. Keyboard interaction (WAI-ARIA Menu / Menubar)

### Horizontal Menubar (root)

| Key | Action |
|---|---|
| Right / Left Arrow | Move focus between top-level items |
| Down Arrow | Open submenu (if any) and focus first item |
| Up Arrow | Open submenu and focus last item |
| Enter / Space | Activate item or open submenu |
| Home / End | First / last top-level item |
| Escape | Close menu |
| Printable character | Type-ahead navigation |

### Vertical Menu / Submenu

| Key | Action |
|---|---|
| Down / Up Arrow | Move focus between items |
| Right Arrow | Open submenu (if any) |
| Left Arrow | Close current submenu and return focus to parent |
| Enter / Space | Activate item or toggle submenu |
| Home / End | First / last item |
| Escape | Close submenu / menu |
| Printable character | Type-ahead |

RTL reverses Left/Right arrow behavior.

---

## 8. Focus management

- When a menu opens, focus moves into the menu.
- Roving `tabindex` is the preferred model for menuitem focus (finalize during implementation review).
- On close, focus returns to the invoking element.
- Disabled items are skipped during keyboard navigation.
- Focus must remain visible in default, dark, and Forced Colors modes.

---

## 9. Popup positioning

- Submenus are positioned adjacent to their parent item.
- Basic collision detection (flip / fit) is required.
- Prefer reuse of existing Toolkit popup / overlay infrastructure.
- Animations must respect `prefers-reduced-motion`.

---

## 10. Data binding

- Support both:
  - Hierarchical collections (items contain child collections)
  - Flat collections using ParentId-style mapping
- Field mapping (Text, Icon, Disabled, Children / ParentId, etc.) is defined in `API.md`.
- Selectors (typed) take precedence over field-name strings when both are provided.

---

## 11. Templates

- Item template must receive a clear context (the item + any useful state).
- Templates must not break CSS isolation or accessibility roles.

---

## 12. RTL, Theming, and Platform

- RTL is driven by an ancestor `dir="rtl"` (no `EnableRtl` parameter).
- Component must work with `SfThemeRoot` tokens.
- Forced Colors / High Contrast: focus, selection, and disabled states must remain visible without color-only encoding.
- CSS isolation is mandatory.

---

## 13. SSR and interactivity

- Static SSR: render the closed menu structure correctly (visual only).
- Interactive modes: full open/close, keyboard, and popup behavior.
- No hydration mismatch on roles or IDs.

---

## 14. Disposal

`DisposeAsync` must be idempotent. It must clean up any event registrations, popup references, and focus state.

---

## 15. Accessibility expectations

Document and later evidence:

- Correct roles and properties
- Keyboard navigation per section 7
- Screen reader announcements (menu open, item focus, disabled, expanded states)
- NVDA, Narrator, and JAWS validation strategy
- Forced Colors visibility

---

## 16. Definition of done

Implementation is complete only when:

- All in-scope behavior from this specification is implemented
- Public API matches `API.md` and is fully XML-documented
- Zero build / analyzer / CS1591 / trim warnings
- TEST-MATRIX tests pass
- Accessibility and visual evidence collected
- No release-blocking defects

---

## 17. Open points (to finalize during implementation)

1. Exact focus model (roving tabindex vs other) — prefer roving tabindex.
2. Degree of collision detection sophistication in v1.
3. Final decision on generic `SfMenu<TItem>` vs non-generic + context approach.
4. Whether a minimal `SfMenuItem` declarative component is required in v1.

These points must not block the rest of the specification.