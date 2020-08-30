using System;

namespace MaximumLengthOfSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int GetMaxLen(int[] nums)
        {
            int evenNegPos = -1, oddNegPos = nums.Length;
            int countNeg = 0, res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    evenNegPos = i;
                    oddNegPos = nums.Length;
                    countNeg = 0;
                }
                else
                {
                    countNeg += nums[i] < 0 ? 1 : 0;
                    if (countNeg % 2 == 0)
                        res = Math.Max(res, i - evenNegPos);
                    else
                    {
                        oddNegPos = Math.Min(oddNegPos, i);
                        res = Math.Max(res, i - oddNegPos);
                    }
                }
            }
            return res;
        }
    }
}
