using Microsoft.VisualBasic.Devices;
using System.Management;
using System.Text;
using The_Isle_Evrima_Manager.IO;

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
            new Thread(() => {
                CoreFiles.InitializeStructure();
            }).Start();
            HardwareInfo();


            lblServerStatus.ForeColor = Color.OrangeRed;
            lblServerStatus.Text = "Server idle...";
            lblCores.Text = Environment.ProcessorCount.ToString();
            lblCoreSpeed.Text = $"{baseSpeed}GHz (Max {maxSpeed}GHz)";            
            lblRAM.Text = $"{ramSize / 1024 / 1024 / 1024}GB";
        }
        private void HardwareInfo()
        {
            ramSize = new ComputerInfo().TotalPhysicalMemory;
            using (ManagementObject Mo = new ManagementObject("Win32_Processor.DeviceID='CPU0'"))
            {
                var b = (uint)(Mo["CurrentClockSpeed"])/1000.0;
                var m = (uint)(Mo["MaxClockSpeed"])/1000.0;
                baseSpeed = b.ToString("0.0");
                maxSpeed = m.ToString("0.0");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            SysPrep();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
