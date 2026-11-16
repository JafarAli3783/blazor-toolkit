# Competitive Matrix – SfList (Syncfusion Blazor Toolkit)

**Date:** 2026-10-28  
**Status:** Research only. This file is not a requirement source. A competitor cell marked N means the behavior was not found in the cited public docs; it is not proof that the product lacks the feature. `PRD.md` and `API.md` decide v1 scope.  
**Primary competitors evaluated:**
}<|tool_call|>
edit_file  
1. MudBlazor – MudList\&lt;T\&gt; / MudListItem\&lt;T\&gt; / MudListSubheader  
2. Telerik UI for Blazor – ListBox, ListView  
3. DevExpress Blazor – DxListBox  
4. Radzen Blazor – RadzenListBox, RadzenDataList  
5. Ant Design Blazor – List  
6. Blazorise – ListGroup, SelectList  
7. Blazor Bootstrap – List Group  
8. HAVIT Blazor – (list / selection patterns)  
9. Material.Blazor – (list / navigation patterns)  
10. Majorsoft Blazor Components – (list / collection patterns)

**Sources:** Public documentation and demos only (no source-code copying).

---

## Legend
- **Y** = Fully supported and publicly documented  
- **P** = Partial / limited  
- **N** = Not supported or not documented  
- **Sf** = Proposed Syncfusion Blazor Toolkit SfList behavior

---

## Feature Comparison Matrix

| Feature | MudBlazor | Telerik ListBox | Telerik ListView | DevExpress DxListBox | Radzen ListBox | Radzen DataList | Ant Design List | Blazorise | Blazor Bootstrap | SfList Proposal | Notes / Gap |
|---------|-----------|-----------------|------------------|----------------------|----------------|-----------------|-----------------|-----------|------------------|-----------------|-------------|
| Static item rendering | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Equal |
| Data-bound item rendering | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Equal |
| Generic data support | Y | Y | Y | Y | Y | Y | Y | Y | P | Y | Sf equal to best |
| Item templates | Y | Y | Y | Y | Y | Y | Y | Y | P | Y | Sf first-class |
| Header templates | P | N | Y | P | P | Y | Y | P | N | Y | Sf better |
| Footer templates | P | N | Y | P | P | Y | Y | P | N | Y | Sf better |
| Empty templates | P | P | P | P | P | P | Y | P | N | Y | Sf first-class |
| Loading templates | P | P | P | P | P | P | Y | P | N | Y | Sf first-class |
| Group templates | P | N | P | P | P | P | Y | N | N | Y | Sf strong |
| Nested / hierarchical lists | Y | N | N | N | N | N | P | N | N | Y | Sf matches Mud + better a11y |
| Single selection | Y | Y | N | Y | Y | N | N | Y | N | Y | Equal |
| Multiple selection | Y | Y | N | Y | Y | N | N | Y | N | Y | Equal |
| Selection via keyboard | Y | Y | N | Y | Y | N | N | P | N | Y | Sf full ARIA |
| Selection via pointer | Y | Y | N | Y | Y | N | N | Y | N | Y | Equal |
| Disabled items | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Equal |
| Read-only behavior | P | Y | P | Y | Y | P | P | P | N | Y | Sf explicit |
| Checkable items | Y | P | N | Y | P | N | N | P | N | Y | Sf first-class |
| Icons | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Equal |
| Avatars | Y | Y | Y | Y | Y | Y | Y | P | N | Y | Equal |
| Images | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Equal |
| Badges | P | P | P | P | P | P | Y | P | N | Y | Sf better |
| Supporting text | Y | Y | Y | Y | Y | Y | Y | P | N | Y | Equal |
| Leading / trailing content | Y | Y | Y | Y | Y | Y | Y | P | N | Y | Equal |
| Navigation links | Y | N | N | N | N | N | Y | Y | Y | Y | Sf supports Href |
| Custom attributes | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Equal |
| Custom CSS classes | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Equal + isolation |
| Per-item customization | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Equal |
| Event model | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Sf cancellable changing |
| Two-way binding | Y | Y | N | Y | Y | N | N | Y | N | Y | Equal |
| Programmatic selection | Y | Y | N | Y | Y | N | N | Y | N | Y | Equal |
| Programmatic focus | P | Y | P | Y | P | P | P | P | N | Y | Sf explicit API |
| Virtualization | P | P | P | P | P | P | P | N | N | Y | Sf first-class |
| Large-data performance | P | P | P | P | P | P | P | N | N | Y | Measured targets |
| Grouping | P | N | P | P | P | P | Y | N | N | Y | Sf strong |
| Sorting | N | N | N | N | N | N | N | N | N | N (consumer) | Out of v1. N means not found in cited docs, not proof of absence | |replace_all❌false|old_string_is_regex❌false|fuzzy_match_percent❌100|unicode_normalized❌false|replace_multiple_strings_in_single_turn❌true|string_replace_mode❌single_match|edit_type❌string_replace|mode❌string_replace|instructions❌|command❌|timeout❌|run_in_background❌false|description❌Fix sorting row in competitive matrix|file_path❌/workspace/blazor-toolkit/.github/specs/List/competitive-matrix.md|new_string❌| Sorting | N | N | N | N | N | N | N | N | N | N (consumer) | Out of v1. N means not found in cited docs, not proof of absence | |old_string❌| Sorting | N | N | N | N | N | N | N | N | N | Y | Sf first-class (consumer-optional) | |replace_all❌false|file_path_is_regex❌false|path❌/workspace/blazor-toolkit/.github/specs/List/competitive-matrix.md|content_is_regex❌false|content❌|pattern❌|glob❌*.md|max_count❌|output_mode❌content|offset❌0|limit❌2000|todos❌|subagent_type❌|title❌|body❌|draft❌|repo❌|repos❌|taskId❌|message❌|statusFilter❌|agentName❌|timeout_seconds❌|wait_ms_before_async❌|query❌|url❌|search_term❌|explanation❌|block_until_ms❌|timeout_ms❌|timeout_seconds_wait_for_background
| Filtering | N | N | N | N | N | N | N | N | N | N (consumer) | Out of scope |
| Search integration | N | N | N | N | N | N | N | N | N | N (consumer) | Out of scope |
| Drag-and-drop | N | Y | N | P | P | N | N | N | N | N (consumer) | Out of v1. Cited docs are not proof of absence |
| Reordering | N | Y | N | P | P | N | N | N | N | N (consumer) | Out of v1. Host may reorder its own collection |
| Responsive layout | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Container-aware |
| Mobile usability | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Touch targets 44px |
| Touch interaction | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Equal |
| RTL | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Logical properties |
| Localization | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | No hard-coded strings |
| CSS isolation | Y | P | P | P | P | P | P | P | P | Y | Native Toolkit |
| Theme integration | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | SfThemeRoot tokens |
| High Contrast mode | P | P | P | P | P | P | P | P | P | Y | Forced Colors tested |
| Dark mode | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Theme tokens |
| Reduced-motion support | P | P | P | P | P | P | P | P | P | Y | Explicit |
| Keyboard accessibility | Y | Y | P | Y | Y | P | P | P | P | Y | Full per mode |
| Screen reader support | Y | Y | P | Y | Y | P | P | P | P | Y | Evidence process |
| ARIA implementation | Y | Y | P | Y | Y | P | P | P | P | Y | Mode-correct |
| WCAG support | Y (claimed) | Y (claimed) | Y | Y | Y | Y | Y | Y | Y | Y (AA + evidence) | Measured |
| State persistence | P | P | P | P | P | P | P | N | N | N (host) | Out of v1. No component-owned storage key |
| Server-side rendering | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Static SSR friendly |
| Blazor Server | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Equal |
| Blazor WebAssembly | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Equal |
| Static SSR | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | No mismatch |
| Interactive SSR | Y | Y | Y | Y | Y | Y | Y | Y | Y | Y | Equal |
| No-JavaScript behavior | P | P | P | P | P | P | P | P | P | Y | Pure Blazor preferred |
| Testing coverage | Good | Good | Good | Good | Good | Good | Good | Medium | Medium | Excellent | bUnit + Playwright + a11y |
| API consistency | High | High | High | High | High | High | High | Medium | Medium | High | Toolkit conventions |
| Extensibility | High | High | High | High | High | High | High | Medium | Medium | High | Templates + slots |
| Performance | Good | Good | Good | Good | Good | Good | Good | Medium | Medium | Target leading | Virtualization + keys |
| Developer experience | Excellent | Excellent | Excellent | Excellent | Excellent | Excellent | Good | Good | Good | Excellent | Samples + XML docs |

