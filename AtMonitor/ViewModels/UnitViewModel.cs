using AtMonitor.Models;
using AtMonitor.Services;
using AtMonitor.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AtMonitor.ViewModels;

public partial class UnitViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly ISettingsService _settingsService;
    private readonly IAlertService _alertService;
    private IDispatcherTimer updateTimer;

    [ObservableProperty]
    private UnitState state;

    [ObservableProperty]
    private bool canPeopleBeAdded;

    public UnitViewModel(
        INavigationService navigationService,
        ISettingsService settingsService,
        IAlertService alertService)
    {
        _navigationService = navigationService;
        _settingsService = settingsService;
        _alertService = alertService;
        Unit = new Unit();
        Members.CollectionChanged += Members_CollectionChanged;

        updateTimer = Application.Current!.Dispatcher.CreateTimer();
        updateTimer.Interval = TimeSpan.FromSeconds(1);
        updateTimer.Tick += UpdateTimer_Tick;
        updateTimer.Stop();

        OnStateChanged(State);
    }

    public Unit Unit { get; }

    public string Name
    {
        get => Unit.Name;
        set
        {
            SetProperty(Unit.Name, value, Unit, (u, n) => u.Name = n);
            CallSign = $"{_settingsService.BaseCallSign} {Name}";
        }
    }

    public string? CallSign
    {
        get => Unit.CallSign;
        private set => SetProperty(Unit.CallSign, value, Unit, (u, n) => u.CallSign = n);
    }

    public string Order
    {
        get => Unit.Order ?? string.Empty;
        set => SetProperty(Unit.Order, value, Unit, (u, n) => u.Order = n);
    }

    public string Location
    {
        get => Unit.Location ?? string.Empty;
        set => SetProperty(Unit.Location, value, Unit, (u, n) => u.Location = n);
    }

    public bool CanBeChanged { get; set; } = true;

    public int ReturnPressure => Members.Count > 0
        ? Members.Max(m => m.ReturnPressure) : 0;

    public TimeSpan TimeToNextReading
    {
        get
        {
            if (Members.Count == 0) return TimeSpan.FromMinutes(10);

            var lastReadingTime = Members
                .Select(m => m.LatestReading?.Time ?? default)
                .Max();

            return lastReadingTime != default
                ? lastReadingTime + TimeSpan.FromMinutes(10) - DateTime.Now
                : TimeSpan.FromMinutes(10);
        }
    }

    public ObservableCollection<PersonViewModel> Members { get; } = [];

    [RelayCommand]
    private async Task PickPeople()
        => await _navigationService.NavigateToPeoplePicker(Members);

    [RelayCommand]
    private void RemoveMember(object parameter)
        => Members.Remove((PersonViewModel)parameter);

    [RelayCommand]
    private async Task AddReading()
        => await _navigationService.NavigateToPage<PressureReadingPage>(Members);

    [RelayCommand]
    private async Task ChangeState(object parameter)
    {
        var newState = (UnitState)parameter;

        if (newState == State)
        {
            return;
        }
        else if (newState > State + 1)
        {
            if (!await _alertService.ShowConfirmationAsync(
                "Warnung",
                $"Möchten Sie wirklich einen Zustand überspringen?",
                "Ja",
                "Nein"))
            {
                return;
            }
        }
        else if (newState < State)
        {
            if (!await _alertService.ShowConfirmationAsync(
                "Warnung",
                $"Der Trupp befindet sich derzeit im Zustand \"{State.Description()}\".\nMöchten Sie den Zustand wirklich zu \"{newState.Description()}\" ändern?",
                "Ja",
                "Nein"))
            {
                return;
            }
        }

        if (newState > UnitState.Idle && Members.Sum(m => m.PressureReadings.Count) == 0
            || newState == UnitState.Working
            || await _alertService.ShowConfirmationAsync("Druck erfassen?", "", "Ja", "Nein"))
        {
            await AddReading();
        }

        State = newState;
        Members.ForEach(m => m.State = State);
    }

    partial void OnStateChanged(UnitState value)
    {
        CanPeopleBeAdded = State == UnitState.Idle;
        if (State > UnitState.Idle && State < UnitState.Done)
        {
            updateTimer.Start();
        }
        else
        {
            updateTimer.Stop();
        }
    }

    private void UpdateTimer_Tick(object? sender, EventArgs e)
    {
        Members.ForEach(m => m.UpdatePressureEstimate());
        OnPropertyChanged(nameof(TimeToNextReading));
        OnPropertyChanged(nameof(ReturnPressure));
    }

    private void Members_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Unit.Members = [.. Members.Select(pvm => pvm.Person)];
    }
}