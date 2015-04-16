using cn.antontech.ITHelper.AutoActions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace cn.antontech.ITHelper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            actionTab.Visible = false;
            processBar.Visible = false;
            if (RunAsHelper.IsRunAsAdmin())
            {
                this.Text += "(管理员模式)";
                runAsAdminToolStripMenuItem.Visible = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadActions();
            this.webLinks.Url = new Uri("http://www.antontech.cn/publish/ITHelper/Links.html");
            this.webSoft.Url = new Uri("http://www.antontech.cn/publish/ITHelper/Soft.html");
            //this.wbSchool.Url = new Uri("https://home.antonoil.com/informatization/FAQ/Forms/AllItems.aspx");
            this.webSchool.Url = new Uri("http://www.antontech.cn/publish/ITHelper/Manual.html");
            this.webHelper.Url = new Uri("http://www.antontech.cn/publish/ITHelper/ITService.html");
            //this.tabPageSchool.Parent = null;
            RemindBox reminBox = new RemindBox();
            reminBox.Show();
        }

        private void LoadActions()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Actions.xml");
            foreach (XmlElement node in doc.GetElementsByTagName("ActionGroup"))
            {
                ActionGroup actionGroup = new ActionGroup(node);
                actionListBox.Items.Add(actionGroup);
            }
        }

        void actionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActionGroup actionGroup = actionListBox.SelectedItem as ActionGroup;
            if (actionGroup != null)
            {
                actionTab.Visible = true;
                actionTabPage.Text = actionGroup.Name;
                tabInstruction.Text = actionGroup.Instruction;
            }
            else
            {
                actionTab.Visible = false;
            }
            eventListBox.Items.Clear();
        }

        void startActionButton_Click(object sender, EventArgs e)
        {
            ActionGroup actionGroup = actionListBox.SelectedItem as ActionGroup;

            if (actionGroup.NeedAdmin && !RunAsHelper.IsRunAsAdmin())
            {
                DialogResult result = MessageBox.Show("此操作需要管理员权限，是否以管理员权限重新启动应用？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    RunAsHelper.RunAsAdmin();
                    return;
                }
            }

            processBar.Visible = true;
            processBar.Style = ProgressBarStyle.Blocks;
            startActionButton.Enabled = false;
            actionListBox.Enabled = false;
            eventListBox.Items.Clear();
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += Action_DoWork;
            bw.ProgressChanged += Action_ProgressChanged;
            bw.RunWorkerCompleted += Action_RunWorkerCompleted;
            bw.WorkerReportsProgress = true;
            bw.RunWorkerAsync(actionGroup);
        }

        void Action_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            eventListBox.Items.Add(new ActionEventArgs("处理完毕"));
            processBar.Visible = false;
            startActionButton.Enabled = true;
            actionListBox.Enabled = true;
        }

        void Action_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                eventListBox.Items.Add(e.UserState);
            }
            if (e.ProgressPercentage > 0)
            {
                processBar.Value = e.ProgressPercentage;
            }
            
        }

        void Action_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            ActionGroup actionGroup = e.Argument as ActionGroup;
            foreach (XmlElement actionNode in actionGroup.ActionList)
            {
                try
                {
                    BaseAction action = ActionFactory.GetAction(actionNode as XmlElement);
                    action.Notify += (o, a) =>
                    {
                        bw.ReportProgress(0, a);
                    };
                    action.Exec();
                }
                catch (Exception ex)
                {
                    bw.ReportProgress(0,
                        new ActionEventArgs(ActionEventType.Error, string.Format("执行{0}失败：{1}", actionNode.Name, ex.Message)));
                }
                bw.ReportProgress((actionGroup.ActionList.IndexOf(actionNode) + 1) * 100 / actionGroup.ActionList.Count);
            }
            e.Result = e.Argument;
        }

        void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Owner = this;
            about.ShowDialog();
        }

        void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void runAsAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunAsHelper.RunAsAdmin();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Updating formUpdate = new Updating();
                formUpdate.Show(this);
            }
            else
            {
                DialogResult result = MessageBox.Show(this, "当前不是以网络部署运行，请点击确定按钮运行更新！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    Process.Start("iexplore.exe","http://www.antontech.cn/publish/ITHelper/ITHelper.application");
                }
            }
        }

        private void startScanButton_Click(object sender, EventArgs e)
        {
            startScanButton.Enabled = false;
            processBar.Visible = true;
            processBar.Style = ProgressBarStyle.Marquee;
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (o, a) =>
            {
                CheckComputerInfo checkComputerInfo = new CheckComputerInfo();
                String systemInfo = "计算机\r\n" +
                        "     计算机名：\t\t\t" + checkComputerInfo.getHostName() + "\r\n" +
                        "     计算机全名：\t\t\t" + checkComputerInfo.getHostFullName() + "\r\n" +
                        "     域：\t\t\t\t" + checkComputerInfo.getDomainName() + "\r\n" +
                        "     当前用户：\t\t\t" + checkComputerInfo.getOSCurrentUser() + "\r\n" +
                        "操作系统\r\n" +
                        "     名称：\t\t\t\t" + checkComputerInfo.getOSName() + "\r\n" +
                        "     版本:\t\t\t\t" + checkComputerInfo.getOSVersion() + "\r\n" +
                        "     位数：\t\t\t\t" + checkComputerInfo.getOSBit() + "\r\n" +
                        "     路径：\t\t\t\t" + checkComputerInfo.getOSPath() + "\r\n" +
                         "网络\r\n" +
                        "     IP地址：\t\t\t" + checkComputerInfo.getOSIP() + "\r\n" +
                        "     子网掩码：\t\t\t" + checkComputerInfo.getSubnet() + "\r\n" +
                        "     网关地址：\t\t\t" + checkComputerInfo.getDefaultGateway() + "\r\n" +
                         "     首选DNS地址：\t\t\t" + checkComputerInfo.getDNSAddress() + "\r\n" +
                         "应用程序\r\n" +
                        "     Office版本：\t\t\t" + checkComputerInfo.getOfficeVersion() + "\r\n" +
                        "     IE版本：\t\t\t" + checkComputerInfo.getIEVersion() + "\r\n" +
                        "主板\r\n" +
                        "     主板型号：\t\t\t" + checkComputerInfo.getBaseBoardName() + "\r\n" +
                        "     CPU型号：\t\t\t" + checkComputerInfo.getCPUName() + "\r\n" +
                        "     CPU主频：\t\t\t" + checkComputerInfo.getCPUMHZ() + "\r\n";
                a.Result = systemInfo;
            };
            bw.RunWorkerCompleted += (o, a) =>
            {
                systemInfoTxt.Text = a.Result as string;
                processBar.Visible = false;
                startScanButton.Enabled = true;
            };
            bw.RunWorkerAsync();
        }

        private void sysinfoButton_Click(object sender, EventArgs e)
        {
            const string cRegKeySysInfo = @"SOFTWARE\Microsoft\Shared Tools\MSINFO";
            const string cRegValSysInfo = "PATH";
            const string cRegKeySysInfoLoc = @"SOFTWARE\Microsoft\Shared Tools Location";
            const string cRegValSysInfoLoc = "MSINFO";
            try
            {
                string fileName;

                //不同版本的windows系统，注册表存放的位置不同，共有两处

                //第一处
                RegistryKey getRegKey = Registry.LocalMachine;
                RegistryKey getSubKey = getRegKey.OpenSubKey(cRegKeySysInfo);

                if (getSubKey == null)
                {
                    //第二处
                    getSubKey = getRegKey.OpenSubKey(cRegKeySysInfoLoc);
                    fileName = getSubKey.GetValue(cRegValSysInfoLoc).ToString() + @"\MSINFO32.EXE";
                }
                else
                {
                    fileName = getSubKey.GetValue(cRegValSysInfo).ToString();
                }

                //调用外部可执行程序
                Process newPro = new Process();
                newPro.StartInfo.FileName = fileName;
                newPro.Start();
            }
            catch { }
        }
    }
}
