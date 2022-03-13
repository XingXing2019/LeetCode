using System;
using System.Collections.Generic;
using System.Linq;

namespace FindAllKDistantIndicesInAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 4, 9, 1, 3, 9, 5 };
            int key = 9, k = 1;
            Console.WriteLine(FindKDistantIndices(nums, key, k));
        }

        public static IList<int> FindKDistantIndices(int[] nums, int key, int k)
        {
            var indexes = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != key) continue;
                indexes.Add(i);
            }
            var res = new List<int>();
            if (indexes.Count == 0) return res;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == key)
                    res.Add(i);
                else
                {
                    var index = indexes.BinarySearch(i);
                    if (index < 0) index = ~index;
                    if (index == 0 && indexes[0] - i <= k)
                        res.Add(i);
                    else if (index == indexes.Count && i - indexes[^1] <= k)
                        res.Add(i);
                    else if (index != 0 && index != indexes.Count && (i - indexes[index - 1] <= k || indexes[index] - i <= k))
                        res.Add(i);
                }
            }
            return res;
        }
    }
}
