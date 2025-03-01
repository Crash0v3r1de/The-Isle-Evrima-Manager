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
    public partial class frmRCONSettings : Form
    {
        public frmRCONSettings()
        {
            InitializeComponent();
        }

        private void exitAndDiscardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // When github is public, load wiki page for this functionality
        }

        private void saveAndCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RCONGlobalTracker.rconHost = txtHost.Text;
            RCONGlobalTracker.rconPort = txtPort.Text;
            RCONGlobalTracker.rconPassword = txtPassword.Text;
            RCONGlobalTracker.rconEnabled = chkEnableRCON.Checked;
            this.Close();
            this.Dispose();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmRCONSettings_Load(object sender, EventArgs e)
        {
            txtHost.Text = RCONGlobalTracker.rconHost;
            txtPort.Text = RCONGlobalTracker.rconPort;
            txtPassword.Text = RCONGlobalTracker.rconPassword;
            chkEnableRCON.Checked = RCONGlobalTracker.rconEnabled;
        }
    }
}
