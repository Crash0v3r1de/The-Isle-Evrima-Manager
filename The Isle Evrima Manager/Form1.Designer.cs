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
            stsStripMain = new StatusStrip();
            lblServerStatus = new ToolStripStatusLabel();
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
            richTextBox1 = new RichTextBox();
            stsStripMain.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // stsStripMain
            // 
            stsStripMain.Items.AddRange(new ToolStripItem[] { lblServerStatus });
            stsStripMain.Location = new Point(0, 428);
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
            // groupBox1
            // 
            groupBox1.Controls.Add(lblSteamClient);
            groupBox1.Controls.Add(lblcplusplus);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 64);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "System Checks";
            // 
            // lblSteamClient
            // 
            lblSteamClient.AutoSize = true;
            lblSteamClient.Location = new Point(89, 39);
            lblSteamClient.Name = "lblSteamClient";
            lblSteamClient.Size = new Size(38, 15);
            lblSteamClient.TabIndex = 2;
            lblSteamClient.Text = "label3";
            // 
            // lblcplusplus
            // 
            lblcplusplus.AutoSize = true;
            lblcplusplus.Location = new Point(92, 19);
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
            label2.Size = new Size(77, 15);
            label2.TabIndex = 2;
            label2.Text = "Steam Client:";
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
            groupBox2.Location = new Point(12, 82);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 79);
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
            groupBox3.Controls.Add(richTextBox1);
            groupBox3.Location = new Point(12, 167);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(776, 258);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Server Console";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(6, 22);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(764, 230);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(stsStripMain);
            Name = "Form1";
            Text = "The Isle Evirma Manager";
            Load += Form1_Load;
            stsStripMain.ResumeLayout(false);
            stsStripMain.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
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
        private RichTextBox richTextBox1;
    }
}
