# SfToolbar acceptance criteria

Each criterion is written as Given, When, Then so a tool can check it. Every Must requirement in [Spec.md](Spec.md) appears in at least one criterion. [TRACEABILITY.md](TRACEABILITY.md) links criteria to tasks and tests.

| AC | Requirement | Criterion | Level |
| --- | --- | --- | --- |
| `AC-TB-001` | `TB-API-010`, `TB-API-190`, `TB-CMP-040` | Given the built Toolbar assembly, when the public API inventory runs, then `SfToolbar` is in `Syncfusion.Blazor.Toolkit`, `IToolbarItem` and `ToolbarItemCollection` are not public, and the diff against the shipped baseline contains only additions. | M |
| `AC-TB-002` | `TB-API-020`, `TB-API-030`, `TB-API-040` | Given a default `SfToolbar`, when it renders, then `Orientation` is `Horizontal`, `OverflowMode` is `Popup` and `Align` is `Start`. | M |
| `AC-TB-003` | `TB-API-050`, `TB-API-200`, `TB-ISO-040` | Given `CssClass="x"` and an unmatched attribute `data-a="1"`, when the toolbar renders, then the root element has class `x` and attribute `data-a="1"` and keeps the scope attribute. | M |
| `AC-TB-004` | `TB-API-060`, `TB-ITM-150` | Given an `OnClick` handler and an `OnItemClick` handler, when an item is clicked, then `OnClick` runs first and `OnItemClick` runs second with the matching `ItemId`. | M |
| `AC-TB-005` | `TB-API-070` | Given a rendered toolbar, when `RefreshOverflowAsync`, `FocusAsync`, `GetVisibleItems` and `GetOverflowItems` are called, then each completes without throwing and returns the documented type. | M |
| `AC-TB-006` | `TB-API-080`, `TB-API-120`, `TB-API-160`, `TB-API-170` | Given the public API inventory, when it is compared with `API.md`, then `SfToolbar` has no `Enabled`, `ToolbarGroup` has no template member, and all six enums match the documented members. | M |
| `AC-TB-007` | `TB-API-090`, `TB-API-100`, `TB-API-110`, `TB-API-130`, `TB-API-140` | Given each item component, when its parameters are listed by reflection in the test, then the documented parameters exist with the documented defaults and `@bind-Selected` compiles. | M |
| `AC-TB-008` | `TB-API-150`, `TB-ITM-160`, `TB-ITM-170`, `TB-ITM-050` | Given an `OnClick` handler that sets `Cancel=true`, when a Toggle item is clicked, then `Selected` is unchanged and `OnItemClick` still fires. | M |
| `AC-TB-009` | `TB-ITM-160` | Given an `OnClick` handler that sets `Cancel=true` on a Menu item, when it is clicked, then its nested popup stays closed. | M |
| `AC-TB-010` | `TB-API-180` | Given a Release build, when the compiler runs, then it reports zero CS1591 warnings for Toolbar types. | M |
| `AC-TB-011` | `TB-ITM-010`, `TB-ITM-020`, `TB-ITM-140` | Given a toolbar with five declarative children, when it renders, then they appear in declaration order, and an empty toolbar renders only the root without error. | M |
| `AC-TB-012` | `TB-ITM-030`, `TB-ITM-060`, `TB-ITM-070` | Given a Button, a Separator, a Spacer and a Group, when they render, then the Button is an `SfButton`, the Separator has `role="separator"` and the Group has `role="group"` with its `aria-label`. | M |
| `AC-TB-013` | `TB-ITM-040` | Given a Toggle with `Selected=true`, when it renders, then it has `aria-pressed="true"`. | M |
| `AC-TB-014` | `TB-ITM-080`, `TB-ITM-090` | Given one item with `Visible=false` and one with `Enabled=false`, when the toolbar renders, then the first is absent from the DOM and the second has `aria-disabled="true"` and ignores clicks. | M |
| `AC-TB-015` | `TB-ITM-100`, `TB-ITM-110`, `TB-ITM-120` | Given each `DisplayMode` and `Align` value, when the toolbar renders, then icon and text appear as documented, `IconOnly` keeps the text as accessible name and `Tooltip` does not change the name. | M |
| `AC-TB-016` | `TB-ITM-130` | Given a `ToolbarTemplateItem` with a text box, when the toolbar overflows, then the template content moves into the popup with the other items. | M |
| `AC-TB-017` | `TB-ITM-180`, `TB-ITM-190`, `TB-ITM-210` | Given items sharing a `GroupName` and Split, DropDown and Menu items, when each is activated, then radio items exclude each other, check items multi-select and popup items expose `aria-haspopup` and `aria-expanded`. | M |
| `AC-TB-018` | `TB-ITM-200`, `TB-API-210`, `TB-API-220` | Given `Items` with three models and an `ItemTemplate`, when the toolbar renders, then three templated items appear and mixing declarative children keeps a stable order. | M |
| `AC-TB-019` | `TB-OVF-010`, `TB-OVF-020` | Given items with mixed `Overflow` and `Priority` values and a fixed container width, when the algorithm runs, then the visible set equals the greedy result of the documented sort order. | M |
| `AC-TB-020` | `TB-OVF-030`, `TB-OVF-100` | Given all items fit, then no overflow button renders; given none fit, then the button renders and the popup lists all items. | M |
| `AC-TB-021` | `TB-OVF-040`, `TB-OVF-170`, `TB-A11Y-070` | Given `Popup` mode with overflowed items, when the popup opens, then it is an inline element with `role="menu"` whose entries are `SfButton` with `role="menuitem"`. | M |
| `AC-TB-022` | `TB-OVF-050` | Given `Scrollable` mode and a narrow container, when the toolbar renders, then it shows one line with horizontal scrolling and no popup. | M |
| `AC-TB-072` | `TB-OVF-051` | Given `Scrollable` mode, when the content fits and when it does not, then the navigation chevrons are hidden when nothing overflows, are disabled at the corresponding edge of the scroll range, and a press-and-hold on a chevron scrolls the content continuously. | M |
| `AC-TB-023` | `TB-OVF-060`, `TB-OVF-070` | Given a toolbar, when the container resizes or an item changes `Visible`, `Priority`, `Overflow` or `Enabled`, then overflow is recalculated once within 16 ms. | M |
| `AC-TB-024` | `TB-OVF-080` | Given a narrow container in a wide viewport, when the page renders, then items overflow according to the container width. | M |
| `AC-TB-025` | `TB-OVF-090` | Given an open popup, when an item is selected, `Escape` is pressed or the page is clicked outside, then the popup closes. | M |
| `AC-TB-026` | `TB-OVF-110`, `TB-KBD-110`, `TB-SEC-040` | Given the shipped script assets and C# sources, when the interop audit runs, then the only browser APIs used for measurement are `ResizeObserver` and `getBoundingClientRect`, no focus library is referenced and no `eval` or `new Function` appears. | M |
| `AC-TB-027` | `TB-OVF-120`, `TB-RTL-030` | Given `EnableRtl=true` and overflow, when the toolbar renders, then the overflow button and popup sit on the left edge. | M |
| `AC-TB-028` | `TB-OVF-130`, `TB-OVF-140` | Given `MultiRow` and `Extended` modes, when items exceed one row, then MultiRow wraps and Extended hides extra rows behind an expand button. | M |
| `AC-TB-029` | `TB-OVF-150` | Given open and close of the popup, when each occurs, then `OnOverflowOpen` and `OnOverflowClose` fire once each. | M |
| `AC-TB-030` | `TB-KBD-010`, `TB-A11Y-040`, `TB-A11Y-050` | Given a toolbar, when the user tabs in, moves with arrows, tabs out and tabs back, then exactly one item has `tabindex="0"` and focus returns to the last focused item. | M |
| `AC-TB-031` | `TB-KBD-020`, `TB-KBD-040` | Given a horizontal toolbar, when `ArrowRight` is pressed, then focus moves to the next enabled item in LTR and to the previous in RTL. | M |
| `AC-TB-032` | `TB-KBD-030` | Given a vertical toolbar, when `ArrowDown` and `ArrowUp` are pressed, then focus moves to the next and previous enabled item. | M |
| `AC-TB-033` | `TB-KBD-050`, `TB-KBD-060` | Given a focused toolbar, when `Home`, `End`, `Enter` and `Space` are pressed, then focus moves to the first and last enabled item and the focused item activates. | M |
| `AC-TB-034` | `TB-KBD-070`, `TB-KBD-090`, `TB-KBD-100` | Given an open popup, when `Escape` is pressed, then the popup closes and focus returns to the overflow button; when the popup opens, focus moves into it. | M |
| `AC-TB-035` | `TB-KBD-080` | Given disabled, hidden, separator and spacer elements between items, when arrows are pressed, then focus skips them. | M |
| `AC-TB-036` | `TB-KBD-120` | Given an open nested menu, when arrow keys and `Escape` are pressed, then focus moves among entries and returns to the owner. | M |
| `AC-TB-037` | `TB-A11Y-010`, `TB-A11Y-020`, `TB-A11Y-030` | Given a toolbar with `AriaLabel`, when it renders in each orientation, then the root has `role="toolbar"`, matching `aria-orientation` and the accessible name. | M |
| `AC-TB-038` | `TB-A11Y-060` | Given overflowed items, when the toolbar renders, then the overflow button has `aria-haspopup="menu"`, `aria-expanded` and `aria-controls` pointing at the popup id. | M |
| `AC-TB-039` | `TB-A11Y-080`, `TB-A11Y-090`, `TB-SMP-020`, `TB-SMP-030` | Given the 12 routes of ADR-010, when axe-core runs with WCAG 2.2 AA tags, then each phase-applicable route has zero critical and serious violations and is wired in `config.json` and `ToolbarTests.cs`. | M |
| `AC-TB-040` | `TB-A11Y-100`, `TB-A11Y-110` | Given desktop and mobile viewports, when item bounding boxes are measured, then each target is at least 24 by 24 px and on the mobile viewport at least 44 by 44 px. | M |
| `AC-TB-041` | `TB-A11Y-120`, `TB-A11Y-130`, `TB-THM-040` | Given light, dark and forced-colors rendering, when a screenshot and contrast check run, then focus indicators reach 3:1 and system colors are used in forced-colors. | M |
| `AC-TB-042` | `TB-A11Y-140` | Given MANUAL-VALIDATION.md, when release sign-off is requested, then scenarios SR-TB-001 to SR-TB-004 (role, orientation, names, disabled state, toggle state and expanded state announced) each have a named reviewer and status Pass. | M |
| `AC-TB-043` | `TB-A11Y-160` | Given MANUAL-VALIDATION.md, when Phase 2 release sign-off is requested, then scenario SR-TB-005 (nested menu roles and states announced) has a named reviewer and status Pass. | M |
| `AC-TB-044` | `TB-RTL-010`, `TB-RTL-020` | Given `EnableRtl` true, false and null, when the toolbar renders, then direction is set or inherited as documented. | M |
| `AC-TB-045` | `TB-RTL-040`, `TB-THM-010`, `TB-THM-020`, `TB-ISO-010`, `TB-ISO-050` | Given the component stylesheet, when the CSS lint runs, then direction layout uses logical properties, colors come from custom properties, no color literals exist and styles are scoped. | M |
| `AC-TB-046` | `TB-RTL-050`, `TB-I18-010`, `TB-I18-020` | Given a runtime culture and RTL change, when the parameters change, then strings and layout update without recreating the component instance. | M |
| `AC-TB-047` | `TB-THM-030` | Given any toolbar, when it renders, then the root has class `e-toolbar` and the orientation modifier class. | M |
| `AC-TB-048` | `TB-ISO-020`, `TB-ISO-030` | Given two toolbars on one page, when one changes, then the other and the host page styles are unchanged. | M |
| `AC-TB-049` | `TB-LIF-010`, `TB-LIF-080` | Given an item added and then removed, when the toolbar disposes, then the item unregisters and no handler remains attached. | M |
| `AC-TB-050` | `TB-LIF-020` | Given a Static SSR page, when it renders, then item markup is present, no event handler works, no measurement script runs and overflow degrades to wrapping or scrolling by CSS. | M |
| `AC-TB-051` | `TB-LIF-030`, `TB-LIF-040` | Given a prerendered page, when the circuit connects, then measurement initializes once and existing markup is reconciled without recreating item state. | M |
| `AC-TB-052` | `TB-LIF-050` | Given Auto mode with a toggled item bound with `@bind-Selected`, when the transition from Server to WebAssembly happens, then `Selected` keeps its value. | M |
| `AC-TB-053` | `TB-LIF-060`, `TB-LIF-070`, `TB-SEC-060` | Given a disconnected circuit or a disposed toolbar, when a resize or click callback arrives, then no exception is thrown and no state changes. | M |
| `AC-TB-054` | `TB-LIF-090`, `TB-LIF-100` | Given duplicate ids, an invalid enum value, a negative priority and a zero-width container, when the toolbar renders, then it does not throw. | M |
| `AC-TB-055` | `TB-LIF-110` | Given 100 rapid parameter changes, when rendering settles, then the final DOM matches the last parameters. | R |
| `AC-TB-056` | `TB-SEC-010`, `TB-SEC-020` | Given `Text`, `IconCss`, `Tooltip` and `Badge` set to `<img src=x onerror=alert(1)>`, when the toolbar renders, then the markup contains escaped text and no `img` element. | M |
| `AC-TB-057` | `TB-SEC-030`, `TB-SEC-070`, `TB-CMP-070`, `TB-CMP-080`, `TB-CMP-100` | Given the source and docs, when the review script runs, then `CssClass` and `HtmlAttributes` are documented as trust boundaries, raw HTML appears only in non-interactive structure and no forbidden package, reflection or `SfButtonGroup` use exists. | M |
| `AC-TB-058` | `TB-SEC-050` | Given a page served with a strict CSP, when the toolbar renders and operates, then no CSP violation is reported. | M |
| `AC-TB-059` | `TB-PRF-010`, `TB-PRF-020`, `TB-PRF-030`, `TB-PRF-040` | Given 100 items, when the benchmark runs, then render takes under 16 ms, adding 20 items under 10 ms, debounce 32 ms or less and first paint impact under 5 ms. | M |
| `AC-TB-060` | `TB-PRF-050` | Given the published assets, when the size check runs, then Toolbar JavaScript is 15 KB gzipped or less. | M |
| `AC-TB-061` | `TB-PRF-060` | Given an item state change, when it renders, then only that item re-renders. | R |
| `AC-TB-062` | `TB-CMP-010`, `TB-CMP-050`, `TB-CMP-060` | Given net8.0, net9.0 and net10.0 builds and a trimmed AOT publish, when they run, then there are zero warnings of any kind. | M |
| `AC-TB-063` | `TB-CMP-020` | Given the render-mode matrix in `TEST-MATRIX.md`, when it runs, then the P0 suite passes in Static SSR, Server, WebAssembly and Auto. | M |
| `AC-TB-064` | `TB-CMP-030`, `TB-CMP-090` | Given Chromium, Edge, Firefox and WebKit, when every sample route loads, then the P0 suite passes and the console has zero errors. | M |
| `AC-TB-065` | `TB-SMP-010` | Given the Sample Browser, when `/navigations/toolbar` loads, then exactly six demos render. | M |
| `AC-TB-066` | `TB-SMP-040`, `TB-SMP-050` | Given a toolbar with every item type, when it renders, then each documented `data-testid` is present for its phase. | M |
| `AC-TB-067` | `TB-SMP-060` | Given the samples, when reviewed, then at least one shows scoped CSS usage. | R |
| `AC-TB-068` | `TB-TST-010`, `TB-TST-020`, `TB-TST-030` | Given the test run with coverage, when it finishes, then every public member is exercised, statement coverage is 85 percent or more and the combinatorial overflow theory runs. | M |
| `AC-TB-069` | `TB-TST-040`, `TB-TST-050`, `TB-TST-060`, `TB-TST-070` | Given a pull request, when CI runs, then P0 and P1 gates, regression tests and visual baselines pass. Given the repository, when `python scripts/traceability/generate_traceability.py --check` runs and the harness gate component-traceability runs, then the first reports no stale or incomplete links and the second reports zero duplicate scenarios. | M |
| `AC-TB-070` | `TB-API-230`, `TB-API-240`, `TB-API-250`, `TB-API-260` | Given `OverflowSettings`, `OnOverflowOpen`, `OnOverflowClose`, nested `Items` and a `ToolbarTemplateContext`, when a Phase 2 toolbar renders, then each member exists, is documented and works as described in `API.md`. | M |
| `AC-TB-071` | `TB-TST-080` | Given MANUAL-VALIDATION.md, when release sign-off is requested, then every SR-TB scenario has a named reviewer and status Pass. | M |
