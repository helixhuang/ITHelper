using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace cn.antontech.ITHelper.AutoActions
{
    public class ShowMessageAction : BaseAction
    {
        private Config _config;
        public ShowMessageAction(XmlElement config)
            : this(new Config(config))
        {
        }
        public ShowMessageAction(Config config)
        {
            _config = config;
        }

        public override void Exec()
        {
            MessageBox.Show(_config.Message);
        }

        public class Config
        {
            public Config()
            {

            }
            public Config(XmlElement config)
            {
                Message = config.Attributes["Message"].Value;
            }
            public string Message { get; set; }
        }
    }
}
