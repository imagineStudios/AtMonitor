namespace AtMonitor.Models;

public record Person(string FirstName, string LastName)
{
    public string Name => $"{FirstName} {LastName}";
}