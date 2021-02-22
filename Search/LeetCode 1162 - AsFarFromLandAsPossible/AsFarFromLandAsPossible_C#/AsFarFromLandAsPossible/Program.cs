using System;
using System.Collections.Generic;

namespace AsFarFromLandAsPossible
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new int[][]
            {
                new[] {1, 0, 0},
                new[] {0, 0, 0},
                new[] {0, 0, 0},
            };
            Console.WriteLine(MaxDistance(grid));
        }
        static int MaxDistance(int[][] grid)
        {
            var queue = new Queue<int[]>();
            var visit = new bool[grid.Length][];
            for (int i = 0; i < visit.Length; i++)
                visit[i] = new bool[grid[0].Length];
            for (int x = 0; x < grid.Length; x++)
            {
                for (int y = 0; y < grid[0].Length; y++)
                {
                    if (grid[x][y] == 1)
                    {
                        queue.Enqueue(new []{x, y});
                        visit[x][y] = true;
                    }
                }
            }
            int[] dx = {-1, 1, 0, 0}, dy = {0, 0, -1, 1};
            var level = -1;
            while (queue.Count != 0)
            {
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    for (int j = 0; j < 4; j++)
                    {
                        int newX = dx[j] + cur[0];
                        int newY = dy[j] + cur[1];
                        if (newX >= 0 && newX < grid.Length && newY >= 0 && newY < grid.Length && !visit[newX][newY])
                        {
                            visit[newX][newY] = true;
                            queue.Enqueue(new []{newX, newY});
                        }
                    }
                }
                level++;
            }
            return level != 0 ? level : -1;
        }
    }
}
