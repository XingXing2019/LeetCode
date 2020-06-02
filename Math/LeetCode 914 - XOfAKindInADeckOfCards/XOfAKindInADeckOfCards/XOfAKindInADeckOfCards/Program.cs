//统计deck每个数字的个数，并找出出现次数最少的个数。如果这个最少个数小于2，则返回false。
//否则检查其余数字出现的个数是否与这个最小个数有公约数。如果没有则返回false。如果都有公约数，返回true。
using System;
using System.Collections.Generic;
using System.Linq;

namespace XOfAKindInADeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] deck = { 1, 2, 3, 4, 4, 3, 2, 1 };
            Console.WriteLine(HasGroupsSizeX(deck));
        }
        static bool HasGroupsSizeX(int[] deck)
        {
            var record = new Dictionary<int, int>();
            foreach (var card in deck)
            {
                if (!record.ContainsKey(card))
                    record[card] = 1;
                else
                    record[card]++;
            }
            var counts = record.Select(r => r.Value).ToList();
            var min = counts.Min(c => c);
            if (min < 2)
                return false;
            for (int i = 0; i < counts.Count; i++)
                for (int j = i + 1; j < counts.Count; j++)
                    if (!HasCommonDivisor(counts[i], counts[j]))
                        return false;
            return true;
        }
        static bool HasCommonDivisor(int n1, int n2)
        {
            for (int i = 2; i <= Math.Min(n1, n2); i++)
                if (n1 % i == 0 && n2 % i == 0)
                    return true;
            return false;
        }
    }
}
