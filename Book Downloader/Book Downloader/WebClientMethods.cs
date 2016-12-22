#define Debug
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
            Invoke(new MethodInvoker(() => OutputTextBox.Text = string.Format("Current Progress :{0}% {1}", e.ProgressPercentage, ((DownloadSession)sender).FileName)));
        }

        public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                UnlockButtons();
                OutputTextBox.Clear();
            }));

            if (e.Cancelled)
                ErrorTextBox.AppendText("Cancelled?!");

            if (e.Error != null)
            {
                Invoke(new MethodInvoker(() =>
                {
                    ErrorTextBox.Clear();
                    ErrorTextBox.AppendText(e.Error.Message + '\n'
                                + e.Error.StackTrace
                                + e.Error?.InnerException?.Message
                                + e.Error?.InnerException?.StackTrace);
                }));
                if (File.Exists(((DownloadSession)sender).FileName))
                    File.Delete(((DownloadSession)sender).FileName);
            }

            else
            {
                Invoke(new MethodInvoker(() => OutputTextBox.AppendText($"Done with {((DownloadSession)sender).FileName}")));
#if Debug

#else
                File.Move(((DownloadSession)sender).FileName, Environment.GetEnvironmentVariable("BookDownloader", EnvironmentVariableTarget.User) + ((DownloadSession)sender).FileName);
#endif           
            }

            IsDownloading = false;
            if (NotifyOnDone)
                Invoke(new MethodInvoker(() => Notify()));

        }

        public void Notify()
        {
            WindowState = FormWindowState.Minimized;
            Show();
            WindowState = FormWindowState.Normal;
        }

    }
}