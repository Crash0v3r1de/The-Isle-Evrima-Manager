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
        // If JSON is older/wrong scheme than this, it's going to error out
        // {serverDir}\Saved\Config\WindowsServer
        private string currDir = Environment.CurrentDirectory;
        public ManagerStatus CurrentStatus { get; set; } = ManagerStatus.idle;
        public bool IsRunning { get; set; } = true;
        public string steamCMDexe = Environment.CurrentDirectory + @"\utils\steamcmd\steamcmd.exe";
        public string utilPath = Environment.CurrentDirectory + @"\utils\";
        public string tmpPath = Environment.CurrentDirectory + @"\tmp\";
        public string serverPath = Environment.CurrentDirectory + @"\server\";
        public string dllDir = Environment.CurrentDirectory + @"\server\TheIsle\Binaries\Win64\";
        public string serverExe = Environment.CurrentDirectory + @"\server\TheIsleServer.exe";
        public string gameINI { get; set; } = @"TheIsle\Saved\Config\WindowsServer\Game.ini";
        public string engineINI { get; set; } = @"TheIsle\Saved\Config\WindowsServer\Engine.ini";
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
        public bool autoloadDLLs { get; set; } = true;
        public bool steamCMDInitialized { get; set; } = false;
        public bool customServerDir { get; set; } = false;
    }
}
