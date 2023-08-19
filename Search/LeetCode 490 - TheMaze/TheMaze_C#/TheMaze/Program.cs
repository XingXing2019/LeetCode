using System;
using System.Collections.Generic;

namespace TheMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] maze = new int[][]
            {
                new int[]{0, 0, 1, 0, 0}, 
                new int[]{0, 0, 0, 0, 0}, 
                new int[]{0, 0, 0, 1, 0}, 
                new int[]{1, 1, 0, 1, 1}, 
                new int[]{0, 0, 0, 0, 0}, 
            };
            int[] start = {0, 4};
            int[] destination = {4, 4};
            Console.WriteLine(HasPath(maze, start, destination));
        }
        static bool HasPath(int[][] maze, int[] start, int[] destination)
        {
            var queue = new Queue<int[]>();
            queue.Enqueue(start);
            int[] dx = {-1, 1, 0, 0};
            int[] dy = {0, 0, -1, 1};
            var visit = new HashSet<string>();
            visit.Add($"{start[0]}:{start[1]}");
            while (queue.Count != 0) {
                var cur = queue.Dequeue();
                if (cur[0] == destination[0] && cur[1] == destination[1]) return true;
                for (int i = 0; i < 4; i++)
                {
                    int stopX = 0, stopY = 0;
                    for (int j = 0; j < 100; j++)
                    {
                        int newX = dx[i] * j + cur[0];
                        int newY = dy[i] * j + cur[1];
                        if (newX < 0 || newX >= maze.Length || newY < 0 || newY >= maze[0].Length || maze[newX][newY] == 1) break;
                        stopX = newX;
                        stopY = newY;
                    }
                    if (visit.Add($"{stopX}:{stopY}"))
                        queue.Enqueue(new[] { stopX, stopY });
                }
            }
            return false;
        }
    }
}
