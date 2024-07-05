namespace AtMonitor.Models;

public class Mission(DateTime begin)
{
    public DateTime Begin { get; } = begin;

    public DateTime? End { get; set; }

    public string Title { get; set; } = $"Einsatz {begin:g}";

    public string? Description { get; set; }

    public Unit[] Units { get; set;  } = [];
}
