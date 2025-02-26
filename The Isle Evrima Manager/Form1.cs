using Microsoft.VisualBasic.Devices;
using System.Configuration;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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

        public Form1()
        {
            InitializeComponent();
        }
        private void SysPrep()
        {
            if (InvokeRequired) {
                Invoke(SysPrep);
                return;
            }
            CoreFiles.InitializeStructure();
            var t1 = new Thread(() =>
            {
                StatusTracker();
            });
            t1.IsBackground = true;
            t1.Start();
            var t2 = new Thread(() =>
            {
                CoreFiles.InitializeStructure();
            });
            t2.IsBackground = true;
            t2.Start();
            HardwareInfo();
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
            SysPrep(); // Need to run this first to setup folders for logs
            UpdateTitle();
            Logger.Log($"Tool Started | Current Dir: {Environment.CurrentDirectory}", LogType.Info);

        }
        private void UpdateTitle() {
            if (InvokeRequired) {
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
            while (ManagerStatusTracker.IsRunning)
            {
                //UpdateStatusLabel();
                lblServerStatus.ForeColor = Color.Black;

                switch (ManagerStatusTracker.CurrentStatus)
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
            Environment.Exit(0);
        }

        private void steamCMDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                ManagerStatusTracker.CurrentStatus = ManagerStatus.downloadingSteamCMD;
                new BinaryDownloader().DownloadSteamCMD();
                new SteamCMDControl().InitializeTool();
                ManagerStatusTracker.CurrentStatus = Enums.ManagerStatus.idle;
            }).Start();
        }

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

        private void theIsleServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                ManagerStatusTracker.CurrentStatus = ManagerStatus.downloadingServerFiles;
                new SteamCMDControl().InstallIsleServer();
                ManagerStatusTracker.CurrentStatus = ManagerStatus.idle;
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
                Thread.Sleep(ManagerStatusTracker.resourceRefreshInt);
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


                Thread.Sleep(ManagerStatusTracker.serverStatsRefreshInt);
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
            new Thread(() =>
            {
                Logger.Log("Downloading Steam Client...", LogType.Info);
                new WebClient().DownloadFile("https://cdn.fastly.steamstatic.com/client/installer/SteamSetup.exe", $"{ManagerStatusTracker.tmpPath}\\SteamSetup.exe");
                ProcessStartInfo args = new ProcessStartInfo($"{ManagerStatusTracker.tmpPath}\\SteamSetup.exe");
                args.Arguments = "/S"; // add silent install option
                Process installer = new Process();
                installer.StartInfo = args;
                Logger.Log("Installing Steam Client...", LogType.Info);
                installer.Start();
                installer.WaitForExit(); // Unsure of exit code indicating installed correctly - I'll log it
                Logger.Log($"Steam Client installed(?) - Exit code {installer.ExitCode}", LogType.Info);
                ManagerStatusTracker.steamClientInstalled = true;
                File.Delete($"{ManagerStatusTracker.tmpPath}\\SteamSetup.exe");
            }).Start();
        }

        private void steamClientWhatGivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The server will not process clients connecting without Steam being installed. It should be as simple as a missing DLL needed somewhere in the server root but cant find anything about that.\nSo for a workaround installing the steam client completely fixes this issue and allows users to connect successfully.\n\nKnow the proper fix for this? Please post it on the project's github!", "Why the heck do I have to install the Steam client for a server?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/Crash0v3r1de/the-isle-evrima-manager");
        }
    }
}
