using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveLetterToEqualizeFrequency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var word = "zz";
            Console.WriteLine(EqualFrequency(word));
        }

        public static bool EqualFrequency(string word)
        {
            var dict = word.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            if (dict.Count == 1)
                return true;
            var freqs = new Dictionary<int, int>();
            foreach (var letter in dict.Keys)
            {
                var freq = dict[letter];
                if (!freqs.ContainsKey(freq))
                    freqs[freq] = 0;
                freqs[freq]++;
            }
            var keys = freqs.Select(x => x.Key).OrderBy(x => x).ToList();
            if (keys.Count == 1)
                return keys[0] == 1;
            if (keys.Count > 2 || keys[^1] - keys[0] != 1)
                return false;
            return freqs[keys[0]] == 1 || freqs[keys[^1]] == 1;
        }
    }
}
