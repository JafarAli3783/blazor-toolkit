# Chip evidence

| Field | Value |
|-------|--------|
| Component | `SfChip` and `SfChipSet<TItem>` |
| Specs compared | `Spec.md` 1.0-proposed, `API.md` 1.0.0-proposed, `PRD.md` 1.0, `TEST-MATRIX.md`, `API-xml.md` |
| Implementation branch | `bc/519d5657-description-consider` |
| Source | `src/Components/Buttons/Chips/` |
| Method | Source comparison plus runtime runs in this environment: bUnit on net8.0, Playwright Chromium, axe, visual baselines, and a Release library build with SBOM generation disabled. |
| Date | 2026-10-29 |

## Verdict

The implementation matches the Chip spec for public API, chip types, selection, removal, overflow, templates, forms, RTL, and CSS isolation.

Runtime results are in section 4.

## 1. Spec behavior

| ID | Requirement | Evidence | Result |
|----|-------------|----------|--------|
| S-01 | Passive chips are not buttons | `RootTag` is `span` unless the type is interactive or a navigation link. | Passed (source) |
| S-02 | Interactive chips use native `button` or `a` | Navigation with `Href` renders `a`. Other interactive types render `button type="button"`. | Passed (source) |
| S-03 | Filter and Choice expose `aria-pressed` | `RootAttributes` sets `aria-pressed` only for those types. | Passed (source) |
| S-04 | Selection is cancelable and does not mutate the source | `CommitSelectionAsync` returns when `SelectionChanging.Cancel` is set. | Passed (source) |
| S-05 | Choice with Multiple behaves as Single | `EffectiveMode` downgrades that combination. | Passed (source) |
| S-06 | Removal is cancelable and hides the chip | A canceled remove leaves the chip. A successful standalone remove renders nothing. A set chip is hidden by the set. | Passed (source) |
| S-07 | Remove does not raise activation | Remove click uses `stopPropagation` and does not call `OnClick`. | Passed (source) |
| S-08 | Disabled and read-only block removal | `RemoveDisabled` is `Disabled \|\| ReadOnly`. | Passed (source) |
| S-09 | Focus restores after set removal | `RequestRemoveAsync` sets `focusTargetId` from `ChipFocusCoordinator.Restore`. | Passed (source) |
| S-10 | Overflow Wrap, Scroll, and Collapse | Root class is `e-chipset-wrap`, `e-chipset-scroll`, or `e-chipset-collapse`. | Passed (source) |
| S-11 | Error, loading, and empty replace chips | `SfChipSet.razor` renders those templates before items. | Passed (source) |
| S-12 | Templates keep slot order | Leading, text, trailing, then the remove button. Author leading content suppresses the automatic check. | Passed (source) |
| S-13 | RTL stays on the set | `SfChipSet.RootAttributes` sets `dir="rtl"` and `e-rtl`. Each chip does not set `dir`. | Passed (source) |
| S-14 | Forms notify `EditContext` | `NotifyEditContext` uses `ValueExpression` after a committed selection change. | Passed (source) |
| S-15 | Theme and CSS isolation | Both roots emit `SfThemeRoot`. Generated slots and the remove button use `::deep`. | Passed (source) |
| S-16 | Close and check glyphs match the theme font | Default glyphs are `e-toolkit-icons e-close` and `e-toolkit-icons e-check`. | Passed (source) |
| S-17 | Static chips do not require a chip script | Click, selection, and removal stay in C#. JavaScript is imported for collapse measurement only. | Passed (source) |

## 2. Public API

