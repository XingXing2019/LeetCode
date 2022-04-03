using System;
using System.Linq;

namespace MaximumCandiesAllocatedToKChildren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaximumCandies(int[] candies, long k)
        {
            long li = 0, hi = candies.Max();
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                var count = Count(candies, mid);
                if (count >= k)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return Math.Max(0, (int) hi);
        }

        public long Count(int[] candies, long target)
        {
            if (target == 0) return long.MaxValue;
            long res = 0;
            foreach (var candy in candies)
                res += candy / target;
            return res;
        }
    }
}
