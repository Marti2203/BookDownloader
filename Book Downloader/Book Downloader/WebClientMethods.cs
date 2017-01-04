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
                
#if Debug

#else
                File.Move(((DownloadSession)sender).FileName, Environment.GetEnvironmentVariable("BookDownloader", EnvironmentVariableTarget.User) + ((DownloadSession)sender).FileName);
#endif
            }

            IsDownloading = false;

            if (NotifyBox.Checked)
                Invoke(new MethodInvoker(() => Notify()));

        }

        private void DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            IsDownloading = false;
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
                File.WriteAllBytes(string.Format(@"\\?\{0}{1}", Environment.GetEnvironmentVariable("BookDownloader"), ((DownloadSession)sender).FileName), e.Result);
            }
        }

        private void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Error != null)
            {
                return;
            }
            BackgroundImage = new Bitmap(new MemoryStream(e.Result));
            Invoke(new MethodInvoker(() => Refresh()));
        }

        public void Notify()
        {
            WindowState = FormWindowState.Minimized;
            Show();
            WindowState = FormWindowState.Normal;
        }
        
    }
}