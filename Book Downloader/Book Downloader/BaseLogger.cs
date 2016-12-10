using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Downloader
{
#warning Implement Logger
    class BaseLogger : ILogger
    {
        public void Error(Severity severity, string message, params object[] elements)
        {
            throw new NotImplementedException();
        }

        public void Signal(Severity severity, string message, params object[] elements)
        {
            throw new NotImplementedException();
        }

        public void Warning(Severity severity, string message, params object[] elements)
        {
            throw new NotImplementedException();
        }
    }
}
