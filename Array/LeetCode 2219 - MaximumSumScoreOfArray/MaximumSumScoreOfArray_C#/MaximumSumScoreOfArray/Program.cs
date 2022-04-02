using System;

namespace MaximumSumScoreOfArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long MaximumSumScore(int[] nums)
        {
            var prefix = new long[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
            var res = long.MinValue;
            for (int i = 0; i < prefix.Length; i++)
            {
                var front = prefix[i];
                var after = i == 0 ? prefix[^1] : prefix[^1] - prefix[i - 1];
                res = Math.Max(res, Math.Max(front, after));
            }
            return res;
        }
    }
}
