using System;

namespace LongestNiceSubarray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int LongestNiceSubarray(int[] nums)
        {
            var res = 0;
            int li = 0, hi = 0;
            while (hi < nums.Length)
            {
                while (li < hi && !IsValid(nums, li, hi))
                    li++;
                res = Math.Max(res, hi - li + 1);
                hi++;
            }
            return res;
        }

        public bool IsValid(int[] nums, int li, int hi)
        {
            for (int i = li; i <= hi; i++)
            {
                for (int j = i + 1; j <= hi; j++)
                {
                    if ((nums[i] & nums[j]) != 0)
                        return false;
                }
            }
            return true;
        }
    }
}
