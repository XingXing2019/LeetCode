//创建动态数组dp，代表每个数字最少能有几个平方数组成。先将数组中每个元素设为int最大值。再遍历dp将index为一个数字平方的位置设为1，代表该数字可以被一个平方数组成。
//每个数都可以看做一个平方数j * j加上一个任意数i，则组成该数字的个数等于组成i的数字个数加一， 数学表达为dp[i + j * j] = dp[i] + 1。
//遍历数组，对于数组中的每个数字为当前数字和dp[i] + 1中较小的数字。
//需要注意的是，组成每个数字的平方数和任意数可以由不止一对，所有要每次选取当前数字可能计算数字中较小值。
using System;

namespace PerfectSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 15;
            Console.WriteLine(NumSquares(n));
        }
        static int NumSquares(int n)
        {
            int[] dp = new int[n + 1];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = int.MaxValue;
            for (int i = 0; i * i <= n; i++)
                dp[i * i] = 1;
            for (int i = 1; i <= n; i++)
                for (int j = 1; i + j * j <= n; j++)
                    dp[i + j * j] = Math.Min(dp[i] + 1, dp[i + j * j]);
            return dp[n];
        }
    }
}
