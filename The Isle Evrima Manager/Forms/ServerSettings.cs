using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Isle_Evrima_Manager.Forms
{
    public partial class frmServerSettings : Form
    {
        public string ServerName { get; set; } // Name of the server - ASCII only to my knowledge
        public int MaxPlayers { get; set; } // max players allowed into server
        public bool EnableHumans { get; set; } // Allows humans, doesn't even work to my knowledge as of 2/24/2025
        public string MapName { get; set; } // Map name to load
        public bool EnableQueue { get; set; } // allow a queue when server is full
        public int QueuePort { get; set; } // port for join queue when full
        public bool ServerPasswordProtected { get; set; } // sets server join require valid password
        public string ServerPassword { get; set; } // server password to join with
        public bool EnableRCON { get; set; } // Enable the RCON protocol
        public string RCONPassword { get; set; } // password to use with RCON client
        public int RCONPort { get; set; } // port for RCON to listen for connections
        public bool DynamicWeather { get; set; } // Allows weather to change from server side (admin panel can also control it)
        public int MinimumWeatherVariationInterval { get; set; } // minimum time between weather changes in seconds
        public int MaximumWeatherVariationInterval { get; set; } // maximum time between weather changes in seconds
        public int ServerDayLengthMinutes { get; set; } // how long days should be in mins
        public int ServerNightLengthMinutes { get; set; } // how long nights should be in mins
        public bool ServerWhitelistMode { get; set; } // Only allow users on whitelist into server??
        public bool EnableGlobalChat { get; set; } // why not let people talk smack
        public bool SpawnAI { get; set; } // spawn AI animals (for food)
        public int AISpawnInterval { get; set; } // in seconds for animal spawns
        public int AIDensity { get; set; } // larger than 1 is more spawns
        public bool EnableMigration { get; set; } // Disable/Enable Migrations, include Patrols and Mass
        public int MaxMigrationTime { get; set; } // Assuming this is still meant to be here (literally copy pasta from offical Steam Doc lol)
        public int SpeciaMigrationTime { get; set; } // Max time a species MZ stays active in seconds
        public bool EnableMassMigration { get; set; } // let mass migrations happen
        public int MassMigrationTime { get; set; } // How often new mass migration is set in seconds
        public int MassMigrationDisableTime { get; set; } // How long a mass migration last once set in seconds
        public bool EnablePatrolZones { get; set; } // self explanitory
        public bool EnableDiets { get; set; } // protein, lipid, water, carbs
        public int GrowthMultiplier { get; set; } // larger number is faster growth
        public bool FallDamage { get; set; } // self explanitory
        public bool AllowRecordingReplays { get; set; } // don't see why you'd disable this
        public bool SpawnPlants { get; set; } // dont hate the herbivores
        public int PlantSpawnMultiplier { get; set; } // larger number is more plants
        public bool EnableMutations { get; set; } // allow mutations - mutations specific stuff in seperate window/option frmMutationSettings
        public bool UseRegionSpawning { get; set; } // allow region spawn options in loadin/respawn menu
        public bool RegionSpawnCooldown { get; set; } // may or may not work - enable/disable
        public int RegionSpawnCooldownTimeSeconds { get; set; } // may or may not work - in seconds
        public string Discord { get; set; } // Discord invite ID - NOT the full URL, add check and parser if full URL
        public int CorpseDecayMultiplier { get; set; } // greater than 1 is faster decomp, less than 1 is slower decomp


        public frmServerSettings()
        {
            InitializeComponent();
        }

        private void exitAndDiscardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void chkServerPassword_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkWhitelist_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWhitelist.Checked) btnWhitelistFrm.Visible = true;
            else btnWhitelistFrm.Visible = false;
        }

        private void chkMutations_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMutations.Checked) btnMutations.Visible = true;
            else btnMutations.Visible = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Opens the steam article - eventually I'll add the PDF from the Discord and open the PDF direct
            Process.Start("explorer.exe", "https://steamcommunity.com/sharedfiles/filedetails/?id=2952501611");
        }

        private void btnVIPs_Click(object sender, EventArgs e)
        {
            ServerVIPS serverVIPS = new ServerVIPS();
            serverVIPS.ShowDialog(); // wait until closed
            if (serverVIPS.VIPs.Count > 0)
            {
                // Parse into the settings JSON then handle saving to INI if not running server
            }
        }

        private void btnAdmins_Click(object sender, EventArgs e)
        {
            ServerAdmins serverAdmins = new ServerAdmins();
            serverAdmins.ShowDialog(); // wait until closed
            if (serverAdmins.AdminSteamIDs.Count > 0)
            {
                // Parse into the settings JSON then handle saving to INI if not running server
            }
        }

        private void btnWhitelistFrm_Click(object sender, EventArgs e)
        {
            ServerWhitelist serverWhitelist = new ServerWhitelist();
            serverWhitelist.ShowDialog(); // wait until closed
            if (serverWhitelist.WhitelistIDs.Count > 0)
            {
                // Parse into the settings JSON then handle saving to INI if not running server
            }
        }
    }
}
