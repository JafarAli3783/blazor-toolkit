# Evidence.md — SfAppBar Release Validation

## Syncfusion Blazor Toolkit

| Field | Value |
|---------|---------|
| **Component** | SfAppBar (family: SfAppBar, SfAppBarItem, SfAppBarSpacer, SfAppBarOverflow) |
| **Version** | 1.0 |
| **Specs** | Spec.md, API.md, API-xml.md, PRD.md, TEST-MATRIX.md, competitive-matrix.md, sample-preparer.md |
| **Source** | `src/Components/Layout/AppBar/` *(or final path under `src/Components/` as implemented)* |
| **Branch** | *TBD* |
| **Date** | *TBD* |
| **Namespace** | Syncfusion.Blazor.Toolkit |
| **License** | MIT |
| **TFMs** | net8.0 / net9.0 / net10.0 |
| **Rule** | Never invent results. Use **Not yet collected** or **Not yet measured** until executed. |

---

## Table of Contents

1. [Verdict](#verdict)
2. [Spec Behavior Results](#1-spec-behavior-results)
3. [Public API](#2-public-api)
4. [Evidence Catalog](#3-evidence-catalog)
5. [Collection Process](#4-collection-process)
6. [Runtime Record](#5-runtime-record)
7. [Accessibility Evidence Map](#6-accessibility-evidence-map)
8. [Sample Coverage Status](#7-sample-coverage-status)
9. [Toolkit Primitive Reuse Status](#8-toolkit-primitive-reuse-status)
10. [Traceability Status](#9-traceability-status)
11. [Notes (Fill After Implementation)](#10-notes-fill-after-implementation)
12. [Release Checklist](#11-release-checklist)
13. [Sign-off](#12-sign-off)
14. [Document History](#13-document-history)

---

## Verdict

*Pending collection of runtime evidence.*

**Target:** Implementation matches Spec for:

- Position (Top/Bottom)
- Mode (Static/Fixed/Sticky)
- Density
- Regions (Leading, Branding, Title, Content, Actions, Overflow)
- SfButton-based commands (no raw HTML command buttons)
- Toolbar and landmark semantics
- Keyboard navigation (roving tabindex)
- Overflow measurement (Phase 2)
- Templates (Phase 2)
- RTL support
- Forced-colors and High Contrast support
- Theme tokens through SfThemeRoot
- Static SSR compatibility
- AOT and trimming cleanliness
- Public API surface compliance with API.md and API-xml.md

**Ship Authority:** CI evidence only.

Manual exploratory QA is **not** a release gate (PRD G-11).

Scripted screen-reader transcripts (NVDA, Narrator, JAWS) are release-evidence artifacts and do not override or replace automated validation requirements.

---

## 1. Spec Behavior Results

| ID | Requirement | Spec Ref | Result |
|----|-------------|----------|--------|
| S-AB-pos | Top → `<header>`; Bottom → `<footer>` | S-AB-LAY-01 | Not yet collected |
| S-AB-mode | Static / Fixed / Sticky CSS + scroll behavior | S-AB-LAY-02 | Not yet collected |
| S-AB-density | Comfortable / Compact classes | S-AB-LAY-03 | Not yet collected |
| S-AB-reg | Regions + spacer + item composition | S-AB-REG-01, S-AB-REG-03 | Not yet collected |
| S-AB-cmd | Commands via SfButton / SfButtonGroup (not raw `<button>` actions) | S-AB-REUSE-01, R-AB-020 | Not yet collected |
| S-AB-a11y-toolbar | Actions container `role="toolbar"` + accessible name | S-AB-A11Y-01 | Not yet collected |
| S-AB-a11y-landmark | Banner/contentinfo via header/footer | S-AB-A11Y-02 | Not yet collected |
| S-AB-kbd | Tab into toolbar; Arrow / Home / End navigation | S-AB-KBD-01, S-AB-A11Y-03 | Not yet collected |
| S-AB-focus | Visible focus indicator | S-AB-A11Y-04 | Not yet collected |
| S-AB-ovf | EnableOverflow measurement, trigger, open/close, Escape | S-AB-OVR-01–04 | Not yet collected |
| S-AB-tpl | Leading/Branding/Title/Content/Actions/Overflow templates | S-AB-RND-01 | Not yet collected |
| S-AB-rtl | RTL layout and keyboard direction | S-AB-A11Y-09 | Not yet collected |
| S-AB-hc | High Contrast / Forced Colors visibility | S-AB-A11Y-06, S-AB-A11Y-07 | Not yet collected |
| S-AB-motion | prefers-reduced-motion support | S-AB-A11Y-08 | Not yet collected |
| S-AB-ssr | Static SSR valid; overflow progressive enhancement | S-AB-STATE-01, S-AB-RND-01 | Not yet collected |
| S-AB-theme | SfThemeRoot, CSS isolation, theme tokens | S-AB-CSS-*, S-AB-QL-04 | Not yet collected |
| S-AB-testid | Stable `data-testid` hooks | S-AB-TESTID-01 | Not yet collected |
| S-AB-no-combobox | MUST NOT use combobox pattern | S-AB-A11Y-10 | Not yet collected |

---

## 2. Public API

| Item | Result |
|--------|--------|
| SfAppBar parameters vs API.md | Not yet collected |
| SfAppBarItem / SfAppBarSpacer / SfAppBarOverflow vs API.md | Not yet collected |
| Enums (`AppBarPosition`, `AppBarMode`, `AppBarDensity`, `AppBarAlignment`) numeric values stable | Not yet collected |
| Events (`OnItemClick`, `OnOverflowOpened`, `OnOverflowClosed`) order and args | Not yet collected |
| Methods (`FocusAsync`, `RefreshAsync`, `MeasureAsync`) behavior | Not yet collected |
| Cascading `AppBarContext` register/unregister | Not yet collected |
| XML docs complete / 0 CS1591 | Not yet collected |
| API.md ≡ implementation (no silent public surface drift) | Not yet collected |
| API-xml.md examples still accurate | Not yet collected |

---

## 3. Evidence Catalog

| ID | Evidence Item | Method | Artifact | Pass Criteria | Stage | Storage | Retention | Status |
|------|------|------|------|------|------|------|------|------|
| EV-AB-001 | Release build | CI | Log | 0 errors | CI | Actions | 14d | Not yet collected |
| EV-AB-002 | Compiler/analyzer warnings | CI | Log | 0 warnings (`-warnaserror`) | CI | Actions | 14d | Not yet collected |
| EV-AB-003 | XML documentation warnings (CS1591) | CI | Log | 0 warnings | CI | Actions | 14d | Not yet collected |
| EV-AB-004 | Nullable clean | CI | Log | 0 nullable warnings | CI | Actions | 14d | Not yet collected |
| EV-AB-005 | AOT publish warnings | CI | Log | 0 AOT warnings | CI | Actions | 14d | Not yet collected |
| EV-AB-006 | Trimming warnings | CI | Log | 0 trim warnings | CI | Actions | 14d | Not yet collected |
| EV-AB-007 | bUnit L1/L2 execution | CI | trx | 100% pass | CI | Actions | 14d | Not yet collected |
| EV-AB-008 | Playwright Chromium functional | CI | Report | Pass | CI | Actions | 14d | Not yet collected |
| EV-AB-009 | Playwright Firefox functional | CI | Report | Pass | CI | Actions | 14d | Not yet collected |
| EV-AB-010 | Playwright WebKit functional | CI | Report | Pass | CI | Actions | 14d | Not yet collected |
| EV-AB-011 | Axe critical violations | CI | JSON | 0 critical | CI | Actions | 14d | Not yet collected |
| EV-AB-012 | Axe serious violations | CI | JSON | 0 serious | CI | Actions | 14d | Not yet collected |
| EV-AB-013 | Keyboard matrix | Playwright + Notes | MD | Spec complete | CI | Actions | 14d | Not yet collected |
| EV-AB-014 | NVDA transcripts | Scripted | Files | Match approved script | Release | Repo | Permanent | Not yet collected |
| EV-AB-015 | Narrator transcripts | Scripted | Files | Match approved script | Release | Repo | Permanent | Not yet collected |
| EV-AB-016 | JAWS transcripts | Scripted | Files | Match or waiver | Release | Repo | Permanent | Not yet collected |
| EV-AB-017 | Forced Colors validation | PW emulate | PNG | Borders and states visible | CI | Actions | 14d | Not yet collected |
| EV-AB-018 | High Contrast validation | Manual/CI | PNG | Indicators visible | Release | A11Y | Permanent | Not yet collected |
| EV-AB-019 | Dark Mode validation | PW | PNG | Theme tokens render correctly | CI | Actions | 14d | Not yet collected |
| EV-AB-020 | RTL validation | PW | PNG + Report | RTL and keyboard verified | CI | Actions | 14d | Not yet collected |
| EV-AB-021 | Density validation | PW/bUnit | Report | Compact/Comfortable verified | CI | Actions | 14d | Not yet collected |
| EV-AB-022 | Fixed mode scroll | PW | Report | Remains visible | CI | Actions | 14d | Not yet collected |
| EV-AB-023 | Sticky mode scroll | PW | Report | Behaves per spec | CI | Actions | 14d | Not yet collected |
| EV-AB-024 | Overflow interaction | PW | Report | Spec-compliant open/close/Escape | CI | Actions | 14d | Not yet collected |
| EV-AB-025 | Overflow SSR behavior | PW + SSR | Log | SSR safe; Interactive measured | CI | Actions | 14d | Not yet collected |
| EV-AB-026 | Focus restore after overflow | bUnit + PW | Report | Spec keyboard rules | CI | Actions | 14d | Not yet collected |
| EV-AB-027 | Icon-only accessible names | bUnit + Axe | Report | aria-label present | CI | Actions | 14d | Not yet collected |
| EV-AB-028 | SSR/Hydrate validation | PW | Log | No hydration mismatch | CI | Actions | 14d | Not yet collected |
| EV-AB-029 | Console errors | PW | Capture | 0 runtime errors | CI | Actions | 14d | Not yet collected |
| EV-AB-030 | data-testid contract | bUnit + PW | Report | Spec hooks present | CI | Actions | 14d | Not yet collected |
| EV-AB-031 | DisposeAsync teardown | bUnit | TRX | No throw; cleanup complete | CI | Actions | 14d | Not yet collected |
| EV-AB-032 | Memory leak cycles | Lab | Notes | No severe leak | Nightly | Actions | 14d | Not yet measured |
| EV-AB-033 | Initial render performance | Lab | Metrics | Median/P95 documented | Nightly | Evidence | Permanent | Not yet measured |
| EV-AB-034 | Resize/overflow performance | Lab | Metrics | Median/P95 documented | Nightly | Evidence | Permanent | Not yet measured |
| EV-AB-035 | Stretch ≥100 actions | Lab | Metrics | Documented or deferred | Nightly | Evidence | Permanent | Not yet measured |
| EV-AB-036 | API review | Human | Checklist | Approved | PR | GitHub | Permanent | Not yet collected |
| EV-AB-037 | XML doc review | Human | Checklist | Approved | PR | GitHub | Permanent | Not yet collected |
| EV-AB-038 | Spec ↔ TEST-MATRIX traceability | Human | Matrix | Complete; no orphans | Release | Repo | Permanent | Not yet collected |
| EV-AB-039 | Samples execute (SMP-01–06) | CI/Manual | Notes | All samples execute | Release | Samples | Permanent | Not yet collected |
| EV-AB-040 | Visual baselines (V-AB-001–020) | PR/CI | PNG | Accepted diffs only | Nightly | Repo | 30d | Not yet collected |
| EV-AB-041 | Reuse matrix audit | Review | Notes | Respected | PR | GitHub | Permanent | Not yet collected |
| EV-AB-042 | Commercial package audit | CI Audit | refs.txt | No commercial refs | CI | Actions | 14d | Not yet collected |
| EV-AB-043 | CSS isolation active | Integration | Report | Isolation attribute present | CI | Actions | 14d | Not yet collected |
| EV-AB-044 | Cross-browser matrix | CI | Reports | Chromium, Firefox, WebKit pass | CI | Actions | 14d | Not yet collected |
| EV-AB-045 | Viewport validation | PW | Report | 320/375/768/1024/1440 validated | CI | Actions | 14d | Not yet collected |
| EV-AB-046 | OnItemClick event | bUnit | TRX | Fires with expected args | CI | Actions | 14d | Not yet collected |
| EV-AB-047 | Overflow event order | bUnit | TRX | Opened/Closed sequence valid | CI | Actions | 14d | Not yet collected |
| EV-AB-048 | 400% zoom reflow | PW | PNG | Usable, no critical loss | CI | Actions | 14d | Not yet collected |
| EV-AB-049 | Fixed-mode offset contract | Sample/PW | Notes | Documented and demonstrated | Release | Samples | Permanent | Not yet collected |
| EV-AB-050 | Release approval | Sign-off | Approval | Approved/Waiver | Release | GitHub | Permanent | Not yet collected |

---

## 4. Collection Process

1. Run build, analyzer, AOT, trim, and warning validation from TEST-MATRIX L6.
2. Execute AppBar unit and integration tests (`U-AB-*`, `I-AB-*`).
3. Execute Playwright tests across Chromium, Firefox, and WebKit.
4. Execute Axe validation on all ten required routes.
5. Generate keyboard matrix artifact.
6. Collect NVDA, Narrator, and JAWS scripted transcripts.
7. Generate visual baselines (V-AB-001–020).
8. Record performance metrics only when actual measurements exist.
9. Audit Toolkit primitive reuse and dependency compliance.
10. Never invent values. Use **Not yet collected** or **Not yet measured** until evidence exists.

---

## 5. Runtime Record

| Suite | Result |
|---------|---------|
| Build (0 errors) | Not yet collected |
| Analyzer / Nullable / CS1591 | Not yet collected |
| AOT | Not yet collected |
| Trimming | Not yet collected |
| bUnit (L1/L2) | Not yet collected |
| Playwright Chromium | Not yet collected |
| Playwright Firefox | Not yet collected |
| Playwright WebKit | Not yet collected |
| Axe (Critical/Serious) | Not yet collected |
| Keyboard Matrix | Not yet collected |
| Visual Snapshots | Not yet collected |
| Console Errors | Not yet collected |
| SSR/Hydrate | Not yet collected |
| Performance | Not yet measured |
| Memory Leak Analysis | Not yet measured |
| NVDA Transcripts | Not yet collected |
| Narrator Transcripts | Not yet collected |
| JAWS Transcripts | Not yet collected |

---

## 6. Accessibility Evidence Map

| Requirement | Spec ID | Automated Evidence | SR / Visual Evidence | Status |
|-------------|---------|--------------------|----------------------|--------|
| Toolbar semantics | S-AB-A11Y-01 | EV-AB-011, EV-AB-012, EV-AB-007 | EV-AB-014–016 | Not yet collected |
| Landmark header/footer | S-AB-A11Y-02 | EV-AB-011, EV-AB-012 | EV-AB-014–016 | Not yet collected |
| Keyboard navigation | S-AB-A11Y-03 | EV-AB-013, EV-AB-008–010 | EV-AB-014–016 | Not yet collected |
| Focus visibility | S-AB-A11Y-04 | EV-AB-013, EV-AB-040 | EV-AB-018 | Not yet collected |
| Accessible names | S-AB-A11Y-05 | EV-AB-027, EV-AB-011 | EV-AB-014–016 | Not yet collected |
| High Contrast | S-AB-A11Y-06 | EV-AB-011 | EV-AB-018 | Not yet collected |
| Forced Colors | S-AB-A11Y-07 | EV-AB-017 | — | Not yet collected |
| Reduced Motion | S-AB-A11Y-08 | EV-AB-007 / CSS contract | Notes | Not yet collected |
| RTL | S-AB-A11Y-09 | EV-AB-020, EV-AB-012 | EV-AB-014–016 | Not yet collected |
| Not Combobox | S-AB-A11Y-10 | EV-AB-011, EV-AB-041 | — | Not yet collected |

---

## 7. Sample Coverage Status

| Sample | Route | Status |
|---------|---------|---------|
| SMP-01 Default | `/appbar/default` | Not yet collected |
| SMP-02 Responsive & Overflow | `/appbar/responsive` (+ overflow variant) | Not yet collected |
| SMP-03 Navigation | `/appbar/navigation` | Not yet collected |
| SMP-04 Templates | `/appbar/templates` | Not yet collected |
| SMP-05 Fixed vs Sticky | `/appbar/fixed-sticky` | Not yet collected |
| SMP-06 States & Accessibility | `/appbar/states` | Not yet collected |

**Constraint:** Catalog remains **exactly 6 samples**. Axe routes must map to these samples or query variants and must not introduce additional catalog entries.

---

## 8. Toolkit Primitive Reuse Status

| Rule | Expected | Status |
|--------|----------|--------|
| Commands use SfButton | MUST | Not yet collected |
| Icon-only via SfButton + IconCss | MUST | Not yet collected |
| SfButtonGroup for grouped actions | SHOULD | Not yet collected |
| No SfMenu hard dependency | MUST | Not yet collected |
| SfAvatar not required | Template-only identity | Not yet collected |
| SfThemeRoot integration | MUST | Not yet collected |
| SfTooltip on icon-only usage | SHOULD | Not yet collected |
| No commercial Syncfusion.Blazor packages | MUST NOT | Not yet collected |
| CSS Isolation | MUST | Not yet collected |

---

## 9. Traceability Status

| Traceability Artifact | Status |
|----------------------|--------|
| PRD Goals G-01–G-15 ↔ Spec IDs | Runtime verification not yet collected |
| API.md members ↔ Tests | Execution proof not yet collected |
| TEST-MATRIX exit criteria | CI proof not yet collected |
| Samples ↔ Axe ↔ Snapshots | Execution proof not yet collected |
| EV-AB Evidence Catalog ↔ Artifacts | Not yet collected |

> When filling after CI, update only **Status** and **Result** fields. Do not fabricate metrics or outcomes.

---

## 10. Notes (Fill After Implementation)

- Record intentional axe exclusions and compensating tests.
- Record disabled-item keyboard policies if applicable- [ ] Required EV-AB CI items collected (or formally waived)
- [ ] NVDA transcript collected (EV-AB-014)
- [ ] Narrator transcript collected (EV-AB-015)
- [ ] JAWS collected or waived (EV-AB-016)
- [ ] No open P0 issues
- [ ] No open P1 accessibility issues without waiver
- [ ] TEST-MATRIX exit criteria satisfied
- [ ] Specification Definition of Done satisfied
- [ ] Exactly 6 samples available and executable
- [ ] Public API frozen
- [ ] XML documentation complete
- [ ] 0 CS1591 warnings
- [ ] 0 AOT warnings
- [ ] 0 Trim warnings
- [ ] 0 Analyzer warnings
- [ ] Toolkit primitive reuse validated
- [ ] Two maintainer approvals
- [ ] EV-AB-050 sign-off completed

---

## 12. Sign-off

| Role | Name | Date | Result |
|--------|--------|--------|--------|
| Implementing Engineer | | | |
| Reviewer | | | |
| Accessibility Reviewer | | | |
| Release Owner | | | |

**Result Values**

- `Approved`
- `Approved with waiver`
- `Blocked`

*Do not pre-fill names, dates, or results.*

---

## 13. Document History

| Version | Date | Changes |
|---------|------|---------|
| 1.0 | *TBD* | Initial AppBar evidence template aligned to Toolkit evidence rules (no invented results) |

---

### Rule Reminder

| Status Value | When To Use |
|--------------|-------------|
| **Not yet collected** | Test, review, or artifact not executed |
| **Not yet measured** | Performance or memory metrics not available |
| **Collected** | Artifact exists and pass criteria evaluated |
| **Measured** | Numerical evidence attached |
| **Waived** | Written waiver linked in Notes and Sign-off |

> **Never invent results.**
> Evidence status may only be updated using actual collected artifacts.