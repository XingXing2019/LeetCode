using System;
using System.Collections.Generic;

namespace IntervalsBetweenIdenticalElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static long[] GetDistances(int[] arr)
        {
            var positions = new Dictionary<int, List<long>>();
            var dict = new Dictionary<int, List<long>>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                {
                    positions[arr[i]] = new List<long>();
                    dict[arr[i]] = new List<long>();
                }
                positions[arr[i]].Add(i);
                dict[arr[i]].Add(i);
            }
            foreach (var list in dict.Values)
            {
                for (int i = 1; i < list.Count; i++)
                    list[i] += list[i - 1];
            }
            var res = new long[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                var list = dict[arr[i]];
                var index = positions[arr[i]].BinarySearch(i);
                var smaller = index == 0 ? 0 : list[index - 1] - (long)index * i;
                var larger = list[^1] - list[index] - (long)(list.Count - index - 1) * i;
                res[i] = Math.Abs(smaller) + Math.Abs(larger);
            }
            return res;
        }
    }
}
