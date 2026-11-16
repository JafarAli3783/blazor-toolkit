# SfList – Behavior Specification
## Syncfusion Blazor Toolkit

**Version:** 1.1 (Proposal)  
**Status:** Proposed behavior. Not implementation-ready and not implemented.  
**Authority:** `PRD.md` owns scope. `API.md` owns public members. This file owns behavior and must not introduce a parameter that `API.md` does not name.  
**Last updated:** 2026-10-28

---

## 1. Summary

`SfList<TItem>` is a reusable list foundation for passive, navigation, selectable, checkable, grouped, nested, and virtualized lists.

Passive and navigation lists must not receive `role="listbox"`. Listbox semantics apply only when selection is enabled.

Public types, in `Syncfusion.Blazor.Toolkit`: `SfList<TItem>`, `SfListItem`, `SfListGroup`, `SfListHeader`, `SfListFooter`, `SfListSubheader`, and `SfListDivider`. Member lists are in `API.md`.

Intended source, when implementation starts: `src/Components/Lists/`. That folder does not exist yet.

---

## 2. Scope

### In v1

- Informational, action, and navigation lists
- Single-select and multi-select lists
- Checkable lists, independent of selection
- Templated and grouped lists
- Nested expandable lists
- Virtualized large-data lists
- Icons, avatars, supporting text, and leading or trailing slots
- Disabled items
- Header, footer, subheader, divider, empty, loading, and error regions

### Out of v1

Sorting, filtering, searching, drag-and-drop, component-owned persistence, and horizontal layout. See PRD section 8 and section 22. Consumers may sort or reorder their own collection before binding it.

---

## 3. Semantic modes

| Mode | Root role | Item role | Selection | Keyboard |
|---|---|---|---|---|
| Passive | `list` | `listitem` | None | Natural tab order |
| Navigation | `list` | link or `listitem` | None | Natural tab order |
| Single | `listbox` | `option` | One | Proposed roving tabindex |
| Multiple | `listbox` | `option` | Many | Proposed roving tabindex |
| Checkable | list or listbox, by selection mode | same, plus checkbox | Independent of checks | Combined |

`SelectionMode.None` uses `role="list"`. `Single` and `Multiple` use `role="listbox"` and `aria-multiselectable="true"` only for multiple. Checks add checkbox semantics. They do not replace list or option roles.

---

## 4. Rendering

- Declarative `SfListItem` children and data-bound `DataSource` may be used. Mixed content has a deterministic order: declarative children, then data items.
- Every item uses a stable `@key` from the identity rules in `API.md`.
- Null or empty data with no declarative children shows `EmptyTemplate`, or a localized built-in empty state when that template is absent.
- Duplicate keys use last-wins and emit a Development warning.
- Unknown field names fall back and emit a Development warning. They do not throw in production.

Field-name parameters and typed selectors are separate. When both are set, the selector wins. The mapping members are named only in `API.md`.

---

## 5. Loading and error

| Flags | Visible content |
|---|---|
| `HasError` true | `ErrorTemplate` wins, even if `IsLoading` is also true |
| `IsLoading` true and `HasError` false | `LoadingTemplate`; items are not interactive |
| Both false, no items | Empty state |
| Both false, items present | Items |

Loading and error regions use a polite live region. Loading suppresses activation, selection, check, and expand.

---

## 6. Selection

Modes and event order are defined in `API.md`.

- Pointer selection follows the current mode.
- Keyboard selection uses Space or Enter according to the mode table below.
- Multiple mode supports Shift range over enabled items, Ctrl or Cmd toggle, and Ctrl+A for enabled items.
- Disabled items are never selected. An incoming selection that includes a disabled item drops that item and emits a Development warning.
- Selection survives a data refresh when identity matches.
- Off-screen virtualized items keep their selection.
- `SelectedValue` is ignored when mode is `None`.
- A controlled bind is authoritative after each render. An equal external update does not raise selection events.

---

## 7. Checks and nested expansion

Checks are independent of selection. A consumer that wants both must bind both.

Expandable items expose `aria-expanded`. `ExpandAsync` and `CollapseAsync` use the cancellable expansion pipeline and do nothing when there is no nested list.

Nested interactive content, including buttons and links, stays in the tab order. It must not become a keyboard trap. Arrow keys move the list active item. Tab moves into and out of nested controls.

---

