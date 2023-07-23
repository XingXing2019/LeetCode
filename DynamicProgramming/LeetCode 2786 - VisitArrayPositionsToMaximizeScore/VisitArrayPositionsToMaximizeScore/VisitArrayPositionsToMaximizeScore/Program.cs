using System;

namespace VisitArrayPositionsToMaximizeScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 8, 50, 65 };
            var x = 74;
            Console.WriteLine(MaxScore(nums, x));
        }

        public static long MaxScore(int[] nums, int x)
        {
            long odd = nums[0] % 2 != 0 ? nums[0] : nums[0] - x;
            long even = nums[0] % 2 == 0 ? nums[0] : nums[0] - x;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                    even = Math.Max(even + nums[i], odd + nums[i] - x);
                else
                    odd = Math.Max(odd + nums[i], even + nums[i] - x);
            }
            return Math.Max(odd, even);
        }
    }
}
