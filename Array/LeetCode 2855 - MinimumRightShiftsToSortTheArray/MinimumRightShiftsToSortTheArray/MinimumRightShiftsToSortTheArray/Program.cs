using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumRightShiftsToSortTheArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int> { 3, 4, 5, 1, 2 };
            Console.WriteLine(MinimumRightShifts(nums));
        }

        public static int MinimumRightShifts(IList<int> nums)
        {
            var index = nums.IndexOf(nums.Min());
            var newNums = nums.Skip(index).Concat(nums.Take(index)).ToList();
            for (int i = 1; i < newNums.Count; i++)
            {
                if (newNums[i] < newNums[i - 1])
                    return -1;
            }
            return (nums.Count - index) % nums.Count;
        }
    }
}
