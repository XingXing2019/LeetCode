using System;

namespace MaximumBeauty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaximumBeauty(int[] nums, int k)
        {
            Array.Sort(nums);
            int li = 0, hi = 0, res = 0;
            while (hi < nums.Length)
            {
                while (li < hi && nums[li] + 2 * k < nums[hi])
                    li++;
                res = Math.Max(res, hi - li + 1);
                hi++;
            }
            return res;
        }
    }
}
