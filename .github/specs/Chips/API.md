# API.md — SfChip / SfChipSet

## Syncfusion Blazor Toolkit

**Version:** 1.0.0-proposed  
**Namespace:** `Syncfusion.Blazor.Toolkit`  
**Aligned With:** Spec.md 1.0-proposed (Chips)

---

## Overview

This document defines the normative public API surface for the toolkit Chip components. It is the member contract. Spec-kit commercial Chip member names are not this API. Parent requirement IDs are in `TRACEABILITY.md`.

All parameter names, default values, behaviors, events, methods, accessibility requirements, and samples must remain consistent with:

- Spec.md
- API XML Documentation
- Test Matrix
- Sample Browser Demonstrations

Internal rendering helpers and implementation details are not considered public API.

---

# 1. Components

| Component | Generics | Description |
|------------|------------|-------------|
| `SfChip` | — | Standalone declarative chip |
| `SfChipSet<TItem>` | `TItem` | Chip container supporting data binding, selection, removal, and overflow management |

**Non-Public Components**

The following remain internal implementation details:

- Remove icon renderers
- Overflow measurement services
- Layout helpers
- Accessibility infrastructure helpers

---

# 2. Enumerations

## 2.1 ChipType

| Name | Value | Description |
|--------|--------:|-------------|
| Informational | 0 | Non-interactive information |
| Status | 1 | Non-interactive status |
| Action | 2 | Activates a command |
| Assist | 3 | Assistive action |
| Filter | 4 | Toggle filter using `aria-pressed` |
| Choice | 5 | Exclusive selection within a set |
| Input | 6 | Tokenized item, typically removable |
| Suggestion | 7 | Suggested action |
| Navigation | 8 | Navigation chip requiring `Href` |
| Custom | 9 | Author-defined semantics |

**Default:** `Informational`

---

## 2.2 ChipSelectionMode

| Name | Value | Description |
|--------|--------:|-------------|
| None | 0 | No selection |
| Single | 1 | Single selection |
| Multiple | 2 | Multiple selection |

**Default:** `None`

---

## 2.3 ChipVariant

| Name | Value | Description |
|--------|--------:|-------------|
| Filled | 0 | Filled appearance |
| Outlined | 1 | Outlined appearance |

**Default:** `Filled`

---

## 2.4 ChipSize

| Name | Value | Description |
|--------|--------:|-------------|
| Small | 0 | Compact |
| Medium | 1 | Standard |
| Large | 2 | Comfortable |

**Default:** `Medium`

---

## 2.5 ChipShape

| Name | Value | Description |
|--------|--------:|-------------|
| Rounded | 0 | Standard rounded corners |
| Pill | 1 | Fully rounded pill appearance |

**Default:** `Rounded`

---

## 2.6 ChipOverflowMode

| Name | Value | Description |
|--------|--------:|-------------|
| Wrap | 0 | Wrap to additional rows |
| Scroll | 1 | Horizontal scrolling |
| Collapse | 2 | Display "+N" overflow control |

**Default:** `Wrap`

---

## 2.7 ChipRemoveReason

| Name | Value | Description |
|--------|--------:|-------------|
| RemoveButton | 0 | Remove button clicked |
| Keyboard | 1 | Remove via Delete/Backspace |
| Programmatic | 2 | Removed through API |

---

# 3. SfChip

## Parameters

| Parameter | Type | Default | Two-Way | Description |
|------------|------|---------|---------|-------------|
| ChildContent | `RenderFragment?` | `null` | No | Body content |
| Text | `string?` | `null` | No | Display text |
| ChipType | `ChipType` | `Informational` | No | Semantic type |
| Variant | `ChipVariant` | `Filled` | No | Visual style |
| Size | `ChipSize` | `Medium` | No | Display size |
| Shape | `ChipShape` | `Rounded` | No | Shape |
| Disabled | `bool` | `false` | No | Disables interaction |
| ReadOnly | `bool` | `false` | No | Blocks modification |
| Removable | `bool` | `false` | No | Displays remove button |
| Selected | `bool` | `false` | Yes | Selection state |
| Value | `object?` | `null` | No | Chip value when projected into a set |
| IsLoading | `bool` | `false` | No | Suppresses activation |
| HasError | `bool` | `false` | No | Error state class |
| Href | `string?` | `null` | No | Navigation URL |
| Target | `string?` | `null` | No | Link target |
| Rel | `string?` | `null` | No | Link rel attribute |
| IconCss | `string?` | `null` | No | Leading icon CSS class |
| ImageUrl | `string?` | `null` | No | Leading image URL |
| ImageAlt | `string?` | `null` | No | Image alt text |
| CssClass | `string?` | `null` | No | Additional classes |
| Style | `string?` | `null` | No | Inline styles |
| Id | `string?` | `null` | No | DOM id |
| AriaLabel | `string?` | `null` | No | Accessible label |
| AriaLabelledBy | `string?` | `null` | No | Id of the labelling element |
| AriaDescribedBy | `string?` | `null` | No | DescribedBy IDs |
| EnableRtl | `bool` | `false` | No | Right-to-left layout |
| TabIndex | `int?` | `null` | No | Focus override |
| HtmlAttributes | `Dictionary<string, object>?` | `null` | No | Additional attributes |
| LeadingTemplate | `RenderFragment?` | `null` | No | Leading content |
| TrailingTemplate | `RenderFragment?` | `null` | No | Trailing content |
| RemoveTemplate | `RenderFragment?` | `null` | No | Remove content |

