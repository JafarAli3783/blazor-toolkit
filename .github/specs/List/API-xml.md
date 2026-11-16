# API-xml.md

> Proposed XML documentation for the members in `API.md` only. This file adds no public member that `API.md` does not name. It is not implementation source and has not been compiled.

```csharp
/// <summary>
/// Renders a reusable, accessible list that supports passive, selectable, checkable, grouped, nested, and virtualized scenarios.
/// </summary>
/// <typeparam name="TItem">The type of the data item.</typeparam>
/// <remarks>
/// <para>
/// When <see cref="SelectionMode"/> is <see cref="ListSelectionMode.None"/>, the root uses <c>role="list"</c>.
/// When selection is single or multiple, the root uses <c>role="listbox"</c> and items use <c>role="option"</c>.
/// </para>
/// <para>
/// Field-name parameters and typed selectors are separate. When both are set, the selector wins.
/// Supply a stable identity through <see cref="ItemKey"/>, <see cref="ValueSelector"/>, <see cref="ValueField"/>, or <see cref="Comparer"/>
/// so selection and focus survive a data refresh.
/// </para>
/// <para>
/// Built-in sorting, drag-and-drop, and component-owned persistence are not part of this contract.
/// </para>
/// </remarks>
public partial class SfList<TItem> : ComponentBase, IAsyncDisposable
{
    /// <summary>Gets or sets the items to display.</summary>
    [Parameter] public IEnumerable<TItem>? DataSource { get; set; }

    /// <summary>Gets or sets the property name that supplies display text. Ignored when <see cref="TextSelector"/> is set.</summary>
    [Parameter] public string? TextField { get; set; }

    /// <summary>Gets or sets the selector that supplies display text. Wins over <see cref="TextField"/>.</summary>
    [Parameter] public Func<TItem, string?>? TextSelector { get; set; }

    /// <summary>Gets or sets the property name used for item identity. Ignored when <see cref="ValueSelector"/> is set.</summary>
    [Parameter] public string? ValueField { get; set; }

    /// <summary>Gets or sets the selector used for item identity. Wins over <see cref="ValueField"/>.</summary>
    [Parameter] public Func<TItem, object?>? ValueSelector { get; set; }

    /// <summary>Gets or sets the property name that indicates a disabled item. Ignored when <see cref="DisabledSelector"/> is set.</summary>
    [Parameter] public string? DisabledField { get; set; }

    /// <summary>Gets or sets the selector that indicates a disabled item. Wins over <see cref="DisabledField"/>.</summary>
    [Parameter] public Func<TItem, bool>? DisabledSelector { get; set; }

    /// <summary>Gets or sets the property name that supplies an icon class or path. Ignored when <see cref="IconSelector"/> is set.</summary>
    [Parameter] public string? IconField { get; set; }

    /// <summary>Gets or sets the selector that supplies an icon class or path. Wins over <see cref="IconField"/>.</summary>
    [Parameter] public Func<TItem, string?>? IconSelector { get; set; }

    /// <summary>Gets or sets the property name used for grouping. Ignored when <see cref="GroupSelector"/> is set.</summary>
    [Parameter] public string? GroupField { get; set; }

    /// <summary>Gets or sets the selector used for grouping. Wins over <see cref="GroupField"/>.</summary>
    [Parameter] public Func<TItem, string?>? GroupSelector { get; set; }

    /// <summary>Gets or sets the property name that returns nested child items. Ignored when <see cref="ChildItemsSelector"/> is set.</summary>
    [Parameter] public string? ChildItemsField { get; set; }

    /// <summary>Gets or sets the selector that returns nested child items. Wins over <see cref="ChildItemsField"/>.</summary>
    [Parameter] public Func<TItem, IEnumerable<TItem>?>? ChildItemsSelector { get; set; }

    /// <summary>Gets or sets the factory that produces a stable key for each item.</summary>
    [Parameter] public Func<TItem, object>? ItemKey { get; set; }

    /// <summary>Gets or sets item equality when no key is used.</summary>
    [Parameter] public IEqualityComparer<TItem>? Comparer { get; set; }

    /// <summary>Gets or sets equality for keys produced by <see cref="ItemKey"/> or <see cref="ValueSelector"/>.</summary>
    [Parameter] public IEqualityComparer<object>? KeyComparer { get; set; }

    /// <summary>Gets or sets the selection mode. The default is <see cref="ListSelectionMode.None"/>.</summary>
    [Parameter] public ListSelectionMode SelectionMode { get; set; } = ListSelectionMode.None;

    /// <summary>Gets or sets the selected item in single-selection mode.</summary>
    [Parameter] public TItem? SelectedValue { get; set; }

    /// <summary>Occurs when <see cref="SelectedValue"/> changes.</summary>
    [Parameter] public EventCallback<TItem?> SelectedValueChanged { get; set; }

    /// <summary>Gets or sets the selected items in multiple-selection mode.</summary>
    [Parameter] public IEnumerable<TItem>? SelectedValues { get; set; }

    /// <summary>Occurs when <see cref="SelectedValues"/> changes.</summary>
    [Parameter] public EventCallback<IEnumerable<TItem>?> SelectedValuesChanged { get; set; }

    /// <summary>Gets or sets whether items can be checked independently of selection. The default is <see cref="ListCheckMode.None"/>.</summary>
    [Parameter] public ListCheckMode CheckMode { get; set; } = ListCheckMode.None;

    /// <summary>Gets or sets the checked items when <see cref="CheckMode"/> is <see cref="ListCheckMode.Multiple"/>.</summary>
    [Parameter] public IEnumerable<TItem>? CheckedValues { get; set; }

    /// <summary>Occurs when <see cref="CheckedValues"/> changes.</summary>
    [Parameter] public EventCallback<IEnumerable<TItem>?> CheckedValuesChanged { get; set; }

    /// <summary>Gets or sets the template used to render each data item.</summary>
    [Parameter] public RenderFragment<TItem>? ItemTemplate { get; set; }

    /// <summary>Gets or sets the template used to render a group header.</summary>
    [Parameter] public RenderFragment<string>? GroupTemplate { get; set; }

    /// <summary>Gets or sets the template rendered above the items.</summary>
    [Parameter] public RenderFragment? HeaderTemplate { get; set; }

    /// <summary>Gets or sets the template rendered below the items.</summary>
    [Parameter] public RenderFragment? FooterTemplate { get; set; }

    /// <summary>Gets or sets the template shown when the data source is null or empty and there are no declarative children.</summary>
    [Parameter] public RenderFragment? EmptyTemplate { get; set; }

    /// <summary>Gets or sets the template shown while <see cref="IsLoading"/> is <see langword="true"/>.</summary>
    [Parameter] public RenderFragment? LoadingTemplate { get; set; }

    /// <summary>Gets or sets the template shown while <see cref="HasError"/> is <see langword="true"/>.</summary>
    [Parameter] public RenderFragment? ErrorTemplate { get; set; }

    /// <summary>Gets or sets whether the loading template replaces the items.</summary>
    [Parameter] public bool IsLoading { get; set; }

    /// <summary>Gets or sets whether the error template replaces the items and the loading template.</summary>
    [Parameter] public bool HasError { get; set; }

    /// <summary>Gets or sets the visual density. The default is <see cref="ListDensity.Comfortable"/>.</summary>
    [Parameter] public ListDensity Density { get; set; } = ListDensity.Comfortable;

    /// <summary>Gets or sets whether the entire list is disabled.</summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>Gets or sets a fixed CSS height.</summary>
    [Parameter] public string? Height { get; set; }

    /// <summary>Gets or sets the maximum CSS height.</summary>
    [Parameter] public string? MaxHeight { get; set; }

    /// <summary>Gets or sets whether virtualization is enabled. This is one-way for the component lifetime.</summary>
    [Parameter] public bool EnableVirtualization { get; set; }

    /// <summary>Gets or sets the accessible name of the list.</summary>
    [Parameter] public string? AriaLabel { get; set; }

    /// <summary>Gets or sets the id of the element that labels the list.</summary>
    [Parameter] public string? AriaLabelledBy { get; set; }

    /// <summary>Gets or sets additional CSS classes applied to the root.</summary>
    [Parameter] public string? CssClass { get; set; }

    /// <summary>Gets or sets the root element id. A generated id is used when this is null.</summary>
    [Parameter] public string? Id { get; set; }

    /// <summary>Gets or sets unmatched attributes applied to the root element.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>Gets or sets declarative child content, including <see cref="SfListItem"/> elements.</summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>Occurs before the selection changes. Set <see cref="ListSelectionChangingEventArgs{TItem}.Cancel"/> to keep the current selection.</summary>
    [Parameter] public EventCallback<ListSelectionChangingEventArgs<TItem>> SelectionChanging { get; set; }

    /// <summary>Occurs after the selection has changed.</summary>
    [Parameter] public EventCallback<ListSelectionChangedEventArgs<TItem>> SelectionChanged { get; set; }

    /// <summary>Occurs when an item is activated by pointer or keyboard.</summary>
    [Parameter] public EventCallback<ListItemClickEventArgs<TItem>> OnItemClick { get; set; }

    /// <summary>Clears the current selection through the cancellable selection pipeline. No-op when selection mode is <see cref="ListSelectionMode.None"/>.</summary>
    public void ClearSelection() { }

    /// <summary>Selects all enabled items when selection mode is <see cref="ListSelectionMode.Multiple"/>. No-op otherwise.</summary>
    public void SelectAll() { }

    /// <summary>Moves keyboard focus to the active item, or to the list root when selection is disabled.</summary>
    public ValueTask FocusAsync() => default;

    /// <summary>Scrolls the specified item into view, including an item that virtualization has not yet realized.</summary>
    /// <exception cref="ArgumentNullException"><paramref name="item"/> is <see langword="null"/>.</exception>
    public ValueTask ScrollIntoViewAsync(TItem item) => default;

    /// <summary>Releases item registrations and pending work. Safe to call more than once.</summary>
    public ValueTask DisposeAsync() => default;
}

/// <summary>Represents one item inside an <see cref="SfList{TItem}"/>.</summary>
public partial class SfListItem : ComponentBase
{
    /// <summary>Gets or sets the primary text.</summary>
    [Parameter] public string? Text { get; set; }

    /// <summary>Gets or sets the supporting text.</summary>
    [Parameter] public string? SecondaryText { get; set; }

    /// <summary>Gets or sets the leading icon class or path.</summary>
    [Parameter] public string? Icon { get; set; }

    /// <summary>Gets or sets whether the item is disabled.</summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>Gets or sets whether the item is selected.</summary>
    [Parameter] public bool Selected { get; set; }

    /// <summary>Gets or sets whether the item is checked. Independent of <see cref="Selected"/>.</summary>
    [Parameter] public bool Checked { get; set; }

    /// <summary>Occurs when <see cref="Checked"/> changes.</summary>
    [Parameter] public EventCallback<bool> CheckedChanged { get; set; }

    /// <summary>Gets or sets whether the nested list is expanded.</summary>
    [Parameter] public bool Expanded { get; set; }

    /// <summary>Occurs when <see cref="Expanded"/> changes.</summary>
    [Parameter] public EventCallback<bool> ExpandedChanged { get; set; }

    /// <summary>Gets or sets the initial expanded state when <see cref="Expanded"/> is not bound.</summary>
    [Parameter] public bool DefaultExpanded { get; set; }

    /// <summary>Gets or sets the navigation URL. Prefer <see cref="ListSelectionMode.None"/> for link lists.</summary>
    [Parameter] public string? Href { get; set; }

    /// <summary>Gets or sets the link target.</summary>
    [Parameter] public string? Target { get; set; }

    /// <summary>Gets or sets additional CSS classes.</summary>
    [Parameter] public string? CssClass { get; set; }

    /// <summary>Gets or sets unmatched attributes applied to the item.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>Gets or sets custom item content.</summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>Gets or sets leading-slot content.</summary>
    [Parameter] public RenderFragment? LeadingContent { get; set; }

    /// <summary>Gets or sets trailing-slot content.</summary>
    [Parameter] public RenderFragment? TrailingContent { get; set; }

    /// <summary>Gets or sets a nested list.</summary>
    [Parameter] public RenderFragment? NestedList { get; set; }

    /// <summary>Occurs when the item is clicked.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    /// <summary>Occurs before expansion changes. Set <see cref="ListExpansionChangingEventArgs.Cancel"/> to keep the current state.</summary>
    [Parameter] public EventCallback<ListExpansionChangingEventArgs> ExpansionChanging { get; set; }

    /// <summary>Occurs after expansion has changed.</summary>
    [Parameter] public EventCallback<ListExpansionChangedEventArgs> ExpansionChanged { get; set; }

    /// <summary>Expands the nested list through the cancellable expansion pipeline. No-op when <see cref="NestedList"/> is null.</summary>
    public ValueTask ExpandAsync() => default;

    /// <summary>Collapses the nested list through the cancellable expansion pipeline. No-op when <see cref="NestedList"/> is null.</summary>
    public ValueTask CollapseAsync() => default;
}

/// <summary>Groups declarative list items under a header.</summary>
public partial class SfListGroup : ComponentBase
{
    /// <summary>Gets or sets the group header text.</summary>
    [Parameter] public string? Header { get; set; }

    /// <summary>Gets or sets custom group-header content.</summary>
    [Parameter] public RenderFragment? HeaderTemplate { get; set; }

    /// <summary>Gets or sets additional CSS classes.</summary>
    [Parameter] public string? CssClass { get; set; }

    /// <summary>Gets or sets unmatched attributes applied to the group.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>Gets or sets the grouped items.</summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }
}

/// <summary>Renders content above the list items.</summary>
public partial class SfListHeader : ComponentBase
{
    /// <summary>Gets or sets header content.</summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>Gets or sets additional CSS classes.</summary>
    [Parameter] public string? CssClass { get; set; }

    /// <summary>Gets or sets unmatched attributes applied to the header.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }
}

/// <summary>Renders content below the list items.</summary>
public partial class SfListFooter : ComponentBase
{
    /// <summary>Gets or sets footer content.</summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>Gets or sets additional CSS classes.</summary>
    [Parameter] public string? CssClass { get; set; }

    /// <summary>Gets or sets unmatched attributes applied to the footer.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }
}

/// <summary>Renders a group subheader.</summary>
public partial class SfListSubheader : ComponentBase
{
    /// <summary>Gets or sets the subheader text.</summary>
    [Parameter] public string? Text { get; set; }

    /// <summary>Gets or sets custom subheader content.</summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>Gets or sets additional CSS classes.</summary>
    [Parameter] public string? CssClass { get; set; }

    /// <summary>Gets or sets unmatched attributes applied to the subheader.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }
}

/// <summary>Renders a non-interactive divider between list regions.</summary>
public partial class SfListDivider : ComponentBase
{
    /// <summary>Gets or sets additional CSS classes.</summary>
    [Parameter] public string? CssClass { get; set; }

    /// <summary>Gets or sets unmatched attributes applied to the divider.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }
}

/// <summary>Specifies how list items can be selected.</summary>
public enum ListSelectionMode
{
    /// <summary>No selection. The list uses role=list.</summary>
    None = 0,
    /// <summary>Only one item may be selected.</summary>
    Single = 1,
    /// <summary>More than one item may be selected.</summary>
    Multiple = 2
}

/// <summary>Specifies list item density.</summary>
public enum ListDensity
{
    /// <summary>Standard spacing.</summary>
    Comfortable = 0,
    /// <summary>Reduced vertical padding.</summary>
    Dense = 1
}

/// <summary>Specifies whether items can be checked independently of selection.</summary>
public enum ListCheckMode
{
    /// <summary>No check UI.</summary>
    None = 0,
    /// <summary>Items can be checked independently of selection.</summary>
    Multiple = 1
}

/// <summary>Provides data for <see cref="SfList{TItem}.SelectionChanging"/>.</summary>
public sealed class ListSelectionChangingEventArgs<TItem> : EventArgs
{
    /// <summary>Gets or sets whether the change is cancelled.</summary>
    public bool Cancel { get; set; }

    /// <summary>Gets items about to be added.</summary>
    public IReadOnlyList<TItem> AddedItems { get; init; } = Array.Empty<TItem>();

    /// <summary>Gets items about to be removed.</summary>
    public IReadOnlyList<TItem> RemovedItems { get; init; } = Array.Empty<TItem>();

    /// <summary>Gets the proposed selection.</summary>
    public IReadOnlyList<TItem> SelectedItems { get; init; } = Array.Empty<TItem>();
}

/// <summary>Provides data for <see cref="SfList{TItem}.SelectionChanged"/>.</summary>
public sealed class ListSelectionChangedEventArgs<TItem> : EventArgs
{
    /// <summary>Gets items added to the selection.</summary>
    public IReadOnlyList<TItem> AddedItems { get; init; } = Array.Empty<TItem>();

    /// <summary>Gets items removed from the selection.</summary>
    public IReadOnlyList<TItem> RemovedItems { get; init; } = Array.Empty<TItem>();

    /// <summary>Gets the selection after the change.</summary>
    public IReadOnlyList<TItem> SelectedItems { get; init; } = Array.Empty<TItem>();
}

/// <summary>Provides data for <see cref="SfList{TItem}.OnItemClick"/>.</summary>
public sealed class ListItemClickEventArgs<TItem> : EventArgs
{
    /// <summary>Gets the activated item.</summary>
    public required TItem Item { get; init; }

    /// <summary>Gets the original pointer event arguments.</summary>
    public required MouseEventArgs OriginalArgs { get; init; }

    /// <summary>Gets whether the item is selected after the activation policy runs.</summary>
    public bool IsSelected { get; init; }

    /// <summary>Gets whether the item is checked after the activation policy runs.</summary>
    public bool IsChecked { get; init; }
}

/// <summary>Provides data for <see cref="SfListItem.ExpansionChanging"/>.</summary>
public sealed class ListExpansionChangingEventArgs : EventArgs
{
    /// <summary>Gets or sets whether the expansion change is cancelled.</summary>
    public bool Cancel { get; set; }

    /// <summary>Gets whether the change would expand the item.</summary>
    public bool Expanding { get; init; }
}

/// <summary>Provides data for <see cref="SfListItem.ExpansionChanged"/>.</summary>
public sealed class ListExpansionChangedEventArgs : EventArgs
{
    /// <summary>Gets whether the item is expanded after the change.</summary>
    public bool Expanded { get; init; }
}
```
