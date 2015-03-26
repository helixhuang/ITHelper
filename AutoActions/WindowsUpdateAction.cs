using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using WUApiLib;

namespace cn.antontech.ITHelper.AutoActions
{
    public class WindowsUpdateAction : BaseAction
    {
        private Config _config;
         public WindowsUpdateAction(XmlElement config)
            : this(new Config(config))
        {
        }

        public WindowsUpdateAction(Config config)
        {
            _config = config;
        }

        public override void Exec()
        {
            if (string.IsNullOrEmpty(_config.Level))
            {
                OnNotify(string.Format("不能设置更新级别 {0}，请检查配置文件是否存在问题", _config.Level));
            }
            else
            {
                OnNotify(string.Format("开始设置更新级别 {0}", _config.Level));
                AutomaticUpdatesClass auc = new AutomaticUpdatesClass();
                AutomaticUpdatesNotificationLevel value = (AutomaticUpdatesNotificationLevel)Enum.Parse(typeof(AutomaticUpdatesNotificationLevel), _config.Level);
                auc.Settings.NotificationLevel = value;
                auc.Settings.Save();
                OnNotify(string.Format("设置更新级别 {0} 成功 ", _config.Level));
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
                string level = config.Attributes["Level"].Value;
                Level = level;
            }
            public string Level { get; set; }
        }
    }
}
