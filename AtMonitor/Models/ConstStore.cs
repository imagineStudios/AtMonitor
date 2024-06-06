namespace AtMonitor.Models;

public class ConstStore<T> : IStore<T>
{
    private readonly T[] _values;

    public ConstStore(IEnumerable<T> values)
    {
        _values = values.ToArray();
    }

    public IEnumerable<T> GetAll() => _values;
}
