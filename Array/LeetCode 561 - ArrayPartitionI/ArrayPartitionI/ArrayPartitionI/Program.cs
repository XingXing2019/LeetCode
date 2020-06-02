//尽量把差距小的数排在一起，这样才能不浪费大的数字。
//先将nums排序，然后从第一位开始，隔位相加。
using System;

namespace ArrayPartitionI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int ArrayPairSum(int[] nums)
        {
            int maxSum = 0;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i += 2)
                maxSum += nums[i];
            return maxSum;
        }
    }
}
