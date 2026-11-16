# competitive-matrix.md — Blazor Chips / Tags / Tokens
## Syncfusion Blazor Toolkit Chips Proposal

| Field | Value |
|-------|--------|
| **Version** | 1.0-proposed |
| **Proposal** | SfChip / SfChipSet\&lt;TItem\&gt; |
| **Method** | Public documentation and demos review (no source copy) |
| **Primary references** | MudBlazor Chips; Ant Design Blazor Tag; DevExpress TagBox; Telerik chip/tag/multi-select patterns; Radzen; Blazorise; Material Design chip guidance; Fluent UI tag/token patterns |

If a URL moved, use the vendor’s current equivalent component and note the replacement during implementation validation.

Legend: **Y** = publicly supported · **P** = partial / via another control · **N** = not typical · **R** = Toolkit **requirement** (must implement)

---

## 1. Competitor snapshot

| Library | Primary surface | Notes |
|---------|-----------------|-------|
| MudBlazor | MudChip, MudChipSet | Strong chip set + selection variants |
| Ant Design Blazor | Tag, CheckableTag, Select tags | Closable + checkable tags |
| DevExpress Blazor | TagBox / tag rendering | Strong tokenized values |
| Telerik UI for Blazor | Chip / chip-like / multi-select tags | Ecosystem patterns vary by control |
| Radzen | Badge, SelectBar, AutoComplete tokens | Patterns split across controls |
| Blazorise | Tag, Badge, close | Lighter tag model |
| Material.Blazor / MD guidance | Filter/input/assist chips | Interaction reference |
| Fluent UI Blazor | Badge, Tag, dismissible patterns | Token/dismiss reference |
| HAVIT / Blazor Bootstrap / Majorsoft | Badge/pill/tag patterns | Lighter coverage |

---

## 2. Feature comparison matrix

