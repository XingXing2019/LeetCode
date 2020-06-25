//字典按照key排序
using System;
using System.Collections.Generic;
using System.Linq;

namespace HandOfStraights
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hand = {1, 2, 3, 6, 2, 3, 4, 7, 8};
            int W = 3;
            Console.WriteLine(IsNStraightHand(hand, W));
        }
        static bool IsNStraightHand(int[] hand, int W)
        {
            if (hand.Length % W != 0) return false;
            var dict = new Dictionary<int, int>();
            foreach (var num in hand)
            {
                if (!dict.ContainsKey(num))
                    dict[num] = 1;
                else
                    dict[num]++;
            }
            dict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            while (dict.Count != 0)
            {
                int num = dict.First(x => x.Value > 0).Key;
                int count = dict[num];
                for (int i = 0; i < W; i++)
                {
                    if (!dict.ContainsKey(num + i)) return false;
                    dict[num + i] -= count;
                    if (dict[num + i] < 0) return false;
                    if (dict[num + i] == 0) dict.Remove(num + i);
                }
            }
            return true;
        }
    }
}
