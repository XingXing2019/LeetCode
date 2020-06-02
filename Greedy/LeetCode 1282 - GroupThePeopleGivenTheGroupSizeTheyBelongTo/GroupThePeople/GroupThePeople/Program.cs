//先将具有相同groupsize的人分组存入字典。再遍历每个组划分为几个具有字典key大小的小组，存入结果。
using System;
using System.Collections.Generic;

namespace GroupThePeople
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] groupSizes = { 2,2 };
            Console.WriteLine(GroupThePeople(groupSizes));
        }
        static IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            var res = new List<IList<int>>();
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < groupSizes.Length; i++)
            {
                if (!dict.ContainsKey(groupSizes[i]))
                    dict[groupSizes[i]] = new List<int> { i };
                else
                    dict[groupSizes[i]].Add(i);
            }
            foreach (var kv in dict)
            {
                int count = kv.Value.Count / kv.Key;
                for (int i = 0; i < count; i++)
                {
                    var tem = new int[kv.Key];
                    kv.Value.CopyTo(i * kv.Key, tem, 0, kv.Key);
                    res.Add(tem);
                }
            }
            return res;
        }
    }
}
