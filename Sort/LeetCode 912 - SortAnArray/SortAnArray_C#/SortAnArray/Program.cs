using System;
using System.Collections.Generic;

namespace SortAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static IList<int> SortArray(int[] nums)
        {
            int[] res = new int[nums.Length];
            Array.Sort(nums);
            for (int i = 0; i < res.Length; i++)
                res[i] = nums[i];
            return res;
        }
    }
}
