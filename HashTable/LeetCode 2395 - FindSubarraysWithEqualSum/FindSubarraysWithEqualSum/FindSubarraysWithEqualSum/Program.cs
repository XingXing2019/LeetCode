using System;
using System.Collections.Generic;

namespace FindSubarraysWithEqualSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool FindSubarrays(int[] nums)
        {
            var sum = new HashSet<int>();
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (!sum.Add(nums[i] + nums[i + 1]))
                    return true;
            }
            return false;
        }
    }
}
