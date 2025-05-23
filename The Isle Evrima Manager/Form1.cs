using CoreRCON;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System.Configuration;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using The_Isle_Evrima_Manager.Enums;
using The_Isle_Evrima_Manager.Forms;
using The_Isle_Evrima_Manager.IO;
using The_Isle_Evrima_Manager.Threadz.ThreadTracking;
using The_Isle_Evrima_Manager.Tools;
using The_Isle_Evrima_Manager.WebActions;

namespace The_Isle_Evrima_Manager
{
    public partial class Form1 : Form
    {
        private string baseSpeed = "";
        private string maxSpeed = "";
        private ulong ramSize;
        private ManagerSettingsIO manSet = new ManagerSettingsIO();

        public Form1()
        {
            InitializeComponent();
        }
        private void SysPrep()
        {
            // TODO: Once github is public, finish this method and add one for EVIRMA steam releases
            //var updates = new UpdateChecker();
            //updates.ManagerUpdate();

            if (InvokeRequired)
            {
                Invoke(SysPrep);
                return;
            }
            CoreFiles.InitializeStructure();

            var t2 = new Thread(() =>
            {
                CoreFiles.InitializeStructure();
            });
            t2.IsBackground = true;
            t2.Start();
        }
        private void StartThreads()
        {
            HardwareInfo();
            var t1 = new Thread(() =>
            {
                StatusTracker();
            });
            t1.IsBackground = true;
            t1.Start();
            var t3 = new Thread(() =>
            {
                RuntimeReqChecks();
            });
            t3.IsBackground = true;
            t3.Start();
            var t4 = new Thread(() =>
            {
                MonitorMemory();
            });
            t4.IsBackground = true;
            t4.Start();
            var t5 = new Thread(() =>
            {
                UpdateServerStatLabels();
            });
            t5.IsBackground = true;
            t5.Start();
            lblServerStatus.ForeColor = Color.OrangeRed;
            lblServerStatus.Text = "Server idle...";
            lblCores.Text = Environment.ProcessorCount.ToString();
            lblCoreSpeed.Text = $"{baseSpeed}GHz (Max {maxSpeed}GHz)";
            lblRAM.Text = $"{ramSize / 1024 / 1024 / 1024}GB";
        }
        private void RuntimeReqChecks()
        {
            if (InvokeRequired)
            {
                Invoke(RuntimeReqChecks);
                return;
            }
            Debug.WriteLine("Checking requirements...");
            var reqs = new RequirementChecker();
            var cplusres = reqs.VisualcCheck();
            var steam = reqs.SteamPresent();
            bool allGood = false;
            if (!cplusres)
            {
                lblcplusplus.ForeColor = Color.OrangeRed;
                lblcplusplus.Font = new Font(lblcplusplus.Font, FontStyle.Bold);
                lblcplusplus.Text = "Not Installed - prompt on start";
            }
            else
            {
                lblcplusplus.ForeColor = Color.Green;
                lblcplusplus.Text = "Installed";
            }
            if (!steam)
            {
                lblSteamClient.ForeColor = Color.OrangeRed;
                lblSteamClient.Font = new Font(lblSteamClient.Font, FontStyle.Bold);
                lblSteamClient.Text = "Installs with server"; // Eventually we'll automate install or add button option
            }
            else
            {
                lblSteamClient.ForeColor = Color.Green;
                lblSteamClient.Text = "Installed";
            }

            while (!allGood)
            {
                bool cplusgood = false;
                bool steamgood = false;
                if (!cplusres)
                {
                    lblcplusplus.ForeColor = Color.OrangeRed;
                    lblcplusplus.Font = new Font(lblcplusplus.Font, FontStyle.Bold);
                    lblcplusplus.Text = "Not Installed - prompt on start";
                }
                else
                {
                    lblcplusplus.ForeColor = Color.Green;
                    lblcplusplus.Text = "Installed";
                    cplusgood = true;
                }
                if (!steam)
                {
                    lblSteamClient.ForeColor = Color.OrangeRed;
                    lblSteamClient.Font = new Font(lblSteamClient.Font, FontStyle.Bold);
                    lblSteamClient.Text = "Installs with server"; // Eventually we'll automate install or add button option
                }
                else
                {
                    lblSteamClient.ForeColor = Color.Green;
                    lblSteamClient.Text = "Installed";
                    steamgood = true;
                }
                Debug.WriteLine("Waiting for requirements to be met...");
                Thread.Sleep(1000);
                if (cplusgood && steamgood) allGood = true; break;
            }
        }
        private void HardwareInfo()
        {
            // Clock speeds return kinda weird - https://stackoverflow.com/questions/6923763/how-to-get-cpu-frequency-in-c-sharp
            ramSize = new ComputerInfo().TotalPhysicalMemory;
            using (ManagementObject Mo = new ManagementObject("Win32_Processor.DeviceID='CPU0'"))
            {
                var b = (uint)(Mo["CurrentClockSpeed"]) / 1000.0;
                var m = (uint)(Mo["MaxClockSpeed"]) / 1000.0;
                baseSpeed = b.ToString("0.0");
                maxSpeed = m.ToString("0.0");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            btnPendingSettingsChange.Visible = false;
            CheckRunningPriv();
            if (manSet.FirstRun()) SysPrep(); // Need to run this first to setup folders for logs
            else manSet.LoadManagerSettings();
            if (manSet.GameSettingsPresent())
            {
                CoreFiles.LoadGameServerSettings();
                CoreFiles.LoadGameServerStatusSettings();
                CoreFiles.LoadRebootOption();
            }            
            StartThreads();
            UpdateTitle();
            Logger.Log($"Tool Started | Current Dir: {Environment.CurrentDirectory}", LogType.Info);
            Logger.Log($"Server Dir: {ManagerGlobalTracker.serverPath}", LogType.Info);

        }
        private void CheckRunningPriv()
        {
            // TODO: currently only can check if user is admin NOT if the program was ran withadmin rights
            // I'll come back to this eventually for a new method to test if running with elevated privs
            if (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                // running as admin - process priority can be changed
                lblIsAdmin.ForeColor = Color.Green;
                lblIsAdmin.Text = "Running as admin - able to update process priority";
                btnChangeProcPrior.Enabled = true;

            }
            else
            {
                // running as normal priv - process priority cannot be changed
                lblIsAdmin.Text = "Running as normal user - change proccess priority disabled";
                btnChangeProcPrior.Enabled = false;
                btnChangeProcPrior.Text = "Change Server Process Priority (NOT ADMIN)";
            }
        }
        private void UpdateTitle(bool update = false)
        {
            if (InvokeRequired)
            {
                Invoke(UpdateTitle);
                return;
            }

            if (update)
            {
                this.Text = $"The Isle Evirma Server Manager - v{Properties.Settings.Default.version} | Windows {Environment.OSVersion.Version.Major} | UPDATE AVAILABLE ON GITHUB!";
            }
            else
            {
                var up = new UpdateChecker();
                if (up.ManagerUpdate())
                {
                    // Not newest compiled version compared to Github release tag
                    Logger.Log("Manager Update Available!", LogType.Info);
                    this.Text = $"The Isle Evirma Server Manager - v{Properties.Settings.Default.version} | Windows {Environment.OSVersion.Version.Major} | UPDATE AVAILABLE ON GITHUB!";
                }
                else
                {
                    this.Text = $"The Isle Evirma Server Manager - v{Properties.Settings.Default.version} | Windows {Environment.OSVersion.Version.Major}";
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void StatusTracker()
        {
            while (ManagerGlobalTracker.IsRunning)
            {
                //UpdateStatusLabel();                
                var fon = new Font(lblServerStatus.Font, FontStyle.Regular);
                switch (ManagerGlobalTracker.CurrentStatus)
                {
                    case ManagerStatus.idle:
                        if (lblServerStatus.Text != "Server idle...")
                        {
                            fon = new Font(lblServerStatus.Font, FontStyle.Regular);
                            lblServerStatus.Font = fon;
                            lblServerStatus.ForeColor = Color.OrangeRed;
                            lblServerStatus.Text = "Server idle...";
                        }
                        break;
                    case ManagerStatus.downloadingSteamCMD:
                        if (lblServerStatus.Text != "Downloading SteamCMD...")
                        {
                            fon = new Font(lblServerStatus.Font, FontStyle.Regular);
                            lblServerStatus.Font = fon;
                            lblServerStatus.ForeColor = Color.DarkCyan;
                            lblServerStatus.Text = "Downloading SteamCMD...";
                        }
                        break;
                    case ManagerStatus.downloadingServerFiles:
                        if (lblServerStatus.Text != "Downloading server files...")
                        {
                            fon = new Font(lblServerStatus.Font, FontStyle.Regular);
                            lblServerStatus.Font = fon;
                            lblServerStatus.ForeColor = Color.DarkCyan;
                            lblServerStatus.Text = "Downloading server files...";
                        }
                        break;
                    case ManagerStatus.startingServer:
                        if (lblServerStatus.Text != "Starting server...")
                        {
                            fon = new Font(lblServerStatus.Font, FontStyle.Bold);
                            lblServerStatus.Font = fon;
                            lblServerStatus.ForeColor = Color.GreenYellow;
                            lblServerStatus.Text = "Starting server...";
                        }
                        break;
                    case ManagerStatus.stoppingServer:
                        if (lblServerStatus.Text != "Stopping server...")
                        {
                            fon = new Font(lblServerStatus.Font, FontStyle.Bold);
                            lblServerStatus.Font = fon;
                            lblServerStatus.ForeColor = Color.YellowGreen;
                            lblServerStatus.Text = "Stopping server...";
                        }
                        break;
                    case ManagerStatus.error:
                        if (lblServerStatus.Text != "Error halted...CHECK LOGS")
                        {
                            fon = new Font(lblServerStatus.Font, FontStyle.Underline);
                            lblServerStatus.Font = fon;
                            lblServerStatus.ForeColor = Color.Red;
                            lblServerStatus.Text = "Error halted...CHECK LOGS";
                        }
                        break;
                    case ManagerStatus.serverRunning:
                        lblServerStatus.ForeColor = Color.SpringGreen;
                        fon = new Font(lblServerStatus.Font, FontStyle.Bold);
                        lblServerStatus.Font = fon;
                        lblServerStatus.Text = "Server running!";
                        break;
                    default:
                        if (lblServerStatus.Text != "Server idle...")
                        {
                            fon = new Font(lblServerStatus.Font, FontStyle.Regular);
                            lblServerStatus.Font = fon;
                            lblServerStatus.ForeColor = Color.OrangeRed;
                            lblServerStatus.Text = "Server idle...";
                        }
                        break;
                }


                Thread.Sleep(1000);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoreFiles.SaveManagerSettings();
            Environment.Exit(0);
            Application.Exit(); // Force any hanging threads close I guess
        }

        private void steamCMDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.downloadingSteamCMD);
                new BinaryDownloader().DownloadSteamCMD();
                new SteamCMDControl().InitializeTool();
                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.idle);
            }).Start();
        }



