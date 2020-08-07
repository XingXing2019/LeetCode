using System;
using System.Collections.Generic;

namespace ShortestWordDistanceIII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int ShortestWordDistance(string[] words, string word1, string word2)
        {
            var dict = new Dictionary<string, List<int>>();
            for (int i = 0; i < words.Length; i++)
            {
                if(!dict.ContainsKey(words[i]))
                    dict[words[i]] = new List<int>();
                dict[words[i]].Add(i);
            }
            var res = int.MaxValue;
            if (word1 == word2)
            {
                for (int i = 1; i < dict[word1].Count; i++)
                    res = Math.Min(res, dict[word1][i] - dict[word1][i - 1]);
                return res;
            }
            int p1 = 0, p2 = 0;
            while (p1 < dict[word1].Count && p2 < dict[word2].Count)
            {
                res = Math.Min(res, Math.Abs(dict[word1][p1] - dict[word2][p2]));
                if (dict[word1][p1] > dict[word2][p2])
                    p2++;
                else
                    p1++;
            }
            return res;
        }
    }
}
