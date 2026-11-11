# Spec.md — SfChip / SfChipSet
## Syncfusion Blazor Toolkit Chips Component
**Version:** 1.0-proposed  
**Status:** Authoritative implementation specification  
**Depends on:** Phase B locked decisions; repository conventions discovered under `<a href="https://github.com/syncfusion/blazor-toolkit`" target="_blank" rel="noopener noreferrer" title="https://github.com/syncfusion/blazor-toolkit`" class="fai-ChatInputEntity__text ___6erqso0 fyind8e f1tx3yz7 f1deo86v f1eh06m1 f1iescvh">https://github.com/syncfusion/blazor-toolkit`</a>  
**Namespace:** `Syncfusion.Blazor.Toolkit`  
**Source root:** `src/Components/Buttons/Chips/`

Folder placement does not change the namespace. `ChipSelectionMode` is not ButtonGroup `SelectionMode`. Default rendering uses native `button`, `a`, or `span` and does not embed `SfButton`.

---

## 1. Executive summary

Chips are compact, semantic tokens used for filters, choices, actions, navigation, status, suggestions, and removable input values. The Syncfusion Blazor Toolkit Chips component provides:

- **`SfChip`** — standalone declarative chip  
- **`SfChipSet&lt;TItem&gt;`** — data-bound or multi-chip container with selection, removal orchestration, overflow, and empty/loading/error states  

Design principles:

1. **Semantics follow interaction** — passive chips are not buttons, options, or listbox items.  
2. **Native elements first** — prefer `button`, `a`, and `span` over abstract ARIA roles.  
3. **No heavyweight Toolkit component per chip** — native controls and templates only.  
4. **Stable identity** — selection and removal key off `ItemKey` (or equivalent).  
5. **Focus restoration after removal** is defined and testable.  
6. **Token typing is not part of base `SfChip` / core `SfChipSet` API** — host composition or a future specialized field owns the text input.  
7. **Blazor-native** — JavaScript only for overflow measurement or focus helpers that cannot be done reliably in pure Blazor; always disposed.  
8. **Warning-free** — nullable, analyzers, XML docs, and build must stay clean.

This specification is the implementation contract for toolkit Chip. API.md, API-xml.md, TEST-MATRIX.md, sample-preparer.md, and Evidence.md must remain consistent with it.

Cross-platform Chip IDs (`CHIP-*`) live in the spec-kit Chip bundle. They are not restated here. `TRACEABILITY.md` maps those parents onto this contract. The commercial Blazor override does not apply except where `TRACEABILITY.md` says a `CHIP-BLZ-*` delta applies. Do not add commercial `Created` / `Destroyed` events. Selected values are keys/values as defined below, not commercial chip instances. Interactive modes use native `button`, `a`, or `span` per §6, not a forced `listbox` / `option` role.

---

## 2. Repository analysis (implementation obligation)

Before coding, implementers **must** inspect the Toolkit repository and align with:

| Area | Align to |
|------|----------|
| Project layout | `src/Components/Buttons/Chips/` beside Button and ButtonGroup. Card is the partial-class and test peer. Lists and Accordions are not in this repository. |
| Naming | `Sf*` components, `Syncfusion.Blazor.Toolkit` namespace, `e-*` public CSS where that is the Toolkit convention |
| Parameters | `CssClass`, `Id`, `HtmlAttributes` / `CaptureUnmatchedValues`, `EnableRtl`, `AriaLabel` patterns from peer components |
| Styling | Theme tokens (`--color-sf-*` or current Toolkit tokens), CSS isolation, `::deep` only when required |
| Tests | bUnit project layout, Playwright fixtures, axe registration, visual snapshot folders |
| Samples | Catalog + `*Demo.razor` + TOC/`CodePreview` pattern used by Card/List/Accordion |
| JS interop | Existing module registration and disposal idioms |
| Form integration | Existing `EditContext` / `IFieldIdentifier` patterns if present |

If inspection conflicts with a name in this Spec (e.g. child component pattern), **behavior stays**; **names adjust** to repository convention and API.md is updated in the same change.

