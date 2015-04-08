using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace cn.antontech.ITHelper.AutoActions
{
    public class OpenFileAction : BaseAction
    {
        private Config _config;
        public OpenFileAction(XmlElement config)
            :this(new Config(config))
        {
        }

        public OpenFileAction(Config config)
        {
            _config = config;
        }

        public override void Exec()
        {
            if(!File.Exists(_config.Path))
            {
                OnNotify(string.Format("打开{0}错误",_config.Name));
            }
            else
            {
                OnNotify(string.Format("正在打开用户手册..."));
                System.Diagnostics.Process.Start(_config.Path);
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
                string path = config.Attributes["Path"].Value;
                Name = name;
                Path = path;
            }
            public string Name { get; set; }
            public string Path { get; set; }
        }
    }
}
