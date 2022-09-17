using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DeleteTreeNodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nodes = 7;
            int[] parent = { -1, 0, 0, 1, 2, 2, 2 };
            int[] value = { 1, -2, 4, 0, -2, -1, -1 };
            Console.WriteLine(DeleteTreeNodes(nodes, parent, value));
        }

        public static int DeleteTreeNodes(int nodes, int[] parent, int[] value)
        {
            var graph = new List<int>[nodes];
            for (int i = 0; i < nodes; i++)
                graph[i] = new List<int>();
            for (int i = 0; i < parent.Length; i++)
            {
                if (parent[i] == -1) continue;
                graph[parent[i]].Add(i);
            }
            var deleted = new HashSet<int>();
            DFS(graph, value, 0, deleted);
            var visited = new HashSet<int>();
            foreach (var node in deleted)
                Count(graph, node, visited);
            return nodes - visited.Count;
        }

        public static int DFS(List<int>[] graph, int[] value, int cur, HashSet<int> deleted)
        {
            var sum = value[cur] + graph[cur].Sum(x => DFS(graph, value, x, deleted));
            if (sum == 0) 
                deleted.Add(cur);
            return sum;
        }

        public static void Count(List<int>[] graph, int cur, HashSet<int> visited)
        {
            if (!visited.Add(cur))
                return;
            graph[cur].ForEach(x => Count(graph, x, visited));
        }
    }
}
