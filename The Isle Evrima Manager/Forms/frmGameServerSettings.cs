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
        private void frmServerSettings_Load(object sender, EventArgs e) { 
        
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

            if (adminCount <= 0) {
                // admin good
                var result = MessageBox.Show("There are NO server admins set, is this okay?\n*no to add*", "Missing Server Admins", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    new ServerAdmins().ShowDialog(this);
                }                
            }
            if (whitelistCount <= 0 && GameServerSettings.GameIniSession.ServerWhitelistMode) {
                var result = MessageBox.Show("Whitelist enabled but no users, add users or cancel to disable", "Whitelist Enabled - no IDs", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    new ServerWhitelist().ShowDialog(this);
                }
                else { 
                    GameServerSettings.GameIniSession.ServerWhitelistMode = false;
                }
            }
            if (vipCount <= 0) { 
                var result = MessageBox.Show("There are no VIPs entered, is this okay?\n*no to add*", "No VIPs, Verify it's normal", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) { 
                    new ServerVIPS().ShowDialog(this);
                }
            }
            if (disallowAICount <= 0) {
                var result = MessageBox.Show("All AI is allowed, is this okay?", "All AI Allowed", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) {
                    // Leave this window open and exit method
                    dontClose = false;
                }
            }
            if (!dontClose) allValid = true;
            if (allValid) {
                CoreFiles.SaveEngineINI();
                CoreFiles.SaveGameINI();
                this.Close();
                this.Dispose();
            }
        }
        private void lblRegionCooldownNotice_LinkClicked(object sender, EventArgs e) {
            // Load wiki page about this when clicked
            Process.Start("explorer.exe","GITHUB");
        }
        private void lblCooldownNoticeExpanded_LinkClicked(object sender, EventArgs e)
        {
            // Load wiki page about this when clicked
            Process.Start("explorer.exe", "GITHUB");
        }
        private void ParseCoreSetting() {
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
            GameServerSettings.GameIniSession.EnableRCON = chkRCON.Checked;
            GameServerSettings.GameIniSession.FallDamage = chkFallDamage.Checked;
            GameServerSettings.GameIniSession.GrowthMultiplier = (int)txtGrowthRate.Value;
            GameServerSettings.GameIniSession.MapName = txtMapName.Text;
            GameServerSettings.GameIniSession.MassMigrationDisableTime = (int)txtMassMigrationCooldown.Value;
            GameServerSettings.GameIniSession.MassMigrationTime = (int)txtMassMigrationTime.Value;
            GameServerSettings.GameIniSession.MaximumWeatherVariationInterval = (int)txtMaxWeatherVariation.Value;
            GameServerSettings.GameIniSession.MaxMigrationTime = (int)txtMassMigrationCooldown.Value;
            GameServerSettings.GameIniSession.MaxPlayers = (int)txtMaxPlayers.Value;
            GameServerSettings.GameIniSession.MinimumWeatherVariationInterval = (int)txtMassMigrationCooldown.Value;
            GameServerSettings.GameIniSession.PlantSpawnMultiplier = (int)txtPlantDensity.Value;
            GameServerSettings.GameIniSession.QueuePort = (int)txtQueuePort.Value;
            GameServerSettings.GameIniSession.RCONPassword = txtRCONPass.Text;
            GameServerSettings.GameIniSession.RCONPort = (int)txtRCONPort.Value;
            GameServerSettings.GameIniSession.RegionSpawnCooldown = chkRegionSpawnCooldown.Checked;
            GameServerSettings.GameIniSession.RegionSpawnCooldownTimeSeconds = (int)txtRegionCooldownSecs.Value;
            GameServerSettings.GameIniSession.ServerDayLengthMinutes = (int)txtRegionCooldownSecs.Value;
            GameServerSettings.GameIniSession.ServerName = txtServerName.Text;
            GameServerSettings.GameIniSession.ServerNightLengthMinutes = (int)txtNightLength.Value;
            GameServerSettings.GameIniSession.ServerPassword = txtSrvPassword.Text;
            GameServerSettings.GameIniSession.ServerPasswordProtected = chkServerPassword.Checked;
            GameServerSettings.GameIniSession.ServerWhitelistMode = chkWhitelist.Checked;
            GameServerSettings.GameIniSession.SpawnAI = chkAI.Checked;
            GameServerSettings.GameIniSession.SpawnPlants = chkSpawnPlants.Checked;
            GameServerSettings.GameIniSession.SpeciaMigrationTime = (int)txtSpeciesMigrationTime.Value;
            GameServerSettings.GameIniSession.UseRegionSpawning = chkRegionSpawn.Checked;
        }
        private void ParseDynoClasses() {
            var dino = new DinoClass();
            if (chkDryosaurus.Checked) { 
                dino.ClassName = "Dryosaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
            if (chkHypsilophodon.Checked)
            {
                dino.ClassName = "Hypsilophodon";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
            if (chkPachycephalosaurus.Checked)
            {
                dino.ClassName = "Pachycephalosaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
            if (chkStegosaurus.Checked)
            {
                dino.ClassName = "Stegosaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
            if (chkTenontosaurus.Checked)
            {
                dino.ClassName = "Tenontosaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
            if (chkCarnotaurus.Checked)
            {
                dino.ClassName = "Carnotaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
            if (chkCeratosaurus.Checked)
            {
                dino.ClassName = "Ceratosaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
            if (chkDeinosuchus.Checked)
            {
                dino.ClassName = "Deinosuchus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
            if (chkDiabloceratops.Checked)
            {
                dino.ClassName = "Diabloceratops";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
            if (chkPteranodon.Checked)
            {
                dino.ClassName = "Pteranodon";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
            if (chkTroodon.Checked)
            {
                dino.ClassName = "Troodon";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
            if (chkBeipiaosaurus.Checked)
            {
                dino.ClassName = "Beipiaosaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
            if (chkGallimimus.Checked)
            {
                dino.ClassName = "Gallimimus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
            if (chkDilophosaurus.Checked)
            {
                dino.ClassName = "Dilophosaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
            if (chkHerrerasaurus.Checked)
            {
                dino.ClassName = "Herrerasaurus";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
            if (chkMaiasaura.Checked)
            {
                dino.ClassName = "Maiasaura";
                GameServerSettings.GameIniState.AllowedClasses.Add(dino);
            }
        }
        private void ParseAIClasses() { 
            var ai = new AIClasses();
            if (!chkCompsoAI.Checked) {
                ai.AIName = "Compsognathus";
                GameServerSettings.GameIniState.DisallowedAIClasses.Add(ai);
            }
            if (!chkPteranodon.Checked) {
                ai.AIName = "Pterodactylus";
                GameServerSettings.GameIniState.DisallowedAIClasses.Add(ai);
            }
            if (!chkBoarAI.Checked) {
                ai.AIName = "Boar";
                GameServerSettings.GameIniState.DisallowedAIClasses.Add(ai);
            }
            if (!chkDeerAI.Checked) {
                ai.AIName = "Deer";
                GameServerSettings.GameIniState.DisallowedAIClasses.Add(ai);
            }
            if (!chkGoatAI.Checked) {
                ai.AIName = "Goat";
                GameServerSettings.GameIniState.DisallowedAIClasses.Add(ai);
            }
            if (!chkSeaturtleAI.Checked) {
                ai.AIName = "Seaturtle";
                GameServerSettings.GameIniState.DisallowedAIClasses.Add(ai);
            }
        }
    }
}
