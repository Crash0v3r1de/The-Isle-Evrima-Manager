namespace The_Isle_Evrima_Manager.Forms
{
    partial class frmRCONTasks
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
            exitAndDiscardChangesToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            lstTasks = new ListBox();
            btnEditTask = new Button();
            btnDisableTask = new Button();
            btnEnableTask = new Button();
            groupBox2 = new GroupBox();
            txtTaskCommand = new TextBox();
            label5 = new Label();
            chkEnableTask = new CheckBox();
            txtHowOften = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            btnAddTask = new Button();
            txtExecTime = new ComboBox();
            label2 = new Label();
            txtTaskName = new TextBox();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { saveAndCloseToolStripMenuItem, exitAndDiscardChangesToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(519, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // saveAndCloseToolStripMenuItem
            // 
            saveAndCloseToolStripMenuItem.Name = "saveAndCloseToolStripMenuItem";
            saveAndCloseToolStripMenuItem.Size = new Size(98, 20);
            saveAndCloseToolStripMenuItem.Text = "Save and Close";
            // 
            // exitAndDiscardChangesToolStripMenuItem
            // 
            exitAndDiscardChangesToolStripMenuItem.Name = "exitAndDiscardChangesToolStripMenuItem";
            exitAndDiscardChangesToolStripMenuItem.Size = new Size(152, 20);
            exitAndDiscardChangesToolStripMenuItem.Text = "Exit and Discard Changes";
            exitAndDiscardChangesToolStripMenuItem.Click += exitAndDiscardChangesToolStripMenuItem_Click;
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
            groupBox1.Controls.Add(lstTasks);
            groupBox1.Controls.Add(btnEditTask);
            groupBox1.Controls.Add(btnDisableTask);
            groupBox1.Controls.Add(btnEnableTask);
            groupBox1.Location = new Point(12, 237);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(462, 233);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Current Tasks";
            // 
            // lstTasks
            // 
            lstTasks.FormattingEnabled = true;
            lstTasks.ItemHeight = 15;
            lstTasks.Location = new Point(6, 22);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(450, 169);
            lstTasks.TabIndex = 4;
            // 
            // btnEditTask
            // 
            btnEditTask.Location = new Point(296, 199);
            btnEditTask.Name = "btnEditTask";
            btnEditTask.Size = new Size(114, 23);
            btnEditTask.TabIndex = 4;
            btnEditTask.Text = "Edit Selected";
            btnEditTask.UseVisualStyleBackColor = true;
            btnEditTask.Click += btnEditTask_Click;
            // 
            // btnDisableTask
            // 
            btnDisableTask.Location = new Point(169, 199);
            btnDisableTask.Name = "btnDisableTask";
            btnDisableTask.Size = new Size(121, 23);
            btnDisableTask.TabIndex = 3;
            btnDisableTask.Text = "Disable Selected";
            btnDisableTask.UseVisualStyleBackColor = true;
            // 
            // btnEnableTask
            // 
            btnEnableTask.Location = new Point(48, 199);
            btnEnableTask.Name = "btnEnableTask";
            btnEnableTask.Size = new Size(115, 23);
            btnEnableTask.TabIndex = 2;
            btnEnableTask.Text = "Enable Selected";
            btnEnableTask.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtTaskCommand);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(chkEnableTask);
            groupBox2.Controls.Add(txtHowOften);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(btnAddTask);
            groupBox2.Controls.Add(txtExecTime);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtTaskName);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(12, 27);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(419, 204);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "New Task";
            // 
            // txtTaskCommand
            // 
            txtTaskCommand.Location = new Point(6, 130);
            txtTaskCommand.Name = "txtTaskCommand";
            txtTaskCommand.Size = new Size(398, 23);
            txtTaskCommand.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 112);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 9;
            label5.Text = "Command";
            // 
            // chkEnableTask
            // 
            chkEnableTask.AutoSize = true;
            chkEnableTask.Checked = true;
            chkEnableTask.CheckState = CheckState.Checked;
            chkEnableTask.Location = new Point(12, 163);
            chkEnableTask.Name = "chkEnableTask";
            chkEnableTask.Size = new Size(86, 19);
            chkEnableTask.TabIndex = 8;
            chkEnableTask.Text = "Enable Task";
            chkEnableTask.UseVisualStyleBackColor = true;
            // 
            // txtHowOften
            // 
            txtHowOften.FormattingEnabled = true;
            txtHowOften.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly", "Hourly" });
            txtHowOften.Location = new Point(77, 83);
            txtHowOften.Name = "txtHowOften";
            txtHowOften.Size = new Size(131, 23);
            txtHowOften.TabIndex = 7;
            txtHowOften.SelectedIndexChanged += txtHowOften_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(214, 86);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 6;
            label4.Text = "What Time";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 86);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 5;
            label3.Text = "How Often";
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(104, 163);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(295, 23);
            btnAddTask.TabIndex = 4;
            btnAddTask.Text = "Add/Update Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // txtExecTime
            // 
            txtExecTime.FormattingEnabled = true;
            txtExecTime.Items.AddRange(new object[] { "Mightnight", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am" });
            txtExecTime.Location = new Point(284, 83);
            txtExecTime.Name = "txtExecTime";
            txtExecTime.Size = new Size(120, 23);
            txtExecTime.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 63);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 2;
            label2.Text = "When to Execute";
            // 
            // txtTaskName
            // 
            txtTaskName.Location = new Point(6, 37);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(323, 23);
            txtTaskName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "Task Name";
            // 
            // frmRCONTasks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 482);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmRCONTasks";
            Text = "RCON Schedules Tasks";
            Load += frmRCONTasks_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem saveAndCloseToolStripMenuItem;
        private ToolStripMenuItem exitAndDiscardChangesToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label2;
        private TextBox txtTaskName;
        private Label label1;
        private ComboBox txtExecTime;
        private Button btnAddTask;
        private ComboBox txtHowOften;
        private Label label4;
        private Label label3;
        private CheckBox chkEnableTask;
        private Button btnEditTask;
        private Button btnDisableTask;
        private Button btnEnableTask;
        private ListBox lstTasks;
        private TextBox txtTaskCommand;
        private Label label5;
    }
}