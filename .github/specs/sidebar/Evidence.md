# SfSidebar evidence

| Field | Value |
| --- | --- |
| Component | `SfSidebar` |
| Specs compared | Toolkit Sidebar specs, version 2.1, under `.github/specs/sidebar/` (`Spec.md`, `API.md`, `API-xml.md`, `PRD.md`, `TEST-MATRIX.md`, `sample-preparer.md`, `competitive-matrix.md`) |
| Implementation branch | `bc/200a8e4a-act-system-architect` at `ad64700b9610af68ae39c81056a8ecc1cfaca494` |
| Source | `src/Components/Navigations/Sidebar/` |
| Method | Source read of the named files, then commands run in this session |
| Date | 2026-11-06 |

**Verdict: Passed for the commands that ran.** Behaviour, visual compare, bUnit, and axe passed in this session. JAWS was not run. A passing axe scan does not prove WCAG 1.4.3: every Sidebar scan disables `color-contrast` and `color-contrast-enhanced`. The library build from the earlier part of this session still stands; it was not repeated after the notes markup.

---

## 1. Toolkit behaviour

| ID | Requirement | Evidence | Result |
| --- | --- | --- | --- |
| M-O1 | Overlay is the default mode and floats over content | `SidebarMode.Overlay` is the first enum value. Default `Mode` is `Overlay`. `U-MODE-001` is in the 172 passing bUnit tests | Passed |
| M-P1 | Push shifts the target | `SidebarMode.Push`. `P-UI-006` and `P-CFG-004` passed in Playwright | Passed |
| M-S1 | Shrink shares the container with the target | `SidebarMode.Shrink`. `P-UI-007` and `P-CFG-005` passed | Passed |
| M-N1 | Mini rail is optional and closed by default | `EnableMini` default false. `U-OPEN-003` in the passing bUnit set | Passed |
| M-N2 | Mini rail stays visible to assistive technology while closed | `e-sidebar-mini`. `P-UI-008` passed | Passed |
| M-O2 | Open overlay uses `e-sidebar-open` | Class in `SfSidebar.razor.css`. `P-UI-001` passed | Passed |
| M-O5 | Backdrop click closes an overlay | `U-UIX-001` in the passing bUnit set. `P-UI-004` passed | Passed |
| M-O6 | Escape closes while focus is in the host | `CloseOnEscape` default true. `P-KB-007` passed | Passed |
| P1 | `Start` follows `dir` | `P-RTL-001` passed (right edge in rtl) | Passed |
| P4 | Physical `Left` and `Right` do not flip in rtl | `SidebarPosition.Left` / `Right` stay physical. `P-POS-003` and `P-POS-004` passed | Passed |
| R1 | `Responsive` plus `Breakpoint.Md` (768) switches to overlay | `P-VP-005` passed (767 mobile, 768 desktop) | Passed |
| A1 | Modal overlay is `role="dialog"` | `ROLE_DIALOG` when `IsModal`. `P-KB-004` passed | Passed |
| A2 | Docked panel is `role="navigation"` | `ROLE_NAVIGATION` (`navigation`) in source. Spec §8.1 and the source win over `API.md` text that says `complementary` | Passed |
| A5 | Accessible notes for the panel | `SfSidebar.razor` sets `aria-describedby` to `{panelId}-notes` and renders that notes element. `P-INTG-008` passed | Passed |
| NG1–NG6 | Data-bound items, persistence, AppBar clipping, first-party menu, mandatory layout parent | Spec §12 excludes these from v1 | Deferred |
| PRD G6 | Same notes requirement as A5 | Same source and `P-INTG-008` | Passed |

---

## 2. Public API

| Item | Evidence | Result |
| --- | --- | --- |
| Methods `OpenAsync`, `CloseAsync`, `ToggleAsync`, `FocusAsync` | `SfSidebar.razor.Methods.cs`. `P-API-013` through `P-API-018` passed | Passed |
| Events `IsOpenChanged`, `OnOpened`, `OnClosed`, `OnBreakpointChanged` | `SfSidebar.razor.Events.cs`. `P-EVT-011` through `P-EVT-016` passed | Passed |
| Templates `HeaderTemplate`, `ChildContent`, `FooterTemplate`, `TargetContent` | `SfSidebar.razor`. `P-CFG-010` passed | Passed |
| Defaults: Overlay, Start, Width `"280px"`, Fixed true, EnableAnimation true | Component parameter defaults | Passed (source) |
| `SidebarEventArgs` has `IsOpen`, `Mode`, `Trigger` only | `EventModels.cs`. `Cancel` is absent from the type and from `src/PublicAPI.Shipped.txt` | Passed (source) |
| No `show` / `hide` | No such public methods | Passed (source) |
| `Id` is on `div.e-sidebar` | Markup in `SfSidebar.razor` | Passed (source) |
| `OpenMiniOnHover` | Public parameter. `P-HOV-001` through `P-HOV-007` passed | Passed |

---

## 3. Samples and tests

