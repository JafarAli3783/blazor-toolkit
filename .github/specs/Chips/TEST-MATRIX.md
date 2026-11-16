# TEST-MATRIX.md — SfChip / SfChipSet
## Syncfusion Blazor Toolkit

| Field | Value |
|-------|--------|
| **Version** | 1.0-proposed |
| **Unit project** | `tests/Syncfusion.Blazor.Toolkit.BUnitTest` |
| **Browser project** | `tests/Syncfusion.Blazor.Playwright.Test` |
| **Minimum cases** | &gt;150 (inventory defines 400+ IDs; implement all P0/P1 before release) |
| **Fail on** | P0/P1 fail, warnings, axe critical/serious, sample console errors |

### CI commands (align to repo)

```text
dotnet restore
dotnet build ./src/Syncfusion.Blazor.Toolkit.slnx -c Release
dotnet test tests/Syncfusion.Blazor.Toolkit.BUnitTest -c Release --logger trx
dotnet test tests/Syncfusion.Blazor.Playwright.Test -c Release
```

---

## 1. Traceability

Parent IDs for these rows are in `TRACEABILITY.md`. A local `CHIP-U-*` / `CHIP-A-*` / `CHIP-P-*` ID is a test case, not a second requirement.

| Spec area | Test IDs |
|-----------|----------|
| Modes / semantics | CHIP-U-001–049, CHIP-A-001–020 |
| Selection | CHIP-U-050–089, CHIP-P-010–029 |
| Removal / focus | CHIP-U-090–119, CHIP-P-030–049 |
| Data / templates | CHIP-U-120–149 |
| Overflow | CHIP-U-150–164, CHIP-P-050–069 |
| Empty/loading/error | CHIP-U-165–179 |
| Forms | CHIP-U-180–189, CHIP-P-121–125 |
| CSS / attrs / RTL unit | CHIP-R-001–030 |
| Keyboard | CHIP-P-080–109 |
| Browser SSR | CHIP-P-110–120 |
| axe | CHIP-A-001–050 |
| Visual | CHIP-V-001–040 |
| Perf | CHIP-PERF-001–010 |

---

## 2. Case template (every automated case)

| Field | Content |
|-------|---------|
| ID | CHIP-* |
| Category | Unit / Browser / A11y / Visual / Perf / Render |
| Requirement | Spec section / FR id |
| Title | Short name |
| Purpose | Why |
| Preconditions | Setup |
| Test data | Inputs |
| Steps | Ordered |
| Expected | Observable result |
| Automation | bUnit / Playwright / axe / snapshot |
| Browser | N/A or Cr/FF/WK |
| A11y mode | N/A / keyboard / SR |
| Priority | P0 / P1 / P2 |
| CI group | unit / browser / a11y / visual / perf |
| Evidence | trx / trace / png / json |
| Pass/fail | asserts |
| Risks | flaky focus, measure, etc. |

---

## 3. Full P0 cases (explicit)

### CHIP-U-001
- **Category:** Unit · **Requirement:** Spec §6 Informational  
- **Title:** Informational chip is not a button  
- **Steps:** Render SfChip ChipType=Informational Text="Tag"  
- **Expected:** No `button`; no role=button; no tabindex≥0 on root  
- **Automation:** bUnit · **Priority:** P0 · **CI:** unit  

### CHIP-U-010
- **Title:** Action chip is type=button  
- **Expected:** `button[type=button]`; Enter invokes OnClick once  
- **Priority:** P0  

### CHIP-U-020
- **Title:** Filter sets aria-pressed  
- **Steps:** Toggle filter  
- **Expected:** aria-pressed true/false matches Selected  
- **Priority:** P0  

### CHIP-U-050
- **Title:** Single selection updates SelectedValue  
- **Expected:** Changing then Changed; value matches  
- **Priority:** P0  

### CHIP-U-055
- **Title:** SelectionChanging Cancel blocks update  
- **Expected:** No Changed; value unchanged  
- **Priority:** P0  

### CHIP-U-060
- **Title:** Multiple selection accumulates values  
- **Priority:** P0  

### CHIP-U-090
- **Title:** Removing Cancel keeps chip  
- **Priority:** P0  

### CHIP-U-095
- **Title:** After remove, focus moves to next chip  
- **Priority:** P0  

### CHIP-U-100
- **Title:** Removing last chip focuses previous  
- **Priority:** P0  

### CHIP-U-105
- **Title:** Remove button accessible name contains Remove + text  
- **Priority:** P0  

