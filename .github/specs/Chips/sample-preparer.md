# Chip demo suite — creation specification

| Field | Value |
|---|---|
| **Component** | `SfChip` / `SfChipSet<TItem>` |
| **Catalog route** | `/buttons/chip` |
| **Catalog page** | `samples/Blazor.Toolkit.Samples.Client/Pages/Components/Buttons/Chip.razor` |
| **Demo folder** | `samples/Blazor.Toolkit.Samples.Client/Pages/Demos/Buttons/Chip/` |
| **Purpose** | Create a cohesive, seven-demo Chip suite that introduces passive chips and demonstrates practical interactive patterns. |

## Goal and scope

Create seven focused, polished demos in the specified order. Together, they
introduce informational chips and show action, selection, recipient-token,
responsive-overflow, form, and property-playground scenarios. Update the Chip
catalog introduction, captions, layout, and table of contents to present the
demos as one suite.

This task specifies sample and catalog work only. Do not change Chip component
source, public APIs, selection/removal/overflow behavior, or global theme
styles. Do not imply that a local sample action submits data to a server,
persists settings, or makes a network request.

## Shared implementation rules

- Use `SfChip` and `SfChipSet<TItem>` for chip rendering and their supported
  interactions. Do not recreate chips, selection, removal, or overflow with
  hand-built markup or CSS-only behavior.
- `ChipType.Informational` is passive. Do not attach an action to it or describe
  it as a control. Use an interactive chip type when the user can act.
- Use `ChipType.Action` for operations, `ChipType.Navigation` with a valid
  `Href` for navigation, and `ChipType.Filter` for filter selection.
  `Selected` is relevant to Filter and Choice chips.
- An Input chip's root is passive; its remove control removes the token. Keep
  entry fields beside the chip set, never inside a chip.
- Use only supported `SfChip` parameters and existing enum members. Supported
  parameters include `Text`, `Value`, `ChipType`, `Variant`, `Size`, `Shape`,
  `IconCss`, `ImageUrl`, `ImageAlt`, `Href`, `Target`, `Rel`, `Selected`,
  `Removable`, `Disabled`, `ReadOnly`, `IsLoading`, `HasError`, `CssClass`,
  `Style`, `Id`, `AriaLabel`, `AriaLabelledBy`, `AriaDescribedBy`, `TabIndex`,
  `HtmlAttributes`, `ChildContent`, and templates. Types include
  Informational, Status, Action, Assist, Filter, Choice, Input, Suggestion,
  Navigation, and Custom.
- Use `CssClass` for valid styling classes; do not invent a `Color` parameter
  or a soft `Variant`. Use actual `Variant` values such as `Filled` and
  `Outlined`, and actual `Size` and `Shape` values.
- Keep demo-local markup and state in the corresponding `.razor` components.
  Shared catalog-only layout and responsive styles belong in the `<style>`
  block in `Chip.razor`. Do not add a stylesheet unless an established sample
  convention requires one. Do not duplicate component/theme colors, disabled
  styling, icon positioning, or focus styling in sample CSS.
- Use semantic headings, sections, native buttons and links, associated input
  labels, visible focus, and Toolkit theme tokens. Layouts and feedback must
  remain readable and usable in light and dark themes and at narrow and wide
  viewport widths.

## Demo suite

Create the demos in this exact order. The first is the introductory preview;
the remaining six are named catalog sections.

### 1. Default — `DefaultDemo`

Create a display-only informational gallery with exactly these three groups:

1. **Default and semantic colors:** default appearance plus representative
   semantic `CssClass` colors such as `e-primary`, `e-info`, `e-success`,
   `e-warning`, and `e-danger`.
2. **Filled and outlined:** show supported `Filled` and `Outlined` variants.
3. **Leading content:** show supported `IconCss` examples and an avatar/leading
   content template example.

Every chip is passive `ChipType.Informational`. Include a concise explanation
that informational chips display labels or status and do not perform actions;
direct users to an interactive type when they need to act. Do not add click
handlers or imply that appearance alone makes a chip interactive.

### 2. Actions — `ActionsDemo`

Create a workspace **Sales overview** card or semantic overview panel with
action chips for refreshing insights, exporting, and sharing, plus a
navigation chip linking to a valid in-app destination.

- Each action chip performs a visible, local sample operation and reports a
  meaningful result/status; do not imply backend work.
- Show an action in loading and disabled states while its local operation is
  pending, then restore its usable state.