        private void theIsleServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                ManagerGlobalTracker.CurrentStatus = ManagerStatus.downloadingServerFiles;
                new SteamCMDControl().InstallIsleServer();
                ManagerGlobalTracker.CurrentStatus = ManagerStatus.idle;
            }).Start();

        }
        private void UpdateMemLabel(decimal data, double freeGB, decimal cpu)
        {
            if (InvokeRequired)
            {
                Invoke(UpdateMemLabel, data, freeGB, cpu);
                return;
            }
            lblMemUsage.Text = $"RAM Free: {data}% ({freeGB}GB) | CPU {cpu}%";
        }
        private void MonitorMemory()
        {
            while (refreshResourcesToolStripMenuItem.Checked)
            {
                UpdateMemLabel(HardwareData.FreeCompMemory(), HardwareData.RamFree(), Math.Round(HardwareData.CompCPUUsage(), 1));
                Thread.Sleep(ManagerGlobalTracker.resourceRefreshInt);
            }
        }

        private void refreshResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (refreshResourcesToolStripMenuItem.Checked)
            {
                refreshResourcesToolStripMenuItem.Checked = false;
            }
            else
            {
                refreshResourcesToolStripMenuItem.Checked = true;
                var memt1 = new Thread(() => { MonitorMemory(); });
                memt1.IsBackground = true;
                memt1.Start();
            }
        }

        private void btnServerStatsRefresh_Click(object sender, EventArgs e)
        {
            if (btnServerStatsRefresh.Checked)
            {
                btnServerStatsRefresh.Checked = false;
            }
            else
            {
                btnServerStatsRefresh.Checked = true;
                var statst = new Thread(() => { UpdateServerStats(); });
                statst.IsBackground = true;
                statst.Start();
            }
        }
        private void UpdateServerStats()
        {
            while (btnServerStatsRefresh.Checked)
            {


                Thread.Sleep(ManagerGlobalTracker.serverStatsRefreshInt);
            }
        }
        private void UpdateServerStatLabels()
        {
            if (InvokeRequired)
            {
                Invoke(UpdateServerStatLabels);
                return;
            }
            if (GameServerSettings.GameIniState.AdminSteamIDs.Count != 0) lblAdminCount.Text = GameServerSettings.GameIniState.AdminSteamIDs.Count.ToString();
            if (GameServerSettings.GameIniState.WhitelistIDs.Count != 0) lblWhitelistCount.Text = GameServerSettings.GameIniState.WhitelistIDs.Count.ToString();
            if (GameServerSettings.GameIniState.VIPs.Count != 0) lblVIPCount.Text = GameServerSettings.GameIniState.VIPs.Count.ToString();
            lblPlayerDataCount.Text = ServerAnalytics.PlayerDataCount().ToString();
        }

        private void managerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerSettings manSettings = new ManagerSettings();
            manSettings.ShowDialog(this);
        }

        private void steamClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ManagerGlobalTracker.isleServerInstalled) MessageBox.Show("You must install the game server first...");
            else
            {
                Logger.Log("Copying required Steam DLLs...", LogType.Info);
                if (!CoreFiles.CopyDLLs()) Logger.Log("Failed to copy Steam DLLs, please do manually and report issue on Github", LogType.Error);
                Logger.Log("DLLs copied!", LogType.Info);
            }
        }

        private void steamClientWhatGivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The server will not process clients connecting without Steam being installed. It should be as simple as a missing DLL needed somewhere in the server root but cant find anything about that.\nSo for a workaround installing the steam client completely fixes this issue and allows users to connect successfully.\n\nKnow the proper fix for this? Please post it on the project's github!", "Why the heck do I have to install the Steam client for a server?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/Crash0v3r1de/the-isle-evrima-manager");
        }

        private void configureRCONTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRCONTasks rTasks = new frmRCONTasks();
            rTasks.ShowDialog(this);
        }

        private void configureRCONConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRCONSettings rconSettings = new frmRCONSettings();
            rconSettings.ShowDialog(this);
        }

        private void btnStartServerUI_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(GameServerSettings.GameIniSession.ServerName))
            {
                // Fresh start
                PromptForSetup();
            }
            else
            {
                GameServer.StartServer();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void changeServerDirectoryLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromptServerDir();
        }

        private void PromptServerDir()
        {
            FolderBrowserDialog dir = new FolderBrowserDialog();
            dir.Tag = "Select the directory where the server files will be installed";
            dir.ShowDialog();
            while (true)
            {
                // quick loop to ensure instal is not on the root of a drive directly
                DirectoryInfo d = new DirectoryInfo(dir.SelectedPath);
                if (d.Parent == null) { MessageBox.Show("Steam cannot install directly onto a drive, please create a folder to use."); dir.ShowDialog(); }
                else break;
            }
            var newPath = dir.SelectedPath;
            UpdateGameServerPaths(newPath);
            CoreFiles.SaveManagerSettings();
            CoreFiles.PrcoessServerPathMove(newPath);
            Logger.Log($"Changed server directory to {newPath}", LogType.Info);
        }
        private void StopServerGracefully(bool applyingUpdate = false)
        {
            if (applyingUpdate)
            {
                GameServer.StopGracefully();
            }
            else
            {
                var res = MessageBox.Show("Auto restart is enabled, disable and fully stop the server?", "Auto Restart Enabled", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes) GameServerStatusTracker.RestartProcessOnFail = false;
                GameServer.StopGracefully();
            }
        }
        private void StopServerForcefully()
        {
            var res = MessageBox.Show("Auto restart is enabled, disable and fully stop the server?", "Auto Restart Enabled", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes) GameServerStatusTracker.RestartProcessOnFail = false;
            GameServer.StopForcefully();
        }

        private void btnUIStopServerGraceful_Click(object sender, EventArgs e)
        {
            StopServerGracefully();
        }

        private void btnStartIsleServer_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(GameServerSettings.GameIniSession.ServerName))
            {
                // Fresh start
                PromptForSetup();
            }
            else
            {
                GameServer.StartServer();
            }
        }

        private void btnStopIsleServer_Click(object sender, EventArgs e)
        {
            StopServerGracefully();
        }

        private void btnForceStopIsleServer_Click(object sender, EventArgs e)
        {
            StopServerForcefully();
        }

        private void btnForceStopUI_Click(object sender, EventArgs e)
        {
            StopServerForcefully();
        }

        private void UpdateGameServerPaths(string rootDir)
        {
            // TODO: Not ideal but can redo later
            ManagerGlobalTracker.customServerDir = true;
            ManagerGlobalTracker.serverPath = rootDir;
            ManagerGlobalTracker.dllDir = rootDir + @"\TheIsle\Binaries\Win64\";
            ManagerGlobalTracker.serverExe = rootDir + @"\TheIsleServer.exe";
            ManagerGlobalTracker.serverCoreExe = rootDir + @"\TheIsle\Binaries\Win64\TheIsleServer-Win64-Shipping.exe";
            CoreFiles.SaveManagerSettings();
            CoreFiles.SaveEngineINI();
            CoreFiles.SaveGameINI();
        }

        #region Public Methods
        /// <summary>
        /// Allow outside threads/methods to append to the console
        /// </summary>
        /// <param name="entry">string of message to append</param>
        public static void AppendConsoleEntry(string entry)
        {
            // Really unsure what memory usage will look like overtime
            // Eventually I'll add a code to check usage . xxxMB and reset textbox
            if (Application.OpenForms["Form1"] is Form1 form)
            {
                if (form.txtConsole.InvokeRequired)
                {
                    form.txtConsole.Invoke(new Action<string>(AppendConsoleEntry), entry);
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(entry))
                    {
                        // TODO: add method for alert strings to be notified on
                        if (!entry.Contains("Redirect"))
                        { // ignore .NET redirect messages
                            form.txtConsole.AppendText(entry + "\n");
                            form.txtConsole.Refresh();
                            form.txtConsole.SelectionStart = form.txtConsole.Text.Length;
                            form.txtConsole.ScrollToCaret();
                        }
                    }
                }
            }
        }
        #endregion

        private void adminsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerAdmins admins = new ServerAdmins();
            admins.ShowDialog(this);
            if (GameServerSettings.PendingSettingsApply)
            {
                var result = MessageBox.Show("New game settings pending...restart server to apply?", "Pending Game Changes", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.stoppingServer);
                    GameServer.StopGracefully();
                    while (GameServer.ServerRunning)
                    {
                        Thread.Sleep(1500); // Wait for exit
                    }
                    ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.savingSettings);
                    CoreFiles.SaveGameINI();
                    CoreFiles.SaveGameServerSettings();
                    GameServerSettings.PendingSettingsApply = false;
                    ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.startingServer);
                    GameServer.StartServer();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Gracefully exit server, save settings to Game.ini in ini format, save settings into our own JSON and start the server again
            StopServerGracefully(true);
            ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.stoppingServer);
            new Thread(() =>
            {
                while (GameServer.ServerRunning)
                {
                    Thread.Sleep(1200); // Wait for exit
                }
                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.savingSettings);
                CoreFiles.SaveGameINI();
                CoreFiles.SaveGameServerSettings();
                GameServerSettings.PendingSettingsApply = false;
                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.startingServer);
                GameServer.StartServer();
                SettingsApplied();
            }).Start();
        }

        private void SettingsApplied()
        {
            if (InvokeRequired)
            {
                Invoke(SettingsApplied);
                return;
            }
            btnPendingSettingsChange.Enabled = false;
            btnPendingSettingsChange.Visible = false;
        }

        private void troubleshootingIssuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Load wiki page with random tips people find and report on Discord as well as my findings
            // weird issue that I think is specific to Windows Server OS environments - https://discord.com/channels/401464048610312193/401466217744957460/1343858327012118548

        }

        private void PromptForSetup()
        {
            new ManagerSettings().ShowDialog(this);
            CoreFiles.SaveManagerSettings();

            new frmGameServerSettings().ShowDialog(this);
            if (GameServerSettings.GameIniSession.EnableRCON)
            {
                new frmRCONSettings().ShowDialog(this);
                new frmRCONTasks().ShowDialog(this);
                CoreFiles.SaveRCONSettings();
                CoreFiles.SaveRCONTasks();
            }
            var result = MessageBox.Show("Do you want to change the game servers install location?\n*it installs in the server folder of the root of this tool*", "Change Server Install Path?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) PromptServerDir();
            new Thread(() =>
            {
                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.savingSettings);
                CoreFiles.SaveGameServerSettings();
                CoreFiles.SaveGameServerStatusSettings();
                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.downloadingSteamCMD);
                new BinaryDownloader().DownloadSteamCMD();
                var steam = new SteamCMDControl();
                steam.InitializeTool();
                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.downloadingServerFiles);
                steam.InstallIsleServer();
                CoreFiles.CopyDLLs();
                CoreFiles.SaveEngineINI();
                CoreFiles.SaveGameINI();
                GameServerSettings.PendingSettingsApply = false;
                ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.startingServer);
                GameServer.StartServer();
            }).Start();
        }

        private void btnVerifyIsleServer_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                new SteamCMDControl().VerifyIsleServer();
            }).Start();
        }

        private void generalServerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Make modular method for these calls
            new frmGameServerSettings().ShowDialog(this);
            if (GameServerSettings.PendingSettingsApply)
            {
                var result = MessageBox.Show("New game settings pending...restart server to apply?", "Pending Game Changes", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.stoppingServer);
                    StopServerGracefully(true);
                    while (GameServer.ServerRunning)
                    {
                        Thread.Sleep(1500); // Wait for exit
                    }
                    ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.savingSettings);
                    CoreFiles.SaveGameINI();
                    CoreFiles.SaveGameServerSettings();
                    GameServerSettings.PendingSettingsApply = false;
                    ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.startingServer);
                    GameServer.StartServer();
                }
                else
                {
                    btnPendingSettingsChange.Visible = true;
                    btnPendingSettingsChange.Enabled = true;
                }
            }
        }

        private void vIPsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Make modular method for these calls
            new ServerVIPS().ShowDialog(this);
            if (GameServerSettings.PendingSettingsApply)
            {
                var result = MessageBox.Show("New game settings pending...restart server to apply?", "Pending Game Changes", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.stoppingServer);
                    GameServer.StopGracefully();
                    while (GameServer.ServerRunning)
                    {
                        Thread.Sleep(1500); // Wait for exit
                    }
                    ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.savingSettings);
                    CoreFiles.SaveGameINI();
                    CoreFiles.SaveGameServerSettings();
                    GameServerSettings.PendingSettingsApply = false;
                    ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.startingServer);
                    GameServer.StartServer();
                }
            }
        }

        private void whitelistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Make modular method for these calls
            new ServerWhitelist().ShowDialog(this);
            if (GameServerSettings.PendingSettingsApply)
            {
                var result = MessageBox.Show("New game settings pending...restart server to apply?", "Pending Game Changes", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.stoppingServer);
                    GameServer.StopGracefully();
                    while (GameServer.ServerRunning)
                    {
                        Thread.Sleep(1500); // Wait for exit
                    }
                    ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.savingSettings);
                    CoreFiles.SaveGameINI();
                    CoreFiles.SaveGameServerSettings();
                    GameServerSettings.PendingSettingsApply = false;
                    ManagerStatusHandler.UpdateManagerStatus(ManagerStatus.startingServer);
                    GameServer.StartServer();
                }
            }
        }

        private void checkForManagerUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var up = new UpdateChecker();
            if (up.ManagerUpdate())
            {
                // Not newest compiled version compared to Github release tag
                Logger.Log("Manager Update Available!", LogType.Info);
                UpdateTitle(true);
            }
        }

        private void btnAutoRestartGameServer_Click(object sender, EventArgs e)
        {
            if (btnAutoRestartGameServer.Checked)
            {
                GameServerStatusTracker.RestartProcessOnFail = true;
            }
            else
            {
                GameServerStatusTracker.RestartProcessOnFail = false;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnChangeProcPrior_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("This will set the game server process to highest priority, you're sure?", "Priority Bump", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var proc = Process.GetProcessesByName("TheIsleServer-Win64-Shipping.exe");
                proc[0].PriorityClass = ProcessPriorityClass.RealTime;
            }
        }

        // ...

        private void btnTestRCONConnection_Click(object sender, EventArgs e)
        {
            var ip = RCONGlobalTracker.rconHost;
            var port = RCONGlobalTracker.rconPort;
            string pass = RCONGlobalTracker.rconPassword;
            if (!RCONGlobalTracker.rconEnabled) {
                ip = Interaction.InputBox("Enter RCON server address:", "RCON Connection Test", "localhost"); // Only VB.NET object for some reason
                port = Interaction.InputBox("Enter RCON server port:", "RCON Connection Test", "8888");
                pass = Interaction.InputBox("Enter RCON server password:", "RCON Connection Test", "");
            }
            new Task(async () => await RCONCore.ConnectAsync(ip, port, pass)).Start();
            while (!RCONGlobalTracker.isConnected) {
                Thread.Sleep(900);
            }
            RCONCore.SendCommand(RCONType.Announcement,"Test Announcement");
            Console.WriteLine("RCON Connection Test Complete");
        }
    }
}
