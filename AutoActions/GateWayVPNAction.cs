using cn.antontech.ITHelper.AutoActions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace ITHelper.AutoActions
{
    public class GateWayVPNAction : BaseAction
    {
        private Config _config;
        public GateWayVPNAction(XmlElement config)
            :this(new Config(config))
        {
        }

        public GateWayVPNAction(Config config)
        {
            _config = config;
        }

        public override void Exec()
        {
            string path = string.Format(@"System\CurrentControlSet\Services\{0}", _config.Name);
            if (Directory.Exists(path))
            {
                OnNotify(string.Format("设置 {0} 服务自动启动", _config.Name));
                using (RegistryKey serviceKey = Registry.LocalMachine.OpenSubKey(path, true))
                {
                    serviceKey.SetValue("Start", 2);
                    if (Environment.OSVersion.Version.Major >= 6)
                        serviceKey.SetValue("DelayedAutostart", 0, RegistryValueKind.DWord);
                }
                OnNotify("设置成功");
            }
            else
            {
                OnNotify(string.Format("路径不正确，未能找到{0}服务", _config.Name));
            }
        }

        public class Config
        {
            public Config()
            {
            }
            public Config(XmlElement config)
                :this()
            {
                string name = config.Attributes["Name"].Value;
                Name = name;
            }
            public string Name { get; set; }
        }
    }
}
