using AtMonitor.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
namespace AtMonitor.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    public MainPageViewModel(IStore<Person> store)
    {
        foreach (var person in store.GetAll().OrderBy(p => p.LastName).ThenBy(p => p.FirstName))
        {
            People.Add(new PersonViewModel(person));
        }
    }

    [ObservableProperty]
    private string _title = "Hallo";

    [RelayCommand]
    private void AddTeamAsync()
    {
        //return NavigationService.NavigateToAsync("Settings");
    }

    public ObservableCollection<TeamViewModel> Teams { get; } = [];

    public ObservableCollection<PersonViewModel> People { get; } = [];
}
