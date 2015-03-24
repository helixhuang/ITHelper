﻿namespace ITHelper
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuTop = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageIcons = new System.Windows.Forms.ImageList(this.components);
            this.statusBottom = new System.Windows.Forms.StatusStrip();
            this.processBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.copyrightLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageFix = new System.Windows.Forms.TabPage();
            this.tabPageScan = new System.Windows.Forms.TabPage();
            this.sysInfoNameLabel = new System.Windows.Forms.Label();
            this.tabPageSoftware = new System.Windows.Forms.TabPage();
            this.tabPageLinks = new System.Windows.Forms.TabPage();
            this.tabPageSchool = new System.Windows.Forms.TabPage();
            this.tabPageHelper = new System.Windows.Forms.TabPage();
            this.sysInfoLabel = new System.Windows.Forms.Label();
            this.splitContainerAction = new System.Windows.Forms.SplitContainer();
            this.actionListBox = new ITHelper.ActionListBox();
            this.actionTab = new System.Windows.Forms.TabControl();
            this.actionTabPage = new System.Windows.Forms.TabPage();
            this.eventListBox = new ITHelper.EventListBox();
            this.toolStripAction = new System.Windows.Forms.ToolStrip();
            this.startActionButton = new System.Windows.Forms.ToolStripButton();
            this.menuTop.SuspendLayout();
            this.statusBottom.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageFix.SuspendLayout();
            this.tabPageScan.SuspendLayout();
            this.splitContainerAction.Panel1.SuspendLayout();
            this.splitContainerAction.Panel2.SuspendLayout();
            this.splitContainerAction.SuspendLayout();
            this.actionTab.SuspendLayout();
            this.actionTabPage.SuspendLayout();
            this.toolStripAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuTop
            // 
            this.menuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuTop.Location = new System.Drawing.Point(0, 0);
            this.menuTop.Name = "menuTop";
            this.menuTop.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuTop.Size = new System.Drawing.Size(723, 25);
            this.menuTop.TabIndex = 4;
            this.menuTop.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.fileToolStripMenuItem.Text = "文件(&F)";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.exitToolStripMenuItem.Text = "退出(&E)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.helpToolStripMenuItem.Text = "帮助(&H)";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.aboutToolStripMenuItem.Text = "关于";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // imageIcons
            // 
            this.imageIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageIcons.ImageStream")));
            this.imageIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageIcons.Images.SetKeyName(0, "fix.png");
            this.imageIcons.Images.SetKeyName(1, "internet.png");
            this.imageIcons.Images.SetKeyName(2, "briefcase.png");
            this.imageIcons.Images.SetKeyName(3, "flag_01.png");
            this.imageIcons.Images.SetKeyName(4, "chat.png");
            this.imageIcons.Images.SetKeyName(5, "people.png");
            // 
            // statusBottom
            // 
            this.statusBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processBar,
            this.toolStripStatusLabel1,
            this.copyrightLabel});
            this.statusBottom.Location = new System.Drawing.Point(0, 331);
            this.statusBottom.Name = "statusBottom";
            this.statusBottom.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusBottom.Size = new System.Drawing.Size(723, 28);
            this.statusBottom.TabIndex = 6;
            this.statusBottom.Text = "statusStrip1";
            // 
            // processBar
            // 
            this.processBar.Name = "processBar";
            this.processBar.Size = new System.Drawing.Size(233, 22);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(331, 23);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(140, 23);
            this.copyrightLabel.Text = "安东石油信息化技术中心";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageFix);
            this.tabControlMain.Controls.Add(this.tabPageScan);
            this.tabControlMain.Controls.Add(this.tabPageSoftware);
            this.tabControlMain.Controls.Add(this.tabPageLinks);
            this.tabControlMain.Controls.Add(this.tabPageSchool);
            this.tabControlMain.Controls.Add(this.tabPageHelper);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.ImageList = this.imageIcons;
            this.tabControlMain.Location = new System.Drawing.Point(0, 25);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(723, 306);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabPageFix
            // 
            this.tabPageFix.Controls.Add(this.splitContainerAction);
            this.tabPageFix.ImageIndex = 0;
            this.tabPageFix.Location = new System.Drawing.Point(4, 25);
            this.tabPageFix.Name = "tabPageFix";
            this.tabPageFix.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFix.Size = new System.Drawing.Size(715, 277);
            this.tabPageFix.TabIndex = 0;
            this.tabPageFix.Text = "一键修复";
            this.tabPageFix.UseVisualStyleBackColor = true;
            // 
            // tabPageScan
            // 
            this.tabPageScan.Controls.Add(this.sysInfoLabel);
            this.tabPageScan.Controls.Add(this.sysInfoNameLabel);
            this.tabPageScan.ImageIndex = 3;
            this.tabPageScan.Location = new System.Drawing.Point(4, 25);
            this.tabPageScan.Name = "tabPageScan";
            this.tabPageScan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScan.Size = new System.Drawing.Size(715, 277);
            this.tabPageScan.TabIndex = 1;
            this.tabPageScan.Text = "系统检测";
            this.tabPageScan.UseVisualStyleBackColor = true;
            this.tabPageScan.Click += new System.EventHandler(this.tabPageScan_Click);
            // 
            // sysInfoNameLabel
            // 
            this.sysInfoNameLabel.AutoSize = true;
            this.sysInfoNameLabel.Location = new System.Drawing.Point(18, 16);
            this.sysInfoNameLabel.Name = "sysInfoNameLabel";
            this.sysInfoNameLabel.Size = new System.Drawing.Size(74, 16);
            this.sysInfoNameLabel.TabIndex = 0;
            this.sysInfoNameLabel.Text = "系统信息名称";
            // 
            // tabPageSoftware
            // 
            this.tabPageSoftware.ImageIndex = 2;
            this.tabPageSoftware.Location = new System.Drawing.Point(4, 25);
            this.tabPageSoftware.Name = "tabPageSoftware";
            this.tabPageSoftware.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSoftware.Size = new System.Drawing.Size(715, 277);
            this.tabPageSoftware.TabIndex = 2;
            this.tabPageSoftware.Text = "软件百宝箱";
            this.tabPageSoftware.UseVisualStyleBackColor = true;
            // 
            // tabPageLinks
            // 
            this.tabPageLinks.ImageIndex = 1;
            this.tabPageLinks.Location = new System.Drawing.Point(4, 25);
            this.tabPageLinks.Name = "tabPageLinks";
            this.tabPageLinks.Size = new System.Drawing.Size(715, 277);
            this.tabPageLinks.TabIndex = 3;
            this.tabPageLinks.Text = "公司网址";
            this.tabPageLinks.UseVisualStyleBackColor = true;
            // 
            // tabPageSchool
            // 
            this.tabPageSchool.ImageIndex = 4;
            this.tabPageSchool.Location = new System.Drawing.Point(4, 25);
            this.tabPageSchool.Name = "tabPageSchool";
            this.tabPageSchool.Size = new System.Drawing.Size(715, 277);
            this.tabPageSchool.TabIndex = 4;
            this.tabPageSchool.Text = "信息化学苑";
            this.tabPageSchool.UseVisualStyleBackColor = true;
            // 
            // tabPageHelper
            // 
            this.tabPageHelper.ImageIndex = 5;
            this.tabPageHelper.Location = new System.Drawing.Point(4, 25);
            this.tabPageHelper.Name = "tabPageHelper";
            this.tabPageHelper.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHelper.Size = new System.Drawing.Size(715, 277);
            this.tabPageHelper.TabIndex = 5;
            this.tabPageHelper.Text = "IT服务地图";
            this.tabPageHelper.UseVisualStyleBackColor = true;
            // 
            // sysInfoLabel
            // 
            this.sysInfoLabel.AutoSize = true;
            this.sysInfoLabel.Location = new System.Drawing.Point(128, 16);
            this.sysInfoLabel.Name = "sysInfoLabel";
            this.sysInfoLabel.Size = new System.Drawing.Size(52, 16);
            this.sysInfoLabel.TabIndex = 1;
            this.sysInfoLabel.Text = "系统信息";
            // 
            // splitContainerAction
            // 
            this.splitContainerAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAction.Location = new System.Drawing.Point(3, 3);
            this.splitContainerAction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerAction.Name = "splitContainerAction";
            // 
            // splitContainerAction.Panel1
            // 
            this.splitContainerAction.Panel1.Controls.Add(this.actionListBox);
            // 
            // splitContainerAction.Panel2
            // 
            this.splitContainerAction.Panel2.Controls.Add(this.actionTab);
            this.splitContainerAction.Size = new System.Drawing.Size(709, 271);
            this.splitContainerAction.SplitterDistance = 173;
            this.splitContainerAction.SplitterWidth = 5;
            this.splitContainerAction.TabIndex = 5;
            // 
            // actionListBox
            // 
            this.actionListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.actionListBox.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.actionListBox.FormattingEnabled = true;
            this.actionListBox.IntegralHeight = false;
            this.actionListBox.ItemHeight = 25;
            this.actionListBox.Location = new System.Drawing.Point(0, 0);
            this.actionListBox.Name = "actionListBox";
            this.actionListBox.Size = new System.Drawing.Size(173, 271);
            this.actionListBox.TabIndex = 0;
            this.actionListBox.SelectedIndexChanged += new System.EventHandler(this.actionListBox_SelectedIndexChanged);
            // 
            // actionTab
            // 
            this.actionTab.Controls.Add(this.actionTabPage);
            this.actionTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionTab.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.actionTab.ImageList = this.imageIcons;
            this.actionTab.Location = new System.Drawing.Point(0, 0);
            this.actionTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.actionTab.Name = "actionTab";
            this.actionTab.SelectedIndex = 0;
            this.actionTab.Size = new System.Drawing.Size(531, 271);
            this.actionTab.TabIndex = 0;
            // 
            // actionTabPage
            // 
            this.actionTabPage.Controls.Add(this.eventListBox);
            this.actionTabPage.Controls.Add(this.toolStripAction);
            this.actionTabPage.ImageIndex = 0;
            this.actionTabPage.Location = new System.Drawing.Point(4, 28);
            this.actionTabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.actionTabPage.Name = "actionTabPage";
            this.actionTabPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.actionTabPage.Size = new System.Drawing.Size(523, 239);
            this.actionTabPage.TabIndex = 1;
            this.actionTabPage.Text = "tabPage2";
            this.actionTabPage.UseVisualStyleBackColor = true;
            // 
            // eventListBox
            // 
            this.eventListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.eventListBox.FormattingEnabled = true;
            this.eventListBox.IntegralHeight = false;
            this.eventListBox.ItemHeight = 25;
            this.eventListBox.Location = new System.Drawing.Point(3, 31);
            this.eventListBox.Name = "eventListBox";
            this.eventListBox.Size = new System.Drawing.Size(517, 204);
            this.eventListBox.TabIndex = 1;
            // 
            // toolStripAction
            // 
            this.toolStripAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startActionButton});
            this.toolStripAction.Location = new System.Drawing.Point(3, 4);
            this.toolStripAction.Name = "toolStripAction";
            this.toolStripAction.Size = new System.Drawing.Size(517, 27);
            this.toolStripAction.TabIndex = 0;
            this.toolStripAction.Text = "toolStrip1";
            // 
            // startActionButton
            // 
            this.startActionButton.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.startActionButton.Image = ((System.Drawing.Image)(resources.GetObject("startActionButton.Image")));
            this.startActionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startActionButton.Name = "startActionButton";
            this.startActionButton.Size = new System.Drawing.Size(57, 24);
            this.startActionButton.Text = "执行";
            this.startActionButton.Click += new System.EventHandler(this.startActionButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 359);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusBottom);
            this.Controls.Add(this.menuTop);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuTop;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "IT助手 -- 安东石油信息化技术中心荣誉出品";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuTop.ResumeLayout(false);
            this.menuTop.PerformLayout();
            this.statusBottom.ResumeLayout(false);
            this.statusBottom.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageFix.ResumeLayout(false);
            this.tabPageScan.ResumeLayout(false);
            this.tabPageScan.PerformLayout();
            this.splitContainerAction.Panel1.ResumeLayout(false);
            this.splitContainerAction.Panel2.ResumeLayout(false);
            this.splitContainerAction.ResumeLayout(false);
            this.actionTab.ResumeLayout(false);
            this.actionTabPage.ResumeLayout(false);
            this.actionTabPage.PerformLayout();
            this.toolStripAction.ResumeLayout(false);
            this.toolStripAction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuTop;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerAction;
        private System.Windows.Forms.TabControl actionTab;
        private System.Windows.Forms.TabPage actionTabPage;
        private System.Windows.Forms.ToolStrip toolStripAction;
        private System.Windows.Forms.ToolStripButton startActionButton;
        private System.Windows.Forms.StatusStrip statusBottom;
        private System.Windows.Forms.ToolStripProgressBar processBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel copyrightLabel;
        private ActionListBox actionListBox;
        private EventListBox eventListBox;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageFix;
        private System.Windows.Forms.TabPage tabPageScan;
        private System.Windows.Forms.TabPage tabPageSoftware;
        private System.Windows.Forms.TabPage tabPageLinks;
        private System.Windows.Forms.TabPage tabPageSchool;
        private System.Windows.Forms.ImageList imageIcons;
        private System.Windows.Forms.TabPage tabPageHelper;
        private System.Windows.Forms.Label sysInfoNameLabel;
        private System.Windows.Forms.Label sysInfoLabel;
    }
}

