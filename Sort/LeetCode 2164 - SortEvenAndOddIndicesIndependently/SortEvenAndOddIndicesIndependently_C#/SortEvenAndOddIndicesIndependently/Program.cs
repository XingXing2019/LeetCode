using System;
using System.Collections.Generic;

namespace SortEvenAndOddIndicesIndependently
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] SortEvenOdd(int[] nums)
        {
            var odd = new List<int>();
            var even = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                    even.Add(nums[i]);
                else
                    odd.Add(nums[i]);
            }
            even.Sort();
            odd.Sort((a, b) => b - a);
            int p1 = 0, p2 = 0;
            for (int i = 0; i < nums.Length; i++)
                nums[i] = i % 2 == 0 ? even[p1++] : odd[p2++];
            return nums;
        }
    }
}
