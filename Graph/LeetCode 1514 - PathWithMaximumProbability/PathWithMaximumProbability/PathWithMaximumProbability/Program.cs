using System;
using System.Collections.Generic;

namespace PathWithMaximumProbability
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            var edges = new int[3][]
            {
                new[] {0, 1},
                new[] {1, 2},
                new[] {0, 2}
            };
            double[] succProb = {0.5, 0.5, 0.2};
            int start = 0, end = 2;
            Console.WriteLine(MaxProbability_BFS(n, edges, succProb, start, end));
        }

        static double MaxProbability_BFS(int n, int[][] edges, double[] succProb, int start, int end)
        {
            var graph = new List<Tuple<int, double>>[n];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new List<Tuple<int, double>>();
            for (int i = 0; i < edges.Length; i++)
            {
                graph[edges[i][0]].Add(new Tuple<int, double>(edges[i][1], succProb[i]));
                graph[edges[i][1]].Add(new Tuple<int, double>(edges[i][0], succProb[i]));
            }
            var probs = new double[n];
            probs[start] = 1;
            var queue = new Queue<int>();
            queue.Enqueue(start);
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                foreach (var next in graph[cur])
                {
                    if (probs[cur] * next.Item2 > probs[next.Item1])
                    {
                        probs[next.Item1] = probs[cur] * next.Item2;
                        queue.Enqueue(next.Item1);
                    }
                }
            }
            return probs[end];
        }
    }
}
