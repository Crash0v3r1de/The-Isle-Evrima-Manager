using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.JSON
{
    public class GameServerJSON
    {
        public bool RestartProcessOnFail { get; set; } = true;
        public bool DiscordNotifyOnFail { get; set; } = true;
        public bool AllowServerRunning { get; set; } = true;
        public bool ForceStop { get; set; } = false;
        public int ServerPort { get; set; } = 7777;
    }
}
