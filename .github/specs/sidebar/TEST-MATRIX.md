# SfSidebar — Test Matrix
## Syncfusion® Toolkit for Blazor

| Field | Value |
|-------|--------|
| **Component** | `SfSidebar` |
| **Namespace** | `Syncfusion.Blazor.Toolkit` |
| **Spec version** | 2.1 (with §4.5 `Fixed` and `BackdropClass` added) |
| **Matrix version** | 2.0 |
| **Goal** | Full automated coverage; CI is the release gate; no mandatory manual tests |
| **Primary tools** | xUnit, bUnit, Playwright, axe-core, `dotnet build` |

---

## 1. How to use this matrix

Every ID below is a **real test**. It appears in the title of exactly one bUnit `DisplayName` (or is listed in it when one test proves several rows) or one Playwright `test(...)` title, so `grep` finds the implementation of any row. A row without an implemented test is not coverage and is listed in section 14 instead.

| Column | Meaning |
|--------|---------|
| **ID** | Stable identifier. Matches the test name. |
| **Spec ref** | Rule code or section in `Spec.md`, or `API.md` where noted. |
| **Priority** | P0 blocker · P1 required for GA · P2 stretch. |
| **Status** | ✅ passed in the recorded run · ❌ failed or unmet · ⏸ not run (reason given). |

**CI policy:** All **P0** and **P1** must be ✅ before merge. **P2** is tracked but non-blocking.

**Recorded run** (Linux sandbox, .NET SDK 10.0.403, Playwright 1.64.1 Node / 1.58 .NET): statuses below come from that run. Nothing marked ✅ was inferred.

---

## 2. Layer summary

| Layer | Tooling | Tests | Recorded result |
|-------|---------|-------|-----------------|
| L1 Unit / component | xUnit + bUnit | 136 IDs in 2 files (169 test cases incl. theory rows) | 169 passed, 0 failed (`--filter Sidebar`, net10.0) |
| L2 Integration | bUnit + fakes | 5 | included in the 169 |
| L3 UI E2E | Playwright | 129 behaviour tests, Chromium only in this session | 129 passed, 0 failed (2026-11-06) |
| L4 A11y scans | Playwright .NET + axe-core | 25 Sidebar axe cases | 25 passed, 0 failed (2026-11-06). Contrast rules disabled. |
| L5 Visual regression | Playwright screenshots | 24 Chromium Linux baselines | 24 passed on the confirming compare (2026-11-06) |
| L6 Build / static | `dotnet build`, API dump | 3 | see section 10 |

The 16 skipped Playwright cases are the 7 visual rows on Firefox and WebKit (baselines are Chromium-only) ×2 = 14, plus forced-colors on Firefox and WebKit (Chromium-only emulation) = 2.

---

## 3. Environment matrix (applies to L3–L5)

| Dimension | Values | Run |
|-----------|--------|-----|
| Browser | Chromium, Firefox, WebKit | All three for L3. Chromium only for L5 and forced colors. |
| Viewport | 375×667, 768×800, 1280×720 | As each test specifies. |
| `dir` | `ltr`, `rtl` | RTL tests. |
| Color scheme | light and one dark page | Dark route `/sidebar/dark-open` (`P-AXE-006`). |
| Forced colors | `forced-colors: active` (Chromium) | P-FC-001. |
| TFM | net10.0 | Run. net8.0 and net9.0 compile in the multi-target build; the bUnit net8.0 target was **not run** here. |
| Animation | `EnableAnimation=false` in fixtures except the timing page | Yes. |

---

## 4. data-testid contract (consumer-owned sample elements only)

The component emits no `data-testid` (U-API-005). Fixtures set these on elements they own:

| testid | Element |
|--------|---------|
| `sidebar-toggle` | Toolkit `SfButton` that opens and closes |
| `sidebar-nav-link` | Navigation link used for `CloseOnNavigate` |
| `main-focusable` | Toolkit `SfButton` in the target content |

Component-owned regions are selected by their public classes.

---

## 5. L1 / L2 — bUnit matrix

### 5.1 API surface

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-API-001 | Added parameters expose the documented defaults | API.md Parameters | bUnit | P0 | ✅ |
| U-API-002 | SidebarBreakpoint has the documented values in order | §6.1 | bUnit | P0 | ✅ |
| U-API-003 | Breakpoint thresholds are exact widths | §6.1 | bUnit | P0 | ✅ |
| U-API-004 | SidebarEventArgs carries IsOpen and Mode and keeps the compatibility members | §7.3 | bUnit | P0 | ✅ |
| U-API-005 | The component never emits data-testid | §2 | bUnit | P0 | ✅ |
| U-API-006 | Legacy members stay on the public surface | API.md Compatibility | bUnit | P0 | ✅ |
| U-API-007 | Enum zero values are the parameter defaults | API.md Enums | bUnit | P0 | ✅ |

### 5.2 Rendering and structure

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-REN-001 | Sidebar renders closed with documented defaults | §2 | bUnit | P0 | ✅ |
| U-REN-002 | Templates and target render only when supplied | §3.1 | bUnit | P0 | ✅ |
| U-REN-003 | Templates and target render only when supplied | §3.1 | bUnit | P0 | ✅ |
| U-REN-004 | Templates and target render only when supplied | §3.1 | bUnit | P0 | ✅ |
| U-REN-005 | Templates and target render only when supplied | §3.2.A | bUnit | P0 | ✅ |
| U-REN-006 | No TargetContent renders no target host | §3.2.B | bUnit | P0 | ✅ |
| U-REN-007 | An explicit Id lands on the panel and stays there across re-renders | §2 | bUnit | P0 | ✅ |
| U-REN-008 | CssClass is appended to the sidebar element | §2 | bUnit | P1 | ✅ |
| U-REN-009 | HtmlAttributes render safe attributes and never overwrite owned ones | §2 | bUnit | P1 | ✅ |
| U-REN-010 | BackdropClass is appended to the backdrop only | M-B1 | bUnit | P1 | ✅ |
| U-REN-011 | A null or blank BackdropClass appends nothing | M-B1 | bUnit | P1 | ✅ |
| U-REN-012 | BackdropClass never decides whether the backdrop renders | M-B2 | bUnit | P1 | ✅ |
| U-REN-013 | Fixed toggles the fixed positioning hook and nothing structural | M-F1, M-F2, M-F3 | bUnit | P1 | ✅ |
| U-REN-014 | An omitted Id is generated once and a later value replaces it | §12 | bUnit | P1 | ✅ |

