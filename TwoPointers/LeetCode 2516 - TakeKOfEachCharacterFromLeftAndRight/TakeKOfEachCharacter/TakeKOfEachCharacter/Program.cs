using System;
using System.Linq;

namespace TakeKOfEachCharacter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "aabaaaacaabc";
            var k = 2;
            Console.WriteLine(TakeCharacters(s, k));
        }

        public static int TakeCharacters(string s, int k)
        {
            var letters = new int[3];
            foreach (var l in s)
                letters[l - 'a']++;
            if (letters.Any(x => x < k)) return -1;
            int li = 0, hi = 0, res = int.MaxValue;
            while (hi < s.Length)
            {
                letters[s[hi] - 'a']--;
                while (li <= hi && letters[s[hi] - 'a'] < k)
                    letters[s[li++] - 'a']++;
                res = Math.Min(res, s.Length - (hi - li + 1));
                hi++;
            }
            return res;
        }
    }
}
