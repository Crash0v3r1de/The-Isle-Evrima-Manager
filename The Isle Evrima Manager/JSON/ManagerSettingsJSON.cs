using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.Enums;

namespace The_Isle_Evrima_Manager.JSON
{
    public class ManagerSettingsJSON
    {
        // Needs to mirror the ManagerGlobalTracker class
        // If JSON is older/wrong scheme than this it's going to error out
        public ManagerStatus CurrentStatus { get; set; } = ManagerStatus.idle;
        public bool IsRunning { get; set; } = true;
        public string steamCMDexe { get; set; } = Environment.CurrentDirectory + @"\utils\steamcmd\steamcmd.exe";
        public string utilPath { get; set; } = Environment.CurrentDirectory + @"\utils\";
        public string tmpPath { get; set; } = Environment.CurrentDirectory + @"\tmp\";
        public string serverPath { get; set; } = Environment.CurrentDirectory + @"\server\";
        public string serverExe { get; set; } = Environment.CurrentDirectory + @"\server\TheIsleServer.exe";
        public string gameINI { get; set; } = Environment.CurrentDirectory + @"\server\Game.ini";
        public string logDir { get; set; } = Environment.CurrentDirectory + @"\logs\";
        public string managerConfDir { get; set; } = Environment.CurrentDirectory + @"\conf\";
        public int resourceRefreshInt { get; set; } = 1200;
        public int serverStatsRefreshInt { get; set; } = 1200;
        public bool monitorHardware { get; set; } = true;
        public bool monitorServer { get; set; } = true;
        public bool checkForManagerUpdates { get; set; } = true;
        public bool enableDiscordNotifications { get; set; } = true;
        public string discordWebhookURL { get; set; } = "";
        public bool cplusplusInstalled { get; set; } = false;
        public bool steamClientInstalled { get; set; } = false;
        public bool steamCMDInstalled { get; set; } = false;
        public bool isleServerInstalled { get; set; } = false;
    }
}
