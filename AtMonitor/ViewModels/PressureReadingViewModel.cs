using AtMonitor.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AtMonitor.ViewModels;

public partial class PressureReadingViewModel : ObservableObject
{
    [ObservableProperty]
    private int pressure;

    public PressureReadingViewModel(PersonViewModel personViewModel, int precission)
    {
        Person = personViewModel;
        Pressure = Person.EstimatedPressure.RoundTo(precission);
    }

    public PersonViewModel Person { get; }

    public void AddReading()
    {
        Person.PressureReadings.Add(
            new PressureReading(Pressure, DateTime.Now));
    }
}
