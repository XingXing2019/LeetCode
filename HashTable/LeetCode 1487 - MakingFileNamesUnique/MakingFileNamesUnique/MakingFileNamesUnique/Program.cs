using System;
using System.Collections.Generic;
using System.Text;

namespace MakingFileNamesUnique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string[] GetFolderNames(string[] names)
        {
            var dict = new Dictionary<string, int>();
            var res = new string[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                if (!dict.ContainsKey(names[i]))
                {
                    res[i] = names[i];
                    dict[names[i]] = 1;
                }
                else
                {
                    var version = dict[names[i]];
                    var temp = new StringBuilder($"{names[i]}({version})");
                    while (dict.ContainsKey(temp.ToString()))
                        temp = new StringBuilder($"{names[i]}({++version})");
                    res[i] = temp.ToString();
                    dict[temp.ToString()] = 1;
                    dict[names[i]] = version + 1;
                }
            }
            return res;
        }
    }
}
