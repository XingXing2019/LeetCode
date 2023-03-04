using System;

namespace CountSubarraysWithFixedBounds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 8, 1, 9, 1 };
            int minK = 1, maxK = 8;
            Console.WriteLine(CountSubarrays(nums, minK, maxK));
        }

        public static long CountSubarrays(int[] nums, int minK, int maxK)
        {
            long res = 0;
            int li = 0, hi = 0, lastMin = -1, lastMax = -1;
            while (hi < nums.Length)
            {
                if (minK <= nums[hi] && nums[hi] <= maxK)
                {
                    if (nums[hi] == minK)
                        lastMin = hi;
                    if (nums[hi] == maxK)
                        lastMax = hi;
                    if (lastMin != -1 && lastMax != -1)
                        res += Math.Min(lastMin, lastMax) - Math.Min(li, Math.Min(lastMin, lastMax)) + 1;
                }
                else
                {
                    li = hi + 1;
                    lastMin = -1;
                    lastMax = -1;
                }
                hi++;
            }
            return res;
        }
    }
}
