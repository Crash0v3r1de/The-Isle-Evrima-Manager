﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;

namespace The_Isle_Evrima_Manager.Tools
{
    public class RequirementChecker
    {
        // Also needs .NET 3.5 installed
        public bool VisualcCheck()
        {
            // Too lazy to want to make my own - copied and modified for 2015-2022 version 
            // Orig snippet https://stackoverflow.com/questions/53000475/how-to-check-if-microsoft-visual-c-2015-redistributable-installed-on-a-device
            string dependenciesPath = @"SOFTWARE\Classes\Installer\Dependencies";
            using (RegistryKey dependencies = Registry.LocalMachine.OpenSubKey(dependenciesPath))
            {
                if (dependencies == null) return false;

                foreach (string subKeyName in dependencies.GetSubKeyNames().Where(n => !n.ToLower().Contains("dotnet") && !n.ToLower().Contains("microsoft")))
                {
                    using (RegistryKey subDir = Registry.LocalMachine.OpenSubKey(dependenciesPath + "\\" + subKeyName))
                    {
                        var value = subDir.GetValue("DisplayName")?.ToString() ?? null;
                        if (string.IsNullOrEmpty(value)) continue;

                        if (Regex.IsMatch(value, @"C\+\+ 2015\-2022.*\(x64\)")) 
                        {
                            ManagerGlobalTracker.cplusplusInstalled = true;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool SteamPresent() {
            if (File.Exists($"{ManagerGlobalTracker.dllDir}steamclient64.dll")) return true;
            return false;
        }        
    }
}
