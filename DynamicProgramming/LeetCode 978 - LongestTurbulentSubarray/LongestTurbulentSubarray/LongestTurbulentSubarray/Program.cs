//动态规划，dp[i]代表当前数字结尾的子串能形成的最长震动数组的长度。
//从第二个数字开始遍历数组，如果当前数字与其前一数字能满足条件，则dp[i]等于dp[i-1]+1。否则，在当前数字等于前一数字时dp[i]等于1，否则等于2.
//遍历过程中，统计能达到的最大长度。
using System;

namespace LongestTurbulentSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 8, 8, 8, 8 };
            Console.WriteLine(MaxTurbulenceSize(A));
        }
        static int MaxTurbulenceSize(int[] A)
        {
            if (A.Length == 1)
                return 1;
            int[] dp = new int[A.Length];
            dp[0] = 1;
            bool isLarger = A[1] > A[0];
            int maxLen = 0;
            for (int i = 1; i < dp.Length; i++)
            {
                if (isLarger && A[i] > A[i - 1] || !isLarger && A[i] < A[i - 1])
                {
                    dp[i] = dp[i - 1] + 1;
                }
                else
                {
                    if (A[i] == A[i - 1])
                        dp[i] = 1;
                    else
                        dp[i] = 2;
                }
                isLarger = !(A[i] > A[i - 1]);
                maxLen = Math.Max(maxLen, dp[i]);
            }
            return maxLen;
        }
    }
}
