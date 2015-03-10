using cn.antontech.ITHelper.AutoActions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            processBar.Visible = true;
            startActionButton.Enabled = false;
            actionListBox.Enabled = false;
            eventListBox.Items.Clear();
            ActionGroup actionGroup = actionListBox.SelectedItem as ActionGroup;
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



    }
}
