using System;

namespace MinimumCostToMakeAllCharactersEqual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long MinimumCost(string s)
        {
            long res = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1]) continue;
                res += Math.Min(i, s.Length - i);
            }
            return res;
        }
    }
}
