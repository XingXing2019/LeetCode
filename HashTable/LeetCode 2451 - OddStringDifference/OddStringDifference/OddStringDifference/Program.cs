using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OddStringDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "abm", "bcn", "alm" };
            Console.WriteLine(OddString(words));
        }

        public static string OddString(string[] words)
        {
            var freq = new Dictionary<string, int>();
            var dict = new Dictionary<string, string>();
            foreach (var word in words)
            {
                var code = Encoding(word);
                dict[code] = word;
                if (!freq.ContainsKey(code))
                    freq[code] = 0;
                freq[code]++;
            }
            return dict[freq.Where(x => x.Value == 1).First().Key];
        }

        private static string Encoding(string word)
        {
            var res = new StringBuilder();
            for (int i = 1; i < word.Length; i++)
                res.Append($":{word[i] - word[i - 1]}");
            return res.ToString();
        }
    }
}
