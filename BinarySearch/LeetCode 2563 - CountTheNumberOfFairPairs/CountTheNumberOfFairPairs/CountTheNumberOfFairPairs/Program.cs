using System;

namespace CountTheNumberOfFairPairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 0, 1, 7, 4, 4, 5 };
            int lower = 3, upper = 6;
            Console.WriteLine(CountFairPairs(nums, lower, upper));
        }

        public static long CountFairPairs(int[] nums, int lower, int upper)
        {
            Array.Sort(nums);
            long res = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                var li = BinarySearch(nums, i + 1, lower - nums[i], true);
                var hi = BinarySearch(nums, i + 1, upper - nums[i], false);
                if (li > hi) continue;
                res += hi - li + 1;
            }

            return res;
        }

        public static int BinarySearch(int[] nums, int start, int target, bool findFirst)
        {
            int li = start, hi = nums.Length - 1;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (findFirst)
                {
                    if (nums[mid] >= target)
                        hi = mid - 1;
                    else
                        li = mid + 1;
                }
                else
                {
                    if (nums[mid] <= target)
                        li = mid + 1;
                    else
                        hi = mid - 1;
                }
            }
            return findFirst ? li : hi;
        }
    }
}
