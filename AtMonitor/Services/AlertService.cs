namespace AtMonitor.Services;

public class AlertService : IAlertService
{
    public Task ShowAlertAsync(string title, string message, string cancel = "OK")
        => Application.Current!.MainPage!.DisplayAlert(title, message, cancel);

    public Task<bool> ShowConfirmationAsync(string title, string message, string accept = "Yes", string cancel = "No")
        => Application.Current!.MainPage!.DisplayAlert(title, message, accept, cancel);
}