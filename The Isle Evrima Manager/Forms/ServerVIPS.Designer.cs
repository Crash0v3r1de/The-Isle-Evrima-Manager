namespace The_Isle_Evrima_Manager.Forms
{
    partial class ServerVIPS
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
            closeToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            btnAddVIP = new Button();
            lblGetID = new LinkLabel();
            txtVIPID = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnRemoveVIP = new Button();
            lstVIPs = new ListBox();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { closeToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(325, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(48, 20);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
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
            groupBox1.Controls.Add(btnAddVIP);
            groupBox1.Controls.Add(lblGetID);
            groupBox1.Controls.Add(txtVIPID);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(290, 114);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add VIP";
            // 
            // btnAddVIP
            // 
            btnAddVIP.Location = new Point(18, 66);
            btnAddVIP.Name = "btnAddVIP";
            btnAddVIP.Size = new Size(258, 23);
            btnAddVIP.TabIndex = 7;
            btnAddVIP.Text = "Add";
            btnAddVIP.UseVisualStyleBackColor = true;
            btnAddVIP.Click += btnAddVIP_Click;
            // 
            // lblGetID
            // 
            lblGetID.AutoSize = true;
            lblGetID.Location = new Point(87, 19);
            lblGetID.Name = "lblGetID";
            lblGetID.Size = new Size(65, 15);
            lblGetID.TabIndex = 6;
            lblGetID.TabStop = true;
            lblGetID.Text = "(Obtain ID)";
            lblGetID.VisitedLinkColor = Color.Blue;
            lblGetID.LinkClicked += lblGetID_LinkClicked;
            // 
            // txtVIPID
            // 
            txtVIPID.Location = new Point(18, 37);
            txtVIPID.Name = "txtVIPID";
            txtVIPID.Size = new Size(258, 23);
            txtVIPID.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 19);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 4;
            label1.Text = "SteamID64";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnRemoveVIP);
            groupBox2.Controls.Add(lstVIPs);
            groupBox2.Location = new Point(12, 147);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(290, 291);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Current VIPs";
            // 
            // btnRemoveVIP
            // 
            btnRemoveVIP.Location = new Point(87, 257);
            btnRemoveVIP.Name = "btnRemoveVIP";
            btnRemoveVIP.Size = new Size(123, 23);
            btnRemoveVIP.TabIndex = 1;
            btnRemoveVIP.Text = "Delete";
            btnRemoveVIP.UseVisualStyleBackColor = true;
            btnRemoveVIP.Click += btnRemoveVIP_Click;
            // 
            // lstVIPs
            // 
            lstVIPs.FormattingEnabled = true;
            lstVIPs.ItemHeight = 15;
            lstVIPs.Location = new Point(6, 22);
            lstVIPs.Name = "lstVIPs";
            lstVIPs.Size = new Size(278, 229);
            lstVIPs.TabIndex = 0;
            // 
            // ServerVIPS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ServerVIPS";
            Text = "Game Server VIPs - Skip Da Line";
            Load += ServerVIPS_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private GroupBox groupBox1;
        private Button btnAddVIP;
        private LinkLabel lblGetID;
        private TextBox txtVIPID;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnRemoveVIP;
        private ListBox lstVIPs;
    }
}