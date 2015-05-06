using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace cn.antontech.ITHelper
{
    public partial class RemindBox : Form
    {
        public RemindBox()
        {
            InitializeComponent();
            remind.TextAlign = ContentAlignment.MiddleCenter;
            remind.Text = "温馨提示";
            lb0.Text = "尊敬的用户：";
            lb1.Text = "        您好！您在使用ITHelper之前，请您注意以下事项：";
            lb2.Text = "1、请您退出360、金山等相关杀毒软件，这些软件可能限制";
            lb3.Text = "   ITHelper的某些功能，影响您的使用体验。";
            lb4.Text = "2、请您安装office，如果您未安装office会导致ITHelper";
            lb5.Text = "   某些功能无法使用。";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(boxVisibility.Checked)
            {
                Properties.Settings.Default.remindBoxVisibility = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                this.Close();
                return;
            }
        }
    }
}
