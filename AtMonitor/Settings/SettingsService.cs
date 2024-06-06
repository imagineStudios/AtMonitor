using AtMonitor.Models;

namespace AtMonitor.Settings;

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
        get => Preferences.Get(nameof(BaseCallSign), string.Empty);
        set => Preferences.Set(nameof(BaseCallSign), value);
    }

    private T GetEnum<T>(string key, T defaultValue)
        where T : struct, Enum
        => Enum.Parse<T>(Preferences.Get(key, defaultValue.ToString()));
    
    private void SetEnum<T>(string key, T value)
        where T : struct, Enum
        => Preferences.Set(key, value.ToString());
}
