#if ANDROID
using Android.App;
using Android.Content;
#endif

using BetterAlarmClock.ViewModel;

namespace BetterAlarmClock
{
#if ANDROID
    [BroadcastReceiver(Exported = true, Enabled = true)]

    public class AlarmReceiver : BroadcastReceiver
    {
        public override async void OnReceive(Context context, Intent intent)
        {
            MainPage.Instance.PlayAlarm(AlarmsViewModel.Instance.Alarms[0].MusicPath);
        }
    }
#endif
}