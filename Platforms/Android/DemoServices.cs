
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BetterAlarmClock;
using BetterAlarmClock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resource = BetterAlarmClock.Resource;
using Android.Support.V4.App;
using AndroidX.Core.App;
using BetterAlarmClock.ViewModel;

namespace BetterAlarmClock.Platforms.Android.Resources
{

    [Service]
    public class DemoServices : Service  //, IServices
    {

        private string NOTIFICATION_CHANNEL_ID = "1000";
        private int NOTIFICATION_ID = 1;
        private string NOTIFICATION_CHANNEL_NAME = "notification";
        Collection<string> alarmTime;
        public static string NotificationTime = "00:00";


        private void startForegroundService()
        {
           

            var notifcationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                createNotificationChannel(notifcationManager);
            }

            var intent = new Intent(this, typeof(StopAlarmReciver));
            PendingIntent alarmPendingIntent = PendingIntent.GetBroadcast(this, 0, intent, 0);


        var notification = new NotificationCompat.Builder(this, NOTIFICATION_CHANNEL_ID);
            notification.SetAutoCancel(false);
            notification.SetOngoing(true);
            notification.SetSmallIcon(Resource.Drawable.appIcon);
            notification.SetContentTitle("ALARM");
            notification.AddAction(Resource.Drawable.exo_icon_pause, "Stop Alarm", alarmPendingIntent);


            notification.SetContentText($"Alarm: {NotificationTime}"); 

            StartForeground(NOTIFICATION_ID, notification.Build());
        }

       
        private void createNotificationChannel(NotificationManager notificationMnaManager)
        {
            var channel = new NotificationChannel(NOTIFICATION_CHANNEL_ID, NOTIFICATION_CHANNEL_NAME,
            NotificationImportance.Max);
            notificationMnaManager.CreateNotificationChannel(channel);
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }


        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            startForegroundService();
            return StartCommandResult.NotSticky;
        }
    }

    /* public override IBinder OnBind(Intent intent)
     {
         throw new NotImplementedException();
     }
     [return: GeneratedEnum]
     public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
     {
         if (intent.Action == "START_SERVICE")
         {
             System.Diagnostics.Debug.WriteLine("Start service");
         }
         else if (intent.Action == "STOP_SERVICE")
         {
             System.Diagnostics.Debug.WriteLine("Stop service");
             StopForeground(true);
             StopSelfResult(startId);
         }
         return StartCommandResult.Sticky;
     }

     public void Start()
     {

         Intent startService = new Intent(MainActivity.ActivityCurrent, typeof(DemoServices));
         startService.SetAction("START_SERVICE");
         if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
         {
             MainActivity.ActivityCurrent.StartForegroundService(startService);
             RegisterNotification();

         }
         else
         {
             MainActivity.ActivityCurrent.StartService(startService);
             RegisterNotification();

         }
     }

     public void Stop()
     {
         Intent stopIntent = new Intent(MainActivity.ActivityCurrent, this.Class);
         stopIntent.SetAction("STOP_SERVICE");
         if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
         {
             MainActivity.ActivityCurrent.StartForegroundService(stopIntent);
             StopForeground(true);
             StopSelfResult(startId);
         }
         else
         {
             MainActivity.ActivityCurrent.StartService(stopIntent);
         }
     }

     private void RegisterNotification()
     {
         NotificationChannel channel = new NotificationChannel("Service Channel", "Service Demo", NotificationImportance.Max);
         NotificationManager manager = (NotificationManager)MainActivity.ActivityCurrent.GetSystemService(Context.NotificationService);
         manager.CreateNotificationChannel(channel);
         Notification notification = new Notification.Builder(this, "ServicioChannel")
             .SetContentTitle("Background Service")
             .SetSmallIcon(Resource.Drawable.AppIcon)
             .SetOngoing(true)
             .Build();

         StartForeground(100, notification);

     }*/
}



