using System;
using System.Collections.Generic;

namespace KillProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static IList<int> KillProcess(IList<int> pid, IList<int> ppid, int kill)
        {
            var graph = new Dictionary<int, List<int>>();
            foreach (var process in pid)
                graph[process] = new List<int>();
            for (int i = 0; i < ppid.Count; i++)
            {
                if(ppid[i] == 0) continue;
                graph[ppid[i]].Add(pid[i]);
            }
            var res = new List<int>();
            var queue = new Queue<int>();
            queue.Enqueue(kill);
            res.Add(kill);
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                foreach (var next in graph[cur])
                {
                    res.Add(next);
                    queue.Enqueue(next);
                }
            }
            return res;
        }
    }
}
