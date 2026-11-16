# SfAutoComplete — Evidence Pack

| Field | Value |
|-------|-------|
| Component | SfAutoComplete\<TItem\> |
| Specs compared | Mud, Telerik, Radzen, Blazorise, Blazored, Havit, Fluent, Ant, DX ComboBox, Blazor Bootstrap |
| Branch | _pending_ |
| Method | Spec review + competitor docs/demos |
| Date | 2026-10-30 |
| Version | **1.1** |

---

## 1. Verdict

**Design contract aligned / runtime pending.**  
The API and test matrix describe a proposed component contract. No implementation or shipped API baseline exists in the repository at this revision; runtime, public-API, and CS1591 claims remain unverified.

---

## 2. Spec behavior table

| ID | Expected evidence | Result |
|----|-------------------|--------|
| S-01 | Unit: StartsWith | _pending_ |
| S-02 | Unit: Contains | _pending_ |
| S-03 | Unit: MinLength | _pending_ |
| S-04 | Unit: Debounce fake time | _pending_ |
| S-05 | Integration: CT cancel | _pending_ |
| S-06 | Integration: stale ignore | _pending_ |
| S-07 | Unit: ForceSelection blur | _pending_ |
| S-08 | Unit: free text | _pending_ |
| S-09 | Unit/E2E: clear | _pending_ |
| S-10 | E2E: keyboard select | _pending_ |
| S-11 | E2E: Escape | _pending_ |
| S-12 | axe + DOM assert expanded | _pending_ |
| S-13 | DOM assert activedescendant | _pending_ |
| S-14 | bUnit template | _pending_ |
| S-15 | bUnit no-results | _pending_ |
| S-16 | E2E loading | _pending_ |
| S-17 | bUnit EditContext | _pending_ |
| S-18 | Unit disabled/readonly | _pending_ |
| S-19 | E2E/visual RTL | _pending_ |
| S-20 | Markup scoped CSS | _pending_ |

---

## 3. Public API mapping

| API surface | Spec / API.md | Tests |
|-------------|---------------|-------|
| Value/Text/CommittedText and `TextChanged` | API §2; Spec §3 | U-AC-008..012, U-AC-041..043, I-AC-010, I-AC-012 |
| `ValueExpression` / EditContext | API §2; Spec §3 | U-AC-036, I-AC-003, I-AC-008 |
| SearchFunc, cancellation, precedence, failure | API §2; Spec §4 | U-AC-006..007, U-AC-030, U-AC-039..040, I-AC-001..002, I-AC-011, P-AC-006..007 |
| FilterType / CustomFilter / text resolution | API §2; Spec §4 | U-AC-001..004, U-AC-020..022, U-AC-037..038 |
| OpenOn, OpenOnFocus, ShowPopupButton | API §2; Spec §5 | U-AC-023..025, P-AC-014 |
| MaxLength, Name, ARIA labels, TabIndex | API §2; Spec §6 | U-AC-026..027, P-AC-013, P-AC-015 |
| OnOpen cancellation, OnClose, OnSearch | API §2; Spec §4–5 | U-AC-028..030 |
| Header/Footer/Loading templates | API §2 | U-AC-031..032 |
| FocusAsync / BlurAsync / ClearAsync | API §3 | U-AC-033..034 |
| MatchSegments / HighlightMatch | API §2 and §5 | U-AC-035, P-AC-016 |
| Static SSR and accessible combobox attributes | Spec §6, §8, §12 | I-AC-009, P-AXE-AC-001..007 |
| Phase 2 MaxItems / virtualization / grouping / adornments | API §2 | U-AC-013, U-AC-044..046 (P1; not MVP) |

---

## 4. TEST-MATRIX mapping

See `TEST-MATRIX.md` §§Phase and priority gates and Counting rule. It defines **92 unique planned test IDs**; P0 gates Phase 1 and P1 gates Phase 2. References in this Evidence document are citations, not additional tests.

### Six sample-browser demos

| Order | Demo | Description |
|---:|---|---|
| 1 | Default | Type-ahead selection from a local list with clear support for common form fields. |
| 2 | Remote data | Debounced asynchronous search with cancellation and loading state for directory-style lookups. |
| 3 | Templates | Customize suggestion rows, empty state, and popup chrome with match highlighting. |
| 4 | Force selection | Compare required list selection with free text and form validation. |
| 5 | Large list | Type-ahead over a large local collection with a suggestion limit; virtualization is Phase 2. |
| 6 | Form and states | Validation, disabled and read-only states, and right-to-left layout for production forms. |

---

## 5. Runtime record template

| Suite | Last run | Pass | Notes |
|-------|----------|------|-------|
| bUnit L1/L2 | | | |
| Playwright L3 | | | |
| axe L4 | | | |
| Visual L5 | | | |
| Build L6 | | | |

---

## 6. Competitor findings → design choices

| Finding | Choice |
|---------|--------|
| Mud CoerceText/CoerceValue complexity | Single **ForceSelection** + ResetValueOnEmptyText |
| Mud/Telerik debounce norms | Default **300** ms |
| Mud 9.12 stale results | **SearchVersion** + ignore stale |
| Telerik virtualization | Phase **2** not MVP |
| Blazorise multi-select | **Non-goal** MVP |
| Blazored template-required friction | Sensible default item render without required templates |
| APG combobox | Full list autocomplete; not toolbar |
| AOT | Prefer **DisplayTextFunc** |

---

## 7. Risks & mitigations

| Risk | Mitigation |
|------|------------|
| Popup positioning across SSR/hydrate | JS position only when interactive; tests on Server + WASM |
| Async race | Version + CTS (mandatory) |
| Reflection trim holes | Document TextField risk; promote DisplayTextFunc |
| Scope creep multi-select | Explicit non-goal |
| Over-large local lists | MaxItems + Phase 2 virtualization |

---

## 8. Notes (do not fail spec)

- Exact chevron icon asset is theme concern.  
- Live region politeness level may vary by SR; axe structural rules still apply.  

---

## 9. Implementation confidence checklist

- [x] ARIA pattern identified (combobox list)  
- [x] Filter pipeline ordered  
- [x] Cancel/stale policy  
- [x] Force vs free text  
- [x] Proposed Phase 1 API inventory aligned across design documents (shipment unverified)  
- [x] Tests layered with IDs  
- [x] Samples limited to 6  
- [ ] Runtime green (pending code)

---

## 10. Document history

| Version | Date | Notes |
|---------|------|-------|
| 1.0 | 2026-10-30 | Initial evidence pack |
| 1.1 | 2026-10-30 | Align API contract, phases, test IDs, static SSR, and sample descriptions; runtime remains pending. |