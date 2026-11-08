namespace Syncfusion.Blazor.Toolkit.Internal;

/// <summary>Computes the next selection list without mutating the caller's collection.</summary>
internal static class ChipSelectionStore
{
    internal static IReadOnlyList<object?> Current(ChipSelectionMode mode, object? selectedValue, IEnumerable<object?>? selectedValues)
    {
        if (mode == ChipSelectionMode.Multiple)
        {
            return selectedValues?.Where(value => value is not null).Distinct(ChipKeyComparer.Instance).ToArray() ?? [];
        }

        if (mode == ChipSelectionMode.Single && selectedValue is not null)
        {
            return [selectedValue];
        }

        return [];
    }

    internal static IReadOnlyList<object?> Propose(
        ChipSelectionMode mode,
        bool allowEmpty,
        IReadOnlyList<object?> current,
        object? value,
        bool clear)
    {
        if (mode == ChipSelectionMode.None || value is null && !clear)
        {
            return current;
        }

        if (clear || mode == ChipSelectionMode.Single && allowEmpty && current.Count == 1 && ChipKeyComparer.Instance.Equals(current[0], value))
        {
            return allowEmpty || mode == ChipSelectionMode.Multiple ? [] : current;
        }

        if (mode == ChipSelectionMode.Single)
        {
            if (!allowEmpty && value is null)
            {
                return current;
            }

            return [value];
        }

        List<object?> next = current.ToList();
        int index = next.FindIndex(item => ChipKeyComparer.Instance.Equals(item, value));
        if (index >= 0)
        {
            next.RemoveAt(index);
        }
        else if (value is not null)
        {
            next.Add(value);
        }

        return next;
    }

    internal static bool Same(IReadOnlyList<object?> left, IReadOnlyList<object?> right)
    {
        if (left.Count != right.Count)
        {
            return false;
        }

        for (int i = 0; i < left.Count; i++)
        {
            if (!ChipKeyComparer.Instance.Equals(left[i], right[i]))
            {
                return false;
            }
        }

        return true;
    }
}
