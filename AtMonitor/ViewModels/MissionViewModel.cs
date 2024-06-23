using AtMonitor.Services;
using AtMonitor.Views;
using CommunityToolkit.Mvvm.Input;

namespace AtMonitor.ViewModels;

public partial class MissionViewModel(INavigationService navigationService) : ViewModelBase
{
    private readonly INavigationService _navigationService = navigationService;

    [RelayCommand]
    private async Task AddUnitAsync()
       => await _navigationService.NavigateToPage<UnitRegistrationPage>();
}
