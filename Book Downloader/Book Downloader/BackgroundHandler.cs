using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Book_Downloader
{
    public abstract class BackgroundHandler
    {
        protected readonly Form _form;
        
        public BackgroundHandler(BackgroundChange change, Form form)
        {
            _form = form;
            Startup(change);
        }

        protected abstract void Startup(BackgroundChange change);

        public abstract void Resized();

        public void ChangeBackground()
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadDataAsync(new Uri($"https://unsplash.it/{_form.Width}/{_form.Height}/?random"));
                client.DownloadDataCompleted += DownloadDataCompleted;
            }
        }

        private void DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Error != null)
            {
                return;
            }
            _form.BackgroundImage = new Bitmap(new MemoryStream(e.Result));
            _form.Invoke(new MethodInvoker(() => _form.Refresh()));
        }
    }
}
