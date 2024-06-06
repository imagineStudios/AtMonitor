using AtMonitor.ViewModels;

namespace AtMonitor.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void NewMissionButton_Clicked(object sender, EventArgs e)
    {
        var page = Handler?.MauiContext?.Services.GetService<MissionPage>();
        //Application.Current.MainPage = page;
        Navigation.PushAsync(page);
    }

    private void ReportsButton_Clicked(object sender, EventArgs e)
    {
        var page = Handler?.MauiContext?.Services.GetService<ReportPage>();
        Navigation.PushAsync(page);
        //Application.Current.MainPage = new NavigationPage(page);
    }
}
