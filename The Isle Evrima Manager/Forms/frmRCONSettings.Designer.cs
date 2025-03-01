namespace The_Isle_Evrima_Manager.Forms
{
    partial class frmRCONSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            saveAndCloseToolStripMenuItem = new ToolStripMenuItem();
            exitAndDiscardToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            chkEnableRCON = new CheckBox();
            txtPassword = new TextBox();
            label3 = new Label();
            txtPort = new NumericUpDown();
            label2 = new Label();
            txtHost = new TextBox();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtPort).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { saveAndCloseToolStripMenuItem, exitAndDiscardToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(426, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // saveAndCloseToolStripMenuItem
            // 
            saveAndCloseToolStripMenuItem.Name = "saveAndCloseToolStripMenuItem";
            saveAndCloseToolStripMenuItem.Size = new Size(98, 20);
            saveAndCloseToolStripMenuItem.Text = "Save and Close";
            saveAndCloseToolStripMenuItem.Click += saveAndCloseToolStripMenuItem_Click;
            // 
            // exitAndDiscardToolStripMenuItem
            // 
            exitAndDiscardToolStripMenuItem.Name = "exitAndDiscardToolStripMenuItem";
            exitAndDiscardToolStripMenuItem.Size = new Size(103, 20);
            exitAndDiscardToolStripMenuItem.Text = "Exit and Discard";
            exitAndDiscardToolStripMenuItem.Click += exitAndDiscardToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(24, 20);
            toolStripMenuItem1.Text = "?";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkEnableRCON);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtPort);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtHost);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(411, 174);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Connection Settings";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // chkEnableRCON
            // 
            chkEnableRCON.AutoSize = true;
            chkEnableRCON.Checked = true;
            chkEnableRCON.CheckState = CheckState.Checked;
            chkEnableRCON.Location = new Point(157, 12);
            chkEnableRCON.Name = "chkEnableRCON";
            chkEnableRCON.Size = new Size(167, 19);
            chkEnableRCON.TabIndex = 6;
            chkEnableRCON.Text = "Enable RCON Connections";
            chkEnableRCON.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(6, 125);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(298, 23);
            txtPassword.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 107);
            label3.Name = "label3";
            label3.Size = new Size(140, 15);
            label3.TabIndex = 4;
            label3.Text = "Password (NOT MASKED)";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(6, 81);
            txtPort.Maximum = new decimal(new int[] { 65353, 0, 0, 0 });
            txtPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(120, 23);
            txtPort.TabIndex = 3;
            txtPort.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 63);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 2;
            label2.Text = "Port";
            // 
            // txtHost
            // 
            txtHost.Location = new Point(6, 37);
            txtHost.Name = "txtHost";
            txtHost.Size = new Size(298, 23);
            txtHost.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 0;
            label1.Text = "Host";
            // 
            // frmRCONSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 208);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmRCONSettings";
            Text = "RCON Connection Settings";
            Load += frmRCONSettings_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtPort).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem saveAndCloseToolStripMenuItem;
        private ToolStripMenuItem exitAndDiscardToolStripMenuItem;
        private GroupBox groupBox1;
        private ToolStripMenuItem toolStripMenuItem1;
        private Label label1;
        private NumericUpDown txtPort;
        private Label label2;
        private TextBox txtHost;
        private TextBox txtPassword;
        private Label label3;
        private CheckBox chkEnableRCON;
    }
}