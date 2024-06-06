using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AtMonitor.ViewModels;

public partial class MissionPageViewModel
{
    [RelayCommand]
    private void AddTeamAsync()
    {
    }
    public ObservableCollection<TeamViewModel> Teams { get; } = [];

}
