using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace cn.antontech.ITHelper.AutoActions
{
    public class CopyFileAction : BaseAction
    {
        private Config _config;
        public CopyFileAction(XmlElement config)
            : this(new Config(config))
        {

        }
        public CopyFileAction(Config config)
        {
            _config = config;
        }

        public override void Exec()
        {

            if ((IntPtr.Size == 4 && _config.OS.Equals("x86", StringComparison.OrdinalIgnoreCase))
                || (IntPtr.Size == 8 && _config.OS.Equals("x64", StringComparison.OrdinalIgnoreCase))
                || (!_config.OS.Equals("x86", StringComparison.OrdinalIgnoreCase) && !_config.OS.Equals("x64", StringComparison.OrdinalIgnoreCase)))
            {
                string from = ProcessPath(_config.From);
                string to = ProcessPath(_config.To);
                File.Copy(from, to, true);
                OnNotify(string.Format("拷贝文件{0}至{1}", from, to));
            }
        }

        private string ProcessPath(string input)
        {
            return input.Replace("%DesktopDirectory%", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory))
                .Replace("%ApplicationData%", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
                .Replace("%CommonApplicationData%", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData))
                .Replace("%CommonProgramFiles%", Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles))
                .Replace("%Cookies%", Environment.GetFolderPath(Environment.SpecialFolder.Cookies))
                .Replace("%Desktop%", Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
                .Replace("%Favorites%", Environment.GetFolderPath(Environment.SpecialFolder.Favorites))
                .Replace("%History%", Environment.GetFolderPath(Environment.SpecialFolder.History))
                .Replace("%InternetCache%", Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))
                .Replace("%LocalApplicationData%", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData))
                .Replace("%MyComputer%", Environment.GetFolderPath(Environment.SpecialFolder.MyComputer))
                .Replace("%MyDocuments%", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
                .Replace("%MyMusic%", Environment.GetFolderPath(Environment.SpecialFolder.MyMusic))
                .Replace("%MyPictures%", Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
                .Replace("%Personal%", Environment.GetFolderPath(Environment.SpecialFolder.Personal))
                .Replace("%ProgramFiles%", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))
                .Replace("%Programs%", Environment.GetFolderPath(Environment.SpecialFolder.Programs))
                .Replace("%Recent%", Environment.GetFolderPath(Environment.SpecialFolder.Recent))
                .Replace("%SendTo%", Environment.GetFolderPath(Environment.SpecialFolder.SendTo))
                .Replace("%StartMenu%", Environment.GetFolderPath(Environment.SpecialFolder.StartMenu))
                .Replace("%Startup%", Environment.GetFolderPath(Environment.SpecialFolder.Startup))
                .Replace("%System%", Environment.GetFolderPath(Environment.SpecialFolder.System))
                .Replace("%Templates%", Environment.GetFolderPath(Environment.SpecialFolder.Templates));
        }

        public class Config
        {
            public Config()
            {
            }
            public Config(XmlElement config)
                : this()
            {

                OS = config.Attributes["OS"].Value;
                From = config.Attributes["From"].Value;
                To = config.Attributes["To"].Value;
            }
            public string OS { get; set; }
            public string From { get; set; }
            public string To { get; set; }
        }

    }
}
