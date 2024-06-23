using AtMonitor.Models;

namespace AtMonitor.Services;

public interface IAppStateService
{
    Mission? ActiveMission { get; }

    bool StartNewMission();

    bool FinalizeMission();

    string GetNextUnitName();
}
