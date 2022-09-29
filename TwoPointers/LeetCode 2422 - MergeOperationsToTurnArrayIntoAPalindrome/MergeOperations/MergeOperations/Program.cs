using System;

namespace MergeOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinimumOperations(int[] nums)
        {
            int li = 0, hi = nums.Length - 1, res = 0;
            int left = nums[li], right = nums[hi];
            while (li < hi)
            {
                if (left == right)
                {
                    left += nums[++li];
                    right += nums[--hi];
                    continue;
                }
                if (left < right)
                    left += nums[++li];
                else
                    right += nums[--hi];
                res++;
            }
            return res;
        }
    }
}
