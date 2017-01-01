using System;
using System.Linq;
using System.Text;

namespace Book_Downloader
{
    public static class WebPageScraper
    {
        public static ILogger Logger { get; set; }
        public static string[] CreateDownloadAddresses(string[] lines)
        => lines
                .Where(element => element.Contains("http://libgen.io/ads.php?md5="))
                .Select(element => element.Split('\'')[1])
                .ToArray();

        public static void CreateLanguageAndExtensions(string[] lines, out string[] languages, out string[] extensions)
        {
            string[] elements = lines
                .Where(element => element.Contains("<td nowrap"))
                .Where((string element, int index) => index % 2 == 1)
                .Select(element => element.Split('<', '>')[2])
                .Select(element => element.Trim())
                .ToArray();
            languages = elements.Where((string element, int index) => index % 2 == 0).ToArray();
            extensions = elements.Where((string element, int index) => index % 2 == 1).ToArray();
        }


        public static string[] CreateBookNames(string[] lines)
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
            .Select(element => Encoding.UTF8.GetString(Encoding.Default.GetBytes(element)))
            .ToArray();

        public static bool CheckForNextPage(string[] lines)
            => lines.Last().StartsWith("< table width = \"100%\" >");

        public static string DownloadKey(string hyperText)
            => CombinedLine(hyperText)
                .Split('>')[1]
                .Split('=')[3];

        public static string GetFileName(string hyperText,out bool needExtension)
        {
            try {
                needExtension = false;
                return CombinedLine(hyperText)
                          .Split(new string[] { "value" }, StringSplitOptions.RemoveEmptyEntries)[1]
                          .Split('\"')[1];
            }
            catch (IndexOutOfRangeException)
            {
                string[] lines = hyperText.Split('\n').Where(element => element.Trim() != string.Empty).ToArray();
                string line = lines.Where(element => element.Contains("title"))
                  .Where((string element, int index) => index == 1).First();
                string result = line.Split('{', '}')[1];
                needExtension = true;
                return result;
            }
        }
        public static string CombinedLine(string hypertext)
            => hypertext.Split('\n').Where(line => line.Contains("DOWNLOAD")).First();
    }
}
