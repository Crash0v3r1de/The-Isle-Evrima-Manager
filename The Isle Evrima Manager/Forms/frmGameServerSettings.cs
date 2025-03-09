using Octokit;
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
using The_Isle_Evrima_Manager.IO;
using The_Isle_Evrima_Manager.JSON;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

namespace The_Isle_Evrima_Manager.Forms
{
    public partial class frmGameServerSettings : Form
    {
        bool allValid = false;
        public frmGameServerSettings()
        {
            InitializeComponent();
        }
        private void frmServerSettings_Load(object sender, EventArgs e)
        {
            if (GameServerSettings.GameIniSession.ServerName != null && !string.IsNullOrWhiteSpace(GameServerSettings.GameIniSession.ServerName)) {
                // settings have been made before, parse them into the UI
                txtAIDensity.Value = GameServerSettings.GameIniSession.AIDensity;
                txtAIInt.Value = GameServerSettings.GameIniSession.AISpawnInterval;
                chkRecordings.Checked = GameServerSettings.GameIniSession.AllowRecordingReplays;
                numCorpseDecay.Value = GameServerSettings.GameIniSession.CorpseDecayMultiplier;
                txtDiscordInvite.Text = GameServerSettings.GameIniSession.Discord;
                chkDynamicWeather.Checked = GameServerSettings.GameIniSession.DynamicWeather;
                chkDiets.Checked = GameServerSettings.GameIniSession.EnableDiets;
                chkGlobalChat.Checked = GameServerSettings.GameIniSession.EnableGlobalChat;
                chkEnableHumans.Checked = GameServerSettings.GameIniSession.EnableHumans;
                chkMassMigrations.Checked = GameServerSettings.GameIniSession.EnableMassMigration;
                chkMigrations.Checked = GameServerSettings.GameIniSession.EnableMigration;
                chkMutations.Checked = GameServerSettings.GameIniSession.EnableMutations;
                chkPatrolZones.Checked = GameServerSettings.GameIniSession.EnablePatrolZones;
                chkQueue.Checked = GameServerSettings.GameIniSession.EnableQueue;
                chkFallDamage.Checked = GameServerSettings.GameIniSession.FallDamage;
                txtGrowthRate.Value = GameServerSettings.GameIniSession.GrowthMultiplier;
                drpMapName.SelectedItem = GameServerSettings.GameIniSession.MapName; // might need to make this better code wise later
                txtMassMigrationCooldown.Value = GameServerSettings.GameIniSession.MassMigrationDisableTime;
                txtMassMigrationTime.Value = GameServerSettings.GameIniSession.MassMigrationTime;
                txtMaxWeatherVariation.Value = GameServerSettings.GameIniSession.MaximumWeatherVariationInterval;
                txtMassMigrationCooldown.Value = GameServerSettings.GameIniSession.MaxMigrationTime;
                txtMaxPlayers.Value = GameServerSettings.GameIniSession.MaxPlayers;
                txtMassMigrationCooldown.Value = GameServerSettings.GameIniSession.MinimumWeatherVariationInterval;
                txtPlantDensity.Value = GameServerSettings.GameIniSession.PlantSpawnMultiplier;
                txtQueuePort.Value = GameServerSettings.GameIniSession.QueuePort;
                chkRCON.Checked = GameServerSettings.GameIniSession.EnableRCON;
                txtRCONPass.Text = GameServerSettings.GameIniSession.RCONPassword;
                txtRCONPort.Value = GameServerSettings.GameIniSession.RCONPort;
                chkRegionSpawnCooldown.Checked = GameServerSettings.GameIniSession.RegionSpawnCooldown;
                txtRegionCooldownSecs.Value = GameServerSettings.GameIniSession.RegionSpawnCooldownTimeSeconds;
                txtServerName.Text = GameServerSettings.GameIniSession.ServerName;
                txtNightLength.Value = GameServerSettings.GameIniSession.ServerNightLengthMinutes;
                txtSrvPassword.Text = GameServerSettings.GameIniSession.ServerPassword;
                chkServerPassword.Checked = GameServerSettings.GameIniSession.ServerPasswordProtected;
                chkWhitelist.Checked = GameServerSettings.GameIniSession.ServerWhitelistMode;
                chkAI.Checked = GameServerSettings.GameIniSession.SpawnAI;
                chkSpawnPlants.Checked = GameServerSettings.GameIniSession.SpawnPlants;
                txtSpeciesMigrationTime.Value = GameServerSettings.GameIniSession.SpeciaMigrationTime;
                chkRegionSpawn.Checked = GameServerSettings.GameIniSession.UseRegionSpawning;
                numServerPort.Value = GameServerStatusTracker.ServerPort;
                LoadDinos();
                LoadDisallowedAI();
            }
        }

