using AtMonitor.Models;

namespace AtMonitor.Services;

public class AppStateService : IAppStateService
{
    public Mission? ActiveMission { get; private set; }

    public bool StartNewMission()
    {
        if (ActiveMission == null)
        {
            ActiveMission = new Mission();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool FinalizeMission()
    {
        if (ActiveMission != null)
        {
            ActiveMission = null;
            return true;
        }
        else
        {
            return false;
        }
    }
}