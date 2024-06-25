using AtMonitor.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace AtMonitor.ViewModels;

public partial class UnitViewModel : ObservableObject
{
    public UnitViewModel(Unit unit)
    {
        Unit = unit;
        Members.CollectionChanged += Members_CollectionChanged;
    }

    public Unit Unit { get; }

    public string Name
    {
        get => Unit.Name;
        set => SetProperty(Unit.Name, value, Unit, (u, n) => u.Name = n);
    }

    public string? CallSign
    {
        get => Unit.CallSign;
        set => SetProperty(Unit.CallSign, value, Unit, (u, n) => u.CallSign = n);
    }

    public string Order
    {
        get => Unit.Order;
        set => SetProperty(Unit.Order, value, Unit, (u, n) => u.Order = n);
    }

    public string Location
    {
        get => Unit.Location;
        set => SetProperty(Unit.Location, value, Unit, (u, n) => u.Location = n);
    }

    public ObservableCollection<Person> Members { get; } = [];

    private void Members_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Unit.Members = [.. Members];
    }
}
