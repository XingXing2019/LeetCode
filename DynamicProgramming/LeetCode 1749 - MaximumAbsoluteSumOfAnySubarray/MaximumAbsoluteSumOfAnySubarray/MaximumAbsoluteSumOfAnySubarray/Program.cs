using System;

namespace MaximumAbsoluteSumOfAnySubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, -3, 2, 3, -4};
            Console.WriteLine(MaxAbsoluteSum(nums));
        }
        
        static int MaxAbsoluteSum(int[] nums)
        {
            int[] min = new int[nums.Length], max = new int[nums.Length];
            min[0] = Math.Min(0, nums[0]);
            max[0] = Math.Max(0, nums[0]);
            int res = Math.Max(Math.Abs(min[0]), Math.Abs(max[0]));
            for (int i = 1; i < nums.Length; i++)
            {
                min[i] = Math.Min(nums[i], min[i - 1] + nums[i]);
                max[i] = Math.Max(nums[i], max[i - 1] + nums[i]);
                res = Math.Max(res, Math.Max(Math.Abs(min[i]), Math.Abs(max[i])));
            }
            return res;
        }
    }
}
