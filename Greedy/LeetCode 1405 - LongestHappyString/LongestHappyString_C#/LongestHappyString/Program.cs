using System;
using System.Collections.Generic;
using System.Text;

namespace LongestHappyString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 1, c = 7;
            Console.WriteLine(LongestDiverseString(a, b, c));
        }
        public static string LongestDiverseString(int a, int b, int c)
        {
            var max = Math.Max(a, Math.Max(b, c));
            var main = max == a ? 'a' : max == b ? 'b' : 'c';
            var filling = max == a
                ? $"{new string('b', b)}{new string('c', c)}"
                : max == b ? $"{new string('a', a)}{new string('c', c)}" : $"{new string('a', a)}{new string('b', b)}";
            var count1 = Math.Min(max, filling.Length);
            var count2 = Math.Min(max, count1 + 1);
            max = Math.Min(max, count2 * 2);
            var gaps = new string[count1];
            var mains = new string[count2];
            int p1 = 0, p2 = 0;
            for (int i = 0; i < filling.Length; i++)
                gaps[p1++ % count1] += filling[i];
            for (int i = 0; i < max; i++)
                mains[p2++ % count2] += main;
            p1 = 0;
            p2 = 0;
            var res = new StringBuilder();
            while (p1 < gaps.Length && p2 < mains.Length)
            {
                res.Append(mains[p2++]);
                res.Append(gaps[p1++]);
            }
            if (p2 != mains.Length) res.Append(mains[p2]);
            return res.ToString();
        }
    }
}
