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
            if (!Directory.Exists(ManagerStatusTracker.serverPath))
            {
                Directory.CreateDirectory(ManagerStatusTracker.serverPath);
            }
            if (!Directory.Exists(ManagerStatusTracker.logDir))
            {
                Directory.CreateDirectory(ManagerStatusTracker.logDir);
            }
        }
        public static void SaveAndExtractSteamCMD(string tmpPath) { 
            ZipFile.ExtractToDirectory(tmpPath, steamCMDDir);
        }
    }
}
