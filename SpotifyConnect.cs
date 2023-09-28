using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Skybrud.Social.Spotify.OAuth;
using Skybrud.Social.Spotify.Responses.Authentication;
using static SpotifyAPI.Web.PlayerSetRepeatRequest;
using System.Net;
using static System.Net.WebRequestMethods;

namespace BetterAlarmClock.spotify
{
    public partial class SpotifyConnect : ObservableObject
    {
       
      

        public static async Task AddSpotifySong()
        {
            HttpClient client = new HttpClient();

            var spotify = new SpotifyClient("b970af07795545b19c914cc261c18fa0");
           // var track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH");
            var tracks = spotify.Library.GetTracks();
            await Shell.Current.DisplayAlert("Spotify:", client.ToString(), "OK");
        }

       
    }
}
