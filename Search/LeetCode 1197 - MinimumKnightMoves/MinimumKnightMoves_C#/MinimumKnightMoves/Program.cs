using System;
using System.Collections.Generic;

namespace MinimumKnightMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 5, y = 5;
            Console.WriteLine(MinKnightMoves_BFS(x, y));
        }
        static int MinKnightMoves_BFS(int x, int y)
        {
            var visit = new HashSet<string>();
            var queue = new Queue<KeyValuePair<int[], int>>();
            visit.Add("0:0");
            queue.Enqueue(new KeyValuePair<int[], int>(new[] { 0, 0 }, 0));
            int[] dx = { 1, 1, 2, 2, -1, -1, -2, -2 };
            int[] dy = { 2, -2, 1, -1, 2, -2, 1, -1 };
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                var step = cur.Value;
                if (cur.Key[0] == Math.Abs(x) && cur.Key[1] == Math.Abs(y)) return step;
                for (int i = 0; i < 8; i++)
                {
                    int newX = dx[i] + cur.Key[0];
                    int newY = dy[i] + cur.Key[1];
                    if (newX >= -300 && newX <= 300 && newY >= -300 && newY <= 300 && !visit.Contains($"{newX}:{newY}"))
                    {
                        visit.Add($"{newX}:{newY}");
                        queue.Enqueue(new KeyValuePair<int[], int>(new[] { newX, newY }, step + 1));
                    }
                }
            }
            return -1;
        }
    }
}