### 5.3 Modes

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-MODE-001 | Mode drives sidebar and container classes | M-O1 | bUnit | P0 | ✅ |
| U-MODE-002 | Mode drives sidebar and container classes | M-P1 | bUnit | P0 | ✅ |
| U-MODE-003 | Mode drives sidebar and container classes | M-S1 | bUnit | P0 | ✅ |
| U-MODE-004 | A runtime Mode change replaces the mode class | §4 | bUnit | P0 | ✅ |
| U-MODE-005 | Open modal overlay is a modal dialog and the target is inert | M-O2 | bUnit | P0 | ✅ |
| U-MODE-006 | Overlay without backdrop is not modal | M-O2 | bUnit | P0 | ✅ |
| U-MODE-007 | Docked rendering uses navigation semantics without a backdrop | M-P2 | bUnit | P0 | ✅ |

### 5.4 Open state, mini and events

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-OPEN-001 | Open sidebar carries the open hooks | §4.4 | bUnit | P0 | ✅ |
| U-OPEN-002 | Sidebar renders closed with documented defaults | M-N1 | bUnit | P0 | ✅ |
| U-OPEN-003 | Mini rail keeps a closed sidebar visible to assistive technology | M-N2 | bUnit | P0 | ✅ |
| U-OPEN-004 | A user close raises IsOpenChanged with false | O1 | bUnit | P0 | ✅ |
| U-OPEN-005 | OpenAsync, CloseAsync and ToggleAsync change the state | §7.2 | bUnit | P0 | ✅ |
| U-OPEN-006 | OpenAsync, CloseAsync and ToggleAsync change the state | §7.2 | bUnit | P0 | ✅ |
| U-OPEN-007 | OpenAsync, CloseAsync and ToggleAsync change the state | §7.2 | bUnit | P0 | ✅ |
| U-OPEN-008 | IsEnabled=false ignores a backdrop activation | O2, §12 | bUnit | P0 | ✅ |
| U-OPEN-009 | OnOpened fires after the state change and carries the applied state and trigger | O4, §7.3 | bUnit | P1 | ✅ |
| U-OPEN-010 | A one-way IsOpen without a callback is not written back | O4 | bUnit | P0 | ✅ |
| U-OPEN-011 | The occupied-width variable follows the state | §4.4, §9.2 | bUnit | P0 | ✅ |
| U-OPEN-012 | Two-way binding follows parent changes without raising events | O1 | bUnit | P0 | ✅ |
| U-OPEN-013 | No-op changes raise no events and IsOpenChanged only fires on a real change | §7.2 | bUnit | P0 | ✅ |
| U-OPEN-014 | An unrelated parent re-render keeps an internally changed state | O1 | bUnit | P0 | ✅ |
| U-OPEN-016 | OnClosed fires after the state change and carries the applied state and trigger | §7.3 | bUnit | P0 | ✅ |

### 5.5 Event timing, animation and cancellation

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-EVT-001 | OnOpened and OnClosed carry the resulting IsOpen and the effective Mode | §7.3 | bUnit | P0 | ✅ |
| U-EVT-002 | With animation active OnOpened waits for Duration | §7.3 (4) | bUnit | P0 | ✅ |
| U-EVT-003 | A newer state change cancels the pending callback | §7.3 (4) | bUnit | P0 | ✅ |
| U-EVT-004 | Reduced motion raises the callback immediately | §7.3 (3) | bUnit | P0 | ✅ |
| U-EVT-005 | A reduced-motion change at runtime applies to the next change | §7.3 (3) | bUnit | P0 | ✅ |
| U-EVT-006 | Dispose cancels a pending callback | §11 | bUnit | P0 | ✅ |
| U-EVT-007 | A zero Duration raises the callback immediately | §7.3 | bUnit | P0 | ✅ |
| U-EVT-008 | The global animation option raises the callback immediately | §7.3 (3) | bUnit | P0 | ✅ |
| U-EVT-009 | Rapid toggles settle on the last state with one callback | §7.3, §12 | bUnit | P0 | ✅ |
| U-EVT-010 | A change inside IsOpenChanged supersedes the outer callback | §7.3 | bUnit | P0 | ✅ |

### 5.6 Position and direction

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-POS-001 | Physical and logical positions resolve to an edge | P1 | bUnit | P0 | ✅ |
| U-POS-002 | Physical and logical positions resolve to an edge | P4 | bUnit | P0 | ✅ |
| U-POS-003 | Physical and logical positions resolve to an edge | P2 | bUnit | P0 | ✅ |
| U-POS-004 | Physical and logical positions resolve to an edge | P2 | bUnit | P0 | ✅ |
| U-POS-005 | Physical and logical positions resolve to an edge | P3 | bUnit | P0 | ✅ |
| U-POS-006 | Physical and logical positions resolve to an edge | P3 | bUnit | P0 | ✅ |
| U-POS-007 | A host direction of rtl resolves logical positions and a later change re-resolves them | §5, P2 | bUnit | P0 | ✅ |
| U-POS-008 | Physical positions ignore the host direction | P1, P4 | bUnit | P0 | ✅ |

