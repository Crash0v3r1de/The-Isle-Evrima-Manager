using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_Isle_Evrima_Manager.JSON.RCON_Task;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

namespace The_Isle_Evrima_Manager.Forms
{
    public partial class frmRCONTasks : Form
    {
        private int currentTask = 0;
        public frmRCONTasks()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Once public, will load wiki RCON task page
        }

        private void exitAndDiscardChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void frmRCONTasks_Load(object sender, EventArgs e)
        {
            if (RCONGlobalTasks.rconTasks.Count > 0)
            {
                // Iterate through list logically, easier to select list after
                for (int x = 0; x < RCONGlobalTasks.rconTasks.Count; x++)
                {
                    var tskName = RCONGlobalTasks.rconTasks[x].TaskName;
                    var tskCmd = RCONGlobalTasks.rconTasks[x].TaskCommand;
                    var tskEnabled = RCONGlobalTasks.rconTasks[x].TaskEnabled;
                    lstTasks.Items.Add($"Name: {tskName} | Command: {tskCmd} | Enabled: {tskEnabled}");
                }
            }

        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (currentTask > 0)
            {
                // We're modifying an existing task
                UpdateTask();
            }
            else {
                // We're adding a new task
                AddNewTask();
            }
            // Eventually can use a DateTime picker but this is quick and dirty for now
            // Time wil be ignored if Hourly is selected
            //Mightnight - 0
            //1am - 1
            //2am - 2
            //3am - 3
            //4am - 4
            //5am - 5
            //6am - 6
            //7am - 7
            //8am - 8
            // How Often
            //Daily - 0
            //Weekly - 1
            //Monthly - 2
            //Hourly - 3
        }