---

## 3. Component-reuse decision matrix

### 3.1 Decision summary

| Candidate | Direct reuse inside each chip | Composition by app | Shared internal primitive | Prohibited embed | Final decision |
|-----------|------------------------------|--------------------|---------------------------|------------------|----------------|
| Button / icon-button | No | Optional in templates | Shared CSS OK | Embedding `SfButton` per chip | **Native `&lt;button&gt;`** |
| Icon component | No | Yes | CSS/`IconCss` | Per-chip icon component | **Class or template** |
| Avatar component | No | Yes | — | Per-chip avatar component | **`ImageUrl` / template** |
| Tooltip | No | Yes | — | Required Tooltip dependency | **Optional `title` / consumer Tooltip** |
| TextBox / Autocomplete / Input | No | **Yes (token samples)** | — | Token field inside `SfChip` | **Host composition** |
| Popup / Menu | No | Future | — | v1 overflow menu | **In-flow collapse only** |
| Badge | No | Yes | — | Per-chip Badge | **Template markup** |
| Spinner | No | Yes | — | Required Spinner | **`LoadingTemplate`** |
| Form / validation infra | Set-level | — | EditContext integration | — | **Integrate at ChipSet when selection is a value** |
| Keyboard / focus utils | — | — | **Prefer Toolkit shared helpers** | — | **Reuse if exists; else internal** |
| Localization / RTL / ID / theme / CSS utils | — | — | **Required** | — | **Must reuse Toolkit patterns** |
| JS interop helpers | Overflow/focus only | — | Toolkit JS patterns | JS for basic click/select | **Minimal, disposed** |
| Virtualization | No default | App-level | — | Virtualize wrapping line as default | **Document thresholds; do not default virtualize** |

### 3.2 Per-candidate detail

#### Button / icon-button

| Field | Content |
|-------|---------|
| Use case | Action/Assist/Filter/Choice activation; remove control |
| Direct reuse | **Not recommended** |
| Composition | App may place Toolkit buttons in templates sparingly |
| Shared primitives | Shared focus-ring / density CSS variables |
| Prohibited | `SfButton` (or equivalent) instance **per chip** in default rendering |
| Architecture | N button components × M chips destroys performance and complicates focus |
| Accessibility | Native `&lt;button type="button"&gt;` provides name, role, keyboard |
| Rendering | Light DOM; one element |
| CSS isolation | Chip owns remove-button classes under chip root |
| Events | `click` stopPropagation on remove so chip activation does not double-fire |
| Focus | Remove is separately focusable when `Removable` |
| Performance | Critical — native only |
| Coupling | None to Button package |
| Circular deps | None |
| API leakage | None |
| SSR | Native button works without interactivity for non-interactive presentation; handlers need interactivity |
| Testing | Standard bUnit/Playwright on `button` |
| Use when | Never as default inner implementation |
| Must not use when | Default chip chrome |
| Fallback | Native button |
| **Final** | **Native `&lt;button type="button"&gt;` for interactive chips and remove** |

#### Icon / Avatar / Badge / Spinner / Tooltip

| Field | Content |
|-------|---------|
| Final | **No hard dependency.** Leading visuals via `IconCss`, `ImageUrl`+`Alt`, or templates. Loading via `LoadingTemplate`. Tooltips optional by consumer. |

#### TextBox / Autocomplete / Input

| Field | Content |
|-------|---------|
| Use case | Creating input tokens |
| Final | **Composition only.** Base `SfChip` / core `SfChipSet` do **not** own a text field. Samples show `&lt;input&gt;` or Toolkit TextBox **beside** ChipSet. A future `SfInputChipSet` may wrap both; out of v1 core. |
| Justification | Keeps API coherent; avoids IME/form conflicts inside every set |

#### Popup / Menu (overflow)

| Field | Content |
|-------|---------|
| Final | **v1: no Popup/Menu.** `ChipOverflowMode.Collapse` uses in-flow “+N” control and expanded inline chips. |
| Fallback | Wrap or Scroll modes |

