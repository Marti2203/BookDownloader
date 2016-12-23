using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Downloader
{
    public interface IPrecedenceCreator
    {
        int this[string fileType] { get; }
    }
}
