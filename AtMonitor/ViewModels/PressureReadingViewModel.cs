using AtMonitor.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AtMonitor.ViewModels;

public partial class PressureReadingViewModel : ObservableObject
{
    [ObservableProperty]
    private int pressure;

    public PressureReadingViewModel(PersonViewModel personViewModel)
    {
        Person = personViewModel;
        Pressure = Person.EstimatedPressure;
    }

    public PersonViewModel Person { get; }

    public void AddReading()
    {
        Person.PressureReadings.Add(
            new PressureReading(Pressure, DateTime.Now));
    }
}
