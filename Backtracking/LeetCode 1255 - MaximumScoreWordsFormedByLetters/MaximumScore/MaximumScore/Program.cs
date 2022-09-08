using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "add", "dda", "bb" };
            char[] letters = { 'a', 'a', 'b', 'b', 'b', 'b', 'd' };
            int[] scores = { 3, 9, 8, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Console.WriteLine(MaxScoreWords(words, letters, scores));
        }

        public static int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            var res = 0;
            var freq = letters.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            for (int i = 0; i < 26; i++)
            {
                if (freq.ContainsKey((char) (i + 'a'))) continue;
                freq[(char)(i + 'a')] = 0;
            }
            DFS(words, 0, freq, score, 0, ref res);
            return res;
        }

        public static void DFS(string[] words, int start, Dictionary<char, int> freq, int[] scores, int score, ref int res)
        {
            if (freq.Any(x => x.Value < 0))
                return;
            res = Math.Max(res, score);
            for (int i = start; i < words.Length; i++)
            {
                var temp = 0;
                foreach (var l in words[i])
                {
                    temp += scores[l - 'a'];
                    freq[l]--;
                }
                DFS(words, i + 1, freq, scores, score + temp, ref res);
                foreach (var l in words[i])
                {
                    freq[l]++;
                }
            }
        }
    }
}
