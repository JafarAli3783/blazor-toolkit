# SfToolbar — Spec Evidence

| Field | Value |
|-------|--------|
| **Component** | `SfToolbar` family |
| **Specs compared** | `Spec.md` 2.0, `API.md`, `PRD.md` 2.0, `TEST-MATRIX.md` 2.0, `COVERAGE.md`, `MANUAL-VALIDATION.md` |
| **Source** | `src/Components/Navigations/Toolbar/` |
| **Date** | 2026-11-10 |
| **Document version** | 3.0 |
| **Status** | Review record only. Nothing in this file is **Implemented** unless a check in this revision measured it. |

---

## Verdict

**Phase 1 (P0) code and automated coverage are green. Release sign-off is not complete.**

The P0 layers that this repository can run are now green: 343 bUnit methods pass, 70 Playwright tests pass (including the 17 visual baselines), and all 13 axe-core scans pass with zero critical or serious violations. The Toolbar sources compile with zero Toolbar warnings. The traceability gate reports every matrix scenario traced, and the traceability generator reports no findings.

What is still open is outside the code: the screen-reader scenarios have no named reviewer, the bUnit project still runs on one target framework, and the browser and render-mode matrices are not exercised. Those gaps are listed in section 6.

The `Spec.md` status column says **Implemented** or **Approved** for the registry rows. That column was not re-verified requirement by requirement here. This file overrides it for review: a `Spec.md` "Implemented" label is not evidence.

---

## 1. What was verified in this revision

### 1.1 Automated runs

| Layer | Command | Result |
|------|---------|--------|
| bUnit (Toolbar filter) | `dotnet test tests/Syncfusion.Blazor.Toolkit.BUnitTest/Syncfusion.Blazor.Toolkit.BUnitTest.csproj -f net8.0 -p:CycloneDxEnabled=false --filter "FullyQualifiedName~Toolbar"` | **343 passed, 0 failed, 0 skipped** |
| Playwright (Toolbar) | `npx playwright test tests/Syncfusion.Blazor.Playwright.Test/Blazor.Toolkit.playwright.Test/Navigations/Toolbar` | **70 passed, 0 failed** (Chromium) |
| Visual baselines | same run, `visual.spec.ts` | **17 passed, 0 failed** (V-TB-001 … V-TB-015 plus P-TB-026 and P-TB-027) |
| axe-core (Toolbar) | `dotnet test accessibility/Blazor.Toolkit.AxeCore.Tests/Blazor.Toolkit.AxeCore.Tests.csproj -c Release -p:CycloneDxEnabled=false --filter "FullyQualifiedName~Toolbar"` | **13 passed, 0 failed** |
| Library build | `dotnet build src/Syncfusion.Blazor.Toolkit.csproj -f net10.0 -p:CycloneDxEnabled=false` | **0 errors, 0 Toolbar warnings** |
| Traceability gate | `python3 .agent/tools/traceability.py --matrix .github/specs/Toolbar/TEST-MATRIX.md --tests tests --component SfTB` | **90 scenarios, 90 traced, 0 missing, 0 duplicate** |
| Traceability generator | `python3 scripts/traceability/generate_traceability.py --spec-dir .github/specs/Toolbar --prefix TB --tasks .agent/tasks --check` | **no findings, TRACEABILITY.md is current** |

The axe run uses the WCAG 2.2 AA tag set from ADR-007 (`wcag2a`, `wcag2aa`, `wcag21a`, `wcag21aa`, `wcag22aa`, `best-practice`). Each of the 12 ADR-010 routes asserts zero violations of any impact, and the assertions also check that no critical or serious violation exists.

### 1.2 Defects found and fixed in this revision

