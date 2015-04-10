using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace cn.antontech.ITHelper.AutoActions
{
    public class RemoveLnkAction : BaseAction
    {
        private Config _config;
        public RemoveLnkAction(XmlElement config)
            :this(new Config(config))
        {
        }

        public RemoveLnkAction(Config config)
        {
            _config = config;
        }

        public override void Exec()
        {
            string userName = Environment.UserName;
            string path = string.Format("C:/Users/{0}/AppData/Roaming/Microsoft/Windows/Start Menu/Programs/", userName);
            if (Directory.Exists(path))
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] fileList = dir.GetFiles();
                for (int i = 0; i < fileList.Length; i++)
                {
                    if (fileList[i].Name.Contains(_config.Str))
                    {
                        if (fileList[i].Name.Contains(_config.Num))
                        {
                            fileList[i].Delete();
                            OnNotify(string.Format("{0} 8 64位快捷方式已删除", _config.Str));
                        }
                    }
                }
                OnNotify(string.Format("未能找到 {0} 8 64位快捷方式", _config.Str));
            }
            else
            {
                OnNotify(string.Format("未能找到 {0} 8 64位快捷方式",_config.Str));
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
                string str = config.Attributes["Str"].Value;
                string num = config.Attributes["Num"].Value;
                Str = str;
                Num = num;
            }
            public string Str { get; set; }
            public string Num { get; set; }
        }
    }
}
