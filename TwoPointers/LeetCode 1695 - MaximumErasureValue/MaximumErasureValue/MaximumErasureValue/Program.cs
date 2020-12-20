using System;
using System.Collections.Generic;

namespace MaximumErasureValue
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1 };
            Console.WriteLine(MaximumUniqueSubarray(nums));
        }
        static int MaximumUniqueSubarray(int[] nums)
        {
            int li = 0, hi = 0, max = 0, sum = 0;
            var set = new HashSet<int>();
            while (hi < nums.Length)
            {
                if (set.Contains(nums[hi]))
                {
                    while (set.Contains(nums[hi]))
                    {
                        set.Remove(nums[li]);
                        sum -= nums[li++];
                    }
                }
                sum += nums[hi];
                set.Add(nums[hi++]);
                max = Math.Max(max, sum);
            }
            return max;
        }
    }
}
