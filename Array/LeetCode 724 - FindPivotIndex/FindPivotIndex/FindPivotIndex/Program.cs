using System;

namespace FindPivotIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int PivotIndex(int[] nums)
        {
            if (nums.Length == 0)
                return -1;
            int[] sums = new int[nums.Length + 1];
            sums[1] = nums[0];
            for (int i = 2; i < sums.Length; i++)
                sums[i] = sums[i - 1] + nums[i - 1];
            for (int i = 1; i < sums.Length; i++)
            {
                if (sums[i - 1] == sums[sums.Length - 1] - sums[i])
                    return i - 1;
            }
            return -1;
        }
    }
}
