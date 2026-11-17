# SfMenu – Test Matrix

## Syncfusion Blazor Toolkit

**Version:** 1.1  
**Status:** Expanded  
**Authority:** This file maps test coverage to the behaviors defined in `Spec.md` and the user stories in `PRD.md`. It must not require any non-goal.  
**Related:** PRD.md, Spec.md, API.md, TRACEABILITY.md, Evidence.md

---

## 1. Test Layers

| Layer | Tooling                  | Purpose                                      |
|-------|--------------------------|----------------------------------------------|
| L1    | xUnit + bUnit            | Unit-level behavior, rendering, keyboard simulation, events, templates |
| L2    | bUnit                    | Parameter interaction, data-binding, focus, state transitions |
| L3    | Playwright               | End-to-end interaction, nested menus, orientation, RTL, real browser behavior |
| L4    | Playwright + axe-core    | Accessibility automated checks               |
| L5    | Playwright screenshots   | Visual regression                            |
| L6    | dotnet build + analyzers | Build quality, nullable, CS1591, trim/AOT safety |

---

## 2. Accessibility Routes (L4)

| Route                    | Purpose                              |
|--------------------------|--------------------------------------|
| /menu/static             | Closed horizontal menu               |
| /menu/open               | Open top-level menu                  |
| /menu/nested             | Open nested submenus                 |
| /menu/disabled           | Disabled items present               |
| /menu/rtl                | Right-to-left layout                 |
| /menu/vertical           | Vertical orientation                 |
| /menu/templates          | Item templates in use                |
| /menu/icons-separators   | Icons + separators                   |
| /menu/keyboard           | Keyboard interaction page            |
| /menu/high-contrast      | Forced Colors / high contrast        |
| /menu/deep-nested        | 4+ level nesting                     |
| /menu/mixed              | Declarative + DataSource mixed       |
| /menu/hover              | OpenOn=Hover behavior                |
| /menu/programmatic       | OpenAsync / CloseAsync / FocusAsync  |

**Target:** 0 axe critical and 0 axe serious violations on all routes.

---

## 3. Test ID Conventions

| Prefix       | Meaning                          |
|--------------|----------------------------------|
| U-MN-        | Unit / bUnit tests               |
| P-MN-        | Playwright interaction tests     |
| P-AXE-MN-    | Playwright + axe tests           |
| V-MN-        | Visual / screenshot tests        |
| B-MN-        | Build / analyzer tests           |

---

## 4. Core Test Matrix

### 4.1 Rendering & Structure (L1)

| ID       | Description                                              | Layer | Priority |
|----------|----------------------------------------------------------|-------|----------|
| U-MN-001 | Root renders with role="menubar" when Horizontal         | L1    | P0       |
| U-MN-002 | Root renders with role="menu" when Vertical              | L1    | P0       |
| U-MN-003 | Menu items render with role="menuitem"                   | L1    | P0       |
| U-MN-004 | Separator renders with role="separator"                  | L1    | P0       |
| U-MN-005 | Disabled item has aria-disabled="true"                   | L1    | P0       |
| U-MN-006 | Item with children has aria-haspopup="menu"              | L1    | P0       |
| U-MN-007 | Open submenu sets aria-expanded="true"                   | L1    | P0       |
| U-MN-008 | Empty menu renders no items                              | L1    | P1       |
| U-MN-009 | Entire menu Disabled=true disables all interaction       | L1    | P0       |
| U-MN-010 | Correct CSS classes applied (sf-menu, orientation, open, focused, disabled, separator) | L1 | P0 |
| U-MN-011 | Stable data-testid attributes are present                | L1    | P0       |
| U-MN-012 | AdditionalAttributes are splatted correctly              | L1    | P1       |

### 4.2 Open / Close Behavior (L1 + L3)