- Render navigation as a link by providing a valid `Href`. If it opens a new
  tab, provide a safe `Rel` value with its `Target`.
- Use an accessible live status for action results. Explain the distinction
  between performing an action and navigating.

### 3. Filters — `FiltersDemo`

Create a **Profile skills** picker with a labeled name field, available skills,
selected count, a separate selected-skills row of removable chips, Clear, and
Save.

- Use a multiple-selection `ChipType.Filter` set for available skills and keep
  its selected values as the single source of truth.
- Selecting/deselecting an available skill updates the count and selected row.
  Removing a selected-row chip deselects the matching filter. Clear resets the
  filter state, selected row, and count together.
- Save presents a local confirmation of the selected skills. Announce changing
  counts and save feedback through an accessible polite live status.
- Give the name field an associated label and make selection, removal, Clear,
  and Save keyboard accessible.

### 4. Removable chips — `RemovableChipsDemo`

Create an email recipient composer with a **To** recipient area, subject and
message context, and an adjacent recipient-entry field.

- Add recipients by pressing Enter or choosing a suggestion. Render recipients
  as removable `ChipType.Input` chips; the chip root remains passive.
- Reject empty and duplicate recipients with meaningful validation/status
  feedback. Removing a recipient updates the recipient collection and status.
- Keep keyboard focus in the recipient-entry field after add, suggestion
  selection, and removal where the user is continuing entry.
- Associate the entry label and validation feedback accessibly, and announce
  recipient changes politely. Do not put an input inside a chip.

### 5. Responsive — `ResponsiveDemo`

Create a constrained preview of category Filter chips with Wrap, Scroll, and
Collapse mode controls, a selection count, and the same category values in every
mode. Select Wrap by default so all categories are visible on initial render.

- Use multiple-selection `ChipType.Filter` chips and controls that switch the
  real `SfChipSet<TItem>` overflow mode; selection must remain unchanged when
  switching modes.
- Include twelve category values. In Collapse, initially show four chips and
  the component's expand/collapse control; keep selection count synchronized
  across modes.
- Make the constrained preview useful at narrow widths without clipping its
  controls or explanatory text. Wrap should wrap, Scroll should scroll, and
  Collapse should expose its overflow control.
- State that Collapse overflow measurement requires interactive rendering.

### 6. Forms — `FormsDemo`

Create a notification-preferences form with a required Filter-chip selection,
an `EditForm`, Submit, validation feedback, and a success confirmation.

- Bind the selected `ChipType.Filter` values to the form model. Submitting with
  no selection shows validation and no success; a valid submit shows a clear
  confirmation.
- Clear stale success feedback when the selection changes. Label and associate
  validation feedback where supported, and announce validation/success updates
  accessibly.
- Keep this as local sample confirmation only; do not imply server submission
  or persistence.

### 7. Playground — `PlaygroundDemo` (new)

Create a live `SfChip` preview, accessible property controls, a generated Razor
snippet, and a copy action. Keep the preview and code synchronized whenever a
control changes. Keep the panel title free of inherited heading margins. On
wide screens, place a single-column vertical property list in the left half and
the Live preview and Generated Razor in the right half; stack the halves on
narrow screens.

Provide controls for:

- `ChipType`, `Variant`, `Size`, `Shape`, and `Text`.
- Leading content choice, including `IconCss` or `ImageUrl`; provide
  `ImageAlt` when an image is used.
- A small set of valid `CssClass` presets.
- `Selected`, only when `ChipType` is Filter or Choice.
- `Removable`, `Disabled`, `ReadOnly`, and `HasError`.
- `Href` and `Target` only when `ChipType` is Navigation.

Only show controls applicable to the selected type and content choice. Use
actual supported parameters and valid enum members; do not generate `Color` or
unsupported variant properties. The snippet must represent the current preview
settings using valid Razor component-attribute enum syntax. Omit default enum
properties (`ChipType.Informational`, `ChipVariant.Filled`, `ChipSize.Medium`,
and `ChipShape.Pill`) from the generated snippet. With the default text, emit
`<SfChip Text="Chip" />`. Give every control an accessible name. If a removable
preview is removed, provide a reset/recreate control so the user can continue
experimenting. Copy the current snippet and show accessible copy feedback;
handle copy failure with clear feedback.

## Files and catalog wiring

Use these exact component names and locations:

