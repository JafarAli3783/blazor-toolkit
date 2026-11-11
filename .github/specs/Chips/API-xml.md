# APIXML.md — XML documentation (revision 2)
## Syncfusion Blazor Toolkit Chips

Complete XML for every public symbol. Implementation must include these comments to satisfy CS1591.

```csharp
namespace Syncfusion.Blazor.Toolkit;

/// <summary>Specifies the functional and semantic behavior of a chip.</summary>
/// <remarks>Passive modes (<see cref="Informational"/>, <see cref="Status"/>) must not be exposed as buttons. Interactive modes use native elements appropriate to the mode.</remarks>
public enum ChipType
{
    /// <summary>Non-interactive informational content.</summary>
    Informational = 0,
    /// <summary>Non-interactive status content.</summary>
    Status = 1,
    /// <summary>Command activation using a native button.</summary>
    Action = 2,
    /// <summary>Assistive action using a native button.</summary>
    Assist = 3,
    /// <summary>Toggleable filter value; uses a pressed state.</summary>
    Filter = 4,
    /// <summary>Mutually exclusive choice within a chip set.</summary>
    Choice = 5,
    /// <summary>User token that is typically removable.</summary>
    Input = 6,
    /// <summary>Suggestion that notifies the host when activated.</summary>
    Suggestion = 7,
    /// <summary>Navigation chip rendered as a link when <c>Href</c> is set.</summary>
    Navigation = 8,
    /// <summary>Author-defined behavior via templates and attributes.</summary>
    Custom = 9
}

/// <summary>Specifies selection behavior for a chip set.</summary>
public enum ChipSelectionMode
{
    /// <summary>Selection is not tracked.</summary>
    None = 0,
    /// <summary>At most one value may be selected.</summary>
    Single = 1,
    /// <summary>Zero or more values may be selected.</summary>
    Multiple = 2
}

/// <summary>Visual surface style of a chip.</summary>
public enum ChipVariant
{
    /// <summary>Filled surface.</summary>
    Filled = 0,
    /// <summary>Outlined surface.</summary>
    Outlined = 1
}

/// <summary>Chip size density.</summary>
public enum ChipSize
{
    /// <summary>Compact density.</summary>
    Small = 0,
    /// <summary>Default density.</summary>
    Medium = 1,
    /// <summary>Comfortable density.</summary>
    Large = 2
}

/// <summary>Corner shape of a chip.</summary>
public enum ChipShape
{
    /// <summary>Standard rounded corners.</summary>
    Rounded = 0,
    /// <summary>Pill-shaped ends.</summary>
    Pill = 1
}

/// <summary>How a chip set handles limited horizontal space.</summary>
public enum ChipOverflowMode
{
    /// <summary>Wrap onto additional lines.</summary>
    Wrap = 0,
    /// <summary>Single line with horizontal scrolling.</summary>
    Scroll = 1,
    /// <summary>Collapse overflowing chips behind an expand control.</summary>
    Collapse = 2
}

/// <summary>Why a chip removal was requested.</summary>
public enum ChipRemoveReason
{
    /// <summary>Remove control activation.</summary>
    RemoveButton = 0,
    /// <summary>Delete or Backspace key.</summary>
    Keyboard = 1,
    /// <summary>Public API method.</summary>
    Programmatic = 2
}

/// <summary>Maps property names on a data item to chip fields when selector delegates are not provided.</summary>
public sealed class ChipFields
{
    /// <summary>Property name for display text.</summary>
    public string? Text { get; set; }
    /// <summary>Property name for selection value.</summary>
    public string? Value { get; set; }
    /// <summary>Property name for disabled state.</summary>
    public string? Disabled { get; set; }
    /// <summary>Property name for removable state.</summary>
    public string? Removable { get; set; }
    /// <summary>Property name for leading icon CSS class.</summary>
    public string? IconCss { get; set; }
    /// <summary>Property name for leading image URL.</summary>
    public string? ImageUrl { get; set; }
    /// <summary>Property name for image alternate text.</summary>
    public string? ImageAlt { get; set; }
    /// <summary>Property name for additional CSS classes.</summary>
    public string? CssClass { get; set; }
    /// <summary>Property name for navigation URL.</summary>
    public string? Href { get; set; }
}

/// <summary>Cancelable removal data for <see cref="SfChip"/>.</summary>
public class ChipRemovingEventArgs
{
    /// <summary>Chip text used when no data item exists.</summary>
    public string? Text { get; init; }
    /// <summary>Resolved key, if any.</summary>
    public object? Key { get; init; }
    /// <summary>Removal reason.</summary>
    public ChipRemoveReason Reason { get; init; }
    /// <summary>Set to <c>true</c> to cancel removal.</summary>
    public bool Cancel { get; set; }
}

/// <summary>Cancelable removal data for <see cref="SfChipSet{TItem}"/>.</summary>
/// <typeparam name="TItem">Data item type.</typeparam>
public class ChipRemovingEventArgs<TItem> : ChipRemovingEventArgs
{
    /// <summary>Item being removed.</summary>
    public TItem Item { get; init; } = default!;
}

/// <summary>Data after a chip has been removed from <see cref="SfChip"/>.</summary>
public class ChipRemovedEventArgs
{
    /// <summary>Chip text when no data item exists.</summary>
    public string? Text { get; init; }
    /// <summary>Resolved key, if any.</summary>
    public object? Key { get; init; }
    /// <summary>Removal reason.</summary>
    public ChipRemoveReason Reason { get; init; }
}

/// <summary>Data after a chip has been removed from <see cref="SfChipSet{TItem}"/>.</summary>
/// <typeparam name="TItem">Data item type.</typeparam>
public class ChipRemovedEventArgs<TItem> : ChipRemovedEventArgs
{
    /// <summary>Removed item.</summary>
    public TItem Item { get; init; } = default!;
}

/// <summary>Cancelable selection change data.</summary>
/// <typeparam name="TItem">Data item type.</typeparam>
public class ChipSelectionChangingEventArgs<TItem>
{
    /// <summary>Item associated with the change, if any.</summary>
    public TItem? Item { get; init; }
    /// <summary>Value associated with the change.</summary>
    public object? Value { get; init; }
    /// <summary>Selected values before the change.</summary>
    public IReadOnlyList<object?> CurrentSelectedValues { get; init; } = Array.Empty<object?>();
    /// <summary>Selected values that will apply if the change is not canceled.</summary>
    public IReadOnlyList<object?> ProposedSelectedValues { get; init; } = Array.Empty<object?>();
    /// <summary>Set to <c>true</c> to cancel the selection change.</summary>
    public bool Cancel { get; set; }
}

/// <summary>Selection change data after a successful update.</summary>
/// <typeparam name="TItem">Data item type.</typeparam>
public class ChipSelectionChangedEventArgs<TItem>
{
    /// <summary>Item associated with the change, if any.</summary>
    public TItem? Item { get; init; }
    /// <summary>Value associated with the change.</summary>
    public object? Value { get; init; }
    /// <summary>Selected values after the change.</summary>
    public IReadOnlyList<object?> SelectedValues { get; init; } = Array.Empty<object?>();
}

/// <summary>Activation data that is not a remove action.</summary>
/// <typeparam name="TItem">Data item type.</typeparam>
public class ChipClickEventArgs<TItem>
{
    /// <summary>Activated item.</summary>
    public TItem Item { get; init; } = default!;
    /// <summary>Resolved key, if any.</summary>
    public object? Key { get; init; }
    /// <summary>Pointer arguments when activation came from a pointer device.</summary>
    public MouseEventArgs? OriginalArgs { get; init; }
}

/// <summary>A single chip with semantic mode, optional selection presentation, and optional removal.</summary>
/// <remarks>
/// <para>Passive modes are not focusable controls. Interactive modes use native button or link elements.</para>
/// <para>Token text entry is not provided by this component. Compose an input with <see cref="SfChipSet{TItem}"/> for input-token scenarios.</para>
/// </remarks>
/// <example><code>&lt;SfChip ChipType="ChipType.Action" Text="Save" OnClick="SaveAsync" /&gt;</code></example>
public partial class SfChip : ComponentBase
{
    /// <summary>Chip body content. When set, takes precedence over <see cref="Text"/>.</summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }
    /// <summary>Text displayed when <see cref="ChildContent"/> is null.</summary>
    [Parameter] public string? Text { get; set; }
    /// <summary>Semantic behavior of the chip.</summary>
    /// <value>Default is <see cref="ChipType.Informational"/>.</value>
    [Parameter] public ChipType ChipType { get; set; } = ChipType.Informational;
    /// <summary>Visual variant.</summary>
    /// <value>Default is <see cref="ChipVariant.Filled"/>.</value>
    [Parameter] public ChipVariant Variant { get; set; } = ChipVariant.Filled;
    /// <summary>Size density.</summary>
    /// <value>Default is <see cref="ChipSize.Medium"/>.</value>
    [Parameter] public ChipSize Size { get; set; } = ChipSize.Medium;
    /// <summary>Corner shape.</summary>
    /// <value>Default is <see cref="ChipShape.Rounded"/>.</value>
    [Parameter] public ChipShape Shape { get; set; } = ChipShape.Rounded;
    /// <summary>When true, the chip does not accept activation, selection toggles, or removal.</summary>
    [Parameter] public bool Disabled { get; set; }
    /// <summary>When true, the user cannot change selection or remove the chip.</summary>
    [Parameter] public bool ReadOnly { get; set; }
    /// <summary>When true, a remove control is rendered if the chip is not disabled or read-only.</summary>
    [Parameter] public bool Removable { get; set; }
    /// <summary>Selected or pressed state for standalone filter/choice presentations.</summary>
    [Parameter] public bool Selected { get; set; }
    /// <summary>Two-way binding callback for <see cref="Selected"/>.</summary>
    [Parameter] public EventCallback<bool> SelectedChanged { get; set; }
    /// <summary>Navigation URL. Required for true link semantics when <see cref="ChipType"/> is <see cref="ChipType.Navigation"/>.</summary>
    [Parameter] public string? Href { get; set; }
    /// <summary>Target for navigation chips.</summary>
    [Parameter] public string? Target { get; set; }
    /// <summary>Rel attribute for navigation chips.</summary>
    [Parameter] public string? Rel { get; set; }
    /// <summary>Leading icon CSS class.</summary>
    [Parameter] public string? IconCss { get; set; }
    /// <summary>Leading image URL.</summary>
    [Parameter] public string? ImageUrl { get; set; }
    /// <summary>Alternate text for <see cref="ImageUrl"/>. Use an empty string only when the image is decorative.</summary>
    [Parameter] public string? ImageAlt { get; set; }
    /// <summary>Additional CSS classes for the root element.</summary>
    [Parameter] public string? CssClass { get; set; }
    /// <summary>Inline styles for the root element.</summary>
    [Parameter] public string? Style { get; set; }
    /// <summary>DOM id. When null, a stable generated id may be assigned.</summary>
    [Parameter] public string? Id { get; set; }
    /// <summary>Accessible name override when visible text is insufficient.</summary>
    [Parameter] public string? AriaLabel { get; set; }
    /// <summary>Optional aria-describedby element id list.</summary>
    [Parameter] public string? AriaDescribedBy { get; set; }
    /// <summary>Optional tabindex override. Prefer default focus rules when null.</summary>
    [Parameter] public int? TabIndex { get; set; }
    /// <summary>Additional HTML attributes for the root element. Supports capture of unmatched values when configured on the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? HtmlAttributes { get; set; }
    /// <summary>Leading slot content.</summary>
    [Parameter] public RenderFragment? LeadingTemplate { get; set; }
    /// <summary>Trailing slot content.</summary>
    [Parameter] public RenderFragment? TrailingTemplate { get; set; }
    /// <summary>Replaces the default remove control. The result must remain an operable button with an accessible name.</summary>
    [Parameter] public RenderFragment? RemoveTemplate { get; set; }
    /// <summary>Raised when the primary chip surface is activated. Not raised for remove-control activation.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
    /// <summary>Cancelable callback before removal.</summary>
    [Parameter] public EventCallback<ChipRemovingEventArgs> Removing { get; set; }
    /// <summary>Callback after successful removal.</summary>
    [Parameter] public EventCallback<ChipRemovedEventArgs> Removed { get; set; }
    /// <summary>Moves focus to the chip primary focusable element.</summary>
    /// <returns>A task representing the operation.</returns>
    public ValueTask FocusAsync() => default;
    /// <summary>Moves focus to the remove control when present.</summary>
    /// <returns>A task representing the operation.</returns>
    public ValueTask FocusRemoveAsync() => default;
}

/// <summary>A set of chips with optional data binding, selection, removal, overflow, and state templates.</summary>
/// <typeparam name="TItem">Type of each data item.</typeparam>
/// <remarks>
/// <para>The set is not a listbox by default. Selection semantics follow <see cref="SelectionMode"/> and <see cref="ChipType"/>.</para>
/// <para>Token text entry is not owned by this component. Compose a separate input with the set when building input-token UX.</para>
/// <para>State template precedence: error over loading over empty over items.</para>
/// </remarks>
public partial class SfChipSet<TItem> : ComponentBase
{
    /// <summary>Declarative chip content when not using <see cref="DataSource"/>.</summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }
    /// <summary>Items rendered as chips. Null is treated as empty.</summary>
    [Parameter] public IEnumerable<TItem>? DataSource { get; set; }
    /// <summary>Returns a stable identity for each item. Required for reliable selection and removal with complex types.</summary>
    [Parameter] public Func<TItem, object>? ItemKey { get; set; }
    /// <summary>Returns display text. Takes precedence over <see cref="Fields"/>.</summary>
    [Parameter] public Func<TItem, string>? TextSelector { get; set; }
    /// <summary>Returns the selection value for an item.</summary>
    [Parameter] public Func<TItem, object?>? ValueSelector { get; set; }
    /// <summary>Returns whether an item is disabled.</summary>
    [Parameter] public Func<TItem, bool>? DisabledSelector { get; set; }
    /// <summary>Returns whether an item is removable.</summary>
    [Parameter] public Func<TItem, bool>? RemovableSelector { get; set; }
    /// <summary>Returns leading icon CSS class.</summary>
    [Parameter] public Func<TItem, string?>? IconCssSelector { get; set; }
    /// <summary>Returns leading image URL.</summary>
    [Parameter] public Func<TItem, string?>? ImageUrlSelector { get; set; }
    /// <summary>Returns image alternate text.</summary>
    [Parameter] public Func<TItem, string?>? ImageAltSelector { get; set; }
    /// <summary>Returns navigation URL.</summary>
    [Parameter] public Func<TItem, string?>? HrefSelector { get; set; }
    /// <summary>Returns additional per-item CSS classes.</summary>
    [Parameter] public Func<TItem, string?>? CssClassSelector { get; set; }
    /// <summary>Property-name mappings used when selector delegates are not set.</summary>
    [Parameter] public ChipFields? Fields { get; set; }
    /// <summary>Default semantic type for projected items.</summary>
    /// <value>Default is <see cref="ChipType.Informational"/>.</value>
    [Parameter] public ChipType ChipType { get; set; } = ChipType.Informational;
    /// <summary>Selection behavior for the set.</summary>
    /// <value>Default is <see cref="ChipSelectionMode.None"/>.</value>
    [Parameter] public ChipSelectionMode SelectionMode { get; set; } = ChipSelectionMode.None;
    /// <summary>Selected value when mode is single.</summary>
    [Parameter] public object? SelectedValue { get; set; }
    /// <summary>Two-way callback for <see cref="SelectedValue"/>.</summary>
    [Parameter] public EventCallback<object?> SelectedValueChanged { get; set; }
    /// <summary>Selected values when mode is multiple.</summary>
    [Parameter] public IEnumerable<object?>? SelectedValues { get; set; }
    /// <summary>Two-way callback for <see cref="SelectedValues"/>.</summary>
    [Parameter] public EventCallback<IEnumerable<object?>?> SelectedValuesChanged { get; set; }
    /// <summary>Allows clearing the selected value in single mode.</summary>
    /// <value>Default is <c>true</c>.</value>
    [Parameter] public bool AllowEmpty { get; set; } = true;
    /// <summary>Disables interaction for the entire set.</summary>
    [Parameter] public bool Disabled { get; set; }
    /// <summary>Prevents user selection and removal changes.</summary>
    [Parameter] public bool ReadOnly { get; set; }
    /// <summary>Default removable state for projected items.</summary>
    [Parameter] public bool Removable { get; set; }
    /// <summary>Default visual variant.</summary>
    [Parameter] public ChipVariant Variant { get; set; } = ChipVariant.Filled;
    /// <summary>Default size.</summary>
    [Parameter] public ChipSize Size { get; set; } = ChipSize.Medium;
    /// <summary>Default shape.</summary>
    [Parameter] public ChipShape Shape { get; set; } = ChipShape.Rounded;
    /// <summary>Overflow layout behavior.</summary>
    /// <value>Default is <see cref="ChipOverflowMode.Wrap"/>.</value>
    [Parameter] public ChipOverflowMode OverflowMode { get; set; } = ChipOverflowMode.Wrap;
    /// <summary>Optional fixed visible count hint in collapse mode.</summary>
    [Parameter] public int? CollapsedVisibleCount { get; set; }
    /// <summary>Shows <see cref="LoadingTemplate"/> and hides items when true.</summary>
    [Parameter] public bool IsLoading { get; set; }
    /// <summary>Shows <see cref="ErrorTemplate"/>. Takes precedence over loading and items.</summary>
    [Parameter] public bool HasError { get; set; }
    /// <summary>Additional root CSS classes.</summary>
    [Parameter] public string? CssClass { get; set; }
    /// <summary>Root inline styles.</summary>
    [Parameter] public string? Style { get; set; }
    /// <summary>Root DOM id.</summary>
    [Parameter] public string? Id { get; set; }
    /// <summary>Accessible name for the set. Recommended when the set is interactive.</summary>
    [Parameter] public string? AriaLabel { get; set; }
    /// <summary>Optional aria-labelledby id list.</summary>
    [Parameter] public string? AriaLabelledBy { get; set; }
    /// <summary>Enables right-to-left presentation.</summary>
    [Parameter] public bool EnableRtl { get; set; }
    /// <summary>Additional root HTML attributes; supports unmatched value capture.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? HtmlAttributes { get; set; }
    /// <summary>Template for each data item's main content.</summary>
    [Parameter] public RenderFragment<TItem>? ChipTemplate { get; set; }
    /// <summary>Leading content template per item.</summary>
    [Parameter] public RenderFragment<TItem>? LeadingTemplate { get; set; }
    /// <summary>Trailing content template per item.</summary>
    [Parameter] public RenderFragment<TItem>? TrailingTemplate { get; set; }
    /// <summary>Remove control template per item.</summary>
    [Parameter] public RenderFragment<TItem>? RemoveTemplate { get; set; }
    /// <summary>Template when there are no items and the set is not loading or in error.</summary>
    [Parameter] public RenderFragment? EmptyTemplate { get; set; }
    /// <summary>Template shown while loading.</summary>
    [Parameter] public RenderFragment? LoadingTemplate { get; set; }
    /// <summary>Template shown when <see cref="HasError"/> is true.</summary>
    [Parameter] public RenderFragment? ErrorTemplate { get; set; }
    /// <summary>Template for the overflow expand control; context is the hidden count.</summary>
    [Parameter] public RenderFragment<int>? OverflowExpandTemplate { get; set; }
    /// <summary>Cancelable callback before selection changes.</summary>
    [Parameter] public EventCallback<ChipSelectionChangingEventArgs<TItem>> SelectionChanging { get; set; }
    /// <summary>Callback after selection changes.</summary>
    [Parameter] public EventCallback<ChipSelectionChangedEventArgs<TItem>> SelectionChanged { get; set; }
    /// <summary>Cancelable callback before a chip is removed.</summary>
    [Parameter] public EventCallback<ChipRemovingEventArgs<TItem>> Removing { get; set; }
    /// <summary>Callback after a chip is removed.</summary>
    [Parameter] public EventCallback<ChipRemovedEventArgs<TItem>> Removed { get; set; }
    /// <summary>Callback when a chip is activated without being removed.</summary>
    [Parameter] public EventCallback<ChipClickEventArgs<TItem>> OnChipClick { get; set; }
    /// <summary>Callback when collapse overflow expanded state changes.</summary>
    [Parameter] public EventCallback<bool> OverflowExpandedChanged { get; set; }
    /// <summary>Selects the chip matching the specified value.</summary>
    /// <param name="value">Selection value.</param>
    public ValueTask SelectAsync(object? value) => default;
    /// <summary>Selects the specified item.</summary>
    /// <param name="item">Item to select.</param>
    public ValueTask SelectItemAsync(TItem item) => default;
    /// <summary>Clears selection when allowed.</summary>
    public ValueTask ClearSelectionAsync() => default;
    /// <summary>Focuses the set or its first focusable chip.</summary>
    public ValueTask FocusAsync() => default;
    /// <summary>Focuses the chip with the specified key.</summary>
    /// <param name="key">Item key.</param>
    public ValueTask FocusChipAsync(object key) => default;
    /// <summary>Requests removal of the chip with the specified key.</summary>
    /// <param name="key">Item key.</param>
    public ValueTask RemoveAsync(object key) => default;
    /// <summary>Requests removal of the specified item.</summary>
    /// <param name="item">Item to remove.</param>
    public ValueTask RemoveItemAsync(TItem item) => default;
    /// <summary>Expands collapsed overflow content.</summary>
    public ValueTask ExpandOverflowAsync() => default;
    /// <summary>Collapses expanded overflow content.</summary>
    public ValueTask CollapseOverflowAsync() => default;
}
```

---

### What changed in this reconsideration (rev 2)

| Gap in prior API docs | Fix |
|---|---|
| Coverage vs expectations unclear | §0 explicit coverage matrix |
| Missing `Rel`, `AriaDescribedBy`, `AriaLabelledBy`, `TabIndex`, `ImageAltSelector` | Added |
| Selection args lacked current vs proposed | `CurrentSelectedValues` / `ProposedSelectedValues` |
| CaptureUnmatchedValues under-specified | Merge rules + Id precedence |
| Form integration silent | §4.5 |
| Out-of-scope APIs ambiguous | §8 explicit exclusions |
| Invalid config incomplete | §10 expanded |
| Exceptions / threading / versioning thin | §11–13 |
| XML missing remarks/examples on components | Added |
| Defaults not locked in one table | §9 |

Method bodies in XML samples are documentation placeholders (`default`); implementation must perform real work.