#### Form / EditContext

| Field | Content |
|-------|---------|
| Final | **`SfChipSet` may integrate** when `SelectionMode` is Single/Multiple so selected values participate in form validation. Follow existing Toolkit field registration patterns. |

#### Keyboard / focus utilities, L10n, RTL, ID generation, theme tokens

| Field | Content |
|-------|---------|
| Final | **Must reuse** repository shared infrastructure where it exists. |

#### Virtualization

| Field | Content |
|-------|---------|
| Final | **Not default.** Wrapping chip layouts are poor virtualization candidates. For hundreds+ chips, recommend Collapse/Scroll, filtering, or paging at app level. |

---

## 4. Component scope

### 4.1 In scope (v1)

- Standalone `SfChip` and `SfChipSet&lt;TItem&gt;`  
- Semantic modes: Informational, Status, Action, Assist, Filter, Choice, Input, Suggestion, Navigation, Custom  
- Selection: None, Single, Multiple  
- Removable chips with cancelable events and focus restore  
- Data binding, templates, disabled/read-only  
- Variants: Filled, Outlined; Sizes: Small, Medium, Large; Shapes: Rounded, Pill  
- Overflow: Wrap (default), Scroll, Collapse  
- Empty / Loading / Error on set  
- RTL, localization hooks, forced-colors, reduced-motion, dark theme tokens  
- Programmatic select/focus/remove  
- EditContext integration for selectable sets  
- SSR-safe declarative markup  

### 4.2 Out of scope (v1)

- Built-in token text input as core API  
- Drag-and-drop reorder  
- Overflow popup/menu  
- Default virtualization  
- Elevated variant (unless free via existing tokens and added later without API break)  
- Select-all (unless added with explicit Spec amendment)  
- Embedding other Toolkit controls as required chrome  

---

## 5. Architecture and hierarchy

```
SfChipSet&lt;TItem&gt;
  ├── Parameters: data, selection, overflow, state templates
  ├── Children: optional declarative chips OR DataSource projection
  ├── Services: selection store, focus coordinator, removal pipeline
  └── Render: chipset root → chip roots → leading / text / trailing / remove

SfChip
  └── Single chip root (same visual/semantic chip renderer as set items)
```

### 5.1 Responsibilities

| Component | Responsibility |
|-----------|----------------|
| `SfChipSet&lt;TItem&gt;` | Item enumeration, keys, selection, removal orchestration, overflow, set-level ARIA label, empty/loading/error, form field value |
| `SfChip` | One chip’s type, content, disabled/read-only/removable, local click/remove when standalone |
| Internal chip renderer | Shared markup path for set items and standalone to avoid drift |

### 5.2 Cascading

- Set cascades **selection mode**, **read-only**, **disabled**, **removable default**, **size/variant/shape**, **register/unregister** callbacks to children when declarative children exist.  
- Child must not override set `SelectionMode` semantics in conflicting ways; child `Selected` is meaningful primarily for Filter/Choice visuals when controlled by set.

### 5.3 Registration

Declarative children register with parent set on init and unregister on dispose. DataSource path does not use child registration; it projects items each render with `@key`.

---

## 6. Semantic modes (normative)

### 6.1 Mode table

| ChipType | Element | Role strategy | Focusable | Selection participation | Activation | Remove default |
|----------|---------|---------------|-----------|---------------------------|------------|----------------|
| Informational | `span` | No interactive role | No (unless only remove is focusable) | No | None | Rare; if removable, only remove is the control |
| Status | `span` | Text/status; not a control | No | No | None | No |
| Action | `button type="button"` | Native button | Yes | No | Click/Enter/Space | Optional |
| Assist | `button type="button"` | Native button | Yes | No | Click/Enter/Space | Optional |
| Filter | `button type="button"` | `aria-pressed` reflects on/off | Yes | Yes (typically multi) | Toggle pressed | Optional |
| Choice | `button type="button"` | Exclusive in Choice sets; `aria-pressed` or checked pattern per set | Yes | Yes (single) | Exclusive select | Optional |
| Input | `span` (token) + remove `button` | Token container; remove is button | Token optionally in tab order per set policy; remove focusable | Via set values | Remove / Delete | **Yes** typical |
| Suggestion | `button type="button"` | Native button | Yes | No default | Notify host | No default |
| Navigation | `a` | Native link; **requires** `Href` | Yes | No | Navigate | No default |
| Custom | Author | Author supplies accessible name and interaction | Author | Opt-in | Author | Opt-in |

