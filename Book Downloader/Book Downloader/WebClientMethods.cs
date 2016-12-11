#define Release
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Book_Downloader
{
    public partial class MainForm : Form
    {
        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            OutputTextBox.Text = string.Format("Current Progress :{0}% {1}", e.ProgressPercentage, ((DownloadSession)sender).FileName);
        }

        public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            OutputTextBox.Clear();
            if (e.Cancelled)
                OutputTextBox.AppendText("Cancelled?!");
            if (e.Error != null)
                OutputTextBox.AppendText("Failed" + e.Error.StackTrace);
            else
            {
                OutputTextBox.Text = "DONE";
                File.Move(((DownloadSession)sender).FileName, MainFormResources.DownloadLocation);
            }
            IsDownloading = false;
        }

    }
}