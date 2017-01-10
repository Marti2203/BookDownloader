#define Debug
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Drawing;

namespace Book_Downloader
{
    public partial class MainFormController : Form
    {
        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Invoke(new MethodInvoker(() => OutputTextBox.Text = string.Format("Current Progress :{0}% {1}", e.ProgressPercentage, ((DownloadSession)sender).FileName)));
        }

        [Obsolete]
        public void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                UnlockButtons();
                OutputTextBox.Clear();
            }));

            if (e.Cancelled)
                Invoke(new MethodInvoker(() => OutputTextBox.Text=$"Cancelled downloading for {((DownloadSession)sender).FileName}"));

            if (e.Error != null)
            {
                Invoke(new MethodInvoker(() =>
                {
                    ErrorTextBox.Clear();
                    ErrorTextBox.AppendText($@"{e.Error.Message} 
                    \n { e.Error.StackTrace}
                    \n { e.Error?.InnerException?.Message }
                    \n { e.Error?.InnerException?.StackTrace}");
                }));
            }

            else
            {
                Invoke(new MethodInvoker(() => OutputTextBox.AppendText($"Done with {((DownloadSession)sender).FileName}")));
            }

            IsDownloading = false;

            if (NotifyOnDone)
                Invoke(new MethodInvoker(() => Notify()));

        }

        private void DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            IsDownloading = false;
            if (NotifyOnDone)
                Invoke(new MethodInvoker(() => Notify()));
            Invoke(new MethodInvoker(() =>
            {
                UnlockButtons();
                StopAsyncButton.Enabled = false;
                OutputTextBox.Clear();
            }));

            if (e.Cancelled)
            {
                Invoke(new MethodInvoker(() => OutputTextBox.Text = $"Cancelled downloading for {((DownloadSession)sender).FileName}"));
            }
            else if (e.Error != null)
            {
                Invoke(new MethodInvoker(() =>
                    ErrorTextBox.Text = $@"{e.Error.Message}
                    { e.Error.StackTrace}
                    { e.Error?.InnerException?.Message }
                    { e.Error?.InnerException?.StackTrace}"
                ));
            }
            else
            {
                Invoke(new MethodInvoker(() => OutputTextBox.Text = $"Finished downloading for {((DownloadSession)sender).FileName}"));
                File.WriteAllBytes(string.Format(@"\\?\{0}{1}", downloadLocation, ((DownloadSession)sender).FileName), e.Result);
            }
        }

        public void Notify()
        {
            WindowState = FormWindowState.Minimized;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void NotifyBox_CheckedChanged(object sender, EventArgs e)
        {
            NotifyOnDone = !NotifyOnDone;
        }
    }
}