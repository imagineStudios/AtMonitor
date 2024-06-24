using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AtMonitor.ViewModels;

public partial class PickerViewModel<T>(T item) : ObservableObject
{
    [ObservableProperty]
    private bool isChecked;

    public event EventHandler? PickStateChanged;

    public T Item { get; } = item;

    public string Title => Item?.ToString() ?? "Item";

    [RelayCommand]
    private void Tapped()
    {
        IsChecked = !IsChecked;
        PickStateChanged?.Invoke(this, EventArgs.Empty);
    }
}
