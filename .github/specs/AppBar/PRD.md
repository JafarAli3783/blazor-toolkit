# SfAppBar — Product Requirements Document

**Component:** SfAppBar  
**Namespace:** Syncfusion.Blazor.Toolkit  
**Repository:** https://github.com/syncfusion/blazor-toolkit  
**License:** MIT  
**TFMs:** net8.0 / net9.0 / net10.0  
**Render modes:** Static SSR, Interactive Server, Interactive WebAssembly, Interactive Auto  
**Version:** 1.0  
**Status:** Implementation-Ready  

---

## Table of Contents

1. [Problem Statement](#1-problem-statement)
2. [Goals](#2-goals)
3. [Non-Goals](#3-non-goals)
4. [Success Metrics](#4-success-metrics)
5. [Personas & Scenarios](#5-personas--scenarios)
6. [Feature Scope by Phase](#6-feature-scope-by-phase)
7. [Requirements Catalog](#7-requirements-catalog)
8. [Quality Gates](#8-quality-gates)
9. [Accessibility Requirements](#9-accessibility-requirements)
10. [Toolkit Primitive Reuse](#10-toolkit-primitive-reuse)
11. [Competitive Positioning](#11-competitive-positioning)
12. [Dependencies & Constraints](#12-dependencies--constraints)
13. [Risks & Mitigations](#13-risks--mitigations)
14. [Future Enhancement Recommendations](#14-future-enhancement-recommendations)
15. [Traceability Summary](#15-traceability-summary)
16. [Document History](#16-document-history)

---

## 1. Problem Statement

The Syncfusion Blazor Toolkit lacks a modern, responsive application shell header and navigation surface. Developers building MIT-licensed Blazor apps currently rely on hand-rolled HTML/CSS, commercial Syncfusion packages, or third-party libraries (MudBlazor, Telerik, Fluent UI, Blazorise, Radzen, etc.) for AppBar/Toolbar/Navbar patterns.

Without a first-class AppBar, the Toolkit cannot provide a complete application chrome foundation (branding, title, actions, overflow, fixed/sticky positioning, accessibility landmarks) that is:

- Fully MIT-compatible
- Free of commercial Syncfusion.Blazor dependencies
- Accessibility-first (WCAG 2.2 AA minimum)
- AOT-safe and trimming-safe
- Fully CI-verifiable with zero mandatory manual QA

**G-00** The Toolkit SHALL provide SfAppBar as the canonical application header/navigation surface.

---

## 2. Goals

| ID | Goal | Priority | Phase |
|----|------|----------|-------|
| G-01 | Provide Top and Bottom AppBar layout modes | Must | MVP |
| G-02 | Support Static, Fixed, and Sticky positioning modes | Must | MVP |
| G-03 | Expose regional layout: Leading, Branding, Title, Content, Actions, Overflow | Must | MVP |
| G-04 | Integrate SfButton (and ButtonGroup where appropriate) for command surfaces | Must | MVP |
| G-05 | Deliver WCAG 2.2 AA compliance with WAI-ARIA Toolbar + Navigation landmark patterns | Must | MVP |
| G-06 | Support Comfortable and Compact density | Must | MVP |
| G-07 | Support theme tokens via SfThemeRoot and CSS isolation | Must | MVP |
| G-08 | Support RTL, high contrast, forced colors, and reduced motion | Must | MVP |
| G-09 | Provide automatic overflow of action items with measurement-driven layout | Must | Phase 2 |
| G-10 | Provide templates for custom content, search, and identity regions | Must | Phase 2 |
| G-11 | Automation-First Quality: All public APIs, accessibility requirements, responsive behaviors, interaction workflows, rendering states, and visual states MUST be validated through automated CI processes such that future releases can be shipped without mandatory manual testing | Must | MVP |
| G-12 | Achieve ≥95% feature parity with Tier-1 competitor AppBar/Toolbar surfaces for scoped features | Should | Phase 2 |
| G-13 | Remain AOT-safe, trim-safe, reflection-free, and pure-Blazor-first | Must | MVP |
| G-14 | Support Static SSR, Interactive Server, WASM, and Auto render modes | Must | MVP |
| G-15 | Ship exactly 6 polished Sample Browser demos covering all primary scenarios | Must | MVP |

---

## 3. Non-Goals

| ID | Non-Goal | Rationale |
|----|----------|-----------|
| NG-01 | Ribbon control | Separate multi-row command surface; out of scope |
| NG-02 | Dock manager / multi-pane docking | Layout framework concern |
| NG-03 | Complex hierarchical navigation framework (full site map, mega-menus) | Use future SfMenu / navigation components |
| NG-04 | Multi-row command shell | Exceeds single-bar AppBar model |
| NG-05 | Dependency on commercial Syncfusion.Blazor packages | Violates MIT-only mandate |
| NG-06 | Raw HTML `<button>` where SfButton exists | Violates primitive reuse |
| NG-07 | Manual QA as a release gate | G-11 requires full automation |
| NG-08 | Vertical sidebar AppBar as primary mode | Defer to future Sidebar/Layout; horizontal AppBar only in MVP–Phase 3 |
| NG-09 | Built-in search input control | Template slot only; use Toolkit TextBox when available |
| NG-10 | Built-in authentication/identity provider | Template slot + future SfAvatar |
| NG-11 | Contextual action bar (Mud-style SectionOutlet swap) | Phase 3 candidate |
| NG-12 | Drag-reorder of actions | Phase 3+ |

---

## 4. Success Metrics

| Metric | Target | Measurement |
|--------|--------|-------------|
| Competitor feature parity (scoped) | ≥95% | competitive-matrix.md gap analysis |
| Public API automation coverage | 100% | TEST-MATRIX.md L1–L6 |
| Traceability coverage | 100% | Evidence.md master matrix |
| Axe critical/serious issues | 0 | L4 Playwright + axe on 10 routes |
| Trim warnings | 0 | B-AB build validation |
| AOT warnings | 0 | B-AB build validation |
| CS1591 warnings | 0 | B-AB build validation |
| Analyzer warnings | 0 | B-AB build validation |
| Runtime console errors | 0 | Playwright console capture |
| Toolkit primitive reuse compliance | 100% for available primitives | U-AB-200+ |
| Sample demos | Exactly 6 | sample-preparer.md |
| WCAG 2.2 AA | Pass | L4 axe + keyboard tests |

---

## 5. Personas & Scenarios

| Persona | Scenario | Requirement IDs |
|---------|----------|-----------------|
| App developer (MIT stack) | Build dashboard shell with logo, title, 5–15 actions | G-01–G-04, G-09 |
| Accessibility engineer | Validate toolbar + banner landmark with NVDA/Narrator/JAWS | G-05, G-08 |
| Enterprise theming | Apply custom tokens via SfThemeRoot, high-contrast mode | G-07, G-08 |
| Mobile-first developer | Overflow actions on 320–375px viewports | G-09, G-12 |
| CI maintainer | Ship releases with zero manual QA | G-11 |

---

## 6. Feature Scope by Phase

### MVP (Phase 1)

- Top / Bottom position
- Static / Fixed / Sticky mode
- Regions: Leading, Branding, Title, Content, Actions
- SfButton / ButtonGroup command integration
- Density: Comfortable / Compact
- Elevation / border theme tokens
- RTL, focus visibility, keyboard (Tab into toolbar, arrows within)
- role="banner" or role="contentinfo" + inner role="toolbar"
- CSS isolation, scoped IDs, data-testid hooks
- Static SSR + Interactive modes
- AOT / trim safe
- Full L1–L6 automation for MVP surface
- Samples SMP-01, SMP-03, SMP-05, SMP-06 (core)

### Phase 2

- Automatic overflow region with measurement (ResizeObserver / Element measurement)
- SfAppBarOverflow + overflow menu surface
- Templates: BrandingTemplate, TitleTemplate, ContentTemplate, ActionsTemplate, OverflowTemplate
- Search region template
- Responsive breakpoint adaptation
- ≤50 actions performance target
- Samples SMP-02, SMP-04 complete

### Phase 3

- ≥100 actions stretch performance
- Advanced adaptive behaviors (priority-based overflow)
- Contextual action bar pattern (optional)
- Visual polish (elevation levels, dense animations with reduced-motion respect)
- Optional SfAvatar / SfMenu integration when those primitives ship

---

## 7. Requirements Catalog

### Layout & Positioning

| ID | Requirement | Phase | Normative |
|----|-------------|-------|-----------|
| R-AB-001 | SfAppBar MUST support AppBarPosition.Top and AppBarPosition.Bottom | MVP | MUST |
| R-AB-002 | SfAppBar MUST support AppBarMode.Static, Fixed, Sticky | MVP | MUST |
| R-AB-003 | Fixed mode MUST pin the bar to the viewport edge and reserve layout space or provide documented offset contract | MVP | MUST |
| R-AB-004 | Sticky mode MUST use CSS position:sticky with documented top/bottom offset | MVP | MUST |
| R-AB-005 | Static mode MUST participate in normal document flow | MVP | MUST |

### Regions

| ID | Requirement | Phase | Normative |
|----|-------------|-------|-----------|
| R-AB-010 | SfAppBar MUST expose Leading, Branding, Title, Content, Actions regions via child components and/or templates | MVP | MUST |
| R-AB-011 | SfAppBarSpacer MUST expand to push subsequent content | MVP | MUST |
| R-AB-012 | SfAppBarItem MUST represent a single action or content unit with optional Priority for overflow | Phase 2 | MUST |
| R-AB-013 | Overflow region MUST collect items that do not fit | Phase 2 | MUST |

### Commands & Primitives

| ID | Requirement | Phase | Normative |
|----|-------------|-------|-----------|
| R-AB-020 | Command surfaces MUST use SfButton (not raw HTML button) | MVP | MUST |
| R-AB-021 | Icon-only commands SHOULD use SfButton with IconCss until SfIconButton exists | MVP | SHOULD |
| R-AB-022 | Grouped commands SHOULD use SfButtonGroup where semantically appropriate | MVP | SHOULD |
| R-AB-023 | Menu actions MUST use Toolkit popup infrastructure or SfMenu when available; justification required if not | Phase 2 | MUST |

### Responsiveness

| ID | Requirement | Phase | Normative |
|----|-------------|-------|-----------|
| R-AB-030 | AppBar MUST adapt layout at 320, 375, 768, 1024, 1440 px | Phase 2 | MUST |
| R-AB-031 | Overflow calculation MUST be driven by element measurement | Phase 2 | MUST |
| R-AB-032 | JS interop MUST be limited to ResizeObserver / measurement / overflow only | Phase 2 | MUST |

### Accessibility

| ID | Requirement | Phase | Normative |
|----|-------------|-------|-----------|
| R-AB-040 | Outer container MUST map to banner (Top) or contentinfo (Bottom) landmark when appropriate | MVP | MUST |
| R-AB-041 | Action group MUST implement WAI-ARIA Toolbar pattern (role="toolbar") | MVP | MUST |
| R-AB-042 | Keyboard: Tab enters toolbar; Arrow keys move among controls; Home/End supported | MVP | MUST |
| R-AB-043 | Focus visibility MUST meet WCAG 2.2 AA | MVP | MUST |
| R-AB-044 | Screen reader support MUST be validated for NVDA, Narrator, JAWS via automation where feasible | MVP | MUST |
| R-AB-045 | High contrast, forced colors, reduced motion, RTL MUST be supported | MVP | MUST |
| R-AB-046 | MUST NOT use Combobox pattern for AppBar | MVP | MUST NOT |

### Quality & Automation

| ID | Requirement | Phase | Normative |
|----|-------------|-------|-----------|
| R-AB-050 | 0 build, CS1591, trim, AOT, analyzer warnings | MVP | MUST |
| R-AB-051 | 100% public API covered by automated tests | MVP | MUST |
| R-AB-052 | All acceptance criteria MUST be CI-verifiable | MVP | MUST |
| R-AB-053 | No manual QA required as release gate | MVP | MUST |

### Theming & Rendering

| ID | Requirement | Phase | Normative |
|----|-------------|-------|-----------|
| R-AB-060 | CSS isolation (.razor.css) MUST be used | MVP | MUST |
| R-AB-061 | Scoped IDs MUST be generated for stable hooks | MVP | MUST |
| R-AB-062 | Theme tokens MUST integrate with SfThemeRoot | MVP | MUST |
| R-AB-063 | data-testid contracts MUST be stable and documented | MVP | MUST |

---

## 8. Quality Gates

| Gate | Criteria | CI Job |
|------|----------|--------|
| Build | 0 warnings (nullable, CS1591, analyzers) | B-AB-001 |
| Trim | 0 trim warnings | B-AB-002 |
| AOT | 0 AOT warnings | B-AB-003 |
| Unit | 100% public API L1 | U-AB-* |
| Integration | Lifecycle, theme, resize | I-AB-* |
| Playwright | Desktop/Tablet/Mobile, keyboard, RTL | P-AB-* |
| Axe | 0 critical, 0 serious on 10 routes | P-AXE-AB-* |
| Snapshots | V-AB-001 … V-AB-020 | V-AB-* |
| Samples | Exactly 6 demos build and render | SMP-* |

**Release rule:** All gates MUST pass. Manual QA MUST NOT be a release gate.

---

## 9. Accessibility Requirements

| Area | Requirement | Spec ID |
|------|-------------|---------|
| Toolbar Semantics | role="toolbar" on action container | S-AB-A11Y-01 |
| Navigation Landmark | banner/contentinfo as appropriate | S-AB-A11Y-02 |
| Keyboard Navigation | Tab + Arrows + Home/End | S-AB-A11Y-03 |
| Focus Visibility | Visible focus ring AA | S-AB-A11Y-04 |
| Screen Reader Support | Accessible names, labels | S-AB-A11Y-05 |
| High Contrast | Theme + system HC | S-AB-A11Y-06 |
| Forced Colors | forced-colors media | S-AB-A11Y-07 |
| Reduced Motion | prefers-reduced-motion | S-AB-A11Y-08 |
| RTL | dir=rtl layout mirror | S-AB-A11Y-09 |

Target: **WCAG 2.2 AA** minimum; **AAA** where practical (focus appearance, contrast).

---

## 10. Toolkit Primitive Reuse

| Requirement | Toolkit Component | Status | Action |
|-------------|-------------------|--------|--------|
| Commands | SfButton | Available | MUST reuse |
| Icon commands | SfButton + IconCss | Available | MUST reuse until SfIconButton |
| Button groups | SfButtonGroup | Available | SHOULD reuse |
| Menu actions | SfMenu | Not available | Use SfDialog / minimal overflow panel; justify in Spec |
| User identity | SfAvatar | Not available | Template slot only |
| Theme | SfThemeRoot | Available | MUST integrate |
| Popup infrastructure | Dialog/Tooltip | Available | Reuse for overflow UI |
| Tooltip on actions | SfTooltip | Available | SHOULD reuse for icon-only labels |

If a listed primitive is not reused, Spec.md MUST contain an explicit justification.

---

## 11. Competitive Positioning

SfAppBar MUST meet or exceed MudBlazor, Telerik, Ignite UI, DevExpress, Fluent UI, Blazorise, Radzen, Bootstrap, Ant Design, and Havit in the scoped feature set, with decisive wins on:

- MIT license purity
- AOT / trimming guarantees
- Automation depth (G-11)
- Toolkit primitive consistency
- Accessibility (Toolbar + landmark)

See competitive-matrix.md for full analysis.

---

## 12. Dependencies & Constraints

- **Allowed dependencies:** Microsoft.AspNetCore.Components.Web, Microsoft.Extensions.Localization, existing Toolkit assemblies only
- **Forbidden:** Syncfusion.Blazor.* commercial packages
- **JS:** Only ResizeObserver, element measurement, overflow calculations
- **No reflection-based runtime APIs**
- **Pure Blazor preferred**

---

## 13. Risks & Mitigations

| Risk | Impact | Mitigation |
|------|--------|------------|
| SfMenu / SfAvatar absent | Overflow UX weaker | Phase 2 overflow panel via Dialog; templates for identity |
| ResizeObserver SSR | Measurement N/A on static | Defer overflow to interactive; progressive enhancement |
| Performance with 100 actions | Layout thrash | Debounced measure; virtualize overflow list Phase 3 |
| Landmark misuse | A11y failures | Strict role mapping + axe gates |

---

## 14. Future Enhancement Recommendations

1. Native SfMenu-backed overflow when SfMenu ships  
2. SfAvatar region helper  
3. Contextual AppBar (SectionOutlet pattern)  
4. Priority-based overflow algorithm  
5. Vertical compact mode (icon rail) as separate component  
6. Integration samples with future SfSidebar  

---

## 15. Traceability Summary

| Goal | Primary Spec IDs | Primary Test IDs |
|------|------------------|------------------|
| G-01 | S-AB-LAY-01 | U-AB-001, P-AB-001 |
| G-02 | S-AB-LAY-02 | U-AB-002, P-AB-002 |
| G-03 | S-AB-REG-01 | U-AB-010, P-AB-010 |
| G-04 | S-AB-CMD-01 | U-AB-020, U-AB-200 |
| G-05 | S-AB-A11Y-* | P-AXE-AB-*, P-AB-KBD-* |
| G-09 | S-AB-OVR-01 | U-AB-030, P-AB-OVR-* |
| G-11 | All | All L1–L6 |

Full matrix: Evidence.md.

---

## 16. Document History

| Version | Date | Author | Changes |
|---------|------|--------|---------|
| 1.0 | 2026-11-06 | Spec Package | Initial implementation-ready PRD |