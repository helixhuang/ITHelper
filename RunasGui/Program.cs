using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RunasGui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                string appName = args[0];
                List<RunasObject> runasList = JsonConvert.DeserializeObject<List<RunasObject>>(File.ReadAllText("RunasData.json", Encoding.UTF8));
                if (runasList != null)
                {
                    RunasObject runasObj = runasList.Find(o => o.Name == appName);
                    if (runasObj != null)
                    {
                        RunasHelper.Runas(runasObj);
                        return;
                    }
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
