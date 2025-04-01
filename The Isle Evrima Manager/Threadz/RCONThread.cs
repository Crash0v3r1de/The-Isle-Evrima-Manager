using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.IO;
using The_Isle_Evrima_Manager.JSON.RCON_Task;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;
using The_Isle_Evrima_Manager.Tools;
using TheIsleEvrimaRconClient;

namespace The_Isle_Evrima_Manager.Threadz
{
    public static class RCONThread
    {
        public static bool RCONSchedulerRunning = false;
        private static List<RCONTaskItemJSON> completedDailyTasks = new List<RCONTaskItemJSON>();
        private static List<RCONTaskItemJSON> completedWeeklyTasks = new List<RCONTaskItemJSON>();
        private static List<RCONTaskItemJSON> completedMonthlyTasks = new List<RCONTaskItemJSON>();

        public static void StartScheduler() {
            RCONSchedulerRunning = true;
            var t1 = new Thread(() =>
            {
                while (RCONSchedulerRunning) { 
                    CheckTasks();
                    Thread.Sleep(10000); // Wait 10 seconds to check again
                }
            });
            t1.Priority = ThreadPriority.BelowNormal; // not sure if this'll create unneeded overhead during task execution so leave bellow normal for now for testing
            t1.IsBackground = true;
            t1.Start();
        }

        #region Private Methods
        private static void CheckTasks() {
            foreach (var task in RCONGlobalTasks.rconTasks) {
                if (task.TaskEnabled) {
                    if (task.TaskDaily & task.TaskRunTime.Hour == DateTime.Now.Hour & task.TaskCompleted.Hour != task.TaskRunTime.Hour & !task.TaskReset) {
                        // Daily task needs ran now - this may work but deep testing needed
                        switch (task.TaskCommand) { 
                            case Enums.RCONType.Announcement:
                                RCONCore.SendCommand(Enums.RCONType.Announcement, task.CustomCommand);
                                break;
                            case Enums.RCONType.Save:
                                RCONCore.SendCommand(Enums.RCONType.Save);
                                break;
                            case Enums.RCONType.Kick:
                                Form1.AppendConsoleEntry("You trying to troll " + task.CustomCommand +"??? (scheduled task)");
                                break;
                        }
                        RCONGlobalTasks.rconTasks.Where(x => x.TaskName == task.TaskName).FirstOrDefault().TaskCompleted = DateTime.Now;
                        RCONGlobalTasks.rconTasks.Where(x => x.TaskName == task.TaskName).FirstOrDefault().TaskReset = false;
                    }
                }
            }
        }
        private static void SanitizeCompleted() {
            foreach (var task in RCONGlobalTasks.rconTasks) {
                if (task.TaskEnabled & task.TaskRunTime.Hour != task.TaskCompleted.Hour) task.TaskReset = true;
            }
        }
        #endregion
    }
}
