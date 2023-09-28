using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if ANDROID
using Android.App;
using Android.Content;
using CommunityToolkit.Maui.Views;
#endif

namespace BetterAlarmClock
{
#if ANDROID
    [BroadcastReceiver(Exported = true, Enabled = true)]

    public class StopAlarmReciver : BroadcastReceiver
    {
        public override async void OnReceive(Context context, Intent intent)
        {
            MainPage.Instance.mediaElements[0].Stop();
            foreach(MediaElement alarmMedia in MainPage.Instance.mediaElements)
            {
                if(alarmMedia.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
                {
                    alarmMedia.Stop();
                }
            }

            Shell.Current.DisplayAlert("Stop alarm","alarms stopped", "ok");
        }

        public void StopAlarm()
        {

        }
    }
#endif
}
