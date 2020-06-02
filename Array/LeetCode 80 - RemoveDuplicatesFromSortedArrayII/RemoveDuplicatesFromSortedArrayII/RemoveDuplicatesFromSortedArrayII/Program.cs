using System;

namespace RemoveDuplicatesFromSortedArrayII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 1, 1, 1, 2, 2, 2, 2, 3 };
            Console.WriteLine(RemoveDuplicates(nums));
        }
        static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int li = 0, hi = 1, count = 1;
            while (hi < nums.Length)
            {
                if (nums[li] == nums[hi] && count == 0)
                    hi++;
                else
                {
                    if (nums[li] == nums[hi])
                        count--;
                    else
                        count = 1;
                    nums[++li] = nums[hi++];
                }
            }
            return li + 1;
        }
    }
}
