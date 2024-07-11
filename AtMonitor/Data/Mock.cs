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
            yield return new Person("Emil", "Dennhorst");
            yield return new Person("Michael", "Marx");
            yield return new Person("Jakob", "Dresen");
            yield return new Person("Thomas", "Frank");
            yield return new Person("Linus", "Torwand");
            yield return new Person("Lukas", "Thiel");
            yield return new Person("Jonas", "Wagner");
            yield return new Person("Paul", "Ganter");
        }
    }
}