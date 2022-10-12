using System;

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
            int index = 1, res = 1, gcd = nums[0];
            while (index < nums.Length)
            {
                gcd = GCD(gcd, nums[index]);
                if (gcd == 1)
                {
                    res++;
                    gcd = nums[index];
                }
                index++;
            }
            return res;
        }

        public static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
