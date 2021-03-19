using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CountPairsOfEqualSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstString = "ab", secondString = "cd";
            Console.WriteLine(CountQuadruples_Array(firstString, secondString));
        }

        public static int CountQuadruples_Dict(string firstString, string secondString)
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

        public static int CountQuadruples_Array(string firstString, string secondString)
        {
            var first = new int[26];
            Array.Fill(first, int.MaxValue);
            var last = new int[26];
            Array.Fill(last, int.MaxValue);
            for (int i = firstString.Length - 1; i >= 0; i--)
                first[firstString[i] - 'a'] = i;
            for (int i = 0; i < secondString.Length; i++)
                last[secondString[i] - 'a'] = i;
            int min = int.MaxValue;
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] == int.MaxValue || last[i] == int.MaxValue)
                {
                    first[i] = int.MaxValue;
                    last[i] = int.MaxValue;
                    continue;
                }
                first[i] -= last[i];
                min = Math.Min(min, first[i]);
            }
            return min == int.MaxValue ? 0 : first.Count(x => x == min);
        }
    }
}