### 6.2 Prohibited

- `role="listbox"` on ChipSet by default  
- `role="option"` on chips unless a **future** documented listbox pattern is explicitly opted in (not v1 default)  
- `role="button"` on Informational/Status  
- Navigation chip without `Href` — treat as Action or invalid config (dev guidance: require Href for Navigation)

### 6.3 Accessible name

Priority: `AriaLabel` → visible text content → `Text` parameter → (for remove) format **Remove {name}** using localized resource with chip’s accessible name substituted.

---

## 7. Rendering model

### 7.1 Chip root structure (logical)

```
[chip root]
  [leading optional: icon / image / template]
  [content: text or ChildContent / template]
  [trailing optional: badge / template]
  [remove button optional]
```

### 7.2 Set root structure

```
[chipset root, aria-label from AriaLabel]
  [empty | loading | error template exclusive by precedence]
  OR
  [chip roots…]
  [overflow +N control when Collapse and hidden count &gt; 0]
```

### 7.3 State template precedence (set)

1. **HasError** → `ErrorTemplate` only  
2. Else **IsLoading** → `LoadingTemplate` only  
3. Else no items → `EmptyTemplate` if provided  
4. Else chips  

Matches Toolkit List/Accordion precedence style.

### 7.4 Keys

- Data-bound: `@key="resolvedKey"` where `resolvedKey = ItemKey(item)` or field map.  
- Missing key function for complex types: implementation must use a documented fallback only if unavoidable; **Spec requirement:** public API encourages/requires `ItemKey` for non-primitive items in selectable/removable sets.

### 7.5 SSR / hydration

- Markup must be valid without interactive handlers attached.  
- Selection and remove handlers attach in interactive render modes.  
- No id/role mismatch on hydrate.  
- Overflow collapse measurement may no-op or show all chips until interactive measurement runs; must not throw.

---

## 8. Data-binding model

### 8.1 Sources

- `DataSource` as `IEnumerable&lt;TItem&gt;?`  
- Declarative `SfChip` / child items when no DataSource  
- Dynamic updates: re-render; selection preserved for keys still present  

### 8.2 Field mapping

Support either individual `Func`/`string` field parameters or a `ChipFields` object:

- Text, Value, Disabled, Removable, IconCss, ImageUrl, CssClass, Href (Url)

### 8.3 Primitives

`TItem` as `string` / value types: text = `ToString()`, value = item, key = item.

### 8.4 Null / empty

- Null DataSource → empty  
- Empty sequence → EmptyTemplate if set  

### 8.5 Duplicates

- **Keys:** must be unique among rendered chips. Duplicate keys: debug assert/log; render first occurrence only or last — **implementation lock:** skip subsequent duplicates and ignore them for selection.  

---

## 9. Selection model

| SelectionChanging exposes current vs proposed selected values (see API.md / API-xml.md).

### 9.1 Modes

| ChipSelectionMode | Behavior |
|-------------------|----------|
| None | No selection state; Filter/Choice should not be used without selection mode |
| Single | At most one selected; `SelectedValue`; `AllowEmpty` default true |
| Multiple | `SelectedValues` set |

### 9.2 Algorithm: user toggle (Filter / Multiple)

```
onActivate(chip):
  if set.Disabled or set.ReadOnly or chip.Disabled: return
  raise SelectionChanging(args)
  if args.Cancel: return
  update SelectedValues
  raise SelectionChanged
  sync EditContext if registered
```

