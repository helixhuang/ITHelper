using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

namespace cn.antontech.ITHelper.AutoActions
{
    public class OpenIEAction : BaseAction
    {
        private Config _config;
        public OpenIEAction(XmlElement config)
            : this(new Config(config))
        {

        }
        public OpenIEAction(Config config)
        {
            _config = config;
        }

        public override void Exec()
        {
            Process.Start("IEXPLORE.EXE", _config.Url);
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
