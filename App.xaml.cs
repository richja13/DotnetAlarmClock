
namespace BetterAlarmClock
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();


            string Message = string.Empty;
           }
            /*#if ANDROID
                    if (Platforms.Android.AndroidServiceManager.IsRunning)
                    {
                        BetterAlarmClock.Platforms.Android.AndroidServiceManager.StartMyService();
                        Message = "Service has started";
                    }
                    else{
                        Message = "Service is running";
                    }
            #endif
                    }
                }*/


            /*  public void StopService()
              {
          #if ANDROID
                  BetterAlarmClock.Platforms.Android.AndroidServiceManager.StopMyService();
                  Message = "Service is stopped";
          #endif*/
        }

    }