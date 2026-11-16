# Task 00000 — SfList research

Researched: 2026-11-16. Status: non-normative supporting evidence, not a product approval or implementation test report.

Normative owner: [PRD.md](../PRD.md) for scope and [API.md](../API.md) for members. This note does not define requirements. If it conflicts with those files, those files win.

## Competitor priority

MudBlazor and Blazor Blueprint UI were researched as context. A feature they ship is not automatically a v1 requirement. Sorting, drag-and-drop, component-owned persistence, built-in search, and horizontal layout remain out of v1 in [PRD.md](../PRD.md). Checkable lists and nested expansion remain in v1. "Not documented" below is not proof that a product lacks a feature.

## Method and limitations

- Sources: component source code on GitHub for MudBlazor and Microsoft Fluent UI Blazor; documentation page and LLM API reference for Blazor Blueprint UI; official documentation pages, API references and demo pages for Syncfusion Blazor ListView and ListBox, Telerik UI for Blazor, DevExpress Blazor and Radzen Blazor; W3C and MDN reference pages. Every source is listed under [Sources](#sources) with the date checked.
- MudBlazor (`mudblazor.com/components/list`, `mudblazor.com/api/MudList`) documentation returned no readable content or an error to the fetch tool [S16]. MudBlazor facts come from the source code on the `dev` branch [S12]–[S15], [S32]. Source code describes the current branch, which can differ from the latest released package. Where this note says MudBlazor has no parameter for a feature, it means none was found in those files.
- Blazor Blueprint UI facts come from the List Box documentation page [S36] and its API reference [S37], linked from the library's LLM index [S38]. The reference states library version 4, component introduced in 4.1, last updated 2026-09-22. "Not documented" for Blazor Blueprint UI means the reference does not describe the feature.
- Fluent UI Blazor (`fluentui-blazor.net/Listbox`) documentation is client-rendered; facts come from the `main` branch source [S21], [S22].
- `docs.devexpress.com` returned HTTP 403 to direct fetches. DevExpress facts come from the public demo page [S30] and, where marked, from a search-result excerpt of the documentation page [S31].
- Nothing was run or tested. No component was installed. Behavior is as documented, not as observed.
- "Not documented" means the pages read did not state the feature. It is a documentation finding, not proof that the feature is absent.
- Features researched: plain display, single and multiple selection, toggle (deselect) selection, checkbox items, nesting, grouping and collapsible groups, sorting, search / filtering, select-all, form validation, drag-and-drop reorder within a list, virtualization, horizontal orientation, templates, label and empty message, read-only, link navigation (including force load), appearance parameters (color, gutters, padding, inset, ripple), state persistence, keyboard model and ARIA roles, RTL. Theme, touch, SSR and render-mode rows of the competitive matrix were not researched.
- Live documentation changes. Re-check before using any statement externally.

## Main competitor — MudBlazor `MudList<T>` / `MudListItem<T>`

Source: `dev` branch source code (checked 2026-11-16). The documentation page returned an error [S16].

| Area | Documented API / behavior | Source |
| --- | --- | --- |
| Items | Declared as `MudListItem<T>` children; no data-source parameter on `MudList`. Item content: `Text`, `SecondaryText`, `Icon`, `AvatarContent`. | [S12], [S14] |
| Selection | `SelectionMode` = `SingleSelection` (default), `MultiSelection`, `ToggleSelection` (activating the selected item deselects it). `SelectedValue` / `SelectedValueChanged`, `SelectedValues` / `SelectedValuesChanged`; `Comparer` for value equality. | [S12], [S15] |
| Check marks | Multi-selection renders a check box in each item; `CheckedIcon`, `UncheckedIcon`, `CheckBoxColor`. The check box is `aria-hidden` and not focusable. | [S12], [S13] |
| Nesting | `NestedList` render fragment on an item; `Expanded` / `ExpandedChanged`; `ExpandLessIcon` / `ExpandMoreIcon`. The nested list renders in a collapse under its parent item. | [S13], [S14] |
| Navigation and actions | `Href`, `Target`, `ForceLoad` on items; `OnClick`, `OnClickPreventDefault`. | [S14] |
| State | `Disabled`, `ReadOnly` (default `false`). | [S12], [S14] |
| Appearance | `Dense`, `Gutters` (default `true`), `Padding`, `Color`, `Inset` (item), `Ripple` (item). | [S12], [S14] |
| Keyboard | Arrow Up / Down, Home / End, Space, Enter; `KeyboardEnabled` (default `true`). Single tab stop. | [S14] |
| ARIA | Container `listbox`, `list` when `ReadOnly`, `tree` when nested, child lists `group`; items `option`, `listitem` or `treeitem`; `aria-selected`; `aria-expanded` on items with a nested list; `aria-multiselectable` in multi-selection. | [S12], [S14], [S32] |
| Not found in source | Filter / search, sorting, drag-and-drop, virtualization, horizontal orientation. Grouping, select-all, form validation, label, empty message, persistence and RTL parameters: not documented. | [S12], [S14] |

## Secondary competitor — Blazor Blueprint UI `BbListBox<TValue>`

Source: documentation page [S36] and API reference [S37] (library version 4; introduced in 4.1; last updated 2026-09-22; checked 2026-11-16).

| Area | Documented API / behavior | Source |
| --- | --- | --- |
| Search | `ShowSearch`; `SearchPlaceholder` (default `"Search..."`); `@bind-SearchText`. | [S36], [S37] |
| Selection | `SelectionMode` `Single` / `Multiple`; `Value` (single), `Values` (multiple). | [S37] |
| Check marks | A drawn check indicator inside the option; no real checkbox element. | [S36], [S37] |
| Select all | `ShowSelectAll` (default `true`, Multiple mode only, applies to visible options only); `SelectAllLabel`. | [S37] |
| Disabled | `Disabled` (whole list); `OptionDisabled` predicate per option. | [S37] |
| Keyboard | Arrow Up / Down (single mode selects as focus moves), Home / End, Page Up / Page Down, Space, Enter, Shift for range, Ctrl+A, type-ahead with an 800 ms reset. | [S36], [S37] |
| ARIA | `role="listbox"` with `role="option"`; `aria-multiselectable`, `aria-activedescendant`, `aria-disabled`, `aria-selected`, `aria-labelledby`. | [S36], [S37] |
| Templates and layout | `ItemTemplate`; `Label`; `AriaLabel`; `Height` (default `16rem`); `EmptyMessage`. | [S37] |
| Forms | `ValueExpression` / `ValuesExpression` for `EditForm` validation. | [S37] |
| Not documented | Grouping, nesting, sorting, drag-and-drop, virtualization. Read-only, link items, horizontal orientation, persistence and RTL are not described either. | [S37] |

## Other vendors

| Competitor | Supported | Edition | API (props / methods / events) | Defaults | UX pattern | Keyboard / A11y | Limitations | Source (date) |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Microsoft Fluent UI Blazor `FluentListbox` | Single and multiple selection, item template, disabled options, read-only | Not documented in sources read | `Items`, `OptionTemplate`, `OptionText`, `OptionValue`, `OptionDisabled`, `OptionSelected`, `OptionTitle`, `OptionComparer`, `SelectedOption`, `SelectedOptionChanged`, `Multiple`, `SelectedOptions`, `SelectedOptionsChanged`, `ChangeOnEnterOnly`, `Height`, `Width`, `ReadOnly` | Not documented | Wraps the `<fluent-listbox>` web component. | Blazor markup sets no `role`; semantics come from the web component (not verified). Has an `onkeydown` handler; keys not documented. | Base class has no virtualization or grouping parameter. Sorting, drag-drop, horizontal, persistence, RTL: not documented. | [S21], [S22] (2026-11-16) |
| Telerik UI for Blazor ListBox | Single / multiple selection, drag-drop within and between instances, toolbar reorder / transfer / remove, connected lists | Commercial (not verified on pricing page) | `SelectionMode` (`ListBoxSelectionMode`), `SelectedItems`, `Draggable`, `DropSources`, `OnDrop`, `OnReorder`, `ConnectedListBoxId`, `ToolBarPosition`, `ItemTemplate`, `NoDataTemplate`, `AriaLabel`, `AriaLabelledBy`, `Enabled`, `Size`, `TextField`, `Height`, `Width`, `Rebind()` | `SelectionMode = Single`, `ToolBarPosition = Right`, `Enabled = true`, `Size = "md"`, `TextField = "Text"` | Form-style ListBox with a side toolbar. | `role="listbox"`, items `option` with `aria-selected`, `aria-multiselectable` when multiple, roving `tabindex`; toolbar `role="toolbar"` with `aria-controls`. Keys: Ctrl+Shift+Up/Down reorder selected items; Ctrl+Right/Left transfer; Ctrl+Shift+Right/Left transfer all; Del removes; Ctrl+Up/Down moves focus only. | Virtualization, grouping, sorting, horizontal, persistence, RTL: not documented in pages read. Ordering for same-instance drops is not documented. | [S23]–[S27] (2026-11-16) |
| Telerik UI for Blazor ListView | Templated item display, paging, editing | Commercial (not verified) | `Data`, `Template`, `HeaderTemplate`, `Pageable`, `PageSize`, `Page`, `EnableLoaderContainer`, `Height`, `Width`, `Class`; header, footer and edit templates described | `Pageable = false`, `PageSize = 10`, `Page = 1`, `EnableLoaderContainer = true` | Repeated item template with header, footer and pager. | Not documented in pages read. | Selection, virtualization, grouping, sorting, drag-drop: not documented in pages read. | [S28], [S29] (2026-11-16) |
| DevExpress Blazor `DxListBox<TData, TValue>` | Single / multiple selection, checkboxes, select all, search box, filtering API, multiple columns, grouping, disabled items, virtual scrolling, templates | Commercial (not verified) | `SelectionMode` (`ListBoxSelectionMode.Multiple`), `ShowCheckboxes`, `ShowSelectAllCheckbox`, `SelectAllAsync`, `DeselectAllAsync`, `Values`, `ValuesChanged`, `SelectedItemsChanged`, `ShowSearchBox`, `SearchText`, `SetFilterCriteria`, `DxListEditorColumn`, `GroupFieldName`, `GroupHeaderDisplayTemplate`, `DisabledFieldName`, `ListRenderMode.Virtual`, `ItemDisplayTemplate`, `EmptyDataAreaTemplate`, `IsDataLoading` | Not documented in sources read | Form-style ListBox; optional search box and columns. | Keyboard navigation mentioned on the demo page; keys and ARIA not documented in pages read. | One group level; users cannot collapse groups [S31]. Sorting, drag-drop, horizontal, persistence, RTL: not documented in pages read. | [S30], [S31] (2026-11-16) |
| Radzen Blazor `RadzenListBox<TValue>` | Single / multiple selection, filtering, virtualization, item template, select all, read-only | Not documented in sources read | `Multiple`, `AllowClear`, `AllowFiltering`, `FilterCaseSensitivity`, `FilterOperator`, `LoadData`, `AllowVirtualization`, `Template`, `LoadingTemplate`, `EmptyTemplate`, `EmptyText`, `AllowSelectAll`, `SelectAllText`, `SelectAll()`, `ReadOnly`, `Disabled`, `DisabledProperty`, `ItemRender` | Single selection by default; other defaults not stated | Form-style ListBox. | `OnKeyDown` handles arrows, Page Up/Down, Home/End. ARIA label members listed (`GetItemAriaLabel` etc.); roles not documented. | Per-item checkboxes, grouping, sorting, drag-drop, horizontal, persistence, RTL: not documented in pages read. | [S17], [S18] (2026-11-16) |
| Radzen Blazor `RadzenDataList<TItem>` | Templated display, paging, virtualization, wrapping layout, empty and loading states | Not documented in sources read | `Template`, `WrapItems`, `AllowPaging`, `PageSize`, `AllowVirtualization`, `EmptyTemplate`, `EmptyText`, `ShowEmptyMessage`, `IsLoading`, `LoadingTemplate`, `LoadData` | Not documented | Repeated template; `WrapItems` wraps items across rows. | Not documented in pages read. | Selection, grouping, sorting, drag-drop, persistence, RTL: not documented in pages read. | [S19], [S20] (2026-11-16) |

## Shipped Syncfusion behavior

| Platform | Existing API / behavior | Source |
| --- | --- | --- |
| Blazor `SfListView<TValue>` | Item `Template`, `GroupTemplate`, `HeaderTemplate`, `ShowHeader`, `HeaderTitle`, `Height`, `CssClass`, `Enabled`, `Animation` (default effect `SlideLeft`, 400 ms). | [S1] |
| Blazor `SfListView` | Check list: `ShowCheckBox`; `CheckBoxPosition` (default `Left`); methods `CheckItemsAsync`, `UncheckItemsAsync`, `GetCheckedItemsAsync`. Space or Enter selects the focused item when `ShowCheckBox` is on. | [S1], [S5] |
| Blazor `SfListView` | Sorting: `SortOrder` (default `None`). | [S1] |
| Blazor `SfListView` | Grouping: `ListViewFieldSettings.GroupBy`; single level only. Collapsible groups: not documented. | [S3] |
| Blazor `SfListView` | Virtualization: `EnableVirtualization`; window scroll by default, container scroll when `Height` is set; height must be in pixels, percentage values are not accepted. | [S4] |
| Blazor `SfListView` | State and direction: `EnablePersistence`, `EnableRtl` (default `false`). | [S1] |
| Blazor `SfListView` | Accessibility: `aria-selected`, `aria-level`; Up/Down move between items, Space selects, Back returns from a nested list. Page states WCAG 2.2 AA and RTL support; Section 508 marked partial. | [S2] |
| Blazor `SfListView` | Drag-and-drop reorder, horizontal orientation: not documented in the pages read. | [S1]–[S5] |
| Blazor `SfListBox<TValue, TItem>` | Selection: `ListBoxSelectionSettings` with `Mode` `Single` / `Multiple` (default `Multiple`), `ShowCheckbox`, `ShowSelectAll`; `MaximumSelectionLength` (default 500). | [S6], [S7] |
| Blazor `SfListBox` | Drag-and-drop: `AllowDragAndDrop` (default `false`) within one list or between lists that share `Scope`; events `DragStart`, `OnDrop`, `Dropped` on `ListBoxEvents`; dual-list toolbar through `ListBoxToolbarSettings.Items` (`MoveTo`, `MoveFrom`, `MoveAllTo`, `MoveAllFrom`). | [S8] |
| Blazor `SfListBox` | Sorting: `SortOrder` (default `None`) on the `Text` field. Grouping: `ListBoxFieldSettings.GroupBy`; group headers are not selectable. Collapsible groups: not documented. | [S9] |
| Blazor `SfListBox` | Other: `AllowFiltering` (default `false`), `Readonly`, `Enabled`, `Height`, `EnablePersistence` (default `false`), `EnableRtl` (default `false`). | [S6] |
| Blazor `SfListBox` | Accessibility: container `role="listbox"`, inner `ul` presentation, items `option`; `aria-multiselectable` when multiple; `aria-selected`. Keys: Up/Down, Home/End, Space toggles, Ctrl+A selects all, Ctrl+Shift+Home/End range, Ctrl+Arrow moves focus without selecting. Keyboard reorder: not documented. | [S10] |
| Blazor `SfListBox` | Virtualization: not documented. A public feedback item requests it. | [S11] |

## Reference patterns

| Reference | Relevant statements | Source (date) |
| --- | --- | --- |
| WAI-ARIA APG Listbox | `listbox` owns `option` (optionally in `group`); `aria-multiselectable` for multi-select; every selectable option carries `aria-selected` or `aria-checked`, not both; options must not contain interactive content (links, buttons, checkboxes) — use Grid instead; groups need an accessible name and at least one option; Home/End strongly recommended over five options; type-ahead recommended; horizontal listbox needs `aria-orientation="horizontal"` and maps Left/Right to Up/Down; `aria-setsize` / `aria-posinset` when options load on scroll; selection may follow focus in single-select, with a caution. No reorder keys are defined; the rearrangeable example uses toolbar buttons. | [S33] (2026-11-16) |
| MDN `list` role | `list` contains `listitem` children; prefer native `ul` / `ol`; `role="presentation"` on `ul` / `ol` propagates to child `li`. Keyboard behavior is not defined for `list`. | [S34] (2026-11-16) |
| WAI-ARIA 1.2 | §5.2.6 examples: `list` owns at least one `listitem`; `listbox` requires ownership of `option` or `group`. Full role tables (§5.4) were not read in this pass. | [S35] (2026-11-16) |

## Gaps and differentiators

The bullets below record the 2026-11-16 research pass. They are not the current contract. The current contract keeps checkable lists, nested expansion, typed selectors, and virtualization, and excludes built-in sort, search, drag-and-drop, persistence, and horizontal layout. See [PRD.md](../PRD.md) and [API.md](../API.md).

- **Nesting.** MudBlazor ships inline nested lists (`NestedList`, `Expanded`) rendered with the ARIA tree pattern [S12], [S14]. Blazor Blueprint UI does not document nesting [S37]. The toolkit adopts inline nesting with the tree pattern (`ChildItemsField` / `ChildItemsSelector`, `SfListItem.NestedList`, `@bind-ExpandedItems`, D-LS-1), and adds what MudBlazor's source does not show: cancellable expansion events, expand / collapse methods, tree check state, and sorting, search and virtualization across levels.
- **Search.** Blazor Blueprint UI (`ShowSearch`, `@bind-SearchText`) [S37], DevExpress [S30], Radzen ListBox [S17] and shipped `SfListBox` (`AllowFiltering`) [S6] ship a search box; MudBlazor has none [S12]. The toolkit ships `ShowSearch`, `@bind-SearchText`, `SearchPlaceholder`, plus `SearchMatch`, `SearchPredicate` and `SearchDelay`, which Blazor Blueprint UI does not document. Placeholder default differs: Blazor Blueprint UI `"Search..."` [S37], toolkit localized `"Search"`.
- **Select all.** Blazor Blueprint UI `ShowSelectAll` is on by default and covers visible options only [S37]; DevExpress (`ShowSelectAllCheckbox`) [S30], Radzen (`AllowSelectAll`) [S18] and shipped `SfListBox` (`ShowSelectAll`) [S7] also offer it. The toolkit ships `ShowSelectAll` off by default (opt-in, toolkit convention), covering visible enabled items, as a real tri-state `SfCheckBox` outside the `ul`.
- **Form validation.** Blazor Blueprint UI binds `ValueExpression` / `ValuesExpression` for `EditForm` [S37]; form integration is not documented for MudBlazor's list [S12]. The toolkit ships `SelectedItemExpression` / `SelectedItemsExpression` (item-valued, set by `@bind-SelectedItem(s)`), `aria-invalid` and the `EditContext` field class.
- **Focus model.** Blazor Blueprint UI uses `aria-activedescendant` [S37]; MudBlazor and Telerik use a single tab stop [S14], [S24]. The toolkit uses roving `tabindex` without `aria-activedescendant` (D-LS-4) because list items can hold real links, buttons and check boxes.
- **Check marks inside options.** MudBlazor renders a hidden, non-focusable check box inside `role="option"` items [S13]; Blazor Blueprint UI draws a check indicator inside options [S36], [S37]. APG says options do not support interactive content [S33]. The toolkit shows checking only in `role="list"` lists (real `SfCheckBox`) and trees (`aria-checked`) (D-LS-2); listbox options carry `aria-selected` only.
- **Deselect, read-only, links.** MudBlazor `ToggleSelection` [S15], `ReadOnly` [S12] and item `ForceLoad` [S14] map to the toolkit's `AllowDeselect`, `ReadOnly` and `ForceLoad` (list and item). Blazor Blueprint UI documents none of the three [S37].
- **Label and empty message.** Blazor Blueprint UI `Label` and `EmptyMessage` [S37]; Radzen `EmptyText` [S18]. The toolkit ships `Label` (named via `aria-labelledby`) and `EmptyText` (plus `EmptyTemplate`).
- **Appearance.** MudBlazor has `Color`, `Gutters`, `Padding`, `Inset`, `Dense` and `Ripple` [S12], [S14]. The toolkit ships `Color`, `Gutters`, `Padding`, `Inset` and `Density`; it has no ripple because the Fluent 2 theme has none (D-LS-17).
- **Type-ahead.** Blazor Blueprint UI resets type-ahead after 800 ms [S37]; the toolkit resets after 500 ms (D-LS-19).
- **Sorting.** No competitor page read documents a built-in sort parameter; MudBlazor has none [S12] and Blazor Blueprint UI does not document one [S37]. Shipped Syncfusion ListView and ListBox both have `SortOrder` [S1], [S9]; the toolkit's `SortOrder` / `SortComparer` continues that pattern.
- **Collapsible groups.** DevExpress states users cannot collapse groups [S31]; Syncfusion ListView and ListBox do not document it [S3], [S9]. MudBlazor collapses nested lists, not groups [S13]. The toolkit's `AllowGroupCollapse` has no direct documented counterpart.
- **Keyboard reorder.** Telerik ListBox reorders with Ctrl+Shift+Up/Down [S27]; the toolkit uses the same keys (Cmd+Shift on macOS) and adds long-press touch drag (D-LS-15). APG defines no reorder key [S33]; shipped Syncfusion ListBox documents none [S10]. MudBlazor and Blazor Blueprint UI have no reorder [S12], [S37].
- **Drag between lists.** Telerik ListBox [S25] and shipped Syncfusion ListBox [S8] support it. The toolkit does not (Spec §2); hosts migrating from `SfListBox` with `Scope` lose this.
- **Virtualization.** DevExpress, Radzen ListBox and Radzen DataList document it [S30], [S17], [S19]; MudBlazor has none [S12]; Blazor Blueprint UI does not document it [S37]; Fluent UI's list base has no parameter [S22]; shipped `SfListBox` does not document it [S11]. The toolkit's `EnableVirtualization` covers flat, grouped and nested lists.
- **State persistence and RTL.** Documented only for shipped Syncfusion components among the products read [S1], [S2], [S6].

## Adopt / avoid

This table is historical research from 2026-11-16. It is not a decision record. Do not treat "adopt" as a v1 requirement. Scope is [PRD.md](../PRD.md).

| Adopt | Avoid |
| --- | --- |
| Built-in search box with placeholder and two-way search text (Blazor Blueprint UI [S37], DevExpress [S30]). | `aria-activedescendant` with focus kept on the container (Blazor Blueprint UI [S37]); list items can hold real controls, so roving `tabindex` is used (D-LS-4). |
| Select-all limited to visible options (Blazor Blueprint UI [S37]), as an opt-in tri-state check box outside the `ul`. | Check marks drawn or hidden inside `role="option"` (Blazor Blueprint UI [S36], MudBlazor [S13]); options carry `aria-selected` only (APG [S33], D-LS-2). |
| `EditForm` validation through a value expression (Blazor Blueprint UI [S37]), item-valued in the toolkit. | Using both `aria-selected` and `aria-checked` on one option (APG [S33]). |
| Inline nested lists with `aria-expanded` and the tree pattern (MudBlazor [S12], [S14]). | Ripple (MudBlazor [S14]); the toolkit's Fluent 2 theme has no ripple effect (D-LS-17). |
| Toggle selection, read-only, force-load links, inset, gutters, padding and color (MudBlazor [S12], [S14], [S15]). | Select-all on by default (Blazor Blueprint UI [S37]); toolkit options are opt-in. |
| Visible label and empty message (Blazor Blueprint UI [S37]). | Percentage-only height with virtualization; shipped ListView requires pixels [S4] — document the toolkit's rule explicitly. |
| Role by mode: `list` for non-selecting lists, `listbox` only when selecting (MudBlazor [S12], APG [S33]). | Claiming keyboard reorder conformance to a standard; none exists [S33]. |
| `aria-selected` on every selectable option, `aria-multiselectable` for multi-select (APG [S33], Telerik [S24], Blazor Blueprint UI [S37]). | Undocumented drop ordering for same-list drag (Telerik gap [S25]); the toolkit's `Reordering` / `Reordered` events state the target index. |
| `aria-setsize` / `aria-posinset` with virtualization (APG [S33]). | Interactive controls inside `role="option"` (APG [S33]). |
| Home/End, Page Up/Down and type-ahead in listbox modes (APG [S33], Blazor Blueprint UI [S37]). | |
| Named groups inside listbox (`group` + accessible name) (APG [S33]). | |

## Sources

- [S1] Syncfusion — SfListView&lt;TValue&gt; class, API reference — https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.SfListView-1.html (checked 2026-11-16)
- [S2] Syncfusion — Accessibility in Blazor ListView — https://blazor.syncfusion.com/documentation/listview/accessibility (checked 2026-11-16)
- [S3] Syncfusion — Grouping in Blazor ListView — https://blazor.syncfusion.com/documentation/listview/grouping (checked 2026-11-16)
- [S4] Syncfusion — Virtualization in Blazor ListView — https://blazor.syncfusion.com/documentation/listview/virtualization (checked 2026-11-16)
- [S5] Syncfusion — Check List in Blazor ListView — https://blazor.syncfusion.com/documentation/listview/check-list (checked 2026-11-16; read via search-result excerpt)
- [S6] Syncfusion — SfListBox&lt;TValue, TItem&gt; class, API reference — https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfListBox-2.html (checked 2026-11-16)
- [S7] Syncfusion — Selection in Blazor ListBox — https://blazor.syncfusion.com/documentation/listbox/selection (checked 2026-11-16)
- [S8] Syncfusion — Drag and drop in Blazor ListBox — https://blazor.syncfusion.com/documentation/listbox/drag-and-drop (checked 2026-11-16)
- [S9] Syncfusion — Sorting and Grouping in Blazor ListBox — https://blazor.syncfusion.com/documentation/listbox/sorting-grouping (checked 2026-11-16)
- [S10] Syncfusion — Accessibility in Blazor ListBox — https://blazor.syncfusion.com/documentation/listbox/accessibility (checked 2026-11-16)
- [S11] Syncfusion feedback — Provides the virtualization support to the ListBox — https://www.syncfusion.com/feedback/34761/provides-the-virtualization-support-to-the-listbox (checked 2026-11-16; title from search result only, status not read)
- [S12] MudBlazor — MudList.razor.cs (dev branch) — https://raw.githubusercontent.com/MudBlazor/MudBlazor/dev/src/MudBlazor/Components/List/MudList.razor.cs (checked 2026-11-16)
- [S13] MudBlazor — MudListItem.razor (dev branch) — https://raw.githubusercontent.com/MudBlazor/MudBlazor/dev/src/MudBlazor/Components/List/MudListItem.razor (checked 2026-11-16)
- [S14] MudBlazor — MudListItem.razor.cs (dev branch) — https://raw.githubusercontent.com/MudBlazor/MudBlazor/dev/src/MudBlazor/Components/List/MudListItem.razor.cs (checked 2026-11-16)
- [S15] MudBlazor — SelectionMode.cs (dev branch) — https://raw.githubusercontent.com/MudBlazor/MudBlazor/dev/src/MudBlazor/Enums/SelectionMode.cs (checked 2026-11-16)
- [S16] MudBlazor — List documentation page — https://mudblazor.com/components/list (checked 2026-11-16; returned an error / no readable content; not used for facts)
- [S17] Radzen — Blazor ListBox demo — https://blazor.radzen.com/listbox (checked 2026-11-16)
- [S18] Radzen — RadzenListBox&lt;TValue&gt; API reference — https://blazor.radzen.com/docs/api/Radzen.Blazor.RadzenListBox-1.html (checked 2026-11-16)
- [S19] Radzen — Blazor DataList demo — https://blazor.radzen.com/datalist (checked 2026-11-16)
- [S20] Radzen — RadzenDataList&lt;TItem&gt; API reference — https://blazor.radzen.com/docs/api/Radzen.Blazor.RadzenDataList-1.html (checked 2026-11-16)
- [S21] Microsoft Fluent UI Blazor — FluentListbox.razor (main branch) — https://raw.githubusercontent.com/microsoft/fluentui-blazor/main/src/Core/Components/List/FluentListbox.razor (checked 2026-11-16)
- [S22] Microsoft Fluent UI Blazor — ListComponentBase.razor.cs (main branch) — https://raw.githubusercontent.com/microsoft/fluentui-blazor/main/src/Core/Components/List/ListComponentBase.razor.cs (checked 2026-11-16)
- [S23] Telerik — Blazor ListBox overview — https://www.telerik.com/blazor-ui/documentation/components/listbox/overview (checked 2026-11-16)
- [S24] Telerik — Blazor ListBox WAI-ARIA support — https://www.telerik.com/blazor-ui/documentation/components/listbox/accessibility/wai-aria-support (checked 2026-11-16)
- [S25] Telerik — Blazor ListBox drag and drop — https://www.telerik.com/blazor-ui/documentation/components/listbox/drag-drop (checked 2026-11-16)
- [S26] Telerik — Blazor ListBox templates — https://www.telerik.com/blazor-ui/documentation/components/listbox/templates (checked 2026-11-16)
- [S27] Telerik — Blazor ListBox keyboard navigation demo — https://demos.telerik.com/blazor-ui/listbox/keyboard-navigation (checked 2026-11-16)
- [S28] Telerik — Blazor ListView overview — https://www.telerik.com/blazor-ui/documentation/components/listview/overview (checked 2026-11-16)
- [S29] Telerik — Blazor ListView templates — https://www.telerik.com/blazor-ui/documentation/components/listview/templates (checked 2026-11-16)
- [S30] DevExpress — Blazor List Box demos — https://demos.devexpress.com/blazor/ListBox (checked 2026-11-16)
- [S31] DevExpress — Group Data (List Box) — https://docs.devexpress.com/Blazor/405397 (checked 2026-11-16; direct fetch returned 403, statement from search-result excerpt)
- [S32] MudBlazor — MudList.razor (dev branch) — https://raw.githubusercontent.com/MudBlazor/MudBlazor/dev/src/MudBlazor/Components/List/MudList.razor (checked 2026-11-16)
- [S33] W3C WAI-ARIA Authoring Practices — Listbox pattern — https://www.w3.org/WAI/ARIA/apg/patterns/listbox/ (checked 2026-11-16)
- [S34] MDN — ARIA: list role — https://developer.mozilla.org/en-US/docs/Web/Accessibility/ARIA/Reference/Roles/list_role (checked 2026-11-16)
- [S35] W3C — WAI-ARIA 1.2, §5.2.6 Required Owned Elements — https://www.w3.org/TR/wai-aria-1.2/#mustContain (checked 2026-11-16)
- [S36] Blazor Blueprint UI — List Box documentation — https://blazorblueprintui.com/docs/components/list-box (checked 2026-11-16)
- [S37] Blazor Blueprint UI — List Box API reference (LLM text; library version 4, introduced 4.1, last updated 2026-09-22) — https://blazorblueprintui.com/llms/components/list-box.txt (checked 2026-11-16)
- [S38] Blazor Blueprint UI — LLM documentation index (links [S37]) — https://blazorblueprintui.com/llms/index.txt (checked 2026-11-16)
