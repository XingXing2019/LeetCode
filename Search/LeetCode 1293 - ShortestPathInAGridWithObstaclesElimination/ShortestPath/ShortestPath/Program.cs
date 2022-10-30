using System;
using System.Collections.Generic;

namespace ShortestPath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[][]
            {
                new[] { 0, 1, 0, 0, 0, 0, 1 },
                new[] { 0, 0, 0, 1, 0, 1, 0 },
            };
            var k = 1;
            Console.WriteLine(ShortestPath(grid, k));
        }

        public static int ShortestPath(int[][] grid, int k)
        {
            int m = grid.Length, n = grid[0].Length;
            var obstacles = new int[m][];
            for (int i = 0; i < m; i++)
            {
                obstacles[i] = new int[n];
                Array.Fill(obstacles[i], int.MaxValue);
            }
            obstacles[0][0] = 0;
            var queue = new Queue<int[]>();
            queue.Enqueue(new[] { 0, 0, 0 });
            var step = 0;
            int[] dir = { 1, 0, -1, 0, 1 };
            while (queue.Count != 0)
            {
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    int x = cur[0], y = cur[1];
                    if (x == m - 1 && y == n - 1) return step;
                    for (int j = 0; j < 4; j++)
                    {
                        int newX = x + dir[j], newY = y + dir[j + 1];
                        if (newX < 0 || newX >= m || newY < 0 || newY >= n)
                            continue;
                        var obstacle = cur[2] + grid[newX][newY];
                        if (obstacle >= obstacles[newX][newY] || obstacle > k)
                            continue;
                        obstacles[newX][newY] = obstacle;
                        queue.Enqueue(new[] { newX, newY, obstacle });
                    }
                }
                step++;
            }
            return -1;
        }
    }
}