| ID       | Description                                              | Layer | Priority |
|----------|----------------------------------------------------------|-------|----------|
| U-MN-020 | Opens on click when OpenOn=Click                         | L1    | P0       |
| U-MN-021 | Opens on hover when OpenOn=Hover                         | L1    | P0       |
| U-MN-022 | Closes on Escape                                         | L1    | P0       |
| U-MN-023 | Closes on outside click / focus loss                     | L1    | P0       |
| U-MN-024 | OpenAsync() opens the menu                               | L1    | P0       |
| U-MN-025 | CloseAsync() closes all levels                           | L1    | P0       |
| U-MN-026 | Selecting leaf item closes the hierarchy (default)       | L1    | P0       |
| U-MN-027 | Nested submenu open/close works correctly                | L1    | P0       |
| U-MN-028 | Multiple open/close cycles are stable                    | L1    | P1       |
| P-MN-001 | Nested multi-level open and close in real browser        | L3    | P0       |
| P-MN-002 | Hover open works on desktop                              | L3    | P0       |
| P-MN-003 | Click still works when OpenOn=Hover (touch fallback)     | L3    | P0       |
| P-MN-004 | Outside click closes nested menus correctly              | L3    | P0       |
| P-MN-005 | Escape closes only the current submenu level             | L3    | P0       |
| P-MN-006 | Programmatic OpenAsync + CloseAsync in real browser      | L3    | P0       |
| P-MN-007 | Rapid open/close does not leave ghost popups             | L3    | P1       |
| P-MN-008 | Menu stays open when interacting inside submenu          | L3    | P0       |

### 4.3 Keyboard Navigation (L1 + L3)

| ID       | Description                                              | Layer | Priority |
|----------|----------------------------------------------------------|-------|----------|
| U-MN-030 | Right/Left arrows move between top-level items (Horizontal) | L1 | P0    |
| U-MN-031 | Down arrow opens submenu and focuses first item          | L1    | P0       |
| U-MN-032 | Up arrow opens submenu and focuses last item             | L1    | P1       |
| U-MN-033 | Up/Down arrows move within vertical menu/submenu         | L1    | P0       |
| U-MN-034 | Right arrow opens submenu (Vertical orientation)         | L1    | P0       |
| U-MN-035 | Left arrow closes submenu and returns focus to parent    | L1    | P0       |
| U-MN-036 | Home / End move to first / last item                     | L1    | P0       |
| U-MN-037 | Enter / Space activates item or opens submenu            | L1    | P0       |
| U-MN-038 | Escape closes current submenu or whole menu              | L1    | P0       |
| U-MN-039 | Type-ahead navigation works                              | L1    | P0       |
| U-MN-040 | Disabled items are skipped during keyboard navigation    | L1    | P0       |
| U-MN-041 | RTL reverses Left/Right arrow behavior                   | L1    | P0       |
| U-MN-042 | Roving tabindex is applied correctly                     | L1    | P0       |
| P-MN-010 | Full keyboard navigation – Horizontal menubar            | L3    | P0       |
| P-MN-011 | Full keyboard navigation – Vertical menu                 | L3    | P0       |
| P-MN-012 | Type-ahead works across nested levels                    | L3    | P0       |
| P-MN-013 | Focus returns to the triggering element on close         | L3    | P0       |
| P-MN-014 | Keyboard navigation works after programmatic open        | L3    | P0       |
| P-MN-015 | Keyboard + mouse mixed interaction is stable             | L3    | P1       |
| P-MN-016 | Home/End + Type-ahead combination works correctly        | L3    | P1       |

### 4.4 Data Binding & Templates (L1)

