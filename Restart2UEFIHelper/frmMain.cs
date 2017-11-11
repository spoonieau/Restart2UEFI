/*
 * Restar2UEFIHelper build 1.0.0.0
 * 
 * Healper exe need by Restart2UEFIAPP. The app luanches and passes args
 * to this helper, then the helper makes to calls to the OS.
 * 
 * https://github.com/spoonieau/Restart2UEFI
 * Written by SpoonieAU
 * Released under GPL3
 */


using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;


namespace Restart2UEFIHelper
{
    public partial class frmMain : Form
    {
        public class FirmwareType
        {
            [DllImport("kernel32.dll")]
            static extern bool GetFirmwareType(ref uint FirmwareType);

            public static uint GetFirmwareType()
            {
                uint firmwaretype = 0;
                if (GetFirmwareType(ref firmwaretype))
                    return firmwaretype;
                else
                    return 0;
            }
        }

        string[] args = Environment.GetCommandLineArgs();
        string fwType = "";

        public frmMain()
        {
            InitializeComponent();
        }

        private void firmWareUEFI()
        {   //args pass from fulltrustLuancher at pos 3
            switch (args.ElementAt(3))
            {
                case "/fwr":
                    try
                    {
                        //Start shutdown.exe pass args /s (shutdown) + /fw (set firmware flag) + /t 0 (no wait time)
                        Process firmwareShutdown = new Process();
                        firmwareShutdown.StartInfo.FileName = "shutdown.exe";
                        firmwareShutdown.StartInfo.Arguments = "/s /fw /t 0";
                        firmwareShutdown.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        firmwareShutdown.StartInfo.UseShellExecute = true;
                        firmwareShutdown.StartInfo.Verb = "runas";
                        firmwareShutdown.Start();
                    }
                    catch
                    {
                        MessageBox.Show("Unable to start shutdown process. Click OK to exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    break;

                case "/fws":
                    try
                    {
                        //Start shutdown.exe pass args /r (restart) + /fw (set firmware flag) + /t 0 (no wait time)
                        Process firmwareRestart = new Process();
                        firmwareRestart.StartInfo.FileName = "shutdown.exe";
                        firmwareRestart.StartInfo.Arguments = "/r /fw /t 0";
                        firmwareRestart.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        firmwareRestart.StartInfo.UseShellExecute = true;
                        firmwareRestart.StartInfo.Verb = "runas";
                        firmwareRestart.Start();
                    }
                    catch
                    {
                        MessageBox.Show("Unable to start restart process. Click OK to exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    break;
                    
            }

        }

        private void errorRetrive()
        {
            txtFirmware.Text ="Retrived fw type:" + fwType;
            txtArgs.Text = "Args passed: " + args.ElementAt(3);

            MessageBox.Show("UEFI type has returned as non UEFI, Application will now exit.", "Error Retrieving Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        private void errorNotUefi()
        {
            txtFirmware.Text = "Retrived fw type:" + fwType;
            txtArgs.Text = "Args passed: " + args.ElementAt(3);

            MessageBox.Show("Unable to retrive UEFI type, Application will now exit.", "Error Incorrect Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Get firmware return type FirmwareTypeUnknown  = 0, FirmwareTypeBios = 1, FirmwareTypeUefi = 2, FirmwareTypeMax = 3
            int fwareT = int.Parse(FirmwareType.GetFirmwareType().ToString());

            fwType = fwareT.ToString();

            try
            {

                
                switch (fwareT)
                {
                    case 0:
                        errorNotUefi();
                        break;

                    case 1:
                        errorNotUefi();
                        break;

                    case 2:

                        firmWareUEFI();
                        break;

                    case 3:
                        errorNotUefi();
                        break;

                    default:
                        errorRetrive();
                        break;
                }
            }
            catch
            {
                errorRetrive();
            }
        }
    }
}
