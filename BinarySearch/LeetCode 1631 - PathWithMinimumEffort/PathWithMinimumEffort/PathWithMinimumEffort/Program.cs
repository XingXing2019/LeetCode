using System;
using System.Collections.Generic;

namespace PathWithMinimumEffort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] heights = new int[][]
            {
                new[] {8, 6, 8, 1, 4, 1},
                new[] {10, 3, 1, 8, 9, 10},
                new[] {1, 5, 6, 9, 8, 5},
                new[] {10, 4, 6, 7, 3, 3},
                new[] {6, 6, 9, 1, 3, 3},
                new[] {3, 1, 10, 3, 4, 1},
                new[] {6, 1, 6, 10, 7, 10},
            };
            var a = BFS(heights, 3);
            Console.WriteLine(MinimumEffortPath(heights));
        }
        static int MinimumEffortPath(int[][] heights)
        {
            int li = 0, hi = 1000000;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (BFS(heights, mid))
                    hi = mid;
                else
                    li = mid + 1;
            }
            return li;
        }

        static bool BFS(int[][] heights, int threshold)
        {
            var visited = new int[heights.Length][];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = new int[heights[0].Length];
            var queue = new Queue<int[]>();
            queue.Enqueue(new[] {0, 0});
            visited[0][0] = 1;
            int[] dx = {-1, 1, 0, 0};
            int[] dy = {0, 0, -1, 1};
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (cur[0] == heights.Length - 1 && cur[1] == heights[0].Length - 1)
                    return true;
                for (int i = 0; i < 4; i++)
                {
                    int newX = cur[0] + dx[i];
                    int newY = cur[1] + dy[i];
                    if(newX < 0 || newX >= heights.Length || newY < 0 || newY >= heights[0].Length) continue;
                    if (Math.Abs(heights[cur[0]][cur[1]] - heights[newX][newY]) <= threshold && visited[newX][newY] == 0)
                    {
                        queue.Enqueue(new []{newX, newY});
                        visited[newX][newY] = 1;
                    }
                }
            }
            return false;
        }
    }
}
