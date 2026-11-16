# Public API Reference – SfToolbar  
**Component:** SfToolbar  
**Namespace:** `Syncfusion.Blazor.Toolkit`  
**Repository:** https://github.com/syncfusion/blazor-toolkit  

> **Status:** Approved (not implemented). No Toolbar implementation or shipped public API baseline exists at this revision. Phase labels define availability; this document does not claim that the members have shipped. Requirement ids are in [Spec.md](Spec.md).

---

## 1. Overview

The `SfToolbar` component provides a responsive, accessible command toolbar for Blazor applications. It supports adaptive overflow, command grouping, templates, keyboard navigation, and full WAI-ARIA compliance.

**Supported render modes**
- Static SSR (markup only; no event interaction or overflow measurement)
- Interactive Server
- Interactive WebAssembly
- Interactive Auto

**Key capabilities**
- Horizontal and vertical orientation
- Four overflow modes (Scrollable, Popup, MultiRow, Extended)
- Priority-based overflow
- Button, Toggle, Split, DropDown, Menu, and Template items
- Grouping, separators, and spacers
- Data binding and declarative definition
- RTL, localization, and high-contrast support

### Phase availability

The Phase column of the registry in [Spec.md](Spec.md) section 22 is the only authority for phase availability. This file does not repeat it.

---

## 2. Components

### 2.1 SfToolbar

Root toolbar component.

#### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Orientation` | `ToolbarOrientation` | `Horizontal` | Layout direction of the toolbar (Horizontal or Vertical). |
| `OverflowMode` | `ToolbarOverflowMode` | `Popup` | Strategy used when items overflow available space. |
| `Align` | `ToolbarAlignment` | `Start` | Alignment of items inside the toolbar. |
| `CssClass` | `string` | `null` | Additional CSS classes applied to the root element. |
| `HtmlAttributes` | `Dictionary<string, object>` | `null` | Additional HTML attributes applied to the root element. |
| `AriaLabel` | `string` | `null` | Accessible name of the toolbar (`aria-label`). |
| `EnableRtl` | `bool?` | `null` | Forces right-to-left direction. `null` inherits from parent/application. |
| `ChildContent` | `RenderFragment` | – | Declarative content (ToolbarItem, ToolbarGroup, etc.). |
| `Items` | `IEnumerable<ToolbarItemModel>` | `null` | Data-bound collection of items (Phase 2). Not the same member as `ToolbarItem.Items` (ADR-011). |
| `ItemTemplate` | `RenderFragment<ToolbarTemplateContext>` | `null` | Template used when rendering items from the `Items` collection. |
| `OverflowSettings` | `ToolbarOverflowSettings` | `new()` | Advanced overflow configuration. |
| `OnItemClick` | `EventCallback<ToolbarItemClickEventArgs>` | – | Raised when any item is clicked. |
| `OnOverflowOpen` | `EventCallback` | – | Raised when the overflow menu opens. |
| `OnOverflowClose` | `EventCallback` | – | Raised when the overflow menu closes. |

#### Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `RefreshOverflowAsync()` | `ValueTask` | Forces recalculation of visible vs. overflowed items. |
| `FocusAsync()` | `ValueTask` | Moves focus into the toolbar (first enabled item). |
| `GetVisibleItems()` | `IReadOnlyList<ComponentBase>` | Returns items currently shown in the main toolbar area. |
| `GetOverflowItems()` | `IReadOnlyList<ComponentBase>` | Returns items currently placed in the overflow menu. |

#### Example – Declarative usage

