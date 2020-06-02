using System;
using System.Collections.Generic;

namespace QueriesOnAPermutationWithKey
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int[] ProcessQueries(int[] queries, int m)
        {
            var p = new List<int>();
            for (int i = 1; i <= m; i++)
                p.Add(i);
            var res = new int[queries.Length];
            int index = 0;
            foreach (var q in queries)
            {
                res[index++] = p.IndexOf(q);
                p.Remove(q);
                p.Insert(0, q);
            }
            return res;
        }
    }
}
