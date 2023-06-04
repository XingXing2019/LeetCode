using System;

namespace SemiOrderedPermutation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int SemiOrderedPermutation(int[] nums)
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
