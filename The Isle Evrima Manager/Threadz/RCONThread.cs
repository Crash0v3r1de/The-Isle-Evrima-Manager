using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.IO;
using The_Isle_Evrima_Manager.JSON.RCON_Task;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;
using TheIsleEvrimaRconClient;

namespace The_Isle_Evrima_Manager.Threadz
{
    public static class RCONThread
    {
        private static bool connected = false;
        public static async Task SendCommand(RCONTaskItemJSON task)
        {
            using (var rc = new EvrimaRconClient(IPAddress.Parse(RCONGlobalTracker.rconHost), int.Parse(RCONGlobalTracker.rconPort), RCONGlobalTracker.rconPassword))
            {
                connected = await rc.ConnectAsync();
                if (connected)
                {
                    var command = GetRCONCommand(task).Split('|');
                    // 0 is the command      1 is the argument
                    if (command[1] == null || string.IsNullOrWhiteSpace(command[1]))
                    {
                        // single command to send
                        var ret = await rc.SendCommandAsync(command[0]);
                    }
                    else {
                        var ret = await rc.SendCommandAsync(command[0], command[1]);
                    }
                }
                else
                {
                    Logger.Log("Failed to connect to RCON server - please check your settings!", LogType.Error);
                }
            }
        }



        #region Private Methods
        private static string GetRCONCommand(RCONTaskItemJSON task) {
                // not custom command
                switch (task.TaskCommand)
                {
                    case Enums.RCONType.Announcement:
                        return $"announcement|{task.CustomCommand}";
                        break;
                    case Enums.RCONType.Kick:
                        return $"kick|{task.CustomCommand}";
                        break;
                    case Enums.RCONType.Ban:
                        return $"ban|{task.CustomCommand}";
                        break;
                    case Enums.RCONType.PlayerList:
                        // handle the return in public method
                        break;
                    case Enums.RCONType.Save:
                        return $"save";
                        break;
                    case Enums.RCONType.Custom:
                        return task.CustomCommand;
                        break;
                }

            return "ERROR";
        }
        #endregion
    }
}
