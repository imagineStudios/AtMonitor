using AtMonitor.Models;
using AtMonitor.Settings;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AtMonitor.ViewModels;

public partial class UnitRegistrationViewModel : ObservableObject
{
    private readonly SettingsService settings;

    public UnitRegistrationViewModel(SettingsService settings)
    {
        this.settings = settings;
    }

    public string Name { get; set; }
}
