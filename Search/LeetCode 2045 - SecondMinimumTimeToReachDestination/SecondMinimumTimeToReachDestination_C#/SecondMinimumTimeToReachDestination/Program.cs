using System;
using System.Collections.Generic;

namespace SecondMinimumTimeToReachDestination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 2, time = 3, change = 2;
            int[][] edges =
            {
                new[] { 1, 2 },
            };
            Console.WriteLine(SecondMinimum(n, edges, time, change));
        }

        public static int SecondMinimum(int n, int[][] edges, int time, int change)
        {
            var graph = new List<int>[n + 1];
            var record = new int[n + 1][];
            for (int i = 0; i < n + 1; i++)
            {
                graph[i] = new List<int>();
                record[i] = new int[2];
                Array.Fill(record[i], int.MaxValue);
            }
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            var queue = new Queue<int[]>();
            queue.Enqueue(new[] { 1, 0 });
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                foreach (var next in graph[cur[0]])
                {
                    var timestamp = cur[1] / change % 2 == 0 ? cur[1] + time : cur[1] + time + change - cur[1] % change;
                    if (record[next][0] == int.MaxValue)
                    {
                        record[next][0] = timestamp;
                        queue.Enqueue(new[] { next, timestamp });
                    }
                    else if (timestamp > record[next][0] && record[next][1] == int.MaxValue)
                    {
                        record[next][1] = timestamp;
                        queue.Enqueue(new[] { next, timestamp });
                    }
                }
            }
            return record[^1][1];
        }
    }
}
