using System;

namespace CanYouEat
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] candiesCount =
            {
                7,4,5,3,8
            };

            int[][] queries = new[] { new[] { 48942, 869704869, 212630006 } };

            Console.WriteLine(CanEat(candiesCount, queries));
        }
        public static bool[] CanEat(int[] candiesCount, int[][] queries)
        {
            long[] nonInclude = new long[candiesCount.Length];
            long[] include = new long[candiesCount.Length];
            include[0] = candiesCount[0];
            for (int i = 1; i < candiesCount.Length; i++)
            {
                include[i] = include[i - 1] + candiesCount[i];
                nonInclude[i] = include[i - 1];
            }
            var res = new bool[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                long min = queries[i][1], max = ((long) queries[i][1] + 1) * queries[i][2];
                if (min >= include[queries[i][0]] || max <= nonInclude[queries[i][0]])
                    continue;
                res[i] = true;
            }
            return res;
        }
    }
}
