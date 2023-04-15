using System;

namespace FindTheScoreOfAllPrefixesOfAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long[] FindPrefixScore(int[] nums)
        {
            var res = new long[nums.Length];
            var max = 0L;
            for (int i = 0; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i]);
                res[i] = i == 0 ? max + nums[i] : res[i - 1] + max + nums[i];
            }
            return res;
        }
    }
}
