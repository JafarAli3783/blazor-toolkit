using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Toolkit.Internal;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Syncfusion.Blazor.Toolkit
{
    /// <summary>
    /// A set of chips bound to <typeparamref name="TItem"/> or composed from <see cref="SfChip"/> children.
    /// </summary>
    /// <typeparam name="TItem">Data item type. Use <see cref="string"/> for declarative-only sets.</typeparam>
    /// <remarks>
    /// The parent owns <see cref="SfChipSet{TItem}.DataSource"/>. Removal hides a chip; it does not mutate the source.
    /// <see cref="SfChipSet{TItem}.MaxChips"/> and <see cref="SfChipSet{TItem}.AllowDuplicates"/> are host policy and never drop bound items.
    /// </remarks>
    public partial class SfChipSet<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] TItem> : SfBaseComponent, IChipSetRegistration
    {
        private readonly List<ProjectedChip> _projected = [];
        private readonly List<object> _removedKeys = [];
        private readonly List<DeclarativeChip> _declarative = [];
        private IJSObjectReference? _chipModule;
        private ElementReference _rootReference;
        private int _focusedIndex;
        private int _hiddenCount;
        private bool _overflowExpanded;
        private bool _choiceWarned;
        private bool _jsReady;
        private string? _focusTargetId;

        private string RootId => string.IsNullOrEmpty(Id) ? $"chipset-{GetHashCode():x}" : Id;

        private bool HasItems => DataSource?.Any() == true || _declarative.Count > 0 || ChildContent is not null;

        private ChipSelectionMode EffectiveMode
        {
            get
            {
                if (ChipType == ChipType.Choice && SelectionMode == ChipSelectionMode.Multiple)
                {
                    if (!_choiceWarned)
                    {
                        _choiceWarned = true;
                        Debug.WriteLine("SfChipSet Choice with ChipSelectionMode.Multiple behaves as Single.");
                    }

                    return ChipSelectionMode.Single;
                }

                return SelectionMode;
            }
        }

        private IEnumerable<ProjectedChip> VisibleChips => _projected.Where(chip => !chip.Removed);

        /// <summary>Id the focus coordinator would move to after the last removal. bUnit asserts this; Playwright asserts document.activeElement.</summary>
        public string? FocusTargetId => _focusTargetId;

        /// <summary>Selects a value through the cancelable selection pipeline.</summary>
        public ValueTask SelectAsync(object? value)
        {
            return CommitSelectionAsync(default!, value, false);
        }

        /// <summary>Selects an item through the cancelable selection pipeline.</summary>
        public ValueTask SelectItemAsync(TItem item)
        {
            object? value = ValueSelector is not null ? ValueSelector(item) : item;
            return CommitSelectionAsync(item, value, false);
        }

        /// <summary>Clears selection when <see cref="SfChipSet{TItem}.AllowEmpty"/> allows it.</summary>
        public ValueTask ClearSelectionAsync()
        {
            return CommitSelectionAsync(default!, null, true);
        }

        /// <summary>Moves focus to the set root.</summary>
        public ValueTask FocusAsync()
        {
            return _rootReference.FocusAsync();
        }

        /// <summary>Moves focus to the chip with the given key when it is rendered.</summary>
        public ValueTask FocusChipAsync(object key)
        {
            ProjectedChip? chip = _projected.FirstOrDefault(item => ChipKeyComparer.Instance.Equals(item.Model.Key, key) && !item.Removed);
            _focusedIndex = chip is null ? _focusedIndex : _projected.IndexOf(chip);
            _focusTargetId = chip?.ElementId;
            return chip?.Chip is null ? ValueTask.CompletedTask : chip.Chip.FocusAsync();
        }

        /// <summary>Removes a chip by key. Does not mutate <see cref="SfChipSet{TItem}.DataSource"/>.</summary>
        public ValueTask RemoveAsync(object key)
        {
            return RequestRemoveAsync(key, default!, ChipRemoveReason.Programmatic);
        }

        /// <summary>Removes a chip by item.</summary>
        public ValueTask RemoveItemAsync(TItem item)
        {
            object key = ItemKey is not null ? ItemKey(item) : item!;
            return RequestRemoveAsync(key, item, ChipRemoveReason.Programmatic);
        }

        /// <summary>Expands collapsed overflow and raises <see cref="SfChipSet{TItem}.OverflowExpandedChanged"/> only on change.</summary>
        public ValueTask ExpandOverflowAsync()
        {
            return SetOverflowAsync(true);
        }

        /// <summary>Collapses overflow and raises <see cref="SfChipSet{TItem}.OverflowExpandedChanged"/> only on change.</summary>
        public ValueTask CollapseOverflowAsync()
        {
            return SetOverflowAsync(false);
        }

        void IChipSetRegistration.Register(DeclarativeChip chip)
        {
            Register(chip);
        }

        void IChipSetRegistration.Unregister(string id)
        {
            Unregister(id);
        }

        async Task IChipSetRegistration.ActivateAsync(object? key, MouseEventArgs args)
        {
            DeclarativeChip? child = FindChild(key);
            await OnChipClick.InvokeAsync(new ChipClickEventArgs<TItem>
            {
                Key = child?.Key ?? key,
            }).ConfigureAwait(true);
            if (EffectiveMode != ChipSelectionMode.None && !Disabled && !ReadOnly && child?.Disabled != true)
            {
                await CommitSelectionAsync(default!, child?.Value ?? key, false).ConfigureAwait(true);
            }
        }

        Task IChipSetRegistration.RemoveChildAsync(object? key, ChipRemoveReason reason)
        {
            DeclarativeChip? child = FindChild(key);
            return RequestRemoveAsync(child?.Key ?? key ?? string.Empty, default!, reason).AsTask();
        }

        private DeclarativeChip? FindChild(object? key)
        {
            return _declarative.FirstOrDefault(item =>
                ChipKeyComparer.Instance.Equals(item.Key, key)
                || ChipKeyComparer.Instance.Equals(item.Value, key)
                || ChipKeyComparer.Instance.Equals(item.Id, key));
        }

        internal void Register(DeclarativeChip chip)
        {
            DeclarativeChip? existing = _declarative.FirstOrDefault(item => item.Id == chip.Id);
            if (existing is null)
            {
                _declarative.Add(chip);
                return;
            }

            existing.Key = chip.Key;
            existing.Value = chip.Value;
            existing.Text = chip.Text;
            existing.Disabled = chip.Disabled;
            existing.Removable = chip.Removable;
            existing.Chip = chip.Chip;
        }

        internal void Unregister(string id)
        {
            _ = _declarative.RemoveAll(item => item.Id == id);
        }

        private RenderFragment RenderProjected(ProjectedChip chip)
        {
            return builder =>
            {
                int seq = 0;
                builder.OpenComponent<SfChip>(seq++);
                builder.AddAttribute(seq++, "Id", chip.ElementId);
                builder.AddAttribute(seq++, "Text", chip.Model.Text);
                builder.AddAttribute(seq++, "Value", chip.Model.Value);
                builder.AddAttribute(seq++, "ChipType", ChipType);
                builder.AddAttribute(seq++, "TabIndex", chip.TabIndex);
                builder.AddAttribute(seq++, "Variant", Variant);
                builder.AddAttribute(seq++, "Size", Size);
                builder.AddAttribute(seq++, "Shape", Shape);
                builder.AddAttribute(seq++, "IconCss", chip.Model.IconCss);
                builder.AddAttribute(seq++, "ImageUrl", chip.Model.ImageUrl);
                builder.AddAttribute(seq++, "ImageAlt", chip.Model.ImageAlt);
                builder.AddAttribute(seq++, "Href", chip.Model.Href);
                builder.AddAttribute(seq++, "CssClass", chip.Model.CssClass);
                builder.AddAttribute(seq++, "Selected", IsSelected(chip.Model.Value));
                builder.AddAttribute(seq++, "Disabled", Disabled || chip.Model.Disabled);
                builder.AddAttribute(seq++, "ReadOnly", ReadOnly);
                builder.AddAttribute(seq++, "Removable", chip.Model.Removable);
                builder.AddAttribute(seq++, "EnableRtl", EnableRtl);
                if (ChipTemplate is not null)
                {
                    builder.AddAttribute(seq++, "ChildContent", ChipTemplate(chip.Item));
                }
                if (LeadingTemplate is not null)
                {
                    builder.AddAttribute(seq++, "LeadingTemplate", LeadingTemplate(chip.Item));
                }
                if (TrailingTemplate is not null)
                {
                    builder.AddAttribute(seq++, "TrailingTemplate", TrailingTemplate(chip.Item));
                }
                if (RemoveTemplate is not null)
                {
                    builder.AddAttribute(seq++, "RemoveTemplate", RemoveTemplate(chip.Item));
                }
                builder.AddAttribute(seq++, "OnClick", EventCallback.Factory.Create<MouseEventArgs>(this, _ => OnProjectedClickAsync(chip)));
                builder.AddAttribute(seq++, "Removing", EventCallback.Factory.Create<ChipRemovingEventArgs>(this, args => OnProjectedRemovingAsync(chip, args)));
                builder.AddComponentReferenceCapture(seq++, instance => chip.Chip = (SfChip)instance);
                builder.CloseComponent();
            };
        }

        private bool IsSelected(object? value)
        {
            return ChipSelectionStore.Current(EffectiveMode, SelectedValue, SelectedValues)
                .Any(item => ChipKeyComparer.Instance.Equals(item, value));
        }

        private async Task OnProjectedClickAsync(ProjectedChip chip)
        {
            await OnChipClick.InvokeAsync(new ChipClickEventArgs<TItem>
            {
                Item = chip.Item,
                Key = chip.Model.Key,
            }).ConfigureAwait(true);
            if (EffectiveMode != ChipSelectionMode.None && !Disabled && !ReadOnly && !chip.Model.Disabled)
            {
                await CommitSelectionAsync(chip.Item, chip.Model.Value, false).ConfigureAwait(true);
            }
        }

        private async Task OnProjectedRemovingAsync(ProjectedChip chip, ChipRemovingEventArgs args)
        {
            await RequestRemoveAsync(chip.Model.Key, chip.Item, args.Reason).ConfigureAwait(true);
            args.Cancel = true;
        }

        private async ValueTask CommitSelectionAsync(TItem item, object? value, bool clear)
        {
            if (Disabled || ReadOnly || EffectiveMode == ChipSelectionMode.None)
            {
                return;
            }

            IReadOnlyList<object?> current = ChipSelectionStore.Current(EffectiveMode, SelectedValue, SelectedValues);
            IReadOnlyList<object?> proposed = ChipSelectionStore.Propose(EffectiveMode, AllowEmpty, current, value, clear);
            if (ChipSelectionStore.Same(current, proposed))
            {
                return;
            }

            ChipSelectionChangingEventArgs<TItem> changing = new()
            {
                Item = item,
                Value = value,
                CurrentSelectedValues = current,
                ProposedSelectedValues = proposed,
            };
            await SelectionChanging.InvokeAsync(changing).ConfigureAwait(true);
            if (changing.Cancel)
            {
                return;
            }

            if (EffectiveMode == ChipSelectionMode.Single)
            {
                SelectedValue = proposed.Count == 0 ? null : proposed[0];
                await SelectedValueChanged.InvokeAsync(SelectedValue).ConfigureAwait(true);
            }
            else
            {
                SelectedValues = [.. proposed];
                await SelectedValuesChanged.InvokeAsync(SelectedValues).ConfigureAwait(true);
            }

            await SelectionChanged.InvokeAsync(new ChipSelectionChangedEventArgs<TItem>
            {
                Item = item,
                Value = value,
                SelectedValues = proposed,
            }).ConfigureAwait(true);
            NotifyEditContext();
        }

        private async ValueTask RequestRemoveAsync(object key, TItem item, ChipRemoveReason reason)
        {
            if (Disabled || ReadOnly)
            {
                return;
            }

            ProjectedChip? chip = _projected.FirstOrDefault(itemChip => ChipKeyComparer.Instance.Equals(itemChip.Model.Key, key) && !itemChip.Removed);
            if (chip is not null && !chip.Model.Removable)
            {
                return;
            }

            ChipRemovingEventArgs<TItem> removing = new()
            {
                Item = chip is null ? item : chip.Item,
                Text = chip?.Model.Text,
                Key = key,
                Reason = reason,
            };
            await Removing.InvokeAsync(removing).ConfigureAwait(true);
            if (removing.Cancel)
            {
                return;
            }

            if (!_removedKeys.Any(existing => ChipKeyComparer.Instance.Equals(existing, key)))
            {
                _removedKeys.Add(key);
            }

            if (chip?.Model.Value is not null && !_removedKeys.Any(existing => ChipKeyComparer.Instance.Equals(existing, chip.Model.Value)))
            {
                _removedKeys.Add(chip.Model.Value);
            }

            int index = chip is null ? _focusedIndex : _projected.IndexOf(chip);
            Rebuild();
            StateHasChanged();
            int next = ChipFocusCoordinator.Restore(index, _projected.Count, CanFocus);
            _focusedIndex = next;
            _focusTargetId = next < 0 ? RootId : _projected[next].ElementId;
            await Removed.InvokeAsync(new ChipRemovedEventArgs<TItem>
            {
                Item = removing.Item,
                Text = removing.Text,
                Key = key,
                Reason = reason,
            }).ConfigureAwait(true);
        }

        private bool CanFocus(int index)
        {
            return index >= 0 && index < _projected.Count && !_projected[index].Removed && !_projected[index].Model.Disabled && !Disabled;
        }

        private void NotifyEditContext()
        {
            if (EditContext is null || ValueExpression is null || ReadOnly || Disabled)
            {
                return;
            }

            EditContext.NotifyFieldChanged(FieldIdentifier.Create(ValueExpression));
        }

        private async Task OnKeyDownAsync(KeyboardEventArgs args)
        {
            int count = _projected.Count;
            int next = args.Key switch
            {
                "ArrowRight" or "ArrowDown" => ChipFocusCoordinator.Move(_focusedIndex, count, EnableRtl && args.Key == "ArrowRight" ? -1 : 1, CanFocus),
                "ArrowLeft" or "ArrowUp" => ChipFocusCoordinator.Move(_focusedIndex, count, EnableRtl && args.Key == "ArrowLeft" ? 1 : -1, CanFocus),
                "Home" => ChipFocusCoordinator.Edge(count, false, CanFocus),
                "End" => ChipFocusCoordinator.Edge(count, true, CanFocus),
                _ => _focusedIndex,
            };
            if (next != _focusedIndex && next >= 0)
            {
                _focusedIndex = next;
                ProjectedChip chip = _projected[next];
                _focusTargetId = chip.ElementId;
                if (chip.Chip is not null)
                {
                    await chip.Chip.FocusAsync().ConfigureAwait(true);
                }
            }
        }

        private async Task ToggleOverflowAsync()
        {
            await SetOverflowAsync(!_overflowExpanded).ConfigureAwait(true);
        }

        private async ValueTask SetOverflowAsync(bool expanded)
        {
            if (_overflowExpanded == expanded)
            {
                return;
            }

            _overflowExpanded = expanded;
            ApplyCollapse();
            StateHasChanged();
            await OverflowExpandedChanged.InvokeAsync(expanded).ConfigureAwait(true);
        }

        private void Rebuild()
        {
            Dictionary<object, SfChip> chips = _projected
                .Where(chip => chip.Chip is not null)
                .GroupBy(chip => chip.Model.Key, ChipKeyComparer.Instance)
                .ToDictionary(group => group.Key, group => group.First().Chip!, ChipKeyComparer.Instance);
            _projected.Clear();
            if (DataSource is null)
            {
                int childIndex = 0;
                foreach (DeclarativeChip child in _declarative)
                {
                    _projected.Add(new ProjectedChip
                    {
                        Model = new ChipModel
                        {
                            Key = child.Key ?? child.Id,
                            Value = child.Value ?? child.Text,
                            Text = child.Text ?? string.Empty,
                            Disabled = child.Disabled,
                            Removable = child.Removable,
                        },
                        ElementId = child.Id,
                        Chip = child.Chip,
                        Removed = _removedKeys.Any(existing => ChipKeyComparer.Instance.Equals(existing, child.Key ?? child.Id) || ChipKeyComparer.Instance.Equals(existing, child.Value)),
                        TabIndex = childIndex == _focusedIndex ? 0 : -1,
                    });
                    childIndex++;
                }

                ApplyCollapse();
                return;
            }

            IReadOnlyList<ChipModel> models = ChipFieldResolver.Resolve(
                DataSource,
                ItemKey,
                TextSelector,
                ValueSelector,
                DisabledSelector,
                RemovableSelector,
                IconCssSelector,
                ImageUrlSelector,
                ImageAltSelector,
                HrefSelector,
                CssClassSelector,
                Fields,
                Removable);
            int index = 0;
            foreach (ChipModel model in models)
            {
                _projected.Add(new ProjectedChip
                {
                    Item = DataSource.ElementAt(index),
                    Model = model,
                    ElementId = $"{RootId}-chip-{index}",
                    Chip = chips.TryGetValue(model.Key, out SfChip? existing) ? existing : null,
                    Removed = _removedKeys.Any(existingKey => ChipKeyComparer.Instance.Equals(existingKey, model.Key) || ChipKeyComparer.Instance.Equals(existingKey, model.Value)),
                    TabIndex = index == _focusedIndex ? 0 : -1,
                });
                index++;
            }

            ApplyCollapse();
        }

        private void ApplyCollapse()
        {
            IEnumerable<ProjectedChip> visible = [.. _projected.Where(chip => !chip.Removed)];
            foreach (ProjectedChip chip in _projected)
            {
                chip.Collapsed = false;
            }

            if (OverflowMode != ChipOverflowMode.Collapse || _overflowExpanded)
            {
                _hiddenCount = 0;
                return;
            }

            int keep = CollapsedVisibleCount ?? visible.Count();
            int shown = 0;
            foreach (ProjectedChip chip in visible)
            {
                bool pin = IsSelected(chip.Model.Value);
                if (!pin && shown >= keep)
                {
                    chip.Collapsed = true;
                }
                else
                {
                    shown++;
                }
            }

            _hiddenCount = visible.Count(chip => chip.Collapsed);
        }

        private Dictionary<string, object> RootAttributes()
        {
            Dictionary<string, object> attributes = new(StringComparer.OrdinalIgnoreCase);
            if (HtmlAttributes is not null)
            {
                foreach (KeyValuePair<string, object> pair in HtmlAttributes)
                {
                    attributes[pair.Key] = pair.Value;
                }
            }

            string overflowClass = OverflowMode switch
            {
                ChipOverflowMode.Wrap => "e-chipset-wrap",
                ChipOverflowMode.Scroll => "e-chipset-scroll",
                ChipOverflowMode.Collapse => "e-chipset-collapse",
                _ => "e-chipset-wrap",
            };
            attributes["id"] = RootId;
            attributes["class"] = string.Join(' ', new[] { "e-chipset", overflowClass, EnableRtl ? "e-rtl" : string.Empty, CssClass }.Where(token => !string.IsNullOrWhiteSpace(token)));
            attributes["data-testid"] = "chipset-root";
            attributes["data-selection"] = EffectiveMode.ToString();
            attributes["tabindex"] = "-1";
            if (!string.IsNullOrEmpty(Style))
            {
                attributes["style"] = Style;
            }

            if (!string.IsNullOrEmpty(AriaLabel))
            {
                attributes["aria-label"] = AriaLabel;
            }

            if (!string.IsNullOrEmpty(AriaLabelledBy))
            {
                attributes["aria-labelledby"] = AriaLabelledBy;
            }

            if (EnableRtl || SyncfusionService?._options.EnableRtl == true)
            {
                attributes["dir"] = "rtl";
            }

            if (Disabled)
            {
                attributes["aria-disabled"] = "true";
            }

            if (ReadOnly)
            {
                attributes["aria-readonly"] = "true";
            }

            return attributes;
        }

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            Rebuild();
        }

        /// <inheritdoc />
        [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "chip.js receives element ids only.")]
        internal override async Task ImportComponentModuleAsync()
        {
            await base.ImportComponentModuleAsync().ConfigureAwait(true);
            if (JSRuntime is null || OverflowMode != ChipOverflowMode.Collapse)
            {
                return;
            }

            IJSObjectReference module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Syncfusion.Blazor.Toolkit/scripts/chip.js").ConfigureAwait(true);
            _chipModule = module;
        }

        /// <inheritdoc />
        internal override async Task OnAfterScriptRenderedAsync()
        {
            if (_chipModule is null || OverflowMode != ChipOverflowMode.Collapse)
            {
                return;
            }

            await _chipModule.InvokeVoidAsync("observe", RootId, DotnetObjectReference).ConfigureAwait(true);
            _jsReady = true;
        }

        /// <summary>
        /// Called by chip.js when collapse measurement changes. Layout pixels stay in Playwright.
        /// <see cref="SfChipSet{TItem}.CollapsedVisibleCount"/> is only the pre-script fallback.
        /// After the first measurement, chip.js may overwrite it so a resize can change the fold.
        /// Measurements are ignored while the set is expanded. An unchanged count does not render again.
        /// </summary>
        [JSInvokable]
        public Task OnOverflowMeasured(int count)
        {
            if (OverflowMode != ChipOverflowMode.Collapse || _overflowExpanded)
            {
                return Task.CompletedTask;
            }

            int visible = _projected.Count(chip => !chip.Removed);
            int upper = Math.Max(visible, 1);
            int next = Math.Clamp(count, visible == 0 ? 0 : 1, upper);
            if (CollapsedVisibleCount == next)
            {
                return Task.CompletedTask;
            }

            CollapsedVisibleCount = next;
            ApplyCollapse();
            StateHasChanged();
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        protected override async ValueTask DisposeAsyncCore()
        {
            try
            {
                if (_chipModule is not null)
                {
                    if (_jsReady)
                    {
                        await _chipModule.InvokeVoidAsync("dispose", RootId).ConfigureAwait(true);
                    }

                    await _chipModule.DisposeAsync().ConfigureAwait(true);
                }
            }
            catch (JSDisconnectedException)
            {
            }
            catch (JSException)
            {
            }

            await base.DisposeAsyncCore().ConfigureAwait(true);
        }

        private sealed class ProjectedChip
        {
            internal TItem Item { get; init; } = default!;

            internal ChipModel Model { get; init; } = new();

            internal string ElementId { get; init; } = string.Empty;

            internal bool Removed { get; set; }

            internal bool Collapsed { get; set; }

            internal int TabIndex { get; set; } = -1;

            internal SfChip? Chip { get; set; }
        }
    }

    /// <summary>Non-generic registration surface cascaded to _declarative <see cref="SfChip"/> children.</summary>
    internal interface IChipSetRegistration
    {
        void Register(DeclarativeChip chip);

        void Unregister(string id);

        Task ActivateAsync(object? key, MouseEventArgs args);

        Task RemoveChildAsync(object? key, ChipRemoveReason reason);
    }

    /// <summary>Declarative child registration handle.</summary>
    internal sealed class DeclarativeChip
    {
        internal string Id { get; set; } = string.Empty;

        internal object? Key { get; set; }

        internal object? Value { get; set; }

        internal string? Text { get; set; }

        internal bool Disabled { get; set; }

        internal bool Removable { get; set; }

        internal SfChip? Chip { get; set; }
    }
}