```razor
<SfToolbar AriaLabel="Main commands" OverflowMode="ToolbarOverflowMode.Popup">
    <ToolbarItem Text="Cut" IconCss="e-icons e-cut" OnClick="@OnCut" />
    <ToolbarItem Text="Copy" IconCss="e-icons e-copy" OnClick="@OnCopy" />
    <ToolbarSeparator />
    <ToolbarItem Text="Paste" IconCss="e-icons e-paste" OnClick="@OnPaste" />
    <ToolbarSpacer />
    <ToolbarItem Text="More" Type="ToolbarItemType.DropDown">
        <Items>
            <ToolbarItem Text="Option A" />
            <ToolbarItem Text="Option B" />
        </Items>
    </ToolbarItem>
</SfToolbar>
```

#### Example – Data-bound usage

```razor
<SfToolbar Items="@toolbarItems" ItemTemplate="@ItemTemplate" />

@code {
    List<ToolbarItemModel> toolbarItems = new()
    {
        new() { Text = "Cut", IconCss = "e-icons e-cut" },
        new() { Text = "Copy", IconCss = "e-icons e-copy" },
        new() { Text = "Paste", IconCss = "e-icons e-paste" }
    };

    RenderFragment<ToolbarTemplateContext> ItemTemplate => context =>
        @<ToolbarItem Text="@context.Item.Text" IconCss="@context.Item.IconCss" />;
}
```

---

### 2.2 ToolbarItem

Represents a single command inside the toolbar.

#### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Id` | `string` | auto-generated | Unique identifier of the item. |
| `Text` | `string` | `null` | Display text and accessible name, including when `DisplayMode=IconOnly`. |
| `IconCss` | `string` | `null` | CSS class for the icon. |
| `IconPosition` | `IconPosition` | `Left` | Position of the icon relative to the text. |
| `Type` | `ToolbarItemType` | `Button` | Behavioral/visual type of the item. |
| `Enabled` | `bool` | `true` | Whether the item is interactive. `SfToolbar` has no toolbar-wide `Enabled` (ADR-005). |
| `Visible` | `bool` | `true` | Whether the item is rendered. |
| `Selected` | `bool` | `false` | Selected state for toggle items (supports `@bind-Selected`). |
| `Overflow` | `ToolbarOverflowOption` | `None` | Overflow priority (`Show`, `Hide`, or `None`). |
| `Priority` | `int` | `0` | Secondary sort key for overflow (lower values stay visible longer). |
| `Tooltip` | `string` | `null` | Supplemental tooltip; does not replace the accessible name in `Text`. |
| `Badge` | `string` | `null` | Badge content. |
| `CssClass` | `string` | `null` | Additional CSS classes. |
| `DisplayMode` | `ToolbarItemDisplayMode` | `IconAndText` | Controls icon-only, text-only, or combined display. |
| `GroupName` | `string` | `null` | Radio-group name for mutually exclusive selection. |
| `ChildContent` | `RenderFragment` | – | Custom content inside the item. |
| `Template` | `RenderFragment<ToolbarTemplateContext>` | – | Advanced item template. |
| `Items` | `RenderFragment` | – | Nested `ToolbarItem` content for Split, DropDown, or Menu types (Phase 2). Not the same member as `SfToolbar.Items` (ADR-011). |
| `OnClick` | `EventCallback<MouseEventArgs>` | – | Click event handler. |

#### Example – Toggle item

```razor
<ToolbarItem Text="Bold"
             IconCss="e-icons e-bold"
             Type="ToolbarItemType.Toggle"
             @bind-Selected="isBold" />
```

#### Example – Split button

```razor
<ToolbarItem Text="Save"
             Type="ToolbarItemType.Split"
             OnClick="@OnSave">
    <Items>
        <ToolbarItem Text="Save As…" OnClick="@OnSaveAs" />
        <ToolbarItem Text="Save All" OnClick="@OnSaveAll" />
    </Items>
</ToolbarItem>
```

---

### 2.3 ToolbarGroup

Groups related items visually and semantically (`role="group"`).

#### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Label` | `string` | `null` | Accessible name (`aria-label`) of the group. |
| `ChildContent` | `RenderFragment` | – | Items that belong to the group. |
| `CssClass` | `string` | `null` | Additional CSS classes. |

