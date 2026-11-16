# API-xml.md

# SfAppBar — XML Documentation (CS1591-Complete)

**Namespace:** Syncfusion.Blazor.Toolkit  
**Usage:** Copy-paste into component source files.  
**Requirement:** 100% public API coverage; 0 CS1591 warnings.

---

# Table of Contents

1. [SfAppBar](#1-sfappbar)
2. [SfAppBarItem](#2-sfappbaritem)
3. [SfAppBarSpacer](#3-sfappbarspacer)
4. [SfAppBarOverflow](#4-sfappbaroverflow)
5. [Enums](#5-enums)
6. [Event Args](#6-event-args)
7. [AppBarContext](#7-appbarcontext)

---

# 1. SfAppBar

```csharp
/// <summary>
/// Renders an application bar (header or footer) for branding, titles,
/// content, and command actions.
/// Supports static, fixed, and sticky positioning with
/// accessibility-aligned toolbar semantics.
/// </summary>
/// <remarks>
/// <para>
/// Use <see cref="SfAppBar"/> as the primary application chrome for
/// Blazor applications built with the MIT-licensed Syncfusion Blazor Toolkit.
/// Command surfaces should use <see cref="SfButton"/> or
/// <see cref="SfButtonGroup"/>.
/// </para>
/// <para>
/// The root element is rendered as a <c>header</c> when
/// <see cref="Position"/> is <see cref="AppBarPosition.Top"/> and as a
/// <c>footer</c> when <see cref="Position"/> is
/// <see cref="AppBarPosition.Bottom"/>.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// &lt;SfAppBar Title="Dashboard"
///           Mode="AppBarMode.Sticky"&gt;
///     &lt;SfAppBarItem&gt;
///         &lt;SfButton Content="Save"
///                   OnClick="SaveAsync" /&gt;
///     &lt;/SfAppBarItem&gt;
/// &lt;/SfAppBar&gt;
/// </code>
/// </example>
public partial class SfAppBar
{
    /// <summary>
    /// Gets or sets the vertical placement of the app bar.
    /// </summary>
    /// <value>
    /// An <see cref="AppBarPosition"/> value.
    /// The default is <see cref="AppBarPosition.Top"/>.
    /// </value>
    [Parameter]
    public AppBarPosition Position { get; set; } = AppBarPosition.Top;

    /// <summary>
    /// Gets or sets how the app bar participates in page scrolling and layout.
    /// </summary>
    /// <value>
    /// An <see cref="AppBarMode"/> value.
    /// The default is <see cref="AppBarMode.Static"/>.
    /// </value>
    [Parameter]
    public AppBarMode Mode { get; set; } = AppBarMode.Static;

    /// <summary>
    /// Gets or sets the density of app bar padding and control sizing.
    /// </summary>
    /// <value>
    /// An <see cref="AppBarDensity"/> value.
    /// The default is <see cref="AppBarDensity.Comfortable"/>.
    /// </value>
    [Parameter]
    public AppBarDensity Density { get; set; } = AppBarDensity.Comfortable;

    /// <summary>
    /// Gets or sets a value indicating whether action items that do not fit
    /// are moved into an overflow surface.
    /// </summary>
    /// <value>
    /// <c>true</c> to enable measurement-based overflow;
    /// otherwise, <c>false</c>.
    /// The default is <c>false</c>.
    /// </value>
    /// <remarks>
    /// Overflow measurement requires an interactive render mode.
    /// Under static SSR, all items remain visible.
    /// </remarks>
    [Parameter]
    public bool EnableOverflow { get; set; }

    /// <summary>
    /// Gets or sets the simple text title displayed in the title region.
    /// </summary>
    /// <value>
    /// A string title, or <c>null</c> to omit the title.
    /// </value>
    [Parameter]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the accessible name for the actions toolbar.
    /// </summary>
    /// <value>
    /// Value used for the toolbar's <c>aria-label</c>.
    /// </value>
    [Parameter]
    public string? AriaLabel { get; set; }

    /// <summary>
    /// Gets or sets the elevation level applied to the app bar surface.
    /// </summary>
    /// <value>
    /// An elevation value typically in the range 0–24.
    /// The default is 2.
    /// </value>
    [Parameter]
    public int Elevation { get; set; } = 2;

    /// <summary>
    /// Gets or sets a value indicating whether a border is displayed on the
    /// edge opposite the app bar placement.
    /// </summary>
    /// <value>
    /// <c>true</c> to display a border; otherwise <c>false</c>.
    /// </value>
    [Parameter]
    public bool ShowBorder { get; set; }

    /// <summary>
    /// Gets or sets the HTML id attribute for the root element.
    /// </summary>
    [Parameter]
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets additional CSS class names applied to the root element.
    /// </summary>
    [Parameter]
    public string? Class { get; set; }

    /// <summary>
    /// Gets or sets inline CSS styles applied to the root element.
    /// </summary>
    [Parameter]
    public string? Style { get; set; }

    /// <summary>
    /// Gets or sets the child content of the app bar, including items,
    /// spacers, and custom content.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the template rendered in the leading region.
    /// </summary>
    [Parameter]
    public RenderFragment? LeadingTemplate { get; set; }

    /// <summary>
    /// Gets or sets the template rendered in the branding region.
    /// </summary>
    [Parameter]
    public RenderFragment? BrandingTemplate { get; set; }

    /// <summary>
    /// Gets or sets the template that replaces the default title region.
    /// </summary>
    [Parameter]
    public RenderFragment? TitleTemplate { get; set; }

    /// <summary>
    /// Gets or sets the template rendered in the content region.
    /// </summary>
    [Parameter]
    public RenderFragment? ContentTemplate { get; set; }

    /// <summary>
    /// Gets or sets the template that replaces the default actions region.
    /// </summary>
    [Parameter]
    public RenderFragment? ActionsTemplate { get; set; }

    /// <summary>
    /// Gets or sets the template rendered inside the overflow surface.
    /// </summary>
    [Parameter]
    public RenderFragment? OverflowTemplate { get; set; }

    /// <summary>
    /// Occurs when the overflow surface opens.
    /// </summary>
    [Parameter]
    public EventCallback OnOverflowOpened { get; set; }

    /// <summary>
    /// Occurs when the overflow surface closes.
    /// </summary>
    [Parameter]
    public EventCallback OnOverflowClosed { get; set; }

    /// <summary>
    /// Occurs when an app bar item is activated.
    /// </summary>
    [Parameter]
    public EventCallback<AppBarItemClickEventArgs> OnItemClick { get; set; }

    /// <summary>
    /// Moves keyboard focus to the first enabled action control in the toolbar.
    /// </summary>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// </returns>
    public Task FocusAsync() => Task.CompletedTask;

    /// <summary>
    /// Forces a layout refresh of the app bar, including overflow
    /// recalculation when enabled.
    /// </summary>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// </returns>
    public Task RefreshAsync() => Task.CompletedTask;

    /// <summary>
    /// Measures action items and updates overflow membership when overflow
    /// is enabled.
    /// </summary>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// </returns>
    public Task MeasureAsync() => Task.CompletedTask;
}
```

---

# 2. SfAppBarItem

```csharp
/// <summary>
/// Represents a single content or action unit within an
/// <see cref="SfAppBar"/>.
/// </summary>
public partial class SfAppBarItem
{
    /// <summary>
    /// Gets or sets a stable identifier for the item.
    /// </summary>
    [Parameter]
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the overflow priority.
    /// Lower values remain visible longer when space is constrained.
    /// </summary>
    [Parameter]
    public int Priority { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the item is visible.
    /// </summary>
    [Parameter]
    public bool Visible { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the item is disabled.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets additional CSS classes applied to the item container.
    /// </summary>
    [Parameter]
    public string? CssClass { get; set; }

    /// <summary>
    /// Gets or sets the content of the item, typically an
    /// <see cref="SfButton"/>.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets optional text metadata associated with the item.
    /// </summary>
    [Parameter]
    public string? Text { get; set; }

    /// <summary>
    /// Gets or sets optional icon CSS metadata associated with the item.
    /// </summary>
    [Parameter]
    public string? IconCss { get; set; }
}
```

---

# 3. SfAppBarSpacer

```csharp
/// <summary>
/// Inserts a flexible or fixed-width spacer within an
/// <see cref="SfAppBar"/>.
/// </summary>
public partial class SfAppBarSpacer
{
    /// <summary>
    /// Gets or sets a fixed-width CSS value.
    /// When <c>null</c>, the spacer grows to fill available space.
    /// </summary>
    [Parameter]
    public string? Width { get; set; }
}
```

---

# 4. SfAppBarOverflow

```csharp
/// <summary>
/// Hosts action items that do not fit within the visible action region
/// of an <see cref="SfAppBar"/>.
/// </summary>
public partial class SfAppBarOverflow
{
    /// <summary>
    /// Gets or sets the overflow content.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
```

---

# 5. Enums

```csharp
/// <summary>
/// Specifies the vertical placement of an <see cref="SfAppBar"/>.
/// </summary>
public enum AppBarPosition
{
    /// <summary>
    /// Places the app bar at the top of the layout (header/banner).
    /// </summary>
    Top = 0,

    /// <summary>
    /// Places the app bar at the bottom of the layout (footer/contentinfo).
    /// </summary>
    Bottom = 1
}
```

```csharp
/// <summary>
/// Specifies how an <see cref="SfAppBar"/> participates in scrolling
/// and viewport positioning.
/// </summary>
public enum AppBarMode
{
    /// <summary>
    /// The app bar remains in normal document flow.
    /// </summary>
    Static = 0,

    /// <summary>
    /// The app bar is fixed to the viewport edge.
    /// </summary>
    Fixed = 1,

    /// <summary>
    /// The app bar uses sticky positioning within its scrolling ancestor.
    /// </summary>
    Sticky = 2
}
```

```csharp
/// <summary>
/// Specifies the density of an <see cref="SfAppBar"/>.
/// </summary>
public enum AppBarDensity
{
    /// <summary>
    /// Standard padding and control sizing.
    /// </summary>
    Comfortable = 0,

    /// <summary>
    /// Reduced padding for compact layouts.
    /// </summary>
    Compact = 1
}
```

```csharp
/// <summary>
/// Specifies alignment options for app bar regions.
/// </summary>
public enum AppBarAlignment
{
    /// <summary>
    /// Align content to the start edge.
    /// </summary>
    Start = 0,

    /// <summary>
    /// Center content.
    /// </summary>
    Center = 1,

    /// <summary>
    /// Align content to the end edge.
    /// </summary>
    End = 2,

    /// <summary>
    /// Distribute content with space between items.
    /// </summary>
    SpaceBetween = 3
}
```

---

# 6. Event Args

```csharp
/// <summary>
/// Provides data for the <see cref="SfAppBar.OnItemClick"/> event.
/// </summary>
public sealed class AppBarItemClickEventArgs
{
    /// <summary>
    /// Gets the identifier of the clicked item, if specified.
    /// </summary>
    public string? ItemId { get; init; }

    /// <summary>
    /// Gets the item instance associated with the event, when available.
    /// </summary>
    public SfAppBarItem? Item { get; init; }
}
```

---

# 7. AppBarContext

```csharp
/// <summary>
/// Cascading context provided by <see cref="SfAppBar"/>
/// to descendant items.
/// </summary>
public sealed class AppBarContext
{
    /// <summary>
    /// Gets the active density.
    /// </summary>
    public AppBarDensity Density { get; init; }

    /// <summary>
    /// Gets the active mode.
    /// </summary>
    public AppBarMode Mode { get; init; }

    /// <summary>
    /// Gets the active position.
    /// </summary>
    public AppBarPosition Position { get; init; }

    /// <summary>
    /// Registers an item for overflow participation.
    /// </summary>
    /// <param name="item">
    /// The item to register.
    /// </param>
    public void Register(SfAppBarItem item)
    {
    }

    /// <summary>
    /// Unregisters an item from overflow participation.
    /// </summary>
    /// <param name="item">
    /// The item to unregister.
    /// </param>
    public void Unregister(SfAppBarItem item)
    {
    }
}
```

---

## CS1591 Compliance Gate

### Requirements

- Every public type MUST have an XML `<summary>`.
- Every public property MUST have an XML `<summary>`.
- Every public method MUST have:
  - `<summary>`
  - `<param>` (where applicable)
  - `<returns>` (where applicable)
- All public enums and enum members MUST have XML documentation.
- All public event argument types MUST be documented.
- All public cascading context types MUST be documented.

### Validation Criteria

- 0 CS1591 Examples should be preserved for high-usage components such as `SfAppBar`.

---