using System;
using System.Collections.Generic;

namespace CountPairsOfSimilarStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "aba", "aabb", "abcd", "bac", "aabc" };
            Console.WriteLine(SimilarPairs(words));
        }

        public static int SimilarPairs(string[] words)
        {
            var dict = new Dictionary<int, int>();
            var res = 0;
            foreach (var word in words)
            {
                var code = Encoding(word);
                if (!dict.ContainsKey(code))
                    dict[code] = 0;
                dict[code]++;
            }
            foreach (var freq in dict.Values)
                res += freq * (freq - 1) / 2;
            return res;
        }

        public static int Encoding(string word)
        {
            var code = 0;
            foreach (var l in word)
                code |= 1 << (l - 'a');
            return code;
        }
    }
}
