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
            Console.WriteLine(LeadsToDestination_BFS(n, edges, source, destination));
        }
        static bool LeadsToDestination_BFS(int n, int[][] edges, int source, int destination)
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

        public bool LeadsToDestination_DFS(int n, int[][] edges, int source, int destination)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            foreach (var e in edges)
                graph[e[0]].Add(e[1]);
            if (graph[destination].Count != 0)
                return false;
            var visited = new HashSet<int> { source };
            return DFS(source, destination, graph, visited);
        }

        public bool DFS(int cur, int destination, List<int>[] graph, HashSet<int> visited)
        {
            if (graph[cur].Count == 0 && cur != destination)
                return false;
            foreach (var next in graph[cur])
            {
                if (visited.Contains(next))
                    return false;
                visited.Add(next);
                if (!DFS(next, destination, graph, visited))
                    return false;
                visited.Remove(next);
            }
            return true;
        }
    }
}
