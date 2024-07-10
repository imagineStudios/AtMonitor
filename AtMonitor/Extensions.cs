namespace AtMonitor;

public static class Extensions
{
    public static void Remove<T>(this ICollection<T> e, Func<T, bool> predicate)
    {
        var toDelete = e.Where(predicate).ToArray();
        toDelete.ForEach(i => e.Remove(i));
    }

    public static void ForEach<T>(this IEnumerable<T> e, Action<T> action)
    {
        foreach (var item in e)
        {
            action?.Invoke(item);
        }
    }

    public static T? GetAttributeOfType<T>(this Enum enumVal)
        where T : Attribute
    {
        var memInfo = enumVal.GetType().GetMember(enumVal.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
        return (attributes.Length > 0) ? (T)attributes[0] : null;
    }
}
