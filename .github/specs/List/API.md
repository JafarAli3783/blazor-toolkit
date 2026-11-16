# SfList — Public API Contract
## Syncfusion Blazor Toolkit

**Namespace:** `Syncfusion.Blazor.Toolkit`  
**Assembly:** Syncfusion.Blazor.Toolkit  
**Nullability:** enabled  
**Status:** Proposed contract. Not frozen and not implemented.  
**Authority:** This file is the only public-member contract. `API-xml.md` documents these members and must not add or rename any. `Spec.md` owns behavior. `PRD.md` owns scope. A member that is not in this file is not a v1 API.

---

## 0. Design decisions (proposed for v1)

| Topic | Decision |
|---|---|
| Field mapping | Separate `string?` field-name parameters and typed `Func<TItem, …>?` selectors. When both are set, the selector wins. Do not use an untyped `object?` parameter for either. |
| Checkable lists | **In v1.** Independent of selection. See `CheckMode` and `CheckedValues`. |
| Nested expansion | **In v1.** Managed expand/collapse on `SfListItem`. |
| Loading / error | `IsLoading` / `HasError` activate templates. Error wins when both are true. |
| Keyboard focus | **Proposed:** roving `tabindex` for selectable lists. Finalize during implementation review. `aria-activedescendant` is not the proposed model because nested interactive content must remain keyboard-reachable. |
| Virtualization | **Proposed:** Blazor built-in `Virtualize`. A custom virtualizer requires a later decision. |
| Sorting | **Out of v1.** No sort parameter, comparer, or event. |
| Drag-and-drop / reorder | **Out of v1.** No reorder parameter, handle, or event. Consumers may reorder their own collection. |
| Persistence | **Out of v1.** No component-owned storage key. The host owns any persisted state. |
| JS interop | None required for the v1 public surface. No `[JSInvokable]` members. |
| Generic constraint | `TItem` unconstrained (reference or value types). |
| Attributes | `AdditionalAttributes` with `CaptureUnmatchedValues = true`. There is no `HtmlAttributes` parameter. |
| RTL | Inherited from an ancestor `dir`. There is no `EnableRtl` parameter. |

## 1. Enums

```csharp
public enum ListSelectionMode { None = 0, Single = 1, Multiple = 2 }
public enum ListDensity { Comfortable = 0, Dense = 1 }
public enum ListCheckMode { None = 0, Multiple = 1 }
```

## 2. Event argument types

```csharp
public sealed class ListSelectionChangingEventArgs<TItem> : EventArgs
{
    public bool Cancel { get; set; }
    public IReadOnlyList<TItem> AddedItems { get; init; } = Array.Empty<TItem>();
    public IReadOnlyList<TItem> RemovedItems { get; init; } = Array.Empty<TItem>();
    public IReadOnlyList<TItem> SelectedItems { get; init; } = Array.Empty<TItem>();
}

public sealed class ListSelectionChangedEventArgs<TItem> : EventArgs
{
    public IReadOnlyList<TItem> AddedItems { get; init; } = Array.Empty<TItem>();
    public IReadOnlyList<TItem> RemovedItems { get; init; } = Array.Empty<TItem>();
    public IReadOnlyList<TItem> SelectedItems { get; init; } = Array.Empty<TItem>();
}

public sealed class ListItemClickEventArgs<TItem> : EventArgs
{
    public required TItem Item { get; init; }
    public required MouseEventArgs OriginalArgs { get; init; }
    public bool IsSelected { get; init; }
    public bool IsChecked { get; init; }
}

public sealed class ListExpansionChangingEventArgs : EventArgs
{
    public bool Cancel { get; set; }
    public bool Expanding { get; init; }
}

public sealed class ListExpansionChangedEventArgs : EventArgs
{
    public bool Expanded { get; init; }
}
```

## 3. `SfList<TItem>`

### 3.1 Parameters

