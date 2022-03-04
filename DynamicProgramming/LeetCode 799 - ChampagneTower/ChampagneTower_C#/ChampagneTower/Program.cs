using System;

namespace ChampagneTower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int poured = 10, query_row = 3, query_glass = 3;
            Console.WriteLine(ChampagneTower(poured, query_row, query_glass));
        }
        public static double ChampagneTower(int poured, int query_row, int query_glass)
        {
            var dp = new double[query_row + 1][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new double[query_row + 1];
            dp[0][0] = (double)poured;
            for (int i = 0; i < query_row; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    var surplus = dp[i][j] - 1;
                    if (!(surplus > 0)) continue;
                    dp[i + 1][j] += surplus / 2;
                    dp[i + 1][j + 1] += surplus / 2;
                }
            }
            return Math.Min(1, dp[query_row][query_glass]);
        }
    }
}
