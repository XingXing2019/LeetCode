using System;

namespace MaxConsecutiveOnesII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1};
            Console.WriteLine(FindMaxConsecutiveOnes(nums));
        }
        static int FindMaxConsecutiveOnes(int[] nums)
        {
            int li = 0, hi = 0, chance = 1, pos = 0;
            int max = int.MinValue;
            while (hi < nums.Length)
            {
                if (nums[hi] == 1)
                    hi++;
                else
                {
                    if (chance == 1)
                    {
                        chance--;
                        hi++;
                        pos = hi;
                    }
                    else
                    {
                        max = Math.Max(max, hi - li);
                        chance = 1;
                        li = pos;
                    }
                }
            }
            max = Math.Max(max, hi - li);
            return max;
        }
    }
}
