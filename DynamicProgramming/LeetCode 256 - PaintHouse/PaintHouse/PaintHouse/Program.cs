using System;
using System.Linq;

namespace PaintHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MinCost(int[][] costs)
        {
            if (costs.Length == 0) return 0;
            var dp = new int[costs.Length][];
            dp[0] = costs[0];
            for (int i = 1; i < dp.Length; i++)
            {
                dp[i] = new int[3];
                dp[i][0] = Math.Min(dp[i - 1][1], dp[i - 1][2]) + costs[i][0];
                dp[i][1] = Math.Min(dp[i - 1][0], dp[i - 1][2]) + costs[i][1];
                dp[i][2] = Math.Min(dp[i - 1][0], dp[i - 1][1]) + costs[i][2];
            }
            return dp[^1].Min();
        }

        
    }
}
