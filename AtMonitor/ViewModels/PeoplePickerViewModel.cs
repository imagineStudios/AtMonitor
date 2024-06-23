using AtMonitor.Models;
using AtMonitor.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AtMonitor.ViewModels;

public partial class PeoplePickerViewModel : ViewModelBase
{
    private Unit unit;

    public PeoplePickerViewModel(IStore<Person> store)
    {
        People = store.GetAll()
            .OrderBy(p => p.LastName)
            .ThenBy(p => p.FirstName)
            .Select(p => new PickerViewModel<Person>(p))
            .ToList();
    }

    public override void OnNavigatingTo(object? parameter)
    {
        base.OnNavigatingTo(parameter);
        if (parameter is Unit unit)
        {
            Unit = unit;
        }
    }

    public List<PickerViewModel<Person>> People { get; }

    public Unit Unit
    {
        get => unit;
        set
        {
            unit = value;
            foreach (var p in People)
            {
                p.IsChecked = unit.Members.Contains(p.Item);
            }
        }
    }
}

public partial class PickerViewModel<T> : ObservableObject
{
    public T Item { get; }

    public PickerViewModel(T item)
    {
        Item = item;
    }

    public string Title => Item.ToString();

    public bool IsChecked { get; set; }
}
