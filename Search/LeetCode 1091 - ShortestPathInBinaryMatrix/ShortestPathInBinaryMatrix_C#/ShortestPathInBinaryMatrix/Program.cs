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

        public int ShortestPathBinaryMatrix_DP(int[][] grid)
        {
            if (grid[0][0] == 1 || grid[^1][^1] == 1) return -1;
            int n = grid.Length;
            var dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n];
                Array.Fill(dp[i], int.MaxValue);
            }
            var queue = new Queue<int[]>();
            queue.Enqueue(new int[] { 0, 0, 1 });
            dp[0][0] = 1;
            int[] dx = { -1, 1, 0, 0, -1, 1, -1, 1 };
            int[] dy = { 0, 0, -1, 1, -1, -1, 1, 1 };
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (cur[0] == n - 1 && cur[1] == n - 1)
                    return cur[2];
                for (int i = 0; i < 8; i++)
                {
                    int newX = cur[0] + dx[i], newY = cur[1] + dy[i];
                    if (newX < 0 || newX >= n || newY < 0 || newY >= n || grid[newX][newY] == 1)
                        continue;
                    if (dp[newX][newY] <= cur[2] + 1)
                        continue;
                    dp[newX][newY] = cur[2] + 1;
                    queue.Enqueue(new int[] { newX, newY, cur[2] + 1 });
                }
            }
            return -1;
        }
    }
}