| Defect | Where | Fix |
|--------|-------|-----|
| `aria-allowed-attr` (critical) | `ToolbarItem.razor`, split wrapper | The split `<span>` carried `aria-haspopup` and `aria-expanded`. A generic element rejects both. The chevron button already owned them, so the span now carries no ARIA. |
| `aria-required-children` (critical) | `ToolbarItem.razor.cs`, nested menu | The nested `role="menu"` contained plain `<button>` elements. A menu only accepts `menuitem`, `menuitemradio` and `menuitemcheckbox` children, so a nested item now writes its role out. |
| `target-size` (serious) | `SfToolbar.razor.css`, chevron | The icon-glyph rule matched the icon-only chevron **button** as well as the glyph span, so the chevron collapsed to 14 × 24 px, under the 24 px minimum of WCAG 2.2 SC 2.5.8. The rule now targets `span.e-btn-icon` only, and the chevron renders at 32 × 32 px. |
| 13 compiler warnings | `SfToolbar.razor.Overflow.cs`, `ToolbarItem.razor.cs` | Dead code removed (`_rootElement`, `IsWrapMode`, `PopupEntryAttributes`), the attribute store turned into a property, the `Remove` results discarded, three `if` statements turned into conditional expressions, the collection expression applied, the unused `MouseEventArgs` parameter dropped, the switch made exhaustive, and `OpenMenuAsync` made synchronous. |
| `U-TB-018` failed with `DirectoryNotFoundException` | `ToolbarCompletionTests.cs` | The test read a staged copy of the stylesheet whose copy target was removed in commit `0975ca01b` while the test stayed. The test now reads the stylesheet from the repository, the same way the sibling script audit does. |
| `U-TB-025` Escape on the overflow button failed | `ToolbarOverflowTests.cs` | The test dispatched the key with bUnit's synchronous `KeyDown` and asserted the result immediately, so it read the state before the async close chain finished. It now uses `KeyDownAsync` and `WaitForAssertion`, matching the sibling Escape test that commit `66be1994a` already converted. |
| `U-TB-012` and `P-TB-015` asserted invalid ARIA | bUnit and Playwright tests | Both asserted `aria-expanded` on the split wrapper. They now read the chevron button, which is the element that owns the attribute. |
| Four matrix scenarios had no test naming them | `ToolbarVisualTests.cs` | The traceability gate reported `U-TB-101`, `U-TB-102`, `U-TB-103` and `U-TB-104` as missing. The behaviour was covered under the older ids `U-TB-021`, `U-TB-022` and `U-TB-050`, so those tests were renamed to the matrix ids, and two new tests were added for the nested-menu placement of `U-TB-102`. The gate now reports 90 of 90 traced, 0 missing and 0 duplicate. |
| `TB-OVF-051` had no acceptance criterion and no task | `ACCEPTANCE-CRITERIA.md`, `.agent/tasks/T-003.md` | The traceability generator reported two findings. A criterion `AC-TB-072` was added and the requirement was linked to task `T-003` next to `TB-OVF-050`. The generator now reports no findings. |
| 15 visual baselines stale | `visual.spec.ts-snapshots/` | The baselines predated the toolbar CSS fixes that narrowed the buttons. They were regenerated. One fixture, `#shot-overflow`, no longer triggered overflow at 420 px, so it was narrowed to 340 px. |
| `toolbar-overflow-scrollable` baseline stale again | `visual.spec.ts-snapshots/` | The chevron grew from 14 px to 32 px when the touch-target defect was fixed, so this one baseline was regenerated a second time. |

### 1.3 A known-flaky test in this environment

`P-TB-047` (`csp.spec.ts`) fails intermittently in a sandbox where the browser blocks WebSocket connections to `localhost`. The Blazor circuit then cannot start, and the framework's reconnection UI writes an inline style, which the page's strict `style-src 'self'` policy rejects. The console shows `net::ERR_BLOCKED_BY_LOCAL_NETWORK_ACCESS_CHECKS` and `Failed to start the transport 'WebSockets'`.

The failure is not attributable to the Toolbar. Measured over six consecutive runs of the same build:

| Build | Pass | Fail | WebSocket error present in every failure |
|-------|------|------|------------------------------------------|
| Baseline (`b67d640aa`, before this revision) | 3 | 3 | yes |
| This revision | 5 | 1 | yes |

