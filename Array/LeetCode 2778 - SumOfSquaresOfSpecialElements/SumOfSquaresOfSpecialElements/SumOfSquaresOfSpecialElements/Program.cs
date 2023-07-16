using System;
using System.Linq;

namespace SumOfSquaresOfSpecialElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int SumOfSquares(int[] nums)
        {
            return nums.Where((x, i) => nums.Length % (i + 1) == 0).Sum(x => x * x);
        }
    }
}
