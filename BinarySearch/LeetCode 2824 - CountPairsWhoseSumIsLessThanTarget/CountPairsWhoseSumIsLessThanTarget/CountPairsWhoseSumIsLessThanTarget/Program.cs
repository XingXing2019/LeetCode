using System;
using System.Collections.Generic;
using System.Linq;

namespace CountPairsWhoseSumIsLessThanTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int> { -6, 2, 5, -2, -7, -1, 3 };
            var target = -2;
            Console.WriteLine(CountPairs(nums, target));
        }

        public static int CountPairs(IList<int> nums, int target)
        {
            nums = nums.OrderBy(x => x).ToList();
            var res = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                var index = BinarySearch(nums, target - nums[i] - 1);
                res += Math.Max(0, index - i);
            }
            return res;
        }

        public static int BinarySearch(IList<int> nums, int target)
        {
            int li = 0, hi = nums.Count - 1;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (nums[mid] > target)
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            return hi;
        }
    }
}
