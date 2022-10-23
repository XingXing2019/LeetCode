using System;

namespace NumberOfSubarraysWithGCDEqualToK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 9, 3, 1, 2, 6, 3 };
            var k = 3;
            Console.WriteLine(SubarrayGCD(nums, k));
        }

        public static int SubarrayGCD(int[] nums, int k)
        {
            var res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var gcd = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (gcd == k) res++;
                    if (gcd < k) break;
                    gcd = GCD(gcd, nums[j]);
                }
                if (gcd == k) res++;
            }
            return res;
        }

        public static int GCD(int num1, int num2)
        {
            return num2 == 0 ? num1 : GCD(num2, num1 % num2);
        }
    }
}
