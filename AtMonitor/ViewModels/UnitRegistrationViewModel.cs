using AtMonitor.Models;
using AtMonitor.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AtMonitor.ViewModels;

public partial class UnitRegistrationViewModel : PageViewModel
{
    private readonly INavigationService _navigationService;
    private readonly ISettingsService _settings;
    private readonly UnitViewModel _unit;

    private MissionPageViewModel? _missionViewModel;

    public UnitRegistrationViewModel(
        INavigationService navigationService,
        ISettingsService settings)
    {
        _navigationService = navigationService;
        _settings = settings;

        _unit = new UnitViewModel(new Unit());
    }

    public string Name
    {
        get => _unit.Name;
        set => SetProperty(_unit.Name, value, _unit, (u, n) => u.Name = n);
    }

    public ObservableCollection<Person> Members => _unit.Members;

    public override void OnNavigatingTo(object? parameter)
    {
        if (parameter is MissionPageViewModel vm)
        {
            _missionViewModel = vm;
            Name = GetNextUnitName();
        }
    }

    [RelayCommand]
    private async Task OkAsync()
    {
        _missionViewModel?.Units.Add(_unit);
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
        await _navigationService.NavigateToPeoplePicker(_unit.Members);
    }

    private string GetNextUnitName()
    {
        var index = _missionViewModel!.Units.Count;
        switch (_settings.DefaultUnitNaming)
        {
            case UnitNaming.ByFunctions:
                var candidates = new string[]
                {
                    "Angriffstrupp",
                    "Wassertrupp",
                    "Sicherheitstrupp",
                };

                if (index < candidates.Length)
                {
                    return candidates[index];
                }
                else
                {
                    goto case UnitNaming.ByNumber;
                }

            case UnitNaming.ByNumber:
                return $"Trupp {index + 1}";

            default:
                return string.Empty;
        }
    }
}
