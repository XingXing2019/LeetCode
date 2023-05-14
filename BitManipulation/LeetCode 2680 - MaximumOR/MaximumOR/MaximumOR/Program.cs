using System;

namespace MaximumOR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 8, 1, 2 };
            var k = 2;
            Console.WriteLine(MaximumOr(nums, k));
        }

        public static long MaximumOr(int[] nums, int k)
        {
            var digits = new int[32];
            var ors = new long[nums.Length];
            long res = 0;
            for (int i = 0; i < 32; i++)
            {
                var count = 0;
                foreach (var num in nums)
                    count += (num >> i) & 1;
                digits[i] = count;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                var num = 0;
                for (int j = 0; j < 32; j++)
                {
                    if (digits[j] - ((nums[i] >> j) & 1) > 0)
                        num += 1 << j;
                }
                ors[i] = num;
            }
            for (int i = 0; i < nums.Length; i++)
                res = Math.Max(res, ors[i] | (long)nums[i] << k);
            return res;
        }
    }
}
