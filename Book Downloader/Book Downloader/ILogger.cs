using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Downloader
{
    interface ILogger
    {
        void Error(Severity severity,string message,params object[] elements);
        void Warning(Severity severity, string message, params object[] elements);
        void Signal(Severity severity, string message, params object[] elements);
    }
    enum Severity
    {
        Low,
        Medium,
        High,
        SEVERE
    }
}
