using System;
using System.Collections.Generic;

namespace EscapeALargeMaze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool IsEscapePossible(int[][] blocked, int[] source, int[] target)
        {
            var set = new HashSet<string>();
            foreach (var block in blocked)
                set.Add($"{block[0]}:{block[1]}");
            return BFS(source, target, 1_000_000, set) && BFS(target, source, 1_000_000, set);
        }

        public bool BFS(int[] source, int[] target, int size, HashSet<string> blocked)
        {
            var queue = new Queue<int[]>();
            queue.Enqueue(source);
            var visited = new HashSet<string> {$"{source[0]}:{source[1]}"};
            int[] dir = { 1, 0, -1, 0, 1 };
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (cur[0] == target[0] && cur[1] == target[1])
                    return true;
                for (int i = 0; i < 4; i++)
                {
                    var newX = cur[0] + dir[i];
                    var newY = cur[1] + dir[i + 1];
                    if (newX < 0 || newX >= size || newY < 0 || newY >= size)
                        continue;
                    if (blocked.Contains($"{newX}:{newY}") || !visited.Add($"{newX}:{newY}"))
                        continue;
                    queue.Enqueue(new[] { newX, newY });
                    if (queue.Count > blocked.Count)
                        return true;
                }
            }
            return false;
        }
    }
}
