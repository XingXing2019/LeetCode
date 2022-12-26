
using System;

namespace MinimizeTheMaximumOfTwoArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int divisor1 = 2, divisor2 = 4, uniqueCnt1 = 8, uniqueCnt2 = 2;
            Console.WriteLine(MinimizeSet(divisor1, divisor2, uniqueCnt1, uniqueCnt2));
        }

        public static int MinimizeSet(int divisor1, int divisor2, int uniqueCnt1, int uniqueCnt2)
        {
            long li = 1, hi = int.MaxValue, lcm = (long)divisor1 * divisor2 / GCD(divisor1, divisor2);
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                var nonDivisible1 = mid - mid / divisor1;
                var nonDivisible2 = mid - mid / divisor2;
                var nonDivisibleBoth = mid - mid / lcm;
                if (nonDivisible1 < uniqueCnt1 || nonDivisible2 < uniqueCnt2 || nonDivisibleBoth < uniqueCnt1 + uniqueCnt2)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return (int)li;
        }

        public static int GCD(int x, int y)
        {
            if (y == 0) return x;
            return GCD(y, x % y);
        }
    }
}
