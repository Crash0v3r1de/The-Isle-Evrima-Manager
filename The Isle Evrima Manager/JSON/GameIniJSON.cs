using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.JSON
{
    public class GameIniJSON
    {
        public GameIniSession GameSession { get; set; }
        public GameIniStateBase GameBase { get; set; }
    }
    public class GameIniSession { 
        public string ServerName { get; set; }
        public int MaxPlayers { get; set; }
        public bool EnableHumans { get; set; } // bEnableHumans
        public string MapName { get; set; }
        public bool EnableQueue { get; set; } // bQueueEnable
        public int QueuePort { get; set; } // bQueuePort
        public bool ServerPasswordProtected { get; set; } // bServerPassword
        public string ServerPassword { get; set; } // ServerPassword
        public bool EnableRCON { get; set; } // bRconEnable
        public string RCONPassword { get; set; } // RconPassword
        public int RCONPort { get; set; } // RconPort
        public bool DynamicWeather { get; set; } // bServerDynamicWeather
        public int MinimumWeatherVariationInterval { get; set; }
        public int MaximumWeatherVariationInterval { get; set; }
        public int ServerDayLengthMinutes { get; set; }
        public int ServerNightLengthMinutes { get; set; }
        public bool ServerWhitelistMode { get; set; } // bServerWhitelist
        public bool EnableGlobalChat { get; set; } // bEnableGlobalChat
        public bool SpawnAI { get; set; } // bSpawnAI
        public int AISpawnInterval { get; set; }
        public int AIDensity { get; set; }
        public bool EnableMigration { get; set; } // bEnableMigration
        public int MaxMigrationTime { get; set; }
        public int SpeciaMigrationTime { get; set; }
        public bool EnableMassMigration { get; set; } // bEnableMassMigration
        public int MassMigrationTime { get; set; }
        public int MassMigrationDisableTime { get; set; }
        public bool EnablePatrolZones { get; set; } // bEnablePatrolZones
        public bool EnableDiets { get; set; } // bEnableDiets
        public int GrowthMultiplier { get; set; }
        public bool FallDamage { get; set; } // bServerFallDamage
        public bool AllowRecordingReplays { get; set; } // bAllowRecordingReplays
        public bool SpawnPlants { get; set; } // bSpawnPlants
        public int PlantSpawnMultiplier { get; set; }
        public bool EnableMutations { get; set; } // bEnableMutations
        public bool UseRegionSpawning { get; set; } // bUseRegionSpawning
        public bool RegionSpawnCooldown { get; set; } // bUseRegionSpawnCooldown
        public int RegionSpawnCooldownTimeSeconds { get; set; }
        public string Discord { get; set; }
        public int CorpseDecayMultiplier { get; set; }
    }
    public class  GameIniStateBase
    {
        public string AdminSteamIDs { get; set; }
        public string WhitelistIDs { get; set; }
        public string VIPs { get; set; }
        public List<DinoClasses> AllowedClasses { get; set; } // null/empty to enable all
        public List<Mutations> EnabledMutations { get; set; } // null/empty to enable all
        public List<AIClasses> DisallowedAIClasses { get; set; } // null/empty to enable all
    }
    public class DinoClasses
    {
        public string ClassName { get; set; }
    }
    public class Mutations { 
        public string Name { get; set; }
        public decimal EffectiveValue { get; set; }
    }
    public class AIClasses
    {
        public string AIName { get; set; }
    }
}
