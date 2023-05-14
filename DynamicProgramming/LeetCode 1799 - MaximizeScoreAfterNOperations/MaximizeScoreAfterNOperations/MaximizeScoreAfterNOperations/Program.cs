using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
            int n = nums.Length, range = 1 << n;
            var dp = new int[range];
            for (int i = 0; i < dp.Length; i++)
            {
                var count = Count(i);
                if ((count & 1) == 1) continue;
                for (int j = 0; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        var state = (1 << j) | (1 << k);
                        if ((state & i) != state) continue;
                        dp[i] = Math.Max(dp[i], dp[i - state] + gcds[nums[j]][nums[k]] * (count >> 1));
                    }
                }

            }
            return dp[^1];
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

        private static int Count(int num)
        {
            var res = 0;
            while (num != 0)
            {
                res += (num & 1);
                num >>= 1;
            }
            return res;
        }
    }
}
