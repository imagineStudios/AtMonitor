namespace AtMonitor.Services;

public abstract class Repository<T>
{
    public abstract T Create(T entity);

    public abstract T Read(long entityId);

    public abstract T Update(T entity);

    public abstract void Delete(long entityId);
}
