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
    public partial class ServerAdmins : Form
    {
        public List<string> AdminSteamIDs = new List<string>();
        public ServerAdmins()
        {
            InitializeComponent();
        }

        private void ServerAdmins_Load(object sender, EventArgs e)
        {
            LoadAdminList();
        }

        private void exitAndDiscardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lblGetID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", "https://steamid.io/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameServerSettings.GameIniState.AdminSteamIDs.RemoveAt(lstAdmins.SelectedIndex);
            GameServerSettings.PendingSettingsApply = true;
            lstAdmins.Items.Clear();
            LoadAdminList();
        }

        private void LoadAdminList()
        {
            if (GameServerSettings.GameIniState.AdminSteamIDs != null && GameServerSettings.GameIniState.AdminSteamIDs.Count > 0)
            {
                for (int x = 0; x < GameServerSettings.GameIniState.AdminSteamIDs.Count; x++)
                {
                    lstAdmins.Items.Add(GameServerSettings.GameIniState.AdminSteamIDs[x]); // Load in logical order
                }
            }
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            // Alot of logic for user error handling
            if (txtAdminID.Text.Length > 17 || txtAdminID.Text.Length < 16)
            {
                if (!IsDigitsOnly(txtAdminID.Text))
                {
                    MessageBox.Show("Steam ID contains non numbers, please use a correct SteamID64.");
                }
                else
                {
                    if (txtAdminID.Text.Length > 17) MessageBox.Show("Steam ID is too long, please use a correct SteamID64.");
                    if (txtAdminID.Text.Length < 16) MessageBox.Show("Steam ID is too short, please use a correct SteamID64.");
                }
                txtAdminID.Text = "";
            }
            else
            {
                if (!IsDigitsOnly(txtAdminID.Text))
                {
                    MessageBox.Show("Steam ID contains non numbers, please use a correct SteamID64.");
                    txtAdminID.Text = "";
                }
                else
                {
                    GameServerSettings.GameIniState.AdminSteamIDs.Add(txtAdminID.Text);
                    GameServerSettings.PendingSettingsApply = true;
                    LoadAdminList();
                    txtAdminID.Text = "";
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

        private void saveAndCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Load wiki page when public
        }
    }
}
