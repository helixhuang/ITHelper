using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RunasGui
{
    public class RunasHelper
    {
        public static void Runas(RunasObject setting)
        {
            try
            {
                char[] passwordChars = setting.GetPassword().ToCharArray();
                System.Security.SecureString securePassword = new System.Security.SecureString();

                foreach (char passChar in passwordChars)
                {
                    securePassword.AppendChar(passChar);
                }

                string[] loginInfo = new string[2];
                if (setting.UserName.Contains("\\"))
                {
                    // username was entered with a domain prefix. split and use.
                    loginInfo = setting.UserName.Split('\\');
                }
                else
                {
                    // username was not entered with a domain prefix. assume local machine. we can update the textbox to show that we're using this assumed value.
                    loginInfo[0] = setting.Domain ?? Environment.MachineName;
                    loginInfo[1] = setting.UserName;
                }

                ProcessStartInfo startInfo = new ProcessStartInfo(setting.ExeFile);
                startInfo.Domain = loginInfo[0];
                startInfo.UserName = loginInfo[1];
                startInfo.Password = securePassword;
                startInfo.UseShellExecute = false;
                startInfo.LoadUserProfile = true;
                startInfo.Verb = "runas";
                if (setting.Args != string.Empty)
                {
                    startInfo.Arguments = setting.Args;
                }

                Process objProcess = Process.Start(startInfo);

                if (objProcess != null)
                {
                    objProcess.EnableRaisingEvents = true;
                    objProcess.Exited += new EventHandler(myProcess_Exited);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void myProcess_Exited(object sender, System.EventArgs e)
        {
            //MessageBox.Show("You exited");
        }
    
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LogonUser(string lpszUserName, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);

        public delegate void RunAsDelegate();

        public static void RunAs(RunAsDelegate MethodToRunAs, string Username, string Password, string Domain)
        {
            IntPtr imp_token;
            WindowsIdentity wid_admin = null;
            WindowsImpersonationContext wic = null;
            try
            {
                if (LogonUser(Username, string.IsNullOrEmpty(Domain) ? "." : Domain, Password, 9, 0, out imp_token))
                {
                    //the impersonation suceeded
                    wid_admin = new WindowsIdentity(imp_token);
                    wic = wid_admin.Impersonate();
                    //run the delegate method
                    MethodToRunAs();
                }
                else
                {
                    throw new Exception(string.Format("Could not impersonate user {0} in domain {1} with the specified password.", Username, Domain));
                }
            }
            catch (Exception se)
            {
                int ret = Marshal.GetLastWin32Error();
                if (wic != null) wic.Undo();
                throw new Exception("Error code: " + ret.ToString(), se);
            }
            finally
            {
                //revert to self
                if (wic != null) wic.Undo();
            }
        }

        public static void RunAs(RunasObject setting)
        {
            RunAs(delegate()
            {
                Process.Start(setting.ExeFile);
            }, setting.UserName, setting.GetPassword(), setting.Domain);
        }
    }
}
