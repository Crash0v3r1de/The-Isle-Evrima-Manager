using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.Enums;

namespace The_Isle_Evrima_Manager.Threadz.ThreadTracking
{
    public static class ManagerGlobalTracker
    {
        private static string currDir = Environment.CurrentDirectory;
        public static ManagerStatus CurrentStatus { get; set; } = ManagerStatus.idle;
        public static bool IsRunning { get; set; } = true;
        public static string steamCMDexe = Environment.CurrentDirectory + @"\utils\steamcmd\steamcmd.exe";
        public static string utilPath = Environment.CurrentDirectory + @"\utils\";
        public static string tmpPath = Environment.CurrentDirectory + @"\tmp\";
        public static string serverPath = Environment.CurrentDirectory + @"\server\";
        public static string dllDir = Environment.CurrentDirectory + @"\server\TheIsle\Binaries\Win64\";
        public static string serverExe = Environment.CurrentDirectory + @"\server\TheIsleServer.exe";
        public static string gameINI { get; set; } = @"TheIsle\Saved\Config\WindowsServer\Game.ini";
        public static string engineINI { get; set; } = @"TheIsle\Saved\Config\WindowsServer\Engine.ini";
        public static string serverCoreExe { get; set; } = Environment.CurrentDirectory + @"\server\TheIsle\Binaries\Win64\TheIsleServer-Win64-Shipping.exe";
        public static string logDir = Environment.CurrentDirectory + @"\logs\";
        public static string managerConfDir = Environment.CurrentDirectory + @"\conf\";
        public static int resourceRefreshInt = 1200;
        public static int serverStatsRefreshInt = 1200;
        public static bool monitorHardware = true;
        public static bool monitorServer = true;
        public static bool checkForManagerUpdates = true;
        public static bool enableDiscordNotifications = true;
        public static string discordWebhookURL = "";
        public static bool cplusplusInstalled = false;
        public static bool steamClientInstalled = false;
        public static bool steamCMDInstalled = false;
        public static bool isleServerInstalled = false;
        public static bool autoloadDLLs = true;
        public static bool steamCMDInitialized = false;
        public static bool customServerDir = false;
    }
}
