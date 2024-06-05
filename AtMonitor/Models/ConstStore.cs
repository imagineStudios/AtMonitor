namespace AtMonitor.Models;

public class ConstStore<T> : IStore<T>
{
    private readonly T[] values;

    public ConstStore(IEnumerable<T> values)
    {
        this.values = values.ToArray();
    }

    public IEnumerable<T> GetAll() => values;
}
