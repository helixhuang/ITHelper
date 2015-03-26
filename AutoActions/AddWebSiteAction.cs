using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace cn.antontech.ITHelper.AutoActions
{
    public class AddWebSiteAction : BaseAction
    {
        private Config _config;
        public AddWebSiteAction(XmlElement config)
            : this(new Config(config))
        {
        }

        public AddWebSiteAction(Config config)
        {
            _config = config;
        }

        public override void Exec()
        {
            if (string.IsNullOrEmpty(_config.Url))
            {
                OnNotify(string.Format("不能添加 {0} 到收藏夹，请检查配置文件是否存在问题", _config.Url));
            }
            else
            {
                OnNotify(string.Format("开始添加 {0} 网址到IE收藏夹", _config.SaveName));
                String favoritesPath = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
                String savePath = favoritesPath;
                if (!String.IsNullOrEmpty(_config.Url) && !String.IsNullOrEmpty(_config.SaveName))
                {
                    savePath += @"/";
                    if (!Directory.Exists(savePath))
                        Directory.CreateDirectory(savePath);
                }
                IWshRuntimeLibrary.WshShell shell_class = new IWshRuntimeLibrary.WshShellClass();
                IWshRuntimeLibrary.IWshShortcut shortcut = null;
                try
                {
                    shortcut = shell_class.CreateShortcut(favoritesPath + @"/" + _config.SaveName + ".lnk") as IWshRuntimeLibrary.IWshShortcut;
                    shortcut.TargetPath = _config.Url;
                    shortcut.Save();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                OnNotify(string.Format("添加 {0} 成功 ", _config.SaveName));
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
                string url = config.Attributes["Url"].Value;
                string saveName = config.Attributes["SaveName"].Value;
                Url = url;
                SaveName = saveName;
            }
            public string Url { get; set; }
            public string SaveName { get; set; }
        }
    }
}
