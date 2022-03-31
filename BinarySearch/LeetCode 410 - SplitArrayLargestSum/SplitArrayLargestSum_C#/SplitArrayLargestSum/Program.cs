using System;
using System.Linq;

namespace SplitArrayLargestSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3 };
            int max = 3;
            Console.WriteLine(Count(nums, max));
        }
        public static int SplitArray(int[] nums, int m)
        {
            int li = nums.Min(), hi = nums.Sum();
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                var count = Count(nums, mid);
                if (count > m) li = mid + 1;
                else hi = mid - 1;
            }
            return li;
        }

        public static int Count(int[] nums, int max)
        {
            int res = 0, sum = 0;
            foreach (var num in nums)
            {
                if (max < num) return int.MaxValue;
                if (sum + num <= max)
                    sum += num;
                else
                {
                    res++;
                    sum = num;
                }
            }
            return res + 1;
        }
    }
}
