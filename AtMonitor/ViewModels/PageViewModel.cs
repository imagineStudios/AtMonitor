using CommunityToolkit.Mvvm.ComponentModel;

namespace AtMonitor.ViewModels;

public class PageViewModel : ObservableObject
{
    public virtual void OnNavigatingTo(object? parameter)
    {
    }

    public virtual void OnNavigatedFrom(bool isForwardNavigation)
    {
    }

    public virtual void OnNavigatedTo()
    {
    }
}
