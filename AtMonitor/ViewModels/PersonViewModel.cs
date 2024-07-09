using AtMonitor.Models;
using AtMonitor.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace AtMonitor.ViewModels;

public partial class PersonViewModel : ObservableObject, IEquatable<Person>
{
    private readonly ISettingsService _settingsService;
    private BottleType bottleType;

    [ObservableProperty]
    private int estimatedPressure;

    public PersonViewModel(Person person, ISettingsService settingsService)
    {
        Person = person;
        _settingsService = settingsService;
        BottleType = _settingsService.DefaultBottleType;
        PressureReadings.CollectionChanged += PressureReadings_CollectionChanged;
    }

    public Person Person { get; }

    public string Name => Person.Name;

    public string Initials => $"{Person.FirstName[0]}{Person.LastName[0]}";

    public BottleType BottleType
    {
        get => bottleType;
        set
        {
            bottleType = value;
            EstimatedPressure = bottleType switch
            {
                BottleType.Single => 300,
                BottleType.Dual => 200,
                _ => throw new NotImplementedException()
            };
        }
    }

    public ObservableCollection<PressureReading> PressureReadings { get; } = [];

    public PressureReading LatestReading => PressureReadings.Last();

    public int InitialPressure => PressureReadings.First().Pressure;

    public double RemainingRelativePressure => PressureReadings.Count > 0
        ? EstimatedPressure / (double)InitialPressure
        : 1.0;

    public bool Equals(Person? other)
        => Person.Equals(other);

    public void UpdatePressureEstimate()
    {
        if (PressureReadings.Count == 0)
        {
            return;
        }

        var latestReading = PressureReadings.
            OrderByDescending(r => r.Time).
            First();

        var timeSinceLastReading = DateTime.Now - LatestReading.Time;

        EstimatedPressure = LatestReading.Pressure
            - (int)Math.Round(timeSinceLastReading.TotalMinutes * _settingsService.EstimatedAirConsumptionRate_BarPerMinute);
        OnPropertyChanged(nameof(RemainingRelativePressure));
    }

    private void PressureReadings_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Person.PressureReadings = [.. PressureReadings];
        OnPropertyChanged(nameof(LatestReading));
    }
}
