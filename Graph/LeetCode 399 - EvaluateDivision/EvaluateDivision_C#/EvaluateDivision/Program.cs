using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace EvaluateDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            var equations = new List<IList<string>>
            {
                new List<string>{"x1", "x2"},
                new List<string>{"x2", "x3"},
                new List<string>{"x3", "x4"},
                new List<string>{"x4", "x5"},
            };
            double[] values = { 3.0, 4.0, 5.0, 6.0 };
            var queries = new List<IList<string>>
            {
                new List<string>{"x1", "x5"},
                new List<string>{"x5", "x2"},
                new List<string>{"x2", "x4"},
                new List<string>{"x2", "x2"},
                new List<string>{"x2", "x9"},
                new List<string>{"x9", "x9"}
            };

            Console.WriteLine(CalcEquation(equations, values, queries));
        }
        static double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var res = new double[queries.Count];
            var graph = new Dictionary<string, Dictionary<string, double>>();
            for (int i = 0; i < equations.Count; i++)
            {
                string x = equations[i][0], y = equations[i][1];
                if (!graph.ContainsKey(x))
                    graph[x] = new Dictionary<string, double>();
                graph[x].Add(y, values[i]);
                if(!graph.ContainsKey(y))
                    graph[y] = new Dictionary<string, double>();
                graph[y].Add(x, 1 / values[i]);
            }
            for (int i = 0; i < queries.Count; i++)
            {
                if(graph.ContainsKey(queries[i][0]) && graph.ContainsKey(queries[i][0])) 
                    DFS(res, graph, new HashSet<string>(), queries[i][0], queries[i][1], 1, i);
                if (res[i] == 0.0) res[i] = -1;
            }
            return res;
        }

        static void DFS(double[] res, Dictionary<string, Dictionary<string, double>> graph, HashSet<string> visit, 
            string start, string target, double num, int index)
        {

            if (start == target) res[index] = num;
            foreach (var next in graph[start])
            {
                if (!visit.Add(next.Key)) continue;
                DFS(res, graph, visit, next.Key, target, num * next.Value, index);
            }
        }
       
    }
}
