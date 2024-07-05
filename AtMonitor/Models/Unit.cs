namespace AtMonitor.Models;

public class Unit()
{
    public string Name { get; set; } = "Neue Einheit";

    public string? CallSign { get; set; }

    public string? Order { get; set; }

    public string? Location { get; set; }

    public Person[] Members { get; set; } = [];
}
