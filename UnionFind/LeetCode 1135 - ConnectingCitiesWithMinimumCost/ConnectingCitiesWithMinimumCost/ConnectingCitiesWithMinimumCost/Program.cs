using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectingCitiesWithMinimumCost
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 3;
            int[][] connections = new[]
            {
                new[] {1, 2, 5},
                new[] {1, 3, 6},
                new[] {2, 3, 1},
            };
            Console.WriteLine(MinimumCost_Kruskal(N, connections));
        }
        public static int MinimumCost_Kruskal(int N, int[][] connections)
        {
            connections = connections.OrderBy(x => x[2]).ToArray();
            int[] parents = new int[N + 1];
            for (int i = 0; i < parents.Length; i++)
                parents[i] = i;
            int[] rank = new int[N + 1];
            int res = 0;
            foreach (var connection in connections)
            {
                int rootX = Find(connection[0], parents);
                int rootY = Find(connection[1], parents);
                if (rootX == rootY) continue;
                Merge(rootX, rootY, parents, rank);
                res += connection[2];
                N--;
            }
            return N == 1 ? res : -1;
        }

        public static int Find(int x, int[] parents)
        {
            if (parents[x] != x)s
                parents[x] = Find(parents[x], parents);
            return parents[x];
        }

        public static void Merge(int rootX, int rootY, int[] parents, int[] rank)
        {
            if (rank[rootX] > rank[rootY]) parents[rootY] = rootX;
            else if (rank[rootX] < rank[rootY]) parents[rootX] = rootY;
            else
            {
                parents[rootY] = rootX;
                rank[rootX]++;
            }
        }
    }
}
