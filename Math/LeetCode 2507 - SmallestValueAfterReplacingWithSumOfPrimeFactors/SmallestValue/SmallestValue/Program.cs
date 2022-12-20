using System;
using System.Collections.Generic;

namespace SmallestValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = 4;
            Console.WriteLine(SmallestValue(n));
        }

        public static int SmallestValue(int n)
        {
            var copy = 0;
            var primes = GetPrimes(n);
            while (!primes.Contains(n) && copy != n)
            {
                copy = n;
                n = GetPrimeSum(n, primes);
            }
            return n;
        }

        public static HashSet<int> GetPrimes(int n)
        {
            var res = new HashSet<int>();
            var dp = new bool[n + 1];
            Array.Fill(dp, true);
            for (int i = 2; i < dp.Length; i++)
            {
                if (!dp[i]) continue;
                for (int j = 2; i * j < dp.Length; j++)
                    dp[i * j] = false;
            }
            for (int i = 2; i < dp.Length; i++)
            {   
                if (!dp[i]) continue;
                res.Add(i);
            }
            return res;
        }

        public static int GetPrimeSum(int n, HashSet<int> primes)
        {
            var sum = 0;
            foreach (var prime in primes)
            {
                if (prime > n) break;
                while (n % prime == 0)
                {
                    sum += prime;
                    n /= prime;
                }
            }
            return sum;
        }
    }
}
