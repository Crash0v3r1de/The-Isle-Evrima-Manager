using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.JSON;
using The_Isle_Evrima_Manager.JSON.RCON_Task;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

namespace The_Isle_Evrima_Manager.IO
{
    public class ManagerSettingsIO
    {
        private string managerSettingsJSON = ManagerGlobalTracker.managerConfDir + @"\manager.json";
        private string rconSettingsJSON = ManagerGlobalTracker.managerConfDir + @"\rcon.json";
        private string rconTasksJSON = ManagerGlobalTracker.managerConfDir + @"\rcon-tasks.json";

        public bool FirstRun()
        {
            return !File.Exists(managerSettingsJSON);
        }
        public bool RCONTasksPresent() { 
            return File.Exists(rconTasksJSON);
        }
        public void LoadManagerSettings()
        {
            string json = File.ReadAllText(managerSettingsJSON);
            ParseLoadedSettings(JsonConvert.DeserializeObject<ManagerSettingsJSON>(json));
        }
        public void LoadRCONSettings()
        {
            string json = File.ReadAllText(managerSettingsJSON);
            ParseRCONSettings(JsonConvert.DeserializeObject<RCONSettingsJSON>(json));
        }
        public void LoadRCONTasks()
        {
            if (RCONTasksPresent())
            { // Just some added validation so we don't load a non existent file
                string json = File.ReadAllText(managerSettingsJSON);
                ParseRCONTasks(JsonConvert.DeserializeObject<List<RCONTaskItemJSON>>(json));
            }            
        }
        public bool GameSettingsPresent() { 
            return File.Exists(ManagerGlobalTracker.managerConfDir + "game-settings.json");
        }


        #region Private Methods
        private void ParseLoadedSettings(ManagerSettingsJSON data) { 
            ManagerGlobalTracker.CurrentStatus = data.CurrentStatus;
            ManagerGlobalTracker.steamCMDexe = data.steamCMDexe;
            ManagerGlobalTracker.utilPath = data.utilPath;
            ManagerGlobalTracker.tmpPath = data.tmpPath;
            ManagerGlobalTracker.serverPath = data.serverPath;
            ManagerGlobalTracker.serverExe = data.serverExe;
            ManagerGlobalTracker.gameINI = data.gameINI;
            ManagerGlobalTracker.logDir = data.logDir;
            ManagerGlobalTracker.managerConfDir = data.managerConfDir;
            ManagerGlobalTracker.resourceRefreshInt = data.resourceRefreshInt;
            ManagerGlobalTracker.serverStatsRefreshInt = data.serverStatsRefreshInt;
            ManagerGlobalTracker.monitorHardware = data.monitorHardware;
            ManagerGlobalTracker.monitorServer = data.monitorServer;
            ManagerGlobalTracker.checkForManagerUpdates = data.checkForManagerUpdates;
            ManagerGlobalTracker.enableDiscordNotifications = data.enableDiscordNotifications;
            ManagerGlobalTracker.discordWebhookURL = data.discordWebhookURL;
            ManagerGlobalTracker.cplusplusInstalled = data.cplusplusInstalled;
            ManagerGlobalTracker.steamClientInstalled = data.steamClientInstalled;
            ManagerGlobalTracker.steamCMDInstalled = data.steamCMDInstalled;
            ManagerGlobalTracker.isleServerInstalled = data.isleServerInstalled;

        }
        private void ParseRCONSettings(RCONSettingsJSON data) { 
            RCONGlobalTracker.rconHost  = data.rconHost;
            RCONGlobalTracker.rconPort = data.rconPort;
            RCONGlobalTracker.rconPassword = data.rconPassword;
            RCONGlobalTracker.rconEnabled  = data.rconEnabled;
        }
        private void ParseRCONTasks(List<RCONTaskItemJSON> data)
        {
            for (int x = 0; x < data.Count;x++) { 
                RCONGlobalTasks.rconTasks.Add(data[x]);
            }
        }
        #endregion
    }
}
