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
            this.Close();
            this.Dispose();
        }

        private void lblGetID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", "https://steamid.io/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selected = lstAdmins.SelectedIndex;
            GameServerSettings.GameIniState.AdminSteamIDs.RemoveAt(selected);
            // TODO: Need to report config change if running and stage the change next stop/reboot
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
                    MessageBox.Show("Steam ID containers non numbers, please use a correct SteamID64.");
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
                    MessageBox.Show("Steam ID containers non numbers, please use a correct SteamID64.");
                    txtAdminID.Text = "";
                }
                else
                {
                    AdminSteamIDs.Add(txtAdminID.Text);
                    lstAdmins.Items.Add(txtAdminID.Text);
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
            foreach (var id in lstAdmins.Items) { 
                GameServerSettings.GameIniState.AdminSteamIDs.Add(id.ToString());
            }
            this.Close();
            this.Dispose();
        }
    }
}
