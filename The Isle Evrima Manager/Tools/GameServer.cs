using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.Enums;
using The_Isle_Evrima_Manager.IO;
using The_Isle_Evrima_Manager.Threadz;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

namespace The_Isle_Evrima_Manager.Tools
{
    public static class GameServer
    {
        private static string serverPrimaryBinary = "TheIsleServer-Win64-Shipping.exe"; // This is the actual server
        private static string serverSecondayBinary = "TheIsleServer.exe"; // Main binary to load the actual server
        private static PerformanceCounter counter = new PerformanceCounter();

        public static string ServerMemoryUage()
        {
            Process[] proc = Process.GetProcessesByName(serverPrimaryBinary); // returns an array but single instance will only have one binary running
            counter.InstanceName = proc[0].ProcessName; // again single isntance this is fine

            var memUsage = counter.NextValue() / (int)(1024) / (int)(1024) / (int)(1024); // shown as GB

            return memUsage.ToString(); // TODO make this cleaner probably, float instead of lazy string
            // TODO: Also add code for secondary binary and combine both memory counters for complete usage by Isle system
        }
        public static void StartServer()
        {
            ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.startingServer);
            var t = new Thread(() =>
            {
                var steam = new SteamCMDControl();
                if (ManagerGlobalTracker.steamClientInstalled)
                { // SteamCMD is installed
                    if (ManagerGlobalTracker.isleServerInstalled) steam.InstallIsleServer();
                }
                else
                {
                    steam.InitializeTool();
                    steam.InstallIsleServer();
                    CoreFiles.CopyDLLs();
                    CoreFiles.WriteEngineINI(); // This doesn't change, it's The Isle's API keys to use Epic Online servers
                }
                if (ManagerGlobalTracker.isleServerInstalled)
                {
                    // Check for settings, start if everything looks good
                    var fullPath = ManagerGlobalTracker.serverPath + ManagerGlobalTracker.gameINI;
                    if (File.Exists(fullPath))
                    {
                        StartServerProcess();
                    }
                    else { 
                        // Prompt for server settings
                    }
                }

                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.serverRunning);
            });
            t.IsBackground = true;
            t.Start();
        }
        public static void StopGracefully()
        {
            ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.stoppingServer);
            GameServerStatusTracker.AllowServerRunning = false;
        }
        public static void StopForcefully()
        {
            ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.stoppingServer);
            GameServerStatusTracker.ForceStop = true;
        }

        #region Private Methods
        private static void StartServerProcess()
        {
            Logger.Log("Starting game server...", LogType.Info);
            ServerThread.server.StartInfo = StartArgs();
            ServerThread.server.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (!String.IsNullOrEmpty(e.Data))
                {
                    Form1.AppendConsoleEntry(e.Data);
                }
            });
            // The way .NET is handling the console when hidden does not allow it to output into the textbox realtime
            // Is what it is for now unless someone has a better code to handle it realtime
            ServerThread.server.Start();
            ServerThread.server.BeginOutputReadLine();
            new Thread(() =>
            {
                ServerThread.ServerThreadManager(); // Start watchdog thread
            }).Start();
            
            ManagerGlobalTracker.CurrentStatus = ManagerStatus.serverRunning;
            Logger.Log("Server started!", LogType.Info);
        }
        private static ProcessStartInfo StartArgs() {
            ProcessStartInfo args = new ProcessStartInfo();
            args.Arguments = $"?Port={GameServerStatusTracker.ServerPort} -ini:Engine:[EpicOnlineServices]:DedicatedServerClientId=xyza7891gk5PRo3J7G9puCJGFJjmEguW -ini:Engine:[EpicOnlineServices]:DedicatedServerClientSecret=pKWl6t5i9NJK8gTpVlAxzENZ65P8hYzodV8Dqe5Rlc8 -log";
            args.UseShellExecute = false;
            args.RedirectStandardOutput = true;
            args.WindowStyle = ProcessWindowStyle.Hidden;
            args.FileName = ManagerGlobalTracker.serverExe;
            return args;
        }
        
        #endregion
    }
}