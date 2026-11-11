# Sample preparer — Chips catalog

| Field | Value |
|-------|-------|
| **Component** | `SfChip` / `SfChipSet<TItem>` |
| **Host** | `samples/Blazor.Toolkit.Samples` |
| **Catalog route** | `/buttons/chip` |
| **Catalog page** | `samples/Blazor.Toolkit.Samples.Client/Pages/Components/Buttons/Chip.razor` |
| **Demos folder** | `samples/Blazor.Toolkit.Samples.Client/Pages/Demos/Buttons/Chip/` |
| **Catalog layout styles** | Keep Chip-catalog-only layout styles in the `<style>` block in `Chip.razor`, as requested. Do not copy Card-specific styles or move Chip theme/color rules into demo CSS. |
| **Visual reference** | `chip-demos-preview.html` is a standalone concept preview. Use it as a layout and interaction reference; implement with the real Toolkit components, not copied static HTML or its mock CSS/JavaScript. |

## Goal and scope

Reduce the Chip catalog to exactly six focused demos. Keep the existing route and
preserve the behavior of the Toolkit components. One demo uses passive
`ChipType.Informational`; the other five demonstrate user-operable actions:
Action/Navigation, Filter selection, Input-chip add/remove, responsive Filter
sets, and form-bound Filter selection.

This is sample work. Do not change component source, public APIs, component
semantics, overflow measurement, or global theme styles to make the demos fit.
Do not silently remove behavior while merging demos. Keep reusable examples
represented in the Default demo, or move their relevant scenario to the
appropriate interactive demo.

These are Toolkit samples, not the commercial `/chips/*` routes exercised by
`accessibility/Blazor.Toolkit.AxeCore.Tests/Tests/ChipsTests.cs`.

## Interaction and component rules

- `ChipType.Informational` is display-only. Its demo description must clearly
  state that the chip is not an interactive control. Use an interactive
  `ChipType` when a user action is intended.
- Use `ChipType.Action` for an action button, `ChipType.Navigation` with `Href`
  for navigation, and `ChipType.Filter` with an appropriate selection mode for
  selectable filters.
- `ChipType.Input` has a passive chip root. In the Removable Tags demo, adding is
  performed by the adjacent host input and Add/Enter controls; removal is
  performed by the chip's remove button. Describe this accurately. Do not change
  the Input chip into an Action chip merely to make its root clickable.
- Keep tag text entry beside `SfChipSet`; do not put a text input inside
  `SfChip`.
- Use `SfChip` and `SfChipSet<TItem>` for the examples. Do not replace component
  behavior with hand-built chip markup, fake selection, or CSS-only interaction.
- `e-chip-soft` is a CSS class supplied through `CssClass`; it is not
  `ChipVariant.Soft`.
- Keep color classes (`e-primary`, `e-info`, `e-success`, `e-warning`,
  `e-danger`) and component icon styling in the component/theme layer. Demo
  styles are for sample layout only. Do not add `e-btn`, `e-secondary`, or
  `e-dark` to chips.

## Six-demo catalog

Render the following six demos in this order. The descriptions must explain
what each chip type does, not only name its API properties. The Default demo is
the introductory preview and has no separate heading or TOC item; the five
interactive demos each have one `CodePreview`, heading, section id, and matching
TOC item. Keep every component type and source-file path synchronized.

| TOC id | Heading | Demo component | Required type and behavior |
|--------|---------|----------------|----------------------------|
| — | — | `DefaultDemo` | Informational `SfChip` examples only, in exactly three groups: default/color classes, soft/outlined, and icons/avatar template. These are illustrative, not interactive. |
| `actions-navigation` | Actions & Navigation | `ActionsDemo` | An Action chip runs an observable action; a Navigation chip renders a real link with `Href` and appropriate `Target`/`Rel` when opening a new tab. |
| `filters` | Filters | `FiltersDemo` | A data-bound, multiple-selection Filter set with count, colored/icon filters, a disabled item, selected chips displayed underneath, per-chip removal, and Clear. |
| `removable-tags` | Removable Tags | `TokensDemo` | Preserve the prior colored removable chips and host `SfTextBox` + Enter/Add workflow, trimming, duplicate prevention, maximum chip count, and remove flow. Input chips remain passive at the root; remove buttons and the text box are interactive. |
| `responsive` | Responsive Filters | `ResponsiveDemo` | Twelve selectable Filter chips; Wrap, Scroll, and Collapse mode controls; keep `CollapsedVisibleCount="4"` and demonstrate the narrow container and show-more/show-less behavior. |
| `forms` | Forms | `FormsDemo` | Multiple-selection Filter chips bound in an `EditForm`, required-selection validation, and successful-submit feedback containing the selected labels. |

### 1. Default — Informational

**Description guidance:** “Informational chips display labels or status and are
not interactive controls. Use an Action, Filter, Choice, or Navigation chip
when a user needs to act.”

Consolidate presentation-only content into exactly three visual groups in the
Default demo. Do not add separate affix or size groups. Use actual `SfChip`
parameters and templates:

