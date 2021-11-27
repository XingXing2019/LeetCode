using System;
using System.Linq;

namespace CountCommonWordsWithOneOccurrence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountWords(string[] words1, string[] words2)
        {
            var dict1 = words1.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var dict2 = words2.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var res = 0;
            foreach (var word in dict1.Keys)
            {
                if (dict1[word] == 1 && dict2.ContainsKey(word) && dict2[word] == 1)
                    res++;
            }
            return res;
        }
    }
}
