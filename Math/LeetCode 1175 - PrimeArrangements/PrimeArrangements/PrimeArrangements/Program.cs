using System;

namespace PrimeArrangements
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 20;
            Console.WriteLine(NumPrimeArrangements(n));
        }

        private const int MOD = 1_000_000_007;
        static int NumPrimeArrangements(int n)
        {
            int primes = 0;
            for (int i = 2; i <= n; i++)
                if (CheckPrime(i))
                    primes++;
            long res = CalcFractorial(primes) * CalcFractorial(n - primes) % MOD;
            return (int) res;
        }

        static bool CheckPrime(int num)
        {
            for (int i = 2; i <= Math.Sqrt(num); i++)
                if (num % i == 0)
                    return false;
            return true;
        }

        static long CalcFractorial(int num)
        {
            long res = 1;
            for (int i = 2; i <= num; i++)
                res = (res * i) % MOD;
            return res;
        }
    }
}
