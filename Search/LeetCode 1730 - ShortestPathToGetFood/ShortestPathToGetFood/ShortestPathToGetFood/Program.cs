using System;
using System.Collections.Generic;

namespace ShortestPathToGetFood
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int GetFood(char[][] grid)
        {
            var start = new int[2];
            for (int x = 0; x < grid.Length; x++)
            {
                for (int y = 0; y < grid[0].Length; y++)
                {
                    if(grid[x][y] != '*') continue;
                    start[0] = x;
                    start[1] = y;
                    break;
                }
            }
            var queue = new Queue<int[]>();
            queue.Enqueue(new []{start[0], start[1], 0});
            var visited = new HashSet<string>() {$"{start[0]}:{start[1]}"};
            int[] dx = {-1, 1, 0, 0};
            int[] dy = {0, 0, -1, 1};
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (grid[cur[0]][cur[1]] == '#') return cur[2];
                for (int i = 0; i < 4; i++)
                {
                    int newX = cur[0] + dx[i];
                    int newY = cur[1] + dy[i];
                    if(newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length)
                        continue;
                    if(visited.Add($"{newX}:{newY}") && grid[newX][newY] != 'X')
                        queue.Enqueue(new []{newX, newY, cur[2] + 1});
                }
            }
            return -1;
        }
    }
}