### 9.3 Algorithm: Choice / Single

```
onActivate(chip):
  if cannot interact: return
  if already selected and AllowEmpty: deselect
  else select only this key/value
  Changing → update → Changed
```

### 9.4 Keyboard (interactive set)

Default:

- **Tab** enters set (one tab stop) **or** tabs through chips when policy is discrete tab stops — **lock for v1 interactive sets:** **roving tabindex** on chip roots when SelectionMode ≠ None or when any chip is Action/Filter/Choice/Suggestion; passive-only sets use no roving.  
- **ArrowLeft/Right** (RTL-aware): move focus  
- **Home/End:** first/last focusable chip  
- **Space/Enter:** activate/toggle per type  
- **Delete/Backspace:** remove if focused chip removable and not read-only  

Arrows **do not** change selection unless Space/Enter (focus ≠ selection).

### 9.5 Programmatic

`SelectAsync`, `ClearSelectionAsync` honor Disabled/ReadOnly rules for user parity unless `force` is not offered — **no force flag in v1**; programmatic still blocked when set ReadOnly (document exception: initial parameter set allowed).

---

## 10. Removal model

### 10.1 Algorithm

```
requestRemove(chip, reason):
  if not chip.Removable or set/chip Disabled or ReadOnly: return
  args = RemovingEventArgs(chip, reason)
  await Removing.InvokeAsync(args)
  if args.Cancel: return
  remove from DataSource binding or invoke host callback pattern
  // For DataSource owned by parent, raise event so parent mutates collection
  await Removed.InvokeAsync(...)
  restoreFocus(chip)
```

Two-way collection mutation: parent owns list; set raises events; samples mutate list in handler. If Toolkit pattern uses `@bind-DataSource`, follow repository convention consistently.

### 10.2 Focus restoration

```
restoreFocus(removed):
  let candidates = focusable chips after removal in visual order
  if next exists: focus next
  else if previous exists: focus previous
  else focus chipset root (tabindex=-1 on root when needed) or associated host input if aria-controls relationship documented
```

### 10.3 Remove button

- `type="button"`  
- Accessible name: localized `Remove {0}` with chip name  
- `click` does not activate Action chip click  
- Visible in forced-colors (border/glyph, not color alone)

### 10.4 Keyboard removal

- **Delete** or **Backspace** when focus is on chip root (not inside nested input): same as remove button  
- v1: **immediate remove** (no two-step)  
- Nested text inputs: keys apply to input, not chip removal  

---

## 11. Overflow model

### 11.1 Modes

| Mode | Behavior |
|------|----------|
| Wrap | `flex-wrap: wrap`; default |
| Scroll | `flex-wrap: nowrap`; `overflow-x: auto` |
| Collapse | Measure fit; hide overflow chips visually but **keep selected/focused chip visible** by pinning or expanding; show `+N`; expand shows all |

### 11.2 Collapse rules

- Focused or selected chips must not disappear without focus move + announcement strategy.  
- **Lock:** when collapsing, prefer visible slots for **selected** chips first, then focused, then earliest.  
- Expand/Collapse control is a `button` with localized name (`Show N more` / `Show less`).  

### 11.3 Measurement

- Prefer pure CSS Wrap/Scroll without JS.  
- Collapse may use `ResizeObserver` via JS interop; on dispose disconnect observer.  
- Collapse measures inline width, not shared `offsetTop`. Sum item widths plus the set gap, reserve the overflow control, and stop when the next chip would pass the root content width. Use the inline start edge so RTL still counts. Skip `display: none` collapsed items. Return at least 1 and at most the item count.  
- The collapse row wraps so measurement can see a second row, then clips to one line with `max-block-size: calc(var(--e-chip-height, 2rem) + 0.2rem)`. That clip is valid for the default chip height only.  
- `CollapsedVisibleCount` is the pre-script fallback. After the first measurement, script may overwrite it so resize can change the fold. Ignore a measurement while expanded. Do not render again when the count is unchanged.  
- If measurement unavailable (SSR): render `CollapsedVisibleCount` when set, otherwise all chips. Collapse applies after interactive measure.

