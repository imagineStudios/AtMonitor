namespace AtMonitor.Models;

public interface IStore<T>
{
    IEnumerable<T> GetAll();
}
