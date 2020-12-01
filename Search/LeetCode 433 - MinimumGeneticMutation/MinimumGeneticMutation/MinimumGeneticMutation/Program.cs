using System;
using System.Collections.Generic;

namespace MinimumGeneticMutation
{
    class Program
    {
        static void Main(string[] args)
        {
            string start = "AACCGGTT", end = "AACCGGTA";
            string[] bank = { "AACCGGTA" };
            Console.WriteLine(MinMutation(start, end, bank));
        }
        static int MinMutation(string start, string end, string[] bank)
        {
            var graph = new Dictionary<string, List<string>> { { start, new List<string>() } };
            foreach (var gene in bank)
                graph[gene] = new List<string>();
            foreach (var kv in graph)
            {
                foreach (var gene in bank)
                {
                    if (CheckConnect(kv.Key, gene))
                        kv.Value.Add(gene);
                }
            }
            var queue = new Queue<Dictionary<string, int>>();
            queue.Enqueue(new Dictionary<string, int> { { start, 0 } });
            var visit = new HashSet<string> { start };
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (cur.ContainsKey(end))
                    return cur[end];
                foreach (var kv in cur)
                {
                    var next = kv.Key;
                    foreach (var gene in graph[next])
                    {
                        if (visit.Add(gene))
                            queue.Enqueue(new Dictionary<string, int> { { gene, kv.Value + 1 } });
                    }
                }
            }
            return -1;
        }

        static bool CheckConnect(string gene1, string gene2)
        {
            var count = 0;
            for (int i = 0; i < gene1.Length; i++)
            {
                if (gene1[i] != gene2[i])
                    count++;
            }
            return count == 1;
        }
    }
}
