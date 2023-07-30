using System;
using System.Collections.Generic;

namespace CountCompleteSubarraysInAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountCompleteSubarrays(int[] nums)
        {
            var unique = new HashSet<int>(nums).Count;
            var res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var set = new HashSet<int>();
                for (int j = i; j < nums.Length && set.Count <= unique; j++)
                {
                    set.Add(nums[j]);
                    if (set.Count != unique)
                        continue;
                    res++;
                }
            }
            return res;
        }
    }
}
