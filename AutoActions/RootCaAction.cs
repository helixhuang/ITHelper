using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace cn.antontech.ITHelper.AutoActions
{
    public class RootCaAction : BaseAction
    {
        private Config _config;
         public RootCaAction(XmlElement config)
            : this(new Config(config))
        {
        }

        public RootCaAction(Config config)
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
                OnNotify(string.Format("开始导入 {0}", _config.Name));
                X509Certificate2 certificate = new X509Certificate2(_config.Path);
                X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
                store.Open(OpenFlags.MaxAllowed);
                store.Add(certificate);
                store.Close();
                OnNotify(string.Format("导入成功 {0}", _config.Name));
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
