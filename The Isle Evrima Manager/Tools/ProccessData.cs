using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.Tools
{
    public static class ProccessData
    {
        private static string serverPrimaryBinary = "TheIsleServer-Win64-Shipping.exe"; // This is the actual server
        private static string serverSecondayBinary = "TheIsleServer.exe"; // Main binary to load the actual server
        private static PerformanceCounter counter = new PerformanceCounter();

        public static string ServerMemoryUage() {
            Process[] proc = Process.GetProcessesByName(serverPrimaryBinary); // returns an array but single instance will only have one binary running
            counter.InstanceName = proc[0].ProcessName; // again single isntance this is fine

            var memUsage = counter.NextValue() / (int)(1024) / (int)(1024) / (int)(1024); // shown as GB

            return memUsage.ToString(); // TODO make this cleaner probably, float instead of lazy string
            // TODO: Also add code for secondary binary and combine both memory counters for complete usage by Isle system
        }
    }
}
