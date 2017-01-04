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
            CreateDownloadFolder();

            IPrecedenceCreator picker = new DefaultPrecedencePicker();
            ILogger logger = new DefaultLogger();
            if (File.Exists("Precedences.txt"))
            {
                using (StreamReader reader = new StreamReader("Precedences.txt"))
                {
                    picker = new DefaultPrecedencePicker(reader.ReadToEnd());
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFormController(picker, logger));
        }

        private static void CreateDownloadFolder()
        {
            DriveInfo biggest = null;
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (biggest == null)
                {
                    biggest = drive;
                }
                try
                {
                    if (drive.AvailableFreeSpace > biggest.AvailableFreeSpace) biggest = drive;
                }
                catch (IOException) { }
            }
            Environment.SetEnvironmentVariable("BookDownloader", string.Format("{0}BookDownloader", biggest.Name), EnvironmentVariableTarget.User);
            Directory.CreateDirectory(string.Format("{0}BookDownloader", biggest.Name));
        }
    }
}
