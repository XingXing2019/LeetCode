using System;
using System.Linq;

namespace MinimumRecolors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var blocks = "BBB";
            var k = 2;
            Console.WriteLine(MinimumRecolors(blocks, k));
        }

        public static int MinimumRecolors(string blocks, int k)
        {
            var res = int.MaxValue;
            for (int i = 0; i <= blocks.Length - k; i++)
                res = Math.Min(res, blocks.Substring(i, k).Count(x => x == 'W'));
            return res;
        }
    }
}
