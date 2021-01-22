using System;
using System.Linq;

namespace HowManyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 8, 1, 2, 2, 3 };
            Console.WriteLine(SmallerNumbersThanCurrent(nums));
        }
        static int[] SmallerNumbersThanCurrent(int[] nums)
        {
            int max = nums.Max(n => n);
            var record = new int[max + 1];
            foreach (var num in nums)
                record[num]++;
            int[] smallerNums = new int[record.Length];
            for (int i = 1; i < smallerNums.Length; i++)
                smallerNums[i] = smallerNums[i - 1] + record[i - 1];
            for (int i = 0; i < nums.Length; i++)
                nums[i] = smallerNums[nums[i]];
            return nums;
        }
    }
}
