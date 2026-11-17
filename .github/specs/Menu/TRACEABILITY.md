# Menu Traceability

## Syncfusion Blazor Toolkit

**Version:** 1.0  
**Status:** Mapping only. Not evidence and not a requirement source.  
**Authority:**  
- `PRD.md` owns product scope  
- `API.md` owns public members  
- `Spec.md` owns behavior  
- `TEST-MATRIX.md` owns test IDs  

This file only maps stories → contract → tests. It must not add public members or introduce non-goals.

---

## 1. Header

| Field        | Value |
|--------------|-------|
| Component    | SfMenu |
| Stories      | Defined in `PRD.md` |
| Tests        | IDs defined only in `TEST-MATRIX.md` |
| Spec Version | 1.0 |

---

## 2. In-Scope Traceability Map

| Story ID | Story / Behavior                              | Contract (Spec / API)                              | Tests |
|----------|-----------------------------------------------|----------------------------------------------------|-------|
| US-01    | Horizontal menubar                            | `Orientation=Horizontal` → `role="menubar"`        | U-MN-001, P-AXE-MN-001 |
| US-02    | Vertical menu                                 | `Orientation=Vertical` → `role="menu"`             | U-MN-002, P-MN-030, P-AXE-MN-006 |
| US-03    | Nested / hierarchical submenus                | `aria-haspopup="menu"`, `aria-expanded`            | U-MN-006, U-MN-007, P-MN-010, P-AXE-MN-003 |
| US-04    | Open on Click                                 | `OpenOn=Click`                                     | U-MN-010 |
| US-05    | Open on Hover                                 | `OpenOn=Hover`                                     | U-MN-011 |
| US-06    | Programmatic open / close                     | `OpenAsync()`, `CloseAsync()`                      | U-MN-014, U-MN-015 |
| US-07    | Keyboard navigation (arrows, Home/End, Enter/Space, Escape) | Spec.md keyboard section                   | U-MN-020 to U-MN-025, P-MN-020, P-AXE-MN-009 |
| US-08    | Type-ahead navigation                         | Character key navigation                           | U-MN-026 |
| US-09    | Disabled items                                | Not activatable, `aria-disabled="true"`            | U-MN-005, U-MN-040, U-MN-041, P-AXE-MN-004 |
| US-10    | Separators                                    | `role="separator"`                                 | U-MN-004, U-MN-042, P-AXE-MN-008 |
| US-11    | Icons                                         | Icon support via field / selector / parameter      | P-AXE-MN-008, V-MN-006 |
| US-12    | Item templates                                | `ItemTemplate`                                     | U-MN-034, P-AXE-MN-007 |
| US-13    | Declarative items                             | `SfMenuItem` children                              | U-MN-035 |
| US-14    | Data binding – hierarchical                   | `DataSource` + Children                             | U-MN-030, U-MN-032 |
| US-15    | Data binding – flat (ParentId)                | `IdField` + `ParentIdField`                        | U-MN-033 |
| US-16    | Selector precedence                           | `*Selector` wins over `*Field`                     | U-MN-031 |
| US-17    | Events (Selected, Open/Close)                 | `OnItemSelected`, `OnOpen`, `OnOpened`, `OnClose`, `OnClosed` | U-MN-050 to U-MN-054 |
| US-18    | RTL support                                   | Inherits from ancestor `dir="rtl"`                 | P-MN-031, P-MN-032, P-AXE-MN-005 |
| US-19    | Focus management                              | Focus moves into menu on open, returns on close    | U-MN-020+, P-MN-020 |
| US-20    | Accessibility (axe)                           | 10 mandatory routes clean                          | P-AXE-MN-001 to P-AXE-MN-010 |
| US-21    | Visual states                                 | Closed, open, nested, RTL, disabled, high contrast | V-MN-001 to V-MN-007 |
| US-22    | Build quality                                 | 0 warnings, 0 CS1591, trim/AOT clean               | B-MN-001 to B-MN-004 |

---

## 3. Proposed / Not Frozen Items

| Topic                        | Current Proposal                              | Finalization Point |
|-----------------------------|-----------------------------------------------|--------------------|
| Focus model                 | Roving `tabindex` preferred                   | Implementation review |
| Generic vs non-generic root | Both `SfMenu` and `SfMenu<TItem>` proposed    | Implementation review |
| Collision detection depth   | Basic flip/fit required in v1                 | Implementation review |
| Base class                  | Reuse existing Toolkit base patterns          | During implementation |

---

## 4. Explicitly Not Mapped (Out of v1)

| Topic                         | Reason |
|-------------------------------|--------|
| Full ContextMenu component    | PRD non-goal (planned as separate component) |
| Mega-menu layouts             | PRD non-goal / future enhancement |
| Checkable / multi-select items| Future enhancement |
| Built-in search / filtering   | PRD non-goal |
| Hamburger / adaptive collapse | Future enhancement |
| Virtualization                | PRD non-goal for v1 |
| Drag-and-drop reordering      | PRD non-goal |
| `EnableRtl` parameter         | RTL is inherited from `dir` (by design) |

---

## 5. Notes

- This file is a **mapping aid only**.  
- Passing tests listed here does not replace the need for Evidence.md runtime verification.  
- Any new public API must be added to `API.md` first; this file only reflects existing contracts.

---