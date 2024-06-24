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
    private readonly Mission _mission;

    public MissionPageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        _mission = new Mission(DateTime.Now);

        Units.CollectionChanged += Units_CollectionChanged;
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
        get => _mission.Title;
        set => SetProperty(_mission.Title, value, _mission, (u, n) => u.Title = n);
    }

    public string? Description
    {
        get => _mission.Description;
        set => SetProperty(_mission.Description, value, _mission, (u, n) => u.Description = n);
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
}
