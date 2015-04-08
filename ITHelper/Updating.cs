using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cn.antontech.ITHelper
{
    public partial class Updating : Form
    {
        public Updating()
        {
            InitializeComponent();
            labelMsg.Text = "";
            labelVersion.Text = String.Format("当前版本： {0}", ApplicationDeployment.CurrentDeployment.CurrentVersion);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Load += Updating_Load;
            this.Disposed += Updating_Disposed;
            this.FormClosed += Updating_FormClosed;
        }

        void Updating_FormClosed(object sender, FormClosedEventArgs e)
        {
            ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            ad.CheckForUpdateProgressChanged -= ad_CheckForUpdateProgressChanged;
            ad.CheckForUpdateCompleted -= ad_CheckForUpdateCompleted;
            ad.UpdateProgressChanged -= ad_UpdateProgressChanged;
            ad.UpdateCompleted -= ad_UpdateCompleted;
        }

        void Updating_Disposed(object sender, EventArgs e)
        {
            ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            ad.CheckForUpdateProgressChanged -= ad_CheckForUpdateProgressChanged;
            ad.CheckForUpdateCompleted -= ad_CheckForUpdateCompleted;
            ad.UpdateProgressChanged -= ad_UpdateProgressChanged;
            ad.UpdateCompleted -= ad_UpdateCompleted;
        }
        void Updating_Load(object sender, EventArgs e)
        {
            CheckUpdate();
        }

        private void CheckUpdate()
        {
            try
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                ad.CheckForUpdateProgressChanged += ad_CheckForUpdateProgressChanged;
                ad.CheckForUpdateCompleted += ad_CheckForUpdateCompleted;
                ad.CheckForUpdateAsync();
            }
            catch (DeploymentDownloadException dde)
            {
                this.Hide();
                MessageBox.Show("不能下载新版本的应用。 \n\n请检查你的网络连接，或稍后再试。\n\n Error: " + dde.Message);
                this.Close();
                return;
            }
            catch (InvalidDeploymentException ide)
            {
                this.Hide();
                MessageBox.Show("不能检查更新，请联系信息化部门解决。\n\n Error: " + ide.Message);
                this.Close();
                return;
            }
            catch (InvalidOperationException ioe)
            {
                this.Hide();
                MessageBox.Show("本应用不是一个可更新程序，请重新安装。\n\n Error: " + ioe.Message);
                this.Close();
                return;
            }
        }

        void ad_CheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.Hide();
                MessageBox.Show("检查版本失败，请稍候再试。\n\n Error: " + e.Error.Message);
                this.Close();
                return;
            }
            else
            {

                if (e.UpdateAvailable)
                {
                    Boolean doUpdate = true;
                    if (!e.IsUpdateRequired)
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
                        MessageBox.Show("当前应用必须升级到版本：" + e.MinimumRequiredVersion.ToString() +
                            "。应用程序将自动更新。",
                            "应用有更新", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    if (doUpdate)
                    {
                        DoUpdate();
                    }
                    else
                    {
                        this.Close();
                        return;
                    }
                }
                else
                {
                    this.Hide();
                    MessageBox.Show("当前程序已是最新版本。");
                    this.Close();
                    return;
                }
            }
        }

        void ad_CheckForUpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            progressUpdate.Value = e.ProgressPercentage;
            labelMsg.Text = string.Format(@"{0}/{1}", e.BytesCompleted, e.BytesTotal);
        }

        private void DoUpdate()
        {
            try
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                ad.UpdateProgressChanged += ad_UpdateProgressChanged;
                ad.UpdateCompleted += ad_UpdateCompleted;
                ad.UpdateAsync();
            }
            catch (DeploymentDownloadException dde)
            {
                this.Hide();
                MessageBox.Show("不能安装更新。 \n\n请检查你的网络连接，或稍后再试。\n\n Error: " + dde);
                return;
            }
        }

        void ad_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.Hide();
                MessageBox.Show("更新失败，请稍候再试。\n\n Error: " + e.Error.Message);
                this.Close();
            }
            else
            {
                this.Hide();
                MessageBox.Show("程序已经更新完毕，即将重启应用生效。");
                Application.Restart();
            }
        }

        void ad_UpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            progressUpdate.Value = e.ProgressPercentage;
            labelMsg.Text = string.Format(@"{0}/{1}", e.BytesCompleted,e.BytesTotal);
        }


    }
}
