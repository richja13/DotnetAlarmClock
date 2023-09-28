using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;

namespace BetterAlarmClock.Platforms.Android
{
    public class MyBackgroundService 
    {
        /* Timer timer = null;
         int myId = (new object()).GetHashCode();
         int BadgeNumber = 0;

         public override IBinder OnBind(Intent intent)
         {
             return null;
         }

         public override StartCommandResult OnStartCommand(Intent intent,
             StartCommandFlags flags, int startId)
         {
             var input = intent.GetStringExtra("inputExtra");

             var notificationIntent = new Intent(this, typeof(MainActivity));
             var pendingIntent = PendingIntent.GetActivity(this, 0, notificationIntent,
                 PendingIntentFlags.Immutable);

             var notification = new NotificationCompat.Builder(this,
                     MainApplication.ChannelId)
                 .SetContentText(input)
                 .SetSmallIcon(Resource.Drawable.AppIcon)
                 .SetContentIntent(pendingIntent);

             // Increment the BadgeNumber
             BadgeNumber++;
             // set the number
             notification.SetNumber(BadgeNumber);
             // set the title (text) to Service Running
             notification.SetContentTitle("Service Running");
             // build and notify
             StartForeground(myId, notification.Build());

             // timer to ensure hub connection
             timer = new Timer(Timer_Elapsed, notification, 0, 10000);

             // You can stop the service from inside the service by calling StopSelf();

             return StartCommandResult.Sticky;
         }


         /// <summary>
         /// 
         /// </summary>
         /// <param name="state"></param>
         async void Timer_Elapsed(object state)
         {
             AndroidServiceManager.IsRunning = true;

             BadgeNumber++;
             string timeString = $"Time: {DateTime.Now.ToLongTimeString()}";
             var notification = (Notification.Builder)state;
             notification.SetNumber(BadgeNumber);
             notification.SetContentTitle(timeString);
             StartForeground(myId, notification.Build());
         }*/
    }
}
