using System;

namespace FindTriangularSumOfAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int TriangularSum(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            var newNums = new int[nums.Length - 1];
            for (int i = 0; i < newNums.Length; i++)
                newNums[i] = (nums[i] + nums[i + 1]) % 10;
            return TriangularSum(newNums);
        }
    }
}
