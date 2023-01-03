using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerSheet.SleeperModels
{
    public class Roster
    {
        public List<string>? taxi { get; set; }
        public List<string>? starters { get; set; }
        public Settings? settings { get; set; }
        public int roster_id { get; set; }
        public List<string>? reserve { get; set; }
        public List<string> players { get; set; }
        public string? player_map { get; set; }
        public string owner_id { get; set; }
        public string? league_id { get; set; }
        public string? keepers { get; set; }
        public string? co_owners { get; set; }
    }
}
