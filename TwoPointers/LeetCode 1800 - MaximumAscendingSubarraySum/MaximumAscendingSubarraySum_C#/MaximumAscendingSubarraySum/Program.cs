using System;

namespace MaximumAscendingSubarraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaxAscendingSum(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int sum = nums[0], res = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                    sum += nums[i];
                else
                {
                    res = Math.Max(res, sum);
                    sum = nums[i];
                }
            }
            res = Math.Max(res, sum);
            return res;
        }
    }
}
