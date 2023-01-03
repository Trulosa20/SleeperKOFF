using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerSheet.SleeperModels
{
    public class Settings
    {
        public int wins { get; set; }
        public int waiver_position { get; set; }
        public int waiver_budget_used { get; set; }
        public int total_moves { get; set; }
        public int ties { get; set; }
        public int rank { get; set; }
        public int ppts_decimal { get; set; }
        public int ppts { get; set; }
        public int losses { get; set; }
        public int fpts_decimal { get; set; }
        public int fpts_against_decimal { get; set; }
        public int fpts_against { get; set; }
        public int fpts { get; set; }
    }
}
