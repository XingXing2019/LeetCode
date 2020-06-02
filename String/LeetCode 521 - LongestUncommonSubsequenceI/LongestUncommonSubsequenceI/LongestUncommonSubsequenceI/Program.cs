using System;

namespace LongestUncommonSubsequenceI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int FindLUSlength(string a, string b)
        {
            return a == b ? -1 : Math.Max(a.Length, b.Length);
        }
    }
}
