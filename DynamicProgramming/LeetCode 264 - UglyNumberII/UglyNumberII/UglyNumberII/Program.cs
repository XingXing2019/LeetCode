//创建动态数组dp，用于记录每一个ugly number，将第一个数设为1。对于其后面的而每一个数，应该为前面所有数字分别乘以2，3，5，所得到的数字中最接近于其之前一个数字的数。
//创建a，b，c指针，初始值全部指向dp中第一个数字。动态遍历dp，创建min为的dp[a] * 2，dp[b] * 3，dp[c] * 5中最小的值。并将dp[i]设为min。
//如果min等于dp[a] * 2，dp[b] * 3，dp[c] * 5中的任何值，都令该指针前进一位。最后返回dp最后一位即为结果。
using System;

namespace UglyNumberII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            Console.WriteLine(NthUglyNumber(n));
        }
        static int NthUglyNumber(int n)
        {
            int[] dp = new int[n];
            dp[0] = 1;
            int a = 0, b = 0, c = 0;
            for (int i = 1; i < dp.Length; i++)
            {
                int min = Math.Min(dp[a] * 2, Math.Min(dp[b] * 3, dp[c] * 5));
                if (dp[a] * 2 == min)
                    a++;
                if (dp[b] * 3 == min)
                    b++;
                if (dp[c] * 5 == min)
                    c++;
                dp[i] = min;
            }
            return dp[dp.Length - 1];
        }
    }
}
