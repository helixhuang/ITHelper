using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Xml;

namespace cn.antontech.ITHelper.AutoActions
{
    public class PopupBlockerAction : BaseAction
    {

        private const string POPUPBLOCKER_DATA = @"Software\Microsoft\Internet Explorer\New Windows\Allow";

        private Config _config;

        public PopupBlockerAction(XmlElement config)
            : this(new Config(config))
        {
        }
        public PopupBlockerAction(Config config)
        {
            _config = config;
        }

        public override void Exec()
        {
            OnNotify(string.Format("将{0}添加到允许弹出窗口", _config.Domain));
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey allowKey = RegistryHelper.GetOrCreateKey(currentUserKey, POPUPBLOCKER_DATA, true);
            allowKey.SetValue(_config.Domain, new byte[] { 0x00, 0x00 }, RegistryValueKind.Binary);
            OnNotify(string.Format("成功添加{0}", _config.Domain));

        }

        public class Config
        {
            public Config()
            {

            }
            public Config(XmlElement config)
                : this()
            {

                string domain = config.Attributes["Domain"].Value;
                this.Domain = domain;
            }
            public string Domain { get; set; }
        }

    }
}
