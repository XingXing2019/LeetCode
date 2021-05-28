using System;

namespace TotalHammingDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int TotalHammingDistance(int[] nums)
        {
            var res = 0;
            for (int i = 0; i < sizeof(int) * 8; i++)
            {
                int oneCount = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    oneCount += (nums[j] & 1);
                    nums[j] >>= 1;
                }
                res += oneCount * (nums.Length - oneCount);
            }
            return res;
        }
    }
}
