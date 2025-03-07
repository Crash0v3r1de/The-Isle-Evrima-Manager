using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.Enums;
using The_Isle_Evrima_Manager.IO;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

namespace The_Isle_Evrima_Manager.Tools
{
    public class SteamCMDControl
    {
        // https://steamcommunity.com/sharedfiles/filedetails/?id=2952501611
        private ProcessStartInfo GetArgs(SteamCMDAction action)
        {
            ProcessStartInfo args = new ProcessStartInfo();
            switch (action)
            {
                case SteamCMDAction.Initialize:
                    args.Arguments = $"+login anonymous +quit";
                    args.UseShellExecute = false;
                    args.RedirectStandardOutput = true;
                    args.WindowStyle = ProcessWindowStyle.Hidden;
                    args.FileName = ManagerGlobalTracker.steamCMDexe;
                    break;
                case SteamCMDAction.InstallEvirma:
                    var path = ManagerGlobalTracker.serverPath;
                    if (ManagerGlobalTracker.serverPath.Last().ToString() == "\\") path = path.Remove(path.Length - 1); // remove invalid trailing \ from path
                    args.Arguments = $"+force_install_dir \"{path}\" +login anonymous +app_update 412680 -beta evrima +quit";
                    args.UseShellExecute = false;
                    args.RedirectStandardOutput = true;
                    args.WindowStyle = ProcessWindowStyle.Hidden;
                    args.FileName = ManagerGlobalTracker.steamCMDexe;
                    break;
                case SteamCMDAction.VerifyEvrima:
                    var path1 = ManagerGlobalTracker.serverPath;
                    if (ManagerGlobalTracker.serverPath.Last().ToString() == "\\") path1 = path1.Remove(path1.Length - 1); // remove invalid trailing \ from path
                    args.Arguments = $"+force_install_dir \"{path1}\" +login anonymous +app_update 412680 -beta evrima validate +quit";
                    args.UseShellExecute = false;
                    args.RedirectStandardOutput = true;
                    args.WindowStyle = ProcessWindowStyle.Hidden;
                    args.FileName = ManagerGlobalTracker.steamCMDexe;
                    break;
                case SteamCMDAction.UpdateEvrima:
                    var path2 = ManagerGlobalTracker.serverPath;
                    if (ManagerGlobalTracker.serverPath.Last().ToString() == "\\") path2 = path2.Remove(path2.Length - 1); // remove invalid trailing \ from path
                    args.Arguments = $"+force_install_dir \"{path2}\" +login anonymous +app_update 412680 -beta evrima +quit";
                    args.UseShellExecute = false;
                    args.RedirectStandardOutput = true;
                    args.WindowStyle = ProcessWindowStyle.Hidden;
                    args.FileName = ManagerGlobalTracker.steamCMDexe;
                    break;
            }
            return args;
        }

        public void InitializeTool()
        {
            Logger.Log("Initializing SteamCMD...",LogType.Info);
            Process proc = new Process();
            proc.StartInfo = GetArgs(SteamCMDAction.Initialize);
            proc.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (!String.IsNullOrEmpty(e.Data))
                {
                    Form1.AppendConsoleEntry(e.Data);
                }
            });
            // The way .NET is handling the console when hidden does not allow it to output into the textbox realtime
            // Is what it is for now unless someone has a better code to handle it realtime
            proc.Start();
            proc.BeginOutputReadLine();
            while (!proc.HasExited) { Thread.Sleep(1200); }
            ManagerGlobalTracker.steamCMDInstalled = true;
            ManagerGlobalTracker.steamCMDInitialized = true;
            CoreFiles.SaveManagerSettings();
            Logger.Log("SteamCMD initialized.",LogType.Info);
        }
        public void InstallIsleServer() {
            Logger.Log("Downloading The Isle EVIRMA Dedicated Server...", LogType.Info);
            Process proc = new Process();
            proc.StartInfo = GetArgs(SteamCMDAction.InstallEvirma);
            proc.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (!String.IsNullOrEmpty(e.Data))
                {
                    Form1.AppendConsoleEntry(e.Data);
                }
            });
            // The way .NET is handling the console when hidden does not allow it to output into the textbox realtime
            // Is what it is for now unless someone has a better code to handle it realtime
            proc.Start();
            proc.BeginOutputReadLine();
            while (!proc.HasExited) { Thread.Sleep(1200); }
            ServerAnalytics.PrepFolder();
            ManagerGlobalTracker.isleServerInstalled = true;
            CoreFiles.SaveManagerSettings();
            Logger.Log("The Isle EVIRMA Dedicated Server installed!.", LogType.Info);
        }
        public void VerifyIsleServer()
        {
            Logger.Log("Verifying The Isle EVIRMA Dedicated Server...", LogType.Info);
            Process proc = new Process();
            proc.StartInfo = GetArgs(SteamCMDAction.VerifyEvrima);
            proc.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (!String.IsNullOrEmpty(e.Data))
                {
                    Form1.AppendConsoleEntry(e.Data);
                }
            });
            // The way .NET is handling the console when hidden does not allow it to output into the textbox realtime
            // Is what it is for now unless someone has a better code to handle it realtime
            proc.Start();
            proc.BeginOutputReadLine();
            while (!proc.HasExited) { Thread.Sleep(1200); }

            CoreFiles.SaveManagerSettings();
            Logger.Log("The Isle EVIRMA Dedicated Server verified!.", LogType.Info);
        }
    }
}
