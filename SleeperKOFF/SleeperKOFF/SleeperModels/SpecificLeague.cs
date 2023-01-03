using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerSheet.SleeperModels
{
    public partial class SpecificLeague
    {
        public int total_rosters { get; set; }
        public string status { get; set; } = null!;
        public string sport { get; set; } = null!;
        public object settings { get; set; } = null!;
        public string season_type { get; set; } = null!;
        public string season { get; set; } = null!;
        public object scoring_settings { get; set; } = null!;
        public object roster_positions { get; set; } = null!;
        public string previous_league_id { get; set; } = null!;
        public string name { get; set; } = null!;
        public string league_id { get; set; } = null!;
        public string avatar { get; set; } = null!;
    }
}
