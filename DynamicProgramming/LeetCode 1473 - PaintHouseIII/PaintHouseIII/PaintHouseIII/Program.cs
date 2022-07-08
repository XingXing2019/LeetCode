using System;

namespace PaintHouseIII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        int[][][] dp; 
        public int MinCost(int[] houses, int[][] cost, int m, int n, int target)
        {
            dp = new int[m][][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[target + 1][];
                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = new int[n + 1];
                    Array.Fill(dp[i][j], -1);
                }
            }
            return DFS(houses, cost, 0, target, 0);
        }

        int DFS(int[] houses, int[][] cost, int index, int target, int lastColor)
        {
            if (target < 0) return -1;
            if (index == houses.Length) return target == 0 ? 0 : -1;
            if (dp[index][target][lastColor] != -1) return dp[index][target][lastColor];
            if (houses[index] > 0)
            {
                var color = houses[index];
                if (color != lastColor) target--;
                return DFS(houses, cost, index + 1, target, color);
            }
            int min = int.MaxValue;
            for (int c = 1; c <= cost[0].Length; c++)
            {
                var costTemp = DFS(houses, cost, index + 1, c == lastColor ? target : target - 1, c);
                if (costTemp == -1) continue;
                costTemp += cost[index][c - 1];
                min = Math.Min(min, costTemp);
            }
            if (min == int.MaxValue) min = -1;
            dp[index][target][lastColor] = min;
            return min;
        }
    }
}