### 5.7 Responsive state machine

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-RES-001 | Responsive=false keeps Mode on a narrow viewport | R4 | bUnit | P0 | ✅ |
| U-RES-002 | Below the breakpoint the effective mode is Overlay | R1 | bUnit | P0 | ✅ |
| U-RES-003 | Crossing to mobile while open closes with IsOpenChanged then OnClosed | R2 | bUnit | P0 | ✅ |
| U-RES-004 | Crossing to desktop never opens the panel | R3 | bUnit | P0 | ✅ |
| U-RES-005 | OnBreakpointChanged reports true below and false at or above the breakpoint | R1 | bUnit | P0 | ✅ |
| U-RES-006 | Dispose removes the listeners and later changes do nothing | R4, §11 | bUnit | P0 | ✅ |
| U-RES-007 | A narrow viewport on load starts closed and reports through the open-state pair | R1 | bUnit | P0 | ✅ |
| U-RES-008 | The active threshold is registered for every Breakpoint value | §6.1 | bUnit | P0 | ✅ |
| U-RES-009 | Breakpoint=Always and None never fall back to Overlay | R4 | bUnit | P0 | ✅ |
| U-RES-010 | Changing Breakpoint or Responsive at runtime updates the registered threshold | §6.2 | bUnit | P0 | ✅ |
| U-RES-011 | Event Mode is the effective mode on a narrow viewport | §7.3 | bUnit | P0 | ✅ |

### 5.8 IsEnabled gating

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-ENA-001 | IsEnabled=false ignores a backdrop activation | O2, M-O5 | bUnit | P0 | ✅ |
| U-ENA-002 | IsEnabled=false ignores Escape | O2, M-O6 | bUnit | P0 | ✅ |
| U-ENA-003 | IsEnabled=false ignores hover expansion | O2, M-N3 | bUnit | P0 | ✅ |
| U-ENA-004 | IsEnabled=false ignores swipe gestures | O2, §12 | bUnit | P0 | ✅ |
| U-ENA-005 | IsEnabled=false still honors the public methods | O2 | bUnit | P0 | ✅ |
| U-ENA-006 | IsEnabled=false still applies a new IsOpen value | O2 | bUnit | P0 | ✅ |
| U-ENA-007 | Escape on the host closes an overlay when enabled | M-O6 | bUnit | P0 | ✅ |

### 5.9 Mini hover

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-HOV-001 | Hover expands a collapsed mini rail visually and collapses on leave | M-N3 | bUnit | P1 | ✅ |
| U-HOV-002 | A touch pointer does not trigger hover expansion | M-N3 | bUnit | P1 | ✅ |
| U-HOV-003 | Hover does nothing without EnableMini or OpenMiniOnHover | M-N3 | bUnit | P1 | ✅ |
| U-HOV-004 | Hover does not apply on a mobile viewport | M-N3 | bUnit | P1 | ✅ |
| U-HOV-005 | An explicit open clears the hover state and stays open on leave | M-N3 | bUnit | P1 | ✅ |

### 5.10 Navigation close

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-NAV-001 | A bound sidebar closes on navigation by default with IsOpenChanged before OnClosed | O3 | bUnit | P0 | ✅ |
| U-NAV-002 | CloseOnNavigate=false never closes, even when bound or when the legacy flag is on | O3 | bUnit | P0 | ✅ |
| U-NAV-003 | Dispose unsubscribes from location changes | §11 | bUnit | P0 | ✅ |
| U-NAV-004 | Without a bound callback the component does not subscribe | O3 | bUnit | P0 | ✅ |
| U-NAV-005 | Switching CloseOnNavigate off at runtime removes the subscription | O3 | bUnit | P0 | ✅ |

### 5.11 Accessibility attributes

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-A11Y-001 | Open modal overlay is a modal dialog and the target is inert | A2, §8.1 | bUnit | P0 | ✅ |
| U-A11Y-002 | Open modal overlay is a modal dialog and the target is inert | §8.1 | bUnit | P0 | ✅ |
| U-A11Y-003 | Explicit Role and AriaLabel win over the defaults | A1 | bUnit | P0 | ✅ |
| U-A11Y-004 | AriaLabelledBy renders aria-labelledby and replaces the default label | A1 | bUnit | P0 | ✅ |
| U-A11Y-005 | A fully closed panel is hidden and an open or mini panel is not | §8.2 | bUnit | P0 | ✅ |
| U-A11Y-006 | Docked rendering uses navigation semantics without a backdrop | §8.1 | bUnit | P0 | ✅ |
| U-A11Y-007 | Explicit Role and AriaLabel win over the defaults | A2 | bUnit | P1 | ✅ |
| U-A11Y-008 | Open modal overlay is a modal dialog and the target is inert | §8.2 | bUnit | P0 | ✅ |
| U-A11Y-009 | AriaLabel and AriaLabelledBy can be set together | A1 | bUnit | P0 | ✅ |
| U-A11Y-010 | The panel never emits aria-expanded or aria-controls | A3 | bUnit | P0 | ✅ |
| U-A11Y-011 | HtmlAttributes cannot override aria-labelledby | A1 | bUnit | P0 | ✅ |
| U-A11Y-012 | The backdrop is not focusable and has no accessible name | §2, §8.2 | bUnit | P0 | ✅ |
| U-A11Y-013 | State changes are announced through a polite live region | §8 (shipped live region) | bUnit | P0 | ✅ |

