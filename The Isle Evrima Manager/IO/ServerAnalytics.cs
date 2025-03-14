﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;
// We could install MS Ini Config Extension package at some point but JSON is king - lets be honest
// using Microsoft.Extensions.Configuration.Ini;
// Or JSON to Ini - npm install json2ini

namespace The_Isle_Evrima_Manager.IO
{
    public static class ServerAnalytics
    {
        // \tiserver\TheIsle\Saved\Config\WindowsServer
        private static string iniDir = @"\server\TheIsle\Saved\Config\WindowsServer";
        private static string iniFile = @"\server\TheIsle\Saved\Config\WindowsServer\Game.ini";
        private static string savedPlayerDataDir = @"\server\TheIsle\Saved\PlayerData";
        private static string windowsServerDirName = "WindowsServer";
        private static string serverDir = "/server";
        // will need to make this cleaner for dynamic paths

        public static void PrepFolder()
        {
            if (!Directory.Exists(iniDir))
            {
                Directory.CreateDirectory(iniDir);
            }
        }
        public static int PlayerDataCount() {
            if (Directory.Exists(savedPlayerDataDir)) {
                var files = Directory.GetFiles(savedPlayerDataDir).Where(f => f.ToLower().EndsWith("sav"));
                return files.Count();
            }
            return 0;
        }
                
    }
}
