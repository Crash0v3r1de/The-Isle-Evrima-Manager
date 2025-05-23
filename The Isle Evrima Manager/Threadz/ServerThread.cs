﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using The_Isle_Evrima_Manager.Enums;
using The_Isle_Evrima_Manager.IO;
using The_Isle_Evrima_Manager.JSON;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;
using The_Isle_Evrima_Manager.Tools;

namespace The_Isle_Evrima_Manager.Threadz
{
    public static class ServerThread
    {
        internal const int CTRL_C_EVENT = 0;
        [DllImport("kernel32.dll")]
        internal static extern bool GenerateConsoleCtrlEvent(uint dwCtrlEvent, uint dwProcessGroupId);
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool AttachConsole(uint dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        internal static extern bool FreeConsole();
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate HandlerRoutine, bool Add);
        // Delegate type to be used as the Handler Routine for SCCH
        delegate Boolean ConsoleCtrlDelegate(uint CtrlType);
        // The above for sending CTRL+C to the server process graceful shutdown
        public static Process server;
        private static volatile bool SENDING_CTRL_C_TO_CHILD = false;
        private static int rebootCounter = 0;


        public static void ServerThreadManager() {
            try {
                while (GameServer.ServerRunning) {
                    if (GameServerStatusTracker.RestartProcessOnFail)
                    {
                        while (GameServerStatusTracker.RestartProcessOnFail)
                        {
                            if (server == null || server.HasExited)
                            {
                                Logger.Log("Server exited(crash?) - restarting...", LogType.Error);
                                Start(); // Restart server
                            }

                            if (!GameServerStatusTracker.AllowServerRunning)
                            {
                                Logger.Log("Server stopping...", LogType.Info);
                                if (server != null)
                                {
                                    if (AttachConsole((uint)server.Id))
                                    {
                                        SetConsoleCtrlHandler(null, true);
                                        try
                                        {
                                            if (!GenerateConsoleCtrlEvent(CTRL_C_EVENT, 0))
                                                server.WaitForExit();
                                        }
                                        finally
                                        {
                                            // nothing
                                        }
                                    }
                                    server.WaitForExit();
                                    if (server.HasExited)
                                    {
                                        Logger.Log("Server stoped!", LogType.Info);
                                        ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.idle);
                                        GameServer.ServerRunning = false;
                                    }
                                }

                                while (!server.HasExited)
                                {
                                    if (server.HasExited) break;
                                    Thread.Sleep(1200);
                                }
                            }
                            if (GameServerStatusTracker.ForceStop)
                            {
                                Logger.Log("Server force stopping...(data corruption may happen)", LogType.Warning);
                                server.Kill();
                                server.WaitForExit();
                                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.idle);
                                GameServer.ServerRunning = false;
                            }
                            if (NightlyRebootLogic()) {
                                if (server != null)
                                {
                                    if (AttachConsole((uint)server.Id))
                                    {
                                        SetConsoleCtrlHandler(null, true);
                                        try
                                        {
                                            if (!GenerateConsoleCtrlEvent(CTRL_C_EVENT, 0))
                                                server.WaitForExit();
                                        }
                                        finally
                                        {
                                            // nothing
                                        }
                                    }
                                    server.WaitForExit();
                                    if (server.HasExited)
                                    {
                                        Logger.Log("Server stoped!", LogType.Info);
                                        ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.idle);
                                        GameServer.ServerRunning = false;
                                    }
                                    Thread.Sleep(8000); // 8 seconds should be enough?
                                    // Start server again
                                    Start();
                                }
                            }
                            Thread.Sleep(5000); // TODO: Maybe add this as manager setting eventually
                            if (server == null || server.HasExited) GameServer.ServerRunning = false;
                            else GameServer.ServerRunning = true;
                        }
                    }
                    else
                    {
                        // Don't restart thread
                        while (true)
                        {
                            if (!GameServerStatusTracker.AllowServerRunning && !GameServerStatusTracker.ForceStop)
                            {
                                Logger.Log("Server stopping...", LogType.Info);
                                if (server != null)
                                {
                                    if (AttachConsole((uint)server.Id))
                                    {
                                        SetConsoleCtrlHandler(null, true);
                                        try
                                        {
                                            if (!GenerateConsoleCtrlEvent(CTRL_C_EVENT, 0))
                                                server.WaitForExit();
                                        }
                                        finally
                                        {
                                            // nothing
                                        }
                                    }
                                    server.WaitForExit();
                                    if (server.HasExited)
                                    {
                                        Logger.Log("Server stoped!", LogType.Info);
                                        ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.idle);
                                        GameServer.ServerRunning = false;
                                        break;
                                    }
                                }

                                while (!server.HasExited)
                                {
                                    if (server.HasExited) break;
                                    Thread.Sleep(1200);
                                }
                                break;

                            }
                            if (GameServerStatusTracker.ForceStop)
                            {
                                Logger.Log("Server force stopping...(data corruption may happen)", LogType.Warning);
                                if (server != null) server.Kill();
                                server.WaitForExit();
                                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.idle);
                                GameServer.ServerRunning = false;
                                while (!server.HasExited)
                                {
                                    if (server.HasExited) break;
                                    Thread.Sleep(1200);
                                }
                                break;
                            }
                            if (server == null || server.HasExited)
                            {
                                Logger.Log("Server exited(crash?) - restart disabled in settings...", LogType.Error);
                                break; // exit the loop and exit thread since not watching the server anymore
                            }
                            if (NightlyRebootLogic())
                            {
                                if (server != null)
                                {
                                    if (AttachConsole((uint)server.Id))
                                    {
                                        SetConsoleCtrlHandler(null, true);
                                        try
                                        {
                                            if (!GenerateConsoleCtrlEvent(CTRL_C_EVENT, 0))
                                                server.WaitForExit();
                                        }
                                        finally
                                        {
                                            // nothing
                                        }
                                    }
                                    server.WaitForExit();
                                    if (server.HasExited)
                                    {
                                        Logger.Log("Server stoped!", LogType.Info);
                                        ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.idle);
                                        GameServer.ServerRunning = false;
                                    }
                                    Thread.Sleep(8000); // 8 seconds should be enough?
                                    // Start server again
                                    Start();
                                    Thread.Sleep(5000); // 5 seconds for binary to load to logic and see it's still running since no restart on crash enabled
                                }
                            }
                            if (server != null && server.HasExited) GameServer.ServerRunning = false;
                            else GameServer.ServerRunning = true;
                            Thread.Sleep(5000); // TODO: Maybe add this as manager setting eventually
                        }
                    }
                }                
            }
            catch(Exception ex) { Logger.Log($"Fatal Thread Manager | {ex.Message}",LogType.Error); }            
        }
        public static void Start(/*ProcessStartInfo args*/) {
            if (server != null && server.StartInfo != null) {
                server.Start();
                server.BeginOutputReadLine();
                server.BeginErrorReadLine();
                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.serverRunning);
                Logger.Log("Server started!", LogType.Info);
            }     
        }

        #region Private Methods
        public enum ConsoleCtrlEvent
        {
            CTRL_C = 0,
            CTRL_BREAK = 1,
            CTRL_CLOSE = 2,
            CTRL_LOGOFF = 5,
            CTRL_SHUTDOWN = 6
        }

        private static bool NightlyRebootLogic()
        {
            // 1AM reboot
                if (DateTime.Now.Hour == 0)
                {
                    // Hour heads up
                    try
                    {
                        RCONCore.ConnectAsync(RCONGlobalTracker.rconHost, RCONGlobalTracker.rconPort, RCONGlobalTracker.rconPassword);
                        RCONCore.SendCommand(RCONType.Announcement, "Server is restarting in 1 hour");
                    }
                    catch (Exception ex) { Logger.Log($"Error reboot announcement - {ex.Message}", LogType.Error); }
                }
                if (DateTime.Now.Hour == 0 & DateTime.Now.Minute == 30)
                {
                    // half hour heads up
                    try
                    {
                        RCONCore.ConnectAsync(RCONGlobalTracker.rconHost, RCONGlobalTracker.rconPort, RCONGlobalTracker.rconPassword);
                        RCONCore.SendCommand(RCONType.Announcement, "Server is restarting in 30 minutes");
                    }
                    catch (Exception ex) { Logger.Log($"Error reboot announcement - {ex.Message}", LogType.Error); }
                }
                if (DateTime.Now.Hour == 0 & DateTime.Now.Minute == 50)
                {
                    // 10 minute heads up
                    try
                    {
                        RCONCore.ConnectAsync(RCONGlobalTracker.rconHost, RCONGlobalTracker.rconPort, RCONGlobalTracker.rconPassword);
                        RCONCore.SendCommand(RCONType.Announcement, "Server is restarting in 10 minutes");
                    }
                    catch (Exception ex) { Logger.Log($"Error reboot announcement - {ex.Message}", LogType.Error); }
                }
                if (DateTime.Now.Hour == 0 & DateTime.Now.Minute == 55)
                {
                    // 5 minute heads up
                    try
                    {
                        RCONCore.ConnectAsync(RCONGlobalTracker.rconHost, RCONGlobalTracker.rconPort, RCONGlobalTracker.rconPassword);
                        RCONCore.SendCommand(RCONType.Announcement, "Server is restarting in 5 minutes - SAFE LOG NOW");
                    }
                    catch (Exception ex) { Logger.Log($"Error reboot announcement - {ex.Message}", LogType.Error); }
                }
                if (DateTime.Now.Hour == 0 & DateTime.Now.Minute == 58)
                {
                    // 2 minute heads up - they're probably screwed now
                    try
                    {
                        RCONCore.ConnectAsync(RCONGlobalTracker.rconHost, RCONGlobalTracker.rconPort, RCONGlobalTracker.rconPassword);
                        RCONCore.SendCommand(RCONType.Announcement, "Server is restarting in 2 minutes...it might be too late to safe log now");
                    }
                    catch (Exception ex) { Logger.Log($"Error reboot announcement - {ex.Message}", LogType.Error); }
                }
                if (rebootCounter == 0 & DateTime.Now.Hour == 1)
                {
                    return true;
                }
                if (rebootCounter != 0 & DateTime.Now.Hour == 2)
                {
                    // reset counter to 0 for next night processing
                    rebootCounter = 0;
                }
                return false;
            }

        #endregion
    }
}
