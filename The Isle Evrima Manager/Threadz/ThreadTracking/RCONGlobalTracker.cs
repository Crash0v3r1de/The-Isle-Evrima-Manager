using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.Threadz.ThreadTracking
{
    public static class RCONGlobalTracker
    {
        public static string rconHost { get; set; } = "127.0.0.1";
        public static string rconPort { get; set; } = "1000";
        public static string rconPassword { get; set; } = "password";
        public static bool rconEnabled { get; set; } = false;
        public static bool isConnected { get; set; } = false;
    }
}
