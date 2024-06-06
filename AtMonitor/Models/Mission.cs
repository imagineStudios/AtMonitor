namespace AtMonitor.Models;

public class Mission
{
    public Mission()
    {
    }

    public DateTime Begin { get; } = DateTime.Now;

    public DateTime? End { get; set; }

    public string? Description { get; set; }

    public List<Unit> Units { get; } = [];
}