### 5.12 Focus (script contract)

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-FOC-001 | The panel is programmatically focusable | §8.3 | bUnit | P1 | ✅ |
| U-FOC-002 | FocusAsync is safe before and after the first render and never changes state | §7.2 | bUnit | P1 | ✅ |
| U-FOC-003 | Opening a modal overlay starts the focus-entry script | §8.3, M-O7 | bUnit | P1 | ✅ |
| U-FOC-004 | Closing a modal overlay asks the script to restore focus to the opener | §8.3 | bUnit | P1 | ✅ |
| U-FOC-005 | Push and Shrink never start the focus trap | M-P3, M-S2 | bUnit | P1 | ✅ |
| U-FOC-006 | An overlay without a backdrop never starts the focus trap | M-O4 | bUnit | P1 | ✅ |
| U-FOC-007 | FocusAsync asks the script to focus the first focusable descendant | §7.2 | bUnit | P1 | ✅ |
| U-FOC-008 | Dispose ends the modal focus behavior without restoring focus | §11 | bUnit | P1 | ✅ |
| U-FOC-010 | Opening a docked sidebar does not steal focus | §8.3 | bUnit | P1 | ✅ |

### 5.13 CSS variables and animation hook

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-CSS-001 | Width, MiniWidth and Duration reach the host as variables | §9.2 | bUnit | P1 | ✅ |
| U-CSS-002 | A negative Duration is exposed as 0ms | §9.2 | bUnit | P1 | ✅ |
| U-CSS-003 | The host style holds only the four published variables | §2, §9.2 | bUnit | P2 | ✅ |
| U-CSS-004 | Unsafe CSS lengths fall back to the defaults | §9.2 (shipped sanitiser) | bUnit | P1 | ✅ |
| U-CSS-005 | calc() lengths are accepted | §9.2 | bUnit | P1 | ✅ |
| U-CSS-006 | Disabling global animation adds the no-animation hook | §9.1 | bUnit | P1 | ✅ |

### 5.14 Static rendering

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-SSR-001 | Markup is complete from parameters without any script | §10 | bUnit | P1 | ✅ |

### 5.15 User dismissal

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-UIX-001 | Backdrop click closes the sidebar with the Backdrop trigger | M-O5 | bUnit | P0 | ✅ |
| U-UIX-002 | CloseOnOverlayClick=false ignores a backdrop click and leaves Escape working | M-O5 | bUnit | P0 | ✅ |
| U-UIX-003 | Escape closes an open sidebar and other keys do not | M-O6 | bUnit | P0 | ✅ |
| U-UIX-004 | CloseOnOverlayClick=false ignores a backdrop click and leaves Escape working | M-O6 | bUnit | P0 | ✅ |

### 5.16 Legacy members (compatibility)

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-LEG-001 | A touch swipe toward the content opens a left sidebar and back closes it | §12 (legacy) | bUnit | P1 | ✅ |
| U-LEG-002 | Mouse drags and EnableGestures=false never change the state | §12 (legacy) | bUnit | P1 | ✅ |
| U-LEG-003 | A cancelled pointer discards the swipe start | §12 (legacy) | bUnit | P1 | ✅ |
| U-LEG-004 | A matching media query opens the sidebar and a non-match closes it | API.md Compatibility | bUnit | P1 | ✅ |
| U-LEG-006 | An unchanged media-query match raises no events | API.md Compatibility | bUnit | P1 | ✅ |
| U-LEG-007 | CloseOnNavigate closes an open sidebar with the Navigation trigger | API.md Compatibility | bUnit | P1 | ✅ |
| U-LEG-008 | CloseOnNavigate leaves a closed sidebar unchanged | API.md Compatibility | bUnit | P1 | ✅ |
| U-LEG-010 | Without two-way binding location changes are ignored | API.md Compatibility | bUnit | P1 | ✅ |

### 5.17 Internal layout helpers

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| U-LAY-001 | SidebarLayout.ResolveToRight handles every position | §5 | bUnit | P1 | ✅ |
| U-LAY-002 | SidebarLayout.GetSwipeResult interprets gestures | §12 (legacy) | bUnit | P1 | ✅ |


## 6. L2 — Integration

These run in the same bUnit project with fakes.

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| I-INT-001 | Two instances with distinct Ids render both panels | M-P4 | bUnit | P1 | ✅ |
| I-INT-002 | One hundred toggles finish in the toggled state | §12 | bUnit | P1 | ✅ |
| I-INT-003 | With animation off OnOpened is raised without waiting | §7.3 | bUnit | P1 | ✅ |
| I-INT-004 | Null templates render safely with an empty body | §3.1, §12 | bUnit | P1 | ✅ |
| I-INT-005 | Missing Id generates one stable identifier per instance | §12 | bUnit | P1 | ✅ |

---

## 7. L3 — Playwright UI matrix

Fixture routes are under `/sidebar/*` in `tests/Syncfusion.Blazor.Playwright.Test/Blazor.Toolkit.Playwright.Samples`. The suite runs on Chromium, Firefox and WebKit through the shared Playwright config.

### 7.1 Core interaction

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| P-UI-001 | Open overlay: panel visible and e-sidebar-open | M-O1, M-O2 | Playwright ×3 browsers | P0 | ✅ |
| P-UI-002 | Backdrop closes the overlay | M-O5 | Playwright ×3 browsers | P0 | ✅ |
| P-UI-003 | Escape closes the overlay | M-O6 | Playwright ×3 browsers | P0 | ✅ |
| P-UI-004 | CloseOnOverlayClick=false keeps the overlay open | M-O5 | Playwright ×3 browsers | P0 | ✅ |
| P-UI-005 | CloseOnEscape=false keeps the overlay open | M-O6 | Playwright ×3 browsers | P0 | ✅ |
| P-UI-006 | Push offsets the target by the width | M-P1 | Playwright ×3 browsers | P0 | ✅ |
| P-UI-007 | Shrink reduces the target width by the width | M-S1 | Playwright ×3 browsers | P0 | ✅ |
| P-UI-008 | Mini rail occupies MiniWidth | M-N2, M-S3 | Playwright ×3 browsers | P0 | ✅ |
| P-UI-009 | Mini expands to Width | §4.4 | Playwright ×3 browsers | P0 | ✅ |
| P-UI-010 | Imperative ToggleAsync flips the state | §7.2 | Playwright ×3 browsers | P1 | ✅ |
| P-UI-011 | CloseOnNavigate closes after following a link | O3 | Playwright ×3 browsers | P0 | ✅ |
| P-UI-012 | IsEnabled=false ignores Escape and backdrop | O2 | Playwright ×3 browsers | P0 | ✅ |

