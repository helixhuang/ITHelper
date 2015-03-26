using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;

namespace cn.antontech.ITHelper.AutoActions
{
    public class WinSockAction : BaseAction
    {
        private Config _config;
        public WinSockAction(XmlElement config)
            : this(new Config(config))
        {
        }

        public WinSockAction(Config config)
        {
            _config = config;
        }

        public override void Exec()
        {
            if (string.IsNullOrEmpty(_config.FileName) || string.IsNullOrEmpty(_config.Arguments))
            {
                OnNotify("不能修复WinSock协议,请检查配置文件是否存在问题");
            }
            else
            {
                OnNotify(string.Format("开始修复WinSock {0}启动", _config.FileName));
                Process process = new Process();
                ProcessStartInfo processStartInfo = new ProcessStartInfo(_config.FileName, _config.Arguments);
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processStartInfo.UseShellExecute = false;
                processStartInfo.RedirectStandardError = true;
                process.StartInfo = processStartInfo;
                process.Start();
                OnNotify("修复成功！请您重启电脑使配置生效");
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
                string fileName = config.Attributes["FileName"].Value;
                string arguments = config.Attributes["Arguments"].Value;
                FileName = fileName;
                Arguments = arguments;
            }
            public string FileName { get; set; }
            public string Arguments { get; set; }
        }
    }
}

