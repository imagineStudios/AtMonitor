using AtMonitor.Services;
using AtMonitor.Views;
using CommunityToolkit.Mvvm.Input;

namespace AtMonitor.ViewModels;

public partial class MainPageViewModel(IAppStateService appStateService, INavigationService navigationService)
    : ViewModelBase
{
    private readonly IAppStateService _appStateService = appStateService;
    private readonly INavigationService _navigationService = navigationService;

    [RelayCommand]
    private async Task NewMissionAsync()
    {
        if (_appStateService.StartNewMission())
        {
            await _navigationService.NavigateToPage<MissionPage>();
        }
    }

    [RelayCommand]
    private async Task ReportsAsync()
        => await _navigationService.NavigateToPage<ReportPage>();
}
