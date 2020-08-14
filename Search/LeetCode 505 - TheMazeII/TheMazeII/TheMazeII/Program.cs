using System;
using System.Collections.Generic;

namespace TheMazeII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] maze = new int[][]
            {
                new []{0, 0, 1, 0, 0},
                new []{0, 0, 0, 0, 0},
                new []{0, 0, 0, 1, 0},
                new []{1, 1, 0, 1, 1},
                new []{0, 0, 0, 0, 0},
            };
            int[] start = {0, 4}, destination = {4, 4};
            Console.WriteLine(ShortestDistance(maze, start, destination));
        }
        static int ShortestDistance(int[][] maze, int[] start, int[] destination)
        {
            var queue = new Queue<int[]>();
            queue.Enqueue(start);
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            var distance = new int[maze.Length][];
            for (int i = 0; i < maze.Length; i++)
            {
                distance[i] = new int[maze[0].Length];
                for (int j = 0; j < distance[i].Length; j++)
                    distance[i][j] = int.MaxValue;
            }
            distance[start[0]][start[1]] = 0;
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int x = dx[i] + cur[0];
                    int y = dy[i] + cur[1];
                    int count = 0;
                    while (x >= 0 && y >= 0 && x < maze.Length && y < maze[0].Length && maze[x][y] == 0)
                    {
                        x += dx[i];
                        y += dy[i];
                        count++;
                    }
                    if (distance[cur[0]][cur[1]] + count < distance[x - dx[i]][y - dy[i]])
                    {
                        distance[x - dx[i]][y - dy[i]] = distance[cur[0]][cur[1]] + count;
                        queue.Enqueue(new[] {x - dx[i], y - dy[i]});
                    }
                }
            }
            return distance[destination[0]][destination[1]] == int.MaxValue ? -1 : distance[destination[0]][destination[1]];
        }
    }
}
