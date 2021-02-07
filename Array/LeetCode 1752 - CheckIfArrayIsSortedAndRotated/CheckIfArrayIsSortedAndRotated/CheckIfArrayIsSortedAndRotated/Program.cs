using System;

namespace CheckIfArrayIsSortedAndRotated
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool Check(int[] nums)
        {
            int count = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    count++;
                    if (count > 1) return false;
                }
            }
            return count == 0 || nums[0] >= nums[^1];
        }
    }
}
