using System;
using System.Linq;

namespace CountWaysToBuildGoodStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int low = 2, high = 3, zero = 1, one = 2;
            Console.WriteLine(CountGoodStrings(low, high, zero, one));
        }
        public static int CountGoodStrings(int low, int high, int zero, int one)
        {
            var dp = new long[high + 1];
            long res = 0, mod = 1_000_000_000 + 7;
            dp[zero]++;
            dp[one]++;
            if (zero != one && one % zero == 0)
                dp[one]++;
            if (zero != one && zero % one == 0)
                dp[zero]++;
            for (int i = Math.Min(zero, one); i <= high; i++)
            {
                if (i == zero || i == one) continue;
                if (i - zero >= 0 && dp[i - zero] != 0)
                    dp[i] = (dp[i] + dp[i - zero]) % mod;
                if (i - one >= 0 && dp[i - one] != 0)
                    dp[i] = (dp[i] + dp[i - one]) % mod;
            }
            for (int i = low; i <= high; i++)
                res = (res + dp[i]) % mod;
            return (int)(res % mod);
        }
    }
}
