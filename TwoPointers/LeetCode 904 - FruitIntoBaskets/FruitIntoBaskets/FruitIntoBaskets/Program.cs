//创建li和hi指针维护一个窗口。初始值指向数组第一个数字。创建count记录实时水果的数量，max记录最大水果的数量。创建fruits字典记录水果的种类和个数。
//遍历数组，如果当前hi指向数字不在fruits中。如果此时字典中水果数量小于2，则将当前数字加入fruits，并让hi指针前进一位，count加一。
//如果此时fruits中水果数量大于等于2，则应移动li指针，每移动一位，时其指向水果在fruits中的数量减一，同时count减一。直到有一种水果在fruits中的数量为0，并将这种水果从字典中去除。
//如果当前水果已经在字典中，则使其在字典中的数量加一，hi前进一位，同时count加一。
//每次将max更新为其与count中较大的值。
using System;
using System.Collections.Generic;

namespace FruitIntoBaskets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tree = { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 };
            Console.WriteLine(TotalFruit(tree));
        }
        static int TotalFruit(int[] tree)
        {
            int li = 0, hi = 0;
            int count = 0, max = 0;
            var fruits = new Dictionary<int, int>();
            while (hi < tree.Length)
            {
                if (!fruits.ContainsKey(tree[hi]))
                {
                    if(fruits.Count < 2)
                    {
                        fruits[tree[hi++]] = 1;
                        count++;
                    }
                    else
                    {
                        bool stop = false;
                        while (!stop)
                        {
                            fruits[tree[li++]]--;
                            count--;
                            foreach (var kv in fruits)
                            {
                                if(kv.Value == 0)
                                {
                                    stop = true;
                                    fruits.Remove(kv.Key);
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    fruits[tree[hi++]]++;
                    count++;
                }
                max = Math.Max(max, count);
            }
            return max;
        }
    }
}
