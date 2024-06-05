using AtMonitor.Models;
using AtMonitor.ViewModels;
using Microsoft.Extensions.Logging;

namespace AtMonitor
{
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
                });

            builder.Services.AddTransient(typeof(MainPage));
            builder.Services.AddTransient(typeof(MainPageViewModel));
            builder.Services.AddSingleton(typeof(IStore<Person>), new ConstStore<Person>(Mock.People));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
