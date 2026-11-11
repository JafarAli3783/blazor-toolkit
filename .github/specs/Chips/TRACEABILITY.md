## Chip traceability

| Field | Value |
|-------|--------|
| **Status** | Mapping only. Not evidence. |
| **Component contract** | `Spec.md`, `API.md`, `PRD.md`, `TEST-MATRIX.md` |
| **Parents** | spec-kit `component-specifications/chip/` |
| **Toolkit override** | spec-kit `component-specifications/chip/framework-overrides/blazor-toolkit.md` |
| **Not the contract** | spec-kit `framework-overrides/blazor.md` (commercial) |

Local test IDs stay in `TEST-MATRIX.md`. This file only names the parent each area implements, deviates from, or does not implement.

| Parent | Toolkit contract | Status |
|--------|------------------|--------|
| `CHIP-SEL-001`, `CHIP-SEL-002` | `ChipSelectionMode.Single` / `Multiple` | met |
| `CHIP-SEL-003`, `CHIP-SEL-004` | `SelectedValue` / `SelectedValues` | met by key/value, not by chip instance |
| `CHIP-SEL-005`, `CHIP-EDIT-010` | `AllowEmpty` default true | deviated — zero-or-one is the default |
| `CHIP-SEL-006` | Selected value is the item key/value | deviated — not the commercial data-item chip instance |
| `CHIP-SEL-007` | Selection owned by the set | met |
| `CHIP-SEL-008`–`CHIP-SEL-011` | `SelectionChanging` then `SelectionChanged` | met |
| `CHIP-SEL-012` | `ChipSelectionMode.None`; Action does not select | met |
| `CHIP-SEL-013`, `CHIP-CMD-001`–`CHIP-CMD-005` | `OnClick` / `OnChipClick` on activation | met when keyboard activation raises the same event |
| `CHIP-DEL-001`, `CHIP-DEL-004`, `CHIP-BLZ-012` | Removable flag orthogonal to selection | met |
| `CHIP-DEL-002`, `CHIP-DEL-003`, `CHIP-DEL-005` | `Removing` / `Removed` | met — cancel blocks removal |
| `CHIP-EDIT-001`–`CHIP-EDIT-008`, `CHIP-BLZ-013` | No typed editor on the chip | n/a — host composition only |
| `CHIP-DRAG-*`, translucent effect | Out of scope | n/a |
| `CHIP-A11Y-001`, `CHIP-A11Y-003`, `CHIP-A11Y-006` | Native `button` / `a` / `span` per Spec §6; native `disabled` | deviated — do not force `listbox` / `option` |
| `CHIP-A11Y-002`, `CHIP-A11Y-005`, `CHIP-A11Y-007`, `CHIP-A11Y-008` | Disabled, contrast, reduced motion, forced colors | in scope; evidence not collected |
| `CHIP-A11Y-004` | Drag keyboard | n/a |
| `CHIP-BLZ-010` | `SfChip` and `SfChipSet<TItem>` child content | met by this type pair, not commercial type names |
| `CHIP-BLZ-011` | `ChipSelectionMode` | met |
| `CHIP-BLZ-020` | Commercial `Created` / `Destroyed` | n/a |
| `CHIP-BLZ-021` | Dispose subscriptions when removed from the render tree | met — no public Destroyed event |
| `CHIP-BLZ-022` | Server, WASM, static SSR markup, interactive SSR | met as Compatibility in Spec §28 |
| Overflow, empty/loading/error, templates, `EditContext` | Spec §4, §11, §14, §19 | extension — no generic parent; do not mark a `CHIP-*` passed for these |
| `PERF-SEL-*`, `PERF-DRAG-*`, `PERF-INPUT-*` | Toolkit perf rows in `TEST-MATRIX.md` | unmapped — do not mark a generic `PERF-*` passed |
