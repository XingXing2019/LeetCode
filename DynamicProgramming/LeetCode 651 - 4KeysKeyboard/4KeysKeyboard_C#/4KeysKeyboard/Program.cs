using System;

namespace _4KeysKeyboard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 8;
            Console.WriteLine(MaxA(n));
        }

        public static int MaxA(int n)
        {
            var dp = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                var max = 0;
                for (int j = 0; j < i - 2; j++)
                    max = Math.Max(max, dp[j] * (i - j - 1));
                dp[i] = Math.Max(i, max);
            }
            return dp[^1];
        }
    }
}
