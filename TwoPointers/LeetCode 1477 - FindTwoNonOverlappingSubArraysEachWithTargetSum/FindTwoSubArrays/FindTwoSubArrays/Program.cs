//两种做法用滑窗或者前序和，原理都是找到所有能达到target的set。
//关键在于找到set后如何确保不重合。可以用一个数组minLen记录在每个数字之前最小的set长度。初始值都设为无穷大。
//每次找到set后都检查一下，当前set左端点之间有没有找到最小长度(这样可以确保set不会重合)，如果不为无穷大，证明找到了最小长度，则更新res为len加上当前set左边找到的最小长度。
using System;
using System.Collections.Generic;

namespace FindTwoSubArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 64, 5, 20, 9, 1, 39 };
            int target = 69;
            Console.WriteLine(MinSumOfLengths_PrefixSum(arr, target));
        }
        static int MinSumOfLengths_SlidingWindow(int[] arr, int target)
        {
            int infinity = int.MaxValue / 2;
            int start = 0;
            int sum = 0, res = infinity;
            int[] minLens = new int[arr.Length];
            int minLen = infinity;
            for (int i = 0; i < minLens.Length; i++)
                minLens[i] = infinity;
            for (int end = 0; end < arr.Length; end++)
            {
                sum += arr[end];
                while (sum > target)
                    sum -= arr[start++];
                if (sum == target)
                {
                    int len = end - start + 1;
                    if (start > 0 && minLens[start - 1] != infinity)
                        res = Math.Min(res, len + minLens[start - 1]);
                    minLen = Math.Min(len, minLen);
                }
                minLens[end] = minLen;
            }
            return res >= infinity ? -1 : res;
        }

        static int MinSumOfLengths_PrefixSum(int[] arr, int target)
        {
            var dict = new Dictionary<int, int>();
            dict[0] = -1;
            var minLens = new int[arr.Length];
            for (int i = 0; i < minLens.Length; i++)
                minLens[i] = int.MaxValue;
            int res = int.MaxValue, minLen = int.MaxValue;
            int prefix = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                prefix += arr[i];
                dict[prefix] = i;
                if (dict.ContainsKey(prefix - target))
                {
                    int start = dict[prefix - target];
                    int len = i - start;
                    if (start >= 0 && minLens[start] != int.MaxValue)
                        res = Math.Min(res, len + minLens[start]);
                    minLen = Math.Min(minLen, len);
                }
                minLens[i] = minLen;
            }
            return res == int.MaxValue ? -1 : res;
        }
    }
}
