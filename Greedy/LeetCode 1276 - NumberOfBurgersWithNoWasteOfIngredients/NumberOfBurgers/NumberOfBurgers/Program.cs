
using System;
using System.Collections.Generic;

namespace NumberOfBurgers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static IList<int> NumOfBurgers(int tomatoSlices, int cheeseSlices)
        {
            var res = new List<int>();
            if (tomatoSlices - 2 * cheeseSlices < 0 || (tomatoSlices - 2 * cheeseSlices) % 2 != 0)
                return res;
            int jumbo = (tomatoSlices - 2 * cheeseSlices) / 2;
            int small = cheeseSlices - jumbo;
            if (jumbo < 0 || small < 0)
                return res;
            res.Add(jumbo);
            res.Add(small);
            return res;
        }
    }
}
