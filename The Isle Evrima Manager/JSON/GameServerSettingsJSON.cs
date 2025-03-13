using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.JSON
{
    public class GameServerSettingsJSON
    {
        public GameIniSession GameIniSession { get; set; }
        public GameIniStateBase GameIniState { get; set; }
        public bool PendingSettingsApply { get; set; } = false; // Also bool in Game Server Status
    }
}