Every failing run reported the WebSocket error; every passing run reported none. The Toolbar script itself never raises a violation, which is what `P-TB-047` actually asserts. The test is green when the circuit connects, which is the case on a normal CI host.

### 1.4 Requirements with direct automated evidence

The requirement ids below have a passing test in the runs above. The list covers the requirements whose verification layer this revision executed. It is not a re-verification of every registry row.

| Area | Requirements with a passing test in this revision |
|------|---------------------------------------------------|
| API | `TB-API-020`, `TB-API-030`, `TB-API-040`, `TB-API-050`, `TB-API-060`, `TB-API-070`, `TB-API-080`, `TB-API-090`, `TB-API-100`, `TB-API-110`, `TB-API-130`, `TB-API-140`, `TB-API-150`, `TB-API-160`, `TB-API-170`, `TB-API-180`, `TB-API-190`, `TB-API-200` |
| ITM | `TB-ITM-010`, `TB-ITM-020`, `TB-ITM-030`, `TB-ITM-040`, `TB-ITM-050`, `TB-ITM-060`, `TB-ITM-070`, `TB-ITM-080`, `TB-ITM-090`, `TB-ITM-100`, `TB-ITM-110`, `TB-ITM-120`, `TB-ITM-130`, `TB-ITM-140`, `TB-ITM-150`, `TB-ITM-160`, `TB-ITM-170` |
| OVF | `TB-OVF-010`, `TB-OVF-020`, `TB-OVF-030`, `TB-OVF-040`, `TB-OVF-050`, `TB-OVF-051`, `TB-OVF-060`, `TB-OVF-070`, `TB-OVF-080`, `TB-OVF-090`, `TB-OVF-120`, `TB-OVF-130`, `TB-OVF-140`, `TB-OVF-150`, `TB-OVF-160`, `TB-OVF-170` |
| KBD | `TB-KBD-010`, `TB-KBD-020`, `TB-KBD-030`, `TB-KBD-040`, `TB-KBD-050`, `TB-KBD-060`, `TB-KBD-070`, `TB-KBD-080`, `TB-KBD-090`, `TB-KBD-100`, `TB-KBD-120` |
| A11Y | `TB-A11Y-010`, `TB-A11Y-020`, `TB-A11Y-030`, `TB-A11Y-040`, `TB-A11Y-050`, `TB-A11Y-060`, `TB-A11Y-070`, `TB-A11Y-080`, `TB-A11Y-090`, `TB-A11Y-100`, `TB-A11Y-110`, `TB-A11Y-130` |
| RTL | `TB-RTL-010`, `TB-RTL-020`, `TB-RTL-030` |
| THM | `TB-THM-030`, `TB-THM-040`, `TB-THM-050` |
| ISO | `TB-ISO-020`, `TB-ISO-030`, `TB-ISO-040` |
| LIF | `TB-LIF-010`, `TB-LIF-020`, `TB-LIF-030`, `TB-LIF-040`, `TB-LIF-050`, `TB-LIF-060`, `TB-LIF-070`, `TB-LIF-080`, `TB-LIF-090`, `TB-LIF-100`, `TB-LIF-110` |
| SEC | `TB-SEC-010`, `TB-SEC-020`, `TB-SEC-030`, `TB-SEC-060`, `TB-SEC-070` |
| I18 | `TB-I18-010`, `TB-I18-020` |
| TST | `TB-TST-030`, `TB-TST-060` |

---

## 2. Requirement implementation status

161 unique requirement ids are in the `Spec.md` registry table. Counts by area:

