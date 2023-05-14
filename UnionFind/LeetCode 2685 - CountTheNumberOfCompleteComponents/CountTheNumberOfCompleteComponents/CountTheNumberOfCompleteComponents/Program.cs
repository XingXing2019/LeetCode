using System;
using System.Collections.Generic;
using System.Linq;

namespace CountTheNumberOfCompleteComponents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 6;
            int[][] edges = new int[][]
            {
                new[] { 0, 1 },
                new[] { 0, 2 },
                new[] { 1, 2 },
                new[] { 3, 4 },
            };
            Console.WriteLine(CountCompleteComponents(n, edges));
        }

        private static int[] parents;
        private static int[] rank;
        public static int CountCompleteComponents(int n, int[][] edges)
        {
            var res = 0;
            parents = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; i++)
                parents[i] = i;
            var usefulEdges = new Dictionary<int, int>();
            foreach (var edge in edges)
            {
                int x = edge[0], y = edge[1];
                Union(x, y);
                if (!usefulEdges.ContainsKey(x))
                    usefulEdges[x] = 0;
                usefulEdges[x]++;
            }
            var roots = new int[n][];
            for (int i = 0; i < n; i++)
            {
                var parent = Find(parents[i]);
                if (roots[parent] == null) roots[parent] = new int[2];
                roots[parent][0]++;
            }
            foreach (var node in usefulEdges.Keys)
            {
                var parent = Find(node);
                roots[parent][1] += usefulEdges[node];
            }
            return roots.Where(x => x != null).Count(x => x[1] == x[0] * (x[0] - 1) / 2);
        }

        private static int Find(int x)
        {
            if (parents[x] != x)
                parents[x] = Find(parents[x]);
            return parents[x];
        }

        private static void Union(int x, int y)
        {
            int rootX = Find(x), rootY = Find(y);
            if (rootX == rootY) return;
            if (rank[rootX] < rank[rootY])
                parents[rootX] = rootY;
            else
            {
                parents[rootY] = rootX;
                if (rank[rootX] == rank[rootY])
                    rank[rootX]++;
            }
        }
    }
}
