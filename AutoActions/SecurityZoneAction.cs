using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace cn.antontech.ITHelper.AutoActions
{
    public class SecurityZoneAction : BaseAction
    {
        const string DOMAINKEY = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings\ZoneMap\Domains";
        const string RANGEKEY = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings\ZoneMap\Ranges";

        private Config _config;
        public SecurityZoneAction(XmlElement config)
            : this(new Config(config))
        {
        }
        public SecurityZoneAction(Config config)
        {
            _config = config;
        }
        public override void Exec()
        {

            RegistryKey currentUserKey = Registry.CurrentUser;

            OnNotify(string.Format("将{0}添加到本地安全区域", _config.Domain));
            Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            if (ip.IsMatch(_config.Domain))
            {
                RegistryKey rangeKey = RegistryHelper.GetOrCreateSubKey(currentUserKey, RANGEKEY, _config.Domain, true);
                rangeKey.SetValue(_config.Protocol, _config.SiteZone, RegistryValueKind.DWord);
                rangeKey.SetValue(":Range", _config.Domain, RegistryValueKind.String);
            }
            else
            {
                string[] tmp = _config.Domain.Split('.');
                string mainDomain = String.Format("{0}.{1}", tmp[1], tmp[2]);
                string subDomain = tmp[0];

                RegistryKey subdomainRegistryKey = RegistryHelper.GetOrCreateSubKey(
                    currentUserKey,
                    string.Format(@"{0}\{1}", DOMAINKEY, mainDomain),
                    subDomain, true);

                object objSubDomainValue = subdomainRegistryKey.GetValue(_config.Protocol);

                if (objSubDomainValue == null || Convert.ToInt32(objSubDomainValue) != _config.SiteZone)
                {
                    subdomainRegistryKey.SetValue(_config.Protocol, _config.SiteZone, RegistryValueKind.DWord);
                }
            }


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

                int siteZone = config.HasAttribute("SiteZone") ? Int16.Parse(config.Attributes["SiteZone"].Value) : 0x1;
                string domain = config.Attributes["Domain"].Value;
                string potocol = config.HasAttribute("Protocol") ? config.Attributes["Protocol"].Value : "*";

                this.SiteZone = siteZone;
                this.Domain = domain;
                this.Protocol = potocol;

            }
            public int SiteZone { get; set; }
            public string Protocol { get; set; }
            public string Domain { get; set; }
        }

    }
}
