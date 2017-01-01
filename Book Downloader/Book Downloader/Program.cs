using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book_Downloader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (Environment.GetEnvironmentVariable("BookDownloader",EnvironmentVariableTarget.User) == null)
            {
                DriveInfo biggest=null;
                foreach(DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (biggest == null)
                    {
                        biggest = drive;
                    }
                    if (drive.AvailableFreeSpace > biggest.AvailableFreeSpace) biggest = drive;
                }
                Environment.SetEnvironmentVariable("BookDownloader",string.Format("{0}BookDownloader",biggest.Name));
                Directory.CreateDirectory(string.Format("{0}BookDownloader", biggest.Name));
            }
            IPrecedenceCreator picker = new DefaultPrecedencePicker();
            ILogger logger = new DefaultLogger();
            if (File.Exists("Precedences.txt"))
            {
                using(StreamReader reader=new StreamReader("Precedences.txt"))
                {
                    picker = new DefaultPrecedencePicker(reader.ReadToEnd()); 
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFormController(picker,logger));
        }
    }
}
