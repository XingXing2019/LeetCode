using System;

namespace CampusBikesII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] workers =
            {
                new[] { 8, 6 },
                new[] { 6, 2 },
            };

            int[][] bikes =
            {
                new[] { 7, 9 },
                new[] { 12, 2 },
                new[] { 3, 4 },
            };

            Console.WriteLine(AssignBikes(workers, bikes));
        }
        public static int AssignBikes(int[][] workers, int[][] bikes)
        {
            var dp = new int[1 << bikes.Length];
            Array.Fill(dp, -1);
            return DFS(workers, bikes, 0, 0, dp);
        }

        public static int DFS(int[][] workers, int[][] bikes, int state, int pos, int[] dp)
        {
            if (pos >= workers.Length) return 0;
            if (dp[state] != -1) return dp[state];
            if (state == (1 << bikes.Length) - 1) return 0;
            var res = int.MaxValue;
            for (int i = 0; i < bikes.Length; i++)
            {
                if ((state & (1 << i)) != 0) continue;
                var dis = Math.Abs(bikes[i][0] - workers[pos][0]) + Math.Abs(bikes[i][1] - workers[pos][1]);
                res = Math.Min(res, dis + DFS(workers, bikes, state | (1 << i), pos + 1, dp));
            }
            dp[state] = res;
            return res;
        }
    }
}
