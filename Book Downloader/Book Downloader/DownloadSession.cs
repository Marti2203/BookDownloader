using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Book_Downloader
{
    class DownloadSession:WebClient
    {
        string fileName;
        public DownloadSession(Uri address,string fileName):base()
        {
            this.fileName = fileName;
            DownloadFileAsync(address, fileName);
            DownloadFileCompleted += DownloadCompleted;
        }
        public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            File.Move(fileName, @"D:\Books");
        }
    }
}
