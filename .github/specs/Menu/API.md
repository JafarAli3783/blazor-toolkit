**API.md**

# SfMenu – Public API

## Syncfusion Blazor Toolkit

**Version:** 1.0  
**Status:** Proposed. Pending API review. Not implemented.  
**Authority:** This file is the only public-member contract. `Spec.md` owns behavior and must not introduce parameters. `API-xml.md` documents only the members listed here.  
**Namespace:** `Syncfusion.Blazor.Toolkit`

---

## 1. Components

| Component              | Kind              | Description                                      |
|------------------------|-------------------|--------------------------------------------------|
| `SfMenu`               | Root              | Primary non-generic menu component               |
| `SfMenu<TItem>`        | Root (generic)    | Data-bound menu using typed items                |
| `SfMenuItem`           | Declarative child | Optional declarative menu item                   |

> Notes:
> - Both generic and non-generic root components are proposed.
> - Final primary surface will be confirmed during implementation review.
> - Declarative `SfMenuItem` is supported to align with Toolkit patterns (similar to `SfListItem`).

---

## 2. SfMenu / SfMenu<TItem> – Parameters

| Parameter            | Type                                      | Default          | Description |
|----------------------|-------------------------------------------|------------------|-------------|
| `Orientation`        | `MenuOrientation`                         | `Horizontal`     | Layout orientation of the root menu |
| `OpenOn`             | `MenuOpenOn`                              | `Click`          | How submenus are opened |
| `DataSource`         | `IEnumerable<TItem>`                      | `null`           | Collection of items when using data binding |
| `TextField`          | `string`                                  | `"Text"`         | Name of the property that contains item text |
| `IconField`          | `string`                                  | `"IconCss"`      | Name of the property that contains icon CSS class |
| `DisabledField`      | `string`                                  | `"Disabled"`     | Name of the property that indicates disabled state |
| `ChildrenField`      | `string`                                  | `"Items"`        | Name of the property that contains child items (hierarchical) |
| `IdField`            | `string`                                  | `"Id"`           | Name of the identity property (flat data) |
| `ParentIdField`      | `string`                                  | `"ParentId"`     | Name of the parent identity property (flat data) |
| `TextSelector`       | `Func<TItem, string>`                     | `null`           | Typed selector for text (takes precedence over `TextField`) |
| `IconSelector`       | `Func<TItem, string>`                     | `null`           | Typed selector for icon CSS class |
| `DisabledSelector`   | `Func<TItem, bool>`                       | `null`           | Typed selector for disabled state |
| `ChildrenSelector`   | `Func<TItem, IEnumerable<TItem>>`         | `null`           | Typed selector for child items |
| `ItemTemplate`       | `RenderFragment<MenuItemContext<TItem>>`  | `null`           | Template for rendering each item |
| `ChildContent`       | `RenderFragment`                          | `null`           | Declarative `SfMenuItem` children |
| `Disabled`           | `bool`                                    | `false`          | Disables the entire menu |
| `Class`              | `string`                                  | `null`           | Additional CSS classes |
| `AdditionalAttributes` | `Dictionary<string, object>`            | `null`           | Additional attributes splatted onto the root element |

---

## 3. SfMenuItem – Parameters (Declarative)

| Parameter       | Type               | Default | Description |
|-----------------|--------------------|---------|-------------|
| `Text`          | `string`           | `null`  | Display text of the item |
| `IconCss`       | `string`           | `null`  | CSS class for the icon |
| `Disabled`      | `bool`             | `false` | Whether the item is disabled |
| `Separator`     | `bool`             | `false` | Renders a visual and semantic separator |
| `Url`           | `string`           | `null`  | Optional navigation URL |
| `Target`        | `string`           | `null`  | Target for the URL (e.g. `_blank`) |
| `ChildContent`  | `RenderFragment`   | `null`  | Nested menu items or custom content |

---

## 4. Enums

