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
            lblIsAdmin = new ToolStripStatusLabel();
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
            autoCopyRequiredDLLsToolStripMenuItem = new ToolStripMenuItem();
            managerSettingsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolStripDropDownButton2 = new ToolStripDropDownButton();
            viewLogsToolStripMenuItem = new ToolStripMenuItem();
            downloadDependenciesToolStripMenuItem = new ToolStripMenuItem();
            steamCMDToolStripMenuItem = new ToolStripMenuItem();
            theIsleServerToolStripMenuItem = new ToolStripMenuItem();
            steamClientToolStripMenuItem = new ToolStripMenuItem();
            btnChangeProcPrior = new ToolStripMenuItem();
            changeServerDirectoryLocationToolStripMenuItem = new ToolStripMenuItem();
            toolStripDropDownButton3 = new ToolStripDropDownButton();
            btnStartIsleServer = new ToolStripMenuItem();
            btnStopIsleServer = new ToolStripMenuItem();
            btnForceStopIsleServer = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            generalServerSettingsToolStripMenuItem = new ToolStripMenuItem();
            userSettingsToolStripMenuItem = new ToolStripMenuItem();
            adminsToolStripMenuItem = new ToolStripMenuItem();
            vIPsToolStripMenuItem = new ToolStripMenuItem();
            whitelistToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            btnVerifyIsleServer = new ToolStripMenuItem();
            btnServerStatsRefresh = new ToolStripMenuItem();
            toolStripDropDownButton5 = new ToolStripDropDownButton();
            configureRCONConnectionToolStripMenuItem = new ToolStripMenuItem();
            configureRCONTasksToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripDropDownButton4 = new ToolStripDropDownButton();
            troubleshootingIssuesToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            btnPendingSettingsChange = new ToolStripButton();
            groupBox4 = new GroupBox();
            lblWhitelistCount = new Label();
            lblVIPCount = new Label();
            lblAdminCount = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            lblPlayerDataCount = new Label();
            label6 = new Label();
            btnStartServerUI = new Button();
            btnUIStopServerGraceful = new Button();
            btnForceStopUI = new Button();
            toolStripSeparator5 = new ToolStripSeparator();
            checkForManagerUpdateToolStripMenuItem = new ToolStripMenuItem();
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
            stsStripMain.Items.AddRange(new ToolStripItem[] { lblServerStatus, lblMemUsage, lblIsAdmin });
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
            // lblIsAdmin
            // 
            lblIsAdmin.Name = "lblIsAdmin";
            lblIsAdmin.Size = new Size(132, 17);
            lblIsAdmin.Text = "Running as normal user";
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
            lblSteamClient.Size = new Size(32, 15);
            lblSteamClient.TabIndex = 2;
            lblSteamClient.Text = "DLLs";
            // 
            // lblcplusplus
            // 
            lblcplusplus.AutoSize = true;
            lblcplusplus.Location = new Point(87, 19);
            lblcplusplus.Name = "lblcplusplus";
            lblcplusplus.Size = new Size(29, 15);
            lblcplusplus.TabIndex = 2;
            lblcplusplus.Text = "c++";
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, toolStripDropDownButton2, toolStripDropDownButton3, toolStripDropDownButton5, toolStripSeparator3, toolStripDropDownButton4, btnPendingSettingsChange });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { refreshResourcesToolStripMenuItem, autoCopyRequiredDLLsToolStripMenuItem, managerSettingsToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
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
            refreshResourcesToolStripMenuItem.Size = new Size(209, 22);
            refreshResourcesToolStripMenuItem.Text = "Refresh Resources";
            refreshResourcesToolStripMenuItem.Click += refreshResourcesToolStripMenuItem_Click;
            // 
            // autoCopyRequiredDLLsToolStripMenuItem
            // 
            autoCopyRequiredDLLsToolStripMenuItem.Checked = true;
            autoCopyRequiredDLLsToolStripMenuItem.CheckState = CheckState.Checked;
            autoCopyRequiredDLLsToolStripMenuItem.Name = "autoCopyRequiredDLLsToolStripMenuItem";
            autoCopyRequiredDLLsToolStripMenuItem.Size = new Size(209, 22);
            autoCopyRequiredDLLsToolStripMenuItem.Text = "Auto Copy Required DLLs";
            // 
            // managerSettingsToolStripMenuItem
            // 
            managerSettingsToolStripMenuItem.Name = "managerSettingsToolStripMenuItem";
            managerSettingsToolStripMenuItem.Size = new Size(209, 22);
            managerSettingsToolStripMenuItem.Text = "Manager Settings";
            managerSettingsToolStripMenuItem.Click += managerSettingsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(206, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(209, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolStripDropDownButton2
            // 
            toolStripDropDownButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton2.DropDownItems.AddRange(new ToolStripItem[] { viewLogsToolStripMenuItem, downloadDependenciesToolStripMenuItem, btnChangeProcPrior, changeServerDirectoryLocationToolStripMenuItem, toolStripSeparator5, checkForManagerUpdateToolStripMenuItem });
            toolStripDropDownButton2.Image = (Image)resources.GetObject("toolStripDropDownButton2.Image");
            toolStripDropDownButton2.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            toolStripDropDownButton2.Size = new Size(47, 22);
            toolStripDropDownButton2.Text = "Tools";
            // 
            // viewLogsToolStripMenuItem
            // 
            viewLogsToolStripMenuItem.Name = "viewLogsToolStripMenuItem";
            viewLogsToolStripMenuItem.Size = new Size(250, 22);
            viewLogsToolStripMenuItem.Text = "View Logs";
            // 
            // downloadDependenciesToolStripMenuItem
            // 
            downloadDependenciesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { steamCMDToolStripMenuItem, theIsleServerToolStripMenuItem, steamClientToolStripMenuItem });
            downloadDependenciesToolStripMenuItem.Name = "downloadDependenciesToolStripMenuItem";
            downloadDependenciesToolStripMenuItem.Size = new Size(250, 22);
            downloadDependenciesToolStripMenuItem.Text = "Download Dependencies (All)";
            // 
            // steamCMDToolStripMenuItem
            // 
            steamCMDToolStripMenuItem.Name = "steamCMDToolStripMenuItem";
            steamCMDToolStripMenuItem.Size = new Size(148, 22);
            steamCMDToolStripMenuItem.Text = "SteamCMD";
            steamCMDToolStripMenuItem.Click += steamCMDToolStripMenuItem_Click;
            // 
            // theIsleServerToolStripMenuItem
            // 
            theIsleServerToolStripMenuItem.Name = "theIsleServerToolStripMenuItem";
            theIsleServerToolStripMenuItem.Size = new Size(148, 22);
            theIsleServerToolStripMenuItem.Text = "The Isle Server";
            theIsleServerToolStripMenuItem.Click += theIsleServerToolStripMenuItem_Click;
            // 
            // steamClientToolStripMenuItem
            // 
            steamClientToolStripMenuItem.Name = "steamClientToolStripMenuItem";
            steamClientToolStripMenuItem.Size = new Size(148, 22);
            steamClientToolStripMenuItem.Text = "Steam DLLs";
            steamClientToolStripMenuItem.Click += steamClientToolStripMenuItem_Click;
            // 
            // btnChangeProcPrior
            // 
            btnChangeProcPrior.Name = "btnChangeProcPrior";
            btnChangeProcPrior.Size = new Size(250, 22);
            btnChangeProcPrior.Text = "Change Server Process Priority";
            // 
            // changeServerDirectoryLocationToolStripMenuItem
            // 
            changeServerDirectoryLocationToolStripMenuItem.Name = "changeServerDirectoryLocationToolStripMenuItem";
            changeServerDirectoryLocationToolStripMenuItem.Size = new Size(250, 22);
            changeServerDirectoryLocationToolStripMenuItem.Text = "Change Server Directory Location";
            changeServerDirectoryLocationToolStripMenuItem.Click += changeServerDirectoryLocationToolStripMenuItem_Click;
            // 
            // toolStripDropDownButton3
            // 
            toolStripDropDownButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton3.DropDownItems.AddRange(new ToolStripItem[] { btnStartIsleServer, btnStopIsleServer, btnForceStopIsleServer, toolStripSeparator2, generalServerSettingsToolStripMenuItem, userSettingsToolStripMenuItem, toolStripSeparator4, btnVerifyIsleServer, btnServerStatsRefresh });
            toolStripDropDownButton3.Image = (Image)resources.GetObject("toolStripDropDownButton3.Image");
            toolStripDropDownButton3.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            toolStripDropDownButton3.Size = new Size(52, 22);
            toolStripDropDownButton3.Text = "Server";
            // 
            // btnStartIsleServer
            // 
            btnStartIsleServer.Name = "btnStartIsleServer";
            btnStartIsleServer.Size = new Size(248, 22);
            btnStartIsleServer.Text = "Start";
            btnStartIsleServer.Click += btnStartIsleServer_Click;
            // 
            // btnStopIsleServer
            // 
            btnStopIsleServer.Name = "btnStopIsleServer";
            btnStopIsleServer.Size = new Size(248, 22);
            btnStopIsleServer.Text = "Stop (Gradefully)";
            btnStopIsleServer.Click += btnStopIsleServer_Click;
            // 
            // btnForceStopIsleServer
            // 
            btnForceStopIsleServer.Name = "btnForceStopIsleServer";
            btnForceStopIsleServer.Size = new Size(248, 22);
            btnForceStopIsleServer.Text = "Force Stop (NOT Recommended)";
            btnForceStopIsleServer.Click += btnForceStopIsleServer_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(245, 6);
            // 
            // generalServerSettingsToolStripMenuItem
            // 
            generalServerSettingsToolStripMenuItem.Name = "generalServerSettingsToolStripMenuItem";
            generalServerSettingsToolStripMenuItem.Size = new Size(248, 22);
            generalServerSettingsToolStripMenuItem.Text = "General Server Settings";
            generalServerSettingsToolStripMenuItem.Click += generalServerSettingsToolStripMenuItem_Click;
            // 
            // userSettingsToolStripMenuItem
            // 
            userSettingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { adminsToolStripMenuItem, vIPsToolStripMenuItem, whitelistToolStripMenuItem });
            userSettingsToolStripMenuItem.Name = "userSettingsToolStripMenuItem";
            userSettingsToolStripMenuItem.Size = new Size(248, 22);
            userSettingsToolStripMenuItem.Text = "User Settings";
            // 
            // adminsToolStripMenuItem
            // 
            adminsToolStripMenuItem.Name = "adminsToolStripMenuItem";
            adminsToolStripMenuItem.Size = new Size(180, 22);
            adminsToolStripMenuItem.Text = "Admins";
            adminsToolStripMenuItem.Click += adminsToolStripMenuItem_Click;
            // 
            // vIPsToolStripMenuItem
            // 
            vIPsToolStripMenuItem.Name = "vIPsToolStripMenuItem";
            vIPsToolStripMenuItem.Size = new Size(180, 22);
            vIPsToolStripMenuItem.Text = "VIPs";
            vIPsToolStripMenuItem.Click += vIPsToolStripMenuItem_Click;
            // 
            // whitelistToolStripMenuItem
            // 
            whitelistToolStripMenuItem.Name = "whitelistToolStripMenuItem";
            whitelistToolStripMenuItem.Size = new Size(180, 22);
            whitelistToolStripMenuItem.Text = "Whitelist";
            whitelistToolStripMenuItem.Click += whitelistToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(245, 6);
            // 
            // btnVerifyIsleServer
            // 
            btnVerifyIsleServer.Name = "btnVerifyIsleServer";
            btnVerifyIsleServer.Size = new Size(248, 22);
            btnVerifyIsleServer.Text = "Verify (will stop if running)";
            btnVerifyIsleServer.Click += btnVerifyIsleServer_Click;
            // 
            // btnServerStatsRefresh
            // 
            btnServerStatsRefresh.Checked = true;
            btnServerStatsRefresh.CheckState = CheckState.Checked;
            btnServerStatsRefresh.Name = "btnServerStatsRefresh";
            btnServerStatsRefresh.Size = new Size(248, 22);
            btnServerStatsRefresh.Text = "Refresh Stats Data";
            btnServerStatsRefresh.Click += btnServerStatsRefresh_Click;
            // 
            // toolStripDropDownButton5
            // 
            toolStripDropDownButton5.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton5.DropDownItems.AddRange(new ToolStripItem[] { configureRCONConnectionToolStripMenuItem, configureRCONTasksToolStripMenuItem });
            toolStripDropDownButton5.Image = (Image)resources.GetObject("toolStripDropDownButton5.Image");
            toolStripDropDownButton5.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton5.Name = "toolStripDropDownButton5";
            toolStripDropDownButton5.Size = new Size(53, 22);
            toolStripDropDownButton5.Text = "RCON";
            // 
            // configureRCONConnectionToolStripMenuItem
            // 
            configureRCONConnectionToolStripMenuItem.Name = "configureRCONConnectionToolStripMenuItem";
            configureRCONConnectionToolStripMenuItem.Size = new Size(228, 22);
            configureRCONConnectionToolStripMenuItem.Text = "Configure RCON Connection";
            configureRCONConnectionToolStripMenuItem.Click += configureRCONConnectionToolStripMenuItem_Click;
            // 
            // configureRCONTasksToolStripMenuItem
            // 
            configureRCONTasksToolStripMenuItem.Name = "configureRCONTasksToolStripMenuItem";
            configureRCONTasksToolStripMenuItem.Size = new Size(228, 22);
            configureRCONTasksToolStripMenuItem.Text = "Configure RCON Tasks";
            configureRCONTasksToolStripMenuItem.Click += configureRCONTasksToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // toolStripDropDownButton4
            // 
            toolStripDropDownButton4.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton4.DropDownItems.AddRange(new ToolStripItem[] { troubleshootingIssuesToolStripMenuItem, aboutToolStripMenuItem });
            toolStripDropDownButton4.Image = (Image)resources.GetObject("toolStripDropDownButton4.Image");
            toolStripDropDownButton4.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            toolStripDropDownButton4.Size = new Size(45, 22);
            toolStripDropDownButton4.Text = "Help";
            // 
            // troubleshootingIssuesToolStripMenuItem
            // 
            troubleshootingIssuesToolStripMenuItem.Name = "troubleshootingIssuesToolStripMenuItem";
            troubleshootingIssuesToolStripMenuItem.Size = new Size(194, 22);
            troubleshootingIssuesToolStripMenuItem.Text = "Troubleshooting Issues";
            troubleshootingIssuesToolStripMenuItem.Click += troubleshootingIssuesToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(194, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // btnPendingSettingsChange
            // 
            btnPendingSettingsChange.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnPendingSettingsChange.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPendingSettingsChange.ForeColor = Color.Teal;
            btnPendingSettingsChange.Image = (Image)resources.GetObject("btnPendingSettingsChange.Image");
            btnPendingSettingsChange.ImageTransparentColor = Color.Magenta;
            btnPendingSettingsChange.Name = "btnPendingSettingsChange";
            btnPendingSettingsChange.Size = new Size(309, 22);
            btnPendingSettingsChange.Text = "Game Server Running - Click to shutdown and update";
            btnPendingSettingsChange.Click += toolStripButton1_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lblWhitelistCount);
            groupBox4.Controls.Add(lblVIPCount);
            groupBox4.Controls.Add(lblAdminCount);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(lblPlayerDataCount);
            groupBox4.Controls.Add(label6);
            groupBox4.Location = new Point(277, 41);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(251, 149);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Server Info";
            // 
            // lblWhitelistCount
            // 
            lblWhitelistCount.AutoSize = true;
            lblWhitelistCount.Location = new Point(88, 82);
            lblWhitelistCount.Name = "lblWhitelistCount";
            lblWhitelistCount.Size = new Size(13, 15);
            lblWhitelistCount.TabIndex = 7;
            lblWhitelistCount.Text = "0";
            // 
            // lblVIPCount
            // 
            lblVIPCount.AutoSize = true;
            lblVIPCount.Location = new Point(59, 60);
            lblVIPCount.Name = "lblVIPCount";
            lblVIPCount.Size = new Size(13, 15);
            lblVIPCount.TabIndex = 6;
            lblVIPCount.Text = "0";
            // 
            // lblAdminCount
            // 
            lblAdminCount.AutoSize = true;
            lblAdminCount.Location = new Point(78, 39);
            lblAdminCount.Name = "lblAdminCount";
            lblAdminCount.Size = new Size(13, 15);
            lblAdminCount.TabIndex = 5;
            lblAdminCount.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 82);
            label9.Name = "label9";
            label9.Size = new Size(85, 15);
            label9.TabIndex = 4;
            label9.Text = "# of Whitelists:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 60);
            label8.Name = "label8";
            label8.Size = new Size(56, 15);
            label8.TabIndex = 3;
            label8.Text = "# of VIPs:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 39);
            label7.Name = "label7";
            label7.Size = new Size(75, 15);
            label7.TabIndex = 2;
            label7.Text = "# of Admins:";
            // 
            // lblPlayerDataCount
            // 
            lblPlayerDataCount.AutoSize = true;
            lblPlayerDataCount.Location = new Point(170, 19);
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
            label6.Size = new Size(169, 15);
            label6.TabIndex = 0;
            label6.Text = "Total Saved Player Data Entries:";
            // 
            // btnStartServerUI
            // 
            btnStartServerUI.Location = new Point(534, 52);
            btnStartServerUI.Name = "btnStartServerUI";
            btnStartServerUI.Size = new Size(254, 53);
            btnStartServerUI.TabIndex = 6;
            btnStartServerUI.Text = "Start\r\n(Prompts for setup if needed)";
            btnStartServerUI.UseVisualStyleBackColor = true;
            btnStartServerUI.Click += btnStartServerUI_Click;
            // 
            // btnUIStopServerGraceful
            // 
            btnUIStopServerGraceful.Location = new Point(534, 111);
            btnUIStopServerGraceful.Name = "btnUIStopServerGraceful";
            btnUIStopServerGraceful.Size = new Size(254, 52);
            btnUIStopServerGraceful.TabIndex = 7;
            btnUIStopServerGraceful.Text = "Stop Grafeully";
            btnUIStopServerGraceful.UseVisualStyleBackColor = true;
            btnUIStopServerGraceful.Click += btnUIStopServerGraceful_Click;
            // 
            // btnForceStopUI
            // 
            btnForceStopUI.Location = new Point(534, 167);
            btnForceStopUI.Name = "btnForceStopUI";
            btnForceStopUI.Size = new Size(254, 23);
            btnForceStopUI.TabIndex = 8;
            btnForceStopUI.Text = "Force Exit (NOT Recommended)";
            btnForceStopUI.UseVisualStyleBackColor = true;
            btnForceStopUI.Click += btnForceStopUI_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(247, 6);
            // 
            // checkForManagerUpdateToolStripMenuItem
            // 
            checkForManagerUpdateToolStripMenuItem.Name = "checkForManagerUpdateToolStripMenuItem";
            checkForManagerUpdateToolStripMenuItem.Size = new Size(250, 22);
            checkForManagerUpdateToolStripMenuItem.Text = "Check for Manager Update";
            checkForManagerUpdateToolStripMenuItem.Click += checkForManagerUpdateToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 486);
            Controls.Add(btnForceStopUI);
            Controls.Add(btnUIStopServerGraceful);
            Controls.Add(btnStartServerUI);
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
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem btnChangeProcPrior;
        private ToolStripStatusLabel lblIsAdmin;
        private ToolStripDropDownButton toolStripDropDownButton5;
        private ToolStripMenuItem configureRCONConnectionToolStripMenuItem;
        private ToolStripMenuItem configureRCONTasksToolStripMenuItem;
        private ToolStripMenuItem autoCopyRequiredDLLsToolStripMenuItem;
        private ToolStripMenuItem changeServerDirectoryLocationToolStripMenuItem;
        private Button btnStartServerUI;
        private Button btnUIStopServerGraceful;
        private Button btnForceStopUI;
        private ToolStripMenuItem btnForceStopIsleServer;
        private ToolStripMenuItem generalServerSettingsToolStripMenuItem;
        private ToolStripMenuItem userSettingsToolStripMenuItem;
        private ToolStripMenuItem adminsToolStripMenuItem;
        private ToolStripMenuItem vIPsToolStripMenuItem;
        private ToolStripMenuItem whitelistToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private Label lblWhitelistCount;
        private Label lblVIPCount;
        private Label lblAdminCount;
        private Label label9;
        private Label label8;
        private Label label7;
        private ToolStripButton btnPendingSettingsChange;
        private ToolStripMenuItem troubleshootingIssuesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem checkForManagerUpdateToolStripMenuItem;
    }
}
