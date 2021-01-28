//创建两个字典记录arr1和arr2中的数字及其出现次数。创建left列表记录arr1中没有在arr2中出现的数字。遍历arr1和arr2，将相应信息存入字典和列表
//创建index指针，辅助将数字计入res。遍历arr2，将其中出现的数字按顺序记录入res，并重复其在arr1中的次数。最后将left排序后存入res。
using System;
using System.Collections.Generic;

namespace RelativeSortArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 };
            int[] arr2 = { 2, 1, 4, 3, 9, 6 };
            Console.WriteLine(RelativeSortArray(arr1, arr2));
        }
        static int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            int[] res = new int[arr1.Length];
            var record1 = new Dictionary<int, int>();
            var record2 = new Dictionary<int, int>();
            var left = new List<int>();            
            for (int i = 0; i < arr2.Length; i++)
                record2[arr2[i]] = 1;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (!record2.ContainsKey(arr1[i]))
                    left.Add(arr1[i]);
                else
                {
                    if (!record1.ContainsKey(arr1[i]))
                        record1[arr1[i]] = 1;
                    else
                        record1[arr1[i]]++;
                }
            }
            int index = 0;
            for (int i = 0; i < arr2.Length; i++)
                for (int j = 0; j < record1[arr2[i]]; j++)
                    res[index++] = arr2[i];
            left.Sort();
            for (int i = 0; i < left.Count; i++)
                res[index++] = left[i];
            return res;
        }
    }
}
