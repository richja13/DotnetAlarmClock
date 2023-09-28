using BetterAlarm.ViewModel;
using BetterAlarmClock.Services;
using BetterAlarmClock.View;
using BetterAlarmClock.ViewModel;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using BetterAlarmClock.spotify;
#if ANDROID
using BetterAlarmClock.Platforms.Android.Resources;
#endif

namespace BetterAlarmClock
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
#if ANDROID
                //  builder.Services.AddTransient<IServices, DemoServices>();
                  //builder.Services.AddTransient<Imessage, ShowMessage>();
#endif
                

                builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMediaElement()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<Alarm>();

     
            builder.Services.AddTransient<AlarmDetailsView>();
            builder.Services.AddSingleton<AlarmDetailsPage>();
            builder.Services.AddTransient<SpotifyConnect>();
            builder.Services.AddSingleton<AlarmsViewModel>();
            builder.Services.AddSingleton<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}