# SfMenu – Test Matrix

## Syncfusion Blazor Toolkit

**Version:** 1.0  
**Status:** Proposed  
**Authority:** This file maps test coverage to the behaviors defined in `Spec.md` and the user stories in `PRD.md`. It must not require any non-goal.  
**Related:** PRD.md, Spec.md, API.md, TRACEABILITY.md, Evidence.md

---

## 1. Test Layers

| Layer | Tooling                  | Purpose |
|-------|--------------------------|---------|
| L1    | xUnit + bUnit            | Unit-level behavior, rendering, keyboard simulation, events, templates |
| L2    | bUnit                    | Parameter interaction, data-binding, focus, state transitions |
| L3    | Playwright               | End-to-end interaction, nested menus, orientation, RTL, real browser behavior |
| L4    | Playwright + axe-core    | Accessibility automated checks |
| L5    | Playwright screenshots   | Visual regression |
| L6    | `dotnet build` + analyzers | Build quality, nullable, CS1591, trim/AOT safety |

---

## 2. Accessibility Routes (L4) – Exactly 10

These routes are mandatory for axe testing:

| Route                        | Purpose |
|------------------------------|---------|
| `/menu/static`               | Closed horizontal menu |
| `/menu/open`                 | Open top-level menu |
| `/menu/nested`               | Open nested submenus |
| `/menu/disabled`             | Disabled items present |
| `/menu/rtl`                  | Right-to-left layout |
| `/menu/vertical`             | Vertical orientation |
| `/menu/templates`            | Item templates in use |
| `/menu/icons-separators`     | Icons + separators |
| `/menu/keyboard`             | Keyboard interaction page |
| `/menu/high-contrast`        | Forced Colors / high contrast |

**Target:** 0 axe critical and 0 axe serious violations on all 10 routes.

---

## 3. Test ID Conventions

| Prefix     | Meaning                     |
|------------|-----------------------------|
| `U-MN-`    | Unit / bUnit tests          |
| `P-MN-`    | Playwright interaction tests |
| `P-AXE-MN-`| Playwright + axe tests      |
| `V-MN-`    | Visual / screenshot tests   |
| `B-MN-`    | Build / analyzer tests      |

---

## 4. Core Test Matrix

### 4.1 Rendering & Structure (L1)

| ID         | Description                                      | Layer | Priority |
|------------|--------------------------------------------------|-------|----------|
| U-MN-001   | Root renders with `role="menubar"` when Horizontal | L1  | P0 |
| U-MN-002   | Root renders with `role="menu"` when Vertical     | L1  | P0 |
| U-MN-003   | Menu items render with `role="menuitem"`          | L1  | P0 |
| U-MN-004   | Separator renders with `role="separator"`         | L1  | P0 |
| U-MN-005   | Disabled item has `aria-disabled="true"`          | L1  | P0 |
| U-MN-006   | Item with children has `aria-haspopup="menu"`     | L1  | P0 |
| U-MN-007   | Open submenu sets `aria-expanded="true"`          | L1  | P0 |

### 4.2 Open / Close Behavior (L1 + L3)

| ID         | Description                                      | Layer | Priority |
|------------|--------------------------------------------------|-------|----------|
| U-MN-010   | Opens on click when `OpenOn=Click`                | L1  | P0 |
| U-MN-011   | Opens on hover when `OpenOn=Hover`                | L1  | P0 |
| U-MN-012   | Closes on Escape                                  | L1  | P0 |
| U-MN-013   | Closes on outside click                           | L1  | P0 |
| U-MN-014   | `OpenAsync()` opens the menu                      | L1  | P0 |
| U-MN-015   | `CloseAsync()` closes all levels                  | L1  | P0 |
| P-MN-010   | Nested submenu opens and closes correctly         | L3  | P0 |

### 4.3 Keyboard Navigation (L1 + L3)

| ID         | Description                                      | Layer | Priority |
|------------|--------------------------------------------------|-------|----------|
| U-MN-020   | Right/Left arrows move between top-level items (Horizontal) | L1 | P0 |
| U-MN-021   | Down arrow opens submenu and focuses first item  | L1  | P0 |
| U-MN-022   | Up/Down arrows move within vertical menu/submenu | L1  | P0 |
| U-MN-023   | Home / End move to first / last item              | L1  | P0 |
| U-MN-024   | Enter / Space activates item or opens submenu     | L1  | P0 |
| U-MN-025   | Escape closes current submenu or whole menu       | L1  | P0 |
| U-MN-026   | Type-ahead moves focus to matching item           | L1  | P1 |
| P-MN-020   | Full keyboard navigation in real browser          | L3  | P0 |

### 4.4 Data Binding & Templates (L1)

