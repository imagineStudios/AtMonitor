using AtMonitor.Models;
using AtMonitor.Services;
using AtMonitor.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AtMonitor.ViewModels;

public partial class MissionPageViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly ISettingsService _settingsService;
    private readonly Mission _mission;
    private IDispatcherTimer? secondTimer;

    public MissionPageViewModel(
        INavigationService navigationService,
        ISettingsService settingsService)
    {
        _navigationService = navigationService;
        _settingsService = settingsService;
        _mission = new Mission(DateTime.Now);

        Units.CollectionChanged += Units_CollectionChanged;

        for (int i = 0; i < 3; i++)
        {
            Units.Add(
                new UnitViewModel(_navigationService, settingsService)
                {
                    Name = GetNextUnitName(),
                });
        }

        secondTimer = Application.Current?.Dispatcher.CreateTimer();
        if (secondTimer != null)
        {
            secondTimer.Interval = TimeSpan.FromSeconds(1);
            secondTimer.Tick += SecondTimer_Tick;
            secondTimer.Start();
        }
    }

    public ObservableCollection<UnitViewModel> Units { get; } = [];

    public DateTime Begin => _mission.Begin;

    public DateTime? End
    {
        get => _mission.End;
        set => SetProperty(_mission.End, value, _mission, (u, n) => u.End = n);
    }

    public string Title
    {
        get => _mission.Title ?? string.Empty;
        set => SetProperty(_mission.Title, value, _mission, (u, n) => u.Title = n);
    }

    public string? Description
    {
        get => _mission.Description;
        set => SetProperty(_mission.Description, value, _mission, (u, n) => u.Description = n);
    }

    public DateTime Time => DateTime.Now;

    public TimeSpan Duration => Time - Begin;

    public string GetNextUnitName()
    {
        var index = Units.Count;
        switch (_settingsService.DefaultUnitNaming)
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

    [RelayCommand]
    private async Task AddUnitAsync()
        => await _navigationService.NavigateToPage<UnitRegistrationPage>(this);

    [RelayCommand]
    private async Task FinalizeMissionAsync()
       => await _navigationService.NavigateToPage<MissionFinalizationPage>(this);

    private void Units_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        _mission.Units = [.. Units.Select(u => u.Unit)];
    }

    private void SecondTimer_Tick(object? sender, EventArgs e)
    {
        OnPropertyChanged(nameof(Time));
        OnPropertyChanged(nameof(Duration));
    }
}
