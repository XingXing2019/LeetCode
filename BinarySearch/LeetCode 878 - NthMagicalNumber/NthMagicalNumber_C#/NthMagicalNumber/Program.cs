using System;

namespace NthMagicalNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 4, a = 2, b = 3;
            Console.WriteLine(NthMagicalNumber(n, a, b));
        }

        public static int NthMagicalNumber(int n, int a, int b)
        {
            var lcm = a * b / GCD(a, b);
            long li = 0, hi = long.MaxValue, mod = 1_000_000_000 + 7;
            while (li < hi)
            {
                var mid = li + (hi - li) / 2;
                var count = mid / a + mid / b - mid / lcm;
                if (count >= n)
                    hi = mid;
                else
                    li = mid + 1;
            }
            return (int)(li % mod);
        }

        public static int GCD(int a, int b)
        {
            if (b == 0) return a;
            return GCD(b, a % b);
        }
    }
}
