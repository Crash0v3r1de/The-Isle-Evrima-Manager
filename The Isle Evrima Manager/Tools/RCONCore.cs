using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.Enums;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;
using TheIsleEvrimaRconClient;

namespace The_Isle_Evrima_Manager.Tools
{
    internal class RCONCore
    {
        public static EvrimaRconClient _rconClient;

        public static async Task ConnectAsync(string host, string port, string password)
        {
            _rconClient = new EvrimaRconClient(new EvrimaRconClientConfiguration(IPAddress.Parse(host), int.Parse(port), password, 5000));
            var connected = await _rconClient.ConnectAsync();
            if (connected)
            {
                RCONGlobalTracker.isConnected = true;
                Debug.WriteLine("Connected");
            }
            else {
                Debug.WriteLine("Not Connected");
            }            
        }
        public static void SendCommand(RCONType type,string announcement = null) {
            var cmd = ParseCommand(type);
            if (announcement == null)
            {
                if (cmd == EvrimaRconCommand.Ban || cmd == EvrimaRconCommand.Kick)
                {
                    // announcement string used for player info
                    _rconClient.SendCommandAsync(cmd, announcement);
                }
                else {
                    _rconClient.SendCommandAsync(cmd);
                }
            }
            else {
                _rconClient.SendCommandAsync(cmd,announcement);
            }
        }


        #region Private Methods
        private static EvrimaRconCommand ParseCommand(RCONType type) {
            switch (type) { 
                case RCONType.Announcement:
                    return EvrimaRconCommand.Announce;
                case RCONType.Ban:
                    return EvrimaRconCommand.Ban;
                case RCONType.Kick:
                    return EvrimaRconCommand.Kick;
                case RCONType.PlayerList:
                    return EvrimaRconCommand.PlayerList;
                case RCONType.Save:
                    return EvrimaRconCommand.Save;
                case RCONType.Custom:
                    return EvrimaRconCommand.Custom;
                default:
                    return EvrimaRconCommand.Custom;
            }
        }
        #endregion
    }
}
