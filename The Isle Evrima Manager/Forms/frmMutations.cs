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
            Mutations mut = new Mutations();
            mut.EffectiveValue = Decimal.Parse(txtMutationEffectiveValue.Text); // It only allows decimal values
            mut.Name = txtMutationName.Text;
            GameServerSettings.GameIniState.EnabledMutations.Add(mut);
            UpdateMutationList();
            txtMutationEffectiveValue.Text = "1.00";
            txtMutationName.Text = "";
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
    }
}