`ToolbarGroup` exposes `ChildContent` only. There is no public `GroupTemplate` or templated-group member in this contract. Use item-level templates for custom item content.

#### Example

```razor
<ToolbarGroup Label="Clipboard">
    <ToolbarItem Text="Cut" IconCss="e-icons e-cut" />
    <ToolbarItem Text="Copy" IconCss="e-icons e-copy" />
    <ToolbarItem Text="Paste" IconCss="e-icons e-paste" />
</ToolbarGroup>
```

---

### 2.4 ToolbarSeparator

Visual divider between items (`role="separator"`).

#### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Visible` | `bool` | `true` | Whether the separator is rendered. |
| `CssClass` | `string` | `null` | Additional CSS classes. |

---

### 2.5 ToolbarSpacer

Flexible space that expands to push adjacent items apart.

#### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `CssClass` | `string` | `null` | Additional CSS classes. |

---

### 2.6 ToolbarTemplateItem

Renders arbitrary custom content while still participating in overflow calculation.

#### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `ChildContent` | `RenderFragment` | – | Custom content. |
| `Overflow` | `ToolbarOverflowOption` | `None` | Overflow priority. |
| `Priority` | `int` | `0` | Secondary overflow priority. |

#### Example – Search box

```razor
<ToolbarTemplateItem>
    <SfTextBox Placeholder="Search…" Width="180px" />
</ToolbarTemplateItem>
```

---

## 3. Supporting Models

### 3.1 ToolbarItemModel

