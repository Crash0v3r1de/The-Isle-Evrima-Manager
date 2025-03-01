using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.IO;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

namespace The_Isle_Evrima_Manager.Threadz
{
    public static class ServerThread
    {
        public static Process server = new Process();
        public static void ServerThreadManager() {
            if (GameServerStatusTracker.RestartProcessOnFail)
            {
                while (GameServerStatusTracker.RestartProcessOnFail)
                {
                    if (!GameServerStatusTracker.AllowServerRunning) { 
                        Logger.Log("Server stopping...", LogType.Info);
                        server.Close(); // Graceful ctrl+c essentially
                        // TODO: see how this is handled once fully close and update status when closed
                    }
                    if (GameServerStatusTracker.ForceStop) { 
                        Logger.Log("Server force stopping...(data corruption may happen)", LogType.Warning);
                        server.Kill(); // Force kill - could corrupt data
                    }
                    if (server.HasExited) { 
                        Logger.Log("Server exited(crash?) - restarting...", LogType.Error);
                        server.Start(); // Restart server
                    }
                    Thread.Sleep(5000); // Maybe add this as manager setting eventually
                }
            }
            else {
                // Don't restart thread
                while (true) {
                    if (!GameServerStatusTracker.AllowServerRunning)
                    {
                        Logger.Log("Server stopping...", LogType.Info);
                        server.Close(); // Graceful ctrl+c essentially
                        // TODO: see how this is handled once fully close and update status when closed
                    }
                    if (GameServerStatusTracker.ForceStop)
                    {
                        Logger.Log("Server force stopping...(data corruption may happen)", LogType.Warning);
                        server.Kill(); // Force kill - could corrupt data
                    }
                    if (server.HasExited) {
                        Logger.Log("Server exited(crash?) - restart disabled in settings...", LogType.Error);
                        break; // exit the loop and exit thread since not watching the server anymore
                    }
                }
            }
        }
    }
}
