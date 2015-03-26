using System;
using System.Collections.Generic;
using System.Text;

namespace cn.antontech.ITHelper.AutoActions
{
    public class SystemInfoAction:BaseAction
    {
        private CheckComputerInfo checkComputerInfo;

        public SystemInfoAction()
        {
            checkComputerInfo = new CheckComputerInfo();
        }

        public override void Exec()
        {
            String systemInfo = "计算机\r\n"+
                                "     计算机名：               " + checkComputerInfo.getHostName() + "\r\n" +
                                "     计算机全名：             " + checkComputerInfo.getHostFullName() + "\r\n" +
                                "     域：                        " + checkComputerInfo.getDomainName() + "\r\n" +
                                "     当前用户：               " + checkComputerInfo.getOSCurrentUser() + "\r\n" +
                                "操作系统\r\n" +
                                "     名称：                  " + checkComputerInfo.getOSName() + "\r\n" +
                                "     版本:                   " + checkComputerInfo.getOSVersion() + "\r\n" +
                                "     位数：                  " + checkComputerInfo.getOSBit() + "\r\n" +
                                "     路径：                  " + checkComputerInfo.getOSPath() + "\r\n" +
                                 "网络\r\n" +
                                "     IP地址：                " + checkComputerInfo.getOSIP() + "\r\n" +
                                "     子网掩码：              " + checkComputerInfo.getSubnet() + "\r\n" +
                                "     网关地址：              " + checkComputerInfo.getDefaultGateway() + "\r\n" +
                                 "     首选DNS地址：        " + checkComputerInfo.getDNSAddress() + "\r\n" +
                                 "应用程序\r\n" +
                                "     Office版本：            " + checkComputerInfo.getOfficeVersion() + "\r\n" +
                                "     IE版本：                  " + checkComputerInfo.getIEVersion() + "\r\n" +
                                "主板\r\n" +
                                "     主板型号：              " + checkComputerInfo.getBaseBoardName() + "\r\n" +
                                "     CPU型号：               " + checkComputerInfo.getCPUName() + "\r\n" +
                                "     CPU主频：               " + checkComputerInfo.getCPUMHZ() + "\r\n";
           
            OnNotify(systemInfo);
        }
    }
}