### CHIP-U-165
- **Title:** HasError wins over IsLoading  
- **Expected:** ErrorTemplate only  
- **Priority:** P0  

### CHIP-U-166
- **Title:** IsLoading hides items  
- **Priority:** P0  

### CHIP-P-001
- **Title:** Click action chip raises OnChipClick/OnClick  
- **Browser:** Cr/FF/WK · **Priority:** P0  

### CHIP-P-030
- **Title:** Click remove removes chip and restores focus  
- **Priority:** P0  

### CHIP-P-080
- **Title:** ArrowRight moves focus in LTR set  
- **Priority:** P0  

### CHIP-P-081
- **Title:** Arrow keys swap in RTL  
- **Priority:** P0  

### CHIP-P-090
- **Title:** Delete key removes focused removable chip  
- **Priority:** P0  

### CHIP-A-001
- **Title:** axe clean basic informational + action page  
- **Priority:** P0  

### CHIP-A-010
- **Title:** Remove button has accessible name  
- **Priority:** P0  

### CHIP-R-001
- **Title:** CssClass merged on root  
- **Priority:** P0  

### CHIP-P-110
- **Title:** Interactive sample hydrates without role/id mismatch  
- **Priority:** P0  

---

## 4. Complete ID inventory (each ID is a required scenario)

**Modes CHIP-U-001–049:** Informational not button; Status not button; Action button; Assist button; Filter pressed; Choice exclusive visual; Input token structure; Suggestion button; Navigation link with Href; Navigation without Href not link; Custom; Disabled each interactive mode; ReadOnly blocks remove; ReadOnly blocks select; Selected two-way standalone; IconCss renders; ImageUrl+Alt; decorative empty alt; AriaLabel overrides; ChildContent vs Text; LeadingTemplate; TrailingTemplate; RemoveTemplate is button; OnClick not on remove; Target on link; Size classes; Variant classes; Shape classes; pressed class; disabled class; readonly class; removable class; FocusAsync; FocusRemoveAsync; HtmlAttributes pass; Id stable; Style applied; null CssClass; multi CssClass; RTL class; long text; bidi text; whitespace text; click Action; keyboard Action; disabled Action no click; Suggestion click; Assist click (49).

**Selection CHIP-U-050–089:** Single select; Single clear AllowEmpty; Single !AllowEmpty; Multiple add; Multiple toggle off; Changing order; Changed once; Cancel; disabled item; readonly set; SelectAsync; SelectItemAsync; ClearSelection; SelectedValue bind; SelectedValues bind; ValueSelector; ItemKey refresh; duplicate key skip; initial invalid; filter multi sync; choice exclusive; remove selected updates selection; focus≠selection; null DataSource; empty list; rebind preserve; multi values unique; programmatic no-op readonly; clear no-op; selection class UI; deselect filter; select disabled no; data replace; value type string; value type int; selection after overflow expand; SelectionMode None ignores select; Choice+Multiple rejected or documented; set Disabled (40). Changing args: Current vs Proposed; cancel leaves selection unchanged

**Removal CHIP-U-090–119:** remove button; keyboard delete; keyboard backspace; programmatic; cancel; disabled; readonly; non-removable; event order; Removed once; focus next; focus prev; focus empty set; double remove; dispose during remove; RemovableSelector; default Removable; no OnChipClick; reason button; reason keyboard; reason programmatic; last chip; single chip; host list mutation; localized name; remove template; forced colors class; rapid clicks; Removing args Item; Removed args Key (30).

**Data/templates CHIP-U-120–149:** DataSource count; TextSelector; Fields.Text; selector wins; ItemKey; ChipTemplate; Leading; Trailing; Remove tpl; CssClassSelector; HrefSelector; Image selector; DisabledSelector; append; remove item; null ds; empty; string items; complex; refresh keys; AriaLabel+template; overflow tpl; declarative children; encode text; long text; bidi; nested content; Fields.Value; Fields.Disabled; Fields.Removable; ImageAlt (30).

**Overflow CHIP-U-150–164:** Wrap class; Scroll class; Collapse class; ExpandAsync; CollapseAsync; visible count; selected pinning unit; OverflowExpandedChanged; expand button present; collapse when expanded; scroll overflow-x; wrap flex-wrap; measure dispose; SSR all chips; expand keyboard (15).

