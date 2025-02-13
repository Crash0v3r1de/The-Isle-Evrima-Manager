using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Isle_Evrima_Manager.IO
{
    public static class GameSettings
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
            var files = Directory.GetFiles(savedPlayerDataDir).Where(f => f.ToLower().EndsWith("sav"));
            return files.Count();
        }
        public static List<string> GetGameSettings()
        {
            List<string> settings = new List<string>();
            foreach (string line in File.ReadLines(iniFile))
            {
                settings.Add(line);
            }
            return settings;
        }
    }
}
