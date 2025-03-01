using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.Threadz.ThreadTracking
{
    public static class GameServerStatusTracker
    {
        public static bool RestartProcessOnFail = true;
        public static bool DiscordNotifyOnFail = true;
        public static bool AllowServerRunning = true; // Used for thread to know when to stop server
    }
}
