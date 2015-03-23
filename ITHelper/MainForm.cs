using cn.antontech.ITHelper.AutoActions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ITHelper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                UpdateCheckInfo info = null;
                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("不能下载新版本的应用。 \n\n请检查你的网络连接，或稍后再试。\n\n Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("不能检查更新，请联系信息化部门解决。\n\n Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("本应用不是一个可更新程序，请重新安装。\n\n Error: " + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = MessageBox.Show("有一个新版本可以使用，现在是否进行更新？", "有更新可用", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("发现新版本：" + info.MinimumRequiredVersion.ToString() +
                            "。应用程序将自动更新。",
                            "应用有更新", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("程序已经更新完毕，即将重启应用生效。");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("不能安装更新。 \n\n请检查你的网络连接，或稍后再试。\n\n Error: " + dde);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("当前程序已是最新版本。");
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(this, "当前不是以网络部署运行，请点击确定按钮运行更新！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    Process.Start("http://www.antontech.cn/publish/ITHelper/ITHelper.application");
                }
            }
        }



    }
}
