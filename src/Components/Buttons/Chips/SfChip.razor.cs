using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor.Toolkit.Internal;
using System.Diagnostics;

namespace Syncfusion.Blazor.Toolkit;

/// <summary>
/// A single chip rendered as a native button, link, or span. Does not wrap <c>SfButton</c>.
/// </summary>
/// <remarks>
/// Navigation without <see cref="SfChip.Href"/> renders as <c>button type="button"</c> and writes a debug diagnostic.
/// Click, selection, and removal stay in C#.
/// </remarks>
public partial class SfChip : SfBaseComponent
{
    private bool removed;
    private bool navigationWarned;
    private bool registered;
    private ElementReference rootReference;
    private ElementReference removeReference;

    private string RootId => string.IsNullOrEmpty(Id) ? $"chip-{GetHashCode():x}" : Id!;

    private bool Interactive => ChipType is ChipType.Action or ChipType.Assist or ChipType.Filter or ChipType.Choice or ChipType.Suggestion or ChipType.Navigation;

    private bool IsLink => ChipType == ChipType.Navigation && !string.IsNullOrEmpty(Href) && !removed;

    private string RootTag => removed ? "span" : IsLink ? "a" : Interactive ? "button" : "span";

    private bool ShowRemove => Removable && !removed;

    private bool HasAuthorLeading => LeadingTemplate is not null || !string.IsNullOrEmpty(ImageUrl) || !string.IsNullOrEmpty(IconCss);

    private bool ShowSelectionCheck => Selected && ChipType is ChipType.Filter or ChipType.Choice && !HasAuthorLeading;

    private bool ShowLeading => HasAuthorLeading || ShowSelectionCheck;

    private bool ActivationBlocked => Disabled || ReadOnly || IsLoading || removed;

    private bool RemoveDisabled => Disabled || ReadOnly;

    private string VisibleName => !string.IsNullOrEmpty(AriaLabel) ? AriaLabel! : !string.IsNullOrEmpty(Text) ? Text! : string.Empty;

    private string RemoveLabel => ChipResources.Format(Localizer, ChipResources.RemoveKey, "Remove {0}", VisibleName);

    private string Css => string.Join(
        ' ',
        new[]
        {
            "e-chip",
            "e-chip-" + ChipType.ToString().ToLowerInvariant(),
            Variant == ChipVariant.Outlined ? "e-chip-outlined" : "e-chip-filled",
            Size switch
            {
                ChipSize.Small => "e-chip-sm",
                ChipSize.Large => "e-chip-lg",
                _ => "e-chip-md",
            },
            Shape == ChipShape.Pill ? "e-chip-pill" : "e-chip-rounded",
            Selected ? "e-chip-selected" : null,
            Disabled ? "e-chip-disabled" : null,
            ReadOnly ? "e-chip-readonly" : null,
            Removable ? "e-chip-removable" : null,
            HasError ? "e-chip-error" : null,
            IsLoading ? "e-chip-loading" : null,
            CssClass,
        }.Where(token => !string.IsNullOrWhiteSpace(token)));

    /// <summary>Moves focus to the chip root.</summary>
    public ValueTask FocusAsync()
    {
        return rootReference.FocusAsync();
    }

    /// <summary>Moves focus to the remove control when it is rendered.</summary>
    public ValueTask FocusRemoveAsync()
    {
        return ShowRemove ? removeReference.FocusAsync() : ValueTask.CompletedTask;
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

        attributes["id"] = RootId;
        attributes["class"] = string.Join(' ', new[] { "e-chip", Css }.Where(token => !string.IsNullOrWhiteSpace(token)).Distinct(StringComparer.Ordinal));
        attributes["data-testid"] = "chip-root";
        if (TabIndex is not null || !attributes.ContainsKey("tabindex"))
        {
            attributes["tabindex"] = TabIndex ?? 0;
        }
        attributes["data-chip-type"] = ChipType.ToString();
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
            attributes["aria-labelledby"] = AriaLabelledBy!;
        }

        if (!string.IsNullOrEmpty(AriaDescribedBy))
        {
            attributes["aria-describedby"] = AriaDescribedBy!;
        }

