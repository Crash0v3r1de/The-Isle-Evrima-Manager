using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.Enums;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

namespace The_Isle_Evrima_Manager.Tools
{
    public static class ManagerStatusHandler
    {
        public static void UpdateManagerStatus(ManagerStatus status)
        {
            switch (status)
            {
                case ManagerStatus.idle:
                    ManagerGlobalTracker.CurrentStatus = ManagerStatus.idle;
                    break;
                case ManagerStatus.downloadingSteamCMD:
                    ManagerGlobalTracker.CurrentStatus = ManagerStatus.downloadingSteamCMD;
                    break;
                case ManagerStatus.downloadingServerFiles:
                    ManagerGlobalTracker.CurrentStatus = ManagerStatus.downloadingServerFiles;
                    break;
                case ManagerStatus.startingServer:
                    ManagerGlobalTracker.CurrentStatus = ManagerStatus.startingServer;
                    break;
                case ManagerStatus.stoppingServer:
                    ManagerGlobalTracker.CurrentStatus = ManagerStatus.stoppingServer;
                    break;
                case ManagerStatus.error:
                    ManagerGlobalTracker.CurrentStatus = ManagerStatus.error;
                    break;
            }
        }
    }
}
