using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int CountGoodRectangles_Linq(int[][] rectangles)
        {
            return rectangles.Select(x => Math.Min(x[0], x[1])).GroupBy(x => x).OrderByDescending(x => x.Key).ToList()[0].Count();
        }
        public int CountGoodRectangles_HashTable(int[][] rectangles)
        {
            var dict = new Dictionary<int, int>();
            var max = 0;
            foreach (var rectangle in rectangles)
            {
                max = Math.Max(max, Math.Min(rectangle[0], rectangle[1]));
                if (!dict.ContainsKey(Math.Min(rectangle[0], rectangle[1])))
                    dict[Math.Min(rectangle[0], rectangle[1])] = 0;
                dict[Math.Min(rectangle[0], rectangle[1])]++;
            }
            return dict[max];
        }
    }
}
