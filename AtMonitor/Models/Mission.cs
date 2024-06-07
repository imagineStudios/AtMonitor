namespace AtMonitor.Models;

public class Mission
{
    public Mission()
    {
        Title = $"Einsatz {Begin}";
    }

    public event EventHandler<Unit>? UnitAdded;

    public DateTime Begin { get; } = DateTime.Now;

    public DateTime? End { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public List<Unit> Units { get; } = [];

    public void AddUnit(Unit unit)
    {
        Units.Add(unit);
        UnitAdded?.Invoke(this, unit);
    }
}
