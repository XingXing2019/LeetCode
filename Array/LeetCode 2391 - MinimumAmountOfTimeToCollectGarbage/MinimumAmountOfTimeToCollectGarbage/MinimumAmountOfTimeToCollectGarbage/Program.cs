using System;
using System.Linq;

namespace MinimumAmountOfTimeToCollectGarbage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int GarbageCollection(string[] garbage, int[] travel)
        {
            int g = 0, p = 0, m = 0;
            for (int i = garbage.Length - 1; i >= 0; i--)
            {
                foreach(var l in garbage[i])
                {
                    if (l == 'G') g++;
                    else if (l == 'P') p++;
                    else m++;
                }
                if (i == 0) continue;
                if (g > 0) g += travel[i - 1];
                if (p > 0) p += travel[i - 1];
                if (m > 0) m += travel[i - 1];
            }
            return g + p + m;
        }
    }
}
