//创建动态数组dp记录每个数字能拆成数字的最大乘积。认为将2-5的结果加入dp，并设置相应的判断条件。
//通过枚举发现在5以后的数字，如果i能被3整除，则dp[i]为3的i/3次幂。如果不能被3整除，则dp[i]为2*dp[i-2]和dp[i-1]/3*4中较大的值。
using System;

namespace IntegerBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6;
            Console.WriteLine(IntegerBreak(n));
        }
        static int IntegerBreak(int n)
        {
            if (n < 4)
                return n - 1;
            if (n == 4)
                return 4;
            if (n == 5)
                return 6;
            int[] dp = new int[n + 1];
            dp[2] = 1;
            dp[3] = 2;
            dp[4] = 4;
            dp[5] = 6;
            for (int i = 6; i < dp.Length; i++)
            {
                if (i % 3 == 0)
                    dp[i] = (int)Math.Pow(3, i / 3);
                else
                    dp[i] = Math.Max(dp[i - 1] / 3 * 4, 2 * dp[i - 2]);
            }
            return dp[n];
        }
        static int IntegerBreak2(int n)
        {
            if (n < 4)
                return n - 1;
            int res = 1;
            while (n > 4)
            {
                res *= 3;
                n -= 3;
            }
            res *= n;
            return res;
        }
    }
}
