using System;
using System.Collections.Generic;

namespace SumOfRemotenessOfAllCells
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long SumRemoteness_BFS(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            long res = 0, sum = 0;
            var visited = new bool[grid.Length][];
            for (int x = 0; x < m; x++)
            {
                visited[x] = new bool[grid[x].Length];
                for (int y = 0; y < n; y++)
                {
                    if (grid[x][y] == -1)
                        visited[x][y] = true;
                    else
                        sum += grid[x][y];
                }
            }
            var groups = new List<long[]>();
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (visited[x][y]) continue;
                    groups.Add(BFS(grid, x, y, visited));
                }
            }
            foreach (var group in groups)
                res += group[0] * (sum - group[1]);
            return res;
        }

        public long[] BFS(int[][] grid, int x, int y, bool[][] visited)
        {
            var res = new long[2];
            var queue = new Queue<int[]>();
            queue.Enqueue(new []{x, y});
            visited[x][y] = true;
            int[] dir = { 1, 0, -1, 0, 1 };
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                res[0]++;
                res[1] += grid[cur[0]][cur[1]];
                for (int i = 0; i < 4; i++)
                {
                    int newX = cur[0] + dir[i], newY = cur[1] + dir[i + 1];
                    if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length || visited[newX][newY])
                        continue;
                    visited[newX][newY] = true;
                    queue.Enqueue(new[] { newX, newY });
                }
            }
            return res;
        }

        public long SumRemoteness_DFS(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            long res = 0, sum = 0;
            var visited = new bool[grid.Length][];
            for (int x = 0; x < m; x++)
            {
                visited[x] = new bool[grid[x].Length];
                for (int y = 0; y < n; y++)
                {
                    if (grid[x][y] == -1) continue;
                    sum += grid[x][y];
                }
            }
            var groups = new List<long[]>();
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (visited[x][y]) continue;
                    var group = new long[2];
                    DFS(grid, x, y, visited, group);
                    groups.Add(group);
                }
            }
            foreach (var group in groups)
                res += group[0] * (sum - group[1]);
            return res;
        }

        public void DFS(int[][] grid, int x, int y, bool[][] visited, long[] group)
        {
            if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length || visited[x][y] || grid[x][y] == -1)
                return;
            group[0]++;
            group[1] += grid[x][y];
            visited[x][y] = true;
            DFS(grid, x + 1, y, visited, group);
            DFS(grid, x - 1, y, visited, group);
            DFS(grid, x, y + 1, visited, group);
            DFS(grid, x, y - 1, visited, group);
        }
    }
}
