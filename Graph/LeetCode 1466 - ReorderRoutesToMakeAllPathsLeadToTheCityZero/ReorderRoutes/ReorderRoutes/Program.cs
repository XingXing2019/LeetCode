using System;
using System.Collections.Generic;

namespace ReorderRoutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            var connections = new int[][]
            {
                new[] {1, 0},
                new[] {1, 2},
                new[] {3, 2},
                new[] {3, 4},
            };
            Console.WriteLine(MinReorder(n, connections));
        }
        static int MinReorder(int n, int[][] connections)
        {
            var graph = new List<int>[n];
            var visit = new bool[n];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new List<int>();
            var queue = new Queue<int>();
            var count = 0;
            foreach (var connection in connections)
                graph[connection[0]].Add(connection[1]);
            for (int i = 0; i < n; i++)
            {
                if (visit[i]) continue;
                visit[i] = true;
                queue.Enqueue(i);
                while (queue.Count != 0)
                {
                    var cur = queue.Dequeue();
                    foreach (var next in graph[cur])
                    {
                        if (next != 0 && !visit[next])
                            count++;
                        if (!visit[next])
                        {
                            queue.Enqueue(next);
                            visit[next] = true;
                        }
                    }
                }
            }
            return count;
        }
    }
}
