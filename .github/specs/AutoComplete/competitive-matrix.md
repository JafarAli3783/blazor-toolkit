# SfAutoComplete — Competitive Feature Matrix

Legend: **S** Supported · **P** Partial · **N** Not supported · **E** Exceeds (Toolkit target)

| Feature Area | Toolkit Target | MudBlazor | Telerik | Radzen | DevExpress ComboBox | Blazorise | Blazored Typeahead | Ant Design | Blazor Bootstrap | Fluent UI | Havit HxAutosuggest |
|--------------|----------------|-----------|---------|--------|---------------------|-----------|--------------------|------------|------------------|-----------|---------------------|
| Local filter StartsWith/Contains | S | S | S | S | S | S | P (app) | S | S | S | P |
| Custom / async SearchFunc | S | S | S (OnRead) | S (LoadData) | S | S | S | S | P | P | S |
| CancellationToken on search | S | S | P | P | P | P | N | N | N | N | P |
| Stale-result ignore | S | S (9.12+) | P | P | P | P | N | P | N | P | P |
| Debounce | S | S | S | S | S | S | S | S | P | P | S |
| MinLength | S | S | S | S | S | S | S | S | S | P | S |
| Force selection | S | S (Coerce*) | P | P | S | S (FreeTyping inv) | P | S | P | S | S |
| Free text | S | S | S | S | P | S | S | S | S | P | S |
| Open on focus | S | S | S | S | S | S | P | S | P | S | P |
| Clear button | S | S | S | S | S | S | S | S | S | S | S |
| Loading indicator | S | S | S | S | S | S | P | S | P | P | S |
| Item template | S | S | S | S | S | S | S | S | S | S | S |
| No-results template | S | S | S | S | S | S | S | S | P | P | S |
| Header/Footer template | S | S | P | P | S | P | S (Footer) | S | N | P | P |
| Match highlight | S | P | P | N | P | S | N | S | N | P | N |
| Grouping | Phase 2 | P | S | P | S | P | N | S | N | S | N |
| Virtualization | Phase 2 | N/P | S | N | S | S | N | S | N | P | N |
| Keyboard APG combobox | S | P–S | S | P | S | P | P | S | P | S | P |
| aria-activedescendant | S | P | S | P | S | P | P | S | P | S | P |
| EditContext validation | S | S | S | S | S | S | S | S | S | S | S |
| RTL | S | S | S | S | S | S | P | S | P | S | S |
| Multi-select | N (non-goal) | N | N* | S (multi) | S | S | N | S | N | S | N |
| MIT / no commercial lock-in | E | S | N | S | N | S | S | S | S | S | S |
| AOT/trim clean goal | E | P | P | P | P | P | P | N | P | P | P |
| Pure Blazor (min JS) | E | P | P | P | P | P | S | N | P | P | P |

\*Telerik AutoComplete is single-value; multi is other components.

---

## Gap analysis — where Toolkit can win

| Opportunity | Action |
|-------------|--------|
| Cancel + stale-safe remote search | First-class `SearchFunc(string, CancellationToken)` + version gate (match/exceed Mud 9.12) |
| Combobox a11y depth | Full APG list autocomplete; axe CI routes |
| AOT & trim | Prefer `DisplayTextFunc`; 0 trim warnings as gate |
| Force-select UX clarity | Single `ForceSelection` + documented blur/Escape (vs multiple Coerce* flags) |
| Zero commercial lock-in | MIT Toolkit path vs Telerik/DevExpress |
| Sample quality | 6 product-grade demos, not API scrapbook |
| Match highlight | Built-in optional highlight segments in item context |
| Virtualization + remote | Phase 2 explicit design (Telerik-class) without MVP delay |

## Competitor notes (summary)

- **MudBlazor:** Strong SearchFunc + cancel; coerce flags flexible; recent stale-result fixes. Multi not supported.  
- **Telerik:** Virtualization, filter operators, OnRead; commercial.  
- **Radzen:** FilterOperator, LoadData, OpenOnFocus, templates; free-text Value=string model.  
- **Blazorise:** FreeTyping, highlight, virtualize, multi — broader but heavier API.  
- **Blazored Typeahead:** Simple templates + SearchMethod; less polished a11y/maintenance.  
- **Havit:** HxAutosuggest / HxSearchBox — solid Bootstrap integration; fewer advanced list features.  
- **Fluent:** Strong a11y patterns; combobox oriented.  
- **Ant Design:** Behavior reference (highlight, options); not Blazor-native.