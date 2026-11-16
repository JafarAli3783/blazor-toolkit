# XML Documentation – SfToolbar  
**Namespace:** `Syncfusion.Blazor.Toolkit`  
**Target:** Syncfusion Blazor Toolkit  
**Style:** Matches existing Toolkit component documentation patterns

Status: Approved (not implemented). This is the XML-documentation contract, not evidence of a shipped API or a completed CS1591 build. Phase 1/P0 and Phase 2/P1 availability follows `API.md`. `ToolbarGroup` has `ChildContent` only; no group-template member is public in this contract.

---

```csharp
namespace Syncfusion.Blazor.Toolkit
{
    /// <summary>
    /// A responsive, accessible command toolbar for Blazor applications.
    /// Supports adaptive overflow, grouping, templates, keyboard navigation,
    /// and full WAI-ARIA compliance.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="SfToolbar"/> implements the WAI-ARIA toolbar design pattern
    /// with roving tabindex and supports the following overflow modes:
    /// Scrollable, Popup, MultiRow, and Extended.
    /// </para>
    /// <para>
    /// Renders static markup in Static SSR; event interaction and overflow measurement
    /// require Interactive Server, Interactive WebAssembly, or Interactive Auto.
    /// The API avoids reflection over consumer models.
    /// </para>
    /// </remarks>
    public partial class SfToolbar : SfBaseComponent
    {
        /// <summary>
        /// Gets or sets the orientation of the toolbar.
        /// </summary>
        /// <value>
        /// One of the <see cref="ToolbarOrientation"/> values.
        /// The default is <see cref="ToolbarOrientation.Horizontal"/>.
        /// </value>
        [Parameter]
        public ToolbarOrientation Orientation { get; set; } = ToolbarOrientation.Horizontal;

        /// <summary>
        /// Gets or sets how overflowing items are handled when content exceeds available space.
        /// </summary>
        /// <value>
        /// One of the <see cref="ToolbarOverflowMode"/> values.
        /// The default is <see cref="ToolbarOverflowMode.Popup"/>.
        /// </value>
        [Parameter]
        public ToolbarOverflowMode OverflowMode { get; set; } = ToolbarOverflowMode.Popup;

        /// <summary>
        /// Gets or sets the alignment of items within the toolbar.
        /// </summary>
        /// <value>
        /// One of the <see cref="ToolbarAlignment"/> values.
        /// The default is <see cref="ToolbarAlignment.Start"/>.
        /// </value>
        [Parameter]
        public ToolbarAlignment Align { get; set; } = ToolbarAlignment.Start;

        /// <summary>
        /// Gets or sets additional CSS classes to apply to the root element of the toolbar.
        /// </summary>
        /// <value>A space-separated list of CSS class names.</value>
        [Parameter]
        public string CssClass { get; set; }

        /// <summary>
        /// Gets or sets additional HTML attributes to apply to the root element of the toolbar.
        /// </summary>
        /// <value>A dictionary of attribute names and values.</value>
        [Parameter]
        public Dictionary<string, object> HtmlAttributes { get; set; }

        /// <summary>
        /// Gets or sets the accessible name of the toolbar.
        /// Rendered as the <c>aria-label</c> attribute.
        /// </summary>
        /// <value>A string that describes the purpose of the toolbar.</value>
        [Parameter]
        public string AriaLabel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether right-to-left (RTL) direction is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> to force RTL; <c>false</c> to force LTR;
        /// <c>null</c> to inherit from a parent cascade or the application.
        /// The default is <c>null</c>.
        /// </value>
        [Parameter]
        public bool? EnableRtl { get; set; }

        /// <summary>
        /// Gets or sets the content of the toolbar when using declarative item definition.
        /// </summary>
        /// <value>A <see cref="RenderFragment"/> that typically contains
        /// <see cref="ToolbarItem"/>, <see cref="ToolbarGroup"/>, 
        /// <see cref="ToolbarSeparator"/>, or <see cref="ToolbarSpacer"/> components.</value>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Gets or sets a collection of items used for Phase 2 data-binding scenarios.
        /// </summary>
        /// <value>
        /// An <see cref="IEnumerable{T}"/> of <see cref="ToolbarItemModel"/>.
        /// When set, the toolbar renders items from this collection instead of (or in addition to)
        /// declarative <see cref="ChildContent"/>.
        /// </value>
        [Parameter]
        public IEnumerable<ToolbarItemModel> Items { get; set; }

        /// <summary>
        /// Gets or sets the Phase 2 template used to render each item when the <see cref="Items"/>
        /// collection is supplied.
        /// </summary>
        /// <value>
        /// A <see cref="RenderFragment{TValue}"/> where the type parameter is
        /// <see cref="ToolbarTemplateContext"/>.
        /// </value>
        [Parameter]
        public RenderFragment<ToolbarTemplateContext> ItemTemplate { get; set; }

        /// <summary>
        /// Gets or sets advanced configuration options for overflow behavior.
        /// </summary>
        /// <value>
        /// An instance of <see cref="ToolbarOverflowSettings"/>.
        /// The default is a new instance with default values.
        /// </value>
        [Parameter]
        public ToolbarOverflowSettings OverflowSettings { get; set; } = new();

        /// <summary>
        /// Event callback raised when any toolbar item is clicked.
        /// </summary>
        /// <value>
        /// An <see cref="EventCallback{TValue}"/> where the type parameter is
        /// <see cref="ToolbarItemClickEventArgs"/>.
        /// </value>
        [Parameter]
        public EventCallback<ToolbarItemClickEventArgs> OnItemClick { get; set; }

        /// <summary>
        /// Event callback raised when the Phase 2 overflow menu opens.
        /// </summary>
        [Parameter]
        public EventCallback OnOverflowOpen { get; set; }

        /// <summary>
        /// Event callback raised when the Phase 2 overflow menu closes.
        /// </summary>
        [Parameter]
        public EventCallback OnOverflowClose { get; set; }

        /// <summary>
        /// Forces a recalculation of which items should appear in the main toolbar
        /// versus the overflow menu.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/> that represents the asynchronous operation.</returns>
        /// <remarks>
        /// Call this method after dynamic changes that may not automatically
        /// trigger an overflow refresh (for example, after external CSS changes
        /// that affect item sizes).
        /// </remarks>
        public ValueTask RefreshOverflowAsync() => default;

        /// <summary>
        /// Moves keyboard focus into the toolbar, placing focus on the first enabled item.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/> that represents the asynchronous operation.</returns>
        public ValueTask FocusAsync() => default;

        /// <summary>
        /// Returns the collection of items currently visible in the main toolbar area.
        /// </summary>
        /// <returns>A read-only list of items that are not overflowed.</returns>
        public IReadOnlyList<ComponentBase> GetVisibleItems() => Array.Empty<ComponentBase>();

        /// <summary>
        /// Returns the collection of items currently placed in the overflow menu.
        /// </summary>
        /// <returns>A read-only list of overflowed items.</returns>
        public IReadOnlyList<ComponentBase> GetOverflowItems() => Array.Empty<ComponentBase>();
    }

    /// <summary>
    /// Represents a single command or control inside an <see cref="SfToolbar"/>.
    /// </summary>
    /// <remarks>
    /// Supports button, toggle, split, dropdown, and menu item types.
    /// Participates in overflow calculation and keyboard navigation.
    /// </remarks>
    public partial class ToolbarItem : ComponentBase, IToolbarItem
    {
        /// <summary>
        /// Gets or sets the unique identifier of the item.
        /// </summary>
        /// <value>
        /// A string that uniquely identifies the item within the toolbar.
        /// If not set, an identifier is generated automatically.
        /// </value>
        [Parameter]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the text displayed on the item and used as its accessible name,
        /// including when <see cref="DisplayMode"/> is icon-only.
        /// </summary>
        /// <value>The caption and accessible name of the item.</value>
        [Parameter]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the CSS class used to render the item icon.
        /// </summary>
        /// <value>A CSS class name that defines the icon.</value>
        [Parameter]
        public string IconCss { get; set; }

        /// <summary>
        /// Gets or sets the position of the icon relative to the text.
        /// </summary>
        /// <value>
        /// One of the icon position values. The default is left of the text.
        /// </value>
        [Parameter]
        public IconPosition IconPosition { get; set; } = IconPosition.Left;

        /// <summary>
        /// Gets or sets the type of the toolbar item, which determines its visual appearance
        /// and interaction behavior. Button and Toggle are Phase 1; Split, DropDown, and Menu are Phase 2.
        /// </summary>
        /// <value>
        /// One of the <see cref="ToolbarItemType"/> values.
        /// The default is <see cref="ToolbarItemType.Button"/>.
        /// </value>
        [Parameter]
        public ToolbarItemType Type { get; set; } = ToolbarItemType.Button;

        /// <summary>
        /// Gets or sets a value indicating whether the item is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if the item can be interacted with; otherwise, <c>false</c>.
        /// The default is <c>true</c>.
        /// </value>
        [Parameter]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the item is visible.
        /// </summary>
        /// <value>
        /// <c>true</c> if the item is rendered; otherwise, <c>false</c>.
        /// The default is <c>true</c>.
        /// </value>
        [Parameter]
        public bool Visible { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether a toggle-style item is in the selected state.
        /// Supports two-way binding with <c>@bind-Selected</c>.
        /// </summary>
        /// <value>
        /// <c>true</c> if the item is selected; otherwise, <c>false</c>.
        /// The default is <c>false</c>.
        /// </value>
        [Parameter]
        public bool Selected { get; set; }

        /// <summary>
        /// Gets or sets the overflow priority of this item.
        /// </summary>
        /// <value>
        /// One of the <see cref="ToolbarOverflowOption"/> values.
        /// The default is <see cref="ToolbarOverflowOption.None"/>.
        /// </value>
        /// <remarks>
        /// <list type="bullet">
        /// <item><see cref="ToolbarOverflowOption.Show"/> – Prefer keeping the item in the main bar.</item>
        /// <item><see cref="ToolbarOverflowOption.Hide"/> – Prefer moving the item to the overflow menu.</item>
        /// <item><see cref="ToolbarOverflowOption.None"/> – Follow normal document order.</item>
        /// </list>
        /// </remarks>
        [Parameter]
        public ToolbarOverflowOption Overflow { get; set; } = ToolbarOverflowOption.None;

        /// <summary>
        /// Gets or sets the secondary priority used when sorting candidates for overflow.
        /// Lower values remain visible longer.
        /// </summary>
        /// <value>An integer priority. The default is 0.</value>
        [Parameter]
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets supplemental tooltip text displayed when the user hovers over the item.
        /// It does not replace the accessible name supplied by <see cref="Text"/>.
        /// </summary>
        /// <value>The tooltip content.</value>
        [Parameter]
        public string Tooltip { get; set; }

        /// <summary>
        /// Gets or sets the badge content displayed on the item.
        /// </summary>
        /// <value>A short string or number rendered as a badge.</value>
        [Parameter]
        public string Badge { get; set; }

        /// <summary>
        /// Gets or sets additional CSS classes applied to the item element.
        /// </summary>
        /// <value>A space-separated list of CSS class names.</value>
        [Parameter]
        public string CssClass { get; set; }

        /// <summary>
        /// Gets or sets the display mode that controls whether icon, text, or both are shown.
        /// </summary>
        /// <value>
        /// One of the <see cref="ToolbarItemDisplayMode"/> values.
        /// The default is <see cref="ToolbarItemDisplayMode.IconAndText"/>.
        /// </value>
        [Parameter]
        public ToolbarItemDisplayMode DisplayMode { get; set; } = ToolbarItemDisplayMode.IconAndText;

        /// <summary>
        /// Gets or sets the Phase 2 name of the radio group this item belongs to.
        /// Items that share the same group name behave as a mutually exclusive set.
        /// </summary>
        /// <value>A group identifier string.</value>
        [Parameter]
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets custom content for the item.
        /// </summary>
        /// <value>A <see cref="RenderFragment"/> rendered inside the item.</value>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Gets or sets an advanced template for the item.
        /// </summary>
        /// <value>
        /// A <see cref="RenderFragment{TValue}"/> where the type parameter is
        /// <see cref="ToolbarTemplateContext"/>.
        /// </value>
        [Parameter]
        public RenderFragment<ToolbarTemplateContext> Template { get; set; }

        /// <summary>
        /// Gets or sets Phase 2 nested items used by Split, DropDown, or Menu item types.
        /// </summary>
        /// <value>A <see cref="RenderFragment"/> that defines child commands.</value>
        [Parameter]
        public RenderFragment Items { get; set; }

        /// <summary>
        /// Event callback raised when the item is clicked.
        /// </summary>
        /// <value>An <see cref="EventCallback{TValue}"/> of <see cref="MouseEventArgs"/>.</value>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }
    }

    /// <summary>
    /// Represents a logical and visual group of toolbar items.
    /// Renders with <c>role="group"</c> for accessibility.
    /// </summary>
    public partial class ToolbarGroup : ComponentBase
    {
        /// <summary>
        /// Gets or sets the accessible name of the group (rendered as <c>aria-label</c>).
        /// </summary>
        [Parameter]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the content of the group.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Gets or sets additional CSS classes applied to the group element.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; }
    }

    /// <summary>
    /// Represents a visual separator between toolbar items.
    /// Renders with <c>role="separator"</c>.
    /// </summary>
    public partial class ToolbarSeparator : ComponentBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether the separator is visible.
        /// </summary>
        /// <value>The default is <c>true</c>.</value>
        [Parameter]
        public bool Visible { get; set; } = true;

        /// <summary>
        /// Gets or sets additional CSS classes applied to the separator.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; }
    }

    /// <summary>
    /// Represents a flexible space that expands to push adjacent items apart.
    /// </summary>
    public partial class ToolbarSpacer : ComponentBase
    {
        /// <summary>
        /// Gets or sets additional CSS classes applied to the spacer.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; }
    }

    /// <summary>
    /// Represents an item that renders arbitrary custom content inside the toolbar
    /// and still participates in overflow calculation.
    /// </summary>
    public partial class ToolbarTemplateItem : ComponentBase, IToolbarItem
    {
        /// <summary>
        /// Gets or sets the custom content of the item.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Gets or sets the overflow priority of this item.
        /// </summary>
        [Parameter]
        public ToolbarOverflowOption Overflow { get; set; } = ToolbarOverflowOption.None;

        /// <summary>
        /// Gets or sets the secondary priority used during overflow sorting.
        /// </summary>
        [Parameter]
        public int Priority { get; set; }
    }

    /// <summary>
    /// Provides configuration options that control overflow button appearance and behavior.
    /// </summary>
    public class ToolbarOverflowSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether the overflow (“More”) button is shown
        /// when one or more items overflow.
        /// </summary>
        /// <value>The default is <c>true</c>.</value>
        public bool ShowOverflowButton { get; set; } = true;

        /// <summary>
        /// Gets or sets the CSS class used for the overflow button icon.
        /// </summary>
        public string OverflowButtonIconCss { get; set; }

        /// <summary>
        /// Gets or sets the tooltip text of the overflow button.
        /// </summary>
        /// <value>The default is <c>"More"</c>.</value>
        public string OverflowButtonTooltip { get; set; } = "More";

        /// <summary>
        /// Gets or sets additional CSS classes applied to the overflow popup.
        /// </summary>
        public string PopupCssClass { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the overflow popup closes
        /// automatically after an item is selected.
        /// </summary>
        /// <value>The default is <c>true</c>.</value>
        public bool CloseOnSelect { get; set; } = true;
    }

    /// <summary>
    /// Represents the data model used when binding items through the
    /// <see cref="SfToolbar.Items"/> parameter.
    /// </summary>
    public class ToolbarItemModel
    {
        /// <summary>Gets or sets the unique identifier of the item.</summary>
        public string Id { get; set; }

        /// <summary>Gets or sets the display text.</summary>
        public string Text { get; set; }

        /// <summary>Gets or sets the icon CSS class.</summary>
        public string IconCss { get; set; }

        /// <summary>Gets or sets the item type.</summary>
        public ToolbarItemType Type { get; set; } = ToolbarItemType.Button;

        /// <summary>Gets or sets a value indicating whether the item is enabled.</summary>
        public bool Enabled { get; set; } = true;

        /// <summary>Gets or sets a value indicating whether the item is visible.</summary>
        public bool Visible { get; set; } = true;

        /// <summary>Gets or sets the selected state for toggle items.</summary>
        public bool Selected { get; set; }

        /// <summary>Gets or sets the overflow option.</summary>
        public ToolbarOverflowOption Overflow { get; set; } = ToolbarOverflowOption.None;

        /// <summary>Gets or sets the overflow priority.</summary>
        public int Priority { get; set; }

        /// <summary>Gets or sets the tooltip text.</summary>
        public string Tooltip { get; set; }

        /// <summary>Gets or sets the badge content.</summary>
        public string Badge { get; set; }

        /// <summary>Gets or sets the radio group name.</summary>
        public string GroupName { get; set; }

        /// <summary>Gets or sets the display mode.</summary>
        public ToolbarItemDisplayMode DisplayMode { get; set; } = ToolbarItemDisplayMode.IconAndText;
    }

    /// <summary>
    /// Provides contextual information to item templates.
    /// </summary>
    public class ToolbarTemplateContext
    {
        /// <summary>
        /// Gets the data item being rendered.
        /// </summary>
        public ToolbarItemModel Item { get; init; }

        /// <summary>
        /// Gets a value indicating whether the item is currently rendered
        /// inside the overflow menu.
        /// </summary>
        public bool IsOverflow { get; init; }
    }

    /// <summary>
    /// Provides data for the <see cref="SfToolbar.OnItemClick"/> event.
    /// </summary>
    public class ToolbarItemClickEventArgs
    {
        /// <summary>
        /// Gets the identifier of the clicked item.
        /// </summary>
        public string ItemId { get; init; }

        /// <summary>
        /// Gets the data model of the clicked item (when data-bound).
        /// </summary>
        public ToolbarItemModel Item { get; init; }

        /// <summary>
        /// Gets the original browser mouse event arguments.
        /// </summary>
        public MouseEventArgs OriginalArgs { get; init; }

        /// <summary>
        /// Gets or sets a value that indicates whether the default action of the click is canceled.
        /// </summary>
        /// <value>
        /// <c>true</c> to stop the default action; otherwise, <c>false</c>. The default is <c>false</c>.
        /// </value>
        /// <remarks>
        /// A canceled Toggle item does not change <c>Selected</c>, and a canceled Split, DropDown
        /// or Menu item does not open. The item <c>OnClick</c> runs first, and
        /// <see cref="SfToolbar.OnItemClick"/> still runs after it when this value is <c>true</c>.
        /// </remarks>
        public bool Cancel { get; set; }
    }

    /// <summary>
    /// Specifies the orientation of the toolbar.
    /// </summary>
    public enum ToolbarOrientation
    {
        /// <summary>Items are arranged horizontally (default).</summary>
        Horizontal,

        /// <summary>Items are arranged vertically.</summary>
        Vertical
    }

    /// <summary>
    /// Specifies how items are aligned inside the toolbar.
    /// </summary>
    public enum ToolbarAlignment
    {
        /// <summary>Items are packed toward the start of the toolbar (default).</summary>
        Start,

        /// <summary>Items are centered.</summary>
        Center,

        /// <summary>Items are packed toward the end of the toolbar.</summary>
        End,

        /// <summary>Items are evenly distributed with equal space between them.</summary>
        Justify
    }

    /// <summary>
    /// Specifies the strategy used when toolbar items overflow the available space.
    /// </summary>
    public enum ToolbarOverflowMode
    {
        /// <summary>
        /// All items remain in a single line; overflow is handled by scrolling.
        /// </summary>
        Scrollable,

        /// <summary>
        /// Items that do not fit are moved into a popup menu (default).
        /// </summary>
        Popup,

        /// <summary>
        /// Overflowing items wrap onto additional rows. This is Phase 2.
        /// </summary>
        MultiRow,

        /// <summary>
        /// Extra rows are collapsed and can be expanded via a button. This is Phase 2.
        /// </summary>
        Extended
    }

    /// <summary>
    /// Specifies the overflow priority of an individual toolbar item.
    /// </summary>
    public enum ToolbarOverflowOption
    {
        /// <summary>
        /// The item should remain in the main toolbar whenever possible.
        /// </summary>
        Show,

        /// <summary>
        /// The item should be moved to the overflow menu whenever possible.
        /// </summary>
        Hide,

        /// <summary>
        /// No special priority; the item follows normal document order (default).
        /// </summary>
        None
    }

    /// <summary>
    /// Specifies the behavioral and visual type of a toolbar item.
    /// </summary>
    public enum ToolbarItemType
    {
        /// <summary>A standard push button.</summary>
        Button,

        /// <summary>A button that maintains a selected/unselected state.</summary>
        Toggle,

        /// <summary>A Phase 2 split button with a primary action and a secondary dropdown.</summary>
        Split,

        /// <summary>A Phase 2 button that opens a dropdown list of commands.</summary>
        DropDown,

        /// <summary>A Phase 2 button that opens a menu of commands.</summary>
        Menu,

        /// <summary>A visual separator.</summary>
        Separator,

        /// <summary>A flexible spacer.</summary>
        Spacer,

        /// <summary>An item that renders custom content via a template.</summary>
        Template
    }

    /// <summary>
    /// Specifies which parts of an item (icon, text, or both) are displayed.
    /// </summary>
    public enum ToolbarItemDisplayMode
    {
        /// <summary>Only the icon is shown.</summary>
        IconOnly,

        /// <summary>Only the text is shown.</summary>
        TextOnly,

        /// <summary>Both icon and text are shown (default).</summary>
        IconAndText
    }
}