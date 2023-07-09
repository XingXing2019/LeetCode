using System;

namespace LongestAlternatingSubarray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 3, 5, 3, 4 };
            Console.WriteLine(AlternatingSubarray(nums));
        }

        public static int AlternatingSubarray(int[] nums)
        {
            var res = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                var count = 1;
                var increase = true;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (increase && nums[j] - nums[j - 1] != 1 || !increase && nums[j - 1] - nums[j] != 1)
                        break;
                    count++;
                    increase = !increase;
                    res = Math.Max(res, count);
                }
            }
            return res;
        }
    }
}
