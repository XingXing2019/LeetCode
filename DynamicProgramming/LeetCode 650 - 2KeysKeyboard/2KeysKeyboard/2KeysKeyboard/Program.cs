//创建爱你动态数组dp，dp[i]代表n等于i时需要几步。
//将dp[1]设为0，dp[i]等于i之前第一个能被i整除数字的步数加一再加上i除以这个数字。
//最后返回dp[n]就是结果。
using System;

namespace _2KeysKeyboard
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 24;
            Console.WriteLine(MinSteps(n));
        }
        static int MinSteps(int n)
        {
            int[] dp = new int[n + 1];
            dp[1] = 0;
            for (int i = 2; i < dp.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (i % j == 0)
                    {
                        dp[i] = dp[j] + i / j;
                        break;
                    }
                }
            }
            return dp[n];
        }
    }
}
