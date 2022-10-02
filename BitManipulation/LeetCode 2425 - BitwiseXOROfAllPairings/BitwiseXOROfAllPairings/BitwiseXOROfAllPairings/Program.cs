using System;
using System.Collections.Generic;
using System.Linq;

namespace BitwiseXOROfAllPairings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int XorAllNums(int[] nums1, int[] nums2)
        {
            if (nums1.Length % 2 == 0 && nums2.Length % 2 == 0)
                return 0;
            if (nums1.Length % 2 != 0 && nums2.Length % 2 == 0)
                return Xor(nums2);
            if (nums1.Length % 2 == 0 && nums2.Length % 2 != 0)
                return Xor(nums1);
            var freq = nums1.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            foreach (var num in nums2)
            {
                if (!freq.ContainsKey(num))
                    freq[num] = 0;
                freq[num]++;
            }
            return Xor(freq.Where(x => x.Value % 2 != 0).Select(x => x.Key));
        }

        public int Xor(IEnumerable<int> nums)
        {
            var res = 0;
            foreach (var num in nums)
                res ^= num;
            return res;
        }
    }
}
