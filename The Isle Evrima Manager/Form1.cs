using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Management;
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
            CoreFiles.InitializeStructure();
            new Thread(() =>
            {
                StatusTracker();
            }).Start();
            new Thread(() =>
            {
                CoreFiles.InitializeStructure();
            }).Start();
            HardwareInfo();
            new Thread(() =>
            {
                RuntimeReqChecks();
            }).Start();
            new Thread(() =>
            {
                MonitorMemory();
            }).Start();

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
                lblSteamClient.Text = "Not Installed - manually install"; // Eventually we'll automate install or add button option
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
                    lblSteamClient.Text = "Not Installed - manually install"; // Eventually we'll automate install or add button option
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
            Logger.Log($"Tool Started | Current Dir: {Environment.CurrentDirectory}", LogType.Info);

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
                new Thread(() => { MonitorMemory(); }).Start();
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
                new Thread(() => { UpdateServerStats(); }).Start();
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
    }
}
