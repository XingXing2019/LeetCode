using System;
using System.Collections.Generic;

namespace CanIWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxChoosableInteger = 20, desiredTotal = 189;
            Console.WriteLine(CanIWin(maxChoosableInteger, desiredTotal));
        }
        public static bool CanIWin(int maxChoosableInteger, int desiredTotal)
        {
            if (desiredTotal <= maxChoosableInteger) return true;
            if ((1 + maxChoosableInteger) * maxChoosableInteger / 2 < desiredTotal) return false;
            var dp = new Dictionary<int, Dictionary<int, int[]>>();
            return DFS(maxChoosableInteger, desiredTotal, 0, 0, 0, dp) == 1;
        }

        public static int DFS(int maxChoosableInteger, int desiredTotal, int mask, int total, int turn, Dictionary<int, Dictionary<int, int[]>> dp)
        {
            if (!dp.ContainsKey(mask))
                dp[mask] = new Dictionary<int, int[]>();
            if (!dp[mask].ContainsKey(total))
                dp[mask][total] = new int[2];
            if (dp[mask][total][turn % 2] != 0)
                return dp[mask][total][turn % 2];
            if (total >= desiredTotal)
                return turn % 2 == 0 ? 2 : 1;
            if (turn % 2 == 0)
            {
                for (int i = 1; i <= maxChoosableInteger; i++)
                {
                    if ((mask & (1 << (i - 1))) != 0) continue;
                    if (DFS(maxChoosableInteger, desiredTotal, mask | (1 << (i - 1)), total + i, turn + 1, dp) == 1)
                        return dp[mask][total][turn % 2] = 1;
                }
                return dp[mask][total][turn % 2] = 2;
            }
            else
            {
                for (int i = 1; i <= maxChoosableInteger; i++)
                {
                    if ((mask & (1 << (i - 1))) != 0) continue;
                    if (DFS(maxChoosableInteger, desiredTotal, mask | (1 << (i - 1)), total + i, turn + 1, dp) == 2)
                        return dp[mask][total][turn % 2] = 2;
                }
                return dp[mask][total][turn % 2] = 1;
            }
        }
    }
}
