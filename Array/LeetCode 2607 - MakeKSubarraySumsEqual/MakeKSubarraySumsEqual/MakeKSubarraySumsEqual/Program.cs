using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeKSubarraySumsEqual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 3, 8 };
            var k = 3;
            Console.WriteLine(MakeSubKSumEqual(arr, k));
        }

        public static long MakeSubKSumEqual(int[] arr, int k)
        {
            var visited = new HashSet<int>();
            var groups = new List<HashSet<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (visited.Contains(i)) continue;
                var group = new HashSet<int>();
                var index = i;
                while (group.Add(index))
                {
                    index = (index + k) % arr.Length;
                }
                visited.UnionWith(group);
                groups.Add(group);
            }
            long res = 0;
            foreach (var group in groups)
                res += GetOperations(arr, group);
            return res;
        }

        public static long GetOperations(int[] arr, HashSet<int> indexes)
        {
            var nums = indexes.Select(x => arr[x]).OrderBy(x => x).ToArray();
            var median = nums[nums.Length / 2];
            return nums.Sum(x => Math.Abs(x - median));
        }
    }
}
