using System;

namespace SumOfAbsoluteDifferences
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {2, 3, 5};
            Console.WriteLine(GetSumAbsoluteDifferences(nums));
        }
        static int[] GetSumAbsoluteDifferences(int[] nums)
        {
            var len = nums.Length;
            int[] prefix = new int[len], res = new int[len];
            for (int i = 0; i < len; i++)
                prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
            for (int i = 0; i < len; i++)
            {
                var before = i == 0 ? 0 : Math.Abs(prefix[i - 1] - nums[i] * i);
                var after = i == len - 1 ? 0 : Math.Abs(prefix[^1] - prefix[i] - nums[i] * (len - 1 - i));
                res[i] = before + after;
            }
            return res;
        }
    }
}
