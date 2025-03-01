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
        public static bool ForceStop = false; // Used to force stop server
        public static int ServerPort = 7777; // Default port for The Isle
        public static bool PendingSettingsChange = false; // Used to know when to apply new settings upon server stop/restart
    }
}
