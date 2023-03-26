using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeSubtractionOperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 4, 9, 6, 10 };
            Console.WriteLine(PrimeSubOperation(nums));
        }

        public static bool PrimeSubOperation(int[] nums)
        {
            var primes = GetPrimes(nums.Max());
            for (int i = nums.Length - 1; i >= 1; i--)
            {
                if (nums[i] > nums[i - 1]) continue;
                var index = primes.BinarySearch(nums[i - 1] - nums[i] + 1);
                if (index < 0) index = ~index;
                if (index >= primes.Count || primes[index] >= nums[i - 1])
                    return false;
                nums[i - 1] -= primes[index];
            }
            return true;
        }

        public static List<int> GetPrimes(int max)
        {
            var dp = new bool[max + 1];
            var res = new List<int>();
            Array.Fill(dp, true);
            for (int i = 2; i < dp.Length; i++)
            {
                if (!dp[i]) continue;
                for (int j = 2; i * j < dp.Length; j++)
                    dp[i * j] = false;
                res.Add(i);
            }
            return res;
        }
    }
}
