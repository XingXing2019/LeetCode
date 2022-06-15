using System;

namespace FindKthSmallestPairDistance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 1, 3 };
            int k = 3;
            Console.WriteLine(SmallestDistancePair(nums, k));
        }

        public static int SmallestDistancePair(int[] nums, int k)
        {
            Array.Sort(nums);
            int li = 0, hi = nums[^1] - nums[0];
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                var count = Count(nums, mid);
                if (count < k)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return li;
        }

        public static int Count(int[] nums, int target)
        {
            int li = 0, hi = 0, res = 0;
            while (hi < nums.Length)
            {
                while (li < hi && nums[hi] - nums[li] > target)
                    li++;
                res += hi - li;
                hi++;
            }
            return res;
        }
    }
}
