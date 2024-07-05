using AtMonitor.Services;
using CommunityToolkit.Mvvm.Input;

namespace AtMonitor.ViewModels;

public partial class UnitRegistrationPageViewModel : PageViewModel
{
    private readonly INavigationService _navigationService;

    private MissionPageViewModel? _missionViewModel;

    public UnitRegistrationPageViewModel(
        INavigationService navigationService,
        ISettingsService settingsService)
    {
        _navigationService = navigationService;
        Unit = new UnitViewModel(_navigationService, settingsService);
    }

    public UnitViewModel Unit { get; }

    public override void OnNavigatingTo(object? parameter)
    {
        if (parameter is MissionPageViewModel vm)
        {
            _missionViewModel = vm;
            Unit.Name = _missionViewModel.GetNextUnitName();
        }
    }

    [RelayCommand]
    private async Task OkAsync()
    {
        _missionViewModel?.Units.Add(Unit);
        await _navigationService.PopAsync();
    }

    [RelayCommand]
    private async Task AbortAsync()
        => await _navigationService.PopAsync();
}
