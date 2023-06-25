using System;

namespace ConstructTheLongestNewString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int LongestString(int x, int y, int z)
        {
            return ((x == y ? x * 2 : Math.Min(x, y) * 2 + 1) + z) * 2;
        }
    }
}
