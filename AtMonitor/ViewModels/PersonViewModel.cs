using AtMonitor.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AtMonitor.ViewModels;

public partial class PersonViewModel : ObservableObject
{
    private readonly Person person;

    public PersonViewModel(Person person)
    {
        this.person = person;
    }

    public string FirstName => person.FirstName;

    public string LastName => person.LastName;

    public override string ToString() => $"{LastName}, {FirstName}";
}
