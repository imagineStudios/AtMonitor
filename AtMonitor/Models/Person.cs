namespace AtMonitor.Models;

public record Person(string FirstName, string LastName) : IEquatable<Person>
{
    public string Name => $"{FirstName} {LastName}";

    public PressureReading[] PressureReadings { get; set; }

    public override string ToString() => Name;
}
