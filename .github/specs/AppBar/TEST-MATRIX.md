# SfAppBar — Test Matrix & Automation Strategy

**Component:** SfAppBar  
**Namespace:** Syncfusion.Blazor.Toolkit  
**Version:** 1.0  
**Cross-refs:** PRD.md (G-11, R-AB-050–053), Spec.md, API.md, Evidence.md, sample-preparer.md  

**Automation philosophy:** No manual testing will ever occur as a release gate. Every acceptance criterion is CI-verifiable. Ship authority is green CI only.

---

## Table of Contents

1. [Automation Philosophy](#1-automation-philosophy)
2. [Coverage Targets](#2-coverage-targets)
3. [Test Layers](#3-test-layers)
4. [ID Conventions](#4-id-conventions)
5. [L1 Unit Tests (xUnit + bUnit)](#5-l1-unit-tests-xunit--bunit)
6. [L2 Integration Tests](#6-l2-integration-tests)
7. [L3 Playwright Functional Tests](#7-l3-playwright-functional-tests)
8. [L4 Axe Accessibility Routes](#8-l4-axe-accessibility-routes)
9. [L5 Visual Snapshot Tests](#9-l5-visual-snapshot-tests)
10. [L6 Build / Trim / AOT Validation](#10-l6-build--trim--aot-validation)
11. [Responsive Viewport Matrix](#11-responsive-viewport-matrix)
12. [Toolkit Primitive Validation](#12-toolkit-primitive-validation)
13. [Render Mode Matrix](#13-render-mode-matrix)
14. [Phase Separation](#14-phase-separation)
15. [CI Job Mapping](#15-ci-job-mapping)
16. [Failure Gates](#16-failure-gates)
17. [Non-Goals](#17-non-goals)
18. [Future Enhancement Tests](#18-future-enhancement-tests)
19. [Traceability Notes](#19-traceability-notes)

---

## 1. Automation Philosophy

| Rule | Normative |
|------|-----------|
| All public APIs MUST have automated tests | MUST |
| All accessibility requirements MUST have automated validation | MUST |
| All visual states in V-AB-* MUST have snapshot tests | MUST |
| Axe critical/serious MUST fail CI | MUST |
| Trim/AOT/CS1591/analyzer warnings MUST fail CI | MUST |
| Runtime console errors MUST fail Playwright jobs | MUST |
| Manual QA MUST NOT be a release gate | MUST NOT |
| data-testid hooks MUST be used for Playwright selectors | MUST |

---

## 2. Coverage Targets

| Area | Target | Verification |
|------|--------|--------------|
| Public APIs | 100% | API.md matrix ↔ U-AB/I-AB/P-AB |
| Parameters | 100% | One L1 test minimum per parameter |
| Events | 100% | Callback invoked asserts |
| Methods | 100% | FocusAsync / RefreshAsync / MeasureAsync |
| Templates | 100% | Each RenderFragment renders marker content |
| Enums | 100% | Value stability + CSS mapping |
| Accessibility S-AB-A11Y-* | 100% | Unit ARIA + axe + keyboard |
| Visual states V-AB-001–020 | 100% | Playwright snapshots |
| Responsive widths | 100% | 320, 375, 768, 1024, 1440 |
| Toolkit primitive reuse | 100% | U-AB-200–203, I-AB-200–201 |

---

## 3. Test Layers

| Layer | Tool | Prefix | Runs on |
|-------|------|--------|---------|
| L1 | xUnit + bUnit | U-AB | PR + main |
| L2 | bUnit integration | I-AB | PR + main |
| L3 | Playwright | P-AB | PR + main |
| L4 | Playwright + axe-core | P-AXE-AB | PR + main |
| L5 | Playwright screenshots | V-AB | main + release |
| L6 | `dotnet build` / publish analyzers | B-AB | PR + main |

---

## 4. ID Conventions

| Type | Prefix | Example |
|------|--------|---------|
| Unit | U-AB | U-AB-001 |
| Integration | I-AB | I-AB-010 |
| Playwright functional | P-AB | P-AB-020 |
| Axe | P-AXE-AB | P-AXE-AB-04 |
| Snapshot | V-AB | V-AB-008 |
| Build | B-AB | B-AB-003 |

---

## 5. L1 Unit Tests (xUnit + bUnit)

### 5.1 Root & layout

| ID | Name | Arrange | Assert | Phase | Spec | API |
|----|------|---------|--------|-------|------|-----|
| U-AB-001 | Renders_root_with_data_testid | Render `<SfAppBar />` | `data-testid="sf-appbar"` present | MVP | S-AB-TESTID-01 | API-AB-001 |
| U-AB-002 | Position_Top_renders_header | Position=Top | Root tag is `header` | MVP | S-AB-LAY-01 | API-AB-010 |
| U-AB-003 | Position_Bottom_renders_footer | Position=Bottom | Root tag is `footer` | MVP | S-AB-LAY-01 | API-AB-010 |
| U-AB-004 | Mode_Static_css | Mode=Static | Class contains `sf-appbar--static` | MVP | S-AB-LAY-02 | API-AB-011 |
| U-AB-005 | Mode_Fixed_css | Mode=Fixed | Class contains `sf-appbar--fixed` | MVP | S-AB-LAY-02 | API-AB-011 |
| U-AB-006 | Mode_Sticky_css | Mode=Sticky | Class contains `sf-appbar--sticky` | MVP | S-AB-LAY-02 | API-AB-011 |
| U-AB-007 | Density_Comfortable_css | Default density | `sf-appbar--comfortable` | MVP | S-AB-LAY-03 | API-AB-012 |
| U-AB-008 | Density_Compact_css | Density=Compact | `sf-appbar--compact` | MVP | S-AB-LAY-03 | API-AB-012 |
| U-AB-009 | Class_merges_user_class | Class="my-bar" | Root has `my-bar` and base class | MVP | S-AB-CSS-01 | API-AB-015 |
| U-AB-010 | Style_applied | Style="z-index:9" | style attribute contains value | MVP | S-AB-CSS-01 | API-AB-016 |
| U-AB-011 | Id_applied | Id="main-appbar" | id="main-appbar" | MVP | S-AB-TESTID-01 | API-AB-017 |
| U-AB-012 | Title_renders_text | Title="Dashboard" | Title region text = Dashboard | MVP | S-AB-REG-01 | API-AB-025 |
| U-AB-013 | Title_null_omits_or_empty | Title=null | No erroneous placeholder text | MVP | S-AB-REG-01 | API-AB-025 |
| U-AB-014 | Elevation_maps_class_or_token | Elevation=4 | Elevation modifier present | MVP | S-AB-CSS-03 | API-AB-026 |
| U-AB-015 | ShowBorder_true_adds_border_class | ShowBorder=true | Border class present | MVP | S-AB-CSS-02 | API-AB-027 |
| U-AB-016 | ShowBorder_false_no_border_class | ShowBorder=false | Border class absent | MVP | S-AB-CSS-02 | API-AB-027 |

### 5.2 Regions, items, spacer

| ID | Name | Arrange | Assert | Phase | Spec | API |
|----|------|---------|--------|-------|------|-----|
| U-AB-020 | ChildContent_renders | Child fragment with marker | Marker in DOM | MVP | S-AB-REG-01 | API-AB-018 |
| U-AB-021 | Item_renders_with_testid | SfAppBarItem Id="save" | `data-testid="sf-appbar-item-save"` | MVP | S-AB-TESTID-01 | API-AB-002 |
| U-AB-022 | Item_Visible_false_not_rendered | Visible=false | Item absent | MVP | S-AB-REG-01 | API-AB-002 |
| U-AB-023 | Item_Disabled_sets_state | Disabled=true | Disabled attribute or aria on control | MVP | S-AB-KBD-02 | API-AB-002 |
| U-AB-024 | Spacer_default_flex | SfAppBarSpacer | `data-testid="sf-appbar-spacer"` + flex class | MVP | S-AB-REG-03 | API-AB-003 |
| U-AB-025 | Spacer_fixed_width | Width="48px" | style/width 48px | MVP | S-AB-REG-03 | API-AB-003 |
| U-AB-026 | Actions_region_testid | Actions present | `data-testid="sf-appbar-actions"` | MVP | S-AB-TESTID-01 | API-AB-001 |
| U-AB-027 | Leading_branding_title_content_testids | Templates/MVP composition | All region testids when content provided | MVP | S-AB-TESTID-01 | API-AB-001 |

### 5.3 Accessibility attributes

| ID | Name | Arrange | Assert | Phase | Spec | API |
|----|------|---------|--------|-------|------|-----|
| U-AB-040 | Toolbar_role_on_actions | Actions with ≥1 control | role="toolbar" on actions container | MVP | S-AB-A11Y-01 | API-AB-014 |
| U-AB-041 | AriaLabel_applied | AriaLabel="Main actions" | aria-label matches | MVP | S-AB-A11Y-01 | API-AB-014 |
| U-AB-042 | Default_aria_label_when_null | AriaLabel=null | Non-empty accessible name strategy applied | MVP | S-AB-A11Y-01 | API-AB-014 |
| U-AB-043 | Empty_actions_no_toolbar_or_safe | No items | No invalid empty toolbar (per Spec edge case) | MVP | S-AB-A11Y-01 | API-AB-001 |

### 5.4 Overflow (Phase 2)

| ID | Name | Arrange | Assert | Phase | Spec | API |
|----|------|---------|--------|-------|------|-----|
| U-AB-050 | EnableOverflow_false_default | Default | EnableOverflow false | Phase 2 | S-AB-OVR-01 | API-AB-013 |
| U-AB-051 | EnableOverflow_true_flag | EnableOverflow=true | Parameter stored / context flag | Phase 2 | S-AB-OVR-01 | API-AB-013 |
| U-AB-052 | Item_Priority_default_zero | New item | Priority==0 | Phase 2 | S-AB-OVR-02 | API-AB-002 |
| U-AB-053 | Item_Priority_custom | Priority=10 | Priority==10 | Phase 2 | S-AB-OVR-02 | API-AB-002 |
| U-AB-054 | Overflow_host_testid | Overflow enabled + items | `sf-appbar-overflow` available after measure path | Phase 2 | S-AB-TESTID-01 | API-AB-004 |

### 5.5 Templates (Phase 2)

| ID | Name | Arrange | Assert | Phase | Spec | API |
|----|------|---------|--------|-------|------|-----|
| U-AB-060 | LeadingTemplate_renders | LeadingTemplate marker | Marker in leading region | Phase 2 | S-AB-RND-01 | API-AB-023 |
| U-AB-061 | BrandingTemplate_renders | BrandingTemplate marker | Marker in branding | Phase 2 | S-AB-RND-01 | API-AB-019 |
| U-AB-062 | TitleTemplate_overrides_Title | Title + TitleTemplate | Template content wins | Phase 2 | S-AB-RND-01 | API-AB-020 |
| U-AB-063 | ContentTemplate_renders | ContentTemplate marker | Marker in content | Phase 2 | S-AB-RND-01 | API-AB-021 |
| U-AB-064 | ActionsTemplate_renders | ActionsTemplate marker | Marker in actions | Phase 2 | S-AB-RND-01 | API-AB-022 |
| U-AB-065 | OverflowTemplate_renders | OverflowTemplate marker | Marker when overflow open path exercised | Phase 2 | S-AB-RND-01 | API-AB-024 |

### 5.6 Events

| ID | Name | Arrange | Assert | Phase | Spec | API |
|----|------|---------|--------|-------|------|-----|
| U-AB-070 | OnItemClick_invoked | Click item button via bUnit | Callback count=1; ItemId set | MVP | S-AB-CMD-01 | API-AB-032 |
| U-AB-071 | OnOverflowOpened_invoked | Open overflow (interactive mock) | Callback once | Phase 2 | S-AB-OVR-03 | API-AB-030 |
| U-AB-072 | OnOverflowClosed_invoked | Close overflow | Callback once | Phase 2 | S-AB-OVR-03 | API-AB-031 |

### 5.7 Methods

| ID | Name | Arrange | Assert | Phase | Spec | API |
|----|------|---------|--------|-------|------|-----|
| U-AB-080 | FocusAsync_focuses_first_enabled | 2 buttons, first enabled | Focus on first enabled | MVP | S-AB-KBD-01 | API-AB-040 |
| U-AB-081 | FocusAsync_skips_disabled | First disabled, second enabled | Focus on second | MVP | S-AB-KBD-02 | API-AB-040 |
| U-AB-082 | RefreshAsync_completes | Call RefreshAsync | Task completes; no throw | Phase 2 | S-AB-OVR-01 | API-AB-041 |
| U-AB-083 | MeasureAsync_completes_with_js_mock | Mock JS measure | Task completes; membership updated | Phase 2 | S-AB-OVR-01 | API-AB-042 |

### 5.8 Enums

| ID | Name | Assert | Phase | API |
|----|------|--------|-------|-----|
| U-AB-090 | AppBarPosition_values | Top=0, Bottom=1 stable | MVP | API-AB-050 |
| U-AB-091 | AppBarMode_values | Static, Fixed, Sticky stable | MVP | API-AB-051 |
| U-AB-092 | AppBarDensity_values | Comfortable, Compact stable | MVP | API-AB-052 |
| U-AB-093 | AppBarAlignment_values | Start, Center, End, SpaceBetween stable | MVP | API-AB-053 |

### 5.9 Defaults matrix

| ID | Parameter | Expected default |
|----|-----------|------------------|
| U-AB-100 | Position | Top |
| U-AB-101 | Mode | Static |
| U-AB-102 | Density | Comfortable |
| U-AB-103 | EnableOverflow | false |
| U-AB-104 | Elevation | 2 |
| U-AB-105 | ShowBorder | false |
| U-AB-106 | Title | null |
| U-AB-107 | AriaLabel | null |

### 5.10 Toolkit primitive reuse

| ID | Name | Assert | Phase | Spec |
|----|------|--------|-------|------|
| U-AB-200 | Sample_composition_uses_SfButton | Test fixture renders SfAppBar + SfButton child | MVP | S-AB-REUSE-01 |
| U-AB-201 | Icon_only_uses_SfButton_IconCss | Fixture uses SfButton IconCss, not raw button | MVP | S-AB-REUSE-01 |
| U-AB-202 | Overflow_does_not_require_SfMenu | Overflow panel uses Toolkit Dialog/panel API surface | Phase 2 | S-AB-REUSE-01 |
| U-AB-203 | Theme_classes_present_under_SfThemeRoot | Render under theme scope; token-driven class or CSS var present | MVP | S-AB-QL-04 |

### 5.11 Edge cases

| ID | Name | Assert | Phase |
|----|------|--------|-------|
| U-AB-210 | Long_title_still_renders | Extremely long Title does not throw | MVP |
| U-AB-211 | Fifty_items_render | 50 SfAppBarItem render without throw | MVP |
| U-AB-212 | SSR_overflow_true_no_throw | EnableOverflow=true without JS | Phase 2 |

**L1 count target:** ≥55 tests for full Phase 2 surface; ≥40 for MVP gate.

---

## 6. L2 Integration Tests

| ID | Name | Scenario | Assert | Phase | Spec |
|----|------|----------|--------|-------|------|
| I-AB-001 | Parameter_churn_Mode | Static→Fixed→Sticky | Classes update each time | MVP | S-AB-STATE-02 |
| I-AB-002 | Parameter_churn_Density | Comfortable→Compact | Class swap | MVP | S-AB-LAY-03 |
| I-AB-003 | Parameter_churn_Position | Top→Bottom | header→footer | MVP | S-AB-LAY-01 |
| I-AB-004 | Dynamic_items_add_remove | Add 3 items, remove 1 | DOM count tracks | MVP | S-AB-REG-04 |
| I-AB-005 | Cascading_AppBarContext | Child reads Density | Child sees parent Density | MVP | S-AB-REG-04 |
| I-AB-006 | Register_Unregister_lifecycle | Item dispose | Unregister called / no leak in context list | Phase 2 | S-AB-REG-04 |
| I-AB-007 | Theme_change_re_render | Toggle theme scope | AppBar still structured; classes consistent | MVP | S-AB-QL-04 |
| I-AB-008 | Title_and_TitleTemplate_conflict | Both set | Template wins per Spec | Phase 2 | S-AB-RND-01 |
| I-AB-009 | Multiple_spacers | Two spacers | Both present | MVP | S-AB-REG-03 |
| I-AB-010 | Resize_debounce_mock | Fire 10 resize events | ≤2 measure calls in window | Phase 2 | S-AB-PERF-01 |
| I-AB-200 | CSS_isolation_attribute | Render | Scoped attribute on root or descendants | MVP | S-AB-CSS-01 |
| I-AB-201 | Scoped_ids_stable_format | Two items with Ids | testids follow `sf-appbar-item-{id}` | MVP | S-AB-TESTID-01 |

---

## 7. L3 Playwright Functional Tests

Selectors MUST use `data-testid` exclusively for component hooks.

| ID | Name | Viewport | Steps | Assert | Phase | Sample |
|----|------|----------|-------|--------|-------|--------|
| P-AB-001 | Default_desktop_visible | 1440 | Open /appbar/default | `#sf-appbar` or testid visible | MVP | SMP-01 |
| P-AB-002 | Fixed_stays_in_viewport | 1440 | Scroll 2000px on fixed demo | AppBar still in viewport | MVP | SMP-05 |
| P-AB-003 | Sticky_sticks_on_scroll | 1440 | Scroll sticky demo | AppBar stuck at top | MVP | SMP-05 |
| P-AB-004 | Bottom_position | 1440 | Open bottom variant | footer appbar at bottom | MVP | SMP-05 |
| P-AB-010 | Action_click | 1440 | Click Save action | UI feedback / console hook / text change | MVP | SMP-01 |
| P-AB-011 | Keyboard_arrow_right | 1440 | Tab to toolbar, ArrowRight | Focus moves to next control | MVP | SMP-03/06 |
| P-AB-012 | Keyboard_arrow_left | 1440 | From 2nd control ArrowLeft | Focus previous | MVP | SMP-06 |
| P-AB-013 | Keyboard_home_end | 1440 | Home/End in toolbar | First/last control focused | MVP | SMP-06 |
| P-AB-014 | Tab_enters_and_leaves_toolbar | 1440 | Tab sequence | Single stop group behavior per Spec | MVP | SMP-06 |
| P-AB-020 | Overflow_opens | 375 | Open responsive demo, click overflow trigger | Overflow panel visible | Phase 2 | SMP-02 |
| P-AB-021 | Overflow_closes_escape | 375 | Open overflow, press Escape | Panel hidden; focus returns | Phase 2 | SMP-02 |
| P-AB-022 | Overflow_keyboard_activate | 375 | Keyboard open overflow item | Item activates | Phase 2 | SMP-02 |
| P-AB-030 | RTL_mirrors_layout | 1440 | Open RTL demo | dir=rtl; leading/actions mirrored | MVP | SMP-06 |
| P-AB-031 | Dark_theme_switch | 1440 | Toggle dark | No crash; appbar visible; contrast intact | MVP | SMP-06 |
| P-AB-040 | Mobile_375_layout | 375 | Open default/responsive | No horizontal page scroll from appbar | Phase 2 | SMP-02 |
| P-AB-041 | Tablet_768_layout | 768 | Open responsive | Layout valid; overflow policy applied | Phase 2 | SMP-02 |
| P-AB-042 | Touch_overflow_trigger | 375 | Tap overflow | Opens | Phase 2 | SMP-02 |
| P-AB-050 | Focus_visible_ring | 1440 | Keyboard focus action | Visible focus indicator | MVP | SMP-06 |
| P-AB-060 | Navigation_links | 1440 | Click nav sample controls | Navigation or handler fires | MVP | SMP-03 |
| P-AB-070 | Disabled_action_not_activated | 1440 | Click disabled | No activation side effect | MVP | SMP-06 |
| P-AB-080 | Console_zero_errors | all | Any demo load | No pageerror / console error | MVP | All |

---

## 8. L4 Axe Accessibility Routes

| ID | Route | Source demo | Phase | Must pass |
|----|-------|-------------|-------|-----------|
| P-AXE-AB-01 | /appbar/default | SMP-01 | MVP | 0 critical, 0 serious |
| P-AXE-AB-02 | /appbar/sticky | SMP-05 variant | MVP | 0 critical, 0 serious |
| P-AXE-AB-03 | /appbar/fixed | SMP-05 variant | MVP | 0 critical, 0 serious |
| P-AXE-AB-04 | /appbar/overflow | SMP-02 | Phase 2 | 0 critical, 0 serious |
| P-AXE-AB-05 | /appbar/responsive | SMP-02 | Phase 2 | 0 critical, 0 serious |
| P-AXE-AB-06 | /appbar/navigation | SMP-03 | MVP | 0 critical, 0 serious |
| P-AXE-AB-07 | /appbar/dense | SMP-06 variant | MVP | 0 critical, 0 serious |
| P-AXE-AB-08 | /appbar/rtl | SMP-06 variant | MVP | 0 critical, 0 serious |
| P-AXE-AB-09 | /appbar/templates | SMP-04 | Phase 2 | 0 critical, 0 serious |
| P-AXE-AB-10 | /appbar/high-contrast | SMP-06 variant | MVP | 0 critical, 0 serious |

Rules: WCAG 2.2 AA tags enabled in axe config. Moderate/minor MAY warn but MUST NOT block unless project policy elevates them.

---

## 9. L5 Visual Snapshot Tests

| ID | Scenario | Viewport | Theme | Phase | Notes |
|----|----------|----------|-------|-------|-------|
| V-AB-001 | Default | 1440 | Light | MVP | SMP-01 |
| V-AB-002 | Focused action | 1440 | Light | MVP | Keyboard focus |
| V-AB-003 | Fixed | 1440 | Light | MVP | SMP-05 |
| V-AB-004 | Sticky | 1440 | Light | MVP | SMP-05 |
| V-AB-005 | Desktop | 1440 | Light | MVP | Full actions |
| V-AB-006 | Tablet | 768 | Light | Phase 2 | |
| V-AB-007 | Mobile | 375 | Light | Phase 2 | |
| V-AB-008 | Overflow open | 375 | Light | Phase 2 | |
| V-AB-009 | Overflow closed | 375 | Light | Phase 2 | |
| V-AB-010 | Navigation | 1440 | Light | MVP | SMP-03 |
| V-AB-011 | Templates | 1440 | Light | Phase 2 | SMP-04 |
| V-AB-012 | RTL | 1440 | Light | MVP | |
| V-AB-013 | Dark theme | 1440 | Dark | MVP | |
| V-AB-014 | High contrast | 1440 | HC | MVP | |
| V-AB-015 | Forced colors | 1440 | Forced | MVP | emulated media |
| V-AB-016 | Disabled actions | 1440 | Light | MVP | |
| V-AB-017 | Long title | 1440 | Light | MVP | ellipsis |
| V-AB-018 | Maximum actions (50) | 1440 | Light | MVP | |
| V-AB-019 | Minimum actions (0–1) | 1440 | Light | MVP | |
| V-AB-020 | Toolkit primitive integration | 1440 | Light | MVP | SfButton visible |

Threshold: project-standard pixel diff; fonts locked in CI container.

---

## 10. L6 Build / Trim / AOT Validation

| ID | Check | Command / mechanism | Pass criteria |
|----|-------|---------------------|---------------|
| B-AB-001 | Build | `dotnet build -warnaserror` | Exit 0 |
| B-AB-002 | Nullable | Nullable context enable | 0 nullable warnings |
| B-AB-003 | CS1591 | Documentation file generate | 0 CS1591 |
| B-AB-004 | AOT | Publish AOT sample host referencing Toolkit | 0 AOT warnings |
| B-AB-005 | Trimming | Trim-mode publish / ILLink | 0 trim warnings |
| B-AB-006 | Analyzers | Toolkit analyzer pack | 0 analyzer warnings |
| B-AB-007 | Console errors | Playwright `pageonerror` + console | 0 errors on sample routes |

---

## 11. Responsive Viewport Matrix

| Width | Layout | Overflow | Focus | Navigation | Resizing |
|-------|--------|----------|-------|------------|----------|
| 320 | P-AB-040 variant | P-AB-020 | P-AB-050 | P-AB-060 | I-AB-010 |
| 375 | P-AB-040 | P-AB-020–022 | P-AB-050 | P-AB-060 | I-AB-010 |
| 768 | P-AB-041 | policy assert | P-AB-011 | P-AB-060 | I-AB-010 |
| 1024 | P-AB-001 | optional | P-AB-011 | P-AB-060 | I-AB-010 |
| 1440 | P-AB-001 | closed | P-AB-011 | P-AB-060 | I-AB-010 |

---

## 12. Toolkit Primitive Validation

| Requirement | Test IDs | Pass criteria |
|-------------|----------|---------------|
| SfButton reuse | U-AB-200, V-AB-020 | SfButton in tree; no raw `<button>` in component source for commands |
| Icon-only via SfButton | U-AB-201 | IconCss pattern fixture |
| No SfMenu dependency | U-AB-202 | Overflow without SfMenu type reference |
| SfThemeRoot | U-AB-203, I-AB-007 | Renders under theme root |
| CSS isolation | I-AB-200 | Isolation attribute |
| Scoped test ids | I-AB-201, U-AB-021 | Stable testids |

Source-level guard (optional CI script): `rg` fails if `SfAppBar*.razor` contains raw command `<button` outside allowed overflow chrome exceptions documented in Spec.

---

## 13. Render Mode Matrix

| Feature | Static SSR | Interactive Server | WASM | Auto |
|---------|------------|--------------------|------|------|
| Layout/regions/title | Required pass | Pass | Pass | Pass |
| SfButton display | Pass | Pass | Pass | Pass |
| OnClick handlers | N/A static | Pass | Pass | Pass |
| Overflow measure | Degraded (all visible) | Pass | Pass | Pass |
| FocusAsync | N/A / no-op safe | Pass | Pass | Pass |
| Keyboard toolbar | N/A static | Pass | Pass | Pass |

Tests: bUnit covers structure; Playwright runs on Interactive Server and WASM sample hosts.

---

## 14. Phase Separation

| Phase | Mandatory test sets |
|-------|---------------------|
| MVP | U-AB-001–043, 070, 080–081, 090–093, 100–107, 200–203, 210–211; I-AB-001–005,007,009,200–201; P-AB-001–014,030–031,050,060,070,080; P-AXE-AB-01–03,06–08,10; V-AB-001–005,010,012–020; all B-AB |
| Phase 2 | All overflow/template tests; P-AXE-AB-04,05,09; V-AB-006–009,011 |
| Phase 3 | 100-action perf; contextual bar tests when specified |

---

## 15. CI Job Mapping

| Job | Layers |
|-----|--------|
| `ci-unit` | L1, L2 |
| `ci-playwright` | L3, L4 |
| `ci-snapshots` | L5 |
| `ci-build-aot-trim` | L6 |

PR merge requires: ci-unit + ci-playwright + ci-build-aot-trim. Snapshots required on main/release.

---

## 16. Failure Gates

| Condition | Result |
|-----------|--------|
| Any L1/L2 fail | Block merge |
| Any L3 fail | Block merge |
| Axe critical/serious | Block merge |
| B-AB-* fail | Block merge |
| Snapshot fail on main | Block release |
| Console error | Block merge |

---

## 17. Non-Goals

- Manual exploratory QA as gate  
- JAWS/NVDA interactive certification as CI blocker (unit+axe cover; optional offline evidence only)  
- Pixel-perfect non-CI browser matrix beyond latest 2 versions in Playwright images  

---

## 18. Future Enhancement Tests

| ID | When |
|----|------|
| U-AB-300 | SfMenu-backed overflow swap |
| U-AB-301 | SfAvatar region helper |
| P-AB-100 | Contextual SectionOutlet AppBar |

---

## 19. Traceability Notes

Every test ID in this document MUST appear in Evidence.md master matrix and/or API traceability rows. No orphan tests; no untested public API members.
