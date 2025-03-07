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
    public partial class ServerWhitelist : Form
    {
        public List<string> WhitelistIDs = new List<string>();
        public ServerWhitelist()
        {
            InitializeComponent();
        }

        private void ServerWhitelist_Load(object sender, EventArgs e)
        {
            LoadWhitelistList();
        }

        private void LoadWhitelistList()
        {
            if (GameServerSettings.GameIniState.WhitelistIDs != null && GameServerSettings.GameIniState.WhitelistIDs.Count > 0)
            {
                for (int x = 0; x < GameServerSettings.GameIniState.WhitelistIDs.Count; x++)
                {
                    lstWhitelistIDs.Items.Add(GameServerSettings.GameIniState.WhitelistIDs[x]); // Load in logical order
                }
            }
        }

        private void lblGetID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", "https://steamid.io/");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Load wiki page when public
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // Alot of logic for user error handling
            if (txtSteamID.Text.Length > 17 || txtSteamID.Text.Length < 16)
            {
                if (!IsDigitsOnly(txtSteamID.Text))
                {
                    MessageBox.Show("Steam ID containers non numbers, please use a correct SteamID64.");
                }
                else
                {
                    if (txtSteamID.Text.Length > 17) MessageBox.Show("Steam ID is too long, please use a correct SteamID64.");
                    if (txtSteamID.Text.Length < 16) MessageBox.Show("Steam ID is too short, please use a correct SteamID64.");
                }
                txtSteamID.Text = "";
            }
            else
            {
                if (!IsDigitsOnly(txtSteamID.Text))
                {
                    MessageBox.Show("Steam ID containers non numbers, please use a correct SteamID64.");
                    txtSteamID.Text = "";
                }
                else
                {
                    ParseNewID(txtSteamID.Text);
                    txtSteamID.Text = "";
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
        private void ParseNewID(string id)
        {
            GameServerSettings.GameIniState.WhitelistIDs.Add(id);
            GameServerSettings.PendingSettingsApply = true;
            ReloadIDList();
        }
        private void ReloadIDList()
        {
            lstWhitelistIDs.Items.Clear();
            for (int x = 0; x < GameServerSettings.GameIniState.WhitelistIDs.Count; x++)
            {
                lstWhitelistIDs.Items.Add(GameServerSettings.GameIniState.WhitelistIDs[x]);
            }
        }

        private void btnRemoveID_Click(object sender, EventArgs e)
        {
            GameServerSettings.GameIniState.AdminSteamIDs.RemoveAt(lstWhitelistIDs.SelectedIndex);
            GameServerSettings.PendingSettingsApply = true;
            lstWhitelistIDs.Items.Clear();
            ReloadIDList();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
