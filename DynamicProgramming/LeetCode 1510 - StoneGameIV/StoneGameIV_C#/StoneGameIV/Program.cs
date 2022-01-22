using System;
using System.Collections.Generic;
using System.Linq;

namespace StoneGameIV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 10000;
            Console.WriteLine(WinnerSquareGame(n));
        }

        public static bool WinnerSquareGame(int n)
        {
            var dp = new bool[n + 1];
            dp[1] = true;
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j * j <= i; j++)
                {
                    if (!dp[i - j * j])
                        dp[i] = true;
                }
            }
            return dp[^1];
        }
    }
}
