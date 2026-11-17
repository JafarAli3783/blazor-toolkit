**API-xml.md**

# SfMenu – XML Documentation

## Syncfusion Blazor Toolkit

**Version:** 1.0  
**Status:** Proposed. Pending implementation.  
**Authority:** This file provides XML documentation only for members defined in `API.md`. It must not introduce new public members. The goal is zero CS1591 semi-warnings.

**Namespace:** `Syncfusion.Blazor.Toolkit`

---

## 1. SfMenu / SfMenu<TItem>

```xml
/// <summary>
/// Represents a hierarchical menu component that supports horizontal (menubar) and vertical orientations.
/// Implements the WAI-ARIA Menu and Menubar patterns.
/// </summary>
/// <typeparam name="TItem">The type of the data item when using data binding.</typeparam>
public partial class SfMenu<TItem> : /* base type to be confirmed */
{
}
```

### Parameters

```xml
/// <summary>
/// Gets or sets the orientation of the menu.
/// </summary>
/// <value>
/// One of the <see cref="MenuOrientation"/> values.
/// The default is <see cref="MenuOrientation.Horizontal"/>.
/// </value>
[Parameter]
public MenuOrientation Orientation { get; set; }

/// <summary>
/// Gets or sets the action that opens submenus.
/// </summary>
/// <value>
/// One of the <see cref="MenuOpenOn"/> values.
/// The default is <see cref="MenuOpenOn.Click"/>.
/// </value>
[Parameter]
public MenuOpenOn OpenOn { get; set; }

/// <summary>
/// Gets or sets the data source used to generate menu items.
/// </summary>
/// <value>An enumerable collection of items, or <c>null</c> when using declarative items only.</value>
[Parameter]
public IEnumerable<TItem>? DataSource { get; set; }

/// <summary>
/// Gets or sets the name of the property that contains the display text of an item.
/// </summary>
/// <value>The field name. The default is <c>"Text"</c>.</value>
[Parameter]
public string TextField { get; set; }

/// <summary>
/// Gets or sets the name of the property that contains the icon CSS class of an item.
/// </summary>
/// <value>The field name. The default is <c>"IconCss"</c>.</value>
[Parameter]
public string IconField { get; set; }

/// <summary>
/// Gets or sets the name of the property that indicates whether an item is disabled.
/// </summary>
/// <value>The field name. The default is <c>"Disabled"</c>.</value>
[Parameter]
public string DisabledField { get; set; }

/// <summary>
/// Gets or sets the name of the property that contains the child items collection (hierarchical data).
/// </summary>
/// <value>The field name. The default is <c>"Items"</c>.</value>
[Parameter]
public string ChildrenField { get; set; }

/// <summary>
/// Gets or sets the name of the identity property used for flat data binding.
/// </summary>
/// <value>The field name. The default is <c>"Id"</c>.</value>
[Parameter]
public string IdField { get; set; }

/// <summary>
/// Gets or sets the name of the parent identity property used for flat data binding.
/// </summary>
/// <value>The field name. The default is <c>"ParentId"</c>.</value>
[Parameter]
public string ParentIdField { get; set; }

/// <summary>
/// Gets or sets a typed selector that returns the display text for an item.
/// When both <see cref="TextSelector"/> and <see cref="TextField"/> are set, the selector takes precedence.
/// </summary>
[Parameter]
public Func<TItem, string>? TextSelector { get; set; }

/// <summary>
/// Gets or sets a typed selector that returns the icon CSS class for an item.
/// When both <see cref="IconSelector"/> and <see cref="IconField"/> are set, the selector takes precedence.
/// </summary>
[Parameter]
public Func<TItem, string>? IconSelector { get; set; }

/// <summary>
/// Gets or sets a typed selector that returns whether an item is disabled.
/// When both <see cref="DisabledSelector"/> and <see cref="DisabledField"/> are set, the selector takes precedence.
/// </summary>
[Parameter]
public Func<TItem, bool>? DisabledSelector { get; set; }

/// <summary>
/// Gets or sets a typed selector that returns the child items of an item.
/// When both <see cref="ChildrenSelector"/> and <see cref="ChildrenField"/> are set, the selector takes precedence.
/// </summary>
[Parameter]
public Func<TItem, IEnumerable<TItem>>? ChildrenSelector { get; set; }

/// <summary>
/// Gets or sets the template used to render each menu item.
/// </summary>
[Parameter]
public RenderFragment<MenuItemContext<TItem>>? ItemTemplate { get; set; }

/// <summary>
/// Gets or sets the child content containing declarative <see cref="SfMenuItem"/> components.
/// </summary>
[Parameter]
public RenderFragment? ChildContent { get; set; }

/// <summary>
/// Gets or sets a value indicating whether the entire menu is disabled.
/// </summary>
/// <value><c>true</c> if the menu is disabled; otherwise, <c>false</c>. The default is <c>false</c>.</value>
[Parameter]
public bool Disabled { get; set; }

/// <summary>
/// Gets or sets additional CSS class names to apply to the root element.
/// </summary>
[Parameter]
public string? Class { get; set; }

/// <summary>
/// Gets or sets a collection of additional attributes that will be applied to the root element.
/// </summary>
[Parameter(CaptureUnmatchedValues = true)]
public Dictionary<string, object>? AdditionalAttributes { get; set; }
```

### Events

