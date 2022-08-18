using System;
using System.Collections.Generic;
using System.Linq;

namespace WillisTowersWatson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 1, 1, 2, 2, 2, 3, 3, 3 };
            Console.WriteLine(MaxEqualFreq(nums));
        }

        public static int MaxEqualFreq(int[] nums)
        {
            var freq = new Dictionary<int, int>();
            var freqDict = new Dictionary<int, HashSet<int>>();
            var res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!freq.ContainsKey(nums[i]))
                    freq[nums[i]] = 0;
                var numFreq = freq[nums[i]];
                if (numFreq != 0)
                {
                    freqDict[numFreq].Remove(nums[i]);
                    if (freqDict[numFreq].Count == 0)
                        freqDict.Remove(numFreq);
                }
                if (!freqDict.ContainsKey(numFreq + 1))
                    freqDict[numFreq + 1] = new HashSet<int>();
                freqDict[numFreq + 1].Add(nums[i]);
                freq[nums[i]]++;
                if (freqDict.Count == 2)
                {
                    var min = freqDict.Min(x => x.Key);
                    var max = freqDict.Max(x => x.Key);
                    if (min == 1 && freqDict[min].Count == 1)
                        res = i + 1;
                    else if (max == min + 1 && (freqDict[min].Count == 1 && min == 1 || freqDict[max].Count == 1))
                        res = i + 1;
                }
                else if (freqDict.Count == 1 && (freqDict.Min(x => x.Key) == 1 || freqDict.First().Value.Count == 1))
                    res = i + 1;
            }
            return res;
        }
    }
}