---

## Gap Analysis

**Strengths of competitors**
- MudBlazor: best nested-list + selection-mode DX
- Telerik ListBox: strongest reordering / transfer / toolbar
- Telerik ListView: strongest templated repeater + paging/editing
- DevExpress / Radzen: solid form-control ListBox behavior
- Ant Design: good empty/loading and meta content

**Weaknesses across the set**
- Incorrect or missing distinction between passive list and listbox semantics
- Incomplete Forced Colors / High Contrast validation
- Virtualization often partial or absent
- Accessibility evidence rarely published at the level of the Toolkit’s process
- CSS isolation and single-token theme integration not native

**SfList differentiators**
1. Correct semantic mode switching (list vs listbox)
2. First-class virtualization with stable identity
3. Full keyboard + ARIA matrix per mode
4. Native CSS isolation + SfThemeRoot tokens
5. Explicit Forced Colors, reduced-motion, RTL, localization
6. Autonomous test matrix aligned with existing bUnit + Playwright infrastructure
7. Measurable performance targets and evidence process

---

## Final Recommendations

- Baseline UX and selection model on MudBlazor List.
- Add Telerik-style programmatic APIs where they do not force listbox semantics.
- Exceed every competitor on accessibility evidence, Forced Colors, virtualization identity, and Toolkit-native styling.
- Keep v1 free of drag-and-drop, built-in sorting or filtering, and component-owned persistence.
- Public API must stay minimal and consistent with existing Sf* components.
- This matrix does not add requirements. If a row conflicts with `PRD.md` or `API.md`, those files win.
