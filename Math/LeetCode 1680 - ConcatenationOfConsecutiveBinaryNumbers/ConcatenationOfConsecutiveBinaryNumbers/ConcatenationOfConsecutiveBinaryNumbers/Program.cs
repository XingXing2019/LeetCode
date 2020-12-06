using System;

namespace ConcatenationOfConsecutiveBinaryNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 12;
            Console.WriteLine(ConcatenatedBinary(n));
        }
        static int ConcatenatedBinary(int n)
        {
            var MOD = 1_000_000_000 + 7;
            long res = 0, pow = 1;
            for (int i = 1; i <= n; i++)
            {
                if (i == pow)
                    pow <<= 1;
                res = (res * pow + i) % MOD;
            }
            return (int) res;
        }
    }
}
