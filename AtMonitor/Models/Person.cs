namespace AtMonitor.Models;

public record Person(string FirstName, string LastName)
{
    public string Name => $"{FirstName} {LastName}";
}

public class History
{

}

public record PressureReading(int Pressure)
{
}
