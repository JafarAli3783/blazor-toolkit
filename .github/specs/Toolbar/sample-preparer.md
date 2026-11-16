# SfToolbar — Sample Preparer

| Field              | Value                                                                 |
|--------------------|-----------------------------------------------------------------------|
| **Component**      | `SfToolbar` family                                                    |
| **Host**           | `samples/Blazor.Toolkit.Samples.Client`                               |
| **Catalog route**  | `/navigations/toolbar`                                                |
| **Demo namespace** | `Blazor.Toolkit.Samples.Client.Pages.Demos.Navigations.Toolbar`        |
| **Demo count**     | **6** (high-standard showcase only)                                   |

This document is the official implementation specification for the `SfToolbar` Sample Browser demos.

Each demo must be **production-quality**, visually competitive with (or better than) DevExpress, Telerik, Fluent / Office, and MudBlazor toolbar demos. A visitor should prefer the Syncfusion Blazor Toolkit toolbar after viewing this set.

**Scope Rule (Strict)**

Only the following files may be created, renamed, or modified:

- `samples/Blazor.Toolkit.Samples.Client/Pages/Components/Navigations/Toolbar.razor` — catalog page and demo registration
- `samples/Blazor.Toolkit.Samples.Client/Pages/Demos/Navigations/Toolbar/*.razor` — the six demo files listed in section 1

Do **not** modify:

- Toolbar component source code
- Any other component source code
- Any bUnit, Playwright, or accessibility test files
- Any other catalog, shared style, configuration, or sample file, except the two navigation entries below

Navigation entries (ADR-018): add exactly one Navigations group with a Toolbar link to `samples/Blazor.Toolkit.Samples.Client/Layout/NavMenu.razor`, and the search entries for the six demo headings to `samples/Blazor.Toolkit.Samples.Client/Layout/SearchIndex.cs`. No other line in those two files changes.

**Goal**

Ship **exactly six** demos:

1. **Default** — polished baseline command bar  
2. **Overflow & Priority** — all overflow modes + priority (primary differentiator vs DevExpress adaptivity-only demos)  
3. **Item Types** — buttons, toggles, split, dropdown, groups, separators, spacers  
4. **Templates** — per-item templates and declarative groups, with a live filter bar
5. **Editor** — real-world editor command strip on a document surface  
6. **Orientation** — header toolbar vs side command rail (app shell)

---

## 1. Catalog Page Structure

| Item          | Path / Value                                                                      |
|---------------|-----------------------------------------------------------------------------------|
| Page          | `samples/Blazor.Toolkit.Samples.Client/Pages/Components/Navigations/Toolbar.razor`   |
| Demos folder  | `samples/Blazor.Toolkit.Samples.Client/Pages/Demos/Navigations/Toolbar/`             |
| Route         | `@page "/navigations/toolbar"`                                                    |
| Base class    | `TocPublishingComponentBase`                                                      |

### TOC and CodePreview mapping (must be used exactly)

| TOC id         | Heading                          | Demo Component      | SourceFile                                                      |
|----------------|----------------------------------|---------------------|-----------------------------------------------------------------|
| —              | Blazor Toolkit Toolbar Component | `DefaultDemo`       | `/Pages/Demos/Navigations/Toolbar/DefaultDemo.razor`               |
| `overflow`     | Overflow & Priority              | `OverflowDemo`      | `/Pages/Demos/Navigations/Toolbar/OverflowDemo.razor`              |
| `items`        | Item Types                       | `ItemsDemo`         | `/Pages/Demos/Navigations/Toolbar/ItemsDemo.razor`                 |
| `templates`    | Templates                        | `TemplatesDemo`     | `/Pages/Demos/Navigations/Toolbar/TemplatesDemo.razor`             |
| `editor`       | Editor                           | `EditorDemo`        | `/Pages/Demos/Navigations/Toolbar/EditorDemo.razor`                |
| `orientation`  | Orientation                      | `OrientationDemo`   | `/Pages/Demos/Navigations/Toolbar/OrientationDemo.razor`           |

Catalog rules:

- Register each demo exactly once (`Description` + `CodePreview`).
- Use the exact TOC headings and ids above.
- First section has **no** TOC id (component introduction).
- `TocItems` matches this table only; remove obsolete entries.

---

## 2. Crispy demo summaries

