//统计每个数字出现的频率记录入字典。将字典中数字的频率加入一个列表，在对列表排序。
//利用linq语句找出字典中频率大于等于列表中倒数第k个频率的数字。
using System;
using System.Collections.Generic;
using System.Linq;

namespace TopKFrequentElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1 };
            int k = 1;
            Console.WriteLine(TopKFrequent(nums, k));
        }
        static IList<int> TopKFrequent(int[] nums, int k)
        {
            var numFrequency = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!numFrequency.ContainsKey(num))
                    numFrequency[num] = 1;
                else
                    numFrequency[num]++;
            }
            var frequencyOrder = new List<int>();
            foreach (var kv in numFrequency)
                frequencyOrder.Add(kv.Value);
            frequencyOrder.Sort();
            int tem = frequencyOrder[frequencyOrder.Count - k];
            return numFrequency.Where(f => f.Value >= tem).Select(f => f.Key).ToList();
        }
    }
}
