using System;
using System.Collections.Generic;

namespace JumpGameIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 0, 2, 1, 2 };
            int start = 2;
            Console.WriteLine(CanReach(arr, start));
        }
        static bool CanReach(int[] arr, int start)
        {
            var graph = new List<int>[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                graph[i] = new List<int>();
                if(i - arr[i] >= 0)
                    graph[i].Add(i - arr[i]);
                if(i + arr[i] < arr.Length)
                    graph[i].Add(i + arr[i]);
            }
            var visit = new bool[arr.Length];
            var queue = new Queue<int>();
            queue.Enqueue(start);
            visit[start] = true;
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (arr[cur] == 0)
                    return true;
                foreach (var next in graph[cur])
                {
                    if (!visit[next])
                    {
                        queue.Enqueue(next);
                        visit[next] = true;
                    }
                }
            }
            return false;
        }
    }
}