---

## Events

| Event | Type |
|---------|------|
| OnClick | `EventCallback<MouseEventArgs>` |
| SelectedChanged | `EventCallback<bool>` |
| Removing | `EventCallback<ChipRemovingEventArgs>` |
| Removed | `EventCallback<ChipRemovedEventArgs>` |

---

## Public Methods

```csharp
ValueTask FocusAsync();
ValueTask FocusRemoveAsync();
```

### Behavioral Notes

- Navigation chips require `Href`.
- Remove actions never trigger `OnClick`.
- Remove functionality is suppressed when `Disabled` or `ReadOnly`.

---

# 4. SfChipSet<TItem>

## Parameters

### Data Binding

| Parameter | Type |
|------------|------|
| ChildContent | `RenderFragment?` |
| DataSource | `IEnumerable<TItem>?` |
| ItemKey | `Func<TItem, object>?` |
| TextSelector | `Func<TItem, string>?` |
| ValueSelector | `Func<TItem, object?>?` |
| DisabledSelector | `Func<TItem, bool>?` |
| RemovableSelector | `Func<TItem, bool>?` |
| IconCssSelector | `Func<TItem, string?>?` |
| ImageUrlSelector | `Func<TItem, string?>?` |
| ImageAltSelector | `Func<TItem, string?>?` |
| HrefSelector | `Func<TItem, string?>?` |
| CssClassSelector | `Func<TItem, string?>?` |
| Fields | `ChipFields?` |

### Selection

| Parameter | Type | Default |
|------------|------|---------|
| SelectionMode | `ChipSelectionMode` | `None` |
| SelectedValue | `object?` | `null` |
| SelectedValues | `IEnumerable<object?>?` | `null` |
| AllowEmpty | `bool` | `true` |
| AllowDuplicates | `bool` | `false` |
| MaxChips | `int?` | `null` |

### Appearance

| Parameter | Type | Default |
|------------|------|---------|
| ChipType | `ChipType` | `Informational` |
| Variant | `ChipVariant` | `Filled` |
| Size | `ChipSize` | `Medium` |
| Shape | `ChipShape` | `Rounded` |
| OverflowMode | `ChipOverflowMode` | `Wrap` |
| CollapsedVisibleCount | `int?` | `null` |

### State

| Parameter | Type | Default |
|------------|------|---------|
| Disabled | `bool` | `false` |
| ReadOnly | `bool` | `false` |
| Removable | `bool` | `false` |
| IsLoading | `bool` | `false` |
| HasError | `bool` | `false` |

### Templates

| Parameter | Type |
|------------|------|
| ChipTemplate | `RenderFragment<TItem>?` |
| LeadingTemplate | `RenderFragment<TItem>?` |
| TrailingTemplate | `RenderFragment<TItem>?` |
| RemoveTemplate | `RenderFragment<TItem>?` |
| EmptyTemplate | `RenderFragment?` |
| LoadingTemplate | `RenderFragment?` |
| ErrorTemplate | `RenderFragment?` |
| OverflowExpandTemplate | `RenderFragment<int>?` |

### Root

| Parameter | Type | Default |
|------------|------|---------|
| CssClass | `string?` | `null` |
| Style | `string?` | `null` |
| Id | `string?` | `null` |
| AriaLabel | `string?` | `null` |
| AriaLabelledBy | `string?` | `null` |
| EnableRtl | `bool` | `false` |
| HtmlAttributes | `Dictionary<string, object>?` | `null` |
| ValueExpression | `Expression<Func<TItem>>?` | `null` | Optional field used to notify a cascading `EditContext` after a committed selection change |

---

## Selector Precedence

1. Explicit selector delegates
2. `ChipFields`
3. Default convention-based resolution

---

## Events

| Event | Type |
|--------|------|
| SelectionChanging | `EventCallback<ChipSelectionChangingEventArgs<TItem>>` |
| SelectionChanged | `EventCallback<ChipSelectionChangedEventArgs<TItem>>` |
| Removing | `EventCallback<ChipRemovingEventArgs<TItem>>` |
| Removed | `EventCallback<ChipRemovedEventArgs<TItem>>` |
| OnChipClick | `EventCallback<ChipClickEventArgs<TItem>>` |
| SelectedValueChanged |
| SelectedValuesChanged |
| OverflowExpandedChanged |

---

## Public Methods

```csharp
ValueTask SelectAsync(object? value);
ValueTask SelectItemAsync(TItem item);
ValueTask ClearSelectionAsync();

ValueTask FocusAsync();
ValueTask FocusChipAsync(object key);

ValueTask RemoveAsync(object key);
ValueTask RemoveItemAsync(TItem item);

ValueTask ExpandOverflowAsync();
ValueTask CollapseOverflowAsync();
```

