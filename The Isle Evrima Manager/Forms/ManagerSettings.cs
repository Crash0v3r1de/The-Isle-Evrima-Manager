using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

namespace The_Isle_Evrima_Manager.Forms
{
    public partial class ManagerSettings : Form
    {
        public ManagerSettings()
        {
            InitializeComponent();
        }

        private void txtHardwareRefreshInt_TextChanged(object sender, EventArgs e)
        {
            int validate = 0;
            if (!int.TryParse(txtHardwareRefreshInt.Text, out validate))
            {
                try
                {
                    // Adding error handling because user error is ever so prevalent.
                    // We'll do final validation on save
                    txtHardwareRefreshInt.Text = txtHardwareRefreshInt.Text.Substring(0, (txtHardwareRefreshInt.TextLength - 1));
                    txtHardwareRefreshInt.SelectionStart = txtHardwareRefreshInt.Text.Length;
                    txtHardwareRefreshInt.ScrollToCaret();
                }
                catch
                {
                    // Just send it to the end either way
                    txtHardwareRefreshInt.SelectionStart = txtHardwareRefreshInt.Text.Length;
                    txtHardwareRefreshInt.ScrollToCaret();
                }
            }
        }

        private void txtServerStatRefreshInt_TextChanged(object sender, EventArgs e)
        {
            int validate = 0;
            if (!int.TryParse(txtServerStatRefreshInt.Text, out validate))
            {
                try
                {
                    // Adding error handling because user error is ever so prevalent.
                    // We'll do final validation on save
                    txtServerStatRefreshInt.Text = txtServerStatRefreshInt.Text.Substring(0, (txtServerStatRefreshInt.TextLength - 1));
                    txtServerStatRefreshInt.SelectionStart = txtServerStatRefreshInt.Text.Length;
                    txtServerStatRefreshInt.ScrollToCaret();
                }
                catch
                {
                    // Just send it to the end either way
                    txtHardwareRefreshInt.SelectionStart = txtHardwareRefreshInt.Text.Length;
                    txtHardwareRefreshInt.ScrollToCaret();
                }
            }
        }

        private void ManagerSettings_Load(object sender, EventArgs e)
        {
            LoadRuntimeSettings();
        }
        private void LoadRuntimeSettings()
        {
            // Load current runtime settings - imported on app load
            txtServerStatRefreshInt.Text = (ManagerStatusTracker.serverStatsRefreshInt / 1000).ToString(); // Parse to second
            txtHardwareRefreshInt.Text = (ManagerStatusTracker.resourceRefreshInt / 1000).ToString();
            chkCPURAM.Checked = ManagerStatusTracker.monitorHardware;
            chkDiscordNotifyFails.Checked = GameServerStatusTracker.DiscordNotifyOnFail;
            chkRestartServerOnFail.Checked = GameServerStatusTracker.RestartProcessOnFail;
            chkServerMonitoring.Checked = ManagerStatusTracker.monitorServer;
            chkForUpdates.Checked = ManagerStatusTracker.checkForManagerUpdates;
            if (!String.IsNullOrWhiteSpace(ManagerStatusTracker.discordWebhookURL)) txtDiscordWebhoolURL.Text = ManagerStatusTracker.discordWebhookURL;
            chkDiscordNotifications.Checked = ManagerStatusTracker.enableDiscordNotifications;
        }
        private void SaveRuntimeSettings()
        {
            // Also will eventually save the manager config to settings.json - when implimented
            ManagerStatusTracker.serverStatsRefreshInt = int.Parse(txtServerStatRefreshInt.Text) * 1000;
            ManagerStatusTracker.resourceRefreshInt = int.Parse(txtHardwareRefreshInt.Text) * 1000;
            ManagerStatusTracker.monitorHardware = chkCPURAM.Checked;
            ManagerStatusTracker.monitorServer = chkServerMonitoring.Checked;
            ManagerStatusTracker.checkForManagerUpdates = chkForUpdates.Checked;
            GameServerStatusTracker.DiscordNotifyOnFail = chkDiscordNotifyFails.Checked;
            GameServerStatusTracker.RestartProcessOnFail = chkRestartServerOnFail.Checked;
            if (!String.IsNullOrWhiteSpace(txtDiscordWebhoolURL.Text)) ManagerStatusTracker.discordWebhookURL = txtDiscordWebhoolURL.Text;
            ManagerStatusTracker.enableDiscordNotifications = chkDiscordNotifications.Checked;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRuntimeSettings();
            this.Close();
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