- **Default and color classes:** default plus primary, info, success, warning,
  and danger.
- **Soft and outlined:** show representative `e-chip-soft` and
  `ChipVariant.Outlined` chips.
- **Icons and avatar template:** show supported icon font classes through
  `IconCss` and one avatar/template example.

All chips in this section must remain `ChipType.Informational` (the default).
Do not attach click handlers or imply that appearance styles make them
interactive.

### 2. Actions & Navigation

**Description guidance:** Explain that Action chips invoke an operation and
Navigation chips navigate to a destination.

- Keep a visible Action-chip operation (for example, run a report) with a
  meaningful status/result and disabled/busy state while it is running.
- Keep a Navigation chip as a link with a valid destination. When using
  `Target="_blank"`, set the safe `Rel` value.
- Do not use a passive Informational chip for either interaction.

### 3. Filters

**Description guidance:** Explain multiple filter selection, selected-state
feedback, and that disabled filter items remain visible but cannot be selected.

Preserve and make explicit the current `FiltersDemo` behavior:

1. Bind a `ChipType.Filter` `SfChipSet` in multiple-selection mode to the
   selected-values collection.
2. Show the selected count and keep the data-bound filter chips visible,
   including the disabled Legacy item.
3. When a filter is selected, show a corresponding filled, removable chip in a
   separate row below the filter set. When deselected, remove its selected-row
   chip.
4. Removing a chip from the selected row must remove the same value from the
   bound selection and update both the filter state and count.
5. Clear must empty the bound selection, clear the selected row, and update the
   count. The disabled item must remain disabled and must not enter the selected
   row.

Use the real `SfChipSet` selection/removal callbacks and `SfChip` components;
do not maintain a second unsynchronized selection state. Preserve the current
representative icon/color examples.

### 4. Removable Tags — Input

**Description guidance:** Explain that the adjacent text field adds tags with
Enter or Add, while the Input chip's remove button removes a tag; the chip body
itself is not an activation button.

Preserve the current `TokensDemo` workflows:

- Keep the `SfTextBox` outside the ChipSet and label it accessibly.
- Use Toolkit `SfTextBox` for text entry; do not use a native `<input>` element.
- Trim whitespace, reject empty values and duplicates, and enforce the existing
  maximum tag count.
- Support both Enter and Add.
- Center the input row and keep the text field to a moderate width (no wider
  than 28rem); remove the helper sentence beneath it.
- Place add/remove status between the input row and tag chips. Highlight only
  successful add/remove messages with the same light-green feedback style used
  by Forms; keep validation/error messages distinct. Provide a contrasting
  dark-theme success palette so text remains readable when dark mode is active.
- Render removable `ChipType.Input` chips, and remove the matching tag from the
  host collection when the remove control is activated.
- Preserve the existing colored removable-chip examples as well as the tag
  input workflow; keep the two examples visually distinct.

### 5. Responsive Filters

**Description guidance:** Explain the Wrap, Scroll, and Collapse layouts and
that filter chips remain selectable in each layout.

- Preserve three mode controls and use them to update `SfChipSet.OverflowMode`.
- Use Toolkit `SfButton` components for the mode controls.
- Use multiple-selection `ChipType.Filter` chips and a narrow container.
- Center the selected-count status between the mode controls and chip set, and
  show it with the light-green feedback style and a readable dark-theme variant.
- Keep twelve category values and `CollapsedVisibleCount="4"`.
- Size the narrow container so four category chips are visible in Collapse at
  the sample viewport. Verify that Wrap wraps, Scroll scrolls, and Collapse
  initially limits visible chips and exposes its overflow control.
- Resizing the container must continue to be handled by the component's
  existing overflow behavior.

### 6. Forms

**Description guidance:** Explain that selected Filter chips bind to the form
model, selection is required, and valid submission displays a confirmation.

- Keep `SfChipSet` inside an `EditForm`, bound to the model's selected values.
- Center the chip set and Submit button consistently, and provide visible
  spacing between them so selected-state icons do not shift the form layout.
- Preserve validation requiring at least one selection. An invalid submit must
  show the validation message and must not show success feedback.
- On a valid submit, display the concise confirmation “Form was submitted”.
- Use a visible, polite live status (`role="status"` / `aria-live="polite"`) for
  success, with readable contrast in light and dark themes. Do not announce
  success before valid submission.
- Clear or refresh stale success feedback when the selection changes, so the
  message does not claim that a different selection was submitted.
- This is a sample confirmation only; do not imply that data was sent to a
  server unless the sample actually implements a server operation.

## Current-demo consolidation map

Use this map to preserve existing value while removing the 14-section catalog:

