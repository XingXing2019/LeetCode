using System;
using System.Collections.Generic;

namespace SentenceSimilarityII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool AreSentencesSimilarTwo(string[] words1, string[] words2, IList<IList<string>> pairs)
        {
            if (words1.Length != words2.Length) return false;
            var graph = new Dictionary<string, List<string>>();
            foreach (var pair in pairs)
            {
                if (!graph.ContainsKey(pair[0]))
                    graph[pair[0]] = new List<string>();
                if (!graph.ContainsKey(pair[1]))
                    graph[pair[1]] = new List<string>();
                graph[pair[0]].Add(pair[1]);
                graph[pair[1]].Add(pair[0]);
            }
            for (int i = 0; i < words1.Length; i++)
            {
                if (!BFS(words1[i], words2[i], graph))
                    return false;
            }
            return true;
        }

        static bool BFS(string start, string end, Dictionary<string, List<string>> graph)
        {
            var queue = new Queue<string>();
            var visit = new HashSet<string> {start};
            queue.Enqueue(start);
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (cur == end) return true;
                if (!graph.ContainsKey(cur)) return false;
                foreach (var next in graph[cur])
                {
                    if(visit.Add(next))
                        queue.Enqueue(next);
                }
            }
            return false;
        }
    }
}
