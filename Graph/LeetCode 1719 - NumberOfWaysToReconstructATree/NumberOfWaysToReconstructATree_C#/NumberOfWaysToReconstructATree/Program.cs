using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfWaysToReconstructATree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] pairs =
            {
                new[] { 1, 2 },
                new[] { 2, 3 },
            };
            Console.WriteLine(CheckWays(pairs));
        }

        public static int CheckWays(int[][] pairs)
        {
            var set = new HashSet<int>();
            List<int>[] graph = new List<int>[501], children = new List<int>[501]; 
            var isRelative = new bool[501][];
            int root = -1, res = 1;
            for (int i = 0; i < 501; i++)
            {
                graph[i] = new List<int>();
                isRelative[i] = new bool[501];
                children[i] = new List<int>();
            }
            foreach (var pair in pairs)
            {
                set.Add(pair[0]);
                set.Add(pair[1]);
                graph[pair[0]].Add(pair[1]);
                graph[pair[1]].Add(pair[0]);
                isRelative[pair[0]][pair[1]] = true;
                isRelative[pair[1]][pair[0]] = true;
            }
            var nodes = set.OrderBy(x => graph[x].Count).ToList();
            for (int i = 0; i < nodes.Count; i++)
            {
                var index = i + 1;
                while (index < nodes.Count && !isRelative[nodes[i]][nodes[index]])
                    index++;
                if (index < nodes.Count)
                {
                    children[nodes[index]].Add(nodes[i]);
                    if (graph[nodes[i]].Count == graph[nodes[index]].Count)
                        res = 2;
                }
                else
                {
                    if (root == -1) root = nodes[i];
                    else return 0;
                }
            }
            return DFS(root, 0, new HashSet<int>(), children, graph) == -1 ? 0 : res;
        }

        private static int DFS(int node, int depth, HashSet<int> visited, List<int>[] children, List<int>[] graph)
        {
            if (!visited.Add(node))
                return -1;
            var sum = children[node].Sum(child => DFS(child, depth + 1, visited, children, graph));
            if (sum + depth != graph[node].Count)
                return -1;
            return sum + 1;
        }
    }
}
