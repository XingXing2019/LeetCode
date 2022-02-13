using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums =
            {
                3, 1, 3, 2, 4, 3 

            };
            Console.WriteLine(MinimumOperations(nums));
        }
        public static int MinimumOperations(int[] nums)
        {
            if (nums.Length == 1) return 0;
            var evenDict = nums.Where((x, i) => i % 2 == 0).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var oddDict = nums.Where((x, i) => i % 2 != 0).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            int[] oddMax = { -1, -1 }, oddSecMax = { -1, -1 };
            int[] evenMax = { -1, -1 }, evenSecMax = { -1, -1 };
            GetMax(oddDict, oddMax, oddSecMax);
            GetMax(evenDict, evenMax, evenSecMax);
            if (oddMax[1] != evenMax[1])
                return nums.Length - oddMax[0] - evenMax[0];
            if (oddSecMax[0] == -1 && evenSecMax[0] != -1)
                return nums.Length - oddMax[0] - evenSecMax[0];
            if (oddSecMax[0] != -1 && evenSecMax[0] == -1)
                return nums.Length - oddSecMax[0] - evenMax[0];
            if (oddSecMax[0] == -1 && evenSecMax[0] == -1)
                return Math.Min(nums.Length - oddMax[0], nums.Length - evenMax[0]);
            return Math.Min(nums.Length - oddMax[0] - evenSecMax[0], nums.Length - oddSecMax[0] - evenMax[0]);
        }

        private static void GetMax(Dictionary<int, int> dict, int[] max, int[] secMax)
        {
            foreach (var key in dict.Keys)
            {
                if (dict[key] > max[0])
                {
                    secMax[0] = max[0];
                    secMax[1] = max[1];
                    max[0] = dict[key];
                    max[1] = key;
                }
                else if (dict[key] > secMax[0])
                {
                    secMax[0] = dict[key];
                    secMax[1] = key;
                }
            }
        }
    }
}
