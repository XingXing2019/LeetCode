using System;
using System.Collections.Generic;

namespace AllPathsFromSourceLeadToDestination
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4, source = 0, destination = 3;
            int[][] edges = new int[][]
            {
                new int[]{0, 1}, 
                new int[]{0, 3}, 
                new int[]{1, 2}, 
                new int[]{2, 1}, 
            };
            Console.WriteLine(LeadsToDestination(n, edges, source, destination));
        }
        static bool LeadsToDestination(int n, int[][] edges, int source, int destination)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new List<int>();
            foreach (var edge in edges)
                graph[edge[0]].Add(edge[1]);
            var nodeOnPath = new HashSet<int>[n];
            for (int i = 0; i < nodeOnPath.Length; i++)
                nodeOnPath[i] = new HashSet<int>();
            var queue = new Queue<int>();
            var visit = new bool[n];
            queue.Enqueue(source);
            nodeOnPath[source].Add(source);
            visit[source] = true;
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (cur != destination && graph[cur].Count == 0 || (cur == destination && graph[cur].Count != 0))
                    return false;
                foreach (var next in graph[cur])
                {
                    if (nodeOnPath[cur].Contains(next) || cur == next)
                        return false;
                    if (!visit[next])
                    {
                        queue.Enqueue(next);
                        visit[next] = true;
                    }
                    nodeOnPath[next].Add(cur);
                }
            }
            return true;
        }
    }
}
