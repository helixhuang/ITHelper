namespace ITHelper
{
    partial class Updating
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
            this.labelVersion = new System.Windows.Forms.Label();
            this.progressUpdate = new System.Windows.Forms.ProgressBar();
            this.labelMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(12, 9);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(35, 13);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "label1";
            // 
            // progressUpdate
            // 
            this.progressUpdate.Location = new System.Drawing.Point(12, 35);
            this.progressUpdate.Name = "progressUpdate";
            this.progressUpdate.Size = new System.Drawing.Size(368, 23);
            this.progressUpdate.TabIndex = 1;
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.Location = new System.Drawing.Point(12, 73);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(35, 13);
            this.labelMsg.TabIndex = 2;
            this.labelMsg.Text = "label1";
            // 
            // Updating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 105);
            this.Controls.Add(this.labelMsg);
            this.Controls.Add(this.progressUpdate);
            this.Controls.Add(this.labelVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Updating";
            this.Text = "检查更新";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.ProgressBar progressUpdate;
        private System.Windows.Forms.Label labelMsg;
    }
}