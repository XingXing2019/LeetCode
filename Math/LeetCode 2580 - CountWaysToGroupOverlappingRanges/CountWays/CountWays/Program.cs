using System;
using System.Linq;

namespace CountWays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountWays(int[][] ranges)
        {
            ranges = ranges.OrderBy(x => x[0]).ToArray();
            long li = ranges[0][0], hi = ranges[0][1], n = 1, mod = 1_000_000_000 + 7;
            for (int i = 1; i < ranges.Length; i++)
            {
                if (li <= ranges[i][0] && ranges[i][0] <= hi)
                    hi = Math.Max(hi, ranges[i][1]);
                else
                {
                    n++;
                    li = ranges[i][0];
                    hi = ranges[i][1];
                }
            }
            var pow = Power(n, mod);
            return (int)(pow % mod);
        }

        private long Power(long n, long mod)
        {
            if (n == 0) return 1;
            var pow = Power(n / 2, mod) % mod;
            return n % 2 == 0 ? pow * pow : pow * pow * 2;
        }
    }
}
