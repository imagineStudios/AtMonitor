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

    [ObservableProperty]
    private PressureReading? latestReading;

    [ObservableProperty]
    private PressureReading? startedWorkingReading;

    public PersonViewModel(Person person, ISettingsService settingsService)
    {
        Person = person;
        _settingsService = settingsService;
        BottleType = _settingsService.DefaultBottleType;
        PressureReadings.CollectionChanged += PressureReadings_CollectionChanged;
    }

    public Person Person { get; }

    public UnitState State { get; set; }

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

    public int InitialPressure
        => PressureReadings.Count > 0
        ? PressureReadings.First().Pressure
        : 0;

    public double RemainingRelativePressure => PressureReadings.Count > 0
        ? EstimatedPressure / (double)InitialPressure
        : 1.0;

    public int ReturnPressure
        => 2 * (InitialPressure - StartedWorkingReading?.Pressure ?? 0);

    public bool Equals(Person? other)
        => Person.Equals(other);

    public void UpdatePressureEstimate()
    {
        if (LatestReading == null)
        {
            return;
        }

        var timeSinceLastReading = DateTime.Now - LatestReading!.Time;

        EstimatedPressure = LatestReading!.Pressure
            - (int)Math.Round(timeSinceLastReading.TotalMinutes * _settingsService.EstimatedAirConsumptionRate_BarPerMinute);
        OnPropertyChanged(nameof(RemainingRelativePressure));
    }

    private void PressureReadings_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Person.PressureReadings = [.. PressureReadings];
        LatestReading = PressureReadings.Last();
        if (StartedWorkingReading == null && State == UnitState.Working)
        {
            StartedWorkingReading = LatestReading;
        }
        OnPropertyChanged(nameof(ReturnPressure));
        UpdatePressureEstimate();
    }
}