Data model used with the `Items` parameter.

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Id` | `string` | `null` | Unique identifier. |
| `Text` | `string` | `null` | Display text. |
| `IconCss` | `string` | `null` | Icon CSS class. |
| `Type` | `ToolbarItemType` | `Button` | Item type. |
| `Enabled` | `bool` | `true` | Enabled state. |
| `Visible` | `bool` | `true` | Visibility. |
| `Selected` | `bool` | `false` | Toggle selected state. |
| `Overflow` | `ToolbarOverflowOption` | `None` | Overflow priority. |
| `Priority` | `int` | `0` | Secondary priority. |
| `Tooltip` | `string` | `null` | Tooltip text. |
| `Badge` | `string` | `null` | Badge content. |
| `GroupName` | `string` | `null` | Radio group name. |
| `DisplayMode` | `ToolbarItemDisplayMode` | `IconAndText` | Display mode. |

---

### 3.2 ToolbarOverflowSettings

Configuration object for overflow behavior.

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `ShowOverflowButton` | `bool` | `true` | Shows the “More” button when items overflow. |
| `OverflowButtonIconCss` | `string` | `null` | CSS class for the overflow button icon. |
| `OverflowButtonTooltip` | `string` | `"More"` | Tooltip of the overflow button. |
| `PopupCssClass` | `string` | `null` | Additional CSS classes for the overflow popup. |
| `CloseOnSelect` | `bool` | `true` | Closes the popup after an item is selected. |

---

### 3.3 ToolbarTemplateContext

Context supplied to item templates.

| Property | Type | Description |
|----------|------|-------------|
| `Item` | `ToolbarItemModel` | The data item being rendered. |
| `IsOverflow` | `bool` | `true` when the item is rendered inside the overflow menu. |

---

### 3.4 ToolbarItemClickEventArgs

Event arguments for `OnItemClick`.

| Property | Type | Description |
|----------|------|-------------|
| `ItemId` | `string` | Identifier of the clicked item. |
| `Item` | `ToolbarItemModel` | Data model of the clicked item (when data-bound). |
| `OriginalArgs` | `MouseEventArgs` | Original browser event arguments. |
| `Cancel` | `bool` | Settable. When `true`, the default action stops: a Toggle keeps `Selected`, and a Split, DropDown or Menu does not open. `OnItemClick` still fires after the item `OnClick`. See ADR-004. |

---

## 4. Enumerations

### 4.1 ToolbarOrientation

| Value | Description |
|-------|-------------|
| `Horizontal` | Items arranged left-to-right (default). |
| `Vertical` | Items arranged top-to-bottom. |

---

### 4.2 ToolbarAlignment

| Value | Description |
|-------|-------------|
| `Start` | Items packed toward the start (default). |
| `Center` | Items centered. |
| `End` | Items packed toward the end. |
| `Justify` | Items evenly distributed. |

---

### 4.3 ToolbarOverflowMode

| Value | Description |
|-------|-------------|
| `Scrollable` | Single line with scrolling. |
| `Popup` | Overflow items moved to a “More” menu (default). |
| `MultiRow` | Overflow items wrap to additional rows. |
| `Extended` | Extra rows collapsed behind an expand button. |

---

### 4.4 ToolbarOverflowOption

| Value | Description |
|-------|-------------|
| `Show` | Prefer keeping the item in the main bar. |
| `Hide` | Prefer moving the item to the overflow menu. |
| `None` | Follow normal document order (default). |

---

### 4.5 ToolbarItemType

| Value | Description |
|-------|-------------|
| `Button` | Standard push button. |
| `Toggle` | Button with selected/unselected state. A non-empty `GroupName` makes it mutually exclusive. |
| `Check` | Button with selected state that stays selected alongside others that share its group name. |
| `Split` | Primary action + secondary dropdown. |
| `DropDown` | Button that opens a dropdown list. |
| `Menu` | Button that opens a menu. |
| `Separator` | Visual separator. |
| `Spacer` | Flexible space. |
| `Template` | Custom content via template. |

---

### 4.6 ToolbarItemDisplayMode

| Value | Description |
|-------|-------------|
| `IconOnly` | Only the icon is shown. |
| `TextOnly` | Only the text is shown. |
| `IconAndText` | Both icon and text are shown (default). |

---

## 5. Events Summary

| Event | Component | Arguments | Description |
|-------|-----------|-----------|-------------|
| `OnItemClick` | `SfToolbar` | `ToolbarItemClickEventArgs` | Any item clicked. Fires after the item `OnClick`. Supports `Cancel`. |
| `OnClick` | `ToolbarItem` | `MouseEventArgs` | Specific item clicked. |
| `OnOverflowOpen` | `SfToolbar` | – | Overflow menu opened. |
| `OnOverflowClose` | `SfToolbar` | – | Overflow menu closed. |
| `SelectedChanged` | `ToolbarItem` (via `@bind-Selected`) | `bool` | Toggle state changed. |

---

## 6. Accessibility Notes

- Root element uses `role="toolbar"` and `aria-orientation`.
- Groups use `role="group"` with optional `aria-label`.
- Separators use `role="separator"`.
- Overflow button uses `aria-haspopup="menu"` and `aria-expanded`.
- Roving `tabindex` is maintained automatically.
- Full keyboard support: Arrow keys, Home, End, Enter, Space, Escape, Tab.

---

## 7. Theme & Styling

- All visual styling is driven by CSS custom properties (compatible with `SfThemeRoot` / `SfThemeScope`).
- Supports Light, Dark, and forced-colors themes (P0, ADR-008).
- CSS isolation compatible.
- Root CSS class follows Toolkit naming conventions (e.g. `.e-toolbar`).

## 8. Sample Browser contract

The six demos are defined only in [sample-preparer.md](sample-preparer.md). Accessibility routes are listed in [ADR-010](adr/ADR-010-accessibility-route-list.md).

---

## 9. Related Types (Internal / Advanced)

| Type | Visibility | Purpose |
|------|------------|---------|
| `IToolbarItem` | internal | Contract implemented by all toolbar items for registration and overflow. |
| `ToolbarItemCollection` | internal | Observable collection that manages item lifetime. |

These types are not part of the public API surface and should not be used directly by application code.