**States CHIP-U-165–179:** Error over loading; loading hides; error hides; empty template; empty not when items; loading template; error template; retry pattern sample; precedence empty; haserror false shows items; isloading false; switch states; empty+loading loading wins; empty+error error; loading+error error (15).

**Forms CHIP-U-180–189:** EditContext register; required fail; required pass; notify on change; readonly field; disabled field; multi values form; clear form; validate on submit; field identifier (10).

**CHIP-R-001–030:** CssClass merge; Style; isolation; unmatched attrs; EnableRtl; data-*; no duplicate ids; not listbox; gap; sizes; shapes; variants; root e-chipset; child e-chip; remove class; selected class; overflow class; class empty; class null; html class merge; style null; id generate; id user; aria-label set; dir; deep optional; no leak global; consumer override; attribute override policy; disabled attr; aria-pressed (30).

**CHIP-P-001–009:** pointer action; filter toggle; choice; remove click; disabled; readonly; touch; nested isolation; double-click (9).

**CHIP-P-010–029:** multi mouse; single mouse; space; enter; cancel hook; programmatic UI; clear UI; bind roundtrip; refresh UI; filter set; choice set; disabled item UI; readonly UI; selected class; focus ring; aria-pressed UI; multi deselect; allow empty UI; !allow empty UI; selection changed once UI (20).

**CHIP-P-030–049:** remove btn; delete; backspace; cancel UI; focus next; focus prev; empty focus; overflow remove; scroll into view; remove last; remove first; keyboard then pointer; pointer then keyboard; removable false; readonly remove; disabled remove; reason path; multi remove sequential; announce path; restore after collapse expand (20).

**CHIP-P-050–069:** wrap; scroll; collapse; expand; collapse2; 320px; 400%; long label; mobile; narrow; tablet; desktop; overflow button; expand keyboard; selected visible; focused visible; rtl overflow; dark overflow; zoom collapse; resize (20).

**CHIP-P-070–079:** RTL layout; RTL arrows; dark; forced-colors; reduced motion; HC; dir inherit; l10n remove string; l10n more; l10n less (10).

**CHIP-P-080–109:** tab in; shift-tab; arrows LTR; home; end; space; enter; delete; backspace; no trap; nested input; RTL arrows; focus visible; many chips; skip disabled; readonly; filter kb; choice kb; action kb; nav link; escape; page keys ignored; type printable ignore/select; focus chip async UI; focus set; arrow from remove; tab to remove; shift from remove; composite (30).

**CHIP-P-110–125:** hydrate; server; wasm; console 0; forms validate; error UI; empty UI; loading UI; refresh; multi-browser; sample routes; no exception; enhanced nav; JS disabled passive; trim smoke notes; AOT notes (16).

**CHIP-A-001–050:** axe routes for each major sample state (basic, filter, choice, removable, disabled, readonly, loading, error, empty, rtl, dark, forced-colors, overflow, forms, templates, navigation, action, suggestion, input, status) + name/role/pressed/selected/focus/duplicate-id/contrast-on/remove-name/set-label/no-listbox/link/alt/decorative/status-passive/keyboard path/target size note/live region/nested/templates name/image/overflow button/expand name/collapse/selected state/disabled state/readonly/error alert/empty (50).

**CHIP-V-001–040:** snapshots listed in Spec visual section (info, action, filter on/off, choice, input, suggestion, nav, filled, outlined, sm/md/lg, pill, icon, image, trailing, selected, disabled, readonly, form invalid, chipset, wrap, scroll, collapse, expanded, empty, loading, error, dark, forced-colors, rtl, 320, 400zoom, long text, focus, hover, pressed, multirow, +N, leading, badge, toolbar) (40).

**CHIP-PERF-001–010:** N=1,10,50,100,500 render; selection 100; remove one of 100; bulk insert 50; collapse resize; dispose 100 cycles; template-heavy 50; SSR render 50; memory note; p95 record process (10). **Not yet measured.**

**Total IDs ≥ 430.**

---

## 5. CI groups

| Group | When | Scope |
|-------|------|--------|
| unit | every PR | bUnit |
| browser | every PR | Playwright functional |
| a11y | every PR | axe + roles |
| visual | main/nightly | snapshots |
| perf | nightly | CHIP-PERF |
| screen-reader-evidence | RC | AT package |

---

## 6. Exit criteria

- All P0/P1 pass on Cr/FF/WK  
- axe critical/serious 0  
- No chip warnings  
- Traceability complete  
- No manual-only Spec behavior without automation or approved SR script  
