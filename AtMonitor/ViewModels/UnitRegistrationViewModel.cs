using AtMonitor.Models;
using AtMonitor.Services;
using AtMonitor.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AtMonitor.ViewModels;

public partial class UnitRegistrationViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly ISettingsService _settings;
    private readonly IAppStateService _appStateService;
    private readonly Unit _unit;

    public UnitRegistrationViewModel(
        INavigationService navigationService,
        ISettingsService settings,
        IAppStateService appStateService)
    {
        _navigationService = navigationService;
        _settings = settings;
        _appStateService = appStateService;

        _unit = new Unit(appStateService.GetNextUnitName());
    }

    public string Name
    {
        get => _unit.Name;
        set => _unit.Name = value;
    }

    public ObservableCollection<Unit> Members { get; } = [];

    [RelayCommand]
    private async Task OkAsync()
    {
        _appStateService.ActiveMission!.Units.Add(_unit);
        await _navigationService.PopAsync();
    }

    [RelayCommand]
    private async Task AbortAsync()
    {
        await _navigationService.PopAsync();
    }

    [RelayCommand]
    private async Task PickPeople()
    {
        await _navigationService.NavigateToPeoplePicker(_unit);
    }
}