| Area | Ids | This revision |
|------|-----|----------------|
| API | 26 | 18 verified by a passing test. The Phase 2 members (`TB-API-210` … `TB-API-260`) have passing tests but their public-API compatibility check was not run |
| ITM | 24 | 17 verified. `TB-ITM-180`, `TB-ITM-190`, `TB-ITM-200` and `TB-ITM-210` have passing tests; the three P2 rows have no test |
| OVF | 18 | 16 verified. `TB-OVF-100` and `TB-OVF-110` have passing tests but `TB-OVF-110` needs the interop audit of section 5 |
| KBD | 12 | 11 verified. `TB-KBD-110` is covered by the script audit in section 5 |
| A11Y | 16 | 12 verified. `TB-A11Y-140` and `TB-A11Y-160` are the manual screen-reader rows and are Pending |
| RTL | 5 | 3 verified. `TB-RTL-040` and `TB-RTL-050` need the CSS lint and the culture-change run |
| THM | 5 | 3 verified. `TB-THM-010` and `TB-THM-020` need the CSS lint |
| ISO | 5 | 3 verified. `TB-ISO-010` and `TB-ISO-050` need the CSS lint |
| LIF | 11 | 11 verified by the bUnit filter, except the render-mode rows that need a host |
| SEC | 7 | 5 verified. `TB-SEC-040` is covered by the script audit; `TB-SEC-050` needs the strict-CSP page |
| PRF | 6 | `TB-PRF-060` verified. The five performance budgets in `AC-TB-059` are recorded by `P-TB-049` but not asserted as thresholds |
| I18 | 2 | 2 verified |
| CMP | 10 | 0 verified. The framework, browser and render-mode matrices were not run |
| SMP | 6 | 0 verified against the Sample Browser. The 12 accessibility routes are verified by the axe run |
| TST | 8 | 2 verified. Coverage, bundle size and the traceability gate were not run |
| **Total** | **161** | |

The requirement-to-test links live in `COVERAGE.md`. `TRACEABILITY.md` is generated from that file and from the acceptance criteria.

Three registry ids have no row in `COVERAGE.md`: `TB-ITM-230`, `TB-ITM-240`, `TB-SMP-060`. They are P2 or Recommended rows, and they have no linked test case.

---

## 3. Test-case counts

Links are taken from `COVERAGE.md`.

| Layer | Linked scenarios | Run in this revision | Passed | Failed | Not run |
|-------|------------------|----------------------|--------|--------|---------|
| bUnit (`U-TB-*`, `I-TB-*`) | 90 | 343 methods in the Toolbar filter | 343 | 0 | — |
| Playwright (`P-TB-*`) | 54 | 53 | 53 | 0 | 1 (`P-TB-040`, the browser matrix) || Playwright axe (`P-AXE-TB-*`) | 12 | 13 test methods over the 12 routes | 13 | 0 | — |
| Visual (`V-TB-*`) | 15 | 17 (the 15 baselines plus P-TB-026 and P-TB-027) | 17 | 0 | — |
| Build (`B-TB-*`) | 8 | 2 | 2 | 0 | 6 |
| Manual (`SR-TB-*`) | 5 | 0 | — | — | 5 |

The bUnit layer is measured in methods, not scenario ids, because several scenarios have more than one method. The count is the method count returned by `dotnet test`.

The `B-TB-*` rows that ran are `B-TB-001` (0 Toolbar build warnings) and `B-TB-002` (0 CS1591 for Toolbar types). `B-TB-003` through `B-TB-008` were not run as checks; the underlying conditions are covered by the runs above but not asserted by a dedicated gate.

---

## 4. Public API

Types exist under `src/Components/Navigations/Toolbar/`. No public-API compatibility check against `src/PublicAPI.Shipped.txt` was run in this revision, so the `public-api-compat` gate is **Unverified**:

`SfToolbar`, `ToolbarItem`, `ToolbarGroup`, `ToolbarSeparator`, `ToolbarSpacer`, `ToolbarTemplateItem`, `ToolbarItemModel`, `ToolbarOverflowSettings`, `ToolbarTemplateContext`, `ToolbarItemClickEventArgs`, `ToolbarOrientation`, `ToolbarAlignment`, `ToolbarOverflowMode`, `ToolbarOverflowOption`, `ToolbarItemType`, `ToolbarItemDisplayMode`.

`IToolbarItem` and `ToolbarItemCollection` are internal, which `AC-TB-001` requires.

---

## 5. Not run

