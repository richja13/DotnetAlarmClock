
using BetterAlarmClock.Services;
using BetterAlarmClock.View;
using BetterAlarm.ViewModel;
using System.Security.Claims;
using BetterAlarmClock.spotify;

namespace BetterAlarmClock.ViewModel
{
    public partial class AlarmsViewModel : ObservableObject
    {
        public ObservableCollection<Alarm> Alarms { get; } = new();

        [ObservableProperty] 
        string hours;

        AlarmDetailsView AlarmDetail;

        public static AlarmsViewModel Instance;

        public AlarmsViewModel()
        {
        
        }

        [RelayCommand]
        public void AddAlarmClock(Alarm alarm)
        {
            Alarms.Add(alarm);
        }

        [RelayCommand]
        async Task SetAlarmClockAsync()
        {
            Instance = this;
            await Shell.Current.GoToAsync(nameof(AlarmDetailsPage),true);
        }

        [RelayCommand]
        public void ToggledAlarm(Alarm alarm)
        {
            Shell.Current.DisplayAlert("HELL YEAH", alarm.IsEnabled.ToString(), "Ok");

            if (alarm.IsEnabled) alarm.IsEnabled = false;
            else alarm.IsEnabled = true;
        }

        [RelayCommand]
        async Task SpotifyTest()
        {
            SpotifyConnect.AddSpotifySong();
        }
    }
}
