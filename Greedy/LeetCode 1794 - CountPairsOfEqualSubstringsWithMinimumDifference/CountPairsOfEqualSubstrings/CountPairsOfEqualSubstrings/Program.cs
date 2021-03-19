using System;
using System.Collections.Generic;
using System.Linq;

namespace CountPairsOfEqualSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstString = "ab", secondString = "cd";
            Console.WriteLine(CountQuadruples(firstString, secondString));
        }

        public static int CountQuadruples(string firstString, string secondString)
        {
            var first = new Dictionary<char, int>();
            var last = new Dictionary<char, int>();
            for (int i = firstString.Length - 1; i >= 0; i--)
                first[firstString[i]] = i;
            for (int i = 0; i < secondString.Length; i++)
                last[secondString[i]] = i;
            int min = int.MaxValue;
            var dict = new Dictionary<int, int>();
            foreach (var kv in first)
            {
                if (last.ContainsKey(kv.Key))
                {
                    int temp = kv.Value - last[kv.Key];
                    if (!dict.ContainsKey(temp))
                        dict[temp] = 0;
                    dict[temp]++;
                    min = Math.Min(min, temp);
                }
            }
            return dict.Count == 0 ? 0 : dict[min];
        }
    }
}