### 7.2 Keyboard and focus

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| P-KB-001 | Focus enters the panel on open | M-O7, §8.3 | Playwright ×3 browsers | P0 | ✅ |
| P-KB-002 | Tab from the last focusable wraps to the first | §8.3 | Playwright ×3 browsers | P0 | ✅ |
| P-KB-003 | Shift+Tab from the first focusable wraps to the last | §8.3 | Playwright ×3 browsers | P0 | ✅ |
| P-KB-004 | Closing restores focus to the opener | §8.3 | Playwright ×3 browsers | P0 | ✅ |
| P-KB-005 | Focus never reaches main content while modal | §8.3 | Playwright ×3 browsers | P0 | ✅ |
| P-KB-006 | Push does not trap focus | M-P3 | Playwright ×3 browsers | P0 | ✅ |
| P-KB-007 | Escape from a docked Push panel closes it | §4.1 (Escape, docked) | Playwright ×3 browsers | P0 | ✅ |
| P-KB-008 | Closing by backdrop restores focus to the opener | §8.3 | Playwright ×3 browsers | P0 | ✅ |
| P-KB-009 | The consumer toggle exposes aria-expanded and aria-controls | A3 | Playwright ×3 browsers | P0 | ✅ |

### 7.3 Responsive viewports

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| P-VP-001 | Desktop keeps Push | R4 | Playwright ×3 browsers | P0 | ✅ |
| P-VP-002 | Mobile load uses Overlay and starts closed | R1 | Playwright ×3 browsers | P0 | ✅ |
| P-VP-003 | Resizing to mobile auto-closes and reports the breakpoint | R2, R1 | Playwright ×3 browsers | P0 | ✅ |
| P-VP-004 | Resizing to desktop never opens the panel | R3 | Playwright ×3 browsers | P0 | ✅ |
| P-VP-005 | The threshold is exact: 767px is mobile and 768px is desktop | §6.1 | Playwright ×3 browsers | P0 | ✅ |
| P-VP-006 | Event Mode reports the effective mode | §7.3 | Playwright ×3 browsers | P0 | ✅ |

### 7.4 RTL

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| P-RTL-001 | Start docks to the physical right in rtl | P2 | Playwright ×3 browsers | P0 | ✅ |
| P-RTL-002 | End docks to the physical left in rtl | P3 | Playwright ×3 browsers | P0 | ✅ |
| P-RTL-003 | An rtl overlay opens on the correct edge | P2 | Playwright ×3 browsers | P1 | ✅ |
| P-RTL-004 | A runtime dir change re-resolves a logical position | §5 | Playwright ×3 browsers | P0 | ✅ |

### 7.5 Dual sidebar

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| P-DUAL-001 | Start and End Push panels do not overlap | M-P4 | Playwright ×3 browsers | P1 | ✅ |

### 7.6 Fixed and BackdropClass

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| P-FIX-001 | Fixed=false positions the panel and backdrop inside the host | M-F2, M-F3 | Playwright ×3 browsers | P0 | ✅ |
| P-FIX-002 | Fixed=true positions the panel and backdrop against the viewport | M-F2, M-F3 | Playwright ×3 browsers | P0 | ✅ |
| P-FIX-003 | BackdropClass lands on the backdrop element only | M-B1, M-B2 | Playwright ×3 browsers | P0 | ✅ |

### 7.7 Mini hover

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| P-HOV-001 | Pointer hover expands the rail and leaving collapses it | M-N3 | Playwright ×3 browsers | P1 | ✅ |
| P-HOV-002 | Keyboard focus does not expand the rail | M-N3 | Playwright ×3 browsers | P1 | ✅ |

### 7.8 Animation and reduced motion

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| P-ANI-001 | OnOpened waits for the Duration when animated | §7.3 (4) | Playwright ×3 browsers | P1 | ✅ |
| P-ANI-002 | Reduced motion raises OnOpened without waiting | §7.3 (3), §9.1 | Playwright ×3 browsers | P1 | ✅ |
| P-ANI-003 | A close before the Duration elapses cancels the OnOpened callback | §7.3 (4) | Playwright ×3 browsers | P1 | ✅ |
| P-ANI-004 | Reduced motion removes the transition | §9.1 | Playwright ×3 browsers | P1 | ✅ |

### 7.9 Forced colors

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| P-FC-001 | Focus is visible with an outline in forced-colors mode | §9.1 | Playwright (Chromium) | P2 | ✅ |

### 7.10 Lab coverage added 2026-11-06

These rows run on `/sidebar/lab` in Chromium. The 2026-11-06 `sidebar.spec.ts` run passed 129 / 0, which includes the earlier 42 behaviour tests and these 87. Firefox and WebKit were not run.

