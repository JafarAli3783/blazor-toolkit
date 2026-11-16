# SfAppBar — Public API Definition

**Namespace:** Syncfusion.Blazor.Toolkit  
**Version:** 1.0  

**Cross References:**  
Spec.md, API-xml.md, TEST-MATRIX.md, Evidence.md

---

# Table of Contents

1. [API Inventory](#1-api-inventory)
2. [Components](#2-components)
3. [Enums](#3-enums)
4. [Cascading State](#4-cascading-state)
5. [Templates](#5-templates)
6. [Events](#6-events)
7. [Methods](#7-methods)
8. [CSS Contracts](#8-css-contracts)
9. [data-testid Contracts](#9-data-testid-contracts)
10. [API Traceability Matrix](#10-api-traceability-matrix)
11. [Phase Separation](#11-phase-separation)
12. [Non-Goals](#12-non-goals)
13. [Future API Recommendations](#13-future-api-recommendations)

---

# 1. API Inventory

| API ID | Member | Kind |
|---------|---------|------|
| API-AB-001 | SfAppBar | Component |
| API-AB-002 | SfAppBarItem | Component |
| API-AB-003 | SfAppBarSpacer | Component |
| API-AB-004 | SfAppBarOverflow | Component |
| API-AB-010 | Position | Parameter |
| API-AB-011 | Mode | Parameter |
| API-AB-012 | Density | Parameter |
| API-AB-013 | EnableOverflow | Parameter |
| API-AB-014 | AriaLabel | Parameter |
| API-AB-015 | Class | Parameter |
| API-AB-016 | Style | Parameter |
| API-AB-017 | Id | Parameter |
| API-AB-018 | ChildContent | Parameter |
| API-AB-019 | BrandingTemplate | Parameter |
| API-AB-020 | TitleTemplate | Parameter |
| API-AB-021 | ContentTemplate | Parameter |
| API-AB-022 | ActionsTemplate | Parameter |
| API-AB-023 | LeadingTemplate | Parameter |
| API-AB-024 | OverflowTemplate | Parameter |
| API-AB-025 | Title | Parameter |
| API-AB-026 | Elevation | Parameter |
| API-AB-027 | ShowBorder | Parameter |
| API-AB-030 | OnOverflowOpened | Event |
| API-AB-031 | OnOverflowClosed | Event |
| API-AB-032 | OnItemClick | Event |
| API-AB-040 | FocusAsync | Method |
| API-AB-041 | RefreshAsync | Method |
| API-AB-042 | MeasureAsync | Method |
| API-AB-050 | AppBarPosition | Enum |
| API-AB-051 | AppBarMode | Enum |
| API-AB-052 | AppBarDensity | Enum |
| API-AB-053 | AppBarAlignment | Enum |
| API-AB-060 | AppBarContext | Cascading State |

---

# 2. Components

## 2.1 SfAppBar (API-AB-001)

Root application bar component.

### Parameters

| Name | Type | Default | Phase | Description |
|--------|------|---------|--------|-------------|
| Position | AppBarPosition | Top | MVP | Top or Bottom placement |
| Mode | AppBarMode | Static | MVP | Static, Fixed, Sticky |
| Density | AppBarDensity | Comfortable | MVP | Comfortable or Compact |
| EnableOverflow | bool | false | Phase 2 | Enables responsive overflow measurement |
| Title | string? | null | MVP | Simple title text |
| AriaLabel | string? | null | MVP | Accessible toolbar name |
| Elevation | int | 2 | MVP | Elevation level (0–24) |
| ShowBorder | bool | false | MVP | Show top/bottom border |
| Id | string? | null | MVP | Element identifier |
| Class | string? | null | MVP | Additional CSS classes |
| Style | string? | null | MVP | Inline styles |
| ChildContent | RenderFragment? | null | MVP | Items, spacers, custom content |
| LeadingTemplate | RenderFragment? | null | Phase 2 | Leading region content |
| BrandingTemplate | RenderFragment? | null | Phase 2 | Branding region content |
| TitleTemplate | RenderFragment? | null | Phase 2 | Title region override |
| ContentTemplate | RenderFragment? | null | Phase 2 | Center/content region |
| ActionsTemplate | RenderFragment? | null | Phase 2 | Actions region override |
| OverflowTemplate | RenderFragment? | null | Phase 2 | Overflow panel content |

### Events

| Name | Type | Phase |
|--------|------|--------|
| OnOverflowOpened | EventCallback | Phase 2 |
| OnOverflowClosed | EventCallback | Phase 2 |
| OnItemClick | EventCallback<AppBarItemClickEventArgs> | MVP |

### Methods

| Name | Signature | Phase | Description |
|--------|-----------|--------|-------------|
| FocusAsync | `Task FocusAsync()` | MVP | Focus first enabled action |
| RefreshAsync | `Task RefreshAsync()` | Phase 2 | Force layout recalculation |
| MeasureAsync | `Task MeasureAsync()` | Phase 2 | Re-run overflow measurement |

---

## 2.2 SfAppBarItem (API-AB-002)

Represents an action or content entry inside the AppBar.

### Parameters

| Parameter | Type | Default | Phase | Description |
|------------|------|---------|--------|-------------|
| Id | string? | null | MVP | Stable id and test identifier suffix |
| Priority | int | 0 | Phase 2 | Lower value remains visible longer |
| Visible | bool | true | MVP | Controls visibility |
| Disabled | bool | false | MVP | Disabled state |
| CssClass | string? | null | MVP | Additional CSS class |
| ChildContent | RenderFragment? | null | MVP | Usually an SfButton |
| Text | string? | null | MVP | Optional text metadata |
| IconCss | string? | null | MVP | Optional icon CSS metadata |

---

## 2.3 SfAppBarSpacer (API-AB-003)

Flexible or fixed-width spacing element.

### Parameters

| Parameter | Type | Default | Description |
|------------|------|---------|-------------|
| Width | string? | null | Fixed width; `null` uses flexible grow behavior |

---

## 2.4 SfAppBarOverflow (API-AB-004) — Phase 2

Container for overflowed AppBar items.

Typically generated automatically when `EnableOverflow=true`, but publicly exposed for advanced customization.

### Parameters

| Parameter | Type | Default |
|------------|------|---------|
| ChildContent | RenderFragment? | null |

---

# 3. Enums

## AppBarPosition (API-AB-050)

```csharp
public enum AppBarPosition
{
    Top,
    Bottom
}
```

## AppBarMode (API-AB-051)

```csharp
public enum AppBarMode
{
    Static,
    Fixed,
    Sticky
}
```

## AppBarDensity (API-AB-052)

```csharp
public enum AppBarDensity
{
    Comfortable,
    Compact
}
```

## AppBarAlignment (API-AB-053)

```csharp
public enum AppBarAlignment
{
    Start,
    Center,
    End,
    SpaceBetween
}
```

Reserved for future alignment helpers and advanced layout scenarios.

---

# 4. Cascading State

## AppBarContext (API-AB-060)

| Member | Type | Purpose |
|----------|------|---------|
| Density | AppBarDensity | Child styling awareness |
| Mode | AppBarMode | Child behavioral awareness |
| Position | AppBarPosition | Child placement awareness |
| Register(SfAppBarItem) | void | Item registration for overflow tracking |
| Unregister(SfAppBarItem) | void | Item cleanup and deregistration |

---

# 5. Templates

The following template parameters are supported:

- `LeadingTemplate`
- `BrandingTemplate`
- `TitleTemplate`
- `ContentTemplate`
- `ActionsTemplate`
- `OverflowTemplate`

> **Phase 2 Feature**  
> MVP implementations may rely on `ChildContent` composition only.

---

# 6. Events

## AppBarItemClickEventArgs

| Property | Type |
|-----------|------|
| ItemId | string? |
| Item | SfAppBarItem? |

### Event Catalog

| Event | Description |
|---------|-------------|
| OnItemClick | Raised when an AppBar action is invoked |
| OnOverflowOpened | Raised when overflow panel opens |
| OnOverflowClosed | Raised when overflow panel closes |

---

# 7. Methods

## FocusAsync

```csharp
Task FocusAsync();
```

Moves focus to the first enabled action item in the toolbar.

## RefreshAsync

```csharp
Task RefreshAsync();
```

Forces AppBar layout recalculation.

## MeasureAsync

```csharp
Task MeasureAsync();
```

Triggers a new responsive overflow measurement pass.

---

# 8. CSS Contracts

All CSS contracts are defined by:

- Spec.md `S-AB-CSS-*`
- CSS isolation model
- Theme token contracts
- Density modifiers
- Position modifiers
- Mode modifiers

### Root CSS Classes

```css
.sf-appbar
.sf-appbar--top
.sf-appbar--bottom
.sf-appbar--static
.sf-appbar--fixed
.sf-appbar--sticky
.sf-appbar--comfortable
.sf-appbar--compact
```

### Region Classes

```css
.sf-appbar__leading
.sf-appbar__branding
.sf-appbar__title
.sf-appbar__content
.sf-appbar__actions
.sf-appbar__overflow
```

---

# 9. data-testid Contracts

Defined by Spec.md `S-AB-TESTID-01`.

### Test IDs

| data-testid | Element |
|-------------|---------|
| sf-appbar | Root |
| sf-appbar-leading | Leading region |
| sf-appbar-branding | Branding region |
| sf-appbar-title | Title region |
| sf-appbar-content | Content region |
| sf-appbar-actions | Actions toolbar |
| sf-appbar-overflow | Overflow host |
| sf-appbar-overflow-trigger | Overflow trigger |
| sf-appbar-item-{id} | Individual item |
| sf-appbar-spacer | Spacer |

---

# 10. API Traceability Matrix

| API ID | Member | Type | Default | Spec IDs | Test IDs |
|---------|---------|---------|---------|---------|---------|
| API-AB-001 | SfAppBar | Component | — | S-AB-ARCH-01 | U-AB-001, P-AB-001 |
| API-AB-002 | SfAppBarItem | Component | — | S-AB-REG-01 | U-AB-010 |
| API-AB-003 | SfAppBarSpacer | Component | — | S-AB-REG-03 | U-AB-011 |
| API-AB-004 | SfAppBarOverflow | Component | — | S-AB-OVR-01 | U-AB-030 |
| API-AB-010 | Position | Parameter | Top | S-AB-LAY-01 | U-AB-002 |
| API-AB-011 | Mode | Parameter | Static | S-AB-LAY-02 | U-AB-003 |
| API-AB-012 | Density | Parameter | Comfortable | S-AB-LAY-03 | U-AB-004 |
| API-AB-013 | EnableOverflow | Parameter | false | S-AB-OVR-01 | U-AB-031 |
| API-AB-014 | AriaLabel | Parameter | null | S-AB-A11Y-01 | U-AB-040 |
| API-AB-015 | Class | Parameter | null | S-AB-CSS-01 | U-AB-005 |
| API-AB-016 | Style | Parameter | null | S-AB-CSS-01 | U-AB-006 |
| API-AB-017 | Id | Parameter | null | S-AB-TESTID-01 | U-AB-007 |
| API-AB-018 | ChildContent | Parameter | null | S-AB-REG-01 | U-AB-012 |
| API-AB-019 | BrandingTemplate | Parameter | null | S-AB-RND-01 | U-AB-050 |
| API-AB-020 | TitleTemplate | Parameter | null | S-AB-RND-01 | U-AB-051 |
| API-AB-021 | ContentTemplate | Parameter | null | S-AB-RND-01 | U-AB-052 |
| API-AB-022 | ActionsTemplate | Parameter | null | S-AB-RND-01 | U-AB-053 |
| API-AB-023 | LeadingTemplate | Parameter | null | S-AB-RND-01 | U-AB-054 |
| API-AB-024 | OverflowTemplate | Parameter | null | S-AB-OVR-01 | U-AB-055 |
| API-AB-025 | Title | Parameter | null | S-AB-REG-01 | U-AB-013 |
| API-AB-026 | Elevation | Parameter | 2 | S-AB-CSS-03 | U-AB-014 |
| API-AB-027 | ShowBorder | Parameter | false | S-AB-CSS-02 | U-AB-015 |
| API-AB-030 | OnOverflowOpened | Event | — | S-AB-OVR-03 | U-AB-060 |
| API-AB-031 | OnOverflowClosed | Event | — | S-AB-OVR-03 | U-AB-061 |
| API-AB-032 | OnItemClick | Event | — | S-AB-CMD-01 | U-AB-062 |
| API-AB-040 | FocusAsync | Method | — | S-AB-KBD-01 | U-AB-070 |
| API-AB-041 | RefreshAsync | Method | — | S-AB-OVR-01 | U-AB-071 |
| API-AB-042 | MeasureAsync | Method | — | S-AB-OVR-01 | U-AB-072 |
| API-AB-050 | AppBarPosition | Enum | — | S-AB-LAY-01 | U-AB-080 |
| API-AB-051 | AppBarMode | Enum | — | S-AB-LAY-02 | U-AB-081 |
| API-AB-052 | AppBarDensity | Enum | — | S-AB-LAY-03 | U-AB-082 |
| API-AB-053 | AppBarAlignment | Enum | — | S-AB-REG-01 | U-AB-083 |
| API-AB-060 | AppBarContext | Cascading State | — | S-AB-REG-04 | I-AB-010 |

---

# 11. Phase Separation

## MVP

- API-AB-001 to API-AB-003
- API-AB-010 to API-AB-012
- API-AB-014 to API-AB-018
- API-AB-025 to API-AB-027
- API-AB-032
- API-AB-040
- API-AB-050 to API-AB-052
- API-AB-060 (subset)

## Phase 2

- EnableOverflow
- Overflow component
- Template parameters
- RefreshAsync
- MeasureAsync
- Overflow events
- Item Priority support

## Phase 3

- Expanded alignment helpers
- Contextual AppBar APIs
- Advanced adaptive layout APIs

---

# 12. Non-Goals

The following APIs are intentionally out of scope:

- Ribbon API
- Docking API
- Multi-row command surface API
- Direct commercial Syncfusion AppBar API compatibility
- Commercial Syncfusion.Blazor dependency mirroring

---

# 13. Future API Recommendations

## Potential Additions

### ThemeColor / Color Support

```csharp
ThemeColor
Color
```

Add after Toolkit-wide semantic color standardization.

### Data-Bound Items Collection

```csharp
IEnumerable<AppBarItemModel> Items
```

Alternative to purely declarative child-content composition.

### OverflowMinVisible

```csharp
int OverflowMinVisible
```

Guarantees a minimum number of visible action items before overflow.

### Advanced Responsive Policies

```csharp
ResponsiveStrategy
OverflowPriorityPolicy
```

Potential future enhancements for enterprise-scale toolbars and adaptive layouts.

---