| Name | Type | Default | Required | Two-way | Valid range / notes |
|---|---|---:|---|---|---|
| DataSource | `IEnumerable<TItem>?` | `null` | No | No | Null/empty uses EmptyTemplate when no children |
| TextField | `string?` | `null` | No | No | Property name; ignored when TextSelector is set |
| TextSelector | `Func<TItem, string?>?` | `null` | No | No | Wins over TextField |
| ValueField | `string?` | `null` | No | No | Property name for identity |
| ValueSelector | `Func<TItem, object?>?` | `null` | No | No | Wins over ValueField |
| DisabledField | `string?` | `null` | No | No | Property name |
| DisabledSelector | `Func<TItem, bool>?` | `null` | No | No | Wins over DisabledField |
| IconField | `string?` | `null` | No | No | Property name |
| IconSelector | `Func<TItem, string?>?` | `null` | No | No | Wins over IconField |
| GroupField | `string?` | `null` | No | No | Property name |
| GroupSelector | `Func<TItem, string?>?` | `null` | No | No | Wins over GroupField |
| ChildItemsField | `string?` | `null` | No | No | Property name |
| ChildItemsSelector | `Func<TItem, IEnumerable<TItem>?>?` | `null` | No | No | Wins over ChildItemsField |
| ItemKey | `Func<TItem, object>?` | `null` | No | No | Highest precedence for `@key` and lookup |
| Comparer | `IEqualityComparer<TItem>?` | `null` | No | No | Item equality when no key is used |
| KeyComparer | `IEqualityComparer<object>?` | `null` | No | No | Equality for keys from ItemKey or ValueSelector |
| SelectionMode | `ListSelectionMode` | `None` | No | No | Drives root role |
| SelectedValue | `TItem?` | `default` | No | Yes | Single only; ignored unless Mode is Single |
| SelectedValueChanged | `EventCallback<TItem?>` | — | No | — | Required for `@bind-SelectedValue` |
| SelectedValues | `IEnumerable<TItem>?` | `null` | No | Yes | Multiple only; input is snapshotted |
| SelectedValuesChanged | `EventCallback<IEnumerable<TItem>?>` | — | No | — | Required for `@bind-SelectedValues` |
| CheckMode | `ListCheckMode` | `None` | No | No | Independent of SelectionMode |
| CheckedValues | `IEnumerable<TItem>?` | `null` | No | Yes | Used when CheckMode is Multiple |
| CheckedValuesChanged | `EventCallback<IEnumerable<TItem>?>` | — | No | — | |
| ItemTemplate | `RenderFragment<TItem>?` | `null` | No | No | |
| GroupTemplate | `RenderFragment<string>?` | `null` | No | No | |
| HeaderTemplate | `RenderFragment?` | `null` | No | No | |
| FooterTemplate | `RenderFragment?` | `null` | No | No | |
| EmptyTemplate | `RenderFragment?` | `null` | No | No | |
| LoadingTemplate | `RenderFragment?` | `null` | No | No | Shown when IsLoading |
| ErrorTemplate | `RenderFragment?` | `null` | No | No | Shown when HasError |
| IsLoading | `bool` | `false` | No | No | Activates LoadingTemplate over items |
| HasError | `bool` | `false` | No | No | Activates ErrorTemplate; error wins over loading |
| Density | `ListDensity` | `Comfortable` | No | No | |
| Disabled | `bool` | `false` | No | No | Disables the entire list |
| Height | `string?` | `null` | No | No | CSS length |
| MaxHeight | `string?` | `null` | No | No | CSS length |
| EnableVirtualization | `bool` | `false` | No | No | One-way for the component lifetime |
| AriaLabel | `string?` | `null` | No | No | Accessible name |
| AriaLabelledBy | `string?` | `null` | No | No | Element id |
| CssClass | `string?` | `null` | No | No | Merged onto the root |
| Id | `string?` | `null` | No | No | Preserved when supplied; otherwise generated |
| AdditionalAttributes | `Dictionary<string, object>?` | `null` | No | No | `CaptureUnmatchedValues = true` |
| ChildContent | `RenderFragment?` | `null` | No | No | Declarative `SfListItem` children |

