using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.JSON;

namespace The_Isle_Evrima_Manager.Threadz.ThreadTracking
{
    public static class GameServerSettings
    {
        public static GameIniSession GameIniSession { get; set; } = new GameIniSession();
        public static GameIniStateBase GameIniState { get; set; } = new GameIniStateBase();
    }
}
