using System;
using System.Collections.Generic;

namespace EscapeTheSpreadingFire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new[]
            {
                new[] { 0, 2, 0, 0, 1 },
                new[] { 0, 2, 0, 2, 2 },
                new[] { 0, 2, 0, 0, 0 },
                new[] { 0, 0, 2, 2, 0 },
                new[] { 0, 0, 0, 0, 0 },
            };
            Console.WriteLine(MaximumMinutes(grid));
        }

        public static int MaximumMinutes(int[][] grid)
        {
            var time = CalcTime(grid);
            int li = 0, hi = 1_000_000_000;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (CanReach(time, grid, mid)) li = mid + 1;
                else hi = mid - 1;
            }
            return hi;
        }

        public static bool CanReach(int[][] time, int[][] grid, int start)
        {
            int m = time.Length, n = time[0].Length;
            var queue = new Queue<int[]>();
            var visited = new bool[m][];
            for (int i = 0; i < m; i++)
                visited[i] = new bool[n];
            queue.Enqueue(new[] { 0, 0, start });
            visited[0][0] = true;
            int[] dir = { 1, 0, -1, 0, 1 };
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (cur[0] == m - 1 && cur[1] == n - 1)
                    return true;
                for (int i = 0; i < 4; i++)
                {
                    int newX = cur[0] + dir[i], newY = cur[1] + dir[i + 1];
                    if (newX < 0 || newX >= m || newY < 0 || newY >= n)
                        continue;
                    if (visited[newX][newY] || time[newX][newY] <= cur[2] + 1 || grid[newX][newY] == 2)
                        continue;
                    visited[newX][newY] = true;
                    queue.Enqueue(new[] { newX, newY, cur[2] + 1 });
                }
            }
            return false;
        }

        public static int[][] CalcTime(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            var time = new int[m][];
            var visited = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                time[i] = new int[n];
                Array.Fill(time[i], int.MaxValue - 1);
                visited[i] = new bool[n];
            }
            var queue = new Queue<int[]>();
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (grid[x][y] != 1) continue;
                    if (grid[x][y] == 2 || grid[x][y] == 1) time[x][y] = 0;
                    visited[x][y] = true;
                    queue.Enqueue(new[] { x, y, 0 });
                }
            }
            int[] dir = { 1, 0, -1, 0, 1 };
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int newX = cur[0] + dir[i], newY = cur[1] + dir[i + 1];
                    if (newX < 0 || newX >= m || newY < 0 || newY >= n || visited[newX][newY] || grid[newX][newY] == 2)
                        continue;
                    visited[newX][newY] = true;
                    time[newX][newY] = cur[2] + 1;
                    queue.Enqueue(new[] { newX, newY, cur[2] + 1 });
                }
            }
            time[m - 1][n - 1]++;
            return time;
        }
    }
}
