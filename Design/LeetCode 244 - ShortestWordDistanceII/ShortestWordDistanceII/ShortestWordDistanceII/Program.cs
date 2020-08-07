using System;
using System.Collections.Generic;

namespace ShortestWordDistanceII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class WordDistance
    {
        private Dictionary<string, List<int>> dict;
        public WordDistance(string[] words)
        {
            dict = new Dictionary<string, List<int>>();
            for (int i = 0; i < words.Length; i++)
            {
                if(!dict.ContainsKey(words[i]))
                    dict[words[i]] = new List<int>();
                dict[words[i]].Add(i);
            }
        }

        public int Shortest(string word1, string word2)
        {
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
    }
}
