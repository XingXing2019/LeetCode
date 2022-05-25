using System;

namespace SmallestRangeII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 7, 2 };
            int k = 1;
            Console.WriteLine(SmallestRangeII(nums, k));
        }

        public static int SmallestRangeII(int[] nums, int k)
        {
            Array.Sort(nums);
            var res = nums[^1] - nums[0];
            int[] plus = new int[nums.Length], minus = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                plus[i] = nums[i] + k;
                minus[i] = nums[i] - k;
            }
            for (int i = 0; i < nums.Length - 1; i++)
            {
                var min = Math.Min(plus[0], minus[i + 1]);
                var max = Math.Max(plus[i], minus[^1]);
                res = Math.Min(res, Math.Abs(max - min));
            }
            return res;
        }
    }
}
