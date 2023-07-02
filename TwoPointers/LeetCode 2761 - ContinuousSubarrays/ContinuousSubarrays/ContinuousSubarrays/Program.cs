using System;
using System.Collections.Generic;
using System.Linq;

namespace ContinuousSubarrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long ContinuousSubarrays(int[] nums)
        {
            int li = 0, hi = 0;
            long res = 0;
            var freq = new Dictionary<int, int>();
            while (hi < nums.Length)
            {
                if (!freq.ContainsKey(nums[hi]))
                    freq[nums[hi]] = 0;
                freq[nums[hi]]++;
                while (li < hi && freq.Max(x => x.Key) - freq.Min(x => x.Key) > 2)
                {
                    freq[nums[li]]--;
                    if (freq[nums[li]] == 0)
                        freq.Remove(nums[li]);
                    li++;
                }
                res += hi - li + 1;
                hi++;
            }
            return res;
        }
    }
}