---

# 5. Supporting Types

## ChipFields

```csharp
public sealed class ChipFields
{
    public string? Text { get; set; }
    public string? Value { get; set; }
    public string? Disabled { get; set; }
    public string? Removable { get; set; }
    public string? IconCss { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageAlt { get; set; }
    public string? CssClass { get; set; }
    public string? Href { get; set; }
}
```

---

## Event Argument Types

### ChipRemovingEventArgs

```csharp
public class ChipRemovingEventArgs
{
    public object? Key { get; set; }
    public string? Text { get; set; }
    public ChipRemoveReason Reason { get; set; }
    public bool Cancel { get; set; }
}
```

### ChipRemovedEventArgs

```csharp
public class ChipRemovedEventArgs
{
    public string? Text { get; set; }
    public object? Key { get; set; }
    public ChipRemoveReason Reason { get; set; }
}
```

### ChipSelectionChangingEventArgs<TItem>

| `CurrentSelectedValues` | `IReadOnlyList<object?>` | Selected values before the change |
| `ProposedSelectedValues` | `IReadOnlyList<object?>` | Selected values that will apply if not canceled |
| `Cancel` | `bool` | Cancel |

`SelectedValues` is not a member of the changing arguments. The completed event carries the applied list.

```csharp
public class ChipSelectionChangingEventArgs<TItem>
{
    public TItem? Item { get; set; }
    public object? Value { get; set; }
    public IReadOnlyList<object?> CurrentSelectedValues { get; set; }
    public IReadOnlyList<object?> ProposedSelectedValues { get; set; }
    public bool Cancel { get; set; }
}
```

### ChipSelectionChangedEventArgs<TItem>

```csharp
public class ChipSelectionChangedEventArgs<TItem>
{
    public TItem? Item { get; set; }
    public object? Value { get; set; }
    public IReadOnlyList<object?> SelectedValues { get; set; }
}
```

---

# 6. Public CSS Contract

```text
e-chip
e-chipset

e-chip-informational
e-chip-status
e-chip-action
e-chip-assist
e-chip-filter
e-chip-choice
e-chip-input
e-chip-suggestion
e-chip-navigation
e-chip-custom

e-chip-filled
e-chip-outlined

e-chip-sm
e-chip-md
e-chip-lg

e-chip-rounded
e-chip-pill

e-chip-selected
e-chip-disabled
e-chip-readonly
e-chip-removable

e-chip-leading
e-chip-trailing
e-chip-remove

e-chipset-wrap
e-chipset-scroll
e-chipset-collapse

e-chipset-overflow
e-rtl
```

Test hooks `data-testid="chip-root"`, `chip-remove`, `chipset-root`, `chip-item`, and `chip-overflow` are not public API.

Declarative `ChildContent` registers each `SfChip` with the set. Selection and removal then use that registration. `DataSource` takes precedence and does not render `ChildContent`.

### CSS Custom Properties

```css
--e-chip-gap
--e-chip-radius
--e-chip-height
--e-chip-accent
```

---

# 7. Localization Resource Keys

| Key | Default Value |
|-------|--------------|
| Chip_Remove | Remove {0} |
| Chip_ShowMore | Show {0} more |
| Chip_ShowLess | Show less |

---

# 8. Default Values

| Property | Default |
|-----------|---------|
| ChipType | Informational |
| SelectionMode | None |
| Variant | Filled |
| Size | Medium |
| Shape | Rounded |
| OverflowMode | Wrap |
| AllowEmpty | true |
| AllowDuplicates | false |
| Removable | false |
| Disabled | false |
| ReadOnly | false |
| IsLoading | false |
| HasError | false |

---

# 9. Invalid Configuration Rules

| Configuration | Behavior |
|---------------|----------|
| Navigation chip without Href | Render as non-link and emit debug diagnostic |
| Choice plus ChipSelectionMode.Multiple | Debug diagnostic, then behave as Single |
| Single and multiple selection values simultaneously configured | Active mode determines precedence |
| Complex data without ItemKey | Selection stability not guaranteed |
| MaxChips exceeded | Do not silently remove bound items |
| Inaccessible RemoveTemplate | Author responsibility; accessibility tests must fail |
| MaxChips exceeded by DataSource | Render all bound items; MaxChips is host add policy only; set does **not** silently drop DataSource items |

---

# 10. Accessibility Requirements

- WCAG 2.2 AA minimum.
- AAA where feasible.
- Full keyboard navigation.
- Screen reader compatibility.
- Accessible remove controls.
- Proper focus management.
- RTL support.
- High contrast support.
- Automated accessibility test coverage.

---

# 11. Versioning

## v1.0

- Initial public release.

### Non-Breaking Changes

- New optional parameters.
- New templates.
- Additional ChipType values.

### Breaking Changes

- Enum value modifications.
- Parameter renames.
- Default value changes.
- Event contract modifications.