### 3.2 Selection: controlled vs uncontrolled

| Situation | Behavior |
|---|---|
| `@bind-SelectedValue` or `@bind-SelectedValues` supplied | **Controlled.** Parent values are authoritative after each render. |
| No bind, only events | **Uncontrolled.** The component keeps internal selection and reports changes. |
| Initial value not in DataSource | Ignored. No exception. Development warning. |
| Both SelectedValue and SelectedValues set | Mode decides. Single uses SelectedValue. Multiple uses SelectedValues. |
| External update equal to current | No SelectionChanging or SelectionChanged. |
| Mutable list passed as SelectedValues | Snapshotted. The caller collection is not mutated. |
| Disabled item in incoming selection | Stripped, with a Development warning. |

**Event order:** `SelectionChanging` → apply state → bind callback → `SelectionChanged`. Cancellation leaves state unchanged and suppresses later callbacks. Programmatic clear and select-all use the same pipeline.

### 3.3 Identity resolution

1. `ItemKey(item)` when set.
2. Otherwise `ValueSelector`, then `ValueField`.
3. Otherwise the item, using `Comparer` or `EqualityComparer<TItem>.Default`.

Key equality uses `KeyComparer` or `EqualityComparer<object>.Default`. Null keys are allowed with a Development warning. Duplicate keys use last-wins and produce a Development warning.

### 3.4 Events

| Name | Type | Notes |
|---|---|---|
| SelectionChanging | `EventCallback<ListSelectionChangingEventArgs<TItem>>` | Cancellable |
| SelectionChanged | `EventCallback<ListSelectionChangedEventArgs<TItem>>` | After commit |
| OnItemClick | `EventCallback<ListItemClickEventArgs<TItem>>` | Pointer or keyboard activation |

### 3.5 Methods

```csharp
public void ClearSelection();
public void SelectAll();
public ValueTask FocusAsync();
public ValueTask ScrollIntoViewAsync(TItem item);
public ValueTask DisposeAsync();
```

- `ClearSelection` uses the selection pipeline. It is a no-op when `SelectionMode` is `None`.
- `SelectAll` selects enabled items when `SelectionMode` is `Multiple`. It is a no-op otherwise.
- `FocusAsync` moves keyboard focus to the active item in a selectable list, or to the list root in a passive list. It completes without throwing when the list is not yet rendered.
- `ScrollIntoViewAsync` scrolls the item into view, including a virtualized item that is not yet realized. It throws `ArgumentNullException` when `item` is null.
- `DisposeAsync` is idempotent. It unregisters items, clears internal maps, and cancels pending work.

### 3.6 Cascading values

Internal `ListContext` provides selection and check modes, density, disabled state, the active item id, and item registration. It is not public application API.

### 3.7 Public CSS

| Class | Element | Meaning |
|---|---|---|
| e-list | root | Root |
| e-list-item | item | Item |
| e-list-item-selected | item | Selected |
| e-list-item-checked | item | Checked |
| e-list-item-disabled | item | Disabled |
| e-list-item-focused | item | Keyboard focus |
| e-list-item-expanded | item | Nested list expanded |
| e-list-dense | root | Density is Dense |
| e-list-group | group | Group container |
| e-list-header | header | Header |
| e-list-footer | footer | Footer |
| e-list-subheader | subheader | Subheader |
| e-list-divider | divider | Divider |
| e-list-empty | region | Empty |
| e-list-loading | region | Loading |
| e-list-error | region | Error |
| e-list-item-level-{n} | item | Zero-based nesting depth |

Public CSS variables: `--e-list-item-min-height`, `--e-list-item-padding`, `--e-list-focus-outline`, `--e-list-selected-bg`, `--e-list-selected-color`, `--e-list-indent-level`, `--e-list-checked-indicator`.

There is no drag-handle class in v1.

### 3.8 Invalid configuration

