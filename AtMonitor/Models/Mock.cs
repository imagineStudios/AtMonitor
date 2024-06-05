namespace AtMonitor.Models;

internal static class Mock
{
    internal static IEnumerable<Person> People
    {
        get
        {
            yield return new Person("Max", "Mustermann");
            yield return new Person("Miri", "Mustermann");
            yield return new Person("Lukas", "Mayer");
            yield return new Person("Dominik", "Schmidt");
            yield return new Person("Matthias", "Schmitt");
            yield return new Person("Moritz", "Bleibtreu");
            yield return new Person("Siggi", "Super");
        }
    }
}