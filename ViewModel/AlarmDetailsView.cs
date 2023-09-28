
using BetterAlarmClock.ViewModel;
using BetterAlarmClock.Services;
using BetterAlarmClock;
using System.Security.Cryptography.X509Certificates;

#if ANDROID
using BetterAlarmClock.Platforms.Android.Resources;
#endif

namespace BetterAlarm.ViewModel 
{
    public partial class AlarmDetailsView : ObservableObject
    {
        [ObservableProperty]
        public TimeSpan alarmTime;

        private string musicFilePath;

        [ObservableProperty]
        public string musicName = "Set Music";


        [RelayCommand]
        async Task GoBackAsync()
        {
            if (musicFilePath is null) return;
            Alarm alarm = new(AlarmTime.Hours, AlarmTime.Minutes, MusicName, "Chill", AlarmTime, musicFilePath);
            AlarmsViewModel.Instance.AddAlarmClock(alarm);
            MainPage.Instance.AlarmSet();
            MusicName = "Set Music";
            await Shell.Current.GoToAsync("..");
#if ANDROID
            Android.Content.Intent intent = new Android.Content.Intent(Android.App.Application.Context, typeof(DemoServices));
            DemoServices.NotificationTime = alarm.Time;
            Android.App.Application.Context.StartForegroundService(intent);
#endif
        }

        [RelayCommand]
        public async Task<FileResult> PickAndShow()
        {
            PickOptions options = new PickOptions();
            try
            {
                var result = await FilePicker.Default.PickAsync(options);
                if (result != null)
                {
                    if (result.FileName.EndsWith("mp3", StringComparison.OrdinalIgnoreCase))
                    {
                        using var stream = await result.OpenReadAsync();
                        musicFilePath = result.FullPath.ToString();
                        MusicName = result.FileName;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }

            return null;
        }

    }
}
