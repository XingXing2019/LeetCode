//int型数字一共32位，对每一位上的数字分别求和。因为除了res其他数字都出现了三次，那么每一个和对3取模就是res在这一位上的数字。
using System;

namespace SingleNumberII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 0, 1, 0, 1, 0, 1, int.MaxValue };
            Console.WriteLine(SingleNumber(nums));
        }
        static int SingleNumber(int[] nums)
        {
            int res = 0;
            for (int i = 0; i < 32; i++)
            {
                int sum = 0;
                foreach (var num in nums)
                    sum += num >> i & 1;
                res |= sum % 3 << i;
            }
            return res;
        }
    }
}
