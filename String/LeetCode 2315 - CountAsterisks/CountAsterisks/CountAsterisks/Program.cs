using System;
using System.Linq;

namespace CountAsterisks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int CountAsterisks(string s)
        {
            var parts = s.Split('|');
            var res = 0;
            for (int i = 0; i < parts.Length; i++)
            {
                if (i % 2 != 0) continue;
                res += parts[i].Count(x => x == '*');
            }
            return res;
        }
    }
}