## 8. Focus

**Proposed, not finalized:** selectable lists use roving `tabindex`. The active item has `tabindex="0"`. Other options have `tabindex="-1"`.

`aria-activedescendant` is not the proposed model. Nested interactive content must remain keyboard-reachable, and an active-descendant container would compete with those controls.

Passive and navigation lists use natural tab order.

Finalize the roving-tabindex choice during implementation review before the public API is treated as frozen.

Focus must be visible in the default theme, dark theme, and Forced Colors. Focus is restored after a data change when the previous active identity still exists.

---

## 9. Keyboard

| Key | Passive or navigation | Single | Multiple |
|---|---|---|---|
| Tab / Shift+Tab | Natural, including nested controls | Enter or leave the list; nested controls stay reachable | Same as single |
| Arrow Up / Down | No list action | Move active item and select it | Move active item |
| Home / End | No list action | First or last enabled item | First or last enabled item |
| Page Up / Down | No list action | Move by a page | Move by a page |
| Enter / Space | Activate an action or link | Select | Toggle selection |
| Shift+Arrow | No list action | No list action | Extend range over enabled items |
| Ctrl+A | No list action | No list action | Select all enabled items |
| Escape | No list action | Clear selection | Clear selection |
| Type-ahead | No list action | Move to a matching enabled item | Move to a matching enabled item |
| Arrow Left / Right | Expand or collapse when nested; reversed in RTL | Same | Same |

RTL reverses directional keys. There is no Alt+Arrow reorder and no drag-handle key.

---

## 10. Layout

v1 is vertical only. Horizontal layout is a future enhancement in the PRD.

Density is Comfortable by default and Dense when requested. Touch targets are at least 44 by 44 CSS pixels. The list is usable at 320 CSS pixels and at 400% zoom. Nested scroll must not trap keyboard focus.

Public CSS classes and variables are listed in `API.md`. There is no drag-handle class.

---

## 11. Virtualization

**Proposed:** use Blazor built-in `Virtualize` when `EnableVirtualization` is true. A custom virtualizer requires a later decision.

`EnableVirtualization` is one-way for the component lifetime. Off-screen selection is retained. `ScrollIntoViewAsync` realizes the target item when needed. `@key` remains mandatory.

Proposed, unmeasured targets:

- 100 simple items: median initial render under 50 ms after warm-up
- 1 000 virtualized items: scroll remains interactive
- A selection change does not re-render the entire list

These numbers are targets, not results.

---

## 12. SSR, hydration, and script

Static SSR renders valid list or listbox markup. Identifiers must not change between prerender and hydration.

No JavaScript interop is required for the v1 public surface. If an implementation later needs script for scroll measurement, that script must be disposed and must not add a public `[JSInvokable]` member without an API review.

A passive list remains readable when script is disabled. Selection requires interactivity.

---

## 13. Security

Templates are encoded by default. `AdditionalAttributes` follows Blazor attribute merging. There is no `HtmlAttributes` parameter.

`Href` is the consumer's responsibility. A `javascript:` URL emits a Development warning and is not executed by the component.

---

## 14. Disposal

`DisposeAsync` is idempotent. It unregisters items, clears internal maps, and cancels pending internal work. It does not throw on a second call.

---

## 15. Accessibility expectations

Document expected announcements for NVDA, Narrator, and JAWS:

- List entry, label, and type
- Item text and position
- Selected, checked, disabled, and expanded
- Loading, empty, and error
- Dynamic insert and remove

Assistive-technology differences are recorded as evidence, not as a pass, until transcripts exist. Axe does not prove those announcements.

---

## 16. Definition of done

This specification is not done. Implementation is done only when all of the following exist:

- In-scope behavior implemented
- Public API reviewed and XML-documented from `API.md`
- Zero warnings
- Retained matrix tests passing
- Accessibility, visual, RTL, Forced Colors, and localization evidence collected
- Samples executable
- No release-blocking defect

Do not mark any of those items passed in this document.

---

## 17. Open checks before API freeze

1. Confirm the base class against current `src/Base` during implementation. Do not invent a base type here.
2. Accept or replace the proposed roving-tabindex model during implementation review.

Sorting, drag-and-drop, persistence, horizontal layout, and the virtualization mechanism are not open product questions. The first four are out of v1. Virtualization is proposed as Blazor `Virtualize`.
