namespace AtMonitor.Models;

public record Bottle(BottleType BottleType)
{
    public int InitialPressure
        => BottleType switch
        {
            BottleType.Single => 300,
            BottleType.Dual => 200,
            _ => 0,
        };
}