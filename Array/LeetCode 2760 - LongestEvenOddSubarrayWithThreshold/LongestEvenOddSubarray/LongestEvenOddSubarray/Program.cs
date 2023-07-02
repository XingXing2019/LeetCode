using System;

namespace LongestEvenOddSubarray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int LongestAlternatingSubarray(int[] nums, int threshold)
        {
            var res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 != 0 || nums[i] > threshold) continue;
                var index = i;
                while (index < nums.Length && nums[index] <= threshold)
                {
                    if (index != i && nums[index] % 2 == nums[index - 1] % 2)
                        break;
                    index++;
                }
                res = Math.Max(res, index - i);
            }
            return res;
        }
    }
}
