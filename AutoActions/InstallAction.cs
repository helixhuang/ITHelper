using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Xml;
using System.Windows.Forms;

namespace cn.antontech.ITHelper.AutoActions
{
    public class InstallAction : BaseAction
    {
        private Config _config;
        public InstallAction(XmlElement config)
            : this(new Config(config))
        {
        }

        public InstallAction(Config config)
        {
            _config = config;
        }

        public override void Exec()
        {
            string baseDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ITHelper\\");
            string filePath = Path.Combine(baseDir, _config.Name);
            if (File.Exists(filePath))
            {
                OnNotify(string.Format("本地找到安装文件 {0} ，开始安装...", _config.Name));
                ProcessStartInfo start = new ProcessStartInfo()
                {
                    FileName = filePath,
                    Arguments = "",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        OnNotify(string.Format("MSG:{0}", result));
                    }
                }
                OnNotify(string.Format("安装成功 {0}", _config.Name));
            }
            else
            {
                OnNotify(string.Format("本地未能找到安装文件，正在下载安装文件 {0}", _config.Name));
                string downLoadPath = Path.Combine(_config.Url, _config.Name); 
                Download downLoad = new Download(downLoadPath, filePath, _config.Name);
                downLoad.ShowDialog();
                OnNotify(string.Format("下载安装文件 {0} 成功，开始安装", _config.Name));
                ProcessStartInfo start = new ProcessStartInfo()
                {
                    FileName = filePath,
                    Arguments = "",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        OnNotify(string.Format("MSG:{0}", result));
                    }
                }
                OnNotify(string.Format("安装成功 {0}", _config.Name));
            }
        }

        public class Config
        {
            public Config()
            {
            }
            public Config(XmlElement config)
                : this()
            {

                string name = config.Attributes["Name"].Value;
                string url = config.Attributes["Url"].Value;
                Name = name;
                Url = url;
            }
            public string Name { get; set; }
            public string Url { get; set; }
        }
    }
}