| ID | Scenario | Spec ref | Automation | Priority | Status |
|----|----------|----------|------------|----------|--------|
| P-API-013–018 | Open, close, toggle, and focus methods, including no duplicate event | API.md | Playwright Chromium | P0 | Passed 2026-11-06 |
| P-EVT-011–016 | Opened, closed, and breakpoint event text | §7.3 | Playwright Chromium | P0 | Passed 2026-11-06 |
| P-UI-013–021 | Backdrop, escape, navigate, gesture, and unrelated-key options | §6 | Playwright Chromium | P1 | Passed 2026-11-06 |
| P-CFG-001–011 | Width, mini width, calc, CssClass, HtmlAttributes, and slots | API.md | Playwright Chromium | P1 | Passed 2026-11-06 |
| P-POS-001–006 | Physical left and right in LTR and RTL | §5 | Playwright Chromium | P0 | Passed 2026-11-06 |
| P-VP-007–016 | Breakpoint and viewport changes | §6 | Playwright Chromium | P1 | Passed 2026-11-06 |
| P-MQ-001–003 | Media query open, close, and clear | §6 | Playwright Chromium | P1 | Passed 2026-11-06 |
| P-GES-001–008 | Touch swipe open and close, including guards | §12 compatibility | Playwright Chromium | P2 | Passed 2026-11-06 |
| P-HOV-003–007 | Hover guards for touch, mobile, disabled, push, and shrink | M-N3 | Playwright Chromium | P1 | Passed 2026-11-06 |
| P-KB-010–018 | Focus candidates, modal tab, and announcements | §8 | Playwright Chromium | P0 | Passed 2026-11-06 |
| P-ANI-005–009 | Duration, reduced motion, and global animation off | §7.3, §9 | Playwright Chromium | P1 | Passed 2026-11-06 |
| P-INTG-001–009 | Button, group, text, checkbox, switch, popup, and second control | §11 | Playwright Chromium | P1 | Passed 2026-11-06 |

### 7.11 Browser cross-check

All P0 rows above pass on all three browsers.

| Suite | Chromium | Firefox | WebKit |
|-------|----------|---------|--------|
| P-UI-* | ✅ | ✅ | ✅ |
| P-KB-* | ✅ | ✅ | ✅ |
| P-VP-* | ✅ | ✅ | ✅ |
| P-RTL-* | ✅ | ✅ | ✅ |
| P-FIX-* | ✅ | ✅ | ✅ |

---

## 8. L4 — Accessibility scan matrix (axe)

Generated by `gulp create-cs` from `accessibility/config.json` into `accessibility/Blazor.Toolkit.AxeCore.Tests/Tests/SidebarTests.cs` (6 pages; the repository cap is 10). Rule tags are the repository's full set (WCAG 2.0/2.1/2.2 A–AAA, best-practice, section508); only the repository's two colour-contrast exclusions apply and the Sidebar allowlist is empty.

