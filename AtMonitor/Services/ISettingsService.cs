using AtMonitor.Models;

namespace AtMonitor.Services;

public interface ISettingsService
{
    string BaseCallSign { get; set; }

    BottleType DefaultBottleType { get; set; }

    UnitNaming DefaultUnitNaming { get; set; }

    string ReportEmailList { get; set; }

    int PressureInterval_Bar { get; set; }

    int EstimatedAirConsumptionRate_BarPerMinute { get; set; }
}
