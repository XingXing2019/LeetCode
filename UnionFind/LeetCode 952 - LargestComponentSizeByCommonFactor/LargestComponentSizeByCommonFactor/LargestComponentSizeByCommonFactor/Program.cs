using System;
using System.Collections.Generic;
using System.Linq;

namespace LargestComponentSizeByCommonFactor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 4, 6, 15};
            Console.WriteLine(LargestComponentSize(nums));
        }

        private static int[] parents;
        private static int[] rank;
        public static int LargestComponentSize(int[] nums)
        {
            var max = nums.Max();
            var set = new HashSet<int>(nums);
            parents = new int[max + 1];
            rank = new int[max + 1];
            for (int i = 0; i < max + 1; i++)
                parents[i] = i;
            var primes = FindPrime(max);
            foreach (var num in nums)
            {
                var copy = num;
                foreach (var prime in primes)
                {
                    if (copy < prime) break;
                    if (copy % prime != 0) continue;
                    Union(num, prime);
                    while (copy % prime == 0)
                        copy /= prime;
                }
            }
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < parents.Length; i++)
            {
                if (!set.Contains(i)) continue;
                var root = Find(parents[i]);
                if (!dict.ContainsKey(root))
                    dict[root] = 0;
                dict[root]++;
            }
            return dict.Max(x => x.Value);
        }

        public static List<int> FindPrime(int n)
        {
            var res = new List<int>();
            if (n < 3) return res;
            var dp = new bool[n + 1];
            for (int i = 0; i < n + 1; i++)
                dp[i] = true;
            for (int i = 2; i < dp.Length; i++)
            {
                if (!dp[i]) continue;
                for (int j = 2; i * j <= n; j++)
                    dp[i * j] = false;
            }
            for (int i = 2; i < dp.Length; i++)
            {
                if (dp[i]) 
                    res.Add(i);
            }
            return res;
        }

        public static int Find(int x)
        {
            if (parents[x] != x)
                parents[x] = Find(parents[x]);
            return parents[x];
        }

        public static void Union(int x, int y)
        {
            int rootX = Find(x), rootY = Find(y);
            if (rootX == rootY) return;
            if (rank[rootX] > rank[rootY])
            {
                parents[rootY] = rootX;
                if (rank[rootX] == rank[rootY])
                    rank[rootX]++;
            }
            else
                parents[rootX] = rootY;
        }
        
    }
}