```csharp
namespace Syncfusion.Blazor.Toolkit
{
    /// <summary>
    /// Specifies the orientation of the menu.
    /// </summary>
    public enum MenuOrientation
    {
        /// <summary>
        /// Items are arranged horizontally (menubar).
        /// </summary>
        Horizontal = 0,

        /// <summary>
        /// Items are arranged vertically.
        /// </summary>
        Vertical = 1
    }

    /// <summary>
    /// Specifies how menu items open their submenus.
    /// </summary>
    public enum MenuOpenOn
    {
        /// <summary>
        /// Submenus open on click or tap.
        /// </summary>
        Click = 0,

        /// <summary>
        /// Submenus open on pointer hover.
        /// </summary>
        Hover = 1
    }
}
```

---

## 5. Events

| Event             | Type                                      | Description |
|-------------------|-------------------------------------------|-------------|
| `OnItemSelected`  | `EventCallback<MenuItemEventArgs>`        | Raised when a menu item is activated |
| `OnOpen`          | `EventCallback<MenuCancelEventArgs>`      | Raised before a menu or submenu opens (cancellable) |
| `OnOpened`        | `EventCallback<MenuEventArgs>`            | Raised after a menu or submenu has opened |
| `OnClose`         | `EventCallback<MenuCancelEventArgs>`      | Raised before a menu or submenu closes (cancellable) |
| `OnClosed`        | `EventCallback<MenuEventArgs>`            | Raised after a menu or submenu has closed |

---

## 6. Methods

| Method              | Signature                     | Description |
|---------------------|-------------------------------|-------------|
| `OpenAsync`         | `Task OpenAsync()`            | Opens the root menu |
| `CloseAsync`        | `Task CloseAsync()`           | Closes the menu and all open submenus |
| `FocusAsync`        | `Task FocusAsync()`           | Moves focus into the menu |
| `RefreshAsync`      | `Task RefreshAsync()`         | Refreshes the menu from the current data source |

---

## 7. Supporting Types

```csharp
namespace Syncfusion.Blazor.Toolkit
{
    /// <summary>
    /// Provides context information for a menu item template.
    /// </summary>
    public class MenuItemContext<TItem>
    {
        public TItem Item { get; init; }
        public bool Disabled { get; init; }
        public bool HasSubMenu { get; init; }
        public bool IsSeparator { get; init; }
    }

    /// <summary>
    /// Provides data for menu item selection events.
    /// </summary>
    public class MenuItemEventArgs : EventArgs
    {
        public object? Item { get; init; }
        public string? Text { get; init; }
        // Additional properties may be added during implementation
    }

    /// <summary>
    /// Provides data for menu open/close events.
    /// </summary>
    public class MenuEventArgs : EventArgs
    {
        // Reserved for future expansion
    }

    /// <summary>
    /// Provides data for cancellable menu open/close events.
    /// </summary>
    public class MenuCancelEventArgs : MenuEventArgs
    {
        public bool Cancel { get; set; }
    }
}
```

---

## 8. CSS Class Contract

| Class                      | Purpose |
|----------------------------|---------|
| `sf-menu`                  | Root element |
| `sf-menu-horizontal`       | Horizontal orientation |
| `sf-menu-vertical`         | Vertical orientation |
| `sf-menu-item`             | Individual menu item |
| `sf-menu-item-disabled`    | Disabled menu item |
| `sf-menu-item-focused`     | Currently focused item |
| `sf-menu-separator`        | Separator item |
| `sf-menu-submenu`          | Submenu popup container |
| `sf-menu-open`             | Applied when a menu/submenu is open |

---

## 9. Stable Test Hooks (`data-testid`)

| data-testid              | Element |
|--------------------------|---------|
| `menu-root`              | Root menu element |
| `menu-item`              | Menu item |
| `menu-item-{id}`         | Specific item by identity |
| `menu-separator`         | Separator |
| `menu-submenu`           | Submenu popup |
| `menu-item-icon`         | Icon element inside an item |

---

## 10. Design Constraints

- Selectors (`*Selector`) always take precedence over field-name strings.
- There is **no** `EnableRtl` parameter. RTL behavior is inherited from the nearest ancestor with `dir="rtl"`.
- The component must not depend on any commercial Syncfusion.Blazor package.
- All public members must have complete XML documentation (see `API-xml.md`) so that CS1591 = 0.
- Prefer reuse of existing Toolkit primitives (popup/overlay, theme tokens, etc.).

---