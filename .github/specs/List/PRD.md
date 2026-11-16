# Product Requirements Document – SfList
## Syncfusion Blazor Toolkit

**Version:** 1.3  
**Status:** Draft, pending API review. Not implemented.  
**Authority:** This file owns product scope. `API.md` is the only public-member contract. `Spec.md` owns behavior and must not introduce parameters. `API-xml.md` documents `API.md` and must not add members. `TEST-MATRIX.md` must not require a non-goal. `Evidence.md` is pending and non-normative until implementation.  
**Related:** Spec.md, API.md, API-xml.md, TEST-MATRIX.md, sample-preparer.md, Evidence.md, competitive-matrix.md

---

## 1. Product background

Syncfusion Blazor Toolkit is an MIT-licensed, open-source Blazor component set (.NET 8/9/10). Chart is the flagship. List is an evaluation roadmap item for layout and form primitives. It is not a Data Grid.

## 2. Problem statement

There is no Toolkit-native list that:

- Separates passive `role="list"` from selectable `role="listbox"` correctly
- Integrates CSS isolation and `SfThemeRoot`
- Ships virtualization, keyboard, Forced Colors, RTL, and measured accessibility evidence
- Matches leading Blazor list and listbox components on semantics and testability

## 3. User needs

| Need | Description |
|---|---|
| Correct semantics | Passive lists must not be exposed as listboxes |
| Selection | Single and multiple selection with bind, cancel, keyboard, and disabled rules |
| Checks | Checkable lists that do not imply selection |
| Rich content | Icons, avatars, supporting text, leading and trailing slots |
| Nesting | Expandable nested lists with keyboard access to nested interactive content |
| Scale | Virtualization for large lists with stable identity |
| Accessibility | WCAG 2.2 AA, including nested interactive content |
| Toolkit fit | Same conventions as existing Sf* components |

## 4. Target users

- App developers building dashboards, settings, navigation, and selection UIs
- Accessibility-focused teams
- Teams on Blazor Server, WebAssembly, static or interactive SSR, and Auto

## 5. Primary use cases

1. Settings and preference lists (single or multiple selection)
2. Navigation side lists (`Href`, `SelectionMode=None`)
3. Templated data lists (icons, avatars, supporting text)
4. Grouped lists
5. Virtualized large lists
6. Nested expandable lists

## 6. Secondary use cases

- Checkable task lists (`CheckMode` independent of selection)
- Action lists with trailing content
- Empty, loading, and error states

Checkable lists and nested expansion are required in v1. They are not future enhancements.

## 7. Goals

| Goal | Metric |
|---|---|
| Spec coverage | Every in-scope story has a retained test row |
| Automated accessibility | axe critical and serious = 0 on samples, once samples exist |
| Keyboard | Spec keyboard matrix covered by Playwright, including nested interactive content |
| Build quality | 0 compiler, analyzer, nullable, and XML-doc warnings on net8, net9, and net10 |
| Samples | Every primary and secondary scenario has an executable sample |
| Performance | Targets measured and published, or a deviation documented |
| Evidence | EV-001–EV-022 complete or waived with rationale |

These are release goals. None of them is claimed as met.

## 8. Non-goals (v1)

- Data Grid, TreeGrid, and Pivot
- Built-in edit or paging toolbar
- Built-in sort, filter, or search
- Drag-and-drop reorder
- Component-owned persistence or a storage key
- Horizontal layout
- Multi-theme providers
- AI surfaces
- Commercial Syncfusion suite parity

Consumers may sort, filter, or reorder their own collection before binding it. That is host behavior, not a list feature.

## 9. Functional requirements (summary)

Member names and defaults live only in `API.md`. Behavior lives in `Spec.md`.

- Static, data-bound, and generic `TItem`
- Separate field-name and typed selector mapping, with selector precedence
- Single and multiple selection, two-way bind, and cancellable change
- `CheckMode` and `CheckedValues`
- Item, group, header, footer, empty, loading, and error templates
- `IsLoading` and `HasError`, with error winning when both are true
- Grouping and nested expansion
- Virtualization with stable item identity
- Disabled items, icons, supporting text, and slots
- Keyboard behavior per semantic mode, with nested interactive content remaining reachable
- RTL from an ancestor `dir`, and localized built-in strings
- CSS isolation and theme tokens

## 10. Accessibility goals

WCAG 2.2 AA with measured evidence. Mode-correct roles, keyboard, focus, Forced Colors, and screen-reader announcements. Nested buttons and links must not become a keyboard trap. AAA only where the component can guarantee it. Axe alone does not prove assistive-technology compatibility.

The proposed focus model for selectable lists is roving `tabindex`. Finalize that choice during implementation review.

## 11. Performance goals (proposed; not measured)

| Scenario | Proposed target | Notes |
|---|---|---|
| Initial render of 100 simple items | median < 50 ms | After warm-up |
| Virtualized 5 000 items | Interactive scroll; no full-list DOM | `EnableVirtualization=true` |
| Selection update | Does not re-render the entire list | Item-level state |
| Create and dispose, 100 cycles | No growth beyond the noise floor | Memory evidence |

No runtime number in this document is a measured result.

## 12. Compatibility goals

