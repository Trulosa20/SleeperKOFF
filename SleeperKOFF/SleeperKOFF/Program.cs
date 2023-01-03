
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlayerSheet.SleeperModels;
using System.Collections;
using System.Xml.Linq;

namespace PlayerSheet
{

    class Program
    {

        static async Task Main(string[] args)
        {
            //START UP
            Console.WriteLine("Starting PlayerSheet import process");

            //set up of objects needed
            ExcelHelper excelHelper = new ExcelHelper();
            SleeperRepository sleeperExtract = new SleeperRepository();
            DataManipulation dataManipulation = new DataManipulation();
            List<UserInfo> managerList = new List<UserInfo>();

            //--ONLY USED ONCE FOR START UP
            //await dataManipulation.PlayerIDNameManipulation(sleeperExtract);
            //await dataManipulation.PlayerPositionNameManipulation(sleeperExtract);
            //--ONLY USED ONCE FOR START UP

            //get roster data for kyle's league
            List<Roster> rosterData = await sleeperExtract.GetRosterData();

            //Create list of each user's team info
            managerList = await dataManipulation.RosterManipulation(rosterData, sleeperExtract);

            //import player data

            //FINISH
            Console.WriteLine("PlayerSheet import process finished");
        }

        

    }

}
