﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterAlarmClock
{
    public interface Imessage
    {
        void ShowMessageAndCatchAction(string Message, Action<string> ToClick);
    }
}