| ID | Scenario | Route | Generated test method | Spec ref | Priority | Status |
|----|----------|-------|-----------------------|----------|----------|--------|
| P-AXE-001 | Overlay closed | `/sidebar/overlay` | `SidebarTests.Sidebar_overlay` | §8.4 | P0 | ✅ 0 violations |
| P-AXE-002 | Overlay open, named dialog | `/sidebar/overlay-open` | `SidebarTests.Sidebar_overlay_open` | A1, §8.4 | P0 | ✅ 0 violations |
| P-AXE-003 | Push expanded | `/sidebar/push-open` | `SidebarTests.Sidebar_push_open` | §8.4 | P0 | ✅ 0 violations |
| P-AXE-004 | Mini rail | `/sidebar/mini` | `SidebarTests.Sidebar_mini` | §8.4 | P0 | ✅ 0 violations |
| P-AXE-005 | RTL overlay open | `/sidebar/rtl-open` | `SidebarTests.Sidebar_rtl_open` | §8.4 | P0 | ✅ 0 violations |
| P-AXE-007 | Shrink expanded | `/sidebar/shrink-open` | `SidebarTests.Sidebar_shrink_open` | §8.4 | P1 | ✅ 0 violations |
| P-AXE-006 | Dark theme | `/sidebar/dark-open` | `SidebarTests.Sidebar_dark_open` | §9 | P2 | Passed 2026-11-06. 0 violations with contrast rules disabled. Does not prove WCAG 1.4.3. |
| P-AXE-008 | End position open | `/sidebar/end-open` | `SidebarTests.Sidebar_additional_routes` (`end-open`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-009 | Hover mini rail | `/sidebar/hover` | `Sidebar_additional_routes` (`hover`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-010 | No backdrop | `/sidebar/no-backdrop` | `Sidebar_additional_routes` (`no-backdrop`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-011 | Modal focus route | `/sidebar/overlay-open` | `Sidebar_additional_routes` (`modal-focus`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-012 | Push focus route | `/sidebar/push-open` | `Sidebar_additional_routes` (`push-focus`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-013 | Shrink focus route | `/sidebar/shrink-open` | `Sidebar_additional_routes` (`shrink-focus`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-014 | Mini focus route | `/sidebar/mini` | `Sidebar_additional_routes` (`mini-focus`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-015 | RTL focus route | `/sidebar/rtl-open` | `Sidebar_additional_routes` (`rtl-focus`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-016 | Dark focus route | `/sidebar/dark-open` | `Sidebar_additional_routes` (`dark-focus`) | §8.4 | P2 | Passed 2026-11-06. Contrast rules disabled. Does not prove WCAG 1.4.3. |
| P-AXE-017 | Closed focus route | `/sidebar/overlay` | `Sidebar_additional_routes` (`closed-focus`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-018 | End escape route | `/sidebar/end-open` | `Sidebar_additional_routes` (`end-escape`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-019 | Hover keys route | `/sidebar/hover` | `Sidebar_additional_routes` (`hover-keys`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-020 | Plain keys route | `/sidebar/no-backdrop` | `Sidebar_additional_routes` (`plain-keys`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-021 | Live region, overlay open | `/sidebar/overlay-open` | `Sidebar_additional_routes` (`live-open`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-022 | Live region, push open | `/sidebar/push-open` | `Sidebar_additional_routes` (`live-push`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-023 | Notes on mini rail | `/sidebar/mini` | `Sidebar_additional_routes` (`notes-mini`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-024 | Notes in RTL | `/sidebar/rtl-open` | `Sidebar_additional_routes` (`notes-rtl`) | §8.4 | P1 | Passed 2026-11-06. Contrast rules disabled. |
| P-AXE-025 | Notes on dark page | `/sidebar/dark-open` | `Sidebar_additional_routes` (`notes-dark`) | §8.4 | P2 | Passed 2026-11-06. Contrast rules disabled. Does not prove WCAG 1.4.3. |

The panel is a `div`, so axe reports no violations on the six scanned routes.

A scan loads a URL and does not click, so open states use routes that render already open.

---

## 9. L5 — Visual regression matrix

Baselines: `tests/Syncfusion.Blazor.Playwright.Test/Blazor.Toolkit.playwright.Test/Navigations/Sidebar/baselines/chromium/`. Tolerance `maxDiffPixelRatio 0.005`. The baselines were recorded from this implementation in this run and then compared on a second run; they were reviewed by eye for two states and not against an independent design reference. Updates go through a dedicated PR.

| ID | Snapshot | Route | Viewport | dir | Priority | Status |
|----|----------|-------|----------|-----|----------|--------|
| P-VIS-001 | `overlay-closed` | `/sidebar/overlay` | 1280×720 | ltr | P1 | ✅ |
| P-VIS-002 | `overlay-open` | `/sidebar/overlay-open` | 1280×720 | ltr | P1 | ✅ |
| P-VIS-003 | `push-open` | `/sidebar/push-open` | 1280×720 | ltr | P1 | ✅ |
| P-VIS-004 | `shrink-open` | `/sidebar/shrink-open` | 1280×720 | ltr | P1 | ✅ |
| P-VIS-005 | `mini` | `/sidebar/mini` | 1280×720 | ltr | P1 | ✅ |
| P-VIS-006 | `rtl-overlay-open` | `/sidebar/rtl-open` | 1280×720 | rtl | P1 | ✅ |
| P-VIS-007 | `mobile-overlay-open` | `/sidebar/overlay-open` | 375×667 | ltr | P1 | ✅ confirming compare, 2026-11-06 |
| P-VIS-008 | `hover-expanded` | `/sidebar/hover` | 1280×720 | ltr | P1 | ✅ confirming compare, 2026-11-06 |
| P-VIS-009 | `end-open` | `/sidebar/lab` | 1280×720 | ltr | P1 | ✅ confirming compare, 2026-11-06 |
| P-VIS-010 | `rtl-right` | `/sidebar/lab` | 1280×720 | rtl | P1 | ✅ confirming compare, 2026-11-06 |
| P-VIS-011 | `responsive-desktop` | `/sidebar/responsive` | 1280×720 | ltr | P1 | ✅ confirming compare, 2026-11-06 |
| P-VIS-012 | `responsive-mobile` | `/sidebar/responsive` | 375×667 | ltr | P1 | ✅ confirming compare, 2026-11-06. Closed at the mobile breakpoint. |
| P-VIS-013 | `fixed-open` | `/sidebar/fixed` | 1280×720 | ltr | P1 | ✅ confirming compare, 2026-11-06 |
| P-VIS-014 | `inflow-open` | `/sidebar/fixed` | 1280×720 | ltr | P1 | ✅ confirming compare, 2026-11-06 |
| P-VIS-015 | `custom-width` | `/sidebar/lab` | 1280×720 | ltr | P2 | ✅ confirming compare, 2026-11-06 |
| P-VIS-016 | `focus-visible` | `/sidebar/overlay-open` | 1280×720 | ltr | P1 | ✅ confirming compare, 2026-11-06 |
| P-VIS-017 | `reduced-motion` | `/sidebar/overlay-open` | 1280×720 | ltr | P1 | ✅ confirming compare, 2026-11-06 |
| P-VIS-018 | `forced-colors` | `/sidebar/overlay-open` | 1280×720 | ltr | P1 | ✅ confirming compare, 2026-11-06 |
| P-VIS-019 | `mini-open` | `/sidebar/mini` | 1280×720 | ltr | P1 | ✅ confirming compare, 2026-11-06 |
| P-VIS-020 | `dual-start` | `/sidebar/dual` | 1280×720 | ltr | P2 | ✅ confirming compare, 2026-11-06 |
| P-VIS-021 | `dual-both` | `/sidebar/dual` | 1280×720 | ltr | P2 | ✅ confirming compare, 2026-11-06 |
| P-VIS-022 | `animation-off` | `/sidebar/lab` | 1280×720 | ltr | P2 | ✅ confirming compare, 2026-11-06 |
| P-VIS-023 | `slots` | `/sidebar/lab` | 1280×720 | ltr | P2 | ✅ confirming compare, 2026-11-06 |
| P-VIS-024 | `scrolled-body` | `/sidebar/lab` | 1280×720 | ltr | P2 | ✅ confirming compare, 2026-11-06 |

---

## 10. L6 — Build and static quality

| ID | Scenario | Expected | Spec ref | Priority | Status |
|----|----------|----------|----------|----------|--------|
| B-BLD-001 | `dotnet build` of the library, all three TFMs | 0 Sidebar warnings, 0 errors | §13.9, PRD G10 | P0 | ✅ 0 Sidebar warnings, 0 errors. The 29 other warnings are outside the Sidebar. |
| B-BLD-002 | Public surface equals `PublicAPI.Shipped.txt` | Match | API.md | P2 | ✅ for net10.0, compared with the gate's own dumper. The PowerShell gate script itself failed to run on Linux (see section 14). |
| B-BLD-003 | Nullable annotations | No new CS86xx in Sidebar files | §13.9 | P1 | ✅ none reported for Sidebar files |

---

## 11. Coverage targets

Coverage was **not measured** in this run (`coverage-diff` gate not run). The targets stay as recommendations.

| Metric | Target | Gate |
|--------|--------|------|
| Statement coverage on `SfSidebar` + related types | ≥ 85% | Recommended |
| Branch coverage on open/close/responsive paths | ≥ 75% | Recommended |
| L3 P0 tests × 3 browsers | 100% pass | Required — met |

---

## 12. Spec rule → test ID index

| Spec rule / section | Test IDs |
|---------------------|----------|
| M-O1–M-O7 | U-MODE-001/005/006, U-UIX-001–004, P-UI-001–005, P-KB-001–005, P-KB-008 |
| M-P1–M-P4 | U-MODE-002/007, P-UI-006, P-KB-006, P-DUAL-001, I-INT-001 |
| M-S1–M-S3 | U-MODE-003, P-UI-007, P-UI-008 |
| M-N1–M-N3 | U-OPEN-002/003, P-UI-008/009, U-HOV-*, P-HOV-* |
| M-F1–M-F3, M-B1–M-B2 | U-REN-010–013, P-FIX-001–003 |
| P1–P4 | U-POS-001–008, P-RTL-001–004 |
| R1–R4 | U-RES-001–011, P-VP-001–006 |
| O1–O4 | U-OPEN-004–017, U-NAV-001–005, U-ENA-*, P-UI-010–012 |
| A1–A3, §8.3 | U-A11Y-001–013, U-FOC-*, P-KB-*, P-AXE-* |
| §7.3 timing | U-EVT-001–010, I-INT-003, P-ANI-001–003 |
| §9 CSS / motion / forced colors | U-CSS-*, P-ANI-004, P-FC-001, P-VIS-* |
| §10 SSR | U-SSR-001 |
| §11 Lifecycle | U-RES-006, U-NAV-003, U-EVT-006, U-FOC-008 |
| §12 Edge cases | U-OPEN-008, I-INT-002, I-INT-004, I-INT-005, P-UI-012 |

---

## 13. Sample routes

| Route | Supports |
|-------|----------|
| `/sidebar/overlay`, `/sidebar/overlay-open` | P-UI, P-KB, P-AXE-001/002, P-VIS-001/002/007 |
| `/sidebar/push`, `/sidebar/push-open` | P-UI-006, P-KB-006/007, P-AXE-003, P-VIS-003 |
| `/sidebar/shrink`, `/sidebar/shrink-open` | P-UI-007, P-AXE-007, P-VIS-004 |
| `/sidebar/mini`, `/sidebar/hover` | P-UI-008/009, P-HOV, P-AXE-004, P-VIS-005 |
| `/sidebar/responsive` | P-VP-* |
| `/sidebar/rtl`, `/sidebar/rtl-open` | P-RTL-*, P-AXE-005, P-VIS-006 |
| `/sidebar/dual` | P-DUAL-001 |
| `/sidebar/fixed` | P-FIX-* |
| `/sidebar/navigate` | P-UI-011 |
| `/sidebar/options`, `/sidebar/timing` | P-UI-004/005/010/012, P-ANI-* |
| `/sidebar/lab` | P-API-013–018, P-EVT-011–016, P-UI-013–021, P-CFG-001–011, P-POS-001–006, P-VP-007–016, P-MQ-001–003, P-GES-001–008, P-HOV-003–007, P-KB-010–018, P-ANI-005–009, P-INTG-001–009 |
| `/sidebar/end-open`, `/sidebar/hover`, `/sidebar/no-backdrop` | P-AXE-008–025 reuse these with the earlier routes |

Playwright fixtures are separate from the dedicated accessibility samples. The accessibility pages are the six under `accessibility/Blazor.Toolkit.Accessibility.Samples/Components/Pages/Sidebar/` (limit: 10).

---

## 14. Not covered, waived, or failing

| Item | State | Reason |
|------|-------|--------|
| P-AXE-006 dark theme | Passed | 2026-11-06 axe scan of `/sidebar/dark-open` reported 0 violations. Contrast rules stayed disabled, so this does not prove WCAG 1.4.3. |
| NVDA and Narrator | Passed | User-reported manual check, 2026-11-06, recorded in `.github/accessibility/screen-reader-smoke.md`. |
| JAWS | Not run | Not part of that check. |
| net10.0 bUnit target | Not configured | The bUnit project targets net8.0 only. net8.0 Sidebar filter passed 172/172 on 2026-11-06. |
| Coverage, mutation, `vulnerable-packages`, `secrets` (gitleaks) and `harness.py gate run` | ⏸ not run | Tooling absent or the harness could not run here (see the T-005 Log). |
| `scripts/check-public-api.ps1` | ⏸ not run to completion | Fails on Linux while loading `Microsoft.AspNetCore.Components`; the surface was compared with the same dumper outside it. |
| Full bUnit project | ❌ 101 failures, all outside the Sidebar | Identical to the base commit apart from one extra failure there; see the T-005 Log. |

---

## 15. Definition of done (matrix)

| Criterion | State |
|-----------|-------|
| Completeness | Every row has an implemented test, except the items in section 14. |
| CI green | **Not claimed.** 2026-11-06 session: bUnit 172 passed / 0 failed (net8.0 only); Playwright behaviour 129 passed / 0 failed (Chromium); visual compare 24 passed / 0 failed after Linux Chromium baselines were written; axe 25 passed / 0 failed with contrast rules disabled (does not prove WCAG 1.4.3). The earlier Release library build had 0 errors. Firefox and WebKit were not run. NVDA and Narrator were reported passed; JAWS was not run. |
| No manual gate | The PR template requires none for the Sidebar; PRD G6 still lists SR notes as evidence. |
| Traceability | Spec rules map to IDs in section 12. |
