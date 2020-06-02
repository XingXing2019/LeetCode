//方法2会比方法1快很多。
using System;
using System.Collections.Generic;
using System.Linq;

namespace DegreeOfAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 2, 3, 1 };
            Console.WriteLine(FindShortestSubArray2(nums));
        }
        static int FindShortestSubArray1(int[] nums)
        {
            var record = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!record.ContainsKey(nums[i]))
                    record[nums[i]] = 1;
                else
                    record[nums[i]]++;
            }
            int degree = record.Max(r => r.Value);
            var dict = new Dictionary<int, int>();
            int li = 0, hi = 0;
            int res = int.MaxValue;
            while (hi < nums.Length)
            {
                if (!dict.ContainsKey(nums[hi]))
                    dict[nums[hi]] = 1;
                else
                    dict[nums[hi]]++;
                if (dict.ContainsValue(degree))
                {
                    while (dict.ContainsValue(degree))
                    {
                        dict[nums[li]]--;
                        li++;
                    }
                    res = Math.Min(res, hi - li + 2);
                }
                hi++;
            }
            return res;
        }
        static int FindShortestSubArray2(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                    dict[nums[i]] = 1;
                else
                    dict[nums[i]]++;
            }
            int degree = dict.Max(r => r.Value);
            List<int>[] record = new List<int>[50001];
            int res = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if(record[nums[i]] == null)
                    record[nums[i]] = new List<int>(){i};
                else
                    record[nums[i]].Add(i);
                if (record[nums[i]].Count == degree)
                {
                    int len = record[nums[i]].Count;
                    res = Math.Min(res, record[nums[i]][len - 1] - record[nums[i]][0] + 1);
                }
            }
            return res;
        }
    }
}
