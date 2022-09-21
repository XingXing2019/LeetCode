using System;
using System.Collections.Generic;
using System.Text;

namespace KSimilarStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int KSimilarity(string s1, string s2)
        {
            var queue = new Queue<string>();
            queue.Enqueue(s1);
            var visited = new HashSet<string> { s1 };
            var res = 0;
            while (queue.Count != 0)
            {
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (cur == s2)
                        return res;
                    var start = 0;
                    while (cur[start] == s2[start])
                        start++;
                    for (int j = start + 1; j < s2.Length; j++)
                    {
                        if (cur[j] == s2[j] || cur[j] != s2[start])
                            continue;
                        var newWord = new StringBuilder(cur);
                        (newWord[start], newWord[j]) = (newWord[j], newWord[start]);
                        if (!visited.Add(newWord.ToString()))
                            continue;
                        queue.Enqueue(newWord.ToString());
                    }
                }
                res++;
            }
            return -1;
        }
    }
}
