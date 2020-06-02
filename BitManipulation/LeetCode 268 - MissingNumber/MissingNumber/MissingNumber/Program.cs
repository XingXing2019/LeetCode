using System;

namespace MissingNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 0, 1 };
            Console.WriteLine(MissingNumber(nums));
        }
        static int MissingNumber(int[] nums)
        {
            int res = 0;
            int[] record = new int[nums.Length + 1];
            foreach (var num in nums)
                record[num]++;
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == 0)
                    res = i;
            }
            return res;
        }
        static int MissingNumber2(int[] nums)
        {
            int expectedSum = nums.Length * (nums.Length + 1) / 2;
            foreach (var num in nums)
                expectedSum -= num;
            return expectedSum;
        }
    }
}
