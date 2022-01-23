using System;
using System.Collections.Generic;
using System.Linq;

namespace KHighestRankedItemsWithinAPriceRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[3][]
            {
                new[] { 1, 2, 0, 1 },
                new[] { 1, 3, 0, 1 },
                new[] { 0, 2, 5, 1 }
            };
            int[] pricing = { 2, 5 }, start = { 0, 0 };
            int k = 3;
            Console.WriteLine(HighestRankedKItems(grid, pricing, start, k));
        }
        public static IList<IList<int>> HighestRankedKItems(int[][] grid, int[] pricing, int[] start, int k)
        {
            var candidates = new List<int[]>();
            var visited = new bool[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
                visited[i] = new bool[grid[0].Length];
            var queue = new Queue<int[]>();
            visited[start[0]][start[1]] = true;
            queue.Enqueue(new[] { start[0], start[1], 0 });
            int[] dir = { 1, 0, -1, 0, 1 };
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (pricing[0] <= grid[cur[0]][cur[1]] && grid[cur[0]][cur[1]] <= pricing[1])
                    candidates.Add(cur);
                for (int i = 0; i < 4; i++)
                {
                    var newX = cur[0] + dir[i];
                    var newY = cur[1] + dir[i + 1];
                    if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length || grid[newX][newY] == 0 || visited[newX][newY])
                        continue;
                    visited[newX][newY] = true;
                    queue.Enqueue(new[] { newX, newY, cur[2] + 1 });
                }
            }
            candidates = candidates.OrderBy(x => x[2]).ThenBy(x => grid[x[0]][x[1]]).ThenBy(x => x[0]).ThenBy(x => x[1]).ToList();
            var res = new List<IList<int>>();
            for (int i = 0; i < Math.Min(k, candidates.Count); i++)
                res.Add(new List<int> { candidates[i][0], candidates[i][1] });
            return res;
        }
    }
}
