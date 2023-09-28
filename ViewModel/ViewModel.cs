using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterAlarmClock.ViewModel
{
    public abstract partial class ViewModel : TinyViewModel
    {
        public ViewModel()
        {
        }

        protected virtual Task HandleException(Exception ex)
        {
            if (ex is UnauthorizedAccessException)
            {
                Navigation.NavigateTo("//Login");
            }

            Console.Write(ex);

            return Task.CompletedTask;
        }
    }
}
