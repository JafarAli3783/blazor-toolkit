# SfAutoComplete — Sample Browser Preparer (exactly 6 demos)

**Strict scope:** catalog entry + **six** `.razor` demo files under the AutoComplete demos folder only.
**Quality bar:** Mud visual playground / Telerik overview polish.

## Catalog Description (shared pattern)

Each demo page MUST include a Description block:

```razor
@* Description
Title: {Title}
Order: {n}
Category: AutoComplete
Description: {1–2 sentence real-world pitch}
*@
```

---

## Demo 1 — Default

| Property | Details |
|---|---|
| File | `Default.razor` |
| Purpose | Local data type-ahead, select, clear |
| Scenario | Pick a US state in a profile form |
| Visual | Single field, popup list, clear icon |
| Interaction | Type → filter → click or Enter → clear |
| Main APIs | Data, @bind-Value, DisplayTextFunc, ClearButton, FilterType=StartsWith |

Description markup:

```text
Title: Default
Order: 1
Category: AutoComplete
Description: Type-ahead selection from a local list with clear support for common form fields.
```

---

## Demo 2 — Filtering & remote

| Property | Details |
|---|---|
| File | `RemoteSearch.razor` |
| Purpose | Debounce, min length, async search, loading, cancel |
| Scenario | Employee directory API lookup |
| Visual | Loading indicator in popup; progressive results |
| Interaction | Type ≥2 chars; pause; see load; type faster; stale ignored |
| Main APIs | SearchFunc, DebounceInterval, MinLength, LoadingTemplate, OnSearch |

Description:

```text
Title: Remote data
Order: 2
Category: AutoComplete
Description: Debounced asynchronous search with cancellation and loading state for directory-style lookups.
```

---

## Demo 3 — Templates

| Property | Details |
|---|---|
| File | `Templates.razor` |
| Purpose | Item, no-results, header/footer; match highlight |
| Scenario | Product search with SKU subtitle |
| Visual | Two-line items; bold match; footer tip |
| Interaction | Type partial name; see highlight; empty query message |
| Main APIs | ItemTemplate, NoResultsTemplate, HeaderTemplate, FooterTemplate, HighlightMatch |

Description:

```text
Title: Templates
Order: 3
Category: AutoComplete
Description: Customize suggestion rows, empty state, and popup chrome with match highlighting.
```

---

## Demo 4 — Force selection & free text

| Property | Details |
|---|---|
| File | `ForceSelection.razor` |
| Purpose | Compare force-select vs free-text policies |
| Scenario | Strict country code vs open tag-like keyword |
| Visual | Two fields side by side + validation message on strict |
| Interaction | Blur with invalid text; strict reverts; free keeps |
| Main APIs | ForceSelection, ResetValueOnEmptyText, EditContext |

Description:

```text
Title: Force selection
Order: 4
Category: AutoComplete
Description: Compare required list selection with free text and form validation.
```

---

## Demo 5 — Large list performance

| Property | Details |
|---|---|
| File | `LargeList.razor` |
| Purpose | Honest large local list; `MaxItems` is Phase 2 (virtualization also Phase 2) |
| Scenario | City picker over thousands of rows |
| Visual | Capped suggestions; note in description if virtualization pending |
| Interaction | Type to narrow; scroll list |
| Main APIs | Phase 1: Data, FilterType=Contains; Phase 2: MaxItems and EnableVirtualization |

Description:

```text
Title: Large list
Order: 5
Category: AutoComplete
Description: Type-ahead over a large local collection with a suggestion limit; virtualization is Phase 2.
```

---

## Demo 6 — Form & states

| Property | Details |
|---|---|
| File | `FormStates.razor` |
| Purpose | Disabled, readonly, validation, loading, RTL toggle or dir=rtl section |
| Scenario | Admin settings form |
| Visual | Grid of states; validation message; RTL example |
| Interaction | Submit invalid; toggle disabled; switch dir |
| Main APIs | Disabled, ReadOnly, EditContext, CssClass, dir |

Description:

```text
Title: Form and states
Order: 6
Category: AutoComplete
Description: Validation, disabled and read-only states, and right-to-left layout for production forms.
```

---

## Sample implementation matrix

| Demo | Competitive polish focus |
|---|---|
| 1 — Default | Mud playground simplicity |
| 2 — Remote | Telerik OnRead / Mud SearchFunc story |
| 3 — Templates | Blazorise/Mud item templates + highlight |
| 4 — Force selection | Clearer than Mud coerce matrix |
| 5 — Large list | Honest perf vs Telerik virt (P2) |
| 6 — Form states | Enterprise form credibility |

Avoid: keyboard-only teaching pages; 15 thin API samples.

---

## Package completeness

| File | Delivered |
|---|---|
| PRD.md | Yes — goals, non-goals, phases, defaults |
| Spec.md | Yes — architecture, state, filter, a11y, CSS isolation |
| competitive-matrix.md | Yes — 10+ competitors + win gaps |
| API.md | Yes — parameters, events, methods, enums, models |
| API-xml.md | Proposed XML inventory — CS1591 unverified until implementation is built |
| TEST-MATRIX.md | Yes — L1–L6 with IDs |
| Evidence.md | Yes — Card-style evidence |
| sample-preparer.md | Yes — exactly 6 demos |

**Normative defaults locked for implementers:** Debounce **300** ms, MinLength **0**, OpenOn **Type**, ForceSelection **false**, ARIA **combobox + listbox**, stale-search **version gate**, `HighlightFirstItem` highlights only (no autofill), `TextChanged` is Phase 1, `MaxItems`/virtualization/grouping/adornments are Phase 2, and multi-select is a non-goal.

**API status:** These demos specify a planned component. The repository currently has no shipped `SfAutoComplete` implementation or public-API baseline; do not report runtime/sample execution or CS1591 as verified until implementation lands.