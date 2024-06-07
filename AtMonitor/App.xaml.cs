using AtMonitor.Views;

namespace AtMonitor;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var page = Handler.MauiContext?.Services.GetService<MainPage>();
        MainPage = new NavigationPage(page)
        {
            BarBackground = Colors.IndianRed,
            BarTextColor = Colors.White,
        };

        return base.CreateWindow(activationState);
    }
}
