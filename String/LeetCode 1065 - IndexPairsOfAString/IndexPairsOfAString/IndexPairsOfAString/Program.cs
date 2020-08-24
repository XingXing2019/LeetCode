using System;
using System.Collections.Generic;
using System.Linq;

namespace IndexPairsOfAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "ababa";
            string[] words = {"aba", "ab"};
            Console.WriteLine(IndexPairs(text, words));
        }
        static int[][] IndexPairs(string text, string[] words)
        {
            var pairs = new List<int[]>();
            for (int i = 0; i < text.Length; i++)
            {
                foreach (var word in words)
                {
                    if(text[i] != word[0] || i > text.Length - word.Length) continue;
                    if(text.Substring(i, word.Length) == word)
                        pairs.Add(new int[]{i, i + word.Length - 1});
                }
            }
            var res = pairs.OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();
            return res;
        }
    }
}