| Demo | Crispy description |
|------|--------------------|
| **Default** | Clean horizontal command bar with grouped actions, separators, and a spacer. Instant click feedback—baseline UX every app needs. |
| **Overflow & Priority** | Switch Popup / Scrollable / MultiRow / Extended, resize the bar, and watch priority decide what stays visible. |
| **Item Types** | Buttons, toggles, split actions, dropdowns, groups, separators, and spacers—pressed states and menus included. |
| **Templates** | Customize individual toolbar items with templates and use declarative groups to organize a live filter bar. |
| **Editor** | A real-world editor command strip above a simple document surface, with formatting toggles and adaptive overflow. |
| **Orientation** | Compare the same commands in a horizontal header toolbar and a vertical side rail. |

---

## 3. Detailed Demo Specifications

### 3.1 DefaultDemo.razor

**Purpose**  
First impression: denser, cleaner, more intentional than a minimal “few buttons” overview.

**Real-world scenario**  
App command bar: New, Edit, Delete, Refresh, Export.

**Visual design**
- Max-width ≈ 720–800 px; alignment consistent with other demos.
- Icon + text; `ToolbarSeparator` + `ToolbarSpacer` (primary left, utilities right).
- Optional faint zone labels (“Document” / “View”) to teach grouping.
- Spacing/density competitive with Fluent Command Bar and DevExpress overview.

**Interaction**  
Clicks → toast or equivalent. No overflow required at default width.

**Main APIs**  
`SfToolbar`, items, `ToolbarSeparator`, `ToolbarSpacer`, click handlers.

**Catalog Description (use exactly)**

```razor
<Description>
    <Header>
        <h1 id="blazor-toolkit-toolbar-component">Blazor Toolkit Toolbar Component</h1>
    </Header>
    <Content>
        Clean horizontal command bar with grouped actions, separators, and a spacer. Instant click feedback—baseline UX every app needs.
    </Content>
</Description>
```

---

### 3.2 OverflowDemo.razor *(required overflow sample)*

**Purpose**  
Beat competitor adaptivity demos by teaching **four overflow strategies + priority** in one interactive surface.

**Real-world scenario**  
Responsive command bar: Save / Undo stay visible longer; secondary actions yield first.

**Visual design**
- **Mode switcher:** Popup | Scrollable | MultiRow | Extended.
- **Resizable demo frame** (drag handle on the toolbar host).
- 8–12 items; mixed `Priority` and `Overflow` (`Show` / `None` / `Hide`).
- Priority chips (“Stays visible”, “Overflows first”).
- **Live caption** per mode:
  - **Popup:** Items move into More.
  - **Scrollable:** Bar scrolls; items stay in-line.
  - **MultiRow:** Items wrap to another row.
  - **Extended:** Extra rows collapse until expanded.
- Default mode: **Popup**.

**Interaction**
- Switch mode → behavior changes immediately.
- Resize → priority rules stay obvious (especially Popup).
- Popup: More opens; select / Escape / outside closes.

**Main APIs**  
Phase 1: `OverflowMode.Popup`/`Scrollable`, `Priority`, `Overflow`; Phase 2: `MultiRow`/`Extended`.

**Catalog Description (use exactly)**

```razor
<Description>
    <Header>
        <h2 id="overflow">Overflow & Priority</h2>
    </Header>
    <Content>
        Switch Popup / Scrollable / MultiRow / Extended, resize the bar, and watch priority decide what stays visible.
    </Content>
</Description>
```

---

### 3.3 ItemsDemo.razor

**Purpose**  
Full built-in item model so users are not pushed to templates for common cases (advantage vs template-heavy stacks).

**Real-world scenario**  
Formatting / insert strip with toggles, split paste, insert menu; optional “selection” checkbox disables Delete.

**Visual design**
- Button, Toggle (`aria-pressed` visible), Separator, Spacer, Group, SplitButton, DropDown/MenuButton.
- Clear groups; no clutter.

**Interaction**  
Toggle state; split primary vs menu; dropdown; disabled item when selection is off.

**Main APIs**  
Phase 1: Button, Toggle, Separator, Spacer, Group, `Selected`, `Enabled`; Phase 2: Split/DropDown/Menu and radio/check groups.

**Catalog Description (use exactly)**

```razor
<Description>
    <Header>
        <h2 id="items">Item Types</h2>
    </Header>
    <Content>
        Buttons, toggles, split actions, dropdowns, groups, separators, and spacers—pressed states and menus included.
    </Content>
</Description>
```

