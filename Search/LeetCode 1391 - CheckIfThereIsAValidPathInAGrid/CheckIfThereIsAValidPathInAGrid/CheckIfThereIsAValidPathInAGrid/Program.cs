using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckIfThereIsAValidPathInAGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid =
            {
                new[] {1, 1, 2},
            };
            Console.WriteLine(HasValidPath_BFS(grid));
        }
        static bool HasValidPath_BFS(int[][] grid)
        {
            if (grid.Length == 0 || grid[0].Length == 0) return false;
            if (grid.Length == 1 && grid[0].Length == 1) return true;
            int[][][] directions =
            {
                new[] {new[] {0, -1, 11, 14, 16}, new[] {0, 1, 11, 13, 15}},
                new[] {new[] {-1, 0, 12, 13, 14}, new[] {1, 0, 12, 15, 16}},
                new[] {new[] {0, -1, 11, 14, 16}, new[] {1, 0, 12, 15, 16}},
                new[] {new[] {0, 1, 11, 13, 15}, new[] {1, 0, 12, 15, 16}},
                new[] {new[] {0, -1, 11, 14, 16}, new[] {-1, 0, 12, 13, 14}},
                new[] {new[] {-1, 0, 12, 13, 14}, new[] {0, 1, 11, 13, 15}}
            };
            int[][] mark = new int[grid.Length][];
            for (int i = 0; i < mark.Length; i++)
                mark[i] = new int[grid[0].Length];
            var queue = new Queue<int[]>();
            queue.Enqueue(new []{0, 0});
            mark[0][0]++;
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                var street = grid[cur[0]][cur[1]];
                for (int i = 0; i < 2; i++)
                {
                    var newX = cur[0] + directions[street - 1][i][0];
                    var newY = cur[1] + directions[street - 1][i][1];
                    if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length) continue;
                    if (!directions[street - 1][i].Contains(grid[newX][newY] + 10))
                        return false;
                    if (newX == grid.Length - 1 && newY == grid[0].Length - 1) return true;
                    if (mark[newX][newY] == 0)
                    {
                        mark[newX][newY]++;
                        queue.Enqueue(new []{newX, newY});
                    }
                    else
                    {
                        mark[newX][newY]++;
                        if(mark[newX][newY] == 3 && newX != 0 && newY != 0)
                            return false;
                    }
                }
            }
            return false;
        }
    }
}