| ID       | Description                                              | Layer | Priority |
|----------|----------------------------------------------------------|-------|----------|
| U-MN-050 | Renders items from DataSource                            | L1    | P0       |
| U-MN-051 | Hierarchical children render as submenus                 | L1    | P0       |
| U-MN-052 | Flat data with ParentId builds correct hierarchy         | L1    | P0       |
| U-MN-053 | TextSelector takes precedence over TextField             | L1    | P0       |
| U-MN-054 | IconSelector / DisabledSelector take precedence          | L1    | P0       |
| U-MN-055 | ChildrenSelector takes precedence                        | L1    | P0       |
| U-MN-056 | ItemTemplate is rendered when provided                   | L1    | P0       |
| U-MN-057 | Declarative SfMenuItem children render                   | L1    | P0       |
| U-MN-058 | Mixed declarative + DataSource (declarative first)       | L1    | P0       |
| U-MN-059 | Deep nesting (4+ levels) works                           | L1    | P1       |
| U-MN-060 | RefreshAsync() updates from new DataSource               | L1    | P1       |
| U-MN-061 | Null / empty DataSource is handled gracefully            | L1    | P0       |
| U-MN-062 | Changing DataSource at runtime updates the menu          | L1    | P1       |

### 4.5 Disabled, Separator, Icons & Navigation

| ID       | Description                                              | Layer | Priority |
|----------|----------------------------------------------------------|-------|----------|
| U-MN-070 | Disabled item cannot be activated                        | L1    | P0       |
| U-MN-071 | Separator is not focusable or activatable                | L1    | P0       |
| U-MN-072 | Icons render correctly via IconCss / IconField           | L1    | P0       |
| U-MN-073 | Url + Target navigation works on item activation         | L1    | P0       |
| U-MN-074 | Separator + Disabled combination renders correctly       | L1    | P1       |
| U-MN-075 | Disabled parent prevents opening its submenu             | L1    | P0       |

### 4.6 Events (L1)

| ID       | Description                                              | Layer | Priority |
|----------|----------------------------------------------------------|-------|----------|
| U-MN-080 | OnItemSelected fires on activation                       | L1    | P0       |
| U-MN-081 | OnOpen / OnOpened fire in correct order                  | L1    | P0       |
| U-MN-082 | OnClose / OnClosed fire in correct order                 | L1    | P0       |
| U-MN-083 | OnOpen can be cancelled                                  | L1    | P0       |
| U-MN-084 | OnClose can be cancelled                                 | L1    | P0       |
| U-MN-085 | Events receive correct item / context data               | L1    | P0       |
| U-MN-086 | Cancelling OnOpen prevents submenu from appearing        | L1    | P0       |

### 4.7 Orientation, RTL, Focus & Positioning (L3 heavy)

| ID       | Description                                              | Layer | Priority |
|----------|----------------------------------------------------------|-------|----------|
| P-MN-020 | Vertical orientation renders and behaves correctly       | L3    | P0       |
| P-MN-021 | RTL layout is visually mirrored                          | L3    | P0       |
| P-MN-022 | RTL reverses horizontal arrow key behavior               | L3    | P0       |
| P-MN-023 | Basic collision detection / flip works near viewport edges | L3  | P0       |
| P-MN-024 | Focus management (enter + return) works correctly        | L3    | P0       |
| P-MN-025 | FocusAsync() moves focus into the menu                   | L3    | P0       |
| P-MN-026 | Submenu positioning is correct relative to parent item   | L3    | P0       |
| P-MN-027 | Deep nested submenus position correctly                  | L3    | P1       |
| P-MN-028 | Menu works correctly inside a scrollable container       | L3    | P1       |
| P-MN-029 | Window resize while menu is open repositions correctly   | L3    | P1       |

### 4.8 Real-world & Edge Scenarios (Playwright)

| ID       | Description                                              | Layer | Priority |
|----------|----------------------------------------------------------|-------|----------|
| P-MN-030 | Large menu (50+ items) remains interactive               | L3    | P1       |
| P-MN-031 | Very deep nesting (6 levels) works without performance issues | L3 | P1    |
| P-MN-032 | Mixed mouse + keyboard interaction is stable             | L3    | P0       |
| P-MN-033 | Menu works correctly after Blazor circuit reconnect      | L3    | P1       |
| P-MN-034 | Multiple SfMenu instances on the same page do not interfere | L3 | P0     |
| P-MN-035 | Menu inside a Dialog / Popup works correctly             | L3    | P1       |
| P-MN-036 | Touch / long-press behavior on mobile viewports          | L3    | P1       |
| P-MN-037 | prefers-reduced-motion is respected for animations       | L3    | P1       |

