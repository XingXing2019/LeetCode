using System;

namespace StoneGameIII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static string StoneGameIII(int[] stoneValue)
        {
            var dp = new int[stoneValue.Length];
            var diff = DFS(stoneValue, 0, dp);
            return diff == 0 ? "Tie" : diff > 0 ? "Alice" : "Bob";
        }

        public static int DFS(int[] stoneValue, int index, int[] dp)
        {
            if (index >= stoneValue.Length)
                return 0;
            if (dp[index] != 0)
                return dp[index];
            int max = int.MinValue, sum = 0;
            for (int i = index; i < Math.Min(stoneValue.Length, index + 3); i++)
            {
                sum += stoneValue[i];
                max = Math.Max(max, sum - DFS(stoneValue, i + 1, dp));
            }
            return dp[index] = max;
        }
    }
}
