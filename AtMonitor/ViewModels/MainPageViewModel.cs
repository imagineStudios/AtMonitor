using AtMonitor.Services;
using AtMonitor.Views;
using CommunityToolkit.Mvvm.Input;

namespace AtMonitor.ViewModels;

public partial class MainPageViewModel(INavigationService navigationService)
    : PageViewModel
{
    private readonly INavigationService _navigationService = navigationService;

    [RelayCommand]
    private async Task NewMissionAsync()
        => await _navigationService.NavigateToPage<MissionPage>();

    [RelayCommand]
    private async Task ReportsAsync()
        => await _navigationService.NavigateToPage<ReportPage>();
}
