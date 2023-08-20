using System;

namespace MakeStringASubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static bool CanMakeSubsequence(string str1, string str2)
        {
            int p1 = 0, p2 = 0;
            while (p1 < str1.Length && p2 < str2.Length)
            {
                var next = str1[p1] + 1 > 'z' ? 'a' : str1[p1] + 1;
                if (str1[p1] == str2[p2] || next == str2[p2])
                    p2++;
                p1++;
            }
            return p2 == str2.Length;
        }
    }
}
