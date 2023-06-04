using System;

namespace MinimumCostToMakeAllCharactersEqual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 1, 4, 3 };
            Console.WriteLine(SemiOrderedPermutation(nums));
        }

        public static int SemiOrderedPermutation(int[] nums)
        {
            int one = 0, n = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                    one = i;
                else if (nums[i] == nums.Length)
                    n = i;
            }
            return one < n ? one + nums.Length - n - 1 : one + nums.Length - n - 2;
        }
    }
}
