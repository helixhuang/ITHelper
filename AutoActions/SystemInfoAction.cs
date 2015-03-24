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
            String systemInfo = "\n" +
                                checkComputerInfo.getHostName() + "\n" +
                                                                checkComputerInfo.getHostFullName() + "\n" +
                                checkComputerInfo.getDomainName() + "\n" +
                                checkComputerInfo.getOSCurrentUser() + "\n" +
                                "\n" +
                                checkComputerInfo.getOSName() + "\n" +
                                checkComputerInfo.getOSVersion() + "\n" +
                                checkComputerInfo.getOSBit() + "\n" +
                                checkComputerInfo.getOSPath() + "\n" +
                                "\n" +
                                checkComputerInfo.getOSIP() + "\n" +
                                checkComputerInfo.getSubnet() + "\n" +
                                checkComputerInfo.getDefaultGateway() + "\n" +
                                checkComputerInfo.getDNSAddress() + "\n" +
                                "\n" +
                                checkComputerInfo.getOfficeVersion() + "\n" +
                                checkComputerInfo.getIEVersion() + "\n" +
                                "\n" +
                                checkComputerInfo.getBaseBoardName() + "\n" +
                                checkComputerInfo.getCPUName() + "\n" +
                                checkComputerInfo.getCPUMHZ() + "\n";
           
            OnNotify(systemInfo);
        }
    }
}