---

## 12. Focus management

| Scenario | Policy |
|----------|--------|
| Passive chips only | No tab stops on chip roots |
| Removable passive | Only remove buttons in tab order (or one stop with arrow to remove — **lock:** remove button in tab order) |
| Interactive set | Roving tabindex among focusable chips |
| After remove | §10.2 |
| Programmatic `FocusChipAsync` | Sets focused chip; ensures visibility if Collapse |

No keyboard traps. Nested interactive content in templates: author responsibility; Spec recommends against nested buttons inside Action chips.

---

## 13. Pointer and touch

- Primary activation: pointer up/click on chip hit target  
- Remove: separate target ≥ 24px CSS px minimum; **prefer 44px** where layout allows (document AAA target size: author may need spacing)  
- Touch: no hover-only affordances required for essential operations  
- Pressed visual state on `:active` for interactive chips  

---

## 14. Templates

| Template | Context | Notes |
|----------|---------|-------|
| `ChipTemplate` | `TItem` or chip context | Replaces default content |
| `LeadingTemplate` | context | Icon/avatar area |
| `TrailingTemplate` | context | Badge/meta |
| `RemoveTemplate` | context | Must still be a real button or host provides equivalent name |
| `EmptyTemplate` | — | Set |
| `LoadingTemplate` | — | Set |
| `ErrorTemplate` | — | Set |

When templates replace text, `AriaLabel` or aria-labelledby must still resolve a name.

---

## 15. Styling architecture

### 15.1 Public classes (proposed; align to repo)

- `e-chip`, `e-chipset`  
- One type class on every chip root, derived from `ChipType`: `e-chip-informational`, `e-chip-status`, `e-chip-action`, `e-chip-assist`, `e-chip-filter`, `e-chip-choice`, `e-chip-input`, `e-chip-suggestion`, `e-chip-navigation`, `e-chip-custom`  
- `e-chip-filled`, `e-chip-outlined`  
- `e-chip-sm`, `e-chip-md`, `e-chip-lg`  
- `e-chip-pill`, `e-chip-rounded`  
- `e-chip-selected` / pressed indicator  
- `e-chip-disabled`, `e-chip-readonly`  
- `e-chip-removable`  
- `e-chip-remove`  
- `e-chipset-wrap`, `e-chipset-scroll`, `e-chipset-collapse`  
- `e-rtl` when RTL  
- Author color classes on `CssClass`, not new enum values: `e-primary`, `e-success`, `e-info`, `e-warning`, `e-danger`. Do not add `e-secondary`, `e-dark`, or `e-btn`.  
- `e-chip-soft` on `CssClass` for a transparent tint. It is not `ChipVariant`.  

### 15.2 Tokens

Use Toolkit color/typography/radius tokens. State is not color alone (border, outline, glyph).

Outlined chips use content text and an accent border. Soft chips do the same. They must not use an on-fill text token such as `--color-sf-primary-text-color` on a transparent background. Filled `.e-chip.e-success` may copy the Button hover text token `--color-sf-primary-text-color` because that surface is filled. Soft and outlined must not. Selected Filter and Choice chips also change border style, not only fill. Selected Filter and Choice chips render an `e-toolkit-icons e-check` glyph in the leading slot when the author did not supply leading content. The default remove glyph is `e-toolkit-icons e-close`. Do not use a text character or `e-icons`; the toolkit theme defines `e-toolkit-icons`. Interactive chips (`button`, `a`) use the theme hover, pressed, and focus-visible tokens. Informational and Status do not. Disabled uses the theme disabled tokens rather than opacity alone. `--e-chip-accent` is the author override for Custom.

### 15.3 CSS isolation

- Styles in component `.razor.css`  
- `::deep` only for authorized child slots  
- Merge `CssClass` onto root  
- Do not depend on generated isolation attribute values in logic  
- Consumer overrides via public classes and CSS variables  

