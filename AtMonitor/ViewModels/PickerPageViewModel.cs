using System.Collections.ObjectModel;

namespace AtMonitor.ViewModels;

public partial class PickerPageViewModel<TModel, TViewModel> : PageViewModel
    where TViewModel : IEquatable<TModel>
{
    private Collection<TViewModel>? _collection;

    public PickerPageViewModel()
    {
        Items = [];
    }

    public PickerPageViewModel(
        IOrderedEnumerable<TModel> items,
        Func<TModel, TViewModel> converter)
    {
        _converter = converter;
        Items = items
            .Select(p => new PickerViewModel<TModel>(p))
            .ToList();

        Items.ForEach(p => p.PickStateChanged += Item_PickStateChanged);
    }

    private void Item_PickStateChanged(object? sender, EventArgs e)
    {
        if (sender is PickerViewModel<TModel> picker)
        {
            if (picker.IsChecked)
            {
                if (!_collection?.Any(i => i.Equals(picker.Item)) ?? false)
                {
                    _collection?.Add(_converter(picker.Item));
                }
            }
            else
            {
                _collection?.Remove(i => i.Equals(picker.Item));
            }
        }
    }

    private readonly Func<TModel, TViewModel> _converter;

    public List<PickerViewModel<TModel>> Items { get; }

    public override void OnNavigatingTo(object? parameter)
    {
        if (parameter is Collection<TViewModel> collection)
        {
            _collection = collection;

            foreach (var item in Items)
            {
                item.IsChecked = _collection.Any(vm => vm.Equals(item.Item));
            }
        }
    }
}