| Current demo | Disposition |
|--------------|-------------|
| `DefaultDemo` | Keep as Default |
| `FilledColorsDemo` | Merge into Default, then delete the old demo file |
| `TextChipsDemo` | Merge into Default, then delete the old demo file |
| `OutlinedChipsDemo` | Merge into Default, then delete the old demo file |
| `IconsDemo` | Merge into Default, then delete the old demo file |
| `TemplatesDemo` (Avatars) | Merge representative avatar/template into Default, then delete the old demo file |
| `TokensDemo` (Closable) | Keep as Removable Tags |
| `AffixDemo` (Prefix/Suffix) | Exclude and delete the old demo file |
| `ActionsDemo` | Keep as Actions & Navigation |
| `FiltersDemo` | Keep and preserve selected-row/remove/Clear synchronization |
| `SizesDemo` | Exclude and delete the old demo file |
| `ResponsiveDemo` | Keep as Responsive Filters and ensure selectable Filter chips |
| `AccessibilityDemo` | Remove as a standalone section and delete the old demo file; incorporate relevant accessibility examples/verification into Filters and all interactive demos |
| `FormsDemo` | Keep as Forms and add valid-submit confirmation |

After consolidating, keep only `DefaultDemo`, `ActionsDemo`, `FiltersDemo`,
`TokensDemo`, `ResponsiveDemo`, and `FormsDemo` in the Chip demo folder. Search
for all references—including `CodePreview`, embedded source registration, and
tests—before deleting the retired demo files.

## Catalog and table of contents

Update `Pages/Components/Buttons/Chip.razor` so that:

- The page renders the Default preview immediately after the introduction,
  without a Default section heading or Default TOC entry. The five interactive
  sections follow in the order above.
- Each section has one descriptive heading, a matching unique TOC id, and one
  `CodePreview` whose `PreviewComponent` and `SourceFile` refer to the correct
  interactive demo. The Default preview has no section heading or TOC link.
- The page-level introduction distinguishes passive Informational chips from
  interactive chip types.
- The right-side TOC contains exactly the five interactive section entries; remove stale ids
  and headings for the retired standalone demos.
- All code-preview source paths remain valid after any rename or consolidation.

## Styling and responsive layout

- Keep catalog layout styles in the `<style>` block in `Chip.razor`, consistent
  with the requested sample organization. Do not copy `card-demos.css` wholesale
  or add Chip styling to Card demo files.
- Keep sample styles limited to layout: section spacing, flex/wrap rows,
  selected-chip rows, Forms feedback spacing, responsive demo width, and
  narrow overflow container.
- Do not duplicate component chip colors, disabled-state rules, icon glyph
  positioning, or focus styles in sample CSS.
- Maintain the current Toolkit typography, color tokens, borders, and focus
  indicators. Avoid hard-coded visual overrides that disguise component issues.
- Check the six demos at narrow and wide viewport widths; controls and chips
  must wrap/scroll according to the sample purpose without clipping descriptions
  or the Forms success message.

## Accessibility and interaction checks

- Every action, navigation link, filter, remove control, layout switch, input,
  Add, Clear, and Submit control must be keyboard operable and have an accessible
  name.
- Keep native buttons/links and existing Chip semantics. Do not add ARIA roles
  that conflict with the native element semantics.
- Verify selected state is conveyed, disabled items are truly disabled, and
  focus remains visible.
- Use polite live status for changing selected counts, action results, and Forms
  success; associate validation messages with the form controls where supported.
- Keep the Default description explicit that Informational chips are not
  interactive.

## Verification checklist

- [ ] Catalog displays six demos: one introductory Default preview without a
      heading or TOC link, followed by five interactive sections and exactly
      five TOC links.
- [ ] Every demo has one working CodePreview and a matching source path.
- [ ] Default shows only passive Informational chips in exactly the three
  specified groups and documents that behavior.
- [ ] Actions & Navigation demonstrates a button action and actual link.
- [ ] Filters: selecting/deselecting updates the selected removable row and
  count; removing a selected chip synchronizes the Filter set; Clear resets all;
  disabled items remain unselectable.
- [ ] Removable Tags: centered 28rem-or-narrower `SfTextBox`, no helper
  sentence, Enter/Add, trimming, duplicate prevention, max count, colored
  removable examples, and Input-chip remove behavior work; successful
  add/remove status appears between the input and chips with light-green
  styling, while validation errors remain distinct.
- [ ] Responsive Filters: Wrap, Scroll, Collapse, selection, and show-more/
  show-less all work in the narrow container.
- [ ] Responsive Filters uses `SfButton` mode controls and displays four
  collapsed chips at the sample viewport; selected-count feedback is
  centered between controls and chips with light-green styling.
- [ ] Forms: empty submission shows validation only; valid submission announces
  “Form was submitted”; changing selection clears stale confirmation.
- [ ] Chip demo folder contains only the six planned demo components, with no
  stale source or `CodePreview` references.
- [ ] Interactive controls work by keyboard and keep visible focus.
- [ ] Forms chips and Submit remain centered with visible vertical spacing after
  selection changes and submission.
- [ ] Sample build succeeds; manually inspect wide and narrow browser layouts.

## Explicitly out of scope

- Changes to `src/Components/Buttons/Chips/`, Chip public APIs, or component
  selection/removal/overflow logic.
- Fixes to component icon alignment, disabled styling, color tokens, or global
  theme behavior.
- Changes to commercial Chips samples or AxeCore tests for commercial routes.
- Server submission, persistence, or network calls for the Forms example unless
  separately requested.
