using AtMonitor.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AtMonitor.ViewModels;

public partial class PressureReadingPageViewModel : PageViewModel
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private PressureReadingViewModel[]? readings;

    public PressureReadingPageViewModel(
        INavigationService navigationService,
        ISettingsService settingsService)
    {
        _navigationService = navigationService;
        PressureInterval = settingsService.PressureInterval_Bar;
    }

    public int PressureInterval { get; }

    public override void OnNavigatingTo(object? parameter)
    {
        if (parameter is IEnumerable<PersonViewModel> people)
        {
            Readings = people.
                Select(p => new PressureReadingViewModel(p, PressureInterval)).
                ToArray();
        }
    }

    [RelayCommand]
    private async Task OkAsync()
    {
        Readings?.ForEach(p => p.AddReading());
        await _navigationService.PopAsync();
    }

    [RelayCommand]
    private async Task AbortAsync()
        => await _navigationService.PopAsync();
}
