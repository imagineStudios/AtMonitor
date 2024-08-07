﻿using AtMonitor.Models;

namespace AtMonitor.Services;

public class SettingsService : ISettingsService
{
    public BottleType DefaultBottleType
    {
        get => GetEnum(nameof(DefaultBottleType), BottleType.Single);
        set => SetEnum(nameof(DefaultBottleType), value);
    }

    public UnitNaming DefaultUnitNaming
    {
        get => GetEnum(nameof(DefaultUnitNaming), UnitNaming.ByFunctions);
        set => SetEnum(nameof(DefaultUnitNaming), value);
    }

    public string ReportEmailList
    {
        get => Preferences.Get(nameof(ReportEmailList), string.Empty);
        set => Preferences.Set(nameof(ReportEmailList), value);
    }

    public string BaseCallSign
    {
        get => Preferences.Get(nameof(BaseCallSign), "Florentine Notzingen 1-40/1");
        set => Preferences.Set(nameof(BaseCallSign), value);
    }

    public int PressureInterval_Bar
    {
        get => Preferences.Get(nameof(PressureInterval_Bar), 10);
        set => Preferences.Set(nameof(PressureInterval_Bar), value);
    }
    public int EstimatedAirConsumptionRate_BarPerMinute
    {
        get => Preferences.Get(nameof(EstimatedAirConsumptionRate_BarPerMinute), 10);
        set => Preferences.Set(nameof(EstimatedAirConsumptionRate_BarPerMinute), value);
    }

    private static T GetEnum<T>(string key, T defaultValue)
        where T : struct, Enum
        => Enum.Parse<T>(Preferences.Get(key, defaultValue.ToString()));
    
    private static void SetEnum<T>(string key, T value)
        where T : struct, Enum
        => Preferences.Set(key, value.ToString());
}
