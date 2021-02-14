using System;

namespace MinimumChanges
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MinOperations(string s)
        {
            var s1 = new int[s.Length];
            var s2 = new int[s.Length];
            for (int i = 0; i < s.Length; i += 2)
                s1[i] = 1;
            for (int i = 1; i < s.Length; i += 2)
                s2[i] = 1;
            int option1 = 0, option2 = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] - '0' != s1[i]) option1++;
                if (s[i] - '0' != s2[i]) option2++;
            }
            return Math.Min(option1, option2);
        }
    }
}
