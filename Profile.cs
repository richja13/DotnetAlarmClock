using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace BetterAlarmClock
{


    public class Profile
    {
        public string? UserName { get; private set; }
        public string? ProfilePictureURL { get; private set; }
        public Followers? UserFollows { get; private set; }
        public bool IsAuthenticated { get; private set; } = false;

        public Profile()
        {
           
        }
    }
}
