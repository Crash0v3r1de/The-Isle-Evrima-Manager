namespace The_Isle_Evrima_Manager.Forms
{
    partial class ServerWhitelist
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
            groupBox1 = new GroupBox();
            btnAddUser = new Button();
            txtSteamID = new TextBox();
            lblGetID = new LinkLabel();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnRemoveID = new Button();
            lstWhitelistIDs = new ListBox();
            menuStrip1 = new MenuStrip();
            closeToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddUser);
            groupBox1.Controls.Add(txtSteamID);
            groupBox1.Controls.Add(lblGetID);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 32);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(285, 104);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add User";
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(6, 66);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(273, 23);
            btnAddUser.TabIndex = 5;
            btnAddUser.Text = "Add";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // txtSteamID
            // 
            txtSteamID.Location = new Point(6, 37);
            txtSteamID.Name = "txtSteamID";
            txtSteamID.Size = new Size(195, 23);
            txtSteamID.TabIndex = 4;
            // 
            // lblGetID
            // 
            lblGetID.AutoSize = true;
            lblGetID.Location = new Point(75, 19);
            lblGetID.Name = "lblGetID";
            lblGetID.Size = new Size(65, 15);
            lblGetID.TabIndex = 3;
            lblGetID.TabStop = true;
            lblGetID.Text = "(Obtain ID)";
            lblGetID.VisitedLinkColor = Color.Blue;
            lblGetID.LinkClicked += lblGetID_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 0;
            label1.Text = "SteamID64";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnRemoveID);
            groupBox2.Controls.Add(lstWhitelistIDs);
            groupBox2.Location = new Point(19, 142);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(270, 271);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Current IDs";
            // 
            // btnRemoveID
            // 
            btnRemoveID.Location = new Point(68, 242);
            btnRemoveID.Name = "btnRemoveID";
            btnRemoveID.Size = new Size(110, 23);
            btnRemoveID.TabIndex = 1;
            btnRemoveID.Text = "Delete";
            btnRemoveID.UseVisualStyleBackColor = true;
            btnRemoveID.Click += btnRemoveID_Click;
            // 
            // lstWhitelistIDs
            // 
            lstWhitelistIDs.FormattingEnabled = true;
            lstWhitelistIDs.ItemHeight = 15;
            lstWhitelistIDs.Location = new Point(6, 22);
            lstWhitelistIDs.Name = "lstWhitelistIDs";
            lstWhitelistIDs.Size = new Size(258, 214);
            lstWhitelistIDs.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { closeToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(312, 24);
            menuStrip1.TabIndex = 2;
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
            // ServerWhitelist
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 424);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ServerWhitelist";
            Text = "Game Server Whitelist IDs";
            Load += ServerWhitelist_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private LinkLabel lblGetID;
        private TextBox txtSteamID;
        private Button btnAddUser;
        private GroupBox groupBox2;
        private Button btnRemoveID;
        private ListBox lstWhitelistIDs;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
    }
}