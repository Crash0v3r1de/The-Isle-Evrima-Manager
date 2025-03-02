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
            var t4 = new Thread(() =>
            {
                MonitorMemory();
            });
            t4.IsBackground = true;
            t4.Start();
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
                lblSteamClient.Text = "Install via Tools Menu"; // Eventually we'll automate install or add button option
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
                    lblSteamClient.Text = "Install via Tools Menu"; // Eventually we'll automate install or add button option
                }
                else
                {
                    lblSteamClient.ForeColor = Color.Green;
                    lblSteamClient.Text = "Installed";
                    steamgood = true;
                }
                Debug.WriteLine("Waiting for requirements to be met...");
                Thread.Sleep(1000);
                if (cplusgood && steamgood) break; allGood = true;
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
            // Might be usable, look into later - really not a big priority at the moment
            //PerformanceCounter cpuCounter = new PerformanceCounter("Processor Information", "% Processor Performance", "_Total");
            //double cpuValue = cpuCounter.NextValue();
            //foreach (ManagementObject obj in new ManagementObjectSearcher("SELECT *, Name FROM Win32_Processor").Get())
            //{
            //    double maxSpeed = Convert.ToDouble(obj["MaxClockSpeed"]) / 1000;
            //    double turboSpeed = maxSpeed * cpuValue / 100;
            //    var data = string.Format("{0} Running at {1:0.00}Ghz, Turbo Speed: {2:0.00}Ghz", obj["Name"], maxSpeed, turboSpeed);
            //    Debug.WriteLine(data);
            //}
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            btnPendingSettingsChange.Visible = false;
            CheckRunningPriv();
            if (manSet.FirstRun()) SysPrep(); // Need to run this first to setup folders for logs
            else manSet.LoadManagerSettings();
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
        private void UpdateTitle()
        {
            if (InvokeRequired)
            {
                Invoke(UpdateTitle);
                return;
            }

            // This used to be ALOT easier/simpler but .NET Core gunna .NET Core
            Assembly ass = Assembly.GetExecutingAssembly();
            FileVersionInfo fv = FileVersionInfo.GetVersionInfo(ass.Location);
            this.Text = $"The Isle Evirma Server Manager - v{fv.FileVersion} | Windows {Environment.OSVersion.Version.Major}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void StatusTracker()
        {
            while (ManagerGlobalTracker.IsRunning)
            {
                //UpdateStatusLabel();
                lblServerStatus.ForeColor = Color.Black;

                switch (ManagerGlobalTracker.CurrentStatus)
                {
                    case ManagerStatus.idle:
                        if (lblServerStatus.Text != "Server idle...") lblServerStatus.Text = "Server idle...";
                        break;
                    case ManagerStatus.downloadingSteamCMD:
                        if (lblServerStatus.Text != "Downloading SteamCMD...") lblServerStatus.Text = "Downloading SteamCMD...";
                        break;
                    case ManagerStatus.downloadingServerFiles:
                        if (lblServerStatus.Text != "Downloading server files...") lblServerStatus.Text = "Downloading server files...";
                        break;
                    case ManagerStatus.startingServer:
                        if (lblServerStatus.Text != "Starting server...") lblServerStatus.Text = "Starting server...";
                        break;
                    case ManagerStatus.stoppingServer:
                        if (lblServerStatus.Text != "Stopping server...") lblServerStatus.Text = "Stopping server...";
                        break;
                    case ManagerStatus.error:
                        if (lblServerStatus.Text != "Error halted...CHECK LOGS")
                        {
                            lblServerStatus.ForeColor = Color.Red;
                            lblServerStatus.Text = "Error halted...CHECK LOGS";
                        }
                        break;
                    case ManagerStatus.serverRunning:
                        if (lblServerStatus.Text != "Server running!")
                        {
                            lblServerStatus.ForeColor = Color.Green;
                            lblServerStatus.Text = "Server running!";
                        }
                        break;
                    default:
                        if (lblServerStatus.Text != "Server idle...") lblServerStatus.Text = "Server idle...";
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
        private void UpdateServerStatLabels(string plrDataCnt)
        {
            if (InvokeRequired)
            {
                Invoke(UpdateServerStatLabels, plrDataCnt);
                return;
            }
            lblPlayerDataCount.Text = plrDataCnt;
        }

        private void managerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerSettings manSettings = new ManagerSettings();
            manSettings.Show();
        }

        private void steamClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ManagerGlobalTracker.isleServerInstalled) MessageBox.Show("You must install the game server first...");
            else
            {
                Logger.Log("Copying required Steam DLLs...", LogType.Info);
                if (!CoreFiles.CopyDLLs()) Logger.Log("Failed to copy Steam DLLs, please do manually and report issue on Github", LogType.Error);
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
            rTasks.ShowDialog();
        }

        private void configureRCONConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRCONSettings rconSettings = new frmRCONSettings();
            rconSettings.ShowDialog();
        }

        private void btnStartServerUI_Click(object sender, EventArgs e)
        {
            GameServer.StartServer();
        }

        private void PromptFreshInstallSettings()
        {
            // Open all settings windows, parse to JSON as well as INI after install
            // set install to true
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void changeServerDirectoryLocationToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void btnUIStopServerGraceful_Click(object sender, EventArgs e)
        {
            GameServer.StopGracefully();
        }

        private void btnStartIsleServer_Click(object sender, EventArgs e)
        {
            GameServer.StartServer();
        }

        private void btnStopIsleServer_Click(object sender, EventArgs e)
        {
            GameServer.StopGracefully();
        }

        private void btnForceStopIsleServer_Click(object sender, EventArgs e)
        {
            GameServer.StopForcefully();
        }

        private void btnForceStopUI_Click(object sender, EventArgs e)
        {
            GameServer.StopForcefully();
        }

        private void UpdateGameServerPaths(string rootDir)
        {
            // TODO: Not ideal but can redo later
            ManagerGlobalTracker.customServerDir = true;
            ManagerGlobalTracker.serverPath = rootDir;
            ManagerGlobalTracker.dllDir = rootDir + @"\TheIsle\Binaries\Win64\";
            ManagerGlobalTracker.serverExe = rootDir + @"\TheIsleServer.exe";
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
        #endregion

        private void adminsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerAdmins admins = new ServerAdmins();
            admins.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Gracefully exit server, save settings to Game.ini in ini format, save settings into our own JSON and start the server again

        }
    }
}
