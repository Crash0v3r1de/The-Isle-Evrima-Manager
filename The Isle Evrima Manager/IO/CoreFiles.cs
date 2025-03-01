using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;
using Newtonsoft.Json;
using The_Isle_Evrima_Manager.JSON;

namespace The_Isle_Evrima_Manager.IO
{
    public static class CoreFiles
    {
        private static string currentDir = Environment.CurrentDirectory;
        private static string steamCMDDir = currentDir+@"\utils\steamcmd";
        private static string utilDir = currentDir + @"\utils";
        private static string tmpDir = currentDir + @"\tmp";


        public static void InitializeStructure() {
            if (!Directory.Exists(utilDir)) { 
            Directory.CreateDirectory(utilDir);
            }
            if (!Directory.Exists(steamCMDDir))
            {
                Directory.CreateDirectory(steamCMDDir);
            }
            if (!Directory.Exists(tmpDir))
            {
                Directory.CreateDirectory(tmpDir);
            }
            if (!Directory.Exists(ManagerGlobalTracker.serverPath))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.serverPath);
            }
            if (!Directory.Exists(ManagerGlobalTracker.logDir))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.logDir);
            }
            if (!Directory.Exists(ManagerGlobalTracker.managerConfDir)) { 
                Directory.CreateDirectory(ManagerGlobalTracker.managerConfDir);
            }
        }
        public static void SaveAndExtractSteamCMD(string tmpPath) { 
            ZipFile.ExtractToDirectory(tmpPath, steamCMDDir);
        }
        public static void SaveGameINI(List<string> ini) {
            // Saved\Config\WindowsServer - folder structure needed inside server root directory
            if (!Directory.Exists(ManagerGlobalTracker.serverPath + "Saved")) { 
                Directory.CreateDirectory(ManagerGlobalTracker.serverPath + "Saved");
            }
            if (!Directory.Exists(ManagerGlobalTracker.serverPath + @"Saved\Config"))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.serverPath + @"Saved\Config");
            }
            if (!Directory.Exists(ManagerGlobalTracker.serverPath + @"Saved\Config\WnidowsServer"))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.serverPath + @"Saved\Config\WindowsServer");
            }
            var fullPath = ManagerGlobalTracker.serverPath + ManagerGlobalTracker.gameINI;
            using (StreamWriter sw = new StreamWriter(fullPath, false)) { 
                for (int x = 0;x < ini.Count; x++)
                {
                    // Write to file in order
                    sw.WriteLine(ini[x]);
                }
            }
        }
        public static void SaveEngineINI(List<string> ini) {
            // Saved\Config\WindowsServer - folder structure needed inside server root directory
            if (!Directory.Exists(ManagerGlobalTracker.serverPath + "Saved"))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.serverPath + "Saved");
            }
            if (!Directory.Exists(ManagerGlobalTracker.serverPath + @"Saved\Config"))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.serverPath + @"Saved\Config");
            }
            if (!Directory.Exists(ManagerGlobalTracker.serverPath + @"Saved\Config\WnidowsServer"))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.serverPath + @"Saved\Config\WindowsServer");
            }
            var fullPath = ManagerGlobalTracker.serverPath + ManagerGlobalTracker.engineINI;
            using (StreamWriter sw = new StreamWriter(fullPath, false))
            {
                for (int x = 0; x < ini.Count; x++)
                {
                    // Write to file in order
                    sw.WriteLine(ini[x]);
                }
            }
        }
        public static void PrcoessServerPathMove(string newPath) {
            if (Directory.Exists(ManagerGlobalTracker.serverPath+ "TheIsle")) {
                Directory.Move(ManagerGlobalTracker.serverPath, newPath);
            }            
            if(ManagerGlobalTracker.serverPath != newPath) ManagerGlobalTracker.serverPath = newPath; // Set new path also - if move before install this'll keep everything happy
        }
        public static bool CopyDLLs() {
            try {
                // We'll group all for now, maybe breakout to new method(s) later
                File.WriteAllBytes(ManagerGlobalTracker.dllDir + "steamclient.dll", Properties.Resources.steamclient);
                File.WriteAllBytes(ManagerGlobalTracker.dllDir + "steamclient64.dll", Properties.Resources.steamclient64);
                File.WriteAllBytes(ManagerGlobalTracker.dllDir + "tier0_s.dll", Properties.Resources.tier0_s);
                File.WriteAllBytes(ManagerGlobalTracker.dllDir + "tier0_s64.dll", Properties.Resources.tier0_s64);
                File.WriteAllBytes(ManagerGlobalTracker.dllDir + "vstdlib_s.dll", Properties.Resources.vstdlib_s);
                File.WriteAllBytes(ManagerGlobalTracker.dllDir + "vstdlib_s64.dll", Properties.Resources.vstdlib_s64);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message,LogType.Error);
                return false;
            }            
            return true;
        }
        public static void WriteEngineINI() {
            // The server when ran seems to remove this file and this is used in the run arguments but we'll write it anyway
            var fullPath = ManagerGlobalTracker.serverPath + ManagerGlobalTracker.engineINI;
            using (StreamWriter sw = new StreamWriter(fullPath,false)) { 
                sw.WriteLine("[EpicOnlineServices]");
                sw.WriteLine("DedicatedServerClientId=xyza7891gk5PRo3J7G9puCJGFJjmEguW");
                sw.WriteLine("DedicatedServerClientSecret=pKWl6t5i9NJK8gTpVlAxzENZ65P8hYzodV8Dqe5Rlc8");
            }
        }
        public static void SaveManagerSettings()
        {
            var fullPath = ManagerGlobalTracker.managerConfDir + "manager.json";
            File.WriteAllText(fullPath, JsonConvert.SerializeObject(ParseManagerSettings()));
        }

        #region Private Methods
        private static ManagerSettingsJSON ParseManagerSettings() {
            ManagerSettingsJSON managerSettings = new ManagerSettingsJSON();
            managerSettings.AutoloadDLLs = ManagerGlobalTracker.autoloadDLLs;
            managerSettings.checkForManagerUpdates = ManagerGlobalTracker.checkForManagerUpdates;
            managerSettings.cplusplusInstalled = ManagerGlobalTracker.cplusplusInstalled;
            managerSettings.CurrentStatus = ManagerGlobalTracker.CurrentStatus;
            managerSettings.discordWebhookURL = ManagerGlobalTracker.discordWebhookURL;
            managerSettings.enableDiscordNotifications = ManagerGlobalTracker.enableDiscordNotifications;
            managerSettings.engineINI = ManagerGlobalTracker.engineINI;
            managerSettings.isleServerInstalled = ManagerGlobalTracker.isleServerInstalled;
            managerSettings.logDir = ManagerGlobalTracker.logDir;
            managerSettings.managerConfDir = ManagerGlobalTracker.managerConfDir;
            managerSettings.monitorHardware = ManagerGlobalTracker.monitorHardware;
            managerSettings.monitorServer = ManagerGlobalTracker.monitorServer;
            managerSettings.resourceRefreshInt = ManagerGlobalTracker.resourceRefreshInt;
            managerSettings.serverExe = ManagerGlobalTracker.serverExe;
            managerSettings.serverPath = ManagerGlobalTracker.serverPath;
            managerSettings.serverStatsRefreshInt = ManagerGlobalTracker.serverStatsRefreshInt;
            managerSettings.steamCMDexe = ManagerGlobalTracker.steamCMDexe;
            managerSettings.steamCMDInstalled = ManagerGlobalTracker.steamCMDInstalled;
            managerSettings.steamCMDInitialized = ManagerGlobalTracker.steamCMDInitialized;
            managerSettings.steamClientInstalled = ManagerGlobalTracker.steamClientInstalled;
            managerSettings.tmpPath = ManagerGlobalTracker.tmpPath;
            managerSettings.utilPath = ManagerGlobalTracker.utilPath;
            return managerSettings;
        }
        #endregion
    }
}
