using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestPalindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int LongestPalindrome(string[] words)
        {
            int res = 0, mid = 0;
            var dict = words.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var set = new HashSet<string>();
            foreach (var key in dict.Keys)
            {
                if (key[0] == key[1])
                {
                    res += dict[key] / 2 * 4;
                    if (dict[key] % 2 != 0)
                        mid = 2;
                }
                else
                {
                    var pair = key[1].ToString() + key[0];
                    if (!dict.ContainsKey(pair) || set.Contains(pair)) continue;
                    res += Math.Min(dict[key], dict[pair]) * 4;
                    set.Add(key);
                }
            }
            return res + mid;
        }
    }
}
