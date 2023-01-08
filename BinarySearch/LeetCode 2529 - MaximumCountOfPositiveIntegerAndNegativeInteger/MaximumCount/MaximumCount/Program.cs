using System;

namespace MaximumCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaximumCount(int[] nums)
        {
            var neg = BinarySearch(nums, true);
            var pos = nums.Length - BinarySearch(nums, false);
            return Math.Max(neg, pos);
        }

        public int BinarySearch(int[] nums, bool isFirst)
        {
            int li = 0, hi = nums.Length - 1;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (isFirst && nums[mid] >= 0 || !isFirst && nums[mid] > 0)
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            return li;
        }
    }
}
