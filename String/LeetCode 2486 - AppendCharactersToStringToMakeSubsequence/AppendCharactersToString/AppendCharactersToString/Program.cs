using System;

namespace AppendCharactersToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int AppendCharacters(string s, string t)
        {
            int p1 = 0, p2 = 0;
            while (p1 < s.Length && p2 < t.Length)
            {
                if (s[p1] == t[p2])
                    p2++;
                p1++;
            }
            return t.Length - p2;
        }
    }
}
