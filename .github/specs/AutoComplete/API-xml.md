# SfAutoComplete — Proposed XML documentation inventory

Namespace: `Syncfusion.Blazor.Toolkit`  
Purpose: Proposed XML docs for the API listed here. This source-only design file is not evidence that CS1591 is zero; no AutoComplete implementation exists in the repository to build or audit.

---

```csharp
namespace Syncfusion.Blazor.Toolkit
{
    /// <summary>
    /// An editable combobox that provides type-ahead suggestions from local data or an asynchronous search function.
    /// Implements the WAI-ARIA combobox pattern with list autocomplete.
    /// </summary>
    /// <typeparam name="TItem">The type of suggestion items.</typeparam>
    public partial class SfAutoComplete<TItem> : ComponentBase, IAsyncDisposable
    {
        /// <summary>
        /// Gets or sets the currently selected item.
        /// </summary>
        [Parameter]
        public TItem Value { get; set; }

        /// <summary>
        /// Occurs when <see cref="Value"/> changes.
        /// </summary>
        [Parameter]
        public EventCallback<TItem> ValueChanged { get; set; }

        /// <summary>
        /// Gets or sets the expression that identifies the selected value for form validation.
        /// </summary>
        /// <remarks>
        /// Blazor supplies this expression for <c>@bind-Value</c>. When an <see cref="EditContext"/>
        /// is present, the component uses it to identify the field for validation notifications.
        /// </remarks>
        [Parameter]
        public Expression<Func<TItem>> ValueExpression { get; set; }

        /// <summary>
        /// Gets or sets the text displayed in the input.
        /// </summary>
        [Parameter]
        public string Text { get; set; }

        /// <summary>
        /// Occurs when component-originated input text changes or is restored by the commit policy.
        /// </summary>
        [Parameter]
        public EventCallback<string> TextChanged { get; set; }

        /// <summary>
        /// Gets or sets a function that returns the display string for an item. Preferred for AOT compatibility.
        /// </summary>
        [Parameter]
        public Func<TItem, string> DisplayTextFunc { get; set; }

        /// <summary>
        /// Gets or sets the name of a public readable string property used for display when <see cref="DisplayTextFunc"/> is not set.
        /// A missing/non-string property or getter failure is surfaced through normal Blazor error handling.
        /// Prefer <see cref="DisplayTextFunc"/> in trimmed or AOT-published applications; reflection by property name is not guaranteed trim-safe.
        /// </summary>
        [Parameter]
        public string TextField { get; set; }

        /// <summary>
        /// Gets or sets the local data source used when <see cref="SearchFunc"/> is not provided.
        /// </summary>
        [Parameter]
        public IEnumerable<TItem> Data { get; set; }

        /// <summary>
        /// Gets or sets an asynchronous search function invoked after debounce when the input text changes.
        /// The <see cref="CancellationToken"/> is cancelled when the query changes, an item is selected,
        /// the value is cleared, or the component is disposed. When supplied, this function takes precedence over <see cref="Data"/>.
        /// Exceptions are surfaced through normal Blazor error handling.
        /// </summary>
        [Parameter]
        public Func<string, CancellationToken, Task<IEnumerable<TItem>>> SearchFunc { get; set; }

        /// <summary>
        /// Gets or sets the local filter algorithm applied to <see cref="Data"/>.
        /// Default is <see cref="AutoCompleteFilterType.StartsWith"/>.
        /// </summary>
        [Parameter]
        public AutoCompleteFilterType FilterType { get; set; }

        /// <summary>
        /// Gets or sets whether local filtering is case-sensitive. Default is <c>false</c>.
        /// </summary>
        [Parameter]
        public bool FilterCaseSensitive { get; set; }

        /// <summary>
        /// Gets or sets a custom predicate used when <see cref="FilterType"/> is <see cref="AutoCompleteFilterType.Custom"/>.
        /// The second argument is the current input query. When this predicate is <c>null</c>,
        /// <see cref="AutoCompleteFilterType.Custom"/> produces no local matches.
        /// </summary>
        [Parameter]
        public Func<TItem, string, bool> CustomFilter { get; set; }

        /// <summary>
        /// Gets or sets the debounce interval in milliseconds before a search runs. Default is 300.
        /// Use 0 for immediate search on each input change.
        /// </summary>
        [Parameter]
        public int DebounceInterval { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of characters required before searching. Default is 0.
        /// </summary>
        [Parameter]
        public int MinLength { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of suggestions to display. This is a Phase 2 member.
        /// When <c>null</c>, all matches are shown (subject to performance guidance).
        /// </summary>
        [Parameter]
        public int? MaxItems { get; set; }

        /// <summary>
        /// Gets or sets whether the user must select an item from the list.
        /// When <c>true</c>, free text that does not match a suggestion is reverted on blur according to component policy.
        /// Default is <c>false</c>.
        /// </summary>
        [Parameter]
        public bool ForceSelection { get; set; }

        /// <summary>
        /// Gets or sets whether clearing the input text resets <see cref="Value"/> to its default value.
        /// Default is <c>false</c>.
        /// </summary>
        [Parameter]
        public bool ResetValueOnEmptyText { get; set; }

        /// <summary>
        /// Gets or sets whether the first suggestion is highlighted when results arrive. Default is <c>true</c>.
        /// </summary>
        [Parameter]
        public bool HighlightFirstItem { get; set; }

        /// <summary>
        /// Gets or sets whether match segments are computed for item templates. Default is <c>true</c>.
        /// </summary>
        [Parameter]
        public bool HighlightMatch { get; set; }

        /// <summary>
        /// Gets or sets when the suggestion popup opens. Default is <see cref="AutoCompleteOpenOn.Type"/>.
        /// </summary>
        [Parameter]
        public AutoCompleteOpenOn OpenOn { get; set; }

        /// <summary>
        /// Gets or sets whether the popup opens when the input receives focus.
        /// This shortcut applies only when <see cref="OpenOn"/> is <see cref="AutoCompleteOpenOn.Type"/>.
        /// Default is <c>false</c>.
        /// </summary>
        [Parameter]
        public bool OpenOnFocus { get; set; }

        /// <summary>
        /// Gets or sets the placeholder text for the input.
        /// </summary>
        [Parameter]
        public string Placeholder { get; set; }

        /// <summary>
        /// Gets or sets whether the clear button is shown when the input is non-empty. Default is <c>true</c>.
        /// </summary>
        [Parameter]
        public bool ClearButton { get; set; }

        /// <summary>
        /// Gets or sets whether a popup toggle button is displayed. Default is <c>false</c>.
        /// </summary>
        [Parameter]
        public bool ShowPopupButton { get; set; }

        /// <summary>
        /// Gets or sets whether the component is disabled. Default is <c>false</c>.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// Gets or sets whether the input is read-only. Default is <c>false</c>.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; }

        /// <summary>
        /// Gets or sets additional CSS classes applied to the root element.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; }

        /// <summary>
        /// Gets or sets the id attribute of the input element.
        /// </summary>
        [Parameter]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name attribute of the input element.
        /// </summary>
        [Parameter]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the maximum character length of the input.
        /// </summary>
        [Parameter]
        public int? MaxLength { get; set; }

        /// <summary>
        /// Gets or sets the accessible name when a visible label is not present.
        /// </summary>
        [Parameter]
        public string AriaLabel { get; set; }

        /// <summary>
        /// Gets or sets the id of the element that labels this combobox.
        /// </summary>
        [Parameter]
        public string AriaLabelledBy { get; set; }

        /// <summary>
        /// Gets or sets the tab index of the input.
        /// </summary>
        [Parameter]
        public int? TabIndex { get; set; }

        /// <summary>
        /// Gets or sets the template used to render each suggestion.
        /// </summary>
        [Parameter]
        public RenderFragment<AutoCompleteItemContext<TItem>> ItemTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template displayed when there are no matching suggestions and the component is not loading.
        /// </summary>
        [Parameter]
        public RenderFragment NoResultsTemplate { get; set; }

        /// <summary>
        /// Gets or sets content rendered above the suggestion list inside the popup.
        /// </summary>
        [Parameter]
        public RenderFragment HeaderTemplate { get; set; }

        /// <summary>
        /// Gets or sets content rendered below the suggestion list inside the popup.
        /// </summary>
        [Parameter]
        public RenderFragment FooterTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template displayed while an asynchronous search is in progress.
        /// </summary>
        [Parameter]
        public RenderFragment LoadingTemplate { get; set; }

        /// <summary>
        /// Gets or sets content rendered before the input. This Phase 2 member is not part of MVP.
        /// </summary>
        [Parameter]
        public RenderFragment PrefixTemplate { get; set; }

        /// <summary>
        /// Gets or sets content rendered after the input. This Phase 2 member is not part of MVP.
        /// </summary>
        [Parameter]
        public RenderFragment SuffixTemplate { get; set; }

        /// <summary>
        /// Gets or sets whether suggestion rendering is virtualized. This Phase 2 member is not part of MVP.
        /// </summary>
        [Parameter]
        public bool EnableVirtualization { get; set; }

        /// <summary>
        /// Gets or sets the row height in pixels used by Phase 2 virtualization.
        /// </summary>
        [Parameter]
        public double ItemHeight { get; set; }

        /// <summary>
        /// Gets or sets the popup height used by Phase 2 virtualization and grouping.
        /// </summary>
        [Parameter]
        public string PopupHeight { get; set; }

        /// <summary>
        /// Gets or sets a function that returns the group key for a suggestion. This Phase 2 member is not part of MVP.
        /// </summary>
        [Parameter]
        public Func<TItem, string> GroupBy { get; set; }

        /// <summary>
        /// Occurs immediately before a closed-to-open popup transition. Set
        /// <see cref="AutoCompleteOpenEventArgs.Cancel"/> to prevent opening.
        /// </summary>
        [Parameter]
        public EventCallback<AutoCompleteOpenEventArgs> OnOpen { get; set; }

        /// <summary>
        /// Occurs once after an open-to-closed popup transition; it does not occur when the popup was already closed.
        /// </summary>
        [Parameter]
        public EventCallback<AutoCompleteCloseEventArgs> OnClose { get; set; }

        /// <summary>
        /// Occurs after debounce and minimum-length checks, immediately before the local or asynchronous search source runs.
        /// </summary>
        [Parameter]
        public EventCallback<AutoCompleteSearchEventArgs> OnSearch { get; set; }

        /// <summary>
        /// Occurs when the user selects a suggestion from the list.
        /// </summary>
        [Parameter]
        public EventCallback<AutoCompleteItemSelectedEventArgs<TItem>> OnItemSelected { get; set; }

        /// <summary>
        /// Occurs when the clear button is activated.
        /// </summary>
        [Parameter]
        public EventCallback OnClear { get; set; }

        /// <summary>
        /// Opens the suggestion popup if the component is interactive and not disabled or read-only.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task OpenAsync() => Task.CompletedTask;

        /// <summary>
        /// Closes the suggestion popup.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task CloseAsync() => Task.CompletedTask;

        /// <summary>
        /// Moves keyboard focus to the input element.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task FocusAsync() => Task.CompletedTask;

        /// <summary>
        /// Removes keyboard focus from the input element.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task BlurAsync() => Task.CompletedTask;

        /// <summary>
        /// Re-executes the current search using the existing input text.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task RefreshAsync() => Task.CompletedTask;

        /// <summary>
        /// Clears the selected value and input text and cancels any pending search.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task ClearAsync() => Task.CompletedTask;
    }

    /// <summary>
    /// Specifies the local filtering algorithm for <see cref="SfAutoComplete{TItem}"/>.
    /// </summary>
    public enum AutoCompleteFilterType
    {
        /// <summary>
        /// Match items whose display text starts with the query.
        /// </summary>
        StartsWith = 0,

        /// <summary>
        /// Match items whose display text contains the query.
        /// </summary>
        Contains = 1,

        /// <summary>
        /// Use the custom predicate supplied by <see cref="SfAutoComplete{TItem}.CustomFilter"/>.
        /// </summary>
        Custom = 2,

        /// <summary>
        /// Do not filter locally; return the data source as provided (honoring <see cref="SfAutoComplete{TItem}.MaxItems"/>).
        /// </summary>
        None = 3
    }

    /// <summary>
    /// Specifies when the autocomplete suggestion popup opens.
    /// </summary>
    public enum AutoCompleteOpenOn
    {
        /// <summary>
        /// Open when type-ahead results are available after input.
        /// </summary>
        Type = 0,

        /// <summary>
        /// Open on input focus when allowed by minimum length and data availability.
        /// </summary>
        Focus = 1,

        /// <summary>
        /// Open on click of the input or popup button.
        /// </summary>
        Click = 2,

        /// <summary>
        /// Open only via the public <see cref="SfAutoComplete{TItem}.OpenAsync"/> method.
        /// </summary>
        Manual = 3
    }

    /// <summary>
    /// Provides item data to suggestion item templates for <see cref="SfAutoComplete{TItem}"/>.
    /// </summary>
    /// <typeparam name="TItem">The type of the underlying data item.</typeparam>
    public sealed class AutoCompleteItemContext<TItem>
    {
        /// <summary>
        /// Gets the underlying data item.
        /// </summary>
        public TItem Item { get; init; }

        /// <summary>
        /// Gets the display text for the item.
        /// </summary>
        public string Text { get; init; }

        /// <summary>
        /// Gets a value indicating whether the item is the active (highlighted) option.
        /// </summary>
        public bool IsActive { get; init; }

        /// <summary>
        /// Gets a value indicating whether the item equals the current selected value.
        /// </summary>
        public bool IsSelected { get; init; }

        /// <summary>
        /// Gets segments of the display text with match-highlighting metadata.
        /// </summary>
        public IReadOnlyList<AutoCompleteTextSegment> MatchSegments { get; init; }
    }

    /// <summary>
    /// Represents a portion of suggestion text used for match highlighting.
    /// </summary>
    public sealed class AutoCompleteTextSegment
    {
        /// <summary>
        /// Gets the text of this segment.
        /// </summary>
        public string Text { get; init; }

        /// <summary>
        /// Gets a value indicating whether this segment matches the current query.
        /// </summary>
        public bool IsMatch { get; init; }
    }

    /// <summary>
    /// Provides data for the <see cref="SfAutoComplete{TItem}.OnOpen"/> event.
    /// </summary>
    public class AutoCompleteOpenEventArgs
    {
        /// <summary>
        /// Gets or sets a value indicating whether opening the popup should be cancelled.
        /// </summary>
        public bool Cancel { get; set; }
    }

    /// <summary>
    /// Provides data for the <see cref="SfAutoComplete{TItem}.OnClose"/> event.
    /// </summary>
    public class AutoCompleteCloseEventArgs
    {
    }

    /// <summary>
    /// Provides data for the <see cref="SfAutoComplete{TItem}.OnSearch"/> event.
    /// </summary>
    public class AutoCompleteSearchEventArgs
    {
        /// <summary>
        /// Gets the query string that triggered the search.
        /// </summary>
        public string Query { get; init; }
    }

    /// <summary>
    /// Provides data for the <see cref="SfAutoComplete{TItem}.OnItemSelected"/> event.
    /// </summary>
    /// <typeparam name="TItem">The type of the selected item.</typeparam>
    public class AutoCompleteItemSelectedEventArgs<TItem>
    {
        /// <summary>
        /// Gets the selected item.
        /// </summary>
        public TItem Item { get; init; }

        /// <summary>
        /// Gets the display text of the selected item.
        /// </summary>
        public string Text { get; init; }
    }
}