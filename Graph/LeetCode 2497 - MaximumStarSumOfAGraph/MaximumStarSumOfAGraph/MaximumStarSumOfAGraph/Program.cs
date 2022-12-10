using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumStarSumOfAGraph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaxStarSum(int[] vals, int[][] edges, int k)
        {
            var graph = new List<int>[vals.Length];
            for (int i = 0; i < vals.Length; i++)
                graph[i] = new List<int>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            var res = int.MinValue;
            for (int i = 0; i < vals.Length; i++)
            {
                var neighbors = graph[i].Where(next => vals[next] > 0).Select(next => vals[next]).OrderByDescending(x => x).Take(k).ToList();
                res = Math.Max(res, vals[i] + neighbors.Sum());
            }
            return res;
        }
    }
}
