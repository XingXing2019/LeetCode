using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LongestWordInDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = {"a", "banana", "app", "appl", "ap", "apple", "apply"};
            Console.WriteLine(LongestWord(words));
        }
        static string LongestWord(string[] words)
        {
            var record = new HashSet<string>();
            foreach (var word in words)
                record.Add(word);
            var res = new List<string>(words);
            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (!record.Contains(word.Substring(0, i + 1)))
                    {
                        res.Remove(word);
                        break;
                    }
                }
            }
            res = res.OrderByDescending(x => x.Length).ThenBy(x => x).ToList();
            return res[0];
        }
    }
}
