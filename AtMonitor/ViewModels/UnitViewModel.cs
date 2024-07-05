using AtMonitor.Models;
using AtMonitor.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AtMonitor.ViewModels;

public partial class UnitViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly ISettingsService _settingsService;

    public UnitViewModel(
        INavigationService navigationService,
        ISettingsService settingsService)
    {
        _navigationService = navigationService;
        _settingsService = settingsService;
        Unit = new Unit();
        Members.CollectionChanged += Members_CollectionChanged;
    }

    public Unit Unit { get; }

    public string Name
    {
        get => Unit.Name;
        set
        {
            SetProperty(Unit.Name, value, Unit, (u, n) => u.Name = n);
            CallSign = $"{_settingsService.BaseCallSign} {Name}";
        }
    }

    public string? CallSign
    {
        get => Unit.CallSign;
        private set => SetProperty(Unit.CallSign, value, Unit, (u, n) => u.CallSign = n);
    }

    public string Order
    {
        get => Unit.Order ?? string.Empty;
        set => SetProperty(Unit.Order, value, Unit, (u, n) => u.Order = n);
    }

    public string Location
    {
        get => Unit.Location ?? string.Empty;
        set => SetProperty(Unit.Location, value, Unit, (u, n) => u.Location = n);
    }

    public ObservableCollection<Person> Members { get; } = [];

    [RelayCommand]
    private async Task PickPeople()
        => await _navigationService.NavigateToPeoplePicker(Members);

    [RelayCommand]
    private void RemoveMember(object parameter)
        => Members.Remove((Person)parameter);

    private void Members_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Unit.Members = [.. Members];
    }
}
