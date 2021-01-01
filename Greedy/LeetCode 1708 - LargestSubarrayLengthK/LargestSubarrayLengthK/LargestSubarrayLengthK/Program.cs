using System;
using System.Linq;

namespace LargestSubarrayLengthK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int[] LargestSubarray(int[] nums, int k)
        {
            var index = Array.IndexOf(nums, nums[..(nums.Length - k + 1)].Max());
            return nums[index..(index + k)];
        }
    }
}
