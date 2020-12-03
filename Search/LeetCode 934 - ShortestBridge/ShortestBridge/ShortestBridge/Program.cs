using System;
using System.Collections.Generic;

namespace ShortestBridge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] A = new int[][]
            {
                new[] {0, 1, 0},
                new[] {0, 0, 0},
                new[] {0, 0, 1},
            };
            Console.WriteLine(ShortestBridge(A));
        }
        static int ShortestBridge(int[][] A)
        {
            var island = new HashSet<string>();
            var water = new Queue<int[]>();
            var visit = new HashSet<string>();
            for (int x = 0; x < A.Length; x++)
            {
                for (int y = 0; y < A[0].Length; y++)
                {
                    if (A[x][y] != 1) continue;
                    BFS(x, y, A, island, water, visit);
                    break;
                }
                if(island.Count != 0) break;
            }
            var min = int.MaxValue;
            var level = 0;
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            while (water.Count != 0)
            {
                var count = water.Count;
                level++;
                for (int i = 0; i < count; i++)
                {
                    var cur = water.Dequeue();
                    for (int j = 0; j < 4; j++)
                    {
                        int newX = dx[j] + cur[0];
                        int newY = dy[j] + cur[1];
                        if (newX < 0 || newX >= A.Length || newY < 0 || newY >= A[0].Length) continue;
                        if (A[newX][newY] == 1 && !island.Contains($"{newX}:{newY}"))
                            min = Math.Min(min, level);
                        if (A[newX][newY] == 0 && visit.Add($"{newX}:{newY}"))
                            water.Enqueue(new[] {newX, newY});
                    }
                }
            }
            return min;
        }

        static void BFS(int x, int y, int[][] A, HashSet<string> island, Queue<int[]> water, HashSet<string> visit)
        {
            island.Add($"{x}:{y}");
            var queue = new Queue<int[]>();
            queue.Enqueue(new[] {x, y});
            int[] dx = {-1, 1, 0, 0};
            int[] dy = {0, 0, -1, 1};
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int newX = dx[i] + cur[0];
                    int newY = dy[i] + cur[1];
                    if (newX < 0 || newX >= A.Length || newY < 0 || newY >= A[0].Length) continue;
                    if (A[newX][newY] == 0 && visit.Add($"{newX}:{newY}"))
                        water.Enqueue(new[] {newX, newY});
                    if (A[newX][newY] == 1 && island.Add($"{newX}:{newY}"))
                        queue.Enqueue(new[] {newX, newY});
                }
            }
        }
    }
}
