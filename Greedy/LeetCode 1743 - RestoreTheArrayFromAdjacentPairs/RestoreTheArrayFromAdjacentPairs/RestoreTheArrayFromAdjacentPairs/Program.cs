using System;
using System.Collections.Generic;
using System.Linq;

namespace RestoreTheArrayFromAdjacentPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] adjacentPairs = new[]
            {
                new[] {2, 1},
                new[] {3, 4},
                new[] {3, 2},
            };
            Console.WriteLine(RestoreArray(adjacentPairs));
        }
        public static int[] RestoreArray(int[][] adjacentPairs)
        {
            var graph = new Dictionary<int, List<int>>();
            foreach (var pair in adjacentPairs)
            {
                if (!graph.ContainsKey(pair[0]))
                    graph[pair[0]] = new List<int>();
                graph[pair[0]].Add(pair[1]);
                if (!graph.ContainsKey(pair[1]))
                    graph[pair[1]] = new List<int>();
                graph[pair[1]].Add(pair[0]);
            }
            int head = graph.First(x => x.Value.Count == 1).Key;
            var queue = new Queue<int>();
            queue.Enqueue(head);
            var set = new HashSet<int>{head};
            var res = new List<int>{head};
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                foreach (var next in graph[cur])
                {
                    if (set.Add(next))
                    {
                        queue.Enqueue(next);
                        res.Add(next);
                    }
                }
            }
            return res.ToArray();
        }
    }
}
