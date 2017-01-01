using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Book_Downloader
{
    class DownloadSession : WebClient
    {
        public string FileName { get; private set; }
        public Uri Address { get; private set; }
        public DownloadSession(Uri address,string fileName):base()
        {
            FileName = fileName;
            Address = address;
            DownloadDataAsync(address, fileName);
        }
    }
}