| Feature | Mud | Ant | DX TagBox | Telerik | Radzen | Blazorise | Fluent/MD ref | **Toolkit R** | How Toolkit equals/better | Validation |
|---------|-----|-----|-----------|---------|--------|-----------|---------------|---------------|---------------------------|------------|
| Static declarative chip | Y | Y | P | P | P | Y | Y | **R** | SfChip | CHIP-U-001+ |
| Data-bound chips | Y | P | Y | Y | P | P | P | **R** | SfChipSet\&lt;T\&gt; + ItemKey | CHIP-U-120+ |
| Generic TItem | Y | P | Y | Y | P | P | P | **R** | Generics | API review |
| Chip templates | Y | P | Y | Y | P | P | P | **R** | Chip/Leading/Trailing/Remove | CHIP-U-130+ |
| Empty template | P | N | P | P | N | N | N | **R** | EmptyTemplate | CHIP-U-165+ |
| Loading template | P | N | P | P | N | N | N | **R** | LoadingTemplate | CHIP-U-165+ |
| Error template | N | N | P | P | N | N | N | **R** | Error wins loading | CHIP-U-165+ |
| Informational passive | P | Y | P | P | Y | Y | Y | **R** | Not a button | CHIP-A-001 |
| Status passive | P | P | P | P | P | Y | P | **R** | Status mode | CHIP-U mode |
| Action chip | Y | N | N | P | P | P | Y | **R** | Native button | CHIP-U-010 |
| Assist chip | P | N | N | N | N | N | Y | **R** | Assist mode | unit |
| Filter chip | Y | Y | P | P | P | N | Y | **R** | aria-pressed | CHIP-U-020 |
| Choice chip | Y | P | P | P | P | N | Y | **R** | Single exclusive | selection tests |
| Input token display | P | P | Y | Y | Y | P | Y | **R** | Input type + removable | tokens sample |
| Suggestion chip | P | N | N | N | N | N | Y | **R** | Suggestion + click | unit |
| Navigation chip | P | P | N | P | P | N | P | **R** | Native `a` + Href | CHIP-U nav |
| Selection none | Y | Y | N | P | P | Y | Y | **R** | SelectionMode.None | unit |
| Single selection | Y | P | Y | Y | P | N | Y | **R** | Single | CHIP-U-050 |
| Multiple selection | Y | Y | Y | Y | P | N | Y | **R** | Multiple | CHIP-U-050+ |
| Keyboard selection | Y | Y | Y | Y | P | P | Y | **R** | Space/Enter | CHIP-P-080+ |
| Pointer selection | Y | Y | Y | Y | Y | P | Y | **R** | Click | CHIP-P-001+ |
| Disabled chips | Y | Y | Y | Y | Y | Y | Y | **R** | Disabled | unit |
| Read-only | P | P | Y | P | P | N | P | **R** | ReadOnly | unit |
| Removable | Y | Y | Y | Y | P | Y | Y | **R** | Removable | CHIP-U-090+ |
| Removal cancellation | P | P | P | P | N | N | N | **R** | Removing.Cancel | CHIP-U-090 |
| Remove accessible name | P | P | P | P | P | P | Y | **R** | `Remove {0}` | CHIP-A-010 |
| Focus restore after remove | P | P | P | P | N | N | P | **R** | Spec algorithm | CHIP-U-095+ |
| Editable chip text | P | P | P | P | N | N | N | **N v1** | Future | — |
| Built-in token textbox | P | P | Y | Y | Y | P | P | **N core** | Composition sample | PRD NG-01 |
| Delimiter tokenization | P | P | Y | Y | Y | P | P | **Host** | Sample host input | sample |
| Icons | Y | Y | Y | Y | Y | Y | Y | **R** | IconCss / template | unit |
| Avatars/images | Y | P | P | P | P | N | Y | **R** | ImageUrl / template | unit |
| Badges | P | P | P | P | Y | Y | Y | **P** | Trailing template | sample |
| Leading/trailing content | Y | P | P | P | P | N | Y | **R** | Templates | unit |
| Custom remove UI | P | P | P | P | N | P | P | **R** | RemoveTemplate | unit |
| CssClass per chip | Y | Y | Y | Y | Y | Y | Y | **R** | CssClass / selector | CHIP-R |
| Html attributes | Y | Y | Y | Y | Y | Y | Y | **R** | HtmlAttributes | CHIP-R |
| Event model rich | Y | P | Y | Y | P | P | P | **R** | Changing/Changed/Removing/Removed | unit |
| Two-way selection bind | Y | P | Y | Y | P | N | P | **R** | SelectedValue(s) | unit |
| Programmatic select | Y | P | Y | Y | P | N | P | **R** | SelectAsync | unit |
| Programmatic focus | P | N | P | P | N | N | P | **R** | FocusAsync / FocusChipAsync | unit |
| Programmatic remove | P | P | Y | Y | P | P | P | **R** | RemoveAsync | unit |
| Wrapping | Y | Y | Y | Y | Y | Y | Y | **R** | Wrap default | CHIP-P-050 |
| Single-line scroll | P | P | P | P | P | N | P | **R** | Scroll | CHIP-P-051 |
| Collapse +N | P | P | P | P | N | N | P | **R** | Collapse + policy | CHIP-P-052 |
| Responsive 320 / 400% | P | P | P | P | P | P | Y | **R** | Required tests | CHIP-P-060+ |
| RTL | Y | Y | Y | Y | P | P | Y | **R** | EnableRtl | CHIP-P-070 |
| Localization strings | Y | Y | Y | Y | P | P | Y | **R** | Resource keys | unit |
| CSS isolation | Y | Y | Y | Y | Y | Y | Y | **R** | Spec isolation | CHIP-R |
| Theme tokens | Y | Y | Y | Y | Y | Y | Y | **R** | Toolkit tokens | visual |
| Forced colors | P | P | P | P | P | P | Y | **R** | Required | CHIP-A/P |
| Dark mode | Y | Y | Y | Y | Y | Y | Y | **R** | Theme | visual |
| Reduced motion | P | P | P | P | P | P | Y | **R** | Honor prefer-reduced-motion | PW |
| Keyboard a11y | Y | Y | Y | Y | P | P | Y | **R** | Full matrix | CHIP-P-080+ |
| Screen reader docs/evidence | P | P | P | P | N | N | P | **R** | Evidence package | EV-CHIP-012+ |
| Form integration | P | P | Y | Y | P | N | P | **R** | EditContext selectable | forms sample |
| SSR markup | Y | Y | Y | Y | Y | Y | Y | **R** | Spec SSR | CHIP-P-110 |
| No JS for basic ops | Y | Y | P | P | P | Y | Y | **R** | JS only measure/focus | review |
| Large collection guidance | P | N | P | P | N | N | P | **R** | Spec thresholds | PERF |
| Avoid listbox default | Y | Y | N/A | N/A | Y | Y | Y | **R** | Explicit non-listbox | CHIP-A |
| Per-chip heavy Button | N | N | N | N | N | N | N | **Forbid** | Native button | EV-CHIP-031 |

---

## 3. Gap analysis

| Market gap | Toolkit response |
|------------|------------------|
| Passive tags as buttons | Informational/Status non-interactive |
| Unnamed close icons | Localized `Remove {0}` |
| Focus lost on delete | Normative restore algorithm + tests |
| Token field forced into chip | Core API excludes text field; composition sample |
| Color-only selection | Forced-colors + non-color indicators |
| Missing empty/loading/error on chip sets | First-class templates + precedence |
| Collapse hides focused chip | Selected/focused pinning policy |

---

## 4. Final recommendations

1. Implement Spec mode table exactly.  
2. Prioritize removal + focus restore + selection cancel tests.  
3. Keep token text entry in host composition for v1.  
4. Ship Wrap/Scroll/Collapse with measurement disposal.  
5. Publish Evidence scripts for NVDA/Narrator/JAWS.  
6. Re-verify competitor URLs at implementation time; requirements stay.

**Superiority claims** are limited to measurable requirements above; performance numbers remain **Not yet measured** until Evidence lab runs.
