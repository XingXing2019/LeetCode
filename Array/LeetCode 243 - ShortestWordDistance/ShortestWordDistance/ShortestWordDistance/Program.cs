using System;
using System.Collections.Generic;

namespace ShortestWordDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int ShortestDistance(string[] words, string word1, string word2)
        {
            var dict = new Dictionary<string, List<int>>();
            for (int i = 0; i < words.Length; i++)
            {
                if(!dict.ContainsKey(words[i]))
                    dict[words[i]] = new List<int>();
                dict[words[i]].Add(i);
            }
            int p1 = 0, p2 = 0, res = int.MaxValue;
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

        static int ShortestDistance_OnePass(string[] words, string word1, string word2)
        {
            int p1 = -1, p2 = -1, res = int.MaxValue;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == word1)
                    p1 = i;
                else if (words[i] == word2)
                    p2 = i;
                if(p1 != -1 && p2 != -1)
                    res = Math.Min(res, Math.Abs(p1 - p2));
            }
            return res;
        }
    }
}
