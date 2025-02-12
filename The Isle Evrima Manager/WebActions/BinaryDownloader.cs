using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.IO;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

namespace The_Isle_Evrima_Manager.WebActions
{
    public class BinaryDownloader
    {
        public bool DownloadSteamCMD() {
            string tmpDir = Environment.CurrentDirectory + @"\tmp\steamcmd.zip";            
            if (!File.Exists(ManagerStatusTracker.steamCMDexe)) {
                while (!File.Exists(tmpDir))
                {
                    // During testing it did not download on the first attempt - no errors, just no download
                    new WebClient().DownloadFile("https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip", tmpDir);
                }
                Logger.Log("SteamCMD downloaded, extracting to utils folder...", LogType.Info);
                CoreFiles.SaveAndExtractSteamCMD(tmpDir);
                File.Delete(tmpDir); // Remove tmp file, we don't like to leave a mess
                Logger.Log("SteamCMD extracted, removing tmp file...", LogType.Info);
            }
            else Logger.Log("SteamCMD already exists, skipping download...", LogType.Info);
            

            return false;
        }
    }
}
