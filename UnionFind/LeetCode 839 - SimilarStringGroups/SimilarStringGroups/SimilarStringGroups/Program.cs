using System;
using System.Collections.Generic;

namespace SimilarStringGroups
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private Dictionary<string, string> parents;
        private Dictionary<string, int> rank;

        public int NumSimilarGroups(string[] strs)
        {
            parents = new Dictionary<string, string>();
            rank = new Dictionary<string, int>();
            foreach (var s in strs)
            {
                parents[s] = s;
                rank[s] = 0;
            }
            for (int i = 0; i < strs.Length; i++)
            {
                for (int j = i + 1; j < strs.Length; j++)
                {
                    string x = strs[i], y = strs[j];
                    if (!IsSimilar(x, y)) continue;
                    Union(x, y);
                }   
            }
            var res = new HashSet<string>();
            foreach (var s in strs)
            {
                var parent = Find(s);
                res.Add(parent);
            }
            return res.Count;
        }

        private string Find(string x)
        {
            if (parents[x] != x)
                parents[x] = Find(parents[x]);
            return parents[x];
        }

        private bool Union(string x, string y)
        {
            string rootX = Find(x), rootY = Find(y);
            if (rootX == rootY) return false;
            if (rank[rootX] < rank[rootY])
                parents[rootX] = rootY;
            else
            {
                parents[rootY] = rootX;
                if (rank[rootX] == rank[rootY])
                    rank[rootX]++;
            }
            return true;
        }

        private bool IsSimilar(string word1, string word2)
        {
            var diff = 0;
            for (int i = 0; i < word1.Length; i++)
            {
                if (word1[i] == word2[i]) continue;
                diff++;
            }
            return diff <= 2;
        }
    }
}