| Surface | Goal |
|---|---|
| Target frameworks | net8.0, net9.0, net10.0 |
| Blazor Server | Supported |
| WebAssembly | Supported |
| Static SSR | Correct markup; interactivity after hydration |
| Interactive Server, WebAssembly, and Auto | Supported where the host supports them |
| Prerender and hydration | No id or role mismatch |
| Enhanced navigation | No broken state |
| Trimming and AOT | Prefer selectors over reflection field names |
| JavaScript disabled | A passive list remains readable; selection requires interactivity |

## 13. Developer experience goals

Predictable API, full XML docs, executable samples, and zero-warning builds. Invalid configuration produces a Development warning, not a production exception, except where `API.md` names an exception.

## 14. Competitive positioning

`competitive-matrix.md` is research only. It is not a requirement source. Undocumented competitor behavior is not proof of absence.

## 15. User stories

**US-01 Static list**  
Acceptance: `role=list`, list items, natural Tab, and an axe-clean sample once a sample exists.

**US-02 Data-bound text**  
Acceptance: items come from `DataSource`; `TextSelector` wins over `TextField`; collection changes update the UI.

**US-03 Item template and slots**  
Acceptance: icon, avatar, supporting text, and trailing content render without breaking isolation.

**US-04 Single select**  
Acceptance: pointer and keyboard select one item; `aria-selected`; `@bind-SelectedValue`; changing is cancellable.

**US-05 Multiple select**  
Acceptance: Ctrl toggle, Shift range, and Ctrl+A; disabled items are skipped; `@bind-SelectedValues`; event order is changing, then bind, then changed.

**US-06 Checkable**  
Acceptance: `CheckMode=Multiple`; `CheckedValues` binds; check is not selection unless the product wires both.

**US-07 Disabled**  
Acceptance: field, selector, or item `Disabled`; not selectable, checkable, or expandable; `aria-disabled`.

**US-08 Grouped**  
Acceptance: group field or selector plus group template; group structure is in the DOM and accessibility tree.

**US-09 Nested expand**  
Acceptance: nested list; `Expanded` bind; expansion changing can cancel; Left and Right; `aria-expanded`; nested interactive content stays in tab order.

**US-10 Navigation**  
Acceptance: `Href` items; `SelectionMode=None`; `role=list`, not listbox.

**US-11 Empty, loading, and error**  
Acceptance: empty template when there is no data; loading shows the loading template; error wins when both flags are true.

**US-12 Virtualization**  
Acceptance: large item count; limited DOM; off-screen selection retained; `ScrollIntoViewAsync` works.

**US-13 Programmatic API**  
Acceptance: `ClearSelection`, `SelectAll`, `FocusAsync`, and `ScrollIntoViewAsync` follow `API.md`.

**US-14 RTL**  
Acceptance: ancestor `dir=rtl`; mirrored layout; arrow keys reversed. No `EnableRtl` parameter.

**US-15 Localization**  
Acceptance: built-in empty and loading strings come from resources.

**US-16 Density and appearance**  
Acceptance: dense class applied; public CSS classes work with `SfThemeRoot`.

**US-17 Forced Colors and dark**  
Acceptance: selection, focus, and disabled remain visible without color-only encoding.

**US-18 Responsive**  
Acceptance: usable at 320px; touch targets at least 44px; reflow at 400% zoom.

**US-19 Assistive technology**  
Acceptance: accessibility-tree snapshots and NVDA, Narrator, and JAWS transcripts for core states, collected after implementation.

**US-20 Dynamic updates**  
Acceptance: insert, remove, and consumer-owned collection reorder preserve selection by identity. This is not component drag-and-drop.

**US-21 SSR and hydration**  
Acceptance: static SSR markup is valid; no hydration mismatch on ids or roles.

**US-22 Disposal**  
Acceptance: `DisposeAsync` is idempotent and clears registrations.

## 16. Success metrics

- Every in-scope story maps to a retained test row
- No open P0 or P1 at release
- Performance numbers published after measurement, or a documented deviation
- All samples executable
- Two maintainer approvals

Sorting, drag-and-drop, and persistence are not success metrics.

## 17. Risks and mitigations

| Risk | Mitigation |
|---|---|
| Focus and virtualization bugs | Early spike; focus-restore tests |
| Assistive-technology variance | Tree asserts and transcripts; no axe-only claims |
| Nested interactive content trapped by listbox focus | Proposed roving tabindex; nested controls stay in tab order |
| Scope creep toward a grid | Non-goals in section 8 |
| Reflection trim breaks field APIs | Prefer selectors; document trim guidance |
| API churn | This contract is proposed until implementation review accepts it |

## 18. Dependencies

- `src/Base` patterns and `SfThemeRoot`
- bUnit and Playwright projects
- Maintainer API review
- Feature discussion per CONTRIBUTING.md

## 19. Assumptions

- Single namespace and CSS isolation remain
- No Data Grid is in the Toolkit charter
- Blazor built-in `Virtualize` is the proposed virtualization mechanism unless a later decision says otherwise

## 20. Constraints

- Do not break existing components
- Zero warnings on the implementation, once it exists
- Branch from `development` and open the pull request into `development`
- Discussion before a large implementation pull request
- Two reviews

## 21. Release readiness

See Spec definition of done and Evidence.md EV-001–EV-022. Every evidence result stays pending until code and tests exist.

## 22. Future enhancements

These are not v1 requirements and have no acceptance criteria:

- Drag-and-drop reorder
- Built-in filter and search
- Built-in sort
- Component-owned persistence
- Horizontal layout
- Infinite scroll helpers
