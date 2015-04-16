using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace cn.antontech.ITHelper.AutoActions
{
    public class OpenFileAction : BaseAction
    {
        private Config _config;
        public OpenFileAction(XmlElement config)
            : this(new Config(config))
        {
        }

        public OpenFileAction(Config config)
        {
            _config = config;
        }

        public override void Exec()
        {
            string notice = string.Format("您是否需要打开 {0}", _config.Name);
            if(MessageBox.Show(
                notice,
                "提示",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information) == DialogResult.OK)
            {
                OnNotify(string.Format("正在通过IE浏览器打开 {0} ...", _config.Name));
                System.Diagnostics.ProcessStartInfo value =
                    new System.Diagnostics.ProcessStartInfo("iexplore.exe", _config.Path);
                System.Diagnostics.Process.Start(value);
                OnNotify(string.Format("打开 {0} 成功", _config.Name));
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
