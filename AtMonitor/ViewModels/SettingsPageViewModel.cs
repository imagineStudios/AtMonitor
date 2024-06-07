using AtMonitor.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AtMonitor.ViewModels;

public partial class SettingsPageViewModel : ObservableObject
{
    private readonly ISettingsService _settingsService;

    public SettingsPageViewModel(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }
}
