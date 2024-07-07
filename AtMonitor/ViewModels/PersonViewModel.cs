using AtMonitor.Models;
using AtMonitor.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;

namespace AtMonitor.ViewModels;

public class PersonViewModel : ObservableObject, IEquatable<Person>
{
    private readonly ISettingsService _settingsService;
    private BottleType bottleType;

    public PersonViewModel(Person person, ISettingsService settingsService)
    {
        Person = person;
        _settingsService = settingsService;
        BottleType = _settingsService.DefaultBottleType;
        PressureReadings.CollectionChanged += PressureReadings_CollectionChanged;
    }

    public string Name => Person.Name;

    public Person Person { get; }

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

    public int EstimatedPressure { get; set; }

    public ObservableCollection<PressureReading> PressureReadings { get; } = [];

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

        var timeSinceLastReading = DateTime.Now - latestReading.Time;

        EstimatedPressure = latestReading.Pressure
            - (int)Math.Round(timeSinceLastReading.TotalMinutes * _settingsService.EstimatedAirConsumptionRate_BarPerMinute);
    }

    private void PressureReadings_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Person.PressureReadings = [.. PressureReadings];
    }
}
