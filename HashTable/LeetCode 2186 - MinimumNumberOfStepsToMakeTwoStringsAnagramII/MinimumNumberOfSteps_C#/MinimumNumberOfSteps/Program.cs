using System;

namespace MinimumNumberOfSteps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinSteps(string s, string t)
        {
            var letters1 = new int[26];
            var letters2 = new int[26];
            foreach (var letter in s)
                letters1[letter - 'a']++;
            foreach (var letter in t)
                letters2[letter - 'a']++;
            var res = 0;
            for (int i = 0; i < 26; i++)
                res += Math.Abs(letters1[i] - letters2[i]);
            return res;
        }
    }
}
