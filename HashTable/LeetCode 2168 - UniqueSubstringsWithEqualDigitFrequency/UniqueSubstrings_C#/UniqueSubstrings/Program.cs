
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniqueSubstrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "98920465371";
            Console.WriteLine(EqualDigitFrequency(s));
        }

        public static int EqualDigitFrequency(string s)
        {
            var res = new HashSet<string>();
            for (int i = 0; i < s.Length; i++)
            {
                var digits = new int[10];
                var subStr = new StringBuilder();
                for (int j = i; j < s.Length; j++)
                {
                    subStr.Append(s[j]);
                    digits[s[j] - '0']++;
                    var set = new HashSet<int>(digits);
                    if (set.Contains(0) && set.Count <= 2 || !set.Contains(0) && set.Count == 1)
                        res.Add(subStr.ToString());
                }
            }
            return res.Count;
        }
    }
}
