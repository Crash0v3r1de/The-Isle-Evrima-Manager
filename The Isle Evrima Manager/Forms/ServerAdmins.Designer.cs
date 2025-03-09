namespace The_Isle_Evrima_Manager.Forms
{
    partial class ServerAdmins
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
            btnAddAdmin = new Button();
            lblGetID = new LinkLabel();
            txtAdminID = new TextBox();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            saveAndCloseToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            groupBox2 = new GroupBox();
            button1 = new Button();
            lstAdmins = new ListBox();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddAdmin);
            groupBox1.Controls.Add(lblGetID);
            groupBox1.Controls.Add(txtAdminID);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(53, 34);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(275, 114);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add Admin";
            // 
            // btnAddAdmin
            // 
            btnAddAdmin.Location = new Point(6, 76);
            btnAddAdmin.Name = "btnAddAdmin";
            btnAddAdmin.Size = new Size(258, 23);
            btnAddAdmin.TabIndex = 3;
            btnAddAdmin.Text = "Add";
            btnAddAdmin.UseVisualStyleBackColor = true;
            btnAddAdmin.Click += btnAddAdmin_Click;
            // 
            // lblGetID
            // 
            lblGetID.AutoSize = true;
            lblGetID.Location = new Point(75, 29);
            lblGetID.Name = "lblGetID";
            lblGetID.Size = new Size(65, 15);
            lblGetID.TabIndex = 2;
            lblGetID.TabStop = true;
            lblGetID.Text = "(Obtain ID)";
            lblGetID.VisitedLinkColor = Color.Blue;
            lblGetID.LinkClicked += lblGetID_LinkClicked;
            // 
            // txtAdminID
            // 
            txtAdminID.Location = new Point(6, 47);
            txtAdminID.Name = "txtAdminID";
            txtAdminID.Size = new Size(258, 23);
            txtAdminID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 29);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 0;
            label1.Text = "SteamID64";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { saveAndCloseToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(382, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // saveAndCloseToolStripMenuItem
            // 
            saveAndCloseToolStripMenuItem.Name = "saveAndCloseToolStripMenuItem";
            saveAndCloseToolStripMenuItem.Size = new Size(48, 20);
            saveAndCloseToolStripMenuItem.Text = "Close";
            saveAndCloseToolStripMenuItem.Click += saveAndCloseToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(24, 20);
            toolStripMenuItem1.Text = "?";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(lstAdmins);
            groupBox2.Location = new Point(12, 154);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(354, 212);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Current Admins";
            // 
            // button1
            // 
            button1.Location = new Point(96, 182);
            button1.Name = "button1";
            button1.Size = new Size(146, 23);
            button1.TabIndex = 1;
            button1.Text = "Delete Selected";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lstAdmins
            // 
            lstAdmins.FormattingEnabled = true;
            lstAdmins.ItemHeight = 15;
            lstAdmins.Location = new Point(6, 22);
            lstAdmins.Name = "lstAdmins";
            lstAdmins.Size = new Size(342, 154);
            lstAdmins.TabIndex = 0;
            // 
            // ServerAdmins
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 373);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ServerAdmins";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Game Server Admins";
            Load += ServerAdmins_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private LinkLabel lblGetID;
        private TextBox txtAdminID;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem saveAndCloseToolStripMenuItem;
        private Button btnAddAdmin;
        private GroupBox groupBox2;
        private ListBox lstAdmins;
        private Button button1;
        private ToolStripMenuItem toolStripMenuItem1;
    }
}