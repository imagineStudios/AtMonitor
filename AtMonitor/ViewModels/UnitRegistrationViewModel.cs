using AtMonitor.Models;
using AtMonitor.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AtMonitor.ViewModels;

public partial class UnitRegistrationViewModel : ObservableObject
{
    private readonly ISettingsService _settings;
    private readonly IAppStateService _appStateService;
    private readonly Unit _unit = new();

    public UnitRegistrationViewModel(ISettingsService settings, IAppStateService appStateService)
    {
        _settings = settings;
        _appStateService = appStateService;
    }

    public string Name { get; set; } = string.Empty;

    public ObservableCollection<UnitViewModel> Units { get; } = [];

    [RelayCommand]
    private void OkAsync()
    {
    }
}

public partial class UnitViewModel : ObservableObject
{

}

public partial class MissionViewModel : ObservableObject
{
    public MissionViewModel()
    {
        
    }
}
