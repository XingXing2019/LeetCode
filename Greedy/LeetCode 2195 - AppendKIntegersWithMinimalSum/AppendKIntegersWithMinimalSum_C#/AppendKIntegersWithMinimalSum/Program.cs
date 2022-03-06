

using System;

namespace AppendKIntegersWithMinimalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 5, 6 };
            int k = 6;
            Console.WriteLine(MinimalKSum(nums, k));
        }
        public static long MinimalKSum(int[] nums, int k)
        {
            Array.Sort(nums);
            long total = k;
            var count = Math.Min(total, nums[0] - 1);
            var res = (1 + count) * count / 2;
            total -= count;
            for (int i = 1; i < nums.Length && total > 0; i++)
            {
                if (nums[i] == nums[i - 1]) continue;
                count = Math.Min(total, nums[i] - nums[i - 1] - 1);
                res += (nums[i - 1] + 1 + nums[i - 1] + count) * count / 2;
                total -= count;
            }
            res += (nums[^1] + 1 + nums[^1] + total) * total / 2;
            return res;
        }
    }
}
