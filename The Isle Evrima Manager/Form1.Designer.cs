namespace The_Isle_Evrima_Manager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            stsStripMain = new StatusStrip();
            lblServerStatus = new ToolStripStatusLabel();
            lblMemUsage = new ToolStripStatusLabel();
            groupBox1 = new GroupBox();
            lblSteamClient = new Label();
            lblcplusplus = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            lblCoreSpeed = new Label();
            lblCores = new Label();
            lblRAM = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            groupBox3 = new GroupBox();
            txtConsole = new RichTextBox();
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            refreshResourcesToolStripMenuItem = new ToolStripMenuItem();
            managerSettingsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolStripDropDownButton2 = new ToolStripDropDownButton();
            viewLogsToolStripMenuItem = new ToolStripMenuItem();
            downloadDependenciesToolStripMenuItem = new ToolStripMenuItem();
            steamCMDToolStripMenuItem = new ToolStripMenuItem();
            theIsleServerToolStripMenuItem = new ToolStripMenuItem();
            steamClientToolStripMenuItem = new ToolStripMenuItem();
            toolStripDropDownButton3 = new ToolStripDropDownButton();
            btnStartIsleServer = new ToolStripMenuItem();
            btnStopIsleServer = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            btnVerifyIsleServer = new ToolStripMenuItem();
            btnServerStatsRefresh = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripDropDownButton4 = new ToolStripDropDownButton();
            steamClientWhatGivesToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            groupBox4 = new GroupBox();
            lblPlayerDataCount = new Label();
            label6 = new Label();
            stsStripMain.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            toolStrip1.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // stsStripMain
            // 
            stsStripMain.Items.AddRange(new ToolStripItem[] { lblServerStatus, lblMemUsage });
            stsStripMain.Location = new Point(0, 464);
            stsStripMain.Name = "stsStripMain";
            stsStripMain.Size = new Size(800, 22);
            stsStripMain.TabIndex = 0;
            stsStripMain.Text = "statusStrip1";
            // 
            // lblServerStatus
            // 
            lblServerStatus.Name = "lblServerStatus";
            lblServerStatus.Size = new Size(35, 17);
            lblServerStatus.Text = "Idle...";
            // 
            // lblMemUsage
            // 
            lblMemUsage.Name = "lblMemUsage";
            lblMemUsage.Size = new Size(80, 17);
            lblMemUsage.Text = "RAM Free: 0%";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblSteamClient);
            groupBox1.Controls.Add(lblcplusplus);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(259, 64);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "System Checks";
            // 
            // lblSteamClient
            // 
            lblSteamClient.AutoSize = true;
            lblSteamClient.Location = new Point(78, 39);
            lblSteamClient.Name = "lblSteamClient";
            lblSteamClient.Size = new Size(38, 15);
            lblSteamClient.TabIndex = 2;
            lblSteamClient.Text = "label3";
            // 
            // lblcplusplus
            // 
            lblcplusplus.AutoSize = true;
            lblcplusplus.Location = new Point(87, 19);
            lblcplusplus.Name = "lblcplusplus";
            lblcplusplus.Size = new Size(38, 15);
            lblcplusplus.TabIndex = 2;
            lblcplusplus.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 39);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 2;
            label2.Text = "Steam DLLs:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 0;
            label1.Text = "c++ Runtime:";
            label1.Click += label1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblCoreSpeed);
            groupBox2.Controls.Add(lblCores);
            groupBox2.Controls.Add(lblRAM);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 111);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(259, 79);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Server Info";
            // 
            // lblCoreSpeed
            // 
            lblCoreSpeed.AutoSize = true;
            lblCoreSpeed.Location = new Point(75, 55);
            lblCoreSpeed.Name = "lblCoreSpeed";
            lblCoreSpeed.Size = new Size(44, 15);
            lblCoreSpeed.TabIndex = 3;
            lblCoreSpeed.Text = "1.0GHz";
            // 
            // lblCores
            // 
            lblCores.AutoSize = true;
            lblCores.Location = new Point(71, 37);
            lblCores.Name = "lblCores";
            lblCores.Size = new Size(13, 15);
            lblCores.TabIndex = 3;
            lblCores.Text = "0";
            // 
            // lblRAM
            // 
            lblRAM.AutoSize = true;
            lblRAM.Location = new Point(41, 19);
            lblRAM.Name = "lblRAM";
            lblRAM.Size = new Size(28, 15);
            lblRAM.TabIndex = 3;
            lblRAM.Text = "0GB";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 55);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 3;
            label5.Text = "Core Speed";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 37);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 3;
            label4.Text = "CPU Cores";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 3;
            label3.Text = "RAM";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtConsole);
            groupBox3.Location = new Point(12, 196);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(776, 258);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Server Console";
            // 
            // txtConsole
            // 
            txtConsole.Location = new Point(6, 22);
            txtConsole.Name = "txtConsole";
            txtConsole.ReadOnly = true;
            txtConsole.Size = new Size(764, 230);
            txtConsole.TabIndex = 0;
            txtConsole.Text = "";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, toolStripDropDownButton2, toolStripDropDownButton3, toolStripSeparator3, toolStripDropDownButton4 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { refreshResourcesToolStripMenuItem, managerSettingsToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(38, 22);
            toolStripDropDownButton1.Text = "File";
            // 
            // refreshResourcesToolStripMenuItem
            // 
            refreshResourcesToolStripMenuItem.Checked = true;
            refreshResourcesToolStripMenuItem.CheckState = CheckState.Checked;
            refreshResourcesToolStripMenuItem.Name = "refreshResourcesToolStripMenuItem";
            refreshResourcesToolStripMenuItem.Size = new Size(169, 22);
            refreshResourcesToolStripMenuItem.Text = "Refresh Resources";
            refreshResourcesToolStripMenuItem.Click += refreshResourcesToolStripMenuItem_Click;
            // 
            // managerSettingsToolStripMenuItem
            // 
            managerSettingsToolStripMenuItem.Name = "managerSettingsToolStripMenuItem";
            managerSettingsToolStripMenuItem.Size = new Size(169, 22);
            managerSettingsToolStripMenuItem.Text = "Manager Settings";
            managerSettingsToolStripMenuItem.Click += managerSettingsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(166, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(169, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolStripDropDownButton2
            // 
            toolStripDropDownButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton2.DropDownItems.AddRange(new ToolStripItem[] { viewLogsToolStripMenuItem, downloadDependenciesToolStripMenuItem });
            toolStripDropDownButton2.Image = (Image)resources.GetObject("toolStripDropDownButton2.Image");
            toolStripDropDownButton2.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            toolStripDropDownButton2.Size = new Size(47, 22);
            toolStripDropDownButton2.Text = "Tools";
            // 
            // viewLogsToolStripMenuItem
            // 
            viewLogsToolStripMenuItem.Name = "viewLogsToolStripMenuItem";
            viewLogsToolStripMenuItem.Size = new Size(230, 22);
            viewLogsToolStripMenuItem.Text = "View Logs";
            // 
            // downloadDependenciesToolStripMenuItem
            // 
            downloadDependenciesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { steamCMDToolStripMenuItem, theIsleServerToolStripMenuItem, steamClientToolStripMenuItem });
            downloadDependenciesToolStripMenuItem.Name = "downloadDependenciesToolStripMenuItem";
            downloadDependenciesToolStripMenuItem.Size = new Size(230, 22);
            downloadDependenciesToolStripMenuItem.Text = "Download Dependencies (All)";
            // 
            // steamCMDToolStripMenuItem
            // 
            steamCMDToolStripMenuItem.Name = "steamCMDToolStripMenuItem";
            steamCMDToolStripMenuItem.Size = new Size(180, 22);
            steamCMDToolStripMenuItem.Text = "SteamCMD";
            steamCMDToolStripMenuItem.Click += steamCMDToolStripMenuItem_Click;
            // 
            // theIsleServerToolStripMenuItem
            // 
            theIsleServerToolStripMenuItem.Name = "theIsleServerToolStripMenuItem";
            theIsleServerToolStripMenuItem.Size = new Size(180, 22);
            theIsleServerToolStripMenuItem.Text = "The Isle Server";
            theIsleServerToolStripMenuItem.Click += theIsleServerToolStripMenuItem_Click;
            // 
            // steamClientToolStripMenuItem
            // 
            steamClientToolStripMenuItem.Name = "steamClientToolStripMenuItem";
            steamClientToolStripMenuItem.Size = new Size(180, 22);
            steamClientToolStripMenuItem.Text = "Steam DLLs";
            steamClientToolStripMenuItem.Click += steamClientToolStripMenuItem_Click;
            // 
            // toolStripDropDownButton3
            // 
            toolStripDropDownButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton3.DropDownItems.AddRange(new ToolStripItem[] { btnStartIsleServer, btnStopIsleServer, toolStripSeparator2, btnVerifyIsleServer, btnServerStatsRefresh });
            toolStripDropDownButton3.Image = (Image)resources.GetObject("toolStripDropDownButton3.Image");
            toolStripDropDownButton3.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            toolStripDropDownButton3.Size = new Size(52, 22);
            toolStripDropDownButton3.Text = "Server";
            // 
            // btnStartIsleServer
            // 
            btnStartIsleServer.Name = "btnStartIsleServer";
            btnStartIsleServer.Size = new Size(213, 22);
            btnStartIsleServer.Text = "Start";
            // 
            // btnStopIsleServer
            // 
            btnStopIsleServer.Name = "btnStopIsleServer";
            btnStopIsleServer.Size = new Size(213, 22);
            btnStopIsleServer.Text = "Stop";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(210, 6);
            // 
            // btnVerifyIsleServer
            // 
            btnVerifyIsleServer.Name = "btnVerifyIsleServer";
            btnVerifyIsleServer.Size = new Size(213, 22);
            btnVerifyIsleServer.Text = "Verify (will stop if running)";
            // 
            // btnServerStatsRefresh
            // 
            btnServerStatsRefresh.Checked = true;
            btnServerStatsRefresh.CheckState = CheckState.Checked;
            btnServerStatsRefresh.Name = "btnServerStatsRefresh";
            btnServerStatsRefresh.Size = new Size(213, 22);
            btnServerStatsRefresh.Text = "Refresh Stats Data";
            btnServerStatsRefresh.Click += btnServerStatsRefresh_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // toolStripDropDownButton4
            // 
            toolStripDropDownButton4.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton4.DropDownItems.AddRange(new ToolStripItem[] { steamClientWhatGivesToolStripMenuItem, aboutToolStripMenuItem });
            toolStripDropDownButton4.Image = (Image)resources.GetObject("toolStripDropDownButton4.Image");
            toolStripDropDownButton4.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            toolStripDropDownButton4.Size = new Size(45, 22);
            toolStripDropDownButton4.Text = "Help";
            // 
            // steamClientWhatGivesToolStripMenuItem
            // 
            steamClientWhatGivesToolStripMenuItem.Name = "steamClientWhatGivesToolStripMenuItem";
            steamClientWhatGivesToolStripMenuItem.Size = new Size(225, 22);
            steamClientWhatGivesToolStripMenuItem.Text = "Steam Client - What gives???";
            steamClientWhatGivesToolStripMenuItem.Click += steamClientWhatGivesToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(225, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lblPlayerDataCount);
            groupBox4.Controls.Add(label6);
            groupBox4.Location = new Point(277, 41);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(251, 149);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Server Info";
            // 
            // lblPlayerDataCount
            // 
            lblPlayerDataCount.AutoSize = true;
            lblPlayerDataCount.Location = new Point(148, 19);
            lblPlayerDataCount.Name = "lblPlayerDataCount";
            lblPlayerDataCount.Size = new Size(13, 15);
            lblPlayerDataCount.TabIndex = 1;
            lblPlayerDataCount.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 19);
            label6.Name = "label6";
            label6.Size = new Size(140, 15);
            label6.TabIndex = 0;
            label6.Text = "Total Players Data Entries:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 486);
            Controls.Add(groupBox4);
            Controls.Add(toolStrip1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(stsStripMain);
            Name = "Form1";
            Text = "The Isle Evirma Server Manager";
            Load += Form1_Load;
            stsStripMain.ResumeLayout(false);
            stsStripMain.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip stsStripMain;
        private ToolStripStatusLabel lblServerStatus;
        private GroupBox groupBox1;
        private Label label1;
        private Label lblSteamClient;
        private Label lblcplusplus;
        private Label label2;
        private GroupBox groupBox2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label lblCoreSpeed;
        private Label lblCores;
        private Label lblRAM;
        private GroupBox groupBox3;
        private RichTextBox txtConsole;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem viewLogsToolStripMenuItem;
        private ToolStripMenuItem downloadDependenciesToolStripMenuItem;
        private ToolStripMenuItem steamCMDToolStripMenuItem;
        private ToolStripMenuItem theIsleServerToolStripMenuItem;
        private ToolStripMenuItem steamClientToolStripMenuItem;
        private ToolStripStatusLabel lblMemUsage;
        private ToolStripMenuItem refreshResourcesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private GroupBox groupBox4;
        private Label lblPlayerDataCount;
        private Label label6;
        private ToolStripDropDownButton toolStripDropDownButton3;
        private ToolStripMenuItem btnStartIsleServer;
        private ToolStripMenuItem btnStopIsleServer;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem btnVerifyIsleServer;
        private ToolStripMenuItem btnServerStatsRefresh;
        private ToolStripMenuItem managerSettingsToolStripMenuItem;
        private ToolStripDropDownButton toolStripDropDownButton4;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem steamClientWhatGivesToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
    }
}
