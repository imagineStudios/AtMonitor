using AtMonitor.Models;

namespace AtMonitor.Services;

public class AppStateService : IAppStateService
{
    private readonly ISettingsService _settingsService;

    public AppStateService(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }
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

    public string GetNextUnitName()
    {
        var index = ActiveMission!.Units.Count + 1;
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
                return $"Trupp {index}";

            default:
                return string.Empty;
        }
    }
}