```xml
/// <summary>
/// Occurs when a menu item is selected (activated).
/// </summary>
[Parameter]
public EventCallback<MenuItemEventArgs> OnItemSelected { get; set; }

/// <summary>
/// Occurs before a menu or submenu opens. The event can be cancelled.
/// </summary>
[Parameter]
public EventCallback<MenuCancelEventArgs> OnOpen { get; set; }

/// <summary>
/// Occurs after a menu or submenu has opened.
/// </summary>
[Parameter]
public EventCallback<MenuEventArgs> OnOpened { get; set; }

/// <summary>
/// Occurs before a menu or submenu closes. The event can be cancelled.
/// </summary>
[Parameter]
public EventCallback<MenuCancelEventArgs> OnClose { get; set; }

/// <summary>
/// Occurs after a menu or submenu has closed.
/// </summary>
[Parameter]
public EventCallback<MenuEventArgs> OnClosed { get; set; }
```

### Methods

```xml
/// <summary>
/// Opens the root menu asynchronously.
/// </summary>
/// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
public Task OpenAsync() { }

/// <summary>
/// Closes the menu and all open submenus asynchronously.
/// </summary>
/// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
public Task CloseAsync() { }

/// <summary>
/// Sets focus to the menu asynchronously.
/// </summary>
/// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
public Task FocusAsync() { }

/// <summary>
/// Refreshes the menu items from the current data source asynchronously.
/// </summary>
/// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
public Task RefreshAsync() { }
```

---

## 2. SfMenuItem

```xml
/// <summary>
/// Represents a declarative menu item that can be used as a child of <see cref="SfMenu"/>.
/// </summary>
public partial class SfMenuItem
{
}
```

### Parameters

```xml
/// <summary>
/// Gets or sets the display text of the menu item.
/// </summary>
[Parameter]
public string? Text { get; set; }

/// <summary>
/// Gets or sets the CSS class used to render the icon of the menu item.
/// </summary>
[Parameter]
public string? IconCss { get; set; }

/// <summary>
/// Gets or sets a value indicating whether the menu item is disabled.
/// </summary>
/// <value><c>true</c> if the item is disabled; otherwise, <c>false</c>. The default is <c>false</c>.</value>
[Parameter]
public bool Disabled { get; set; }

/// <summary>
/// Gets or sets a value indicating whether this instance represents a separator.
/// </summary>
/// <value><c>true</c> to render a separator; otherwise, <c>false</c>. The default is <c>false</c>.</value>
[Parameter]
public bool Separator { get; set; }

/// <summary>
/// Gets or sets the navigation URL associated with the menu item.
/// </summary>
[Parameter]
public string? Url { get; set; }

/// <summary>
/// Gets or sets the target window or frame for the navigation URL.
/// </summary>
[Parameter]
public string? Target { get; set; }

/// <summary>
/// Gets or sets the child content, which may contain nested <see cref="SfMenuItem"/> components.
/// </summary>
[Parameter]
public RenderFragment? ChildContent { get; set; }
```

---

## 3. Enums

```xml
/// <summary>
/// Specifies the orientation of an <see cref="SfMenu"/>.
/// </summary>
public enum MenuOrientation
{
    /// <summary>
    /// Items are arranged horizontally and the root element uses the menubar role.
    /// </summary>
    Horizontal = 0,

    /// <summary>
    /// Items are arranged vertically and the root element uses the menu role.
    /// </summary>
    Vertical = 1
}

/// <summary>
/// Specifies how submenus are opened.
/// </summary>
public enum MenuOpenOn
{
    /// <summary>
    /// Submenus open in response to a click or tap.
    /// </summary>
    Click = 0,

    /// <summary>
    /// Submenus open in response to pointer hover.
    /// </summary>
    Hover = 1
}
```

---

## 4. Supporting Types

```xml
/// <summary>
/// Provides contextual information to the item template of an <see cref="SfMenu{TItem}"/>.
/// </summary>
/// <typeparam name="TItem">The type of the data item.</typeparam>
public class MenuItemContext<TItem>
{
    /// <summary>
    /// Gets the data item associated with the current menu item.
    /// </summary>
    public TItem Item { get; init; }

    /// <summary>
    /// Gets a value indicating whether the item is disabled.
    /// </summary>
    public bool Disabled { get; init; }

    /// <summary>
    /// Gets a value indicating whether the item has a submenu.
    /// </summary>
    public bool HasSubMenu { get; init; }

    /// <summary>
    /// Gets a value indicating whether the item is a separator.
    /// </summary>
    public bool IsSeparator { get; init; }
}

/// <summary>
/// Provides data for the item selection event of a menu.
/// </summary>
public class MenuItemEventArgs : EventArgs
{
    /// <summary>
    /// Gets the data item associated with the selected menu item.
    /// </summary>
    public object? Item { get; init; }

    /// <summary>
    /// Gets the display text of the selected menu item.
    /// </summary>
    public string? Text { get; init; }
}

/// <summary>
/// Provides data for menu open and close events.
/// </summary>
public class MenuEventArgs : EventArgs
{
}

/// <summary>
/// Provides data for cancellable menu open and close events.
/// </summary>
public class MenuCancelEventArgs : MenuEventArgs
{
    /// <summary>
    /// Gets or sets a value indicating whether the event should be cancelled.
    /// </summary>
    public bool Cancel { get; set; }
}
```