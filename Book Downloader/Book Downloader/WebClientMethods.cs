#define Release
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Book_Downloader
{
    public partial class MainFormController : Form
    {
        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            OutputTextBox.Text = string.Format("Current Progress :{0}% {1}", e.ProgressPercentage, ((DownloadSession)sender).FileName);
        }

        public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                UnlockButtonsAndView();
                OutputTextBox.Clear();
            }));

            if (e.Cancelled)
                OutputTextBox.AppendText("Cancelled?!");
            if (e.Error != null)
            {
                OutputTextBox.AppendText("Failed" + e.Error?.StackTrace + e.Error?.InnerException?.StackTrace);
                File.Delete(((DownloadSession)sender).FileName);
            }
            
            else
            {
                OutputTextBox.Text = "DONE";
                File.Move(((DownloadSession)sender).FileName, Environment.GetEnvironmentVariable("BookDownloader", EnvironmentVariableTarget.User) + ((DownloadSession)sender).FileName);
            }

            IsDownloading = false;
            if (NotifyOnDone)
                Invoke(new MethodInvoker(()=>Notify()));
            
        }
        
        public void Notify()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

    }
}