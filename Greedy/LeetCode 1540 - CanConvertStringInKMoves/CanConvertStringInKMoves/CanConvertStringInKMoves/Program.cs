using System;
using System.Collections.Generic;

namespace CanConvertStringInKMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "mpzzwh", t = "kaeblv";
            int k = 24;
            Console.WriteLine(CanConvertString(s, t, k));
        }
        static bool CanConvertString(string s, string t, int k)
        {
            if (s.Length != t.Length) return false;
            var chances = new int[27];
            for (int i = 0; i < chances.Length; i++)
            {
                chances[i] += k / 26;
                if (k % 26 >= i)
                    chances[i]++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                int distance = t[i] - s[i];
                if (distance < 0)
                {
                    chances[26 + distance]--;
                    if (chances[26 + distance] < 0) return false;
                }
                else if (distance > 0)
                {
                    chances[distance]--;
                    if (chances[distance] < 0) return false;
                }
            }
            return true;
        }
    }
}
