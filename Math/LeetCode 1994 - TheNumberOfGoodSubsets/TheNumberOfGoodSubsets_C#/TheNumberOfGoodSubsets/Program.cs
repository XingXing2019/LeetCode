using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TheNumberOfGoodSubsets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 4, 2, 3, 15 };
            Console.WriteLine(NumberOfGoodSubsets_DP(nums));
        }
        
        public static int NumberOfGoodSubsets(int[] nums)
        {
            var candidates = new List<int> { 2, 3, 5, 6, 7, 10, 11, 13, 14, 15, 17, 19, 21, 22, 23, 26, 29, 30 };
            var freq = nums.GroupBy(x => x).Where(x => candidates.Contains(x.Key)).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Count());
            var goodNums = freq.Select(x => x.Key).ToList();
            var ones = nums.Count(x => x == 1);
            var combinations = new List<List<int>>();
            DFS(goodNums, 0, new List<int>(), combinations);
            long res = 0, mod = 1_000_000_000 + 7;
            var banned = new HashSet<string>();
            for (int i = 0; i < candidates.Count; i++)
            {
                for (int j = i + 1; j < candidates.Count; j++)
                {
                    if (GCD(candidates[i], candidates[j]) == 1) continue;
                    banned.Add($"{candidates[i]}:{candidates[j]}");
                }
            }
            foreach (var combination in combinations)
            {
                if (!IsVaild(combination, banned)) continue;
                long sum = 1;
                foreach (var num in combination)
                    sum = sum * freq[num] % mod;
                res += sum;
            }
            for (int i = 0; i < ones; i++)
                res = res * 2 % mod;
            return (int) (res % mod);
        }

        private static int GCD(int nums1, int nums2)
        {
            if (nums2 == 0) return nums1;
            return GCD(nums2, nums1 % nums2);
        }

        private static bool IsVaild(List<int> combination, HashSet<string> banned)
        {
            for (int i = 0; i < combination.Count; i++)
            {
                for (int j = i + 1; j < combination.Count; j++)
                {
                    if (banned.Contains($"{combination[i]}:{combination[j]}"))
                        return false;
                }
            }
            return true;
        }

        public static void DFS(List<int> goodNums, int start, List<int> combination, List<List<int>> combinations)
        {
            if (combination.Count != 0)
            {
                combinations.Add(new List<int>(combination));
            }
            for (int i = start; i < goodNums.Count; i++)
            {
                combination.Add(goodNums[i]);
                DFS(goodNums, i + 1, combination, combinations);
                combination.RemoveAt(combination.Count - 1);
            }
        }

        public static int NumberOfGoodSubsets_DP(int[] nums)
        {
            var primes = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var ones = nums.Count(x => x == 1);
            var dp = new long[1 << primes.Count];
            dp[0] = 1;
            long res = 0, mod = 1_000_000_000 + 7;
            foreach (var num in freq.Keys)
            {
                if (num == 1) continue;
                var encode = EncodeNum(num, primes);
                if (encode == -1) continue;
                for (int i = dp.Length - 1; i >= 1; i--)
                {
                    if (i - encode != (i ^ encode)) continue;
                    dp[i] = (dp[i] + dp[i - encode] * freq[num]) % mod;
                }
            }
            for (int i = 1; i < dp.Length; i++)
                res = (res + dp[i]) % mod;
            for (int i = 0; i < ones; i++)
                res = res * 2 % mod;
            return (int) res;
        }

        private static int EncodeNum(int num, List<int> primes)
        {
            var res = 0;
            for (int i = 0; i < primes.Count; i++)
            {
                if (num % primes[i] == 0)
                {
                    res += 1 << i;
                    num /= primes[i];
                }
                if (num % primes[i] == 0)
                    return -1;
            }
            return res;
        }
    }
}
