using System;

namespace IsSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool IsSubsequence(string s, string t)
        {
            int tick = 0;
            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (; j < t.Length; j++)
                {
                    if(s[i] == t[j])
                    {
                        tick++;
                        j++;
                        break;
                    }
                }
            }
            return tick == s.Length;
        }
    }
}