        private void LoadDinos() {
            if (GameServerSettings.GameIniState.AllowedClasses.Count != 0) {
                UncheckDinos();
                foreach (var d in GameServerSettings.GameIniState.AllowedClasses)
                {
                    // could one line return bool if string is the same value but this is fine for now
                    if (d.ClassName == "Dryosaurus") chkDryosaurus.Checked = true;
                    if (d.ClassName == "Hypsilophodon") chkHypsilophodon.Checked = true;
                    if (d.ClassName == "Pachycephalosaurus") chkPachycephalosaurus.Checked = true;
                    if (d.ClassName == "Stegosaurus") chkStegosaurus.Checked = true;
                    if (d.ClassName == "Tenontosaurus") chkTenontosaurus.Checked = true;
                    if (d.ClassName == "Carnotaurus") chkCarnotaurus.Checked = true;
                    if (d.ClassName == "Ceratosaurus") chkCeratosaurus.Checked = true;
                    if (d.ClassName == "Deinosuchus") chkDeinosuchus.Checked = true;
                    if (d.ClassName == "Diabloceratops") chkDiabloceratops.Checked = true;
                    if (d.ClassName == "Pteranodon") chkPteranodon.Checked = true;
                    if (d.ClassName == "Troodon") chkTroodon.Checked = true;
                    if (d.ClassName == "Beipiaosaurus") chkBeipiaosaurus.Checked = true;
                    if (d.ClassName == "Gallimimus") chkGallimimus.Checked = true;
                    if (d.ClassName == "Dilophosaurus") chkDilophosaurus.Checked = true;
                    if (d.ClassName == "Herrerasaurus") chkHerrerasaurus.Checked = true;
                    if (d.ClassName == "Maiasaura") chkMaiasaura.Checked = true;
                }
            }            
        }
        private void UncheckDinos() {
            chkDryosaurus.Checked = false;
            chkHypsilophodon.Checked = false;
            chkPachycephalosaurus.Checked = false;
            chkStegosaurus.Checked = false;
            chkTenontosaurus.Checked = false;
            chkCarnotaurus.Checked = false;
            chkCeratosaurus.Checked = false;
            chkDeinosuchus.Checked = false;
            chkDiabloceratops.Checked = false;
            chkPteranodon.Checked = false;
            chkTroodon.Checked = false;
            chkBeipiaosaurus.Checked = false;
            chkGallimimus.Checked = false;
            chkDilophosaurus.Checked = false;
            chkHerrerasaurus.Checked = false;
            chkMaiasaura.Checked = false;
        }
        private void LoadDisallowedAI() {
            if (GameServerSettings.GameIniState.DisallowedAIClasses.Count != 0) {
                foreach (var a in GameServerSettings.GameIniState.DisallowedAIClasses)
                {
                    if (a.AIName == "Compsognathus") chkCompsoAI.Checked = false;
                    if (a.AIName == "Pterodactylus") chkPteranodon.Checked = false;
                    if (a.AIName == "Boar") chkBoarAI.Checked = false;
                    if (a.AIName == "Deer") chkDeerAI.Checked = false;
                    if (a.AIName == "Goat") chkGoatAI.Checked = false;
                    if (a.AIName == "Seaturtle") chkSeaturtleAI.Checked = false;

                }
            }            
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

        private static int GetUtcOffsetInSeconds()
        {
            // Get the current local time
            DateTime localTime = DateTime.Now;

            // Get the current UTC time
            DateTime utcTime = DateTime.UtcNow;

            // Calculate the difference between local time and UTC time
            TimeSpan offset = localTime - utcTime;

            // Return the total offset in seconds
            return (int)offset.TotalSeconds;
        }

        private void saveAndCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParseCoreSetting();
            ParseDynoClasses();
            ParseAIClasses();
            var adminCount = GameServerSettings.GameIniState.AdminSteamIDs.Count;
            var whitelistCount = GameServerSettings.GameIniState.WhitelistIDs.Count;
            var vipCount = GameServerSettings.GameIniState.VIPs.Count;
            var disallowAICount = GameServerSettings.GameIniState.DisallowedAIClasses.Count;
            bool dontClose = true;

            if (adminCount <= 0)
            {
                // admin good
                var result = MessageBox.Show("There are NO server admins set, is this okay?\n*no to add*", "Missing Server Admins", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    new ServerAdmins().ShowDialog(this);
                }
            }
            if (whitelistCount <= 0 && GameServerSettings.GameIniSession.ServerWhitelistMode)
            {
                var result = MessageBox.Show("Whitelist enabled but no users, add users or cancel to disable", "Whitelist Enabled - no IDs", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    new ServerWhitelist().ShowDialog(this);
                }
                else
                {
                    GameServerSettings.GameIniSession.ServerWhitelistMode = false;
                }
            }
            if (vipCount <= 0)
            {
                var result = MessageBox.Show("There are no VIPs entered, is this okay?\n*no to add*", "No VIPs, Verify it's normal", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    new ServerVIPS().ShowDialog(this);
                }
            }
            if (disallowAICount <= 0)
            {
                var result = MessageBox.Show("All AI is allowed, is this okay?", "All AI Allowed", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Leave this window open and exit method
                    dontClose = false;
                }
            }else dontClose = false;
            if (!dontClose) allValid = true;
            if (allValid)
            {
                CoreFiles.SaveEngineINI();
                CoreFiles.SaveGameINI();
                this.Close();
                this.Dispose();
            }
        }
        private void lblRegionCooldownNotice_LinkClicked(object sender, EventArgs e)
        {
            // Load wiki page about this when clicked
            Process.Start("explorer.exe", "GITHUB");
        }
        private void lblCooldownNoticeExpanded_LinkClicked(object sender, EventArgs e)
        {
            // Load wiki page about this when clicked
            Process.Start("explorer.exe", "GITHUB");
        }
        private void ParseCoreSetting()
        {
            GameServerSettings.GameIniSession.AIDensity = (int)txtAIDensity.Value;
            GameServerSettings.GameIniSession.AISpawnInterval = (int)txtAIInt.Value;
            GameServerSettings.GameIniSession.AllowRecordingReplays = chkRecordings.Checked;
            GameServerSettings.GameIniSession.CorpseDecayMultiplier = (int)numCorpseDecay.Value;
            GameServerSettings.GameIniSession.Discord = txtDiscordInvite.Text;
            GameServerSettings.GameIniSession.DynamicWeather = chkDynamicWeather.Checked;
            GameServerSettings.GameIniSession.EnableDiets = chkDiets.Checked;
            GameServerSettings.GameIniSession.EnableGlobalChat = chkGlobalChat.Checked;
            GameServerSettings.GameIniSession.EnableHumans = chkEnableHumans.Checked;
            GameServerSettings.GameIniSession.EnableMassMigration = chkMassMigrations.Checked;
            GameServerSettings.GameIniSession.EnableMigration = chkMigrations.Checked;
            GameServerSettings.GameIniSession.EnableMutations = chkMutations.Checked;
            GameServerSettings.GameIniSession.EnablePatrolZones = chkPatrolZones.Checked;
            GameServerSettings.GameIniSession.EnableQueue = chkQueue.Checked;
            GameServerSettings.GameIniSession.FallDamage = chkFallDamage.Checked;
            GameServerSettings.GameIniSession.GrowthMultiplier = (int)txtGrowthRate.Value;
            GameServerSettings.GameIniSession.MapName = drpMapName.SelectedItem?.ToString();
            GameServerSettings.GameIniSession.MassMigrationDisableTime = (int)txtMassMigrationCooldown.Value;
            GameServerSettings.GameIniSession.MassMigrationTime = (int)txtMassMigrationTime.Value;
            GameServerSettings.GameIniSession.MaximumWeatherVariationInterval = (int)txtMaxWeatherVariation.Value;
            GameServerSettings.GameIniSession.MaxMigrationTime = (int)txtMassMigrationCooldown.Value;
            GameServerSettings.GameIniSession.MaxPlayers = (int)txtMaxPlayers.Value;
            GameServerSettings.GameIniSession.MinimumWeatherVariationInterval = (int)txtMassMigrationCooldown.Value;
            GameServerSettings.GameIniSession.PlantSpawnMultiplier = (int)txtPlantDensity.Value;
            GameServerSettings.GameIniSession.QueuePort = (int)txtQueuePort.Value;
            GameServerSettings.GameIniSession.EnableRCON = chkRCON.Checked;
            GameServerSettings.GameIniSession.RCONPassword = txtRCONPass.Text;
            GameServerSettings.GameIniSession.RCONPort = (int)txtRCONPort.Value;
            GameServerSettings.GameIniSession.ServerDayLengthMinutes = (int)txtRegionCooldownSecs.Value;
            GameServerSettings.GameIniSession.ServerName = txtServerName.Text;
            GameServerSettings.GameIniSession.ServerNightLengthMinutes = (int)txtNightLength.Value;
            GameServerSettings.GameIniSession.ServerPassword = txtSrvPassword.Text;
            GameServerSettings.GameIniSession.ServerPasswordProtected = chkServerPassword.Checked;
            GameServerSettings.GameIniSession.ServerWhitelistMode = chkWhitelist.Checked;
            GameServerSettings.GameIniSession.SpawnAI = chkAI.Checked;
            GameServerSettings.GameIniSession.SpawnPlants = chkSpawnPlants.Checked;
            GameServerSettings.GameIniSession.SpeciaMigrationTime = (int)txtSpeciesMigrationTime.Value;
            if (chkRegionSpawn.Checked && !chkRegionSpawnCooldown.Checked)
            {
                GameServerSettings.GameIniSession.UseRegionSpawning = chkRegionSpawn.Checked;
                GameServerSettings.GameIniSession.RegionSpawnCooldown = chkRegionSpawnCooldown.Checked;
                GameServerSettings.GameIniSession.RegionSpawnCooldownTimeSeconds = GetUtcOffsetInSeconds();
                // Server will still apply cooldown timer if this is not the amount of seconds your server is from UTC time
            }
            else {
                GameServerSettings.GameIniSession.UseRegionSpawning = chkRegionSpawn.Checked;
                GameServerSettings.GameIniSession.RegionSpawnCooldown = chkRegionSpawnCooldown.Checked;
                GameServerSettings.GameIniSession.RegionSpawnCooldownTimeSeconds = (int)txtRegionCooldownSecs.Value;
                GameServerStatusTracker.ServerPort = (int)numServerPort.Value;
            }            
        }
        private void ParseDynoClasses()
        {
            GameServerSettings.GameIniState.AllowedClasses.Clear();
            var dino = new DinoClass();
            if (chkDryosaurus.Checked)
            {
                dino.ClassName = "Dryosaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
            if (chkHypsilophodon.Checked)
            {
                dino.ClassName = "Hypsilophodon";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
            if (chkPachycephalosaurus.Checked)
            {
                dino.ClassName = "Pachycephalosaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
            if (chkStegosaurus.Checked)
            {
                dino.ClassName = "Stegosaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
            if (chkTenontosaurus.Checked)
            {
                dino.ClassName = "Tenontosaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
            if (chkCarnotaurus.Checked)
            {
                dino.ClassName = "Carnotaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
            if (chkCeratosaurus.Checked)
            {
                dino.ClassName = "Ceratosaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
            if (chkDeinosuchus.Checked)
            {
                dino.ClassName = "Deinosuchus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
            if (chkDiabloceratops.Checked)
            {
                dino.ClassName = "Diabloceratops";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
            if (chkPteranodon.Checked)
            {
                dino.ClassName = "Pteranodon";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
            if (chkTroodon.Checked)
            {
                dino.ClassName = "Troodon";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
            if (chkBeipiaosaurus.Checked)
            {
                dino.ClassName = "Beipiaosaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
            if (chkGallimimus.Checked)
            {
                dino.ClassName = "Gallimimus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
            if (chkDilophosaurus.Checked)
            {
                dino.ClassName = "Dilophosaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
            if (chkHerrerasaurus.Checked)
            {
                dino.ClassName = "Herrerasaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
            if (chkMaiasaura.Checked)
            {
                dino.ClassName = "Maiasaura";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
                dino = new DinoClass();
            }
        }
        private void ParseAIClasses()
        {
            GameServerSettings.GameIniState.DisallowedAIClasses.Clear();
            var ai = new AIClasses();
            if (!chkCompsoAI.Checked)
            {
                ai.AIName = "Compsognathus";
                GameServerSettings.GameIniState.DisallowedAIClasses.Add(ai);
            }
            if (!chkPteranodon.Checked)
            {
                ai.AIName = "Pterodactylus";
                GameServerSettings.GameIniState.DisallowedAIClasses.Add(ai);
            }
            if (!chkBoarAI.Checked)
            {
                ai.AIName = "Boar";
                GameServerSettings.GameIniState.DisallowedAIClasses.Add(ai);
            }
            if (!chkDeerAI.Checked)
            {
                ai.AIName = "Deer";
                GameServerSettings.GameIniState.DisallowedAIClasses.Add(ai);
            }
            if (!chkGoatAI.Checked)
            {
                ai.AIName = "Goat";
                GameServerSettings.GameIniState.DisallowedAIClasses.Add(ai);
            }
            if (!chkSeaturtleAI.Checked)
            {
                ai.AIName = "Seaturtle";
                GameServerSettings.GameIniState.DisallowedAIClasses.Add(ai);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
