using System;
using System.Collections.Generic;

namespace ShortestPathInBinaryMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int ShortestPathBinaryMatrix(int[][] grid)
        {
            if (grid[0][0] == 1) return -1;
            int[] dx = {-1, 1, 0, 0, -1, 1, -1, 1};
            int[] dy = {0, 0, -1, 1, -1, -1, 1, 1};
            var queue = new Queue<int[]>();
            var visited = new HashSet<string>();
            queue.Enqueue(new[] {0, 0});
            visited.Add("0:0");
            var res = 0;
            while (queue.Count != 0)
            {
                var count = queue.Count;
                res++;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (cur[0] == grid.Length - 1 && cur[1] == grid[0].Length - 1)
                        return res;
                    for (int j = 0; j < 8; j++)
                    {
                        int newX = cur[0] + dx[j];
                        int newY = cur[1] + dy[j];
                        if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length)
                            continue;
                        if (grid[newX][newY] == 0 && visited.Add($"{newX}:{newY}"))
                            queue.Enqueue(new[] {newX, newY});
                    }
                }
            }
            return -1;
        }
    }
}
