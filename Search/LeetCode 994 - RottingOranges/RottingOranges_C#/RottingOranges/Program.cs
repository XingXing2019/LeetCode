using System;
using System.Collections.Generic;
using System.Linq;

namespace RottingOranges
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[][]
            {
                new int[]{2, 1, 1}, 
                new int[]{1, 1, 0}, 
                new int[]{0, 1, 1}, 
            };
            Console.WriteLine(OrangesRotting(grid));
        }
        static int OrangesRotting(int[][] grid)
        {
            var queue = new Queue<int[]>();
            int minute = -1;
            for (int x = 0; x < grid.Length; x++)
            {
                for (int y = 0; y < grid[0].Length; y++)
                {
                    if (grid[x][y] == 2)
                    {
                        queue.Enqueue(new []{x, y});
                        grid[x][y] = -1;
                    }
                }
            }
            if (queue.Count == 0)
                return grid.Any(x => x.Any(y => y == 1)) ? -1 : 0;
            int[] dx = {-1, 1, 0, 0};
            int[] dy = {0, 0, -1, 1};
            while (queue.Count != 0)
            {
                int count = queue.Count;
                minute++;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    for (int j = 0; j < 4; j++)
                    {
                        int newX = dx[j] + cur[0];
                        int newY = dy[j] + cur[1];
                        if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length) continue;
                        if (grid[newX][newY] == 1)
                        {
                            queue.Enqueue(new[] { newX, newY });
                            grid[newX][newY] = -1;
                        }
                    }
                }
            }
            return grid.Any(x => x.Any(y => y == 1)) ? -1 : minute;
        }
    }
}
