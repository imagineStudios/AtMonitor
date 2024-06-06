using AtMonitor.Models;

namespace AtMonitor.Settings;

public interface ISettingsService
{
    string BaseCallSign { get; set; }

    BottleType DefaultBottleType { get; set; }

    UnitNaming DefaultUnitNaming { get; set; }

    string ReportEmailList { get; set; }
}