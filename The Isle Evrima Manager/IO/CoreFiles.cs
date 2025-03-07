using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;
using Newtonsoft.Json;
using The_Isle_Evrima_Manager.JSON;
using static System.Windows.Forms.LinkLabel;
using The_Isle_Evrima_Manager.JSON.RCON_Task;

namespace The_Isle_Evrima_Manager.IO
{
    public static class CoreFiles
    {
        public static void InitializeStructure() {
            if (!Directory.Exists(ManagerGlobalTracker.utilPath)) { 
            Directory.CreateDirectory(ManagerGlobalTracker.utilPath);
            }
            if (!Directory.Exists(ManagerGlobalTracker.utilPath+ @"steamcmd\"))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.utilPath + @"steamcmd\");
            }
            if (!Directory.Exists(ManagerGlobalTracker.tmpPath))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.tmpPath);
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
            ZipFile.ExtractToDirectory(tmpPath, ManagerGlobalTracker.utilPath + @"steamcmd\");
            ManagerGlobalTracker.steamCMDInstalled = true;
            CoreFiles.SaveManagerSettings();
        }
        public static void SaveGameINI() {
            // Saved\Config\WindowsServer - folder structure needed inside server root directory
            var ini = ParseGameServerSettingsIntoINI();
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
        public static void SaveEngineINI() {
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
            WriteEngineINI();
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
        public static void SaveManagerSettings()
        {
            var fullPath = ManagerGlobalTracker.managerConfDir + "manager.json";
            File.WriteAllText(fullPath, JsonConvert.SerializeObject(ParseManagerSettings()));
        }
        public static void LoadGameServerSettings()
        {
            try {
                using (StreamReader sr = new StreamReader(ManagerGlobalTracker.managerConfDir+"game-settings.json")) {
                    var parsed = JsonConvert.DeserializeObject<GameServerSettingsJSON>(sr.ReadToEnd());
                    GameServerSettings.GameIniState = parsed.GameIniState;
                    GameServerSettings.GameIniSession = parsed.GameIniSession;
                    GameServerSettings.PendingSettingsApply = parsed.PendingSettingsApply;
                }
            }
            catch (Exception ex) {
                Logger.Log("Failed to parse game server settings - "+ex.Message,LogType.Debug);
            }
        }
        public static void SaveGameServerSettings()
        {
            // This should NOT be called until server stopped, actual ini file is updated and server is started
            try
            {
                using (StreamWriter sw = new StreamWriter(ManagerGlobalTracker.managerConfDir + "game-settings.json", false))
                {
                    sw.Write(JsonConvert.SerializeObject(new
                    {
                        GameIniState = GameServerSettings.GameIniState,
                        GameIniSession = GameServerSettings.GameIniSession,
                        PendingSettingsApply = GameServerSettings.PendingSettingsApply
                    }));
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Saving game server settings json - " + ex.Message, LogType.Debug);
            }
        }
        public static void SaveRCONSettings()
        {
            using (StreamWriter sw = new StreamWriter(ManagerGlobalTracker.managerConfDir + "rcon-settings.json", false))
            {
                sw.Write(JsonConvert.SerializeObject(new
                {
                    rconHost = RCONGlobalTracker.rconHost,
                    rconPort = RCONGlobalTracker.rconPort,
                    rconPassword = RCONGlobalTracker.rconPassword,
                    rconEnabled = RCONGlobalTracker.rconEnabled
                }));
            }
        }
        public static void SaveRCONTasks()
        {
            using (StreamWriter sw = new StreamWriter(ManagerGlobalTracker.managerConfDir + "rcon-tasks.json", false))
            {
                sw.Write(JsonConvert.SerializeObject(RCONGlobalTasks.rconTasks));
            }
        }
        public static void LoadRCONTasks()
        {
            using (StreamReader sr = new StreamReader(ManagerGlobalTracker.managerConfDir + "rcon-tasks.json"))
            {
                var items = JsonConvert.DeserializeObject<List<RCONTaskItemJSON>>(sr.ReadToEnd());
                foreach (var task in items) { 
                    items.Add(task);
                }
            }
        }
        public static void LoadRCONSettings()
        {
            using (StreamReader sr = new StreamReader(ManagerGlobalTracker.managerConfDir + "rcon-tasks.json"))
            {
                var items = JsonConvert.DeserializeObject<RCONSettingsJSON>(sr.ReadToEnd());
                RCONGlobalTracker.rconHost = items.rconHost;
                RCONGlobalTracker.rconPort = items.rconPort;
                RCONGlobalTracker.rconPassword = items.rconPassword;
                RCONGlobalTracker.rconEnabled = items.rconEnabled;
            }
        }

        #region Private Methods
        private static void WriteEngineINI()
        {
            // The server when ran seems to remove this file and this is used in the run arguments but we'll write it anyway
            var fullPath = ManagerGlobalTracker.serverPath + ManagerGlobalTracker.engineINI;
            using (StreamWriter sw = new StreamWriter(fullPath, false))
            {
                sw.WriteLine("[EpicOnlineServices]");
                sw.WriteLine("DedicatedServerClientId=xyza7891gk5PRo3J7G9puCJGFJjmEguW");
                sw.WriteLine("DedicatedServerClientSecret=pKWl6t5i9NJK8gTpVlAxzENZ65P8hYzodV8Dqe5Rlc8");
            }
        }
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
        private static List<string> ParseGameServerSettingsIntoINI() { 
            List<string> rawINI = new List<string>();
            rawINI.Add("[/script/theisle.tigamesession]"); // Needs added first
            rawINI.Add("ServerName=" + GameServerSettings.GameIniSession.ServerName);
            rawINI.Add("MaxPlayers=" + GameServerSettings.GameIniSession.MaxPlayers);
            rawINI.Add("bEnableHumans=" + GameServerSettings.GameIniSession.EnableHumans);
            rawINI.Add("MapName=" + GameServerSettings.GameIniSession.MapName);
            rawINI.Add("bQueueEnable=" + GameServerSettings.GameIniSession.EnableQueue);
            rawINI.Add("bQueuePort=" + GameServerSettings.GameIniSession.QueuePort);
            rawINI.Add("bServerPassword=" + GameServerSettings.GameIniSession.ServerPasswordProtected);
            rawINI.Add("ServerPassword=" + GameServerSettings.GameIniSession.ServerPassword);
            rawINI.Add("bRconEnable=" + GameServerSettings.GameIniSession.EnableRCON);
            rawINI.Add("RconPassword=" + GameServerSettings.GameIniSession.RCONPassword);
            rawINI.Add("RconPort=" + GameServerSettings.GameIniSession.RCONPort);
            rawINI.Add("bServerDynamicWeather=" + GameServerSettings.GameIniSession.DynamicWeather);
            rawINI.Add("MinimumWeatherVariationInterval=" + GameServerSettings.GameIniSession.MinimumWeatherVariationInterval);
            rawINI.Add("MaximumWeatherVariationInterval=" + GameServerSettings.GameIniSession.MaximumWeatherVariationInterval);
            rawINI.Add("ServerDayLengthMinutes=" + GameServerSettings.GameIniSession.ServerDayLengthMinutes);
            rawINI.Add("ServerNightLengthMinutes=" + GameServerSettings.GameIniSession.ServerNightLengthMinutes);
            rawINI.Add("bServerWhitelist=" + GameServerSettings.GameIniSession.ServerWhitelistMode);
            rawINI.Add("bEnableGlobalChat=" + GameServerSettings.GameIniSession.EnableGlobalChat);
            rawINI.Add("bSpawnAI=" + GameServerSettings.GameIniSession.SpawnAI);
            rawINI.Add("AISpawnInterval=" + GameServerSettings.GameIniSession.AISpawnInterval);
            rawINI.Add("AIDensity=" + GameServerSettings.GameIniSession.AIDensity);
            rawINI.Add("bEnableMigration=" + GameServerSettings.GameIniSession.EnableMigration);
            rawINI.Add("MaxMigrationTime=" + GameServerSettings.GameIniSession.MaxMigrationTime);
            rawINI.Add("SpeciaMigrationTime=" + GameServerSettings.GameIniSession.SpeciaMigrationTime);
            rawINI.Add("bEnableMassMigration=" + GameServerSettings.GameIniSession.EnableMassMigration);
            rawINI.Add("MassMigrationTime=" + GameServerSettings.GameIniSession.MassMigrationTime);
            rawINI.Add("MassMigrationDisableTime=" + GameServerSettings.GameIniSession.MassMigrationDisableTime);
            rawINI.Add("bEnablePatrolZones=" + GameServerSettings.GameIniSession.EnablePatrolZones);
            rawINI.Add("bEnableDiets=" + GameServerSettings.GameIniSession.EnableDiets);
            rawINI.Add("GrowthMultiplier=" + GameServerSettings.GameIniSession.GrowthMultiplier);
            rawINI.Add("bServerFallDamage=" + GameServerSettings.GameIniSession.FallDamage);
            rawINI.Add("bAllowRecordingReplays=" + GameServerSettings.GameIniSession.AllowRecordingReplays);
            rawINI.Add("bSpawnPlants=" + GameServerSettings.GameIniSession.SpawnPlants);
            rawINI.Add("PlantSpawnMultiplier=" + GameServerSettings.GameIniSession.PlantSpawnMultiplier);
            rawINI.Add("bEnableMutations=" + GameServerSettings.GameIniSession.EnableMutations);
            rawINI.Add("bUseRegionSpawning=" + GameServerSettings.GameIniSession.UseRegionSpawning);
            rawINI.Add("bUseRegionSpawnCooldown=" + GameServerSettings.GameIniSession.RegionSpawnCooldown);
            rawINI.Add("RegionSpawnCooldownTimeSeconds=" + GameServerSettings.GameIniSession.RegionSpawnCooldownTimeSeconds);
            rawINI.Add("Discord=" + GameServerSettings.GameIniSession.Discord);
            rawINI.Add("CorpseDecayMultiplier=" + GameServerSettings.GameIniSession.CorpseDecayMultiplier);
            // Logical order, now we do IniState
            rawINI.Add("[/script/theisle.tigamestatebase]"); // Needs to be added first
            if(GameServerSettings.GameIniState.AdminSteamIDs.Count == 0) rawINI.Add($"AdminSteamIDs=");
            foreach (var id in GameServerSettings.GameIniState.AdminSteamIDs)
            {
                rawINI.Add($"AdminSteamIDs={id}");
            }
            if (GameServerSettings.GameIniState.WhitelistIDs.Count == 0) rawINI.Add($"WhitelistIDs=");
            foreach (var id in GameServerSettings.GameIniState.WhitelistIDs)
            {
                rawINI.Add($"WhitelistIDs={id}");
            }
            if (GameServerSettings.GameIniState.VIPs.Count == 0) rawINI.Add($"VIPs=");
            foreach (var id in GameServerSettings.GameIniState.VIPs)
            {
                rawINI.Add($"VIPs={id}");
            }

            foreach (var id in GameServerSettings.GameIniState.AllowedClasses)
            {
                rawINI.Add($"AllowedClasses={id}");
            }
            foreach (var id in GameServerSettings.GameIniState.EnabledMutations)
            {
                rawINI.Add($"EnabledMutations=(MutationName=”{id.Name}”,EffectValue={id.EffectiveValue})");
            }
            foreach (var id in GameServerSettings.GameIniState.DisallowedAIClasses)
            {
                rawINI.Add($"DisallowedAIClasses={id}");
            }
            return rawINI;
        }
        #endregion
    }
}
