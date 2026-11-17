# SfMenu – Evidence

## Syncfusion Blazor Toolkit

**Version:** 1.0  
**Status:** Pending implementation. Non-normative until code, tests, and runtime verification exist.  
**Authority:**  
- `PRD.md` owns scope  
- `Spec.md` owns behavior  
- `API.md` owns public members  
- `TEST-MATRIX.md` owns test IDs  

This file records design rationale, competitor evidence, and (later) runtime verification results. It does **not** define requirements.

---

## 1. Header

| Field                 | Value                              |
|-----------------------|------------------------------------|
| Component             | SfMenu                             |
| Spec Version          | 1.0                                |
| Current Verdict       | Design complete (proposed)         |
| Implementation Status | Not started                        |
| Runtime Verified      | No                                 |
| Last Updated          | 2026-11-16                         |

---

## 2. Design Rationale Summary

| Decision                              | Rationale |
|---------------------------------------|---------|
| Separate Menu and ContextMenu         | Aligns with Telerik, DevExpress, Syncfusion Enterprise, and Microsoft patterns. MudBlazor combines them; we deliberately do not. |
| Support both Horizontal & Vertical    | Required for application menubars and vertical command/navigation menus. |
| WAI-ARIA Menu / Menubar pattern       | Correct semantic roles (`menubar`, `menu`, `menuitem`, `separator`) are mandatory for accessibility leadership. |
| Both declarative + data-bound items   | Matches Toolkit patterns already used in `SfList` and covers the majority of competitor use cases. |
| Selector precedence over field names  | Improves type safety and AOT/trim friendliness. |
| No `EnableRtl` parameter              | RTL is inherited from ancestor `dir` (consistent with modern Toolkit direction). |
| Strong focus on AOT / trim & a11y     | Key differentiators against commercial and open-source competitors. |

---

## 3. Spec Behavior Checklist

| ID    | Behavior                                          | Expected Result                                      | Runtime Result | Notes |
|-------|---------------------------------------------------|------------------------------------------------------|----------------|-------|
| S-01  | Horizontal orientation                            | Root has `role="menubar"`                            | Pending        |       |
| S-02  | Vertical orientation                              | Root has `role="menu"`                               | Pending        |       |
| S-03  | Menu items                                        | Each item has `role="menuitem"`                      | Pending        |       |
| S-04  | Separators                                        | `role="separator"`                                   | Pending        |       |
| S-05  | Disabled items                                    | `aria-disabled="true"` and not activatable           | Pending        |       |
| S-06  | Items with children                               | `aria-haspopup="menu"` + `aria-expanded` management  | Pending        |       |
| S-07  | Open on Click                                     | Submenu opens on click                               | Pending        |       |
| S-08  | Open on Hover                                     | Submenu opens on hover                               | Pending        |       |
| S-09  | Keyboard navigation                               | Full arrow / Home / End / Enter / Space / Escape     | Pending        |       |
| S-10  | Type-ahead                                        | Focus moves to matching item                         | Pending        |       |
| S-11  | Focus management                                  | Focus moves into menu on open and returns on close   | Pending        |       |
| S-12  | Programmatic API                                  | `OpenAsync`, `CloseAsync`, `FocusAsync` work         | Pending        |       |
| S-13  | RTL                                               | Layout + arrow keys reversed                         | Pending        |       |
| S-14  | Collision detection                               | Submenus remain visible when near viewport edge      | Pending        |       |
| S-15  | Accessibility (axe)                               | 0 critical / 0 serious on 10 defined routes          | Pending        |       |
| S-16  | Toolkit primitive reuse                           | Popup / theme tokens / shared infrastructure used    | Pending        |       |
| S-17  | Build quality                                     | 0 warnings, 0 CS1591, trim/AOT clean                 | Pending        |       |

---

## 4. Competitor Evidence Summary

Detailed research is recorded in `_source/00000-menu-research.md`.

| Competitor                  | Key Takeaway for SfMenu |
|----------------------------|-------------------------|
| MudBlazor                  | Simple activator model; combines context menu behavior. We intentionally keep ContextMenu separate. |
| Telerik UI for Blazor      | Excellent data-binding (flat + hierarchical) and ShowOn/HideOn control. Strong parity target. |
| Radzen Blazor              | Clean declarative API and good keyboard support. Good open-source reference. |
| DevExpress Blazor          | Adaptive behavior and solid accessibility. Commercial parity target. |
| Syncfusion Enterprise Menu | Mature feature set (animation, hamburger, templates). Useful internal reference but commercial. |
| Fluent UI Blazor           | Strong accessibility alignment with Microsoft patterns. Important reference for ARIA & focus. |

---

## 5. Runtime Verification Record

*(To be filled after implementation)*

### 5.1 bUnit Results
- Status: Pending
- Total tests: –
- Passed: –
- Failed: –

### 5.2 Playwright Results
- Status: Pending
- Interaction tests: –
- Visual tests: –
- axe results: –

### 5.3 Screenshots
| Scenario                    | Screenshot | Reviewed |
|-----------------------------|----------|----------|
| Closed horizontal           | Pending  | No       |
| Open horizontal             | Pending  | No       |
| Nested submenus             | Pending  | No       |
| Vertical orientation        | Pending  | No       |
| RTL                         | Pending  | No       |
| Disabled + Separators       | Pending  | No       |
| High Contrast               | Pending  | No       |

### 5.4 Accessibility Transcripts
- NVDA: Pending  
- Narrator: Pending  
- JAWS: Pending  

---

## 6. Risks & Mitigations (Evidence Tracking)

| Risk                              | Mitigation                              | Status |
|-----------------------------------|-----------------------------------------|--------|
| Incorrect ARIA pattern            | Follow WAI-ARIA APG + axe + SR testing  | Open   |
| Focus loss on open/close          | Explicit focus tests in TEST-MATRIX     | Open   |
| Popup collision problems          | Reuse Toolkit popup infrastructure      | Open   |
| Scope creep into ContextMenu      | Explicit non-goal in PRD                | Controlled |
| AOT / trim regressions            | Selector preference + analyzer checks   | Open   |

---

## 7. Implementation Confidence Checklist

| Item                                      | Status |
|-------------------------------------------|--------|
| PRD complete and reviewed                 | Proposed |
| Spec.md behavior clear                    | Proposed |
| API.md stable enough for implementation   | Proposed |
| TEST-MATRIX defined                       | Proposed |
| Competitive analysis recorded             | Done |
| Runtime evidence collected                | Not started |
| Accessibility evidence collected          | Not started |
| Final maintainer approval                 | Not started |

---

## 8. Document History

| Version | Date       | Author / Agent | Notes |
|---------|------------|----------------|-------|
| 1.0     | 2026-11-16 | Spec generation | Initial Evidence structure created |

---