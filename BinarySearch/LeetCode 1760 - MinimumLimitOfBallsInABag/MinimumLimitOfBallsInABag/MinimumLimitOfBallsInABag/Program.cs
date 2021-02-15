using System;
using System.Linq;

namespace MinimumLimitOfBallsInABag
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1};
            int maxOperations = 1;
            Console.WriteLine(MinimumSize(nums, maxOperations));
        }
        public static int MinimumSize(int[] nums, int maxOperations)
        {
            int maxSize = nums.Length + maxOperations;
            int li = 1, hi = nums.Max();
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                int size = 0;
                foreach (var num in nums)
                {
                    if (num >= mid)
                        size += num % mid == 0 ? num / mid : num / mid + 1;
                    else
                        size++;
                }
                if (size > maxSize) li = mid + 1;
                else hi = mid;
            }
            return hi;
        }
    }
}
