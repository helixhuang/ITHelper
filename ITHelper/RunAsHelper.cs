using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace ITHelper
{
    public class RunAsHelper
    {
        public static bool IsRunAsAdmin()
        {
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            WindowsPrincipal wp = new WindowsPrincipal(wi);

            return wp.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void RunAsAdmin()
        {
            // It is not possible to launch a ClickOnce app as administrator directly,
            // so instead we launch the app as administrator in a new process.
            ProcessStartInfo processInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase);

            // The following properties run the new process as administrator
            processInfo.UseShellExecute = true;
            processInfo.Verb = "runas";

            // Start the new process
            try
            {
                Process.Start(processInfo);
            }
            catch (Exception)
            {
                // The user did not allow the application to run as administrator
                MessageBox.Show("对不起，当前用户不能够以管理员权限运行此应用程序");
            }

            // Shut down the current process
            Application.Exit();
        }
    }
}
