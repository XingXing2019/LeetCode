//创建record字典用于记录单词和其在数组中的位置。
//遍历list1，将每个单词记录在record中，字典的value设为一个array，第一个元素为当前单词在list1中的位置，第二个元素设为一个较大的值(2000)。
//遍历list2，如果当前单词在record中，则将其位置设为value数组中第二个元素。
//利用linq表达式找出record中value数组两个元素和的最小值。再将敷个条件的单词存入一个数组并返回。
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumIndexSumOfTwoLists
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] list1 = { "Shogun", "KFC", "Burger King" };
            string[] list2 = { "KFC", "Shogun", "Burger King" };
            Console.WriteLine(FindRestaurant(list1, list2));
        }
        static string[] FindRestaurant(string[] list1, string[] list2)
        {
            var record = new Dictionary<string, int[]>();
            for (int i = 0; i < list1.Length; i++)
                record[list1[i]] = new int[] { i, 2000};
            for (int i = 0; i < list2.Length; i++)
                if (record.ContainsKey(list2[i]))
                    record[list2[i]][1] = i;
            int minIndex = record.Min(kv => kv.Value[0] + kv.Value[1]);
            string[] res = record.Where(kv => kv.Value[0] + kv.Value[1] == minIndex).Select(kv => kv.Key).ToArray();
            return res;
        }
    }
}
