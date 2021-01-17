using System;
using System.Linq;

namespace NumberOfRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int CountGoodRectangles(int[][] rectangles)
        {
            return rectangles.Select(x => Math.Min(x[0], x[1])).GroupBy(x => x).OrderByDescending(x => x.Key).ToList()[0].Count();
        }
    }
}
