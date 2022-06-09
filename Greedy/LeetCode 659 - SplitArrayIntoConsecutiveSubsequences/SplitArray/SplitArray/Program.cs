using System;
using System.Collections.Generic;
using System.Linq;

namespace SplitArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 3, 4, 4, 5, 5 };
            Console.WriteLine(IsPossible(nums));
        }

        public static bool IsPossible(int[] nums)
        {
            var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var seq = new Dictionary<int, int>();
            foreach (var num in freq.Keys)
            {
                if (freq[num] == 0) continue;
                if (seq.ContainsKey(num - 1))
                {
                    var min = Math.Min(seq[num - 1], freq[num]);
                    seq[num - 1] -= min;
                    freq[num] -= min;
                    seq[num] = seq.GetValueOrDefault(num, 0) + min;
                }
                if (freq[num] == 0) continue;
                if (freq.GetValueOrDefault(num + 1, 0) < freq[num] || freq.GetValueOrDefault(num + 2, 0) < freq[num])
                    return false;
                seq[num + 2] = seq.GetValueOrDefault(num + 2, 0) + freq[num];
                freq[num + 1] -= freq[num];
                freq[num + 2] -= freq[num];
                freq[num] = 0;
            }
            return freq.All(x => x.Value == 0);
        }
    }
}
