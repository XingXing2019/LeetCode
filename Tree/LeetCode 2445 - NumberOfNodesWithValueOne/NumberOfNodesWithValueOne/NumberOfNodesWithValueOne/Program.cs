using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfNodesWithValueOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int NumberOfNodes(int n, int[] queries)
        {
            var freq = queries.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var dp = new int[n + 1];
            for (int i = 1; i <= n; i++)
                dp[i] = dp[i / 2] + freq.GetValueOrDefault(i, 0);
            return dp.Count(x => x % 2 != 0);
        }
    }
}
