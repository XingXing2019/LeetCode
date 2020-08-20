using System;
using System.Collections.Generic;

namespace WallsAndGates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static void WallsAndGates(int[][] rooms)
        {
            var queue = new Queue<int[]>();
            int distance = 0;
            for (int x = 0; x < rooms.Length; x++)
            {
                for (int y = 0; y < rooms[0].Length; y++)
                {
                    if (rooms[x][y] == 0)
                        queue.Enqueue(new []{x, y});
                }
            }
            int[] dx = {-1, 1, 0, 0};
            int[] dy = {0, 0, -1, 1};
            while (queue.Count != 0)
            {
                distance++;
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    for (int j = 0; j < 4; j++)
                    {
                        int newX = dx[j] + cur[0];
                        int newY = dy[j] + cur[1];
                        if (newX < 0 || newX >= rooms.Length || newY < 0 || newY >= rooms[0].Length)
                            continue;
                        if (rooms[newX][newY] == int.MaxValue)
                        {
                            queue.Enqueue(new[] { newX, newY });
                            rooms[newX][newY] = Math.Min(rooms[newX][newY], distance);
                        }
                    }
                }
            }
        }
    }
}
