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
                foreach (var num in nums)
                {
                    digits[i] += (num >> i) & 1;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                var or = 0;
                for (int j = 0; j < 32; j++)
                {
                    if (digits[j] - ((nums[i] >> j) & 1) < 1) continue;
                    or += 1 << j;
                }
                ors[i] = or;
            }
            for (int i = 0; i < nums.Length; i++)
                res = Math.Max(res, ors[i] | (long)nums[i] << k);
            return res;
        }
    }
}
