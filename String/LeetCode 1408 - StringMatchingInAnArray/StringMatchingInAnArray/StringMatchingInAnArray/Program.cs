using System;
using System.Collections.Generic;
using System.Linq;

namespace StringMatchingInAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static IList<string> StringMatching(string[] words)
        {
            var res = new List<string>();
            words = words.OrderBy(w => w.Length).ToArray();
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (words[j].Contains(words[i]))
                    {
                        res.Add(words[i]);
                        break;
                    }
                }
            }
            return res;
        }
    }
}
