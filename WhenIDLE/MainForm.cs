using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhenIDLE
{
    public partial class MainForm : Form
    {
        private static Int64 trigger;
        private static int inactive;

        public MainForm()
        {
            InitializeComponent();

            #region auto start chkbx
            if (Registry.CurrentUser.OpenSubKey(StartupKey, true).GetValueNames().Contains(StartupValue))
            {
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
                chkbx_autoStart.Checked = true;
            }
            else
                chkbx_autoStart.Checked = false;
            #endregion

            #region set IDLE trigger value
            try
            {
                trigger = Convert.ToInt64(File.ReadLines("settings").First()); // gets the first line from file.
                tb_trigger.Text = trigger.ToString();
            }
            catch (Exception ex) { }
            #endregion
            #region set inactive value
            try
            {
                inactive = Convert.ToInt32(File.ReadLines("settings").ElementAtOrDefault(1)); // gets the first line from file.
                tb_inactiveTime.Text = inactive.ToString();
            }
            catch (Exception ex) { }
            #endregion
        }

        private int mouseIdleTime;
        private int x = MouseMovements.GetMyCusorPosX();
        private int y = MouseMovements.GetMyCusorPosY();
        private void timer_checkIDLE_Tick(object sender, EventArgs e)
        {
            if (x == MouseMovements.GetMyCusorPosX() && y == MouseMovements.GetMyCusorPosY())
            {
                mouseIdleTime++;
            }
            else
            {
                x = MouseMovements.GetMyCusorPosX();
                y = MouseMovements.GetMyCusorPosY();
            }

            decimal percentOccupied = 100 - ((decimal)PerformanceInfo.GetPhysicalAvailableMemoryInMiB() / (decimal)PerformanceInfo.GetTotalMemoryInMiB() * 100);
            if (trigger <= percentOccupied && Convert.ToInt32(tb_inactiveTime.Text) <= (mouseIdleTime/60))
            {
                #region start idle
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C Rundll32.exe advapi32.dll,ProcessIdleTasks";
                process.StartInfo = startInfo;
                process.Start();
                #endregion

                timer_checkIDLE.Stop();
                timer_restartCheck.Start();
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            timer_checkIDLE.Start();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            timer_checkIDLE.Stop();
        }

        #region auto start program when pc starts
        //Startup registry key and value
        private static readonly string StartupKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private static readonly string StartupValue = "WhenIDLE";
        private void chkbx_autoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_autoStart.Checked)
            {
                //Set the application to run at startup
                RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
                key.SetValue(StartupValue, Application.ExecutablePath.ToString());
            }
            else
                Registry.CurrentUser.OpenSubKey(StartupKey, true).DeleteValue(StartupValue);
        }
        #endregion

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void timer_restartCheck_Tick(object sender, EventArgs e)
        {
            if (x != MouseMovements.GetMyCusorPosX() && y != MouseMovements.GetMyCusorPosY())
            {
                timer_checkIDLE.Start();
                timer_restartCheck.Stop();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_setTrigger_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_trigger.Text) && !String.IsNullOrEmpty(tb_inactiveTime.Text))
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists("settings"))
                {
                    File.Delete("settings");
                }

                // Create a new file     
                using (FileStream fs = File.Create("settings"))
                {
                    // Add some text to file    
                    byte[] txt = new UTF8Encoding(true).GetBytes(tb_trigger.Text + "\n" + tb_inactiveTime.Text);
                    fs.Write(txt, 0, txt.Length);
                }

                MessageBox.Show("restart the app to apply new settings");
            }
            else
                MessageBox.Show("one of the properties isn't set.");
        }
    }

    public static class MouseMovements
    {
        public struct POINTAPI
        {
            public int x; public int y;
        }

        [DllImport("user32.dll")]
        public static extern int GetCursorPos(ref POINTAPI lpPoint);

        public static POINTAPI p = new POINTAPI();

        public static int GetMyCusorPosX()
        {
            GetCursorPos(ref p);
            return p.x;
        }
        public static int GetMyCusorPosY()
        {
            GetCursorPos(ref p);
            return p.y;
        }
    }

    public static class PerformanceInfo
    {
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);

        [StructLayout(LayoutKind.Sequential)]
        public struct PerformanceInformation
        {
            public int Size;
            public IntPtr CommitTotal;
            public IntPtr CommitLimit;
            public IntPtr CommitPeak;
            public IntPtr PhysicalTotal;
            public IntPtr PhysicalAvailable;
            public IntPtr SystemCache;
            public IntPtr KernelTotal;
            public IntPtr KernelPaged;
            public IntPtr KernelNonPaged;
            public IntPtr PageSize;
            public int HandlesCount;
            public int ProcessCount;
            public int ThreadCount;
        }

        public static Int64 GetPhysicalAvailableMemoryInMiB()
        {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
            {
                return Convert.ToInt64((pi.PhysicalAvailable.ToInt64() * pi.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }
        }

        public static Int64 GetTotalMemoryInMiB()
        {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
            {
                return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }
        }
    }
}
