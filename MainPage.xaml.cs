using BetterAlarmClock.Services;
using BetterAlarmClock.ViewModel;
using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Net;
using System.Timers;
using static SpotifyAPI.Web.PlayerSetRepeatRequest;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;


#if ANDROID
using BetterAlarmClock.Platforms.Android.Resources;
using Android.App;
using Android.OS;
using Android.Content;
#endif

namespace BetterAlarmClock
{
    public partial class MainPage : ContentPage
    {

        // Service service;
#if ANDROID

        public PendingIntent pendingIntent;
        Android.Content.Intent intent;
        public AlarmManager alarmManager;
#endif

        AlarmsViewModel alarmViewModel;
        public string MessageToast { get; set; }
        public int CounterSnack { get; set; }
        public static MainPage Instance;
        string Source;
        private readonly string state;


        public List<MediaElement> mediaElements = new();

        public MainPage()
        {
            InitializeComponent();
            alarmViewModel = new AlarmsViewModel();
            BindingContext = alarmViewModel;
            Instance = this;
            state = Guid.NewGuid().ToString();
#if ANDROID
            Android.Content.Intent intent = new Android.Content.Intent(Android.App.Application.Context, typeof(DemoServices));
            Android.App.Application.Context.StartForegroundService(intent);
#endif

            Microsoft.Maui.Handlers.WebViewHandler.Mapper.AppendToMapping("UserAgent", (handler, webview) =>
            {

                var userAgent = "Chrome";
#if ANDROID
            handler.PlatformView.Settings.UserAgentString = userAgent;
#elif IOS
                handler.PlatformView.CustomUserAgent = userAgent;
#endif
            });
        }





        public void AlarmSet()
        {
#if ANDROID
            foreach (Alarm alarm in alarmViewModel.Alarms)
            {
                if (alarm.isEnabled)
                {
                    TimeSpan time = alarm.timeSet;

                    var intent = new Android.Content.Intent(Android.App.Application.Context, typeof(AlarmReceiver));

                    pendingIntent = PendingIntent.GetBroadcast(Android.App.Application.Context, 0, intent, PendingIntentFlags.Immutable);

                    intent.PutExtra("pendingIntent", pendingIntent);

                    alarmManager = (AlarmManager)Android.App.Application.Context.GetSystemService(Context.AlarmService);

                    DateTime startTime = new DateTime() + time;

                    long interval = (long)(time.TotalMilliseconds - DateTime.Now.TimeOfDay.TotalMilliseconds);//AlarmManager.IntervalDay  60 * 
                    alarmManager.Set(AlarmType.ElapsedRealtimeWakeup, SystemClock.ElapsedRealtime() + interval, pendingIntent);
                    TestLabel.Text = $"Alarms should work: {SystemClock.ElapsedRealtime() + interval}";
                   // (long)time.TotalMilliseconds
                }

            }

#endif
        }



        public void PlayAlarm(string source)
        {
            MediaElement mediaElement = new MediaElement
            {
                ShouldAutoPlay = true,
                Source = MediaSource.FromFile(source),
                Volume = 1,
                IsVisible = false,
            };

            mediaElements.Add(mediaElement);

            SoundLabel.Add(mediaElement);

            System.Timers.Timer t = new();
            t.Interval = 180000;
            t.Elapsed += PlayMelody;
            t.Enabled = true;
            t.AutoReset = false;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            //("C:\\Users\\xmadi\\Music\\BIGUF.mp3");
            //  Services.Stop();
            //  Shell.Current.DisplayAlert("Service should stop", Services.ToString(), "OK");
#if ANDROID
            var isPendingIntentValid = (pendingIntent != null);

                if (isPendingIntentValid)
                {
                    TestLabel.Text = "The PendingIntent is still valid";
                }
                else
                {
                    TestLabel.Text = "The PendingIntent is no longer valid";
                }

#endif

        }

        private void ImageButton_Clicked1(object sender, EventArgs e)
        {
            //   Services.Start();
            Shell.Current.DisplayAlert("Service should run", "AlarmCancel", "OK");
#if ANDROID
            alarmManager.Cancel(pendingIntent);
#endif

        }


        private void ImageButton_Clicked2(object sender, EventArgs e)
        {
#if ANDROID
    Android.Content.Intent intent = new Android.Content.Intent(Android.App.Application.Context,typeof(DemoServices));
    Android.App.Application.Context.StartForegroundService(intent);
#endif
        }

        private void PlayMelody(Object source, System.Timers.ElapsedEventArgs e)
        {
            MainThread.InvokeOnMainThreadAsync(() =>
            {

                MediaElement mediaElement = new MediaElement
                {
                    ShouldAutoPlay = true,
                    Source = MediaSource.FromFile("C:\\Users\\xmadi\\Music\\Pop.mp3"),
                    Volume = 1,
                    IsVisible = false,
                };

                SoundLabel.Add(mediaElement);

            });

        }


        void Connect()
        {
            var scopes = "playlist-read-private playlist-modify-private";

            var querystring = $"response_type=code&client_id={Constants.SpotifyClientId}&scopes={WebUtility.UrlEncode(scopes)}&redirect_uri={Constants.RedirectUrl}&state={state}";

          /*  LoginWeb.Source = $"https://accounts.spotify.com/authorize?{querystring}";

            LoginWeb.Navigating += LoginWeb_Navigating;*/
        }


        private void LoginWeb_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (!e.Url.Contains("redirect_uri") && e.Url.Contains(Constants.RedirectUrl))
            {
                var queryString = e.Url.Split("?").Last();
                var parts = queryString.Split("&");

                var parameters = parts.Select(x => x.Split("=")).ToDictionary(x => x.First(), x => x.Last());

                var code = parameters["code"];
                var returnState = parameters["state"];

                if (returnState == state && !string.IsNullOrWhiteSpace(code))
                {
                   // _ = Task.Run(async () => await LoginViewModel.HandleAuthCode(code));

                }
            }
        }
    }
}
