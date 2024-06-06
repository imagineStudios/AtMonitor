using AtMonitor.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AtMonitor.ViewModels;

public partial class PeoplePickerViewModel : ObservableObject
{
    public PeoplePickerViewModel(IStore<Person> store)
    {
        People = store.GetAll()
            .OrderBy(p => p.LastName)
            .ThenBy(p => p.FirstName)
            .Select(p => (new PersonViewModel(p), false))
            .ToList();
    }

    public List<(PersonViewModel, bool)> People { get; }
}
