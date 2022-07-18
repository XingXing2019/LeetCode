using System;
using System.Collections.Generic;
using System.Linq;

namespace QueryKthSmallestTrimmedNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        public static int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
        {
            var dict = new Dictionary<int, List<string[]>>();
            var res = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int rightmost = queries[i][1], index = queries[i][0];
                if (!dict.ContainsKey(rightmost))
                {
                    var temp = new List<string[]>();
                    for (int j = 0; j < nums.Length; j++)
                    {
                        var len = nums[j].Length;
                        temp.Add(new[] { nums[j].Substring(len - rightmost), j.ToString() });
                    }
                    temp = temp.OrderBy(x => x[0]).ThenBy(x => int.Parse(x[1])).ToList();
                    dict[rightmost] = temp;
                }
                res[i] = int.Parse(dict[rightmost][index - 1][1]);
            }
            return res;
        }
    }
}