| ID | Item | Evidence | Result |
| --- | --- | --- | --- |
| SMP-CAT | Catalog page | `Pages/Components/Navigations/Sidebar.razor` routes `/navigations/sidebar` and `/navigations/sidebar/close-on-navigate` | Passed (source) |
| SMP-ROUTE | `sample-preparer.md` catalog route | `/navigations/sidebar` | Passed (source) |
| SMP-DEMOS | Demos | Default, Modes, MiniRail, Positions, Responsive, InteractionControls, DualSidebars, Api, and `DarkThemeDemo` | Passed (source) |
| UT | bUnit | `dotnet test tests/Syncfusion.Blazor.Toolkit.BUnitTest/Syncfusion.Blazor.Toolkit.BUnitTest.csproj -c Release --filter FullyQualifiedName~Navigations.SfSidebar` | Passed — 172 passed, 0 failed, 0 skipped, net8.0, 3 s |
| UT-TFM | net10.0 bUnit | The bUnit project `TargetFrameworks` is `net8.0` only | Not configured |
| PW | Playwright behaviour | `npx playwright test` on `sidebar.spec.ts`, Chromium, retries 0 | Passed — 129 passed, 0 failed, 1.4 m |
| VIS | Visual specs | `sidebar.visual.spec.ts`, Chromium. Baselines were written, then the file was run again without `--update-snapshots` | Passed — 24 passed, 0 failed, 19.3 s |
| AXE | Sidebar axe methods | `dotnet test accessibility/Blazor.Toolkit.AxeCore.Tests/Blazor.Toolkit.AxeCore.Tests.csproj -c Release --filter FullyQualifiedName~SidebarTests` against `http://localhost:5001`. The committed helper still says port 5000 | Passed — 25 passed, 0 failed, 2 m 35 s, net10.0. Contrast rules disabled, so this does not prove WCAG 1.4.3 |
| AXE-006 | Dark theme | `DarkOpen.razor` at `/sidebar/dark-open` and `Sidebar_dark_open`, included in the 25 | Passed. Not waived. Does not prove WCAG 1.4.3 |
| SR-NVDA | NVDA | User-reported manual check recorded in `.github/accessibility/screen-reader-smoke.md` | Passed |
| SR-NARR | Narrator | Same user report | Passed |
| SR-JAWS | JAWS | Not claimed | Not run |

The new behaviour file covers `P-API-013`–`018`, `P-EVT-011`–`016`, `P-UI-013`–`021`, `P-CFG-001`–`011`, `P-POS-001`–`006`, `P-VP-007`–`016`, `P-MQ-001`–`003`, `P-GES-001`–`008`, `P-HOV-003`–`007`, `P-KB-010`–`018`, `P-ANI-005`–`009`, and `P-INTG-001`–`009`. Those IDs are in the 129 passing tests. `P-INTG-007` and `P-INTG-009` exercise a second control beside the Sidebar; they do not render a second `SfSidebar`. `P-CFG-011` checks an empty target region, not a missing target element. The component still renders `.e-sidebar-target` when `TargetContent` is set.

---

## 4. Runtime record (this session)

| Command | Result |
| --- | --- |
| `dotnet build src/Syncfusion.Blazor.Toolkit.csproj -c Release` | Passed earlier in this session. net8.0, net9.0, and net10.0. 0 error lines. No `Navigations/Sidebar` warning lines. Not repeated after the notes markup. |
| bUnit filter `FullyQualifiedName~Navigations.SfSidebar` | Passed. 172 / 0 / 0 on net8.0, 3 s. Repeated after the notes markup. |
| Playwright `sidebar.spec.ts` | Passed. 129 / 0, 1.4 m. Host `http://localhost:5000`. |
| Playwright `sidebar.visual.spec.ts` without snapshot update | Passed. 24 / 0, 19.3 s, after a separate `--update-snapshots` run wrote the Linux Chromium baselines. |
| Axe `SidebarTests` | Passed. 25 / 0 / 0 on net10.0, 2 m 35 s. Host `http://localhost:5001`. |

---

## 5. Notes that are not component failures

| Item | Note |
| --- | --- |
| Docked role | Spec §8.1 and source use `navigation`. `API.md` wording `complementary` is the losing text. The role string was not renamed. |
| `Id` | Rendered on `div.e-sidebar`, not the host. |
| Notes | The notes element is the description. `aria-describedby` only points at its id. Both are required. |
| Gestures | Implemented and covered as compatibility. Spec §12 excludes swipe from the v1 contract. |
| Visual baselines | The confirming run compared pixels. It was not a missing-file failure. |
| CSS fallbacks | `SfSidebar.razor.css` uses `--color-sf-*` and also hex fallbacks (`#fff`, `#dee2e6`). |
| Axe contrast | Disabled in every Sidebar method, including `Sidebar_dark_open` and the 18 additional route cases. |
| bUnit TFM | net10.0 cannot be selected. net8.0 is the project's only target. |
| Dark catalog demo | `DarkThemeDemo` is still in the catalog. Removing only that demo was not done in this pass. |

---

## 6. Counts

| Bucket | Count | Meaning |
| --- | --- | --- |
| Section 1 Passed | 16 | Behaviour rows matched to source and a passing test in this session |
| Section 1 Deferred | 1 | NG1–NG6 as one row |
| Public API rows Passed | 8 | Section 2 |
| Commands Passed | 4 | bUnit, behaviour, visual compare, axe. The earlier library build is recorded separately and was not repeated |
| Commands not configured | 1 | bUnit net10.0 |
| Manual Passed | 2 | NVDA, Narrator |
| Manual not run | 1 | JAWS |

**Implemented:** v1 modes, positions, responsive breakpoint, open/close API, events, templates, mini rail, fixed/backdrop, animation, forced-colors CSS, panel notes, catalog samples, bUnit, Playwright behaviour, 24 visual baselines, and 25 axe cases.

**Deferred:** data-bound items, persistence, AppBar clipping, first-party menu, mandatory layout parent.

**Not run:** JAWS. net10.0 bUnit (project does not target it). The library build was not repeated after the notes markup.
