namespace cn.antontech.ITHelper.AutoActions
{
    partial class Download
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
            this.linkLabelNum = new System.Windows.Forms.LinkLabel();
            this.linkLabelPrecent = new System.Windows.Forms.LinkLabel();
            this.label = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // linkLabelNum
            // 
            this.linkLabelNum.AutoSize = true;
            this.linkLabelNum.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelNum.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelNum.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.linkLabelNum.Location = new System.Drawing.Point(327, 150);
            this.linkLabelNum.Name = "linkLabelNum";
            this.linkLabelNum.Size = new System.Drawing.Size(53, 12);
            this.linkLabelNum.TabIndex = 9;
            this.linkLabelNum.TabStop = true;
            this.linkLabelNum.Text = "[00/100]";
            // 
            // linkLabelPrecent
            // 
            this.linkLabelPrecent.AutoSize = true;
            this.linkLabelPrecent.Font = new System.Drawing.Font("宋体", 36F);
            this.linkLabelPrecent.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelPrecent.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.linkLabelPrecent.Location = new System.Drawing.Point(321, 16);
            this.linkLabelPrecent.Name = "linkLabelPrecent";
            this.linkLabelPrecent.Size = new System.Drawing.Size(92, 48);
            this.linkLabelPrecent.TabIndex = 8;
            this.linkLabelPrecent.TabStop = true;
            this.linkLabelPrecent.Text = "00%";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(29, 47);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(59, 12);
            this.label.TabIndex = 7;
            this.label.Text = "下载中...";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(31, 92);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(400, 18);
            this.progressBar.TabIndex = 5;
            // 
            // Download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 180);
            this.Controls.Add(this.linkLabelNum);
            this.Controls.Add(this.linkLabelPrecent);
            this.Controls.Add(this.label);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Download";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Download_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelNum;
        private System.Windows.Forms.LinkLabel linkLabelPrecent;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}