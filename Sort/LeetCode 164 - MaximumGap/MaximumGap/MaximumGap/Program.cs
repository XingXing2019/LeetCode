using System;
using System.Linq;

namespace MaximumGap
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 6, 9, 1, };
            Console.WriteLine(MaximumGap_N(nums));
        }
        public int MaximumGap_NLogN(int[] nums)
        {
            if (nums.Length < 2) return 0;
            Array.Sort(nums);
            int res = 0;
            for (int i = 1; i < nums.Length; i++)
                res = Math.Max(res, nums[i] - nums[i - 1]);
            return res;
        }

        public static int MaximumGap_N(int[] nums)
        {
            if (nums.Length < 2) return 0;
            int min = int.MaxValue, max = int.MinValue, len = nums.Length;
            foreach (var num in nums)
            {
                min = Math.Min(min, num);
                max = Math.Max(max, num);
            }
            var gap = (int)Math.Ceiling((double)(max - min) / (len - 1));
            var minBucket = new int[len - 1];
            var maxBucket = new int[len - 1];
            Array.Fill(minBucket, int.MaxValue);
            Array.Fill(maxBucket, int.MinValue);
            foreach (var num in nums)
            {
                if (num == min || num == max) continue;
                var index = (num - min) / gap;
                minBucket[index] = Math.Min(minBucket[index], num);
                maxBucket[index] = Math.Max(maxBucket[index], num);
            }
            int res = 0, prev = min;
            for (int i = 0; i < len - 1; i++)
            {
                if (minBucket[i] == int.MaxValue && maxBucket[i] == int.MinValue)
                    continue;
                res = Math.Max(res, minBucket[i] - prev);
                prev = maxBucket[i];
            }
            return Math.Max(res, max - prev);
        }
    }
}
