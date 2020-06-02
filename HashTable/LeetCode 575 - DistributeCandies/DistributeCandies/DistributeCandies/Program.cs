//创建kinds字典记录每种糖的个数。
//遍历candies数组，如果当前元素不存在与kinds中，则将其与1加入kinds。否则时其在kinds中对应的个数加一。
//最后返回candies长度一半与kinds中个数两个值中较小的一个。
using System;
using System.Collections.Generic;

namespace DistributeCandies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int DistributeCandies(int[] candies)
        {
            Dictionary<int, int> kinds = new Dictionary<int, int>();
            foreach (var candy in candies)
            {
                if (!kinds.ContainsKey(candy))
                    kinds.Add(candy, 1);
                else
                    kinds[candy]++;
            }
            return Math.Min(candies.Length / 2, kinds.Count);
        }
    }
}
