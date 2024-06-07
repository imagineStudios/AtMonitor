using AtMonitor.Services;
using AtMonitor.ViewModels;

namespace AtMonitor.Views;

public partial class MainPage : ContentPage
{
    private readonly IAppStateService _appStateService;

    public MainPage(MainPageViewModel vm, IAppStateService appStateService)
    {
        _appStateService = appStateService;
        InitializeComponent();
        BindingContext = vm;
    }

    private void NewMissionButton_Clicked(object sender, EventArgs e)
    {
        if (_appStateService.StartNewMission())
        {
            var page = Handler?.MauiContext?.Services.GetService<MissionPage>();
            Navigation.PushAsync(page);
        }
    }

    private void ReportsButton_Clicked(object sender, EventArgs e)
    {
        var page = Handler?.MauiContext?.Services.GetService<ReportPage>();
        Navigation.PushAsync(page);
    }
}
