using BetterAlarm.ViewModel;
using BetterAlarmClock.ViewModel;
using BetterAlarmClock.Services;

namespace BetterAlarmClock.View;

public partial class AlarmDetailsPage : ContentPage
{
    public AlarmDetailsPage(AlarmDetailsView viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;  
    }

   /* public TimeSpan _alarmTime;


    public async Task SetAlarmClock()
    {
        _alarmTime = alarmTime1.Time;
        Alarm alarm = new(_alarmTime.Hours, _alarmTime.Minutes, "After Hours", "Spokojna");
        AlarmsViewModel.Alarms.Add(alarm);
        await Shell.Current.Navigation.PopToRootAsync();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        
        //_alarmTime = alarmTime1.Time;
        //Alarm alarm = new(_alarmTime.Hours, _alarmTime.Minutes, "After Hours", "Spokojna");
        //AlarmsViewModel.Alarms.Add(alarm);
        await Shell.Current.GoToAsync("..");
    }

    private void alarmTime1_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        //_alarmTime = alarmTime1.Time;
        //Debug.WriteLine(alarmTime1.Time);
    }*/

    protected override void OnNavigatedTo(NavigatedToEventArgs e)
    {
        base.OnNavigatedTo(e);
    }
}