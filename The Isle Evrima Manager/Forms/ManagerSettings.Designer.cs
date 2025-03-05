namespace The_Isle_Evrima_Manager.Forms
{
    partial class ManagerSettings
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
            txtServerStatRefreshInt = new TextBox();
            label2 = new Label();
            txtHardwareRefreshInt = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            chkForUpdates = new CheckBox();
            chkServerMonitoring = new CheckBox();
            chkCPURAM = new CheckBox();
            groupBox3 = new GroupBox();
            btnConsoleLogAlertSetup = new Button();
            chkDiscordLogAlerts = new CheckBox();
            chkDiscordNotifyFails = new CheckBox();
            chkRestartServerOnFail = new CheckBox();
            groupBox4 = new GroupBox();
            txtDiscordWebhoolURL = new TextBox();
            label3 = new Label();
            chkDiscordNotifications = new CheckBox();
            btnSave = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtServerStatRefreshInt);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtHardwareRefreshInt);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(555, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(253, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Counters - In Seconds";
            // 
            // txtServerStatRefreshInt
            // 
            txtServerStatRefreshInt.Location = new Point(119, 47);
            txtServerStatRefreshInt.Name = "txtServerStatRefreshInt";
            txtServerStatRefreshInt.Size = new Size(100, 23);
            txtServerStatRefreshInt.TabIndex = 1;
            txtServerStatRefreshInt.TextChanged += txtServerStatRefreshInt_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 55);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 2;
            label2.Text = "Server Stat Refresh:";
            // 
            // txtHardwareRefreshInt
            // 
            txtHardwareRefreshInt.Location = new Point(138, 16);
            txtHardwareRefreshInt.Name = "txtHardwareRefreshInt";
            txtHardwareRefreshInt.Size = new Size(81, 23);
            txtHardwareRefreshInt.TabIndex = 1;
            txtHardwareRefreshInt.TextChanged += txtHardwareRefreshInt_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 0;
            label1.Text = "Hardware Stat Refresh:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkForUpdates);
            groupBox2.Controls.Add(chkServerMonitoring);
            groupBox2.Controls.Add(chkCPURAM);
            groupBox2.Location = new Point(18, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(247, 118);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "General Monitors";
            // 
            // chkForUpdates
            // 
            chkForUpdates.AutoSize = true;
            chkForUpdates.Location = new Point(6, 72);
            chkForUpdates.Name = "chkForUpdates";
            chkForUpdates.Size = new Size(173, 19);
            chkForUpdates.TabIndex = 4;
            chkForUpdates.Text = "Check for Manager Updates";
            chkForUpdates.UseVisualStyleBackColor = true;
            // 
            // chkServerMonitoring
            // 
            chkServerMonitoring.AutoSize = true;
            chkServerMonitoring.Location = new Point(6, 47);
            chkServerMonitoring.Name = "chkServerMonitoring";
            chkServerMonitoring.Size = new Size(190, 19);
            chkServerMonitoring.TabIndex = 3;
            chkServerMonitoring.Text = "Server CPU and Memory Usage";
            chkServerMonitoring.UseVisualStyleBackColor = true;
            // 
            // chkCPURAM
            // 
            chkCPURAM.AutoSize = true;
            chkCPURAM.Location = new Point(6, 22);
            chkCPURAM.Name = "chkCPURAM";
            chkCPURAM.Size = new Size(175, 19);
            chkCPURAM.TabIndex = 2;
            chkCPURAM.Text = "System CPU/Memory Usage";
            chkCPURAM.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnConsoleLogAlertSetup);
            groupBox3.Controls.Add(chkDiscordLogAlerts);
            groupBox3.Controls.Add(chkDiscordNotifyFails);
            groupBox3.Controls.Add(chkRestartServerOnFail);
            groupBox3.Location = new Point(271, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(278, 118);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Game Server Proccess Handling";
            // 
            // btnConsoleLogAlertSetup
            // 
            btnConsoleLogAlertSetup.Enabled = false;
            btnConsoleLogAlertSetup.Location = new Point(6, 89);
            btnConsoleLogAlertSetup.Name = "btnConsoleLogAlertSetup";
            btnConsoleLogAlertSetup.Size = new Size(229, 23);
            btnConsoleLogAlertSetup.TabIndex = 3;
            btnConsoleLogAlertSetup.Text = "Console Log Alert Settings";
            btnConsoleLogAlertSetup.UseVisualStyleBackColor = true;
            // 
            // chkDiscordLogAlerts
            // 
            chkDiscordLogAlerts.AutoSize = true;
            chkDiscordLogAlerts.Enabled = false;
            chkDiscordLogAlerts.Location = new Point(6, 72);
            chkDiscordLogAlerts.Name = "chkDiscordLogAlerts";
            chkDiscordLogAlerts.Size = new Size(233, 19);
            chkDiscordLogAlerts.TabIndex = 2;
            chkDiscordLogAlerts.Text = "Discord Notification on monitored logs";
            chkDiscordLogAlerts.UseVisualStyleBackColor = true;
            // 
            // chkDiscordNotifyFails
            // 
            chkDiscordNotifyFails.AutoSize = true;
            chkDiscordNotifyFails.Location = new Point(6, 47);
            chkDiscordNotifyFails.Name = "chkDiscordNotifyFails";
            chkDiscordNotifyFails.Size = new Size(187, 19);
            chkDiscordNotifyFails.TabIndex = 1;
            chkDiscordNotifyFails.Text = "Discord Notification on Failure";
            chkDiscordNotifyFails.UseVisualStyleBackColor = true;
            // 
            // chkRestartServerOnFail
            // 
            chkRestartServerOnFail.AutoSize = true;
            chkRestartServerOnFail.Location = new Point(6, 22);
            chkRestartServerOnFail.Name = "chkRestartServerOnFail";
            chkRestartServerOnFail.Size = new Size(229, 19);
            chkRestartServerOnFail.TabIndex = 0;
            chkRestartServerOnFail.Text = "Restart Server if Crashed/Failed/Halted";
            chkRestartServerOnFail.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtDiscordWebhoolURL);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(chkDiscordNotifications);
            groupBox4.Location = new Point(18, 136);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(790, 130);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Discord Settings";
            // 
            // txtDiscordWebhoolURL
            // 
            txtDiscordWebhoolURL.Location = new Point(6, 58);
            txtDiscordWebhoolURL.Name = "txtDiscordWebhoolURL";
            txtDiscordWebhoolURL.Size = new Size(687, 23);
            txtDiscordWebhoolURL.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 40);
            label3.Name = "label3";
            label3.Size = new Size(125, 15);
            label3.TabIndex = 1;
            label3.Text = "Discord Webhook URL";
            // 
            // chkDiscordNotifications
            // 
            chkDiscordNotifications.AutoSize = true;
            chkDiscordNotifications.Location = new Point(6, 18);
            chkDiscordNotifications.Name = "chkDiscordNotifications";
            chkDiscordNotifications.Size = new Size(228, 19);
            chkDiscordNotifications.TabIndex = 0;
            chkDiscordNotifications.Text = "Globally Enabled Discord Notifications";
            chkDiscordNotifications.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(18, 272);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(790, 23);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save and Close";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ManagerSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 304);
            Controls.Add(btnSave);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "ManagerSettings";
            Text = "Manager Settings";
            Load += ManagerSettings_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private TextBox txtHardwareRefreshInt;
        private Label label1;
        private TextBox txtServerStatRefreshInt;
        private GroupBox groupBox2;
        private CheckBox chkServerMonitoring;
        private CheckBox chkCPURAM;
        private GroupBox groupBox3;
        private CheckBox chkRestartServerOnFail;
        private CheckBox chkDiscordNotifyFails;
        private CheckBox chkForUpdates;
        private GroupBox groupBox4;
        private TextBox txtDiscordWebhoolURL;
        private Label label3;
        private CheckBox chkDiscordNotifications;
        private Button btnSave;
        private Button btnConsoleLogAlertSetup;
        private CheckBox chkDiscordLogAlerts;
    }
}