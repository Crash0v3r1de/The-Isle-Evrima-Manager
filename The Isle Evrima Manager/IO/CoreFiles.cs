using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

namespace The_Isle_Evrima_Manager.IO
{
    public static class CoreFiles
    {
        private static string currentDir = Environment.CurrentDirectory;
        private static string steamCMDDir = currentDir+@"\utils\steamcmd";
        private static string utilDir = currentDir + @"\utils";
        private static string tmpDir = currentDir + @"\tmp";


        public static void InitializeStructure() {
            if (!Directory.Exists(utilDir)) { 
            Directory.CreateDirectory(utilDir);
            }
            if (!Directory.Exists(steamCMDDir))
            {
                Directory.CreateDirectory(steamCMDDir);
            }
            if (!Directory.Exists(tmpDir))
            {
                Directory.CreateDirectory(tmpDir);
            }
            if (!Directory.Exists(ManagerGlobalTracker.serverPath))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.serverPath);
            }
            if (!Directory.Exists(ManagerGlobalTracker.logDir))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.logDir);
            }
            if (!Directory.Exists(ManagerGlobalTracker.managerConfDir)) { 
                Directory.CreateDirectory(ManagerGlobalTracker.managerConfDir);
            }
        }
        public static void SaveAndExtractSteamCMD(string tmpPath) { 
            ZipFile.ExtractToDirectory(tmpPath, steamCMDDir);
        }
        public static void SaveGameINI(List<string> ini) {
            // Saved\Config\WindowsServer - folder structure needed inside server root directory
            if (!Directory.Exists(ManagerGlobalTracker.serverPath + "Saved")) { 
                Directory.CreateDirectory(ManagerGlobalTracker.serverPath + "Saved");
            }
            if (!Directory.Exists(ManagerGlobalTracker.serverPath + @"Saved\Config"))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.serverPath + @"Saved\Config");
            }
            if (!Directory.Exists(ManagerGlobalTracker.serverPath + @"Saved\Config\WnidowsServer"))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.serverPath + @"Saved\Config\WindowsServer");
            }
            var fullPath = ManagerGlobalTracker.serverPath + ManagerGlobalTracker.gameINI;
            using (StreamWriter sw = new StreamWriter(fullPath, false)) { 
                for (int x = 0;x < ini.Count; x++)
                {
                    // Write to file in order
                    sw.WriteLine(ini[x]);
                }
            }
        }
        public static void SaveEngineINI(List<string> ini) {
            // Saved\Config\WindowsServer - folder structure needed inside server root directory
            if (!Directory.Exists(ManagerGlobalTracker.serverPath + "Saved"))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.serverPath + "Saved");
            }
            if (!Directory.Exists(ManagerGlobalTracker.serverPath + @"Saved\Config"))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.serverPath + @"Saved\Config");
            }
            if (!Directory.Exists(ManagerGlobalTracker.serverPath + @"Saved\Config\WnidowsServer"))
            {
                Directory.CreateDirectory(ManagerGlobalTracker.serverPath + @"Saved\Config\WindowsServer");
            }
            var fullPath = ManagerGlobalTracker.serverPath + ManagerGlobalTracker.engineINI;
            using (StreamWriter sw = new StreamWriter(fullPath, false))
            {
                for (int x = 0; x < ini.Count; x++)
                {
                    // Write to file in order
                    sw.WriteLine(ini[x]);
                }
            }
        }
        public static void PrcoessServerPathMove(string newPath) { 
            Directory.Move(ManagerGlobalTracker.serverPath, newPath);
            ManagerGlobalTracker.serverPath = newPath; // Set new path also
        }
        public static bool CopyDLLs() {
            try {
                // We'll group all for now, maybe breakout to new method(s) later
                File.WriteAllBytes(ManagerGlobalTracker.dllDir + "steamclient.dll", Properties.Resources.steamclient);
                File.WriteAllBytes(ManagerGlobalTracker.dllDir + "steamclient64.dll", Properties.Resources.steamclient64);
                File.WriteAllBytes(ManagerGlobalTracker.dllDir + "tier0_s.dll", Properties.Resources.tier0_s);
                File.WriteAllBytes(ManagerGlobalTracker.dllDir + "tier0_s64.dll", Properties.Resources.tier0_s64);
                File.WriteAllBytes(ManagerGlobalTracker.dllDir + "vstdlib_s.dll", Properties.Resources.vstdlib_s);
                File.WriteAllBytes(ManagerGlobalTracker.dllDir + "vstdlib_s64.dll", Properties.Resources.vstdlib_s64);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message,LogType.Error);
                return false;
            }            
            return true;
        }
    }
}