| Item | Spec | Implementation | Result |
|------|------|----------------|--------|
| Components | `SfChip`, `SfChipSet<TItem>` | Both in `Syncfusion.Blazor.Toolkit` | Passed (source) |
| Enums | `ChipType`, `ChipSelectionMode`, `ChipVariant`, `ChipSize`, `ChipShape`, `ChipOverflowMode`, `ChipRemoveReason` with the specified numeric values | `ChipEnumerations.cs` matches | Passed (source) |
| `SfChip` parameters | Text, Value, ChipType, Variant, Size, Shape, IconCss, ImageUrl, ImageAlt, Href, Target, Rel, Selected, Removable, Disabled, ReadOnly, IsLoading, HasError, CssClass, Style, Id, ARIA parameters, TabIndex, HtmlAttributes, ChildContent, templates, EnableRtl | `SfChip.razor.Members.cs`. Defaults match `API.md`. | Passed (source) |
| `SfChip` events and methods | OnClick, SelectedChanged, Removing, Removed, `FocusAsync`, `FocusRemoveAsync` | Present with the argument types in `API.md` | Passed (source) |
| `SfChipSet` binding and selection | DataSource, selectors, Fields, ChildContent, SelectionMode, SelectedValue, SelectedValues, AllowEmpty, AllowDuplicates, MaxChips | `SfChipSet.razor.Members.cs` | Passed (source) |
| `SfChipSet` appearance, templates, events, and methods | ChipType through OverflowExpandedChanged, plus select, clear, focus, remove, expand, and collapse | Present with the documented defaults | Passed (source) |
| `ChipFields` and event arguments | Text, Value, Disabled, Removable, IconCss, ImageUrl, ImageAlt, CssClass, Href, and the five event argument types | `ChipFields.cs` and `ChipEventArgs.cs` | Passed (source) |

`HtmlAttributes` is a dictionary parameter. It is not `CaptureUnmatchedValues`. That matches `API.md`.

## 3. TEST-MATRIX cases

Matrix source: `.github/specs/Chips/TEST-MATRIX.md` (bUnit `CHIP-U-*`, Playwright `CHIP-P-*`, axe `CHIP-A-*`, visual `CHIP-V-*`).

### 3.1 bUnit (`CHIP-U-*`)

`tests/Syncfusion.Blazor.Toolkit.BUnitTest/Buttons/Chips/SfChipMatrixTest.cs` carries the matrix id in each test name. The Chip filter also includes the other Chip bUnit files.

### 3.2 Playwright (`CHIP-P-*`)

Specs under `Buttons/Chips` cover `CHIP-P-001`, `CHIP-P-030`, `CHIP-P-050`, `CHIP-P-080`, `CHIP-P-081`, `CHIP-P-090`, `CHIP-P-110`, and `CHIP-P-201` through `CHIP-P-207`.

### 3.3 axe (`CHIP-A-*`)

`accessibility/Blazor.Toolkit.AxeCore.Tests/Tests/ToolkitChipsTests.cs` has `CHIP-A-001` and `CHIP-A-010`.

### 3.4 Visual (`CHIP-V-*`)

Baselines live in `visual.spec.ts-snapshots/` for `CHIP-V-001` through `CHIP-V-008`.

## 4. Runtime record

Run on 2026-10-29 in this environment. The sample host ran in Release and the SBOM target was off (`-p:CycloneDxEnabled=false`).

| Suite | What was checked | Result |
|-------|------------------|--------|
| bUnit | `FullyQualifiedName~Chips`, net8.0, Release. | Passed. 163 passed, 0 failed, 0 skipped. |
| Playwright (Chromium) | All specs under `Buttons/Chips`: keyboard, overflow, scenarios, selection, and visual. | Passed. 22 passed, 0 failed. |
| axe | `FullyQualifiedName~ToolkitChipsTests`, 2 tests. | Passed. 2 passed, 0 failed. |
| Visual regression | `CHIP-V-001` through `CHIP-V-008` compared on Chromium. | Passed |
| Build | The net8.0 library built as part of the Chip bUnit Release run, with `CycloneDxEnabled=false`. | Build succeeded. Chip `IL2091` and `IDE0370` warnings were emitted. |

## 5. Notes that do not fail the spec

- `SfChip.EnableRtl` adds `e-rtl` only through the chip set. A standalone chip does not set `dir`.
- Selected Filter and Choice chips render `e-toolkit-icons e-check` in the leading slot when the author did not supply leading content.
- `DataSource` is not mutated when a chip is removed.
- Informational and Status chips stay spans. Passive chips do not get a hand cursor from the component.
- The two toolkit axe tests do not cover every `CHIP-A-*` id in the matrix.
