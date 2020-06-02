//第一种方法是使用递归算法, 这种算法好理解，但是会超时。
//第二种方法时应用动态编程的思想。
//因为一次可以爬1阶或2阶。所以爬到第i阶只与爬到第i-1阶和爬到第i-2阶的方法相关。
//想爬到第i阶方法。可以从i-1阶爬一步，或者从i-2阶爬两步。无需考虑从i-2阶先爬到i-1阶的情况，因为如果这样也相当于从i-1阶爬一步。
//所以爬到第阶方法的数量等于爬到第i-1阶和第i-2阶方法数量的总和。
//先创建一个长度为n+1的数组dp，代表从第0阶到第n阶没从情况爬法的数量。dp[1]设为1，dp[2]设为2。
//遍历数组将dp[i]设为dp[i-1]加dp[i-2]。最后返回dp[n]。
using System;

namespace ClimbingStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ClimbStairs2(1));
        }
        static int ClimbStairs1(int n)
        {
            if (n == 1 || n == 2)
                return n;
            return ClimbStairs1(n - 1) + ClimbStairs1(n - 2);
        }
        static int ClimbStairs2(int n)
        {
            if (n == 0)
                return 1;
            if (n == 1 || n == 2)
                return n;
            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i < dp.Length; i++)
                dp[i] = dp[i - 1] + dp[i - 2];
            return dp[n];
        }
    }
}
