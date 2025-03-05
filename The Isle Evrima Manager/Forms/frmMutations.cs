using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_Isle_Evrima_Manager.JSON;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

namespace The_Isle_Evrima_Manager.Forms
{
    public partial class frmMutations : Form
    {
        private int currentMutationIndex = -1;
        public frmMutations()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Load wiki page when public and setup
        }

        private void frmMutations_Load(object sender, EventArgs e)
        {
            if (GameServerSettings.GameIniState.EnabledMutations != null && GameServerSettings.GameIniState.EnabledMutations.Count > 0)
            {
                for (int x = 0; x < GameServerSettings.GameIniState.EnabledMutations.Count; x++)
                {
                    lstMutations.Items.Add(GameServerSettings.GameIniState.EnabledMutations[x]);
                }
            }
        }

        private void btnAddMutation_Click(object sender, EventArgs e)
        {
            if (currentMutationIndex != -1)
            {
                // We're adding a new item
                Mutations mut = new Mutations();
                mut.EffectiveValue = Decimal.Parse(txtMutationEffectiveValue.Text); // It only allows decimal values
                mut.Name = txtMutationName.Text;
                GameServerSettings.GameIniState.EnabledMutations.Add(mut);
                UpdateMutationList();
                txtMutationEffectiveValue.Text = "1.00";
                txtMutationName.Text = "";
                GameServerSettings.PendingSettingsApply = true;
            }
            else {
                // We're updating an existing item
                GameServerSettings.GameIniState.EnabledMutations[currentMutationIndex].EffectiveValue = Decimal.Parse(txtMutationEffectiveValue.Text);
                GameServerSettings.GameIniState.EnabledMutations[currentMutationIndex].Name = txtMutationName.Text;
                txtMutationEffectiveValue.Text = "1.00";
                txtMutationName.Text = "";
                UpdateMutationList(); // Technically we don't have to but we will just because
                GameServerSettings.PendingSettingsApply = true;
            }
        }

        private void UpdateMutationList()
        {
            lstMutations.Items.Clear();
            LoadMutations();
        }
        private void LoadMutations()
        {
            for (int x = 0; x < GameServerSettings.GameIniState.EnabledMutations.Count; x++)
            {
                lstMutations.Items.Add(GameServerSettings.GameIniState.EnabledMutations[x]);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentMutationIndex = lstMutations.SelectedIndex;
            var selected = GameServerSettings.GameIniState.EnabledMutations[currentMutationIndex];
            txtMutationName.Text = selected.Name;
            txtMutationEffectiveValue.Text = selected.EffectiveValue.ToString();
        }
    }
}
