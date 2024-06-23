namespace AtMonitor.Models;

public class Unit(string name)
{
    public string Name { get; set; } = name;

    public string? CallSign { get; set; }

    public string Order { get; set; }

    public string Location { get; set; }

    public List<Person> Members { get; } = [];
}
