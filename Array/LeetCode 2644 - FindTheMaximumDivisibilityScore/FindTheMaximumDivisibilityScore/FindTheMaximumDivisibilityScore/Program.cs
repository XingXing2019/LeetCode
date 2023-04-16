using System;
using System.Linq;

namespace FindTheMaximumDivisibilityScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaxDivScore(int[] nums, int[] divisors)
        {
            int res = 0, max = -1;
            foreach (var divisor in divisors)
            {
                var count = nums.Count(x => x % divisor == 0);
                if (count < max) continue;
                res = count > max ? divisor : Math.Min(res, divisor);
                max = count;
            }
            return res;
        }
    }
}
