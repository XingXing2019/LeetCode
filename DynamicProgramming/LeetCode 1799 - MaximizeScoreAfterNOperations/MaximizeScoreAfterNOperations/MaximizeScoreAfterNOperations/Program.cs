using System;
using System.Collections.Generic;

namespace MaximizeScoreAfterNOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 4, 6, 8 };
            Console.WriteLine(MaxScore(nums));
        }

        public static int MaxScore(int[] nums)
        {
            var gcds = GetGCDs(nums);
            var dp = new int[nums.Length][][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[nums.Length][];
                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = new int[nums.Length / 2 + 1];
                }
            }
            return DFS(nums, 0, 0, nums.Length / 2, new HashSet<int>(), gcds, dp);
        }

        private static int DFS(int[] nums, int x, int y, int n, HashSet<int> used, Dictionary<int, Dictionary<int, int>> gcds, int[][][] dp)
        {
            if (n == 0)
                return 0;
            if (dp[x][y][n] != 0)
                return dp[x][y][n];
            var sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (used.Contains(i)) continue;
                used.Add(i);
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (used.Contains(j)) continue;
                    used.Add(j);
                    var gcd = gcds[nums[i]][nums[j]];
                    sum += DFS(nums, i, j, n - 1, used, gcds, dp) + gcd * n;
                    used.Remove(j);
                }
                used.Remove(i);
            }
            return dp[x][y][n] = sum;
        }

        private static int GCD(int x, int y)
        {
            return y == 0 ? x : GCD(y, x % y);
        }

        private static Dictionary<int, Dictionary<int, int>> GetGCDs(int[] nums)
        {
            var res = new Dictionary<int, Dictionary<int, int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int x = nums[i], y = nums[j];
                    var gcd = GCD(x, y);
                    if (!res.ContainsKey(x))
                        res[x] = new Dictionary<int, int>();
                    res[x][y] = gcd;
                    if (!res.ContainsKey(y))
                        res[y] = new Dictionary<int, int>();
                    res[y][x] = gcd;
                }
            }
            return res;
        }
    }
}