| Order | Component | Repository path |
|---:|---|---|
| 1 | `DefaultDemo.razor` | `samples/Blazor.Toolkit.Samples.Client/Pages/Demos/Buttons/Chip/DefaultDemo.razor` |
| 2 | `ActionsDemo.razor` | `samples/Blazor.Toolkit.Samples.Client/Pages/Demos/Buttons/Chip/ActionsDemo.razor` |
| 3 | `FiltersDemo.razor` | `samples/Blazor.Toolkit.Samples.Client/Pages/Demos/Buttons/Chip/FiltersDemo.razor` |
| 4 | `RemovableChipsDemo.razor` | `samples/Blazor.Toolkit.Samples.Client/Pages/Demos/Buttons/Chip/RemovableChipsDemo.razor` |
| 5 | `ResponsiveDemo.razor` | `samples/Blazor.Toolkit.Samples.Client/Pages/Demos/Buttons/Chip/ResponsiveDemo.razor` |
| 6 | `FormsDemo.razor` | `samples/Blazor.Toolkit.Samples.Client/Pages/Demos/Buttons/Chip/FormsDemo.razor` |
| 7 | `PlaygroundDemo.razor` **(new)** | `samples/Blazor.Toolkit.Samples.Client/Pages/Demos/Buttons/Chip/PlaygroundDemo.razor` |

Wire all seven, in order, from
`samples/Blazor.Toolkit.Samples.Client/Pages/Components/Buttons/Chip.razor`.
Each must have exactly one `CodePreview` whose `PreviewComponent` names its
matching component and whose `SourceFile` resolves to that component's exact
file. Keep the component type and source path in sync.

Update the catalog introduction to explain the suite and distinguish passive
informational chips from interactive types. Add concise, accurate captions and
descriptive headings for:

| Demo | Heading | Section id / TOC entry |
|---|---|---|
| Default | Introductory preview; no separate section heading | None |
| Actions | Actions & Navigations | `actions` |
| Filters | Filters | `filters` |
| Removable chips | Removable chips | `removable-chips` |
| Responsive | Responsive | `responsive` |
| Forms | Forms | `forms` |
| Playground | Chip playground | `playground` |

The Default preview follows the introduction and has no separate TOC entry.
Give every other section a unique matching section id and right-side TOC entry.
Ensure the seven previews appear in the required order, headings/captions
describe actual content, and every preview source path exists. Keep all
catalog-only layout/responsive rules in `Chip.razor`'s existing `<style>` block;
do not add global styles or Chip theme/component overrides.

## Accessibility, responsive behavior, and verification checklist

- [ ] Exactly seven ordered demos are wired, with seven matching
      `CodePreview` component/source pairs and the new `PlaygroundDemo.razor`.
- [ ] Default contains only passive informational chips in its three specified
      groups and explains their non-interactive purpose.
- [ ] Actions visibly complete and report their local result; busy/disabled
      states are shown; the navigation chip is a valid link.
- [ ] Skills selection, count, removable selected row, Clear, Save, and live
      feedback stay synchronized.
- [ ] Recipient entry supports Enter and suggestions, rejects empty/duplicate
      values, removes recipients, reports feedback, and preserves entry focus.
- [ ] Responsive modes use the same category values and preserve selection;
      Wrap, Scroll, and Collapse behavior and Collapse's initial visible count
      and expand/collapse control are described and usable.
- [ ] Form validation blocks empty submission, valid submission confirms, and
      selection changes clear stale confirmation.
- [ ] Playground preview and generated Razor remain synchronized; controls
      are conditional and accessible; snippet uses supported parameters and
      valid enum syntax; reset and copy feedback work.
- [ ] All interactive controls have accessible names, are keyboard operable,
      and retain visible focus. Selected, disabled, busy, and error states are
      conveyed accessibly.
- [ ] Inputs have associated labels; validation is meaningful and associated
      where supported; changing counts/results use polite live status without
      redundant announcements.
- [ ] Semantic HTML and link/button behavior match the action; no ARIA roles
      conflict with native semantics.
- [ ] Layouts, text, controls, status, and validation remain usable without
      clipping at narrow and wide viewport widths and in light and dark themes.
- [ ] No chip color, focus, disabled, icon, or theme behavior is reimplemented
      in catalog/sample layout styles.

## Out of scope

- Changes to `src/Components/Buttons/Chips/`, public APIs, component behavior,
  selection/removal/overflow logic, or global theme styles.
- Changes to routes, commercial Chip samples, or unrelated sample suites.
- Server operations, persistence, network calls, or non-local form submission.
- Unsupported Chip parameters, invented variant values, or CSS-based
  substitutes for component behavior.
