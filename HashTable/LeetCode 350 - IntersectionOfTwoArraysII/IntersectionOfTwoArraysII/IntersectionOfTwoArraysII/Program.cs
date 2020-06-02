//创建字典Key为int，Value为int[]，用于统计两个数组中共同数组在两个数组中分别出现的次数。
//将共同数字，重复较小次数计入结果。
using System;
using System.Collections.Generic;

namespace IntersectionOfTwoArraysII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = {  };
            int[] nums2 = { 9, 4, 9, 8, 4 };
            Console.WriteLine(Intersect(nums1, nums2));
        }
        static int[] Intersect(int[] nums1, int[] nums2)
        {
            var dict = new Dictionary<int, int[]>();
            foreach (var num in nums1)
            {
                if (!dict.ContainsKey(num))
                    dict[num] = new int[2] { 1, 0 };
                else
                    dict[num][0]++;
            }
            foreach (var num in nums2)
            {
                if (dict.ContainsKey(num))
                    dict[num][1]++;
            }
            var tem = new List<int>();
            foreach (var kv in dict)
                if(kv.Value[1] != 0)
                    for (int i = 0; i < Math.Min(kv.Value[0], kv.Value[1]); i++)
                        tem.Add(kv.Key);
            return tem.ToArray();
        }
    }
}
