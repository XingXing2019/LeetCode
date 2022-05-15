using System;

namespace NumberOfWaysToSplitArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        public int WaysToSplitArray(int[] nums)
        {
            var prefix = new long[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
            var res = 0;
            for (int i = 0; i < prefix.Length - 1; i++)
            {
                if (prefix[i] < prefix[^1] - prefix[i]) continue;
                res++;
            }
            return res;
        }
    }
}