---

### 3.4 TemplatesDemo.razor *(per-item templates + declarative groups)*

**Purpose**  
Showcase the documented per-item template API and ordinary declarative groups in a live-filter command bar. The API does not include group-level templates.

**Real-world scenario**  
Files or tasks workspace: declarative groups containing per-item templated content (search and result chip), filtering a list under the bar.

**Visual design — must include both**

1. **Declarative group**
   - Use `ToolbarGroup.ChildContent` to organize a “Search” or “Filters” cluster.
   - Do not claim or emulate a public group-template API.

2. **Item templates**  
   - **Pill search field** (icon inside, clear (×) when text exists) hosted in a supported per-item template.
   - **Live result chip** (`12 results` → updates while typing).  
   - Optional second templated item (e.g. status filter chip).

3. **Surrounding product UI**  
   - Left: normal commands (New, Upload, Refresh) so the bar still reads as a toolbar.  
   - Spacer before the templated cluster.  
   - **List panel under the bar** of fake files/tasks; filters on type; empty state when no match.  
   - Hint: *Try typing to filter — the templated item and filtered list update together.*

**Interaction**
- Type → list filters; chip updates.  
- Clear → reset.  
- Commands → light feedback.  
- Resize → templated items participate in overflow like other items.

**Main APIs**  
`ToolbarGroup.ChildContent`, `ToolbarItem.Template`, `ToolbarTemplateItem.ChildContent`; Phase 2 data-bound `ItemTemplate` only if that phase is implemented.

**Catalog Description (use exactly)**

```razor
<Description>
    <Header>
        <h2 id="templates">Templates</h2>
    </Header>
    <Content>
        Customize individual toolbar items with templates and use declarative groups to organize a live filter bar.
    </Content>
</Description>
```

---

### 3.5 EditorDemo.razor *(editor only — no grid)*

**Purpose**  
Highest emotional “product” demo—editor chrome competitors often underplay on the Toolbar page.

**Real-world scenario**  
Rich-text style toolbar above a simple document surface (no full editor engine).

**Visual design**
- One toolbar only (no grid sample).
- Groups: clipboard, Bold/Italic/Underline toggles, alignment, insert.
- Fluent/Office density; overflows when narrow.
- Document surface under the bar (padded text block).
- Optional display-only shortcut tooltips (Ctrl+B, etc.).

**Interaction**  
Toggles keep state; clicks give feedback; overflow on resize.

**Main APIs**  
Groups, toggles, separators, spacers, overflow.

**Catalog Description (use exactly)**

```razor
<Description>
    <Header>
        <h2 id="editor">Editor</h2>
    </Header>
    <Content>
        A real-world editor command strip above a simple document surface, with formatting toggles and adaptive overflow.
    </Content>
</Description>
```

---

### 3.6 OrientationDemo.razor *(no RTL toggle; no keyboard/a11y teaching panel)*

**Purpose**  
Orientation as **app chrome**: header bar vs side rail—more memorable than a bare vertical control.

**Real-world scenario**  
Workspace shell: same actions as top commands or left icon rail.

**Visual design**
- App shell frame (border/shadow, content region).
- Switcher: **Header** | **Side rail** (drives `Orientation`).
- Header: horizontal bar above content.
- Side rail: vertical icon-only items with `Text` retained as the accessible name and `Tooltip` as supplemental help; optional selected item.
- Same command set mapped across layouts.
- Content panel reacts lightly to clicks (title/toast).
- Hint: *Switch Header / Side rail — same commands, different placement.*

**Do not include**  
RTL toggle; keyboard cheat-sheets; accessibility design callout panels.

**Main APIs**  
`Orientation` (`Horizontal` | `Vertical`).

**Catalog Description (use exactly)**

```razor
<Description>
    <Header>
        <h2 id="orientation">Orientation</h2>
    </Header>
    <Content>
        Compare the same commands in a horizontal header toolbar and a vertical side rail.
    </Content>
</Description>
```

---

## 4. Competitive bar (what “best” means here)

| vs competitor strength | How this set answers |
|------------------------|----------------------|
| DevExpress adaptivity + priority | **Overflow demo** with four modes + priority + resizable frame |
| DevExpress templates API demo | **Templates** with per-item templates, declarative groups, and live filter UX |
| DevExpress checked/split/dropdown | **Item Types** dedicated surface |
| Fluent/Office command chrome | **Editor** on a document surface |
| Vertical / rail patterns | **Orientation** header vs side rail shell |
| Baseline overview | **Default** with real grouping and spacer |

