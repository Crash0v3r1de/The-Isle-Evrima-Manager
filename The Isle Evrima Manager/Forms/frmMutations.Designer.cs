namespace The_Isle_Evrima_Manager.Forms
{
    partial class frmMutations
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
            btnAddMutation = new Button();
            txtMutationEffectiveValue = new NumericUpDown();
            label2 = new Label();
            txtMutationName = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            button2 = new Button();
            button1 = new Button();
            lstMutations = new ListBox();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtMutationEffectiveValue).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { closeToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(507, 24);
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
            groupBox1.Controls.Add(btnAddMutation);
            groupBox1.Controls.Add(txtMutationEffectiveValue);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtMutationName);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(392, 107);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add Mutation";
            // 
            // btnAddMutation
            // 
            btnAddMutation.Location = new Point(196, 72);
            btnAddMutation.Name = "btnAddMutation";
            btnAddMutation.Size = new Size(189, 23);
            btnAddMutation.TabIndex = 4;
            btnAddMutation.Text = "Add";
            btnAddMutation.UseVisualStyleBackColor = true;
            btnAddMutation.Click += btnAddMutation_Click;
            // 
            // txtMutationEffectiveValue
            // 
            txtMutationEffectiveValue.DecimalPlaces = 2;
            txtMutationEffectiveValue.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            txtMutationEffectiveValue.Location = new Point(95, 70);
            txtMutationEffectiveValue.Name = "txtMutationEffectiveValue";
            txtMutationEffectiveValue.Size = new Size(83, 23);
            txtMutationEffectiveValue.TabIndex = 3;
            txtMutationEffectiveValue.Value = new decimal(new int[] { 100, 0, 0, 131072 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 72);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 2;
            label2.Text = "Effective Value";
            // 
            // txtMutationName
            // 
            txtMutationName.Location = new Point(51, 29);
            txtMutationName.Name = "txtMutationName";
            txtMutationName.Size = new Size(334, 23);
            txtMutationName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 32);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(lstMutations);
            groupBox2.Location = new Point(12, 140);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(485, 298);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Current Mutations";
            // 
            // button2
            // 
            button2.Location = new Point(243, 269);
            button2.Name = "button2";
            button2.Size = new Size(110, 23);
            button2.TabIndex = 2;
            button2.Text = "Remove Selected";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(116, 269);
            button1.Name = "button1";
            button1.Size = new Size(121, 23);
            button1.TabIndex = 1;
            button1.Text = "Edit Selected";
            button1.UseVisualStyleBackColor = true;
            // 
            // lstMutations
            // 
            lstMutations.FormattingEnabled = true;
            lstMutations.ItemHeight = 15;
            lstMutations.Location = new Point(6, 22);
            lstMutations.Name = "lstMutations";
            lstMutations.Size = new Size(473, 244);
            lstMutations.TabIndex = 0;
            // 
            // frmMutations
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmMutations";
            Text = "Server Mutations";
            Load += frmMutations_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtMutationEffectiveValue).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem closeToolStripMenuItem;
        private GroupBox groupBox1;
        private Button btnAddMutation;
        private NumericUpDown txtMutationEffectiveValue;
        private Label label2;
        private TextBox txtMutationName;
        private Label label1;
        private GroupBox groupBox2;
        private ToolStripMenuItem toolStripMenuItem1;
        private Button button2;
        private Button button1;
        private ListBox lstMutations;
    }
}