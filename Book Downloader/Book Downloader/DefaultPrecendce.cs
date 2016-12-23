using System;
using System.Collections.Generic;
using System.Linq;
namespace Book_Downloader
{
    public class DefaultPrecedencePicker : IPrecedenceCreator
    {
        private static string[] defaultValues = new string[]
        {
            "lit:0","djvu:1", "mobi:2" ,"chm:3","epub:4","pdf:5" ,"zip:6"
        };
        private readonly Dictionary<string, int> _values = new Dictionary<string, int>();

        public DefaultPrecedencePicker() : this(defaultValues) { }

        public DefaultPrecedencePicker(string[] lines)
        {
            foreach (string line in lines)
            {
                string[] values = line.Split(':').Select(element => element.Trim()).ToArray();
                _values.Add(values[0], int.Parse(values[1]));
            }
        }

        public int this[string fileType]
        {
            get
            {
                if (_values.ContainsKey(fileType))
                    return _values[fileType];
                return -1;
            }
        }
    }
}