        if (ChipType is ChipType.Filter or ChipType.Choice)
        {
            attributes["aria-pressed"] = Selected ? "true" : "false";
        }

        if (RootTag == "button")
        {
            attributes["type"] = "button";
            if (Disabled)
            {
                attributes["disabled"] = true;
            }
        }
        else if (IsLink)
        {
            attributes["href"] = Href!;
            if (!string.IsNullOrEmpty(Target))
            {
                attributes["target"] = Target!;
            }

            if (!string.IsNullOrEmpty(Rel))
            {
                attributes["rel"] = Rel!;
            }

            if (Disabled)
            {
                attributes["aria-disabled"] = "true";
                attributes["tabindex"] = "-1";
            }
        }
        else if (Disabled)
        {
            attributes["aria-disabled"] = "true";
        }

        if (ReadOnly)
        {
            attributes["aria-readonly"] = "true";
        }

        return attributes;
    }

    private void WarnNavigation()
    {
        if (ChipType == ChipType.Navigation && string.IsNullOrEmpty(Href) && !navigationWarned)
        {
            navigationWarned = true;
            Debug.WriteLine("SfChip navigation without Href renders as button type=button.");
        }
    }

    private async Task OnClickAsync(MouseEventArgs args)
    {
        if (ActivationBlocked || !Interactive)
        {
            return;
        }

        if (Owner is not null)
        {
            await Owner.ActivateAsync(Value ?? Text ?? RootId, args).ConfigureAwait(true);
            return;
        }

        if (ChipType is ChipType.Filter or ChipType.Choice)
        {
            bool next = !Selected;
            if (next != Selected)
            {
                Selected = next;
                await SelectedChanged.InvokeAsync(next).ConfigureAwait(true);
            }
        }

        await OnClick.InvokeAsync(args).ConfigureAwait(true);
    }

    private async Task OnRemoveClickAsync(MouseEventArgs _)
    {
        if (Owner is not null)
        {
            await Owner.RemoveChildAsync(Value ?? Text ?? RootId, ChipRemoveReason.RemoveButton).ConfigureAwait(true);
            return;
        }

        await RequestRemoveAsync(ChipRemoveReason.RemoveButton).ConfigureAwait(true);
    }

    private async Task OnKeyDownAsync(KeyboardEventArgs args)
    {
        if (args.Key is "Delete" or "Backspace")
        {
            await RequestRemoveAsync(ChipRemoveReason.Keyboard).ConfigureAwait(true);
            return;
        }

        if (Owner is not null && args.Key is "ArrowRight" or "ArrowLeft" or "ArrowDown" or "ArrowUp" or "Home" or "End")
        {
            return;
        }

        if (args.Key is " " or "Enter" && Interactive && !ActivationBlocked)
        {
            await OnClickAsync(new MouseEventArgs()).ConfigureAwait(true);
        }
    }

    private async Task RequestRemoveAsync(ChipRemoveReason reason)
    {
        if (!Removable || RemoveDisabled || removed)
        {
            return;
        }

        ChipRemovingEventArgs removing = new()
        {
            Text = Text,
            Key = Value,
            Reason = reason,
        };
        await Removing.InvokeAsync(removing).ConfigureAwait(true);
        if (removing.Cancel)
        {
            return;
        }

        removed = true;
        await Removed.InvokeAsync(new ChipRemovedEventArgs
        {
            Text = Text,
            Key = Value,
            Reason = reason,
        }).ConfigureAwait(true);
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        WarnNavigation();
        SyncRegistration();
    }

    private void SyncRegistration()
    {
        if (Owner is null)
        {
            return;
        }

        Owner.Register(new DeclarativeChip
        {
            Id = RootId,
            Key = Value ?? Text ?? RootId,
            Value = Value ?? Text,
            Text = Text,
            Disabled = Disabled,
            Removable = Removable,
            Chip = this,
        });
        registered = true;
    }

    /// <inheritdoc />
    protected override async ValueTask DisposeAsyncCore()
    {
        if (registered && Owner is not null)
        {
            Owner.Unregister(RootId);
        }

        await base.DisposeAsyncCore().ConfigureAwait(true);
    }
}
