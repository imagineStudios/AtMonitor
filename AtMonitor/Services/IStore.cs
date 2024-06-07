namespace AtMonitor.Services;

public interface IStore<T>
{
    IEnumerable<T> GetAll();
}
