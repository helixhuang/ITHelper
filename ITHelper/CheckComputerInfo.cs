using Microsoft.Win32;
using System;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;

namespace cn.antontech.ITHelper
{

    public class CheckComputerInfo : IDisposable
    {
        private RegistryKey registryKey;
        private RegistryKey registrySubKey;
        private IPHostEntry hostEntry;//主机记录

        public void Dispose()
        {
        }
        public CheckComputerInfo()
        {
            registryKey = Registry.LocalMachine;
            registrySubKey = null;
            hostEntry = Dns.GetHostEntry(Dns.GetHostName());
        }

        //获取计算机的系统名称
        public Object getOSName()
        {
            registrySubKey = registryKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            return registrySubKey.GetValue("ProductName");
        }
        //获取计算机的系统主+副版本
        public Object getOSVersion()
        {
            registrySubKey = registryKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            return registrySubKey.GetValue("CurrentVersion") + "  " + registrySubKey.GetValue("CurrentBuildNumber");
        }
        //获取操作系统位数
        public string getOSBit()
        {
            try
            {
                ConnectionOptions oConn = new ConnectionOptions();
                System.Management.ManagementScope managementScope =
                    new System.Management.ManagementScope("\\\\localhost", oConn);
                System.Management.ObjectQuery objectQuery =
                    new System.Management.ObjectQuery("select AddressWidth from Win32_Processor");
                ManagementObjectSearcher moSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
                ManagementObjectCollection moReturnCollection = null;
                string addressWidth = null;
                moReturnCollection = moSearcher.Get();
                foreach (ManagementObject oReturn in moReturnCollection)
                {
                    addressWidth = oReturn["AddressWidth"].ToString();
                }
                return addressWidth;
            }
            catch
            {
                return "获取错误";
            }
        }
        //获取操作系统安装路径
        public Object getOSPath()
        {
            registrySubKey = registryKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            return registrySubKey.GetValue("SystemRoot");
        }
        //获取系统当前用户
        public Object getOSCurrentUser()
        {
            registrySubKey = registryKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            return registrySubKey.GetValue("RegisteredOwner");
        }
        //获取系统IP地址
        public Object getOSIP()
        {
            IPAddress ip = null;
            foreach (IPAddress ipAddress in hostEntry.AddressList)
            {
                //获取的IP地址列表中，计算机所有处于活动状态的网卡的IPV6地址位于列表前面，检测到如果IP地址类型为IPV4地址时，优先选择作为本机的IP地址
                if (ipAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    ip = ipAddress;
                    break;
                }
            }
            return ip;
        }
        //获取子网掩码
        public string  getSubnet()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection nics = mc.GetInstances();
            foreach (ManagementObject nic in nics)
            {
                if (Convert.ToBoolean(nic["ipEnabled"]) == true)
                {
                    return (nic["IPSubnet"] as string[])[0];
                }
            }
            return "无法获取";
        }
        //获取默认网关
        public string getDefaultGateway()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection nics = mc.GetInstances();
            foreach (ManagementObject nic in nics)
            {
                if (Convert.ToBoolean(nic["ipEnabled"]) == true)
                {
                    return (nic["DefaultIPGateway"] as string[])[0];
                }
            }
            return "无法获取";
        }
        /// <summary>
        ///获取本地DNS服务器地址
        /// </summary>
        /// <returns></returns>
        public string getDNSAddress()
        {
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces(); 
            foreach (NetworkInterface networkInterface in networkInterfaces)
            { if (networkInterface.OperationalStatus == OperationalStatus.Up) 
                { IPInterfaceProperties ipProperties = networkInterface.GetIPProperties(); 
                    IPAddressCollection dnsAddresses = ipProperties.DnsAddresses;
                    foreach (IPAddress dnsAdress in dnsAddresses)
                    {
                        return dnsAdress.ToString(); 
                    } 
                } 
            } throw new InvalidOperationException("Unable to find DNS Address"); 
        }
        //获取计算机名
        public String getHostName()
        {
            return Dns.GetHostName();
        }
        //获取计算机全名
        public String getHostFullName()
        {
            return hostEntry.HostName;
        }
        //获取计算机域名称
        public String getDomainName()
        {
            //计算机全名去掉计算机名即为计算机所在域的名称
            return hostEntry.HostName.Substring(hostEntry.HostName.IndexOf(".") + 1);
        }
        //获取CPU型号
        public Object getCPUName()
        {
            registrySubKey = registryKey.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0");
            return registrySubKey.GetValue("ProcessorNameString");
        }
        //获取CPU主频
        public Object getCPUMHZ()
        {
            registrySubKey = registryKey.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0");
            return registrySubKey.GetValue("~MHz");
        }
        //获取主板型号
        public String getBaseBoardName()
        {
            registrySubKey = registryKey.OpenSubKey(@"HARDWARE\DESCRIPTION\System\BIOS");
            return registrySubKey.GetValue("BaseBoardManufacturer") + " " + "BaseBoardProduct";
        }
        /// <summary>
        /// 获取office版本
        /// </summary>
        /// <returns></returns>
        public string getOfficeVersion()
        {
            try
            {
                string sVersion = string.Empty;
                Microsoft.Office.Interop.Word.Application appVersion = new Microsoft.Office.Interop.Word.Application();
                appVersion.Visible = false;
                switch (appVersion.Version.ToString())
                {
                    case "7.0":
                        sVersion = "95";
                        break;
                    case "8.0":
                        sVersion = "97";
                        break;
                    case "9.0":
                        sVersion = "2000";
                        break;
                    case "10.0":
                        sVersion = "2002";
                        break;
                    case "11.0":
                        sVersion = "2003";
                        break;
                    case "12.0":
                        sVersion = "2007";
                        break;
                    case "14.0":
                        sVersion = "2010";
                        break;
                    case "15.0":
                        sVersion = "2013";
                        break;
                    default:
                        sVersion = "Too Old!";
                        break;
                }
                return sVersion;

            }
            catch
            {
                return "No office";
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns>返回IE版本</returns>
        public string getIEVersion()
        {
            registrySubKey = registryKey.OpenSubKey(@"software\Microsoft\Internet Explorer");
            string IEVersion = (String)registrySubKey.GetValue("Version");
            return IEVersion;
        }
    }
}
