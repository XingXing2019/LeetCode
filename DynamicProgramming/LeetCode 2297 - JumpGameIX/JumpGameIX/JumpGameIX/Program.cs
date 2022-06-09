using System;
using System.Collections.Generic;

namespace JumpGameIX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 2, 4, 4, 1 };
            int[] cost = { 3, 7, 6, 4, 2 };
            Console.WriteLine(MinCost(nums, cost));
        }
        public static long MinCost(int[] nums, int[] costs)
        {
            var up = new int[nums.Length];
            var down = new int[nums.Length];
            var dp = new long[nums.Length];
            Array.Fill(up, -1);
            Array.Fill(down, -1);
            Array.Fill(dp, long.MaxValue);
            dp[0] = 0;
            var stack = new Stack<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count != 0 && nums[i] >= nums[stack.Peek()])
                    up[stack.Pop()] = i;
                stack.Push(i);
            }
            stack.Clear();
            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count != 0 && nums[i] < nums[stack.Peek()])
                    down[stack.Pop()] = i;
                stack.Push(i);
            }
            for (int i = 0; i < dp.Length; i++)
            {
                if (up[i] != -1)
                    dp[up[i]] = Math.Min(dp[up[i]], dp[i] + costs[up[i]]);
                if (down[i] != -1)
                    dp[down[i]] = Math.Min(dp[down[i]], dp[i] + costs[down[i]]);
            }
            return dp[^1];
        }
    }
}
