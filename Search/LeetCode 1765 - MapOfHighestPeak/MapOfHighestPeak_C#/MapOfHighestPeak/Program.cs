using System;
using System.Collections.Generic;

namespace MapOfHighestPeak
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int[][] HighestPeak(int[][] isWater)
        {
            var visited = new bool[isWater.Length][];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = new bool[isWater[0].Length];
            var queue = new Queue<int[]>();
            for (int x = 0; x < isWater.Length; x++)
            {
                for (int y = 0; y < isWater[0].Length; y++)
                {
                    if (isWater[x][y] == 1)
                    {
                        queue.Enqueue(new []{x, y, 1});
                        isWater[x][y] = 0;
                        visited[x][y] = true;
                    }
                }
            }
            int[] dir = {0, -1, 0, 1, 0};
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int newX = dir[i] + cur[0];
                    int newY = dir[i + 1] + cur[1];
                    if(newX < 0 || newX >= isWater.Length || newY < 0 || newY >= isWater[0].Length) continue;
                    if (!visited[newX][newY])
                    {
                        isWater[newX][newY] = cur[2];
                        queue.Enqueue(new []{newX, newY, cur[2] + 1});
                        visited[newX][newY] = true;
                    }
                }
            }
            return isWater;
        }
    }
}
