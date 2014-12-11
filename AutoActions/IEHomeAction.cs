using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace cn.antontech.ITHelper.AutoActions
{
    public class IEHomeAction : BaseAction
    {
        private Config _config;
        public IEHomeAction(XmlElement config)
            : this(new Config(config))
        {
        }
        public IEHomeAction(Config config)
        {
            _config = config;
        }

        public override void Exec()
        {
            RegistryKey startPageKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
            startPageKey.SetValue("Start Page", _config.Url);
            startPageKey.Close();
        }

        public class Config
        {
            public Config()
            {

            }
            public Config(XmlElement config)
                : this()
            {
                Url = config.Attributes["Url"].Value;
            }
            public string Url { get; set; }
        }
    }
}
