using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Downloader
{
    class DefaultLogger : ILogger
    {
        public void Error(Severity severity, string message, params object[] elements)
        {
            WriteMessage("ERROR",severity,message,elements);
        }

        public void Signal(Severity severity, string message, params object[] elements)
        {
            WriteMessage("SIGNAL", severity, message, elements);
        }

        public void Warning(Severity severity, string message, params object[] elements)
        {
            WriteMessage("WARNING", severity, message, elements);
        }

        private void WriteMessage(string type,Severity severity,string message,params object[] elements)
        {
            using (StreamWriter writer = new StreamWriter($"{type}s.txt", true))
            {
                writer.Write($"{severity} {type} {message} :");
                foreach (object element in elements) { writer.Write($"{element}\t"); }
                writer.WriteLine();
            }
        }
    }
}
