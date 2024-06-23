using AtMonitor.Models;
using AtMonitor.Services;
using AtMonitor.ViewModels;
using AtMonitor.Views;
using Microsoft.Extensions.Logging;

namespace AtMonitor;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FontAwesome6");
            })
            .RegisterServices()
            .RegisterViews()
            .RegisterViewModels();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IStore<Person>>(new ConstStore<Person>(Mock.People));
        builder.Services.AddSingleton<IAppStateService, AppStateService>();
        builder.Services.AddSingleton<ISettingsService, SettingsService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        return builder;
    }

    private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MissionFinalizationPage>();
        builder.Services.AddTransient<MissionPage>();
        builder.Services.AddTransient<PeoplePickerPage>();
        builder.Services.AddTransient<ReportPage>();
        builder.Services.AddTransient<UnitRegistrationPage>();
        return builder;
    }
    
    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<MissionPageViewModel>();
        builder.Services.AddTransient<UnitRegistrationViewModel>();
        builder.Services.AddTransient<PeoplePickerViewModel>();
        return builder;
    }
}
