using AtMonitor.Views;

namespace AtMonitor;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        Current!.UserAppTheme = AppTheme.Dark;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var page = Handler.MauiContext?.Services.GetService<MainPage>();
        MainPage = new NavigationPage(page)
        {
            BarBackground = Color.Parse("#152C39"),
            BarTextColor = Colors.White,
        };

        return base.CreateWindow(activationState);
    }
}
