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
            IPrecedenceCreator picker = new DefaultPrecedencePicker();
            if (File.Exists("Precedences.txt"))
            {
                using(StreamReader reader=new StreamReader("Precedences.txt"))
                {
                    picker = new DefaultPrecedencePicker(reader.ReadToEnd().Split('\n')); 
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFormController(picker,new DefaultLogger()));
        }
    }
}
