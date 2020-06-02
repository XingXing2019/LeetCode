using System;
using System.Collections.Generic;
using System.Linq;

namespace RearrangeWordsInASentence
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "Leetcode is cool";
            Console.WriteLine(ArrangeWords_HashMap(text));
        }
        static string ArrangeWords_OrderBy(string text)
        {
            var words = text.Split(' ');
            var res = "";
            words[0] = words[0].ToLower();
            words = words.OrderBy(x => x.Length).ToArray();
            res = string.Join(' ', words);
            return char.ToUpper(res[0]) + res.Substring(1);
        }
        static string ArrangeWords_HashMap(string text)
        {
            var words = text.Split(' ');
            words[0] = words[0].ToLower();
            var longest = words.Max(word => word.Length);
            var records = new List<string>[longest + 1];
            var res = "";
            foreach (var word in words)
            {
                if (records[word.Length] == null)
                    records[word.Length] = new List<string> { word };
                else
                    records[word.Length].Add(word);
            }
            foreach (var record in records)
            {
                if (record == null)
                    continue;
                res += string.Join(' ', record) + " ";
            }
            return char.ToUpper(res[0]) + res.Substring(1, res.Length - 2);
        }
    }
}
