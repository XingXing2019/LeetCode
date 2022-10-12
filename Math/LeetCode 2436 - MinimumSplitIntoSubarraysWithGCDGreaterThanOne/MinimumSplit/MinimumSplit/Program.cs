using System;
using System.Reflection;

namespace MinimumSplit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 12, 3, 14 };
            Console.WriteLine(MinimumSplits(nums));
        }

        public static int MinimumSplits(int[] nums)
        {
            int res = 1, gcd = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                gcd = GCD(gcd, nums[i]);
                if (gcd == 1)
                {
                    res++;
                    gcd = nums[i];
                }
            }
            return res;
        }

        public static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
