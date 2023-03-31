using System;

namespace NumberOfWaysOfCuttingAPizza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pizza = { ".A", "A.", "A.", "AA" };
            var k = 5;
            Console.WriteLine(Ways(pizza, k));
        }

        public static int Ways(string[] pizza, int k)
        {
            long mod = 1_000_000_000 + 7;
            var dp = new long[pizza.Length][][];
            for (int i = 0; i < pizza.Length; i++)
            {
                dp[i] = new long[pizza[0].Length][];
                for (int j = 0; j < pizza[0].Length; j++)
                {
                    dp[i][j] = new long[k + 1];
                }
            }
            return (int)(DFS(pizza, 0, 0, k, mod, dp) % mod);
        }

        public static long DFS(string[] pizza, int row, int col, int k, long mod, long[][][] dp)
        {
            if (k == 1)
                return HasApple(pizza, col, pizza[0].Length, row, pizza.Length) ? 1 : 0;
            if (dp[row][col][k] != 0) 
                return dp[row][col][k];
            long res = 0;
            for (int i = row + 1; i < pizza.Length; i++)
            {
                if (!HasApple(pizza, col, pizza[0].Length, row, i)) continue;
                res += DFS(pizza, i, col, k - 1, mod, dp);
            }
            for (int j = col + 1; j < pizza[0].Length; j++)
            {
                if (!HasApple(pizza, col, j, row, pizza.Length)) continue;
                res += DFS(pizza, row, j, k - 1, mod, dp);
            }
            return dp[row][col][k] = res % mod;
        }

        public static bool HasApple(string[] pizza, int left, int right, int top, int bottom)
        {
            for (int i = top; i < bottom; i++)
            {
                for (int j = left; j < right; j++)
                {
                    if (pizza[i][j] != 'A') continue;
                    return true;
                }
            }
            return false;
        }
    }
}
