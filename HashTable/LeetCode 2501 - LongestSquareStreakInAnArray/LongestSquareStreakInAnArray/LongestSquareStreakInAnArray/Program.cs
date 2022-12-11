using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSquareStreakInAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 4, 3, 6, 16, 8, 2 };
            Console.WriteLine(LongestSquareStreak(nums));
        }

        public static int LongestSquareStreak(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            var subsequences = new List<List<int>>();
            var res = -1;
            foreach (var num in nums)
            {
                if (dict.ContainsKey(num)) continue;
                var pow = num * num;
                var sqrt = Math.Sqrt(num);
                var index = -1;
                if (dict.ContainsKey(pow))
                    index = dict[pow];
                else if (IsPerfectSqrt(num) && dict.ContainsKey((int)sqrt))
                    index = dict[(int)sqrt];
                else
                    index = subsequences.Count;
                if (index == subsequences.Count)
                    subsequences.Add(new List<int>());
                subsequences[index].Add(num);
                dict[num] = index;
            }
            foreach (var subsequence in subsequences)
            {
                if (subsequence.Count == 1) continue;
                res = Math.Max(res, subsequence.Count);
            }
            return res;
        }

        private static bool IsPerfectSqrt(int num, out int sqrt)
        {
            sqrt = -1;
            for (int i = 1; i < Math.Sqrt(num); i++)
            {
                if (i * i == num)
                {
                    sqrt = i;
                    return true;
                }
            }
            return false;
        }
    }
}
