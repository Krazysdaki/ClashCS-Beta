using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashCS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //var p = (Process.GetCurrentProcess()).ToString();
            //MessageBox.Show(p.ToString());
            Process[] self = Process.GetProcessesByName(Application.ProductName);
            if (self.Length > 1)
            {
                Task tip = new Task(() => MessageBox.Show("Another ClashCS-Beta is running!...", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error));
                tip.Start();
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
            Application.Run(new MainForm());
        }

    }
}
