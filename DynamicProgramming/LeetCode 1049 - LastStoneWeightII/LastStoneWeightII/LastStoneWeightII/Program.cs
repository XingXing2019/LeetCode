//思路为试图找出数组中的一组数组，他们的总和最接近整合数组总和的一半。则用这组数去抵消余下的数字，则可以获得最小值。
//先统计数组中总和的一半target。创建一个bool数组dp，长度为target加一。dp[i]用于记录能否有一组数字，他们的总和为i。dp[0]设为true。
//遍历stones中的每个数字。每次遍历时，倒着遍历dp到当前数字。dp[i]=dp[i]||dp[i - s]。由于dp[0]为true，则当遍历到i等于s时，dp[i]也会为true。当遍历到stones中下一个数字时，当遍历到i等于s和上一个数字时，dp[i]也会没设为true。
//如果dp[i]为true，i又正好是target时，证明可以有一组数字总和为target。这时直接返回sum-target-target。否则，用一个max记录可以达到离target最近的值。
//遍历结束后仍未返回，则证明不能达到target，则返回sum-max-max。
using System;

namespace LastStoneWeightII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] stones = { 2, 7, 4, 1, 8, 1 };
            Console.WriteLine(LastStoneWeightII(stones));
        }
        static int LastStoneWeightII(int[] stones)
        {
            int sum = 0;
            foreach (var s in stones)
                sum += s;
            int target = sum / 2;
            bool[] dp = new bool[target + 1];
            dp[0] = true;
            int max = 0;
            foreach (var s in stones)
            {
                for (int i = target; i >= s; i--)
                {
                    dp[i] = dp[i] || dp[i - s];
                    if (dp[i])
                    {
                        if (i == target)
                            return sum - target - target;
                        max = Math.Max(max, i);
                    }
                }
            }
            return sum - max - max;
        }
  
    }
}
