using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.Enums
{
    public enum ManagerStatus
    {
        idle = 0,
        downloadingSteamCMD = 1,
        downloadingServerFiles = 2,
        startingServer = 3,
        stoppingServer = 4,
        error = 5,
        serverRunning = 6,
        savingSettings = 7
    }
}
