using System;

namespace NonDecreasingArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 4, 2, 3 };
            Console.WriteLine(CheckPossibility(nums));
        }
        static bool CheckPossibility(int[] nums)
        {
            if (nums.Length == 1)
                return true;
            int count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    if (count != 0)
                    {
                        if (i == 1 || nums[i] >= nums[i - 2])
                            nums[i - 1] = nums[i];
                        else
                            nums[i] = nums[i - 1];
                        count--;
                    }                        
                    else
                        return false;
                }
            }
            return true;
        }
    }
}
