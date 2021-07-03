using System;
using System.Collections.Generic;

namespace TimeNeededToInformAllEmployees
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 11, headId = 4;
            int[] manager = { 5, 9, 6, 10, -1, 8, 9, 1, 9, 3, 4 };
            int[] informTime = { 0, 213, 0, 253, 686, 170, 975, 0, 261, 309, 337 };
            Console.WriteLine(NumOfMinutes(n, headId, manager, informTime));
        }

        static int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            var graph = new List<int>[n];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new List<int>();
            for (int i = 0; i < manager.Length; i++)
            {
                if(manager[i] != -1)
                    graph[manager[i]].Add(i);
            }
            int res = 0;
            DFS(graph, 0, headID, informTime, ref res);
            return res;
        }

        static void DFS(List<int>[] graph, int sum, int cur, int[] informTime, ref int res)
        {
            if (informTime[cur] == 0)
            {
                res = Math.Max(res, sum);
                return;
            }
            foreach (var next in graph[cur])
                DFS(graph, sum + informTime[cur], next, informTime, ref res);
        }
    }
}
