using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.JSON.RCON_Task
{
    public class RCONTaskItem
    {
        public string TaskName { get; set; }
        public string TaskCommand { get; set; }
        public DateTime TaskRunTime { get; set; }
        public bool TaskEnabled { get; set; }
        public bool TaskHourly { get; set; }
        public bool TaskWeekly { get; set; }
        public bool TaskMonthly { get; set; }
        public bool TaskDaily { get; set; }
    }
}
