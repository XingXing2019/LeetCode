using System;
using System.Collections.Generic;

namespace NumberOfWonderfulSubstrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var word = "aba";
            Console.WriteLine(WonderfulSubstrings(word));
        }

        public static long WonderfulSubstrings(string word)
        {
            var dict = new Dictionary<int, long> { { 0, 1 } };
            var mask = 0;
            long res = 0;
            var valid = new HashSet<int> { 0 };
            for (int i = 0; i < 11; i++)
                valid.Add(1 << i);
            foreach (var l in word)
            {
                var temp = l - 'a';
                if (((mask >> temp) & 1) == 1)
                    mask -= 1 << temp;
                else
                    mask |= 1 << temp;
                foreach (var num in valid)
                {
                    if (!dict.ContainsKey(mask ^ num)) continue;
                    res += dict[mask ^ num];
                }
                if (!dict.ContainsKey(mask))
                    dict[mask] = 0;
                dict[mask]++;
            }
            return res;
        }
    }
}
