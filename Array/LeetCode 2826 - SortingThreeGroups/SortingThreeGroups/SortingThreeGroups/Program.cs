using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingThreeGroups
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int> { 1, 1, 2, 1, 1 };
            Console.WriteLine(MinimumOperations(nums));
        }

        public static int MinimumOperations(IList<int> nums)
        {
            var res = int.MaxValue;
            for (int i = 0; i <= nums.Count; i++)
            {
                for (int j = i; j <= nums.Count; j++)
                {
                    res = Math.Min(res, GetOperations(nums, i, j));
                }
            }
            return res;
        }

        public static int GetOperations(IList<int> nums, int i, int j)
        {
            var copy = new int[nums.Count];
            for (int k = 0; k < nums.Count; k++)
            {
                if (k < i)
                    copy[k] = 1;
                else if (k < j)
                    copy[k] = 2;
                else
                    copy[k] = 3;
            }
            var res = 0;
            for (int k = 0; k < nums.Count; k++)
            {
                if (nums[k] == copy[k]) continue;
                res++;
            }
            return res;
        }
    }
}
