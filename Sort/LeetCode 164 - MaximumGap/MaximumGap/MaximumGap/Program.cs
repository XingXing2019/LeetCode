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
            var max = nums.Max();
            var buckets = new int[max + 1];
            foreach (var num in nums)
                buckets[num]++;
            int prev = -1, res = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] == 0) 
                    continue;
                if (prev != -1)
                    res = Math.Max(res, i - prev);
                prev = i;
            }
            return res;
        }
    }
}
