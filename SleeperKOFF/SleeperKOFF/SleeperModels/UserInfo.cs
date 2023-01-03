using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerSheet.SleeperModels
{
    public class UserInfo
    {
        public string? username { get; set; }
        public string? user_id { get; set; }
        public string? display_name { get; set; }
        public string? avatar { get; set; }
        public List<string>? roster { get; set; } = new();
    }
}
