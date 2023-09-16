using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumArrayLengthAfterPairRemovals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int> { 1, 3, 4, 9 };
            Console.WriteLine(MinLengthAfterRemovals(nums));
        }

        public static int MinLengthAfterRemovals(IList<int> nums)
        {
            int li = 0, hi = nums.Count;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (CanRemove(nums, mid))
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return nums.Count - hi * 2;
        }

        public static bool CanRemove(IList<int> nums, int k)
        {
            if (nums.Count < 2 * k)
                return false;
            for (int i = 0; i < k; i++)
            {
                if (nums[i] < nums[^(k - i)]) continue;
                return false;
            }
            return true;
        }
    }
}
