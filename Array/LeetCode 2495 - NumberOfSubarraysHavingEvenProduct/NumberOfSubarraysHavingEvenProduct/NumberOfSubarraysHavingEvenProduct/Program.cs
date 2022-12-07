using System;

namespace NumberOfSubarraysHavingEvenProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 9, 6, 7, 13 };
            Console.WriteLine(EvenProduct(nums));
        }
        public static long EvenProduct(int[] nums)
        {
            long res = 0, lastEven = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                res += nums[i] % 2 == 0 ? i + 1 : lastEven + 1;
                lastEven = nums[i] % 2 == 0 ? i : lastEven;
            }
            return res;
        }
    }
}
