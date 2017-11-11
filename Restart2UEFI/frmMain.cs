/*
 * Restar2UEFI winforms build 1.0.0.0
 * 
 * https://github.com/spoonieau/Restart2UEFI
 * Written by SpoonieAU
 * Released under GPL3
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;

namespace Restart2UEFI
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
        string fwType = "";
        public frmMain()
        {
            InitializeComponent();

            this.Text = "Restart2UEFI(WinForms)" + (typeof(Program).GetTypeInfo().Assembly.GetName().Version).ToString();

            try
            {
                int fwareT = int.Parse(FirmwareType.GetFirmwareType().ToString());
                switch (fwareT)
                {
                    case 0:
                        errorNotUefi();
                        fwType = "0";
                        break;

                    case 1:
                        errorNotUefi();
                        fwType = "1";
                        break;

                    case 2:
                        firmWareUEFI();
                        break;

                    case 3:
                        errorNotUefi();
                        fwType = "3";
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

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Restart2UEFI(WinForms)" + (typeof(Program).GetTypeInfo().Assembly.GetName().Version).ToString() + Environment.NewLine +
                            "A App using inbult system functions to shutdown or restart you UEFI system to Firmware" + Environment.NewLine +
                            "Developed by SpoonieAU " + "https://github.com/spoonieau","Restart2UEFI",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void errorRetrive()
        {
            txtStatus.BackColor = Color.White;
            txtStatus.ForeColor = Color.Red;
            txtStatus.ReadOnly = true;
            txtStatus.Text = "Firmware type (" + fwType + "): UEFI Not Present";

            btnFirmware.Enabled = false;
            btnFirmwareRestart.Enabled = false;

            MessageBox.Show("An error has occurred trying to retrive Firmware Type", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void errorNotUefi()
        {
            txtStatus.BackColor = Color.White;
            txtStatus.ForeColor = Color.Red;
            txtStatus.Text = "FirmWare type (" + fwType + "): UEFI Not Present";

            btnFirmware.Enabled = false;
            btnFirmwareRestart.Enabled = false;

            MessageBox.Show("Firmware has not been retrieved as UEFI", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
        }

        private void firmWareUEFI()
        {
            txtStatus.BackColor = Color.White;
            txtStatus.ForeColor = Color.Green;
            txtStatus.ReadOnly = true;
            txtStatus.Text = "Firmware type (2): UEFI Present";
        }

        private void btnFirmware_Click(object sender, EventArgs e)
        {
            try
            {
                Process firmware = new Process();
                firmware.StartInfo.FileName = "shutdown.exe";
                firmware.StartInfo.Arguments = "/s /fw /t 0";
                firmware.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                firmware.Start();
                firmware.WaitForExit();

                //Process.Start("shutdown", "/fw /t 0");

                MessageBox.Show("Firmware Flag set", "Flag Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Failure to Set Firmware/Shutdown Flag" + Environment.NewLine
                        + "Application will now exit", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                endApp(); 
            }
        }

        private void btnFirmwareRestart_Click(object sender, EventArgs e)
        {
            try
            {
                Process firmwareRestart = new Process();
                firmwareRestart.StartInfo.FileName = "shutdown.exe";
                firmwareRestart.StartInfo.Arguments = "/r /fw /t 0";
                firmwareRestart.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                firmwareRestart.Start();

                //Process.Start("shutdown", "/r /fw /t 0");
            }
            catch
            {
                MessageBox.Show("Failure to Set Firmware/Restart Flag" + Environment.NewLine
                        + "Application will now exit", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void endApp()
        {
            Application.Exit();
        }
    }

}
