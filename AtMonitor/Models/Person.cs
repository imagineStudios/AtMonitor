namespace AtMonitor.Models;

public record Person(string FirstName, string LastName) : IEquatable<Person>
{
    public string Name => $"{FirstName} {LastName}";

    public override string ToString() => Name;
}
