using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.JSON;

namespace The_Isle_Evrima_Manager.Tools
{
    public class SettingsHandler : IDisposable
    {
        private List<string> lines = new List<string>(); // The list should keep the order of the lines added
        private bool disposed = false;
        public void ProcessGameSettings(GameIniJSON settings) { 
            lines.Clear(); // Clear the list if not empty somehow
            ParseGameSessionIni(settings);
            ParseGameStateBase(settings);
        }


        #region Private Methods
        private void ParseGameSessionIni(GameIniJSON settings) {
            
            lines.Add("[/script/theisle.tigamesession]"); // Needs added first
            lines.Add("ServerName=" + settings.GameSession.ServerName);
            lines.Add("MaxPlayers=" + settings.GameSession.MaxPlayers);
            lines.Add("bEnableHumans=" + settings.GameSession.EnableHumans);
            lines.Add("MapName=" + settings.GameSession.MapName);
            lines.Add("bQueueEnable=" + settings.GameSession.EnableQueue);
            lines.Add("bQueuePort=" + settings.GameSession.QueuePort);
            lines.Add("bServerPassword=" + settings.GameSession.ServerPasswordProtected);
            lines.Add("ServerPassword=" + settings.GameSession.ServerPassword);
            lines.Add("bRconEnable=" + settings.GameSession.EnableRCON);
            lines.Add("RconPassword=" + settings.GameSession.RCONPassword);
            lines.Add("RconPort=" + settings.GameSession.RCONPort);
            lines.Add("bServerDynamicWeather=" + settings.GameSession.DynamicWeather);
            lines.Add("MinimumWeatherVariationInterval=" + settings.GameSession.MinimumWeatherVariationInterval);
            lines.Add("MaximumWeatherVariationInterval=" + settings.GameSession.MaximumWeatherVariationInterval);
            lines.Add("ServerDayLengthMinutes=" + settings.GameSession.ServerDayLengthMinutes);
            lines.Add("ServerNightLengthMinutes=" + settings.GameSession.ServerNightLengthMinutes);
            lines.Add("bServerWhitelist=" + settings.GameSession.ServerWhitelistMode);
            lines.Add("bEnableGlobalChat=" + settings.GameSession.EnableGlobalChat);
            lines.Add("bSpawnAI=" + settings.GameSession.SpawnAI);
            lines.Add("AISpawnInterval=" + settings.GameSession.AISpawnInterval);
            lines.Add("AIDensity=" + settings.GameSession.AIDensity);
            lines.Add("bEnableMigration=" + settings.GameSession.EnableMigration);
            lines.Add("MaxMigrationTime=" + settings.GameSession.MaxMigrationTime);
            lines.Add("SpeciaMigrationTime=" + settings.GameSession.SpeciaMigrationTime);
            lines.Add("bEnableMassMigration=" + settings.GameSession.EnableMassMigration);
            lines.Add("MassMigrationTime=" + settings.GameSession.MassMigrationTime);
            lines.Add("MassMigrationDisableTime=" + settings.GameSession.MassMigrationDisableTime);
            lines.Add("bEnablePatrolZones=" + settings.GameSession.EnablePatrolZones);
            lines.Add("bEnableDiets=" + settings.GameSession.EnableDiets);
            lines.Add("GrowthMultiplier=" + settings.GameSession.GrowthMultiplier);
            lines.Add("bServerFallDamage=" + settings.GameSession.FallDamage);
            lines.Add("bAllowRecordingReplays=" + settings.GameSession.AllowRecordingReplays);
            lines.Add("bSpawnPlants=" + settings.GameSession.SpawnPlants);
            lines.Add("PlantSpawnMultiplier=" + settings.GameSession.PlantSpawnMultiplier);
            lines.Add("bEnableMutations=" + settings.GameSession.EnableMutations);
            lines.Add("bUseRegionSpawning=" + settings.GameSession.UseRegionSpawning);
            lines.Add("bUseRegionSpawnCooldown=" + settings.GameSession.RegionSpawnCooldown);
            lines.Add("RegionSpawnCooldownTimeSeconds=" + settings.GameSession.RegionSpawnCooldownTimeSeconds);
            lines.Add("Discord=" + settings.GameSession.Discord);
            lines.Add("CorpseDecayMultiplier=" + settings.GameSession.CorpseDecayMultiplier);
        }
        private void ParseGameStateBase(GameIniJSON settings) {
            lines.Add("[/script/theisle.tigamestatebase]"); // Needs to be added first
            foreach (var id in settings.GameBase.AdminSteamIDs)
            {
                lines.Add($"AdminSteamIDs={id}");
            }
            foreach (var id in settings.GameBase.WhitelistIDs)
            {
                lines.Add($"WhitelistIDs={id}");
            }
            foreach (var id in settings.GameBase.VIPs)
            {
                lines.Add($"VIPs={id}");
            }
            foreach (var id in settings.GameBase.AllowedClasses)
            {
                lines.Add($"AllowedClasses={id}");
            }
            foreach (var id in settings.GameBase.EnabledMutations)
            {
                lines.Add($"EnabledMutations=(MutationName=”{id.Name}”,EffectValue={id.EffectiveValue})");
            }
            foreach (var id in settings.GameBase.DisallowedAIClasses)
            {
                lines.Add($"DisallowedAIClasses={id}");
            }
        }
        #endregion

        #region Dispose methods
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here
                }

                // Dispose unmanaged resources here

                disposed = true;
            }
        }

        // Destructor to ensure resources are released
        ~SettingsHandler()
        {
            Dispose(false);
        }
        #endregion
    }
}
