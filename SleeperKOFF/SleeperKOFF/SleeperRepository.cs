using Newtonsoft.Json;
using PlayerSheet.SleeperModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PlayerSheet
{
    public class SleeperRepository
    {
        //point of this public class is to have all the api endpoints that we will hit in here
        public async Task<SpecificLeague> GetLeagueName()
        {
            //set up 
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.sleeper.app/v1/league/784479845890523136", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            string requestBody = await response.Content.ReadAsStringAsync();
            SpecificLeague modelFromBody = JsonConvert.DeserializeObject<SpecificLeague>(requestBody);

            return modelFromBody;
        }

        public async Task<List<Roster>> GetRosterData()
        {
            //set up 
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.sleeper.app/v1/league/784479845890523136/rosters", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            string requestBody = await response.Content.ReadAsStringAsync();
            List<Roster> modelFromBody = JsonConvert.DeserializeObject<List<Roster>>(requestBody);

            return modelFromBody;
        }

        public async Task<string> GetOwnerUserName(string ownerID)
        {
            //set up 
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.sleeper.app/v1/user/{ownerID}", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            string requestBody = await response.Content.ReadAsStringAsync();
            UserInfo modelFromBody = JsonConvert.DeserializeObject<UserInfo>(requestBody);
            

            return modelFromBody.display_name;
        }

        public async Task<JObject> GetAllNFLPlayers()
        {
            //set up 
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.sleeper.app/v1/players/nfl", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            string requestBody = await response.Content.ReadAsStringAsync();
            var jObj = JsonConvert.DeserializeObject<JObject>(requestBody);
            //PlayerInfo modelFromBody = JsonConvert.DeserializeObject<Dictionary<string, PlayerInfo>>(requestBody);
            return jObj;
        }
    }
}
