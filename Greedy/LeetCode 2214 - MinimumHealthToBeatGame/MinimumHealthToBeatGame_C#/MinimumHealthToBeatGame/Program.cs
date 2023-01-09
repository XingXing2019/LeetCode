using System;
using System.Linq;

namespace MinimumHealthToBeatGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long MinimumHealth(int[] damage, int armor)
        {
            var max = damage.Max();
            long res = 0;
            foreach (var d in damage)
            {
                if (d != max || armor == 0)
                    res += d;
                else
                {
                    res += Math.Max(0, d - armor);
                    armor = 0;
                }
            }
            return res + 1;
        }
    }
}
