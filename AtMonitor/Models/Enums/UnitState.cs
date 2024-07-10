using System.ComponentModel;

namespace AtMonitor.Models;

public enum UnitState
{
    [Description("Bereit")]
    Idle,

    [Description("Hinweg")]
    Entering,

    [Description("Am Einsatzort")]
    Working,

    [Description("Rückweg")]
    Returning,

    [Description("Fertig")]
    Done,
}
