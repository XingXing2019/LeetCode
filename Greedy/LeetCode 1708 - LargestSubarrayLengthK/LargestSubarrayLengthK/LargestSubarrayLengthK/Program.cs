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

        public int[] LargestSubarray_Loop(int[] nums, int k)
        {
            int max = 0, index = 0;
            for (int i = 0; i <= nums.Length - k; i++)
            {
                if (nums[i] > max)
                {
                    index = i;
                    max = nums[i];
                }
            }
            return nums[index..(index + k)];
        }
    }
}
