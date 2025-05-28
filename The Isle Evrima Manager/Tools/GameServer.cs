using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.Enums;
using The_Isle_Evrima_Manager.Forms;
using The_Isle_Evrima_Manager.IO;
using The_Isle_Evrima_Manager.JSON;
using The_Isle_Evrima_Manager.Threadz;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;
using The_Isle_Evrima_Manager.WebActions;

namespace The_Isle_Evrima_Manager.Tools
{
    public static class GameServer
    {
        private static PerformanceCounter counter = new PerformanceCounter();
        public static bool ServerRunning = false;

        public static string ServerMemoryUage()
        {
            Process[] proc = Process.GetProcessesByName("TheIsleServer-Win64-Shipping.exe"); // returns an array but single instance will only have one binary running
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
                int rebootCounter = 0;
                var steam = new SteamCMDControl();
                if (ManagerGlobalTracker.steamClientInstalled)
                { // SteamCMD is installed
                    if (ManagerGlobalTracker.isleServerInstalled) steam.InstallIsleServer();
                }
                else
                {
                    if(!ManagerGlobalTracker.steamCMDInitialized) steam.InitializeTool();
                    if (!ManagerGlobalTracker.isleServerInstalled) {

                        steam.InstallIsleServer();
                        CoreFiles.CopyDLLs();
                        CoreFiles.SaveEngineINI(); // This doesn't change, it's The Isle's API keys to use Epic Online servers
                    }
                }
                if (ManagerGlobalTracker.isleServerInstalled)
                {
                    // Check for settings, start if everything looks good
                    var fullPath = ManagerGlobalTracker.serverPath + ManagerGlobalTracker.gameINI;
                    if (File.Exists(fullPath))
                    {
                        GameServerStatusTracker.AllowServerRunning = true;
                        StartServerProcess();
                    }
                    else { 
                        // Prompt for server settings
                        PromptForSetup();
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
            ServerThread.server = new Process();
            ServerThread.server.StartInfo = StartArgs();

            ServerThread.server.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                Form1.AppendConsoleEntry(e.Data);
            });
            ServerThread.server.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                Form1.AppendConsoleEntry(e.Data);
            });
            ServerRunning = true;
            ServerThread.Start();
            ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.serverRunning);

            new Thread(() => {
                 ServerThread.ServerThreadManager();
            }).Start();
        }
        private static ProcessStartInfo StartArgs() {
            ProcessStartInfo args = new ProcessStartInfo();
            args.Arguments = $"?Port={GameServerStatusTracker.ServerPort} -ini:Engine:[EpicOnlineServices]:DedicatedServerClientId=xyza7891gk5PRo3J7G9puCJGFJjmEguW -ini:Engine:[EpicOnlineServices]:DedicatedServerClientSecret=pKWl6t5i9NJK8gTpVlAxzENZ65P8hYzodV8Dqe5Rlc8 -log";
            args.UseShellExecute = false;
            args.RedirectStandardOutput = true;
            args.RedirectStandardError = true;
            args.RedirectStandardInput = true;
            args.CreateNoWindow = true;
            args.WindowStyle = ProcessWindowStyle.Hidden;
            args.FileName = ManagerGlobalTracker.serverCoreExe;
            return args;
        }
        private static void PromptForSetup()
        {
            new ManagerSettings().ShowDialog();
            CoreFiles.SaveManagerSettings();

            new frmGameServerSettings().ShowDialog();
            if (GameServerSettings.GameIniSession.EnableRCON)
            {
                new frmRCONSettings().ShowDialog();
                new frmRCONTasks().ShowDialog();
                CoreFiles.SaveRCONSettings();
                CoreFiles.SaveRCONTasks();
            }
            var result = MessageBox.Show("Do you want to change the game servers install location?\n*it installs in the server folder of the root of this tool*", "Change Server Install Path?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) PromptServerDir();
            new Thread(() =>
            {
                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.savingSettings);
                CoreFiles.SaveGameServerSettings();
                CoreFiles.SaveGameServerStatusSettings();
                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.downloadingSteamCMD);
                new BinaryDownloader().DownloadSteamCMD();
                var steam = new SteamCMDControl();
                steam.InitializeTool();
                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.downloadingServerFiles);
                steam.InstallIsleServer();
                CoreFiles.CopyDLLs();
                CoreFiles.SaveEngineINI();
                CoreFiles.SaveGameINI();
                GameServerSettings.PendingSettingsApply = false;
                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.startingServer);
                GameServer.StartServer();
            }).Start();
        }
        private static void PromptServerDir()
        {
            FolderBrowserDialog dir = new FolderBrowserDialog();
            dir.Tag = "Select the directory where the server files will be installed";
            dir.ShowDialog();
            while (true)
            {
                // quick loop to ensure instal is not on the root of a drive directly
                DirectoryInfo d = new DirectoryInfo(dir.SelectedPath);
                if (d.Parent == null) { MessageBox.Show("Steam cannot install directly onto a drive, please create a folder to use."); dir.ShowDialog(); }
                else break;
            }
            var newPath = dir.SelectedPath;
            UpdateGameServerPaths(newPath);
            CoreFiles.SaveManagerSettings();
            CoreFiles.PrcoessServerPathMove(newPath);
            Logger.Log($"Changed server directory to {newPath}", LogType.Info);
        }
        private static void UpdateGameServerPaths(string rootDir)
        {
            // TODO: Not ideal but can redo later
            ManagerGlobalTracker.customServerDir = true;
            ManagerGlobalTracker.serverPath = rootDir;
            ManagerGlobalTracker.dllDir = rootDir + @"\TheIsle\Binaries\Win64\";
            ManagerGlobalTracker.serverExe = rootDir + @"\TheIsleServer.exe";
            ManagerGlobalTracker.serverCoreExe = rootDir + @"\TheIsle\Binaries\Win64\TheIsleServer-Win64-Shipping.exe";
            CoreFiles.SaveManagerSettings();
        }
        #endregion
    }
}