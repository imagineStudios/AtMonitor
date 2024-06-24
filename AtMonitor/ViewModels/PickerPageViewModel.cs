using System.Collections.ObjectModel;

namespace AtMonitor.ViewModels;

public partial class PickerPageViewModel<T> : PageViewModel
    where T : IEquatable<T>
{
    private Collection<T>? _collection;

    public PickerPageViewModel()
    {
        Items = [];
    }

    public PickerPageViewModel(IOrderedEnumerable<T> items)
    {
        Items = items
            .Select(p => new PickerViewModel<T>(p))
            .ToList();

        Items.ForEach(p => p.PickStateChanged += Item_PickStateChanged);
    }

    private void Item_PickStateChanged(object? sender, EventArgs e)
    {
        if (sender is PickerViewModel<T> picker)
        {
            if (picker.IsChecked)
            {
                if (!_collection?.Any(i => i.Equals(picker.Item)) ?? false)
                {
                    _collection?.Add(picker.Item);
                }
            }
            else
            {
                _collection?.Remove(i => i.Equals(picker.Item));
            }
        }
    }

    public List<PickerViewModel<T>> Items { get; }

    public override void OnNavigatingTo(object? parameter)
    {
        if (parameter is Collection<T> collection)
        {
            _collection = collection;

            foreach (var item in collection)
            {
                Items
                    .Where(i => i.Item.Equals(item))
                    .ForEach(i => i.IsChecked = true);
            }
        }
    }
}
