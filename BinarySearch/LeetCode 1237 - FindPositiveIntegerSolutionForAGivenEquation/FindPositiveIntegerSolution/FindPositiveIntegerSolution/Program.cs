using System;
using System.Collections.Generic;

namespace FindPositiveIntegerSolution
{
    public class CustomFunction
    {
        // Returns f(x, y) for any given positive integers x and y.
        // Note that f(x, y) is increasing with respect to both x and y.
        // i.e. f(x, y) < f(x + 1, y), f(x, y) < f(x, y + 1)
        public int f(int x, int y)
        {
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<IList<int>> FindSolution(CustomFunction customfunction, int z)
        {
            int x = 1, y = 1000;
            var res = new List<IList<int>>();
            while (x <= 1000 && y >= 1)
            {
                if (customfunction.f(x, y) == z)
                {
                    res.Add(new List<int> { x, y });
                    x++;
                }
                else if (customfunction.f(x, y) < z)
                    x++;
                else
                    y--;
            }
            return res;
        }
    }
}