| Case | Behavior |
|---|---|
| IsLoading and HasError both true | ErrorTemplate wins |
| SelectAll when Mode is Single or None | No-op |
| SelectedValue when Mode is None | Ignored |
| Missing text mapping | `ToString()` plus a Development warning |
| Duplicate keys | Last wins plus a Development warning |
| Unknown field name | Fallback plus a Development warning |
| Sort, drag, reorder, or persistence parameter | Not part of this contract |

### 3.9 Accessibility impact

- `SelectionMode.None` uses `role="list"` and `role="listitem"`.
- `Single` and `Multiple` use `role="listbox"` and `role="option"`.
- `Multiple` sets `aria-multiselectable="true"`.
- `AriaLabel` and `AriaLabelledBy` provide the accessible name.
- Disabled state maps to `aria-disabled` and blocks selection, check, and expand.
- Check UI uses checkbox semantics and does not replace option or listitem state.
- Expandable items expose `aria-expanded`.
- Selectable lists use roving `tabindex="0"` / `-1`. Nested interactive content remains in the tab order.

### 3.10 Trimming / AOT

Prefer selector delegates over reflection-based field names for trimmed or AOT publishing. Document any reflection retention requirements in the Toolkit trimming guide.

### 3.11 Threading

UI-thread only through the Blazor dispatcher. Not safe for concurrent background calls.

## 4. SfListItem

| Name | Type | Default | Two-way | Notes |
|---|---|---:|---|---|
| Text | `string?` | `null` | No | Primary text |
| SecondaryText | `string?` | `null` | No | Supporting text |
| Icon | `string?` | `null` | No | Leading icon class or path |
| Disabled | `bool` | `false` | No | Not selectable, checkable, or expandable |
| Selected | `bool` | `false` | No | Declarative override |
| Checked | `bool` | `false` | Yes | With CheckedChanged |
| CheckedChanged | `EventCallback<bool>` | — | — | |
| Expanded | `bool` | `false` | Yes | Nested list |
| ExpandedChanged | `EventCallback<bool>` | — | — | |
| DefaultExpanded | `bool` | `false` | No | Initial only when Expanded is not bound |
| Href | `string?` | `null` | No | Prefer SelectionMode.None |
| Target | `string?` | `null` | No | Link target |
| CssClass | `string?` | `null` | No | |
| AdditionalAttributes | `Dictionary<string, object>?` | `null` | No | `CaptureUnmatchedValues = true` |
| ChildContent | `RenderFragment?` | `null` | No | |
| LeadingContent | `RenderFragment?` | `null` | No | |
| TrailingContent | `RenderFragment?` | `null` | No | |
| NestedList | `RenderFragment?` | `null` | No | Nested `SfList` |
| OnClick | `EventCallback<MouseEventArgs>` | — | No | |
| ExpansionChanging | `EventCallback<ListExpansionChangingEventArgs>` | — | No | Cancellable |
| ExpansionChanged | `EventCallback<ListExpansionChangedEventArgs>` | — | No | After commit |

`ExpandAsync()` and `CollapseAsync()` use the expansion pipeline. Both are no-ops when `NestedList` is null.

## 5. Supporting components

### SfListGroup

`Header` (`string?`), `HeaderTemplate` (`RenderFragment?`), `CssClass`, `AdditionalAttributes`, and `ChildContent`.

### SfListHeader / SfListFooter

`ChildContent`, `CssClass`, and `AdditionalAttributes`.

### SfListSubheader

`Text` (`string?`), `ChildContent`, `CssClass`, and `AdditionalAttributes`.

### SfListDivider

`CssClass` and `AdditionalAttributes`.

Supporting components have no selection, check, sort, drag, or persistence API.

## 6. Versioning and breaking-change risks

- Additive parameters or events: minor.
- Renaming a public CSS class or parameter: major.
- Changing the default selection mode or role mapping: major.
- Changing event order: major.
- No public constants in v1.
- This contract is proposed. It is not frozen until implementation review accepts it.
