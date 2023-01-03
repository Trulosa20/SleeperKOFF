using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlayerSheet.SleeperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlayerSheet
{
    public class DataManipulation
    {
        public string? _fullName = string.Empty;
        public string? _playerID = string.Empty;
        public string? _position = string.Empty;

        public async Task<List<UserInfo>> RosterManipulation(List<Roster> listofRosters, SleeperRepository sleeperRepo)
        {
            //set up objects needed
            string ownerID = "";
            string userName = "";
            List<UserInfo> userInfoList = new List<UserInfo>();

            List<string> rosterPlayerIDs = new List<string>();
            Dictionary<string, string> playerDictionary = new Dictionary<string, string>();
            //hit read xml
            playerDictionary = readXml("C:\\Sleeper\\nflplayerdata.xml");

            foreach (Roster roster in listofRosters)
            {
                ownerID = roster.owner_id;
                userName = await sleeperRepo.GetOwnerUserName(ownerID);
                rosterPlayerIDs = roster.players;
                UserInfo userInfo = new UserInfo();
                userInfo.username = userName;

                foreach (string playerID in rosterPlayerIDs)
                {
                    //store name of each player into roster model for each owner
                    string playerName = playerDictionary[playerID];
                    //add player name to userinfo object
                    userInfo.roster.Add(playerName);
                }

                //add user info to list of user info
                userInfoList.Add(userInfo);
            }
            // needs to return a list of userinfo for each owner that we will go into another method to export to excel
            return userInfoList;
        }

        private Dictionary<string, string> readXml(string location)
        {
            var data = new Dictionary<string, string>();

            var xml = XDocument.Load(location);
            foreach (var element in xml.Descendants("entry").ToList())
            {
                var key = element.Element("key").Value;
                var value = element.Element("value").Value;
                data.Add(key, value);
            }

            return data;
        }

        //only needs to be used once to get all player data
        public async Task<Dictionary<string, string>> PlayerIDNameManipulation(SleeperRepository sleeperRepo)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            //get player data
            JObject jsonObject = await sleeperRepo.GetAllNFLPlayers();
            foreach(var value in jsonObject)
            {
                string playerIDValue = Convert.ToString(value.Value);
                PlayerInfo modelFromBody = JsonConvert.DeserializeObject<PlayerInfo>(playerIDValue);

                _fullName = modelFromBody.full_name;
                _playerID = modelFromBody.player_id;
                dictionary.Add(_playerID, _fullName);
            }
            
            storeXml("C:\\Sleeper\\nflplayerdata.xml", dictionary);

            return dictionary;
        }

        //only needs to be used once to get all player data
        public async Task<Dictionary<string, string>> PlayerPositionNameManipulation(SleeperRepository sleeperRepo)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            //get player data
            JObject jsonObject = await sleeperRepo.GetAllNFLPlayers();
            foreach (var value in jsonObject)
            {
                string playerIDValue = Convert.ToString(value.Value);
                PlayerInfo modelFromBody = JsonConvert.DeserializeObject<PlayerInfo>(playerIDValue);

                _fullName = modelFromBody.full_name;
                _position = modelFromBody.position;

                if (_fullName == null)
                {
                    _fullName = string.Empty;
                }

                if (dictionary.Keys.Contains(_fullName))
                {
                    continue;
                }

                if(_fullName == "Duplicate Player")
                {
                    continue;
                }

                if (_position == "LB" || _position == "G" || _position == "CB" || _position == "DB" || _position == "DL" || _position == "LS" || _position == "NT" || _position == "DE" || _position == "T")
                {
                    continue;   
                }

                if(_fullName != string.Empty && _position != null)
                {
                    dictionary.Add(_fullName, _position);
                }
            }

            storeXml("C:\\Sleeper\\nflplayernamepostiondata.xml", dictionary);

            return dictionary;
        }

        //only needs to be used once to store data
        private void storeXml(string location, Dictionary<string, string> data)
        {
            var xml = new XElement("storage",
                            data.Select(kv => new XElement("entry",
                                        new XElement("key", kv.Key),
                                        new XElement("value", kv.Value))));
            xml.Save(location);
        }
    }
}
