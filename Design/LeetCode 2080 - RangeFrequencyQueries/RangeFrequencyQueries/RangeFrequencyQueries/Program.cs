using System;
using System.Collections.Generic;

namespace RangeFrequencyQueries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rfq = new RangeFreqQuery(new[] { 12, 33, 4, 56, 22, 2, 34, 33, 22, 12, 34, 56 });
            Console.WriteLine(rfq.Query(1, 2, 4));
            Console.WriteLine(rfq.Query(0, 11, 33));
        }
    }

    public class RangeFreqQuery
    {
        private Dictionary<int, List<int>> dict;
        public RangeFreqQuery(int[] arr)
        {
            dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                    dict[arr[i]] = new List<int>();
                dict[arr[i]].Add(i);
            }
        }

        public int Query(int left, int right, int value)
        {
            if (!dict.ContainsKey(value))
                return 0;
            var indexs = dict[value];
            var leftIndex = indexs.BinarySearch(left);
            leftIndex = leftIndex < 0 ? ~leftIndex - 1 : leftIndex - 1;
            var rightIndex = indexs.BinarySearch(right);
            rightIndex = rightIndex < 0 ? ~rightIndex : rightIndex + 1;
            return rightIndex - leftIndex - 1;
        }
    }

}
