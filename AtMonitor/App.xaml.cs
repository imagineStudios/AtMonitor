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
        MainPage = new NavigationPage(Handler.MauiContext?.Services.GetService<MainPage>());
        return base.CreateWindow(activationState);
    }
}