---

## 16. Accessibility (normative)

### 16.1 WCAG posture

Target **WCAG 2.2 Level AA** for all component-controlled behavior; **AAA** where feasible (e.g. focus appearance, target size enhanced). Where AAA depends on author color/content, document author responsibility.

### 16.2 Guarantees vs author

| Component guarantees | Author provides |
|----------------------|-----------------|
| Correct roles/elements per mode | Sufficient visible text or AriaLabel |
| Keyboard ops for interactive modes | Non-conflicting nested controls |
| Named remove button | Meaningful chip text for name substitution |
| Focus visible styles (theme) | Contrast of custom CSS overrides |
| Forced-colors borders | — |

### 16.3 Live regions

Optional polite announcements for bulk remove/add are **not** required in v1 if individual focus moves adequately; if implemented, use restrained polite live region without spam.

---

## 17. Screen reader expectations

| Event | Expectation |
|-------|-------------|
| Focus chip | Name + role/state (pressed/selected/disabled) |
| Focus remove | “Remove {name}” button |
| Toggle filter | Pressed/not pressed announced |
| Remove | Focus lands on next control; name announced |
| Empty/loading/error | Template content available to AT |

Validate with NVDA, Narrator, JAWS evidence packages — axe is not sufficient proof.

---

## 18. RTL and localization

- `EnableRtl` or ancestor `dir=rtl`  
- Logical properties for padding/margins  
- Leading/trailing swap  
- Arrow keys mirror  
- All UI strings (remove, more, less, empty defaults if any) from localization resources — **no hard-coded English in component code**  

---

## 19. Form integration

When `SelectionMode` is Single or Multiple:

- Register with `EditContext` if present  
- Field current value = `SelectedValue` / `SelectedValues`  
- On change notify field changed  
- Support required validation via standard EditContext validators in samples  

ReadOnly/Disabled: do not accept user edits; still display value.

---

## 20. Performance

### 20.1 Targets (proposed until measured)

| Scenario | Proposed target |
|----------|-----------------|
| 50 simple chips initial render | Interactive within one frame budget on reference hardware — **Not yet measured** |
| 100 chips | Usable; prefer Collapse/Scroll — **Not yet measured** |
| 500+ | App should filter/page — **Not yet measured** |

### 20.2 Rules

- One lightweight chip root per item  
- No Toolkit Button/Badge/Avatar component per chip  
- Stable `@key`  
- Avoid re-rendering entire set when one selection bit changes where feasible  
- Dispose JS observers  

---

## 21. JavaScript interop

Allowed:

- Overflow width measurement / ResizeObserver  
- Optional scroll-into-view for focused chip in Scroll mode  

Required:

- Idempotent dispose  
- No interop for click/selection/remove basics  

---

## 22. Error handling and edge cases

| Case | Behavior |
|------|----------|
| Navigation without Href | Do not render as link; fall back to button-like Action or skip navigation semantics (prefer compile-time guidance; runtime: render as button with warning in DEBUG) |
| Remove on non-removable | No-op |
| SelectionChanging cancel | No state change; no Changed |
| Rapid double remove | Second no-op if already removed |
| Dispose during async Removing | Cancellation; no call into disposed set |
| Extremely long text | Truncate with max-width + title/tooltip optional; full name still in accessible name |
| Malicious Href | Render as provided; document consumer sanitization; no `javascript:` encouragement |

---

## 23. Security

- Encode text content (Blazor default)  
- Do not provide raw HTML API in v1  
- `HtmlAttributes` splatting: consumer responsibility  
- Unbounded DataSource: document DoS risk; encourage Max visible / collapse  

---

## 24. Disposal

```
DisposeAsync:
  unregister from parent if any
  disconnect ResizeObserver / JS refs
  clear handlers
  safe to call twice (idempotent)
```

---

## 25. Events (normative order)

**Selection:** `SelectionChanging` → (if not canceled) state update → `SelectionChanged`  

**Removal:** `Removing` → (if not canceled) collection/UI update → `Removed` → focus restore  

