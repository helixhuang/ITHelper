using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;

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

            if (!File.Exists(_config.Path))
            {
                OnNotify(string.Format("不能加载 {0}（{1}），请检查文件是否存在", _config.Name, _config.Path));
            }
            else
            {
                OnNotify(string.Format("开始安装 {0}", _config.Name));
                ProcessStartInfo start = new ProcessStartInfo()
                {
                    FileName = _config.Path,
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
                string path = config.Attributes["Path"].Value;
                Name = name;
                Path = path;
            }
            public string Name { get; set; }
            public string Path { get; set; }
        }
    }
}