| ID         | Description                                      | Layer | Priority |
|------------|--------------------------------------------------|-------|----------|
| U-MN-030   | Renders items from `DataSource`                   | L1  | P0 |
| U-MN-031   | `TextSelector` takes precedence over `TextField`  | L1  | P0 |
| U-MN-032   | Hierarchical children render as submenus          | L1  | P0 |
| U-MN-033   | Flat data with ParentId builds correct hierarchy  | L1  | P1 |
| U-MN-034   | `ItemTemplate` is used when provided              | L1  | P0 |
| U-MN-035   | Declarative `SfMenuItem` children render          | L1  | P0 |

### 4.5 Disabled & Separator (L1)

| ID         | Description                                      | Layer | Priority |
|------------|--------------------------------------------------|-------|----------|
| U-MN-040   | Disabled item cannot be activated                 | L1  | P0 |
| U-MN-041   | Disabled item is skipped in keyboard navigation   | L1  | P0 |
| U-MN-042   | Separator is not focusable or activatable         | L1  | P0 |

### 4.6 Events (L1)

| ID         | Description                                      | Layer | Priority |
|------------|--------------------------------------------------|-------|----------|
| U-MN-050   | `OnItemSelected` fires on activation              | L1  | P0 |
| U-MN-051   | `OnOpen` / `OnOpened` fire in correct order       | L1  | P0 |
| U-MN-052   | `OnClose` / `OnClosed` fire in correct order      | L1  | P0 |
| U-MN-053   | `OnOpen` can be cancelled                         | L1  | P1 |
| U-MN-054   | `OnClose` can be cancelled                        | L1  | P1 |

### 4.7 RTL & Orientation (L3)

| ID         | Description                                      | Layer | Priority |
|------------|--------------------------------------------------|-------|----------|
| P-MN-030   | Vertical orientation renders correctly            | L3  | P0 |
| P-MN-031   | RTL reverses horizontal arrow key behavior        | L3  | P0 |
| P-MN-032   | RTL layout is visually mirrored                   | L3  | P1 |

### 4.8 Accessibility (L4)

| ID             | Description                                      | Layer | Priority |
|----------------|--------------------------------------------------|-------|----------|
| P-AXE-MN-001   | `/menu/static` – 0 critical/serious              | L4  | P0 |
| P-AXE-MN-002   | `/menu/open` – 0 critical/serious                | L4  | P0 |
| P-AXE-MN-003   | `/menu/nested` – 0 critical/serious              | L4  | P0 |
| P-AXE-MN-004   | `/menu/disabled` – 0 critical/serious            | L4  | P0 |
| P-AXE-MN-005   | `/menu/rtl` – 0 critical/serious                 | L4  | P0 |
| P-AXE-MN-006   | `/menu/vertical` – 0 critical/serious            | L4  | P0 |
| P-AXE-MN-007   | `/menu/templates` – 0 critical/serious           | L4  | P0 |
| P-AXE-MN-008   | `/menu/icons-separators` – 0 critical/serious    | L4  | P0 |
| P-AXE-MN-009   | `/menu/keyboard` – 0 critical/serious            | L4  | P0 |
| P-AXE-MN-010   | `/menu/high-contrast` – 0 critical/serious       | L4  | P0 |

### 4.9 Visual Regression (L5)

| ID         | Description                                      | Layer | Priority |
|------------|--------------------------------------------------|-------|----------|
| V-MN-001   | Closed horizontal menu                           | L5  | P1 |
| V-MN-002   | Open horizontal menu                             | L5  | P1 |
| V-MN-003   | Nested submenus                                  | L5  | P1 |
| V-MN-004   | Vertical menu                                    | L5  | P1 |
| V-MN-005   | RTL menu                                         | L5  | P1 |
| V-MN-006   | Disabled + separator states                      | L5  | P1 |
| V-MN-007   | High contrast mode                               | L5  | P1 |

### 4.10 Build Quality (L6)

| ID         | Description                                      | Layer | Priority |
|------------|--------------------------------------------------|-------|----------|
| B-MN-001   | Solution builds with 0 warnings (net8/net9/net10)| L6 | P0 |
| B-MN-002   | 0 CS1591 (missing XML comments)                  | L6  | P0 |
| B-MN-003   | Nullable reference types clean                   | L6  | P0 |
| B-MN-004   | Trim / AOT analysis clean                        | L6  | P0 |

---

## 5. Definition of Done (Testing)

The Menu component testing is considered complete when:

- All **P0** tests pass
- All 10 axe routes report 0 critical and 0 serious issues
- Visual screenshots are captured and reviewed
- Build is warning-free across supported TFMs
- No open P0 or P1 defects related to the tested behaviors

---

## 6. Notes

- Test IDs listed above form the minimum viable matrix. Additional tests may be added during implementation.
- Tests must use the stable `data-testid` values defined in `API.md`.
- Non-goals from `PRD.md` (ContextMenu, mega-menu, checkable items, virtualization, etc.) must not appear as required tests.

---