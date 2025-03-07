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
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

namespace The_Isle_Evrima_Manager.Forms
{
    public partial class ServerVIPS : Form
    {
        public List<string> VIPs = new List<string>();
        public ServerVIPS()
        {
            InitializeComponent();
        }

        private void ServerVIPS_Load(object sender, EventArgs e)
        {
            LoadVIPList();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Load wiki page when public
        }

        private void btnAddVIP_Click(object sender, EventArgs e)
        {
            // Alot of logic for user error handling
            if (txtVIPID.Text.Length > 17 || txtVIPID.Text.Length < 16)
            {
                if (!IsDigitsOnly(txtVIPID.Text))
                {
                    MessageBox.Show("Steam ID contains non numbers, please use a correct SteamID64.");
                }
                else
                {
                    if (txtVIPID.Text.Length > 17) MessageBox.Show("Steam ID is too long, please use a correct SteamID64.");
                    if (txtVIPID.Text.Length < 16) MessageBox.Show("Steam ID is too short, please use a correct SteamID64.");
                }
                txtVIPID.Text = "";
            }
            else
            {
                if (!IsDigitsOnly(txtVIPID.Text))
                {
                    MessageBox.Show("Steam ID contains non numbers, please use a correct SteamID64.");
                    txtVIPID.Text = "";
                }
                else
                {
                    GameServerSettings.GameIniState.AdminSteamIDs.Add(txtVIPID.Text);
                    GameServerSettings.PendingSettingsApply = true;
                    LoadVIPList();
                    txtVIPID.Text = "";
                }
            }
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void lblGetID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", "https://steamid.io/");
        }

        private void LoadVIPList()
        {
            if (GameServerSettings.GameIniState.VIPs != null && GameServerSettings.GameIniState.VIPs.Count > 0)
            {
                for (int x = 0; x < GameServerSettings.GameIniState.VIPs.Count; x++)
                {
                    lstVIPs.Items.Add(GameServerSettings.GameIniState.VIPs[x]); // Load in logical order
                }
            }
        }

        private void btnRemoveVIP_Click(object sender, EventArgs e)
        {
            GameServerSettings.GameIniState.VIPs.RemoveAt(lstVIPs.SelectedIndex);
            GameServerSettings.PendingSettingsApply = true;
            lstVIPs.Items.Clear();
            LoadVIPList();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
