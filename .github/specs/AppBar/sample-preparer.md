# SfAppBar — Sample Browser Preparer (Exactly 6 Demos)

**Version:** 1.0  
**Rule:** Exactly six polished demos. No more, no less.  
**Cross-refs:** PRD G-15, Spec.md, API.md, TEST-MATRIX.md, Evidence.md  

---

## Table of Contents

1. [Sample Inventory](#1-sample-inventory)
2. [SMP-01 Default](#2-smp-01-default)
3. [SMP-02 Responsive](#3-smp-02-responsive)
4. [SMP-03 Navigation](#4-smp-03-navigation)
5. [SMP-04 Templates](#5-smp-04-templates)
6. [SMP-05 Fixed vs Sticky](#6-smp-05-fixed-vs-sticky)
7. [SMP-06 States & Accessibility](#7-smp-06-states--accessibility)
8. [Sample Coverage Matrix](#8-sample-coverage-matrix)
9. [Catalog Description Standards](#9-catalog-description-standards)
10. [Non-Goals](#10-non-goals)
11. [Future Samples (Out of Browser Count)](#11-future-samples-out-of-browser-count)

---

## 1. Sample Inventory

| ID | Route | Title | Phase |
|----|-------|-------|-------|
| SMP-01 | /appbar/default | Default | MVP |
| SMP-02 | /appbar/responsive | Responsive & Overflow | Phase 2 |
| SMP-03 | /appbar/navigation | Navigation | MVP |
| SMP-04 | /appbar/templates | Templates | Phase 2 |
| SMP-05 | /appbar/fixed-sticky | Fixed vs Sticky | MVP |
| SMP-06 | /appbar/states | States & Accessibility | MVP |

Also map axe routes `/appbar/dense`, `/appbar/rtl`, `/appbar/high-contrast`, `/appbar/overflow`, `/appbar/sticky`, `/appbar/fixed` as aliases or query variants of the six demos so L4’s 10 routes resolve without adding catalog demos.

---

## 2. SMP-01 Default

**Purpose:** Basic branding and actions.  

**Real-world scenario:** Internal admin dashboard header with product name and primary actions.  

**UX goals:** Clear hierarchy; actions use SfButton; spacer pushes actions end.  

**APIs demonstrated:** Position(Top), Mode(Static), Title, ChildContent, SfAppBarItem, SfAppBarSpacer, SfButton, Density default, Elevation.  

**Catalog Description:**  
> Get started with SfAppBar using a product title, flexible spacer, and toolkit buttons for primary actions.

**Spec IDs:** S-AB-LAY-01, S-AB-REG-01, S-AB-REUSE-01, S-AB-CSS-01  

**Test IDs:** U-AB-001, U-AB-013, U-AB-200, P-AB-001, P-AXE-AB-01, V-AB-001, V-AB-020  

---

## 3. SMP-02 Responsive

**Purpose:** Responsive and overflow behavior.  

**Real-world scenario:** Toolbar with many actions on mobile and desktop.  

**UX goals:** Items collapse into overflow under 768px; overflow keyboard accessible.  

**APIs demonstrated:** EnableOverflow, Priority, MeasureAsync path, Overflow events, SfAppBarOverflow.  

**Catalog Description:**  
> Explore automatic overflow as the viewport shrinks. Action priority controls which commands remain visible.

**Spec IDs:** S-AB-OVR-01–04, S-AB-JS-01, S-AB-PERF-01  

**Test IDs:** U-AB-030, U-AB-031, P-AB-020, P-AB-021, P-AB-040, P-AXE-AB-04, P-AXE-AB-05, V-AB-007, V-AB-008, V-AB-009  

---

## 4. SMP-03 Navigation

**Purpose:** Application navigation bar.  

**Real-world scenario:** Marketing or app shell with logo, nav links, and account action.  

**UX goals:** Leading menu button, branding, title, end actions; landmark correct.  

**APIs demonstrated:** Leading region composition, Branding via ChildContent, Title, OnItemClick, AriaLabel.  

**Catalog Description:**  
> Build a navigation-oriented app bar with branding, section title, and end-aligned commands.

**Spec IDs:** S-AB-REG-01, S-AB-A11Y-01, S-AB-A11Y-02, S-AB-KBD-01  

**Test IDs:** P-AB-060, P-AB-011, P-AXE-AB-06, V-AB-010  

---

## 5. SMP-04 Templates

**Purpose:** Custom content, identity placeholder, search region.  

**Real-world scenario:** App header with search field and user placeholder avatar (template).  

**UX goals:** Templates compose without fighting default regions.  

**APIs demonstrated:** LeadingTemplate, BrandingTemplate, TitleTemplate, ContentTemplate, ActionsTemplate.  

**Catalog Description:**  
> Customize every region with templates for search, branding artwork, and identity placeholders.

**Spec IDs:** S-AB-RND-01, S-AB-REG-01  

**Test IDs:** U-AB-050–054, P-AXE-AB-09, V-AB-011  

---

## 6. SMP-05 Fixed vs Sticky

**Purpose:** Positioning comparison.  

**Real-world scenario:** Long scrolling documentation page.  

**UX goals:** Side-by-side or toggles showing Fixed vs Sticky vs Static.  

**APIs demonstrated:** Mode Fixed, Sticky, Static; Position Top/Bottom.  

**Catalog Description:**  
> Compare static, fixed, and sticky positioning modes for top and bottom app bars.

**Spec IDs:** S-AB-LAY-02, S-AB-LAY-01  

**Test IDs:** P-AB-002, P-AB-003, P-AXE-AB-02, P-AXE-AB-03, V-AB-003, V-AB-004  

---

## 7. SMP-06 States & Accessibility

**Purpose:** RTL, theme, contrast, disabled actions, compact density.  

**Real-world scenario:** Global enterprise shell with accessibility modes.  

**UX goals:** Demonstrate keyboard, disabled items, dense mode, RTL, high contrast.  

**APIs demonstrated:** Density Compact, Disabled items, Class for theme, AriaLabel, FocusAsync.  

**Catalog Description:**  
> Validate dense layout, disabled actions, right-to-left, and high-contrast friendly rendering.

**Spec IDs:** S-AB-A11Y-03–09, S-AB-LAY-03  

**Test IDs:** P-AB-030, P-AB-050, P-AXE-AB-07, P-AXE-AB-08, P-AXE-AB-10, V-AB-012, V-AB-014, V-AB-016  

---

## 8. Sample Coverage Matrix

| Sample | Spec IDs | APIs | Tests |
|--------|----------|------|-------|
| SMP-01 | S-AB-LAY-01, S-AB-REG-01, S-AB-REUSE-01 | API-AB-001,002,003,010,011,025 | U-AB-001,013,200; P-AB-001; P-AXE-AB-01; V-AB-001,020 |
| SMP-02 | S-AB-OVR-* | API-AB-013,004,030,031,041,042 | U-AB-030,031; P-AB-020,021,040; P-AXE-AB-04,05; V-AB-007–009 |
| SMP-03 | S-AB-A11Y-01,02, KBD-01 | API-AB-014,032 | P-AB-060,011; P-AXE-AB-06; V-AB-010 |
| SMP-04 | S-AB-RND-01 | API-AB-019–023 | U-AB-050–054; P-AXE-AB-09; V-AB-011 |
| SMP-05 | S-AB-LAY-01,02 | API-AB-010,011 | P-AB-002,003; P-AXE-AB-02,03; V-AB-003,004 |
| SMP-06 | S-AB-A11Y-*, LAY-03 | API-AB-012,040 | P-AB-030,050; P-AXE-AB-07,08,10; V-AB-012,014,016 |

---

## 9. Catalog Description Standards

- One or two sentences  
- No marketing fluff beyond capability  
- Mention Toolkit primitives when shown (SfButton)  

---

## 10. Non-Goals

- Seventh catalog demo  
- Ribbon samples  
- Full application shell with sidebar (link only if exists)  

---

## 11. Future Samples (Out of Browser Count)

- Contextual AppBar  
- 100-action stress demo (docs only)  
- SfMenu-backed overflow after SfMenu ships  

---

## Lessons Learned (All Files)

1. Prefer SfButton over raw HTML for every command.  
2. Overflow is interactive-only; SSR must remain valid.  
3. Toolbar + landmark dual semantics are non-negotiable.  
4. Exactly six samples force prioritization.  
5. G-11 means every acceptance criterion has an automated owner.