### 4.9 Accessibility (L4)

| ID            | Description                                      | Layer | Priority |
|---------------|--------------------------------------------------|-------|----------|
| P-AXE-MN-001  | /menu/static – 0 critical/serious                | L4    | P0       |
| P-AXE-MN-002  | /menu/open – 0 critical/serious                  | L4    | P0       |
| P-AXE-MN-003  | /menu/nested – 0 critical/serious                | L4    | P0       |
| P-AXE-MN-004  | /menu/disabled – 0 critical/serious              | L4    | P0       |
| P-AXE-MN-005  | /menu/rtl – 0 critical/serious                   | L4    | P0       |
| P-AXE-MN-006  | /menu/vertical – 0 critical/serious              | L4    | P0       |
| P-AXE-MN-007  | /menu/templates – 0 critical/serious             | L4    | P0       |
| P-AXE-MN-008  | /menu/icons-separators – 0 critical/serious      | L4    | P0       |
| P-AXE-MN-009  | /menu/keyboard – 0 critical/serious              | L4    | P0       |
| P-AXE-MN-010  | /menu/high-contrast – 0 critical/serious         | L4    | P0       |
| P-AXE-MN-011  | /menu/deep-nested – 0 critical/serious           | L4    | P1       |
| P-AXE-MN-012  | /menu/mixed – 0 critical/serious                 | L4    | P1       |
| P-AXE-MN-013  | /menu/hover – 0 critical/serious                 | L4    | P1       |
| P-AXE-MN-014  | /menu/programmatic – 0 critical/serious          | L4    | P1       |

### 4.10 Visual Regression (L5)

| ID      | Description                        | Layer | Priority |
|---------|------------------------------------|-------|----------|
| V-MN-001| Closed horizontal menu             | L5    | P1       |
| V-MN-002| Open horizontal menu               | L5    | P1       |
| V-MN-003| Nested submenus                    | L5    | P1       |
| V-MN-004| Vertical menu                      | L5    | P1       |
| V-MN-005| RTL menu                           | L5    | P1       |
| V-MN-006| Disabled + separator states        | L5    | P1       |
| V-MN-007| High contrast mode                 | L5    | P1       |
| V-MN-008| Hover state                        | L5    | P1       |
| V-MN-009| Deep nested open state             | L5    | P1       |

### 4.11 Build Quality (L6)

| ID      | Description                                      | Layer | Priority |
|---------|--------------------------------------------------|-------|----------|
| B-MN-001| Solution builds with 0 warnings (net8/net9/net10)| L6    | P0       |
| B-MN-002| 0 CS1591 (missing XML comments)                  | L6    | P0       |
| B-MN-003| Nullable reference types clean                   | L6    | P0       |
| B-MN-004| Trim / AOT analysis clean                        | L6    | P0       |

---

## 5. Final Counts

| Category                        | Count |
|--------------------------------|-------|
| **bUnit tests (U-MN-*)**       | **75** |
| **Playwright interaction (P-MN-*)** | **37** |
| **Accessibility (P-AXE-MN-*)** | **14** |
| Visual regression (V-MN-*)     | 9     |
| Build quality (B-MN-*)         | 4     |

**Total tests in matrix: 139**

---

## 6. Definition of Done (Testing)

The Menu component testing is considered complete when:

- All **P0** tests pass
- All accessibility routes report 0 critical and 0 serious issues
- Visual screenshots are captured and reviewed
- Build is warning-free across supported TFMs
- No open P0 or P1 defects related to the tested behaviors

---

## 7. Notes

- This is now a comprehensive matrix covering virtually all scenarios defined in the current specs.
- Additional tests may still be added during implementation if new edge cases are discovered.
- Tests must use the stable `data-testid` values defined in `API.md`.
- Non-goals from `PRD.md` (ContextMenu, mega-menu, checkable items, virtualization, etc.) must not appear as required tests.