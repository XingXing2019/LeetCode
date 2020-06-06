using System;
using System.Collections.Generic;

namespace AllPathsFromSourceToTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            var res = new List<IList<int>>();
            var visit = new bool[graph.Length];
            visit[0] = true;
            var path = new List<int>();
            DFS(graph, visit, 0, graph.Length - 1, path, res);
            return res;
        }

        private void DFS(int[][] graph, bool[] visit, int cur, int target, List<int> path, List<IList<int>> res)
        {
            path.Add(cur);
            visit[cur] = true;
            if (cur == target)
            {
                var temp = new List<int>(path);
                res.Add(temp);
            }
            foreach (var next in graph[cur])
            {
                if(visit[next]) continue;
                DFS(graph, visit, next, target, path, res);
                visit[next] = false;
                path.Remove(next);
            }
        }
    }
}
