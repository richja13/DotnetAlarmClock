using System.Text.Json.Serialization;
using BetterAlarmClock;
#if ANDROID
using Android.OS;
#endif

namespace BetterAlarmClock.Services
{
    public partial class Alarm : ObservableObject
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public string Music { get; set; }
        public string Melody { get; set; }
        public string Time { get; set; }
        public TimeSpan timeSet { get; set; }
        
        [ObservableProperty]
        public string timeLeft;

        [ObservableProperty]
        public bool isEnabled;

        [ObservableProperty]
        public string musicPath;

        public TimeSpan currentTime;

        public Alarm(int Hour, int Minute, string Music, string Melody, TimeSpan timeSet, string musicPath)
        {
            this.Hour = Hour;
            this.Minute = Minute;
            this.Music = Music;
            this.Melody = Melody;
            this.timeSet = timeSet;
            MusicPath = musicPath;
            currentTime = DateTime.Now.TimeOfDay;

            timeLeft = (timeSet - currentTime).ToString().Substring(0, 8);

            Time = $"{Hour.ToString("00")}:{Minute.ToString("00")}";
            IsEnabled = true;
            UpdatetimeLeft();
        }


        private void UpdatetimeLeft()
        {
            Device.StartTimer(System.TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(UpdateTime);
                return true;
            });
        }


        public async void UpdateTime()
        {
            currentTime = DateTime.Now.TimeOfDay;
/*#if ANDROID
            currentTime = SystemClock.ElapsedRealtime();            
#endif*/
            TimeLeft = (timeSet - currentTime).ToString().Substring(0, 8);
            AlarmTimer(currentTime);
        }

        public void AlarmTimer(TimeSpan localDateTime)
        {
            if (IsEnabled)
            {
                if (TimeLeft.ToString().Substring(0, 8) == "00:00:00")
                {
                    //MainPage.Instance.PlayAlarm(musicPath);
                   // Shell.Current.DisplayAlert("Wakie wakie its time for school", $"Oh noo {localDateTime.Minutes}", "OK");
                }
            }
        }


        public void ToggleAlarm()
        {
            /*  if (IsEnabled) IsEnabled = false;
              else IsEnabled = true;*/
            Shell.Current.DisplayAlert("ToggleAlarm", $"{IsEnabled}", "OK");
        }


        public Command ToggledCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (IsEnabled) IsEnabled = false;
                    else IsEnabled = true;
                });
            }
        }

    }

    [JsonSerializable(typeof(List<Alarm>))]
    internal sealed partial class AlarmContext : JsonSerializerContext
    {

    }

}

