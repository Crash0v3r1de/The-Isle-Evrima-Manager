using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.Threadz.ThreadTracking
{
    public static class GameServerStatusTracker
    {
        public static bool RestartProcessOnFail { get; set; } = true;
        public static bool DiscordNotifyOnFail { get; set; } = true;
        public static bool AllowServerRunning { get; set; } = true; // Used for thread to know when to stop server
        public static bool ForceStop { get; set; } = false; // Used to force stop server
        public static int ServerPort { get; set; } = 7777; // Default port
        public static bool PendingSettingsChange { get; set; } = false; // Used to know when to apply new settings upon server stop/restart
    }
}
