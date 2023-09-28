using BetterAlarmClock.View;

namespace BetterAlarmClock
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AlarmDetailsPage), typeof(AlarmDetailsPage));
        }
    }
}