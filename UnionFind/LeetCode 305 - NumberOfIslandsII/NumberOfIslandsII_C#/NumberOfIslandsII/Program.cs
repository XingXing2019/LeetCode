using System;
using System.Collections.Generic;

namespace NumberOfIslandsII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m = 3, n = 3;
            int[][] positions = new[]
            {
                new[] { 0, 0 },
                new[] { 0, 1 },
                new[] { 1, 2 },
                new[] { 2, 1 },
            };
            Console.WriteLine(NumIslands2(m, n, positions));
        }

        private static int[] parents;
        private static int[] rank;
        public static IList<int> NumIslands2(int m, int n, int[][] positions)
        {
            parents = new int[m * n];
            rank = new int[m * n];
            for (int i = 0; i < parents.Length; i++)
                parents[i] = i;
            var count = 0;
            int[] dir = { 1, 0, -1, 0, 1 };
            var res = new List<int>();
            var map = new int[m][];
            for (int i = 0; i < m; i++)
                map[i] = new int[n];
            foreach (var position in positions)
            {
                int x = position[0], y = position[1];
                if (map[x][y] == 1)
                {
                    res.Add(count);
                    continue;
                }
                map[x][y] = 1;
                count++;
                for (int i = 0; i < 4; i++)
                {
                    int newX = x + dir[i], newY = y + dir[i + 1];
                    if (newX < 0 || newX >= m || newY < 0 || newY >= n || map[newX][newY] == 0) continue;
                    if (Union(x * n + y, newX * n + newY)) count--;
                }
                res.Add(count);
            }
            return res;
        }

        public static int Find(int x)
        {
            if (x != parents[x])
                parents[x] = Find(parents[x]);
            return parents[x];
        }

        public static bool Union(int x, int y)
        {
            int rootX = Find(x), rootY = Find(y);
            if (rootX == rootY) return false;
            if (rank[rootX] >= rank[rootY])
            {
                parents[rootY] = rootX;
                if (rank[rootX] == rank[rootY])
                    rank[rootX]++;
            }
            else
                parents[rootX] = rootY;
            return true;
        }
    }
}
