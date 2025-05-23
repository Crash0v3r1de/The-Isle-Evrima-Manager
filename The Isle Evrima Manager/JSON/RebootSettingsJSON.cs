using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.JSON
{
    public class RebootSettingsJSON
    {
        public bool NightlyRestartsEnabled { get; set; } = false;
        public bool UseRCONAnnouncements { get; set; } = false;
    }
}