- The public-API compatibility check against the shipped baseline
- Firefox and WebKit. `playwright.config.ts` declares the Chromium project only, so `P-TB-040` and `TB-CMP-030` are unproven
- The WebAssembly, Auto and Static SSR hosts. `P-TB-041` … `P-TB-044` need those hosts
- `net9.0` and `net10.0` bUnit runs. The bUnit project still targets `net8.0` only (ADR-016, task `T-008`, blocked on a package-pin approval)
- The trimmed AOT publish and the IL-linker check (`B-TB-004`, `TB-CMP-050`, `TB-CMP-080`)
- The statement-coverage threshold and the public-member coverage check (`TB-TST-010`, `TB-TST-020`)
- The gzipped bundle-size check (`B-TB-006`, `TB-PRF-050`)
- The performance thresholds of `AC-TB-059`. `P-TB-049` records the timings but asserts no threshold
- The Sample Browser review of `/navigations/toolbar` and the navigation entries (task `T-009`, `TB-SMP-010`)
- The screen-reader rows of `MANUAL-VALIDATION.md`

### 5.1 Script audit

`U-TB-016` reads `src/wwwroot/scripts/toolbar.js` and asserts that the file contains `ResizeObserver` and `getBoundingClientRect` and does not contain `eval(`, `new Function` or `paddingLeft`. That test passes, so `TB-OVF-110` and `TB-SEC-040` hold for the shipped script.

---

## 6. Open work

| Item | Requirement | Why it is open |
|------|-------------|----------------|
| Name a reviewer for SR-TB-001 … SR-TB-005 | `TB-A11Y-140`, `TB-A11Y-160`, `TB-TST-080` | `MANUAL-VALIDATION.md` lists every scenario as "Unassigned" and "Pending". A P0 Pending scenario blocks release |
| Multi-target the bUnit project | `TB-CMP-010`, `TB-CMP-060`, `TB-TST-010`, `TB-TST-040` | The project targets `net8.0` only. ADR-016 requires `net8.0;net9.0;net10.0`. Task `T-008` is blocked on a package-pin approval |
| Add Firefox and WebKit projects | `TB-CMP-030`, `TB-CMP-090` | `playwright.config.ts` declares Chromium only |
| Run the WebAssembly, Auto and Static SSR hosts | `TB-CMP-020`, `TB-LIF-020`, `TB-LIF-050` | `P-TB-041` … `P-TB-044` need those hosts |
| Run the AOT publish and the trim check | `TB-CMP-050`, `TB-CMP-080` | Not run in this revision |
| Assert the performance budgets | `TB-PRF-010` … `TB-PRF-040` | `P-TB-049` records timings but asserts no threshold |
| Assert the bundle size | `TB-PRF-050` | No size check exists |
| Assert the coverage threshold | `TB-TST-010`, `TB-TST-020` | The 85 % statement threshold and the public-member check are not enforced |
| Review the Sample Browser | `TB-SMP-010`, `TB-SMP-060` | Task `T-009` is still open |
| Close the task ledger | — | `T-002` … `T-007` and `T-009` are open in `.agent/tasks/index.json` even though most of their content is on disk. `T-008` is blocked |

---

## 7. Document history

| Version | Date | Notes |
|---------|------|-------|
| 3.0 | 2026-11-10 | Full re-run. bUnit 343 passed and 0 failed. Playwright 70 passed. axe-core 13 passed with zero violations. Toolbar build warnings cleared to zero. Traceability gate 90 of 90 traced with 0 missing and 0 duplicate; the traceability generator reports no findings. Ten defects fixed, listed in section 1.2. Screen-reader, framework, browser and render-mode gaps recorded in section 6. |
| 2.3 | 2026-07-14 | Review record. 161 requirements, 0 marked implemented. bUnit filter 331 passed, 10 failed. Failed tests kept. Sample popup check recorded separately. |

**Next step:** assign a named reviewer to the five screen-reader scenarios, and unblock task `T-008` so the bUnit project can run on all three library frameworks.