**Activation (Action/Suggestion):** `OnClick` / `OnChipClick` after gesture; does not fire for remove button  

---

## 26. Public API summary

Normative detailed list lives in **API.md**. Spec requires:

- Parameters and defaults consistent with API.md  
- XML on all public symbols in API-xml.md  
- No speculative APIs beyond Phase B outline  

---

## 27. Testing strategy

See **TEST-MATRIX.md** (CHIP-U/P/A/V/PERF/R, &gt;150 cases).

Minimum proof:

- Mode semantics and roles  
- Selection Changing/Changed and cancel  
- Removal + focus restore  
- Keyboard matrix + RTL arrows  
- Overflow modes  
- State template precedence  
- CSS class merge / isolation  
- Forced-colors smoke  
- SSR hydrate smoke  
- EditContext sample path  

---

## 28. Compatibility

| Host | Support |
|------|---------|
| Blazor Server | Yes |
| WebAssembly | Yes |
| Static SSR | Markup yes; interaction needs interactive mode |
| Interactive SSR | Yes |
| Auto | Yes if repo supports |
| Trimming / AOT | Follow Toolkit patterns; document warnings |
| JS disabled | Passive display; no remove/select |

---

## 29. Implementation phases

| Phase | Deliverable |
|-------|-------------|
| P0 | `SfChip` informational/action/filter + styles + bUnit smoke |
| P1 | `SfChipSet` data bind, selection, remove, focus restore |
| P2 | Overflow wrap/scroll/collapse, templates, states |
| P3 | RTL, forced-colors, EditContext, Playwright/axe |
| P4 | Samples (8), visual baselines, evidence package |

---

## 30. Definition of done

- [ ] All in-scope behaviors implemented per this Spec  
- [ ] API.md + API-xml.md complete; zero XML warnings  
- [ ] Build: zero compiler/analyzer/nullable warnings in Chips  
- [ ] TEST-MATRIX P0/P1 green on required browsers  
- [ ] axe critical/serious zero on registered routes  
- [ ] Focus restore and remove names verified  
- [ ] Samples (≤8) executable  
- [ ] Evidence.md filled with real artifacts (not invented)  
- [ ] Reuse matrix respected (no per-chip SfButton)  
- [ ] No release-blocking defects  

---

## 31. Open questions (validation only — not placeholders for behavior)

| ID | Question | Resolution method |
|----|----------|-------------------|
| Q1 | Exact child type name (`SfChipItem` vs repeated `SfChip`) | Match Card/Accordion child convention in repo |
| Q2 | EditContext registration helper existence | Copy peer component pattern |
| Q3 | Collapse measurement JS module location | Existing interop folder conventions |
| Q4 | Resource file pattern for L10n strings | Existing Toolkit l10n approach |

Behavior in this Spec remains binding while names/helpers align to Q1–Q4.

---

## 32. Final acceptance checklist

- [ ] Passive chips are not buttons/options  
- [ ] Action/Assist use native button  
- [ ] Navigation uses native link with Href  
- [ ] Filter uses aria-pressed  
- [ ] Choice exclusive in set  
- [ ] Remove named `Remove {chip}`  
- [ ] SelectionChanging before Changed  
- [ ] Removing before Removed; focus restored  
- [ ] Token text input not required on base API  
- [ ] No Toolkit Button per chip  
- [ ] Overflow collapse does not strand focus  
- [ ] State precedence Error &gt; Loading &gt; Empty  
- [ ] RTL arrows mirrored  
- [ ] Forced-colors show state without color-only  
- [ ] Spec ↔ API ↔ tests ↔ samples consistent  

---

## 33. Document control

| Version | Date | Notes |
|---------|------|-------|
| 1.0-proposed | 2026-11-02 | Initial authoritative Spec from Phase B locks |

**Next documents:** API.md (normative parameter tables), API-xml.md, PRD.md, competitive-matrix.md, TEST-MATRIX.md, sample-preparer.md, Evidence.md.
