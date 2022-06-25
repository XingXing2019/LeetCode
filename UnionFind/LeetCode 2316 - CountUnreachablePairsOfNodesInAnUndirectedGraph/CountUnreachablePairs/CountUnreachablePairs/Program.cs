using System;
using System.Collections.Generic;
using System.Linq;

namespace CountUnreachablePairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 100000;
            int[][] edges = {
               
            };
            Console.WriteLine(CountPairs(n, edges));
        }

        private static int[] parents;
        private static int[] rank;
        public static long CountPairs(int n, int[][] edges)
        {
            parents = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; i++)
                parents[i] = i;
            foreach (var edge in edges)
                Union(edge[0], edge[1]);
            var dict = new Dictionary<int, long>();
            long res = 0, sum = n;
            for (int i = 0; i < n; i++)
            {
                var root = Find(i);
                dict[root] = dict.GetValueOrDefault(root, 0) + 1;
            }
            var groups = dict.Select(x => x.Value).ToArray();
            foreach (var count in groups)
            {
                res += count * (sum - count);
                sum -= count;
            }
            return res;
        }

        public static int Find(int x)
        {
            if (parents[x] != x)
                parents[x] = Find(parents[x]);
            return parents[x];
        }

        public static void Union(int x, int y)
        {
            int rootX = Find(x), rootY = Find(y);
            if (rootX == rootY)
                return;
            if (rank[rootX] >= rank[rootY])
            {
                parents[rootY] = rootX;
                if (rank[rootX] == rank[rootY])
                    rank[rootX]++;
            }
            else
                parents[rootX] = rootY;
        }
    }
}
