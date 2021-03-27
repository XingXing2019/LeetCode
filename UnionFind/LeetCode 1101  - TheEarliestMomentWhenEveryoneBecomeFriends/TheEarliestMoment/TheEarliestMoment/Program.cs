using System;
using System.Linq;

namespace TheEarliestMoment
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] logs =
            {
                new[] {1, 0, 1}, new[] {2, 3, 4}, new[] {3, 2, 3}, new[] {4, 1, 5}, new[] {5, 2, 4}, new[] {6, 1, 2},
                new[] {7, 0, 3}, new[] {8, 4, 5}
            };
            int N = 6;
            Console.WriteLine(EarliestAcq(logs, N));
        }
        static int EarliestAcq(int[][] logs, int N)
        {
            logs = logs.OrderBy(x => x[0]).ToArray();
            var parents = new int[N];
            for (int i = 0; i < parents.Length; i++)
                parents[i] = i;
            var rank = new int[N];
            foreach (var log in logs)
            {
                if (Merge(log[1], log[2], parents, rank))
                    N--;
                if (N == 1)
                    return log[0];
            }
            return -1;
        }

        static int Find(int[] parents, int x)
        {
            if (parents[x] != x)
                parents[x] = Find(parents, parents[x]);
            return parents[x];
        }

        static bool Merge(int x, int y, int[] parents, int[] rank)
        {
            int xRoot = Find(parents, x);
            int yRoot = Find(parents, y);
            if (xRoot == yRoot) return false;
            if (rank[xRoot] > rank[yRoot])
                parents[yRoot] = xRoot;
            else if (rank[xRoot] < rank[yRoot])
                parents[xRoot] = yRoot;
            else
            {
                parents[yRoot] = xRoot;
                rank[xRoot]++;
            }
            return true;
        }
    }
}
