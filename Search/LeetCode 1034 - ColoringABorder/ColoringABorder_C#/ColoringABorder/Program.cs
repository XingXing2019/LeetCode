using System;
using System.Collections.Generic;

namespace ColoringABorder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[][]
            {
                new []{1,2,1,2,1,2},
                new []{2,2,2,2,1,2},
                new []{1,2,2,2,1,2}
            };
            int r0 = 1, c0 = 3, color = 2;
            Console.WriteLine(ColorBorder_BFS(grid, r0, c0, color));
        }
        static int[][] ColorBorder_BFS(int[][] grid, int r0, int c0, int color)
        {
            var queue = new Queue<int[]>();
            var visit = new HashSet<string>();
            visit.Add($"{r0}:{c0}");
            queue.Enqueue(new []{r0, c0});
            int originalColor = grid[r0][c0];
            int[] dx = {-1, 1, 0, 0};
            int[] dy = {0, 0, -1, 1};
            var positions = new List<int[]>();
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                int count = 0;
                for (int i = 0; i < 4; i++)
                {
                    int newX = dx[i] + cur[0];
                    int newY = dy[i] + cur[1];
                    if(newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length) continue;
                    if (grid[newX][newY] == originalColor)
                    {
                        count++;
                        if (visit.Add($"{newX}:{newY}"))
                            queue.Enqueue(new[] {newX, newY});
                    }
                }
                if (count < 4)
                    positions.Add(new []{cur[0], cur[1]});
            }
            foreach (var position in positions)
                grid[position[0]][position[1]] = color;
            return grid;
        }
    }
}