Visual quality must match commercial demos: consistent icons, spacing, focus states, Light/Dark/High Contrast.

---

## 5. Global Implementation Rules

1. **Icons** — Toolkit/Fluent-style; icon-only items keep their `Text` as the accessible name; `Tooltip` is supplemental help.
2. **Components** — Public Toolkit APIs only; no commercial Syncfusion.Blazor packages.  
3. **Overflow** — Demo 2 covers Popup/Scrollable in Phase 1 and MultiRow/Extended in Phase 2.
4. **Templates** — Demo 4 uses per-item templates and declarative groups only; no group-template API is assumed.
5. **Editor** — Editor only; no grid toolbar.  
6. **Orientation** — No RTL control; no keyboard/a11y teaching UI.  
7. **Styling** — Shared CSS in `Toolbar.razor`; demo-local CSS in each file; CSS isolation respected.  
8. **Test hooks** — `data-testid`s from `TEST-MATRIX.md`.  
9. **Quality** — Equal or better polish than DevExpress / Telerik toolbar demos on first paint and interaction.

---

## 6. Demo File Implementation Plan

| Final demo file | Responsibility | Legacy names to replace |
|-----------------|----------------|-------------------------|
| `DefaultDemo.razor` | Default grouped command bar | `DefaultDemo.razor` |
| `OverflowDemo.razor` | Four modes + priority + resizable frame | `OverflowDemo`, `PriorityDemo`, `AdaptiveDemo` |
| `ItemsDemo.razor` | Full item-type showcase | `ItemsDemo`, `CommandsDemo` |
| `TemplatesDemo.razor` | Per-item templates + declarative group + live filter bar | `TemplatesDemo` |
| `EditorDemo.razor` | Editor-only + document surface | `UseCasesDemo`, `EditorDemo`, `GridToolbarDemo` |
| `OrientationDemo.razor` | Header vs side rail shell | `OrientationDemo`, `AccessibilityDemo` |

### Completion checklist

1. All six files exist at the expected paths.  
2. `Toolbar.razor` registers exactly six previews in catalog order.  
3. TOC ids, headings, and `SourceFile` paths match section 1.  
4. Descriptions match section 3 exactly.  
5. No out-of-scope file changes.  
6. `/navigations/toolbar` works in Server, WASM, and Auto.  
7. Light / Dark / High Contrast verified.  
8. Overflow: all four modes + priority on resize.  
9. Templates: per-item template + declarative group are visible; live search/list works.
10. Editor only (no grid).  
11. Orientation: Header / Side rail only—no RTL, no a11y/keyboard teaching UI.

---

## 7. Final Acceptance Criteria

- Exactly **six** demos; each professional and intentional.  
- **Default** is a complete baseline (groups, separator, spacer).  
- **Overflow & Priority** clearly demonstrates Popup, Scrollable, MultiRow, and Extended.  
- **Item Types** covers Button, Toggle, Separator, Spacer, Group, Split, DropDown/Menu.  
- **Templates** demonstrates supported per-item templates and declarative groups, plus pill search, result chip, and filterable list.
- **Editor** is a single editor strip on a document surface.  
- **Orientation** shows header vs side rail with the same commands.  
- No visual noise, style leaks, or broken mobile widths.  
- Required `data-testid` hooks present.  
- Overall impression meets or exceeds competing toolbar demo pages.

---

## 8. Showcase polish (recommended)

| Polish | Where |
|--------|--------|
| Resizable frame + mode captions + priority chips | `OverflowDemo` |
| Declarative group + per-item template + pill search + chip + list | `TemplatesDemo` |
| Document surface under toolbar | `EditorDemo` |
| Selection → disabled Delete | `ItemsDemo` |
| App shell + Header / Side rail switcher | `OrientationDemo` |

**Out of scope for this set:** grid toolbar; RTL toggle in Orientation; keyboard/a11y instruction panels; separate catalog entry per overflow mode; ribbon/personalization.

---

**Document Owner**: Toolkit Team  
**Status**: Final — ready for sample implementation  
**Related Documents**: `PRD.md`, `SPEC.md`, `TEST-MATRIX.md`, `EVIDENCE.md`
