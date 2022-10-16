using System;
using System.Linq;

namespace MinimizeMaximumOfArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 7, 1, 6 };
            Console.WriteLine(MinimizeArrayValue(nums));
        }

        public static int MinimizeArrayValue(int[] nums)
        {
            int li = 0, hi = nums.Max();
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                var temp = new long[nums.Length];
                Array.Copy(nums, temp, nums.Length);
                if (IsValid(temp, mid) > mid)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return li;
        }

        public static long IsValid(long[] nums, int target)
        {
            for (int i = nums.Length - 1; i >= 1; i--)
            {
                var diff = Math.Max(0, nums[i] - target);
                nums[i] -= diff;
                nums[i - 1] += diff;
            }
            return nums[0];
        }
    }
}
