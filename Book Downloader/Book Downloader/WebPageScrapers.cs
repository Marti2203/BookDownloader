using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book_Downloader
{
    public partial class MainFormController : Form
    {

        private static string[] CreateDownloadAddresses(string[] lines)
        => lines
                .Where(element => element.Contains("http://libgen.io/ads.php?md5="))
                .Select(element => element.Split('\'')[1])
                .ToArray();


        private static string[] CreateLanguageAndExtensions(string[] lines)
        => lines
                .Where(element => element.Contains("<td nowrap"))
                .Where((element, index) => index % 2 == 1)
                .Select(element => element.Split('<', '>')[2])
                .ToArray();


        private static string[] CreateBookNames(string[] lines)
        => lines
            .Where(element => element.Contains("<td width="))                       
            .Select(element =>
                        {
                            StringBuilder builder = new StringBuilder();
                            int counter = 0;
                            foreach (char character in element)
                            {
                                if (character == '<')
                                    counter++;
                                if (character == '>')
                                    counter--;
                                if (counter == 0 && character != '.')
                                    builder.Append(character);
                            }
                            string result = builder
                            .ToString()
                            .Trim()
                            .Trim('>');

                            int index = 0;
                            if ((index = result.LastIndexOf(" >>")) != -1)
                                result = result.Remove(index).Trim('>').Replace('>', ' ');

                            result = result.Replace('>', ' ');

                            string[] splittedParts;
                            if ((splittedParts = result.Split(new string[] { "  " }, StringSplitOptions.RemoveEmptyEntries)).Length == 2)
                                result = splittedParts[0];
                            else if (splittedParts.Length == 3)
                                result = splittedParts[1];

                            return result.Trim();
                        })
            .ToArray();

        private bool CheckForNextPage(string line) 
            => line
                .StartsWith("< table width = \"100%\" >");

        private static string DownloadKey(string hyperText)
        => hyperText
            .Split('\n')
            .Where(line => line.Contains("DOWNLOAD"))
            .First()
            .Split('>')[1]
            .Split('=')[3];
    }
}
