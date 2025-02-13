using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.Tools
{
    /// <summary>
    /// Class will gather hardware data to display to the user
    /// </summary>
    public static class HardwareData
    {
        private static ComputerInfo machine = new ComputerInfo();
        private static PerformanceCounter perf = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        public static string CurrentAppMemUsage() { 
            return $"{GC.GetTotalMemory(false) / 1024 / 1024} MB";
        }
        public static decimal FreeCompMemory()
        {
            var totalRAM = machine.TotalPhysicalMemory;
            var freeRAM = machine.AvailablePhysicalMemory;
            var percFree = Decimal.Divide(freeRAM, totalRAM)*100;
            return Math.Round(percFree, 1);
        }
        public static decimal CompCPUUsage()
        {
            //TODO: GC showing wrong memory usage info, will look into later since not a big deal right now
            return Convert.ToDecimal(perf.NextValue());
        }
        public static double RamFree()
        {
            var free = machine.AvailablePhysicalMemory;
            var tot = free / 1024.0 / 1024.0 / 1024.0; // GB
            return Math.Round(tot, 1);
        }
    }
}
