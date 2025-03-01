using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.JSON
{
    public class RCONSettingsJSON
    {
        public string rconHost { get; set; } = "127.0.0.1";
        public string rconPort { get; set; } = "1000";
        public string rconPassword { get; set; } = "password";
        public bool rconEnabled { get; set; } = false;
    }
}
