using System;
using System.Collections.Generic;

namespace FindTheSafestPathInAGrid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IList<int>> grid = new List<IList<int>>
            {
                new List<int> { 0, 1, 1 },
                new List<int> { 0, 1, 1 },
                new List<int> { 0, 0, 0 },
            };
            Console.WriteLine(MaximumSafenessFactor(grid));
        }

        public static int MaximumSafenessFactor(IList<IList<int>> grid)
        {
            var n = grid.Count;
            var map = GetSafeness(grid);
            var dp = new int[n][];
            for (int i = 0; i < n; i++)
                dp[i] = new int[n];
            var res = 0;
            var queue = new Queue<int[]>();
            var safeness = map[0][0];
            dp[0][0] = safeness;
            queue.Enqueue(new[] {0, 0, safeness});
            int[] dir = { 1, 0, -1, 0, 1 };
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (cur[0] == n - 1 && cur[1] == n - 1)
                {
                    res = Math.Max(res, cur[2]);
                    continue;
                }
                for (int i = 0; i < 4; i++)
                {
                    int newX = cur[0] + dir[i], newY = cur[1] + dir[i + 1];
                    if (newX < 0 || newX >= n || newY < 0 || newY >= n) continue;
                    safeness = Math.Min(map[newX][newY], cur[2]);
                    if (safeness > dp[newX][newY])
                    {
                        dp[newX][newY] = safeness;
                        queue.Enqueue(new []{newX, newY, safeness});
                    }
                }
            }
            return res;
        }

        public static int[][] GetSafeness(IList<IList<int>> grid)
        {
            var n = grid.Count;
            var map = new int[n][];
            for (int i = 0; i < n; i++)
            {
                map[i] = new int[n];
                Array.Fill(map[i], int.MaxValue);
            }
            int[] dir = { 1, 0, -1, 0, 1 };
            var queue = new Queue<int[]>();
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (grid[x][y] == 0) continue;
                    queue.Enqueue(new[] { x, y, 0 });
                    map[x][y] = 0;
                }
            }
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int newX = cur[0] + dir[i], newY = cur[1] + dir[i + 1];
                    if (newX < 0 || newX >= n || newY < 0 || newY>= n) continue;
                    if (cur[2] + 1 < map[newX][newY])
                    {
                        map[newX][newY] = cur[2] + 1;
                        queue.Enqueue(new int[] { newX, newY, cur[2] + 1 });
                    }
                }
            }
            return map;
        }
    }
}
