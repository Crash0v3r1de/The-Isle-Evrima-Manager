using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.IO
{
    public static class CoreFiles
    {
        private static string steamCMDDir = "/utils/steamcmd";
        private static string utilDir = "/utils";




        public static void InitializeStructure() {
            if (!Directory.Exists(utilDir)) { 
            Directory.CreateDirectory(utilDir);
            }
            if (!Directory.Exists(steamCMDDir))
            {
                Directory.CreateDirectory(steamCMDDir);
            }
        }
    }
}
