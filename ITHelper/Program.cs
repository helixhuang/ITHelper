using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;

namespace cn.antontech.ITHelper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (System.Environment.OSVersion.Version.Major < 6)
            {
                MessageBox.Show("此应用不支持Windows XP");
            }
            else
            {
                string baseDir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ITHelper");
                if(!System.IO.Directory.Exists(baseDir))
                {
                    System.IO.Directory.CreateDirectory(baseDir);
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }

        }
    }
}
