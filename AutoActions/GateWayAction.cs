using cn.antontech.ITHelper.AutoActions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace cn.antontech.ITHelper.AutoActions
{
    public class GateWayAction : BaseAction
    {
        private Config _config;
        public GateWayAction(XmlElement config)
            : this(new Config(config))
        {
        }

        public GateWayAction(Config config)
        {
            _config = config;
        }

        public override void Exec()
        {
            OnNotify(string.Format("设置 {0} 服务自动启动", _config.Name));
            using (RegistryKey serviceKey = 
                Registry.LocalMachine.OpenSubKey(string.Format(@"System\CurrentControlSet\Services\{0}", _config.Name), true))
            {
                if (serviceKey == null)
                {
                    OnNotify(string.Format("{0}服务不存在", _config.Name));
                }
                else
                {
                    serviceKey.SetValue("Start", 2);
                    if (Environment.OSVersion.Version.Major >= 6)
                        serviceKey.SetValue("DelayedAutostart", 0, RegistryValueKind.DWord);
                    OnNotify("设置成功！");
                }
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
                Name = name;
            }
            public string Name { get; set; }
        }
    }
}
