using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace cn.antontech.ITHelper.AutoActions
{
    public partial class Download : Form
    {
        //public delegate void mainFormContentControl(bool isFinish);

        public Download(string _downLoadPath, string _filePath, string _fileName)
        {
            InitializeComponent();
            DownLoadPath = _downLoadPath;
            FilePath = _filePath;
            FileName = _fileName;
        }

        public string DownLoadPath { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }

        //public event mainFormContentControl contentControl;

        private void Download_Load(object sender, EventArgs e)
        {
            label.Text = String.Format("[{0}]下载中...", FileName);
            fileDownloading();
        }

        private void fileDownloading()
        {
            try
            {
                WebClient wc = new WebClient();
                wc.DownloadFileAsync(new Uri(DownLoadPath), FilePath);
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;
            }
            catch(WebException we)
            {
                MessageBox.Show(we.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Action<DownloadProgressChangedEventArgs> onCompleted = progressChanging;
            onCompleted.Invoke(e);
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Action<AsyncCompletedEventArgs> onCompleted = progressCompleted;
            onCompleted.Invoke(e);
        }

        private void progressChanging(DownloadProgressChangedEventArgs obj)
        {
            progressBar.Value = obj.ProgressPercentage;
            linkLabelPrecent.Text = String.Format("{0}%", obj.ProgressPercentage);
            linkLabelNum.Text = String.Format("{0}M/{1}M", Math.Round((double)obj.BytesReceived / 1024 / 1024, 2), Math.Round((double)obj.TotalBytesToReceive / 1024 / 1024, 2));
        }

        private void progressCompleted(AsyncCompletedEventArgs obj)
        {
            label.Text = String.Format("[{0}]下载已经完成！", FileName);
            this.Dispose();
        }
    }
}