        private void txtHowOften_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Daily - 0
            //Weekly - 1
            //Monthly - 2
            //Hourly - 3
            if (txtHowOften.SelectedIndex == 3)
            {
                txtExecTime.Enabled = false;
            }
            else
            {
                if (!txtExecTime.Enabled) txtExecTime.Enabled = true; // re enable if Hourly was ever selected before
            }
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.Items.Count > 0) {
                currentTask = lstTasks.SelectedIndex;
                txtTaskName.Text = RCONGlobalTasks.rconTasks[currentTask].TaskName;
                ParseHowOften(currentTask);
                ParseTime(currentTask);
                chkEnableTask.Checked = RCONGlobalTasks.rconTasks[currentTask].TaskEnabled;
            }            
        }


        #region Private methods
        private void ParseHowOften(int taskNum) {
            // TODO: Make this a switch
            //Daily - 0
            //Weekly - 1
            //Monthly - 2
            //Hourly - 3
            if (RCONGlobalTasks.rconTasks[taskNum].TaskMonthly) { 
                txtHowOften.SelectedIndex = 2;
            }
            if (RCONGlobalTasks.rconTasks[taskNum].TaskHourly)
            {
                txtHowOften.SelectedIndex = 3;
            }
            if (RCONGlobalTasks.rconTasks[taskNum].TaskWeekly)
            {
                txtHowOften.SelectedIndex = 1;
            }
            if (RCONGlobalTasks.rconTasks[taskNum].TaskDaily)
            {
                txtHowOften.SelectedIndex = 0;
            }
        }
        private void ParseTime(int taskNum) {
            DateTime time = RCONGlobalTasks.rconTasks[taskNum].TaskRunTime;
            //Mightnight - 0
            //1am - 1
            //2am - 2
            //3am - 3
            //4am - 4
            //5am - 5
            //6am - 6
            //7am - 7
            //8am - 8
            switch (time.Hour) {
                case 0: // Midnight
                    txtExecTime.SelectedIndex = 0;
                    break;
                case 1: // 1am 
                    txtExecTime.SelectedIndex = 1;
                    break;
                case 2: // 2am
                    txtExecTime.SelectedIndex = 2;
                    break;
                case 3: // 3am
                    txtExecTime.SelectedIndex = 3;
                    break;
                case 4: // 4am
                    txtExecTime.SelectedIndex = 4;
                    break;
                case 5: // 5am
                    txtExecTime.SelectedIndex = 5;
                    break;
                case 6: // 6am
                    txtExecTime.SelectedIndex = 6;
                    break;
                case 7: // 7am
                    txtExecTime.SelectedIndex = 7;
                    break;
                case 8: // 8am
                    txtExecTime.SelectedIndex = 8;
                    break;
            }
        }
        private void UpdateTask() { 
            RCONGlobalTasks.rconTasks[currentTask].TaskName = txtTaskName.Text;
            RCONGlobalTasks.rconTasks[currentTask].TaskEnabled = chkEnableTask.Checked;
            RCONGlobalTasks.rconTasks[currentTask].TaskCommand = txtTaskCommand.Text;
            if (txtHowOften.SelectedIndex == 2)RCONGlobalTasks.rconTasks[currentTask].TaskMonthly = true;
            if(txtHowOften.SelectedIndex == 0)RCONGlobalTasks.rconTasks[currentTask].TaskDaily = true;
            if(txtHowOften.SelectedIndex == 1)RCONGlobalTasks.rconTasks[currentTask].TaskWeekly = true;
            if(txtHowOften.SelectedIndex == 3)RCONGlobalTasks.rconTasks[currentTask].TaskHourly = true;
            switch (txtExecTime.SelectedIndex) { 
                case 0: // Midnight
                    RCONGlobalTasks.rconTasks[currentTask].TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    break;
                case 1: // 1am
                    RCONGlobalTasks.rconTasks[currentTask].TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 1, 0, 0);
                    break;
                case 2: // 2am
                    RCONGlobalTasks.rconTasks[currentTask].TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 2, 0, 0);
                    break;
                case 3: // 3am
                    RCONGlobalTasks.rconTasks[currentTask].TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 3, 0, 0);
                    break;
                case 4: // 4am
                    RCONGlobalTasks.rconTasks[currentTask].TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 4, 0, 0);
                    break;
                case 5: // 5am
                    RCONGlobalTasks.rconTasks[currentTask].TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 5, 0, 0);
                    break;
                case 6: // 6am
                    RCONGlobalTasks.rconTasks[currentTask].TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 0, 0);
                    break;
                case 7: // 7am
                    RCONGlobalTasks.rconTasks[currentTask].TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
                    break;
                case 8: // 8am
                    RCONGlobalTasks.rconTasks[currentTask].TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                    break;
            }
            ClearForNewTask();
        }
        private void ClearForNewTask() {
            currentTask = 0;
            txtTaskName.Text = "";
            txtHowOften.SelectedIndex = 0;
            txtExecTime.SelectedIndex = 0;
            chkEnableTask.Checked = true;
        }
        private void UpdateTaskList()
        {
            lstTasks.Items.Clear();
            for (int x = 0; x < RCONGlobalTasks.rconTasks.Count; x++)
            {
                var tskName = RCONGlobalTasks.rconTasks[x].TaskName;
                var tskCmd = RCONGlobalTasks.rconTasks[x].TaskCommand;
                var tskEnabled = RCONGlobalTasks.rconTasks[x].TaskEnabled;
                lstTasks.Items.Add($"Name: {tskName} | Command: {tskCmd} | Enabled: {tskEnabled}");
            }
        }
        private void AddNewTask() { 
            RCONTaskItem task = new RCONTaskItem();
            task.TaskName = txtTaskName.Text;
            task.TaskEnabled = chkEnableTask.Checked;
            task.TaskCommand = txtTaskCommand.Text;
            if (txtHowOften.SelectedIndex == 2) task.TaskMonthly = true;
            if (txtHowOften.SelectedIndex == 0) task.TaskDaily = true;
            if (txtHowOften.SelectedIndex == 1) task.TaskWeekly = true;
            if (txtHowOften.SelectedIndex == 3) task.TaskHourly = true;
            switch (txtExecTime.SelectedIndex)
            {
                case 0: // Midnight
                    task.TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    break;
                case 1: // 1am
                    task.TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 1, 0, 0);
                    break;
                case 2: // 2am
                    task.TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 2, 0, 0);
                    break;
                case 3: // 3am
                    task.TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 3, 0, 0);
                    break;
                case 4: // 4am
                    task.TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 4, 0, 0);
                    break;
                case 5: // 5am
                    task.TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 5, 0, 0);
                    break;
                case 6: // 6am
                    task.TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 0, 0);
                    break;
                case 7: // 7am
                    task.TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
                    break;
                case 8: // 8am
                    task.TaskRunTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                    break;
            }
            RCONGlobalTasks.rconTasks.Add(task);
            UpdateTaskList();
            ClearForNewTask();
        }
        #endregion
    }
}
