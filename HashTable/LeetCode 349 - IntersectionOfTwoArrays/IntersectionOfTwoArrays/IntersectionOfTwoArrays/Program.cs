//创建dict字典记录nums1中出现的数字，先将字典的value设为false。再遍历nums2，如果字典中有当前数字，则将其设为true。
//利用linq将dict中value为true的生成一个数组，并返回。
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntersectionOfTwoArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { };
            int[] nums2 = { 9, 4, 9, 8, 4 };
            Console.WriteLine(Intersection(nums1, nums2));
        }
        static int[] Intersection(int[] nums1, int[] nums2)
        {
            var dict = new Dictionary<int, bool>();
            for (int i = 0; i < nums1.Length; i++)
                if (!dict.ContainsKey(nums1[i]))
                    dict[nums1[i]] = false;
            for (int i = 0; i < nums2.Length; i++)
                if (dict.ContainsKey(nums2[i]))
                    dict[nums2[i]] = true;
            return dict.Where(d => d.Value).Select(d => d.Key).ToArray();
        }